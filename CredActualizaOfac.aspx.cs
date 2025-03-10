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


public partial class CredActualizaOfac : System.Web.UI.Page
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
                case ".XLSX":
                    FileUpload1.SaveAs(ruta + "ListaOFAC.xlsx");
                    ValidarAchivo(ruta + "ListaOFAC.xlsx");
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

    private void ValidarAchivo(string archivo)
    {
        Datos sv = new Datos();

        string Nit;
        OleDbConnection CExcel;

        /*se hace referencia al sistem .data.OLEDB*/
        //OleDbConnection CExcel = new OleDbConnection(@"Provider = Microsoft.jet.oledb.4.0; Data Source= " + archivo + "; Extended Properties= Excel 8.0");
        /*se ejecuta la consulta a la hoha de excel*/

        /*se hace referencia al sistem .data.OLEDB*/

        CExcel = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivo + ";Extended Properties='Excel 12.0 Macro;HDR=YES'");

        /*se ejecuta la consulta a la hoha de excel*/
        CExcel.Open();

        DataTable dt = CExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        if (dt != null)
        {
            String[] excelSheets = new String[dt.Rows.Count];
            String HojasBuscar = "Colombia$";
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
                OleDbDataAdapter AdpExcel = new OleDbDataAdapter("Select NIT,NOMBRE,OBSERVACION from [ColombiaDatos$]", CExcel);
                /*se carga el resultadao en el dataset*/
                DataSet DS = new DataSet();
                DS.Tables.Add("Excel");
                AdpExcel.Fill(DS.Tables["Excel"]);

                if (DS.Tables["Excel"].Rows.Count > 0)
                {
                    sv.EliminarListaOfac(Convert.ToInt32(Session["IdPais"].ToString()));

                    for (int i = 0; i < DS.Tables["Excel"].Rows.Count; i++)
                    {
                        if (DS.Tables["Excel"].Rows[i]["NIT"].ToString().Trim().Length > 0)
                            Nit = DS.Tables["Excel"].Rows[i]["NIT"].ToString();
                        else
                            Nit = "";

                        sv.OfacIngresa(DS.Tables["Excel"].Rows[i]["NIT"].ToString(), DS.Tables["Excel"].Rows[i]["NOMBRE"].ToString(), DS.Tables["Excel"].Rows[i]["OBSERVACION"].ToString(), Nit, Convert.ToInt32(Session["IdPais"].ToString()));
                    }

                    sv.ListaOfacActualiza(Convert.ToInt32(Session["IdPais"].ToString()));
                    DS.Clear();
                    Response.Write("<script>alert('Lista Clinton Actualizada')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Archivo No Contiene Registros')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Falta la Hoja Colombia Con la Información Correspondiente')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Archivo No Contiene Hojas')</script>");
        }

    }
}
