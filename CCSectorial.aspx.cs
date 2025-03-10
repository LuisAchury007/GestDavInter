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

public partial class CCSectorial : System.Web.UI.Page
{

    DataSet DsErrores = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Datos sv = new Datos();
        string ruta;
        ruta = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Archivos\\Carguemo\\";
        DirectoryInfo DIR = new DirectoryInfo(ruta);

        if (!DIR.Exists)
        {
            DIR.Create();
        }
        if (FileUpload1.HasFile)
        {
            string fileName = Server.HtmlEncode(FileUpload1.FileName);
            string extension = System.IO.Path.GetExtension(fileName);

            switch (extension.ToUpper())
            {
                case ".XLS":
                    FileUpload1.SaveAs(ruta + FileUpload1.FileName);
                    ValidarAchivo(ruta + FileUpload1.FileName, FileUpload1.FileName, extension.ToUpper());
                    break;
                case ".XLSX":
                    FileUpload1.SaveAs(ruta + FileUpload1.FileName);
                    ValidarAchivo(ruta + FileUpload1.FileName, FileUpload1.FileName, extension.ToUpper());
                    break;
                default:
                    Response.Write("<script>alert('Debe ser un archivo de excel')</script>");
                    break;
            }
        }
        else
        {
            Response.Write("<script>alert('No ha especificado ningún archivo.')</script>");
            return;
        }

    }

    private void ValidarAchivo(string archivo, string NomArchivo, string Formato)
    {
        Boolean existe;
        int Periodo = 0;
        Datos sv = new Datos();
        Funciones fun = new Funciones();
      //  OleDbConnection CExcel;
        DataSet ds = new DataSet();
        DataSet dts = new DataSet();

        /*se hace referencia al sistem .data.OLEDB*/
        //if (Formato == ".XLS" || Formato == ".XLSX")
        //    CExcel = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivo + ";Extended Properties='Excel 12.0 Macro;HDR=YES'");
        //else
        //    CExcel = new OleDbConnection(@"Provider = Microsoft.jet.oledb.4.0; Data Source= " + archivo + "; Extended Properties= Excel 8.0");


        OleDbConnection CExcel = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivo + ";Extended Properties='Excel 12.0 Macro;HDR=YES'");

        CExcel.Open();

        DataTable dt = CExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

        if (dt != null)
        {
            String[] excelSheets = new String[dt.Rows.Count];
            String HojasBuscar = "CSectorial$";
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
                OleDbDataAdapter AdpExcel = new OleDbDataAdapter("select distinct IdSector  from [CSectorial$]", CExcel);

                /*se carga el resultadao en el dataset*/
                DataSet DS = new DataSet();
                DS.Tables.Add("Excel");
                AdpExcel.Fill(DS.Tables["Excel"]);

                this.ListValidacion.BackColor = Color.White;
                this.ListValidacion.Items.Clear();
                this.ListValidacion.Visible = false;

                DataSet DSSQL = new DataSet();
                DSSQL = sv.CredSectoresCombo();

                for (int i = 0; i < DS.Tables["Excel"].Rows.Count; i++)
                {
                    existe = false;
                    for (int j = 0; j < DSSQL.Tables[0].Rows.Count; j++)
                    {
                        if (DS.Tables["Excel"].Rows[i]["IdSector"].ToString() != string.Empty)
                        {
                            if (int.Parse(DS.Tables["Excel"].Rows[i]["IdSector"].ToString()) == int.Parse(DSSQL.Tables[0].Rows[j]["IdSector"].ToString()))
                            {
                                existe = true;
                            }
                        }
                    }

                    if (existe == false)
                    {
                        this.ListValidacion.BackColor = Color.Red;
                        this.ListValidacion.Visible = true;
                        this.ListValidacion.Items.Add("Sector: " + DS.Tables["Excel"].Rows[i]["IdSector"].ToString() + " No Existe ");
                    }
                }

                AdpExcel = new OleDbDataAdapter("select distinct Anio_mes from [CSectorial$]", CExcel);
                DS.Tables["Excel"].Clear();
                AdpExcel.Fill(DS.Tables["Excel"]);

                if (DS.Tables["Excel"].Rows.Count > 1)
                {
                    this.ListValidacion.BackColor = Color.Red;
                    this.ListValidacion.Visible = true;
                    this.ListValidacion.Items.Add("Solo Se puede cargar un periodo al tiempo ");
                }

                DSSQL.Clear();

                DSSQL = sv.SePeriodos(0);
                for (int i = 0; i < DS.Tables["Excel"].Rows.Count; i++)
                {
                    for (int j = 0; j < DSSQL.Tables[0].Rows.Count; j++)
                    {

                        if (DS.Tables["Excel"].Rows[i]["Anio_mes"].ToString() != string.Empty)
                        {
                            if (int.Parse(DS.Tables["Excel"].Rows[i]["Anio_mes"].ToString()) != int.Parse(DSSQL.Tables[0].Rows[j]["Anio_Mes"].ToString()))
                            {
                                this.ListValidacion.BackColor = Color.Red;
                                this.ListValidacion.Visible = true;
                                this.ListValidacion.Items.Add("Periodo " + DS.Tables["Excel"].Rows[i]["Anio_mes"].ToString() + " No habilitado");
                                break;
                            }
                        }
                    }
                }

                if (DSSQL.Tables[0].Rows.Count == 0)
                {
                    this.ListValidacion.BackColor = Color.Red;
                    this.ListValidacion.Visible = true;
                    this.ListValidacion.Items.Add("No hay periodos habilitados");
                }
                else
                {
                    Periodo = int.Parse(DSSQL.Tables[0].Rows[0]["Anio_Mes"].ToString());
                }

                if (this.ListValidacion.Items.Count == 0)
                {
                    sv.DeCSectorial(Periodo);

                    AdpExcel = new OleDbDataAdapter("select Anio_mes, IdSector, Calificacion from [CSectorial$]", CExcel);
                    DS.Tables["Excel"].Clear();
                    AdpExcel.Fill(DS.Tables["Excel"]);

                    /* INICIO: David Alzate 24/08/2017 - Asunto: se agregan nuevas columnas al dataset DS.Tables["Excel"] para que guarden la auditoria del cargue de Calificacion sectorial*/
                    DataColumn usuarioId = new DataColumn("IdUsuario", typeof(System.Int32));
                    usuarioId.DefaultValue = Session["IdUsuario"].ToString();
                    DS.Tables["Excel"].Columns.Add(usuarioId);

                    DataColumn fechaSistema = new DataColumn("FechaSistema", typeof(System.DateTime));
                    fechaSistema.DefaultValue = DateTime.Now;
                    DS.Tables["Excel"].Columns.Add(fechaSistema);
                    /* FIN: David Alzate 24/08/2017 */

                    if (DS.Tables["Excel"].Rows.Count > 0)
                    {
                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["StrCredito"].ConnectionString))
                        {
                            bulkCopy.BulkCopyTimeout = 600; // in seconds
                            bulkCopy.DestinationTableName = "SectorCalificacion";

                            bulkCopy.ColumnMappings.Add("Anio_mes", "Anio_mes");
                            bulkCopy.ColumnMappings.Add("IdSector", "IdSector");
                            bulkCopy.ColumnMappings.Add("Calificacion", "Calificacion");
                            bulkCopy.ColumnMappings.Add("IdUsuario", "IdUsuario");
                            bulkCopy.ColumnMappings.Add("FechaSistema", "FechaSistema");

                            bulkCopy.WriteToServer(DS.Tables["Excel"]);
                        }
                        Response.Write("<script>alert('Información cargada correctamente')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('No hay registro')</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Falta la hoja CSectorial')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Archivo no contiene hojas')</script>");
        }

    }
}