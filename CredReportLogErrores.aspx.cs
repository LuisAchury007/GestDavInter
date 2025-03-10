using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data.OleDb;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;

public partial class CredReportLogErrores : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IDusuario"] == null)
        {
            Response.Redirect("Salir.aspx");
        }

        if (Page.IsPostBack == false)
        {

        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Funciones fun = new Funciones();
        Datos sv = new Datos();

        DataSet ds = new DataSet();

        ds = sv.SeLogErrores();

        string filename;
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (fun.ExportExcellDataset(int.Parse(Session["IDusuario"].ToString()), ds, Request.ServerVariables["APPL_PHYSICAL_PATH"]))
            {
                filename = "Report" + Session["IDusuario"].ToString() + ".xls";

                string filepath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Archivos\Datos\" + filename;


                //filename = "Report.xls";
                //Response.Clear();
                //Response.ContentType = "application/octet-stream";
                //Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                //Response.Flush();
                //Response.WriteFile(filepath);
                //Response.End();

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

    }
}