using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;

public partial class Inf_SectoresIndicadores : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Page.IsPostBack == false)
        {

            if (Session["IDusuario"] == null)
            {
                Response.Redirect("Salir.aspx");
            }

            llenardatos();
            GrillaLlenar();

        }



    }

    private void llenardatos()
    {

        Datos sv = new Datos();
        DataView vista = new DataView();
        DataSet ds = new DataSet();


        ds = sv.ComSectores(0, 1, Convert.ToInt32(Session["IdPais"].ToString()));
        vista = ds.Tables[0].DefaultView;
        vista.Sort = "Sector ASC";

        this.cmbSector.DataSource = vista;
        this.cmbSector.DataTextField = "Sector";
        this.cmbSector.DataValueField = "IdSector";
        this.cmbSector.DataBind();
        ds.Clear();




        ds = sv.GCredVegencia(Convert.ToInt32(Session["IdPais"].ToString()), 1);

        this.CmbVigencia.DataSource = ds.Tables[0].DefaultView;
        this.CmbVigencia.DataTextField = "Anio";
        this.CmbVigencia.DataValueField = "Anio";
        this.CmbVigencia.DataBind();

        ds.Clear();


    }

    protected void CmbAgregado_SelectedIndexChanged(object sender, EventArgs e)
    {
        GrillaLlenar();
    }

    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        System.IO.StringWriter sw = new System.IO.StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        Page page = new Page();
        HtmlForm form = new HtmlForm();

        // Deshabilitar la validación de eventos, sólo asp.net 2
        page.EnableEventValidation = false;

        // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
        page.DesignerInitialize();

        page.Controls.Add(form);
        form.Controls.Add(GridLista);

        page.RenderControl(htw);

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=data.xls");
        Response.Charset = "UTF-8";
        Response.ContentEncoding = Encoding.Default;
        Response.Write(sb.ToString());
        
        ApplicationInstance.CompleteRequest();


    }

    private void GrillaLlenar()
    {

        Datos sv = new Datos();
        DataSet DataS = new DataSet();

        DataS = sv.IndicadoresSectorAnio(int.Parse(this.cmbSector.SelectedValue), 1, Boolean.Parse(this.CmbAgregado.SelectedValue), 
            int.Parse(this.CmbVigencia.SelectedValue), int.Parse(Session["IdPais"].ToString()));


        int cuantos = 0;
        int j = 0;
        int i = 0;


        cuantos = DataS.Tables[0].Columns.Count;


        DataTable dt = new DataTable();
        DataRow dr;



        dt.Columns.Add(new DataColumn("INDICADORES", typeof(string)));
        dt.Columns.Add(new DataColumn("Total", typeof(string)));
        dt.Columns.Add(new DataColumn("ValorPyme", typeof(string)));
        dt.Columns.Add(new DataColumn("ValorEmpresarial", typeof(string)));
        dt.Columns.Add(new DataColumn("ValorCooporativo", typeof(string)));



        string titulo = "0";

        for (i = 0; i < DataS.Tables[0].Rows.Count; i++)
        {
            dr = dt.NewRow();
            if (titulo.Trim() != DataS.Tables[0].Rows[i][8].ToString().Trim())
            {
                dr["INDICADORES"] = DataS.Tables[0].Rows[i][8].ToString().Trim().ToUpper();
                titulo = DataS.Tables[0].Rows[i][8].ToString().Trim();
                dt.Rows.Add(dr);
                dr = dt.NewRow();

            }

            dr["INDICADORES"] = DataS.Tables[0].Rows[i][1];

            for (j = 2; j < 6; j++)
            {
                if (object.ReferenceEquals(DataS.Tables[0].Rows[i][j], DBNull.Value))
                {
                    dr[DataS.Tables[0].Columns[j].ColumnName] = "-";
                }
                else
                {
                    dr[DataS.Tables[0].Columns[j].ColumnName] = DataS.Tables[0].Rows[i][6].ToString() + String.Format("{0:N}", DataS.Tables[0].Rows[i][j]) + DataS.Tables[0].Rows[i][7].ToString();

                }
            }


            dt.Rows.Add(dr);
        }

        //Eliminar Columnas Actuales(Opcional):
        //GridLista.Columns.Clear();

        GridLista.DataSource = dt;

        GridLista.DataBind();

        if (GridLista.Rows.Count > 0)
        {
            string texto = null;

            GridLista.HeaderRow.HorizontalAlign = HorizontalAlign.Center;

            GridLista.ControlStyle.Font.Size = 10;

            GridLista.Rows[0].ControlStyle.BackColor = System.Drawing.Color.Gray;
            GridLista.Rows[0].ControlStyle.Font.Size = 10;
            GridLista.Rows[0].ControlStyle.Font.Bold = true;


            for (j = 0; j < GridLista.Rows.Count; j++)
            {
                for (i = 1; i < dt.Columns.Count; i++)
                {

                    GridLista.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Right;

                }
            }

            for (i = 0; i < GridLista.Rows.Count; i++)
            {
                texto = GridLista.Rows[i].Cells[0].Text.Trim();
                switch (texto)
                {
                    case "P&G":
                    case "BALANCE":
                    case "ENDEUDAMIENTO":
                    case "EFICIENCIA":
                    case "LIQUIDEZ":
                    case "Z-SCORE":
                    case "COBERTURA":
                        GridLista.Rows[i].ControlStyle.BackColor = System.Drawing.Color.Gray;
                        GridLista.Rows[i].ControlStyle.Font.Size = 11;
                        GridLista.Rows[i].ControlStyle.Font.Bold = true;

                        //GridLista.Rows[i].Cells[0]. = false;

                        break;
                }
            }
        }


        DataS.Clear();

    }

    protected void cmbSector_SelectedIndexChanged(object sender, EventArgs e)
    {
        GrillaLlenar();
    }

    protected void CmbVigencia_SelectedIndexChanged(object sender, EventArgs e)
    {
        GrillaLlenar();
    }
}