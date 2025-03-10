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

public partial class Inf_CFinalGeneradas : System.Web.UI.Page
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

    protected void Button1_Click(object sender, EventArgs e)
    {

        Funciones fun = new Funciones();
        string filename;

        Datos sv = new Datos();
        DataSet DataS = new DataSet();

        DataS = sv.CredCfinalxInfo(int.Parse(this.CmbPeriodos.SelectedValue), 0, 0);


        if (fun.ExportExcellDataset(int.Parse(Session["IDusuario"].ToString()), DataS, Request.ServerVariables["APPL_PHYSICAL_PATH"]))
        {

            filename = "Report" + Session["IDusuario"].ToString() + ".xls";

            //string filepath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Archivos\Datos\" + filename;

            //filename = "Report.xls";
            //Response.Clear();
            //Response.ContentType = "application/octet-stream";
            //Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            //Response.Flush();
            //Response.WriteFile(filepath);

            //ApplicationInstance.CompleteRequest();

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

        DataS.Clear();

    }
}