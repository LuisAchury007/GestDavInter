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

public partial class Inf_TasaConversion : System.Web.UI.Page
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


    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {
        DataSet dsDatos = new DataSet();
        Datos sv = new Datos();
        dsDatos = sv.InfConvDivisasxPais(Convert.ToInt32(Session["IdPais"].ToString()));

        string NomArchivo = "Conversion" + int.Parse(Session["IDusuario"].ToString()) + ".xls";
        string targetPath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Archivos\Datos";
        string destFile = System.IO.Path.Combine(targetPath, NomArchivo);


        Workbook book = new Workbook();

        // Specify which Sheet should be opened and the size of window by default

        book.ExcelWorkbook.ActiveSheetIndex = 1;
        book.ExcelWorkbook.WindowTopX = 100;
        book.ExcelWorkbook.WindowTopY = 200;
        book.ExcelWorkbook.WindowHeight = 7000;
        book.ExcelWorkbook.WindowWidth = 8000;

        // Some optional properties of the Document
        book.Properties.Author = "Luis Achury";
        book.Properties.Title = "Gestor Comercial y de Credito";
        book.Properties.Created = DateTime.Now;

        // Add a Worksheet with some data
        Worksheet sheet = book.Worksheets.Add("Clientes");
        WorksheetRow row = sheet.Table.Rows.Add();

        row.Index = 1;

        for (int i = 0; i < dsDatos.Tables[0].Columns.Count; i++)
        {
            row.Cells.Add(dsDatos.Tables[0].Columns[i].ColumnName);
        }



        for (int i = 0; i < dsDatos.Tables[0].Rows.Count; i++)
        {
            row = sheet.Table.Rows.Add();

            for (int j = 0; j < dsDatos.Tables[0].Columns.Count; j++)
            {

                row.Cells.Add(new WorksheetCell(Convert.ToString(dsDatos.Tables[0].Rows[i][j])));
            }

        }


        book.Save(destFile);

        dsDatos.Clear();

        Response.Clear();
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + NomArchivo);
        Response.Flush();
        Response.WriteFile(destFile);
        Response.End();


    }

}