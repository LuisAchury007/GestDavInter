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
using System.Data.SqlClient;

public partial class CredActualizarModelo : System.Web.UI.Page
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        Datos sv = new Datos();

        string ruta;
        ruta = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Archivos\\Modelo\\"+ Session["IdPais"].ToString() + "\\";

        //bool existe = Directory.Exists(ruta);
        DirectoryInfo DIR = new DirectoryInfo(ruta);

        if (!DIR.Exists)
        {
            DIR.Create();
        }

        if (FileUpload1.HasFile)
        {
            //try
            //{
            string fileName = Server.HtmlEncode(FileUpload1.FileName);
            string extension = System.IO.Path.GetExtension(fileName);

            switch (extension.ToUpper())
            {
                case ".XLSM":
                    FileUpload1.SaveAs(ruta + "ModeloTemp.xlsm");
                    ValidarAchivo(ruta + "ModeloTemp.xlsm");
                    break;
                default:
                    Response.Write("<script>alert('Debe ser un archivo de excel xlsm')</script>");
                    break;
            }
            /* }
             catch (Exception ex)
             {
                 MsgBox1.ShowMessage(ex.Message.ToString());
             }*/
        }
        else
        {
            Response.Write("<script>alert('No ha especificado archivo.')</script>");
            return;
        }

    }

    private void ValidarAchivo(string archivo)
    {
        Datos sv = new Datos();

        Funciones fun = new Funciones();
        /*se hace referencia al sistem .data.OLEDB*/
        //OleDbConnection CExcel = new OleDbConnection(@"Provider = Microsoft.jet.oledb.4.0; Data Source= " + archivo + "; Extended Properties= Excel 8.0");
        OleDbConnection CExcel = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivo + ";Extended Properties='Excel 12.0; HDR=YES'");
        CExcel.Open();

        DataTable dt = CExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

        if (dt != null)
        {
            String[] excelSheets = new String[dt.Rows.Count];
            String[] HojasBuscar = { "RC$", "'CIFIN - Decl# Renta$'", "'Hoja de Trabajo$'", "'Estados Financieros$'", "'Balances y Proyecciones$'", "'Presentacion$'" };
            int x = 0;
            foreach (DataRow row in dt.Rows)
            {
                excelSheets[x] = row["TABLE_NAME"].ToString();
                x++;
            }

            int cuantos = 0;
            for (int i = 0; i < HojasBuscar.Length; i++)
            {
                for (int j = 0; j < excelSheets.Length; j++)
                {
                    if (excelSheets[j] == HojasBuscar[i])
                    {
                        cuantos++;
                        break;
                    }
                }
            }

            CExcel.Close();
            if (cuantos >= 4)
            {
                string sourceFile;
                sourceFile = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Archivos\\Modelo\\"+ Session["IdPais"].ToString() + "\\ModeloTemp.xlsm";

                string destFile;
                destFile = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Archivos\\Modelo\\"+ Session["IdPais"].ToString()  + "\\Modelo.xlsm";

                System.IO.File.Copy(sourceFile, destFile, true);
                Response.Write("<script>alert('Maqueta Actualizado Correctamente')</script>");
            }
            else
            {
                Response.Write("<script>alert('Maqueta No Valido Comuniquese con su administrador')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Archivo No Contiene Hojas')</script>");
        }
        System.IO.File.Delete(archivo);

    }
}
