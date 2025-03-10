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

public partial class Inf_CalificacionMasiva : System.Web.UI.Page
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
            txtFechaI.Text = String.Format("{0:yyyy/MM}", DateTime.Now);
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Funciones fun = new Funciones();
        string filename;
        Datos sv = new Datos();
        DataSet ds = new DataSet();


        ds = sv.SeCalifSectorial(txtFechaI.Text.Replace("/", ""));

        if (ds.Tables[0].Rows.Count > 0)
        {

            if (fun.CrearReport(int.Parse(Session["IDusuario"].ToString()), Request.ServerVariables["APPL_PHYSICAL_PATH"], ds))
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
        }
        else
        {
            Response.Write("<script>alert('No hay registros almacenados para la fecha " + txtFechaI.Text + ".')</script>");
        }

    }
}