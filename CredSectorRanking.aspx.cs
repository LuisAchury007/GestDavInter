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
using Encoder = Microsoft.Security.Application.Encoder;

public partial class BencSectorRanking : System.Web.UI.Page
{

    DataSet Dscompleto;
    double[] lista;


    int IdIndicador;

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Request["IdIndicador"] != null))
        {
            IdIndicador = int.Parse(Request["IdIndicador"]);
        }
        else
        {
            IdIndicador = 90001;
        }



        if (Page.IsPostBack == false)
        {
            LlenarDatos();
            GrillaLlenar();
        }
        else
        {
            llenarlista();
            Dscompleto = (DataSet)ViewState["DscompletoState"];
            GridLista.DataSource = Dscompleto.Tables[0];
            GridLista.DataBind();

        }

    }

    public void llenarlista()
    {
        int i = 0;
        int contador = 1;
        for (i = 0; i < this.GridLista.Rows.Count; i++)
        {
            //En la posición 13 es en donde se encuentra el control Check.
            if (((CheckBox)this.GridLista.Rows[i].Cells[0].Controls[1]).Checked)
            {
                Array.Resize(ref lista, (contador));
                lista[contador - 1] = double.Parse(this.GridLista.Rows[i].Cells[1].Text);
                contador += 1;
            }
        }

    }

    protected void Page_PreRender(object sender, System.EventArgs e)
    {
        this.ViewState.Add("DscompletoState", Dscompleto);
    }

    private void LlenarDatos()
    {

        Datos sv = new Datos();
        DataSet DataS = new DataSet();

        DataS = sv.CredIndicadores(1);

        this.CmbIndicadores.DataSource = DataS.Tables[0].DefaultView;
        this.CmbIndicadores.DataTextField = "Diminutivo";
        this.CmbIndicadores.DataValueField = "IdIndicador";
        this.CmbIndicadores.DataBind();

        this.CmbIndicadores.SelectedValue = IdIndicador.ToString();


        DataS.Clear();



    }

    private void GrillaLlenar()
    {

        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = sv.CredRankingSector(int.Parse(Encoder.HtmlEncode(Request.QueryString["IdSector"])), int.Parse(this.CmbIndicadores.SelectedValue));



        int cuantos = 0;
        int i = 0;

        cuantos = ds.Tables[0].Columns.Count;

        if (this.GridLista.Columns.Count < 4)
        {
            for (i = 2; i < cuantos; i++)
            {

                BoundField lobColumnBound;

                //Crear Columna:
                lobColumnBound = new BoundField();
                lobColumnBound.DataField = ds.Tables[0].Columns[i].ColumnName;  // del Origen de datos
                lobColumnBound.HeaderText = ds.Tables[0].Columns[i].ColumnName;
                lobColumnBound.SortExpression = ds.Tables[0].Columns[i].ColumnName;
                lobColumnBound.ItemStyle.HorizontalAlign = HorizontalAlign.Right;

                if (i % 2 == 1)
                {
                    lobColumnBound.DataFormatString = "{0:N}";
                }



                GridLista.Columns.Add(lobColumnBound);

            }
        }


        GridLista.DataSource = ds.Tables[0].DefaultView;
        GridLista.DataBind();
        Dscompleto = new DataSet();
        Dscompleto = ds;
        // ds.Clear();





    }

    protected void CmbIndicadores_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("CredSectorRanking.aspx?IdSector=" + Request["IdSector"] + "&NombreSec=" + Request["NombreSec"] + "&IdIndicador=" + this.CmbIndicadores.SelectedValue);
    }

    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        System.IO.StringWriter sw = new System.IO.StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        Page page = new Page();
        HtmlForm form = new HtmlForm();

        #region "Manejar paginación de la grilla | Agustín David Cruz González (16/Jul/2014)."

        GridLista.AllowPaging = false; //Se establece AllowPaging en false para obtener todos los registros de la grilla y no solo los de la hoja actual.
        GridLista.DataBind(); //Se enlaza la grilla con el origen de datos
        GridLista.EnableViewState = true; //Mantener el estado actual de la grilla.
        GridLista.Columns[0].Visible = false; // Ocultar columna de checks para no exportarla.

        #endregion

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

        Response.Cache.SetCacheability(HttpCacheability.NoCache); // Se deshabilita el cache | Agustín David Cruz González (16/Jul/2014).

        Response.ContentEncoding = Encoding.Default;
        Response.Write(sb.ToString());
        
        ApplicationInstance.CompleteRequest();

        #region "Dejar la grilla como estaba | Agustín David Cruz González (16/Jul/2014)."

        GridLista.AllowPaging = true; // Se vuelve a dejar la grilla en el estado original de paginación (AllowPaging = true)
        GridLista.DataBind(); // Se vuelve a enlazar la grilla.

        #endregion
    }

    public string GridViewSortDirection
    {

        get
        {
            object o = ViewState["SortDirection"];
            return ((o == null) ? "ASC" : Convert.ToString(o));
        }
        set { ViewState["SortDirection"] = value; }
    }

    public string GridViewSortExpression
    {
        get
        {
            object o = ViewState["SortExpression"];
            return ((o == null) ? string.Empty : Convert.ToString(o));
        }
        set { ViewState["SortExpression"] = value; }
    }

    protected string GetSortDirection()
    {
        switch ((GridViewSortDirection))
        {

            case "ASC":
                GridViewSortDirection = "DESC";

                break;
            case "DESC":
                GridViewSortDirection = "ASC";

                break;
        }

        return GridViewSortDirection;

    }

    protected void Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataTable dataTable = GridLista.DataSource as DataTable;
        DataView dataView = new DataView(dataTable);


        GridLista.DataSource = SortDataTable(dataView, true);
        // Calculate the current page number. 
        GridLista.PageIndex = e.NewPageIndex;


        // Reset selected index 
        GridLista.SelectedIndex = -1;

        GridLista.DataBind();
        // Identificar en qué página estás
        int currentPageIndex = e.NewPageIndex + 1; // Sumar 1 porque los índices comienzan en 0
        Label1.Text = "Página actual: " + currentPageIndex.ToString();

    }

    protected DataView SortDataTable(DataView DataTable1, bool isPageIndexChanging)
    {
        if ((DataTable1 != null))
        {
            DataView vista = DataTable1;


            if ((!string.IsNullOrEmpty(GridViewSortExpression)))
            {
                if ((isPageIndexChanging))
                {
                    vista.Sort = GridViewSortExpression + " " + GridViewSortDirection;
                }
                else
                {
                    vista.Sort = GridViewSortExpression + " " + GetSortDirection();

                }
            }
            return vista;
        }
        else
        {
            return new DataView();
        }
    }

    protected void Grid_Sorting(object sender, System.Web.UI.WebControls.GridViewSortEventArgs e)
    {
        DataTable dataTable = GridLista.DataSource as DataTable;


        DataView dataView = new DataView(dataTable);

        GridViewSortExpression = e.SortExpression;
        int pageIndex = GridLista.PageIndex;
        GridLista.DataSource = SortDataTable(dataView, false);
        GridLista.DataBind();
        GridLista.PageIndex = pageIndex;


    }

}
