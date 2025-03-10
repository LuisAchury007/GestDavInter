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
using System.IO;
using System.Data.OleDb;
using System.Drawing;
using CarlosAg.ExcelXmlWriter;
using System.Text.RegularExpressions;


public partial class CredDescargarModelo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IDusuario"] == null)
        {
            Response.Redirect("Salir.aspx");
        }

        if (Page.IsPostBack == false)
        {
            LLenardatos();
        }
    }

    protected void Page_PreRender(object sender, System.EventArgs e)
    {

    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        Datos sv = new Datos();

  //      DataSet ds = new DataSet();
        string NITBusqueda = "";
   
       
        if (txtRazonSocial.Text != "" || txtNIT.Text != "") 
        {
            if (txtNIT.Text != "")
            {
                NITBusqueda = this.txtNIT.Text;
            }

            LlenarLista();
    //        ds = sv.GcredEmpresaDatosPorRazonSocial(NITBusqueda, txtRazonSocial.Text, Convert.ToInt32(Session["IdPais"].ToString()));
        }
        else
        {
            Response.Write("<script>alert('Digite un valor númerico en el campo No. Documento y/o un valor en el campo razón social. \n ¡Favor revisar!')</script>");
            txtNIT.Text = "";
        }

    }

    protected void GridNITPlantilla_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string NITDescarga;
        Datos sv = new Datos();
        DataTable dtCurrentTable = (DataTable)ViewState["ConsecutivosEditables"];

        switch (e.CommandName)
        {
            case "Descargar":
                string Cadena;

                NITDescarga = e.CommandArgument.ToString();
                Cadena = sv.ExisteConversionNit(Convert.ToInt32(Session["IdPais"].ToString()), NITDescarga, int.Parse(this.cmbDivisa.SelectedValue));

                if (Cadena.Length == 0)
                    DescargarArchivo(NITDescarga);
                else
                {
                    Response.Write("<script>alert('La Divisa:"+ this.cmbDivisa.SelectedItem +" No tiene Tasa de Conversion para el periodo: "+ Cadena + " ')</script>");
                }


                break;
        }
    }

    private void LlenarLista()
    {
        Datos sv = new Datos();

        DataSet dsDatos;
        string NIT = "";
        if (txtNIT.Text != "")
        {
            NIT = this.txtNIT.Text;
        }
        dsDatos = sv.GcredEmpresaDatosPorRazonSocialLista(NIT, txtRazonSocial.Text, Convert.ToInt32(Session["IdPais"].ToString()));
        GridNITPlantilla.DataSource = dsDatos;
        GridNITPlantilla.DataBind();
        if (dsDatos.Tables[0].Rows.Count == 0)
        {
            txtNIT.Text = "";
            txtRazonSocial.Text = "";
            lblCantidadCoincTexto.Visible = false;
            lblCantidadCoincInfo.Visible = false;
        }
        else
        {
            lblCantidadCoincTexto.Visible = true;
            lblCantidadCoincInfo.Visible = true;
            lblCantidadCoincInfo.Text = dsDatos.Tables[0].Rows.Count.ToString();
        }

    }

    private void DescargarArchivo(String NITDescarga)
    {

        Funciones fun = new Funciones();
        string filename;
        string path = Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Archivos\Modelo\" + Session["IdPais"].ToString() + @"\";
        filename = "Modelo" + NITDescarga + "_" + Session["IDusuario"].ToString() + ".xlsm";

        string targetPath = path +  "\\Generados\\";
        string sourceFile = System.IO.Path.Combine(path, "Modelo.xlsm");
        string destFile = System.IO.Path.Combine(targetPath, filename);

        System.IO.File.Copy(sourceFile, destFile, true);

        if (fun.CrearCaratula(NITDescarga, destFile, true, Convert.ToInt32(Session["IdPais"].ToString()), Convert.ToInt32(this.cmbDivisa.SelectedValue), this.cmbDivisa.SelectedItem.ToString(), Session["Pais"].ToString()))
        {
            string filepath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Archivos\" + Session["Carpeta"] + @"\Modelo\" + Session["IdPais"].ToString() + @"\Generados\" + filename;

            FileInfo fi = new FileInfo(filepath);
            long sz = fi.Length;

            filename = "Modelo" + NITDescarga + ".xlsm";
            Response.Clear();
            Response.ClearContent();
            Response.ContentType = "application/vnd.ms-excel.sheet.macroEnabled.12";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.AddHeader("Content-Length", sz.ToString("F0"));
            Response.TransmitFile(filepath);

            Response.Flush();
            
            ApplicationInstance.CompleteRequest();

            txtNIT.Text = "";
            txtRazonSocial.Text = "";
        }

    }

    private void LLenardatos()
    {
        Datos sv = new Datos();

        DataSet ds = new DataSet();

        //ds = sv.SeGrupoEmpresarial(0, 3, "");

        //this.CmbGrupos.DataSource = ds.Tables[0].DefaultView;
        //this.CmbGrupos.DataTextField = "GrupoEmpresarial";
        //this.CmbGrupos.DataValueField = "IdGrupoEm";
        //this.CmbGrupos.DataBind();

        //ds.Clear();

        ds = sv.DivisaLista(0, 1);

        this.cmbDivisa.DataSource = ds.Tables[0].DefaultView;
        this.cmbDivisa.DataTextField = "divisa";
        this.cmbDivisa.DataValueField = "IdDivisa";
        this.cmbDivisa.DataBind();

        this.cmbDivisa.SelectedValue = Session["Divisa"].ToString();


    }

    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    Datos sv = new Datos();

    //    DataSet ds = new DataSet();

    //    ds = sv.SeGrupoEmpxEmpresas(int.Parse(this.CmbGrupos.SelectedValue.ToString()), 2, Convert.ToInt32(Session["IdPais"].ToString()));

    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        Funciones fun = new Funciones();
    //        string filename;
    //        string path = Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Archivos\Modelo\" + Session["IdPais"].ToString() + @"\";
    //        filename = "Modelo" + this.CmbGrupos.SelectedValue + Session["IDusuario"].ToString() + ".xlsm";

    //        string targetPath = path + "Generados\\";
    //        string sourceFile = System.IO.Path.Combine(path, "Modelo.xlsm");
    //        string destFile = System.IO.Path.Combine(targetPath, filename);

    //        System.IO.File.Copy(sourceFile, destFile, true);

    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            fun.CrearCaratula(ds.Tables[0].Rows[i]["NIT"].ToString(), destFile, true, Convert.ToInt32(Session["IdPais"].ToString()), Convert.ToInt32(this.cmbDivisa.SelectedValue), this.cmbDivisa.SelectedItem.ToString());
    //        }

    //        string filepath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Archivos\" + Session["Carpeta"] + @"\Modelo\"+ Session["IdPais"].ToString() + @"\Generados\" + filename;

    //        FileInfo fi = new FileInfo(filepath);
    //        long sz = fi.Length;

    //        filename = "Modelo" + this.CmbGrupos.SelectedValue + ".xlsm";
    //        Response.Clear();
    //        Response.ClearContent();
    //        Response.ContentType = "application/vnd.ms-excel.sheet.macroEnabled.12";
    //        Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
    //        Response.AddHeader("Content-Length", sz.ToString("F0"));
    //        Response.TransmitFile(filepath);

    //        Response.Flush();
            
    //        ApplicationInstance.CompleteRequest();
    //    }
    //    else
    //    {
    //        Response.Write("<script>alert('Grupo Empresarial No Posee Empresas')</script>");
    //    }

    //}
}