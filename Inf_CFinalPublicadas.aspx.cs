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
using CarlosAg.ExcelXmlWriter;
using System.Text.RegularExpressions;
using System.IO;

public partial class Inf_CFinalPublicadas : System.Web.UI.Page
{
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

            LLenardatos();

        }


    }

    protected void Button1_Click(object sender, EventArgs e)
    {


        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = sv.CredCfinalPublicaInfo(0, int.Parse(this.CmbPeriodos.SelectedValue), "", Convert.ToInt32(Session["IdPais"].ToString()));

        Funciones fun = new Funciones();
        string filename;


        if (fun.ExportExcellDataset(int.Parse(Session["IDusuario"].ToString()), ds, Request.ServerVariables["APPL_PHYSICAL_PATH"]))
        {

            filename = "Report" + Session["IDusuario"].ToString() + ".xls";

            string filepath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Archivos\Datos\" + filename;

            FileInfo fi = new FileInfo(filepath);
            long sz = fi.Length;

            filename = "Report.xls";
            Response.Clear();
            Response.ClearContent();
            Response.ContentType = "application/vnd.ms-excel.sheet.macroEnabled.12";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.AddHeader("Content-Length", sz.ToString("F0"));
            Response.TransmitFile(filepath);

            Response.Flush();

            ApplicationInstance.CompleteRequest();

        }

        ds.Clear();


    }

    protected void Button4_Click(object sender, EventArgs e)
    {


        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = sv.CredCfinalPublicaUditoria(0, int.Parse(this.CmbPeriodos.SelectedValue), "", Convert.ToInt32(Session["IdPais"].ToString()));

        Funciones fun = new Funciones();
        string filename;


        if (fun.ExportExcellDataset(int.Parse(Session["IDusuario"].ToString()), ds, Request.ServerVariables["APPL_PHYSICAL_PATH"]))
        {

            filename = "Report" + Session["IDusuario"].ToString() + ".xls";

            string filepath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Archivos\Datos\" + filename;

            filename = "Report.xls";
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.Flush();
            Response.WriteFile(filepath);
            
            ApplicationInstance.CompleteRequest();

        }

        ds.Clear();


    }

    protected void Button2_Click(object sender, EventArgs e)
    {

        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = ds = sv.CredCfinalPublicaInfo(1, 0, this.TxtNit.Text, Convert.ToInt32(Session["IdPais"].ToString()));

        Funciones fun = new Funciones();
        string filename;


        if (fun.ExportExcellDataset(int.Parse(Session["IDusuario"].ToString()), ds, Request.ServerVariables["APPL_PHYSICAL_PATH"]))
        {

            filename = "Report" + Session["IDusuario"].ToString() + ".xls";

            string filepath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Archivos\Datos\" + filename;

            filename = "Report.xls";
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.Flush();
            Response.WriteFile(filepath);
            
            ApplicationInstance.CompleteRequest();

        }

        ds.Clear();

    }

    protected void Button3_Click(object sender, EventArgs e)
    {

        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = ds = sv.CredCfinalPublicaUditoria(1, 0, this.TxtNit.Text, Convert.ToInt32(Session["IdPais"].ToString()));

        Funciones fun = new Funciones();
        string filename;


        if (fun.ExportExcellDataset(int.Parse(Session["IDusuario"].ToString()), ds, Request.ServerVariables["APPL_PHYSICAL_PATH"]))
        {

            filename = "Report" + Session["IDusuario"].ToString() + ".xls";

            string filepath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Archivos\Datos\" + filename;

            filename = "Report.xls";
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.Flush();
            Response.WriteFile(filepath);
            
            ApplicationInstance.CompleteRequest();

        }

        ds.Clear();

    }

    private void LLenardatos()
    {

        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = sv.SePeriodos(4);

        this.CmbPeriodos.DataSource = ds.Tables[0].DefaultView;
        this.CmbPeriodos.DataTextField = "Anio_Mes";
        this.CmbPeriodos.DataValueField = "Anio_Mes";
        this.CmbPeriodos.DataBind();


        ds.Clear();

    }
}