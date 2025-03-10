using System;
using System.Collections;
using System.Collections.Generic;
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

public partial class Inf_ReportCCualitativa : System.Web.UI.Page
{
    DataSet Dscompleto;
    public string macroState1 = "collapse";
    public string macroState2 = "collapse";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IDusuario"] == null)
        {
            Response.Redirect("Salir.aspx");
        }

        if (Page.IsPostBack == false)
        {
            Datos sv = new Datos();
            if (!sv.ComValidaPaginaPerfil(int.Parse(Session["IdPerfil"].ToString()), Request.Url.Segments[Request.Url.Segments.Length - 1]))
            {
                Response.Redirect("Salir.aspx");
            }
            txtFechaI.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now.AddDays(-30));
            txtFechaF.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
            txtFechaInicial.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now.AddDays(-30));
            txtxFechaFinal.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);

            LLenarDatos();
        }
        else
        {
            Dscompleto = (DataSet)ViewState["DscompletoState"];
        }
    }

    private void LLenarDatos()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = sv.CualitativaSeleccion();
        ds.Tables[0].Rows.Add("-1", " Seleccione>>");
        this.CmbCalificacionCualitativa.DataSource = ds.Tables[0].DefaultView;
        this.CmbCalificacionCualitativa.SelectedValue = "-1";
        this.CmbCalificacionCualitativa.DataTextField = "NomCualitativa";
        this.CmbCalificacionCualitativa.DataValueField = "IdEncCualitativa";
        this.CmbCalificacionCualitativa.DataBind();
        ds.Clear();
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]

    public static List<string> SearchClients(string prefixText, int count, int IdPais)
    {
        Datos sv = new Datos();
        DataSet dsDatos = new DataSet();
        DataView vista = new DataView();
        List<string> list = new List<string>();

        dsDatos = sv.ListaEmpresasNit(prefixText.Trim(), IdPais);
        vista = dsDatos.Tables[0].DefaultView;
        vista.Sort = "RazonSocial ASC";

        DataTable dt = new DataTable();
        dt = vista.ToTable();



        for (int i = 0; i < dt.Rows.Count; i++)
        {
            list.Add(dt.Rows[i].ItemArray[0] + " - " + dt.Rows[i].ItemArray[1]);
        }



        return list;

    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();
        Funciones fun = new Funciones();
        String nit = "";
        int n;
        Boolean Seleccion = chkTodosActas.Checked;

        if (CmbCalificacionCualitativa.SelectedValue != "-1")
        {
            if (Seleccion == false)
            {
                var isNumber = int.TryParse(this.txtEmpre.Text.Trim().Split('-')[0], out n);

                if (this.txtEmpre.Text != "" && isNumber == true)
                {

                    nit = this.txtEmpre.Text.Trim().Split('-')[0];
                    ds = sv.SeCCualitativaXEmp(nit, int.Parse(CmbCalificacionCualitativa.SelectedValue), 1, fun.Cononica(txtFechaI.Text), fun.Cononica(txtFechaF.Text),1, Convert.ToInt32(Session["IdPais"].ToString()));

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ExportaExcel(ds);
                    }
                }
                else
                {
                    Response.Write("<script>alert('Debe seleccionar una empresa o un grupo empresarial')</script>");
                }
            }
            else
            {
                ds = sv.SeCCualitativaXEmp("", int.Parse(CmbCalificacionCualitativa.SelectedValue), 2, fun.Cononica(txtFechaI.Text), fun.Cononica(txtFechaF.Text),1, Convert.ToInt32(Session["IdPais"].ToString()));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ExportaExcel(ds);

                }
            }
        }
        else
        {
            Response.Write("<script>alert('Debe seleccionar un tipo de encuesta')</script>");
        }

        macroState1 = "in";
    }

    protected void BtnBuscaCualitativa_Click(object sender, EventArgs e)
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();
        Funciones fun = new Funciones();
        ds = sv.SeCCualitativaXEmp("", int.Parse(CmbCalificacionCualitativa.SelectedValue), 2, fun.Cononica(txtFechaI.Text), fun.Cononica(txtFechaF.Text),2, Convert.ToInt32(Session["IdPais"].ToString()));
        if (ds.Tables[0].Rows.Count > 0)
        {
            ExportaExcel(ds);

        }




        macroState2 = "in";
    }

    protected void LimpiarInfo()
    {
        chkTodosActas.Checked = false;
        txtEmpre.Text = "";
    }

    public void ExportaExcel(DataSet Datos)
    {
        LimpiarInfo();
        Funciones fun = new Funciones();
        string filename;
        if (Datos.Tables[0].Rows.Count > 0)
        {

            if (fun.ExportExcellDataset(int.Parse(Session["IDusuario"].ToString()), Datos, Request.ServerVariables["APPL_PHYSICAL_PATH"]))
            {

                filename = "Report" + Session["IDusuario"].ToString() + ".xls";

                string filepath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Archivos\Datos\" + filename;

                filename = "Report.xls";
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                Response.Flush();
                Response.WriteFile(filepath);
                //  Response.SuppressContent = true;
                ApplicationInstance.CompleteRequest();


            }


            Datos.Clear();
        }
    }

    protected void chkTodosActas_CheckedChanged(object sender, EventArgs e)
    {
        if (chkTodosActas.Checked == true)
        {
            txtEmpre.Enabled = false;
            txtEmpre.Text = "";
        }
        else
        {
            txtEmpre.Enabled = true;
            txtEmpre.Text = "";
        }
        macroState1 = "in";
    }
}