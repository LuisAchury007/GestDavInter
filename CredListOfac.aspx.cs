using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using CarlosAg.ExcelXmlWriter;
using System.Text.RegularExpressions;
using System.Data;



public partial class CredListOfac : System.Web.UI.Page
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
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string NomArchivo = "ListaOFAC.xlsx";
        string filepath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Archivos\Carguemo\" + NomArchivo;

        Response.Clear();
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + "ListaOFAC.xlsx");
        Response.Flush();
        Response.WriteFile(filepath);
        
        ApplicationInstance.CompleteRequest();
    }
}
