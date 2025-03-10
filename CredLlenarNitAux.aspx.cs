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



public partial class CredLlenarNitAux : System.Web.UI.Page
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
        ruta = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Archivos\\Carguemo\\";

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
                case ".XLS":
                case ".XLSX":
                    FileUpload1.SaveAs(ruta + FileUpload1.FileName);
                    ValidarAchivo(ruta + FileUpload1.FileName, extension.ToUpper());
                    break;
                default:
                    Response.Write("<script>alert('Debe ser un archivo de excel')</script>");
                    break;

            }


            /* }
             catch (Exception ex)
             {
                 Response.Write("<script>alert('ERROR: ' " + ex.Message.ToString() + ")</script>");
             }*/


        }
        else
        {
            Response.Write("<script>alert('No ha especificado archivo.')</script>");
            return;
        }


    }

    private void ValidarAchivo(string archivo, string Formato)
    {
        Datos sv = new Datos();
        string Nit;

        /*se hace referencia al sistem .data.OLEDB*/
        OleDbConnection CExcel = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivo + ";Extended Properties='Excel 12.0 Macro;HDR=YES'");

        CExcel.Open();

        DataTable dt = CExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);


        if (dt != null)
        {



            String[] excelSheets = new String[dt.Rows.Count];
            String HojasBuscar = "NitTemporal$";
            int x = 0;


            foreach (DataRow row in dt.Rows)
            {
                excelSheets[x] = row["TABLE_NAME"].ToString();
                x++;
            }


            int cuantos = 0;




            for (int j = 0; j < excelSheets.Length; j++)
            {

                if (excelSheets[j] == HojasBuscar)
                {
                    cuantos++;
                    break;
                }

            }



            CExcel.Close();

            if (cuantos == 1)
            {



                /*se ejecuta la consulta a la hoha de excel*/
                OleDbDataAdapter AdpExcel = new OleDbDataAdapter("Select NIT from [NitTemporal$]", CExcel);
                /*se carga el resultadao en el dataset*/
                DataSet DS = new DataSet();
                DS.Tables.Add("Excel");
                AdpExcel.Fill(DS.Tables["Excel"]);




                if (DS.Tables["Excel"].Rows.Count > 0)
                {

                    sv.EliminaNitTemporal(int.Parse(Session["IDusuario"].ToString()));

                    for (int i = 0; i < DS.Tables["Excel"].Rows.Count; i++)
                    {
                        if (DS.Tables["Excel"].Rows[i]["NIT"].ToString().Trim().Length > 0)
                        {
                            Nit = DS.Tables["Excel"].Rows[i]["NIT"].ToString();
                            sv.IngresaNitTemporal(Nit, int.Parse(Session["IDusuario"].ToString()));
                        }
                    }

                    Response.Write("<script>alert('Tabla Actualizada')</script>");

                }
                else
                {

                    Response.Write("<script>alert('Archivo No Contiene Registros')</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('Falta la Hoja NitTemporal')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Archivo No Contiene Hojas')</script>");
        }

        System.IO.File.Delete(archivo);

    }


}
