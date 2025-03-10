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
using System.Collections.Generic;
public partial class CredPublicarR : System.Web.UI.Page
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
                    FileUpload1.SaveAs(ruta + FileUpload1.FileName);
                    ValidarAchivo(ruta + FileUpload1.FileName);
                    break;
                default:
                    Response.Write("<script>alert('Debe ser un archivo de excel')</script>");
                    break;

            }


            /* }
             catch (Exception ex)
             {
                 MsgBox1.ShowMessage("ERROR:  " + ex.Message.ToString());
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

        Boolean existe;
        Datos sv = new Datos();
        Funciones fun = new Funciones();

        /*se hace referencia al sistem .data.OLEDB*/
        OleDbConnection CExcel = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivo + ";Extended Properties='Excel 12.0 Macro;HDR=YES'");

        CExcel.Open();

        DataTable dt = CExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);


        if (dt != null)
        {

            String[] excelSheets = new String[dt.Rows.Count];
            String HojasBuscar = "Publicar$";
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
                OleDbDataAdapter AdpExcel = new OleDbDataAdapter("select distinct Nit from [Publicar$]", CExcel);
                /*se carga el resultadao en el dataset*/
                DataSet DS = new DataSet();
                DS.Tables.Add("Excel");
                AdpExcel.Fill(DS.Tables["Excel"]);

                this.ListValidacion.BackColor = Color.White;
                this.ListValidacion.Items.Clear();
                this.ListValidacion.Visible = false;



                Int64 pa = Convert.ToInt64(DS.Tables["Excel"].Rows.Count);

                for (int i = 0; i < DS.Tables["Excel"].Rows.Count; i++)
                {
                    existe = sv.CredValidaNitCliente(DS.Tables["Excel"].Rows[i]["Nit"].ToString(), Convert.ToInt32(Session["IdPais"].ToString()));

                    if (existe == false)
                    {
                        this.ListValidacion.BackColor = Color.Red;
                        this.ListValidacion.Visible = true;
                        this.ListValidacion.Items.Add("La empreas: " + DS.Tables["Excel"].Rows[i]["Nit"].ToString() + " No Existe");

                    }
                }


                AdpExcel = new OleDbDataAdapter("select Distinct R from [Publicar$]", CExcel);
                /*se carga el resultadao en el dataset*/
                DS.Tables["Excel"].Clear();
                AdpExcel.Fill(DS.Tables["Excel"]);


                for (int i = 0; i < DS.Tables["Excel"].Rows.Count; i++)
                {
                    existe = sv.CredValidaR(DS.Tables["Excel"].Rows[i]["R"].ToString());

                    if (!existe)
                    {

                        this.ListValidacion.BackColor = Color.Red;
                        this.ListValidacion.Visible = true;
                        this.ListValidacion.Items.Add("La R :" + DS.Tables["Excel"].Rows[i]["R"].ToString() + " No Habilitada Para Cargar al Sistema");

                    }
                }

                AdpExcel = new OleDbDataAdapter("select Distinct Periodo from [Publicar$]", CExcel);
                /*se carga el resultadao en el dataset*/
                DS.Tables["Excel"].Clear();
                AdpExcel.Fill(DS.Tables["Excel"]);


                if (DS.Tables["Excel"].Rows.Count > 1)
                {
                    this.ListValidacion.BackColor = Color.Red;
                    this.ListValidacion.Visible = true;
                    this.ListValidacion.Items.Add("Solo se puede Cargar un periodo a la vez");
                }

                int periodo;

                periodo = sv.CredPeriodoActivo();

                for (int i = 0; i < DS.Tables["Excel"].Rows.Count; i++)
                {

                    if (periodo != int.Parse(DS.Tables["Excel"].Rows[i]["Periodo"].ToString()))
                    {

                        this.ListValidacion.BackColor = Color.Red;
                        this.ListValidacion.Visible = true;
                        this.ListValidacion.Items.Add("Empresa :" + DS.Tables["Excel"].Rows[i]["Periodo"].ToString() + " Periodo no Habilitado");

                    }
                }

                if (this.ListValidacion.Items.Count == 0)
                {


                    /* INICIO: David Alzate 05/09/2017 - Asunto: Codigo para mostrar en pantalla que NIT estan duplicados e  indicar que solo se cargaron una vez al sistema */
                    AdpExcel = new OleDbDataAdapter("select NIT from [Publicar$]", CExcel);
                    /*se carga el resultadao en el dataset*/
                    DS.Tables["Excel"].Clear();
                    AdpExcel.Fill(DS.Tables["Excel"]);
                    List<String> nit = new List<String>();

                    for (int i = 0; i < DS.Tables["Excel"].Rows.Count; i++)
                    {
                        nit.Add(DS.Tables["Excel"].Rows[i]["Nit"].ToString());
                    }

                    foreach (var grouping in nit.GroupBy(t => t).Where(t => t.Count() != 1))
                    {
                        this.ListValidacion.BackColor = Color.Yellow;
                        this.ListValidacion.Visible = true;
                        this.ListValidacion.Items.Add(string.Format("La empresa: '{0}', se encuentra repetida en el documento de excel, solo se cargo una vez al sistema.", grouping.Key, grouping.Count()));
                    }
                    /* FIN: David Alzate 05/09/2017 */

                    AdpExcel = new OleDbDataAdapter("select NIT, Periodo, R, Valor from [Publicar$]", CExcel);
                    /*se carga el resultadao en el dataset*/
                    DS.Tables["Excel"].Clear();
                    AdpExcel.Fill(DS.Tables["Excel"]);

                    Boolean RValida;

                    for (int i = 0; i < DS.Tables["Excel"].Rows.Count; i++)
                    {
                        RValida = sv.CredPublicarR(DS.Tables["Excel"].Rows[i]["Nit"].ToString(), int.Parse(DS.Tables["Excel"].Rows[i]["Periodo"].ToString()), int.Parse(Session["IDusuario"].ToString()), DS.Tables["Excel"].Rows[i]["R"].ToString(), decimal.Parse(DS.Tables["Excel"].Rows[i]["Valor"].ToString()), Convert.ToInt32(Session["IdPais"].ToString()));
                        if (!RValida)
                        {
                            this.ListValidacion.BackColor = Color.Yellow;
                            this.ListValidacion.Visible = true;
                            this.ListValidacion.Items.Add("Para el No. Documento" + DS.Tables["Excel"].Rows[i]["Nit"].ToString() + " la R: " + DS.Tables["Excel"].Rows[i]["R"].ToString() + " O el Valor: " + DS.Tables["Excel"].Rows[i]["Valor"].ToString() + " No existe en las Calificaciones Realizados en el sistema ");
                        }
                    }
                    Response.Write("<script>alert('Información Cargada Correctamente')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Archivo No Valido')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Falta la Hoja Publicar')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Archivo No Contiene Hojas')</script>");
        }


    }
}


