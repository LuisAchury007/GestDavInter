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

public partial class CGFormCPI : System.Web.UI.Page
{
    DataSet DsErrores = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IDusuario"] == null)
        {
            Response.Redirect("Salir.aspx");
        }
        if (Page.IsPostBack == false)
        {
            EliminaIndividual();
            Llenardatos();
        }
    }

    protected void EliminaIndividual()
    {
        Datos sv = new Datos();

        sv.DeInfoCalificaciones(1, true);

    }


    protected void Llenardatos()
    {
        DataSet dts = new DataSet();
        Datos sv = new Datos();
        DataView vista = new DataView();

        dts = sv.SeDatosCoXEmpresa(0, "TipGarantias", 0);
        if (dts.Tables[0].Rows.Count > 0)
        {
            dts.Tables[0].Rows.Add(" -1", " Seleccione--");
            vista = dts.Tables[0].DefaultView;
            vista.Sort = "IdTipGarantia ASC";

            this.CmbTipoGarnat.DataSource = vista;
            this.CmbTipoGarnat.SelectedValue = "-1";
            this.CmbTipoGarnat.DataTextField = "TipGarantia";
            this.CmbTipoGarnat.DataValueField = "IdTipGarantia";
            this.CmbTipoGarnat.DataBind();
            dts.Clear();
        }
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
            Response.Write("<script>alert('No ha especificado archivo.')</script>");
            return;
        }

    }
    private void ValidarAchivo(string archivo, string NomArchivo, string Formato)
    {
        Datos sv = new Datos();
        Funciones fun = new Funciones();
        OleDbConnection CExcel;
        DataSet ds = new DataSet();
        DataSet dts = new DataSet();

        /*se hace referencia al sistem .data.OLEDB*/
        if (Formato == ".XLS" || Formato == ".XLSX")
            CExcel = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivo + ";Extended Properties='Excel 12.0 Macro;HDR=YES'");
        else
            CExcel = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivo + ";Extended Properties='Excel 12.0 Macro;HDR=YES'");

        CExcel.Open();

        DataTable dt = CExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

        if (dt != null)
        {
            String[] excelSheets = new String[dt.Rows.Count];
            String HojasBuscar = "BASE_PI$";
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
                OleDbDataAdapter AdpExcel = new OleDbDataAdapter("select IND,TIPOID,ID,IDSINDIGIT, OBLIG, SALDOCAP,PROVISION, DIASMORA,CALIF, AÑO_MES,REEST,TGTIA,CGTIA  from [BASE_PI$]", CExcel);
                /*se carga el resultadao en el dataset*/
                DataSet DS = new DataSet();
                DS.Tables.Add("Excel");
                AdpExcel.Fill(DS.Tables["Excel"]);
                DataSet DsCargar = new DataSet();
                DsCargar.Tables.Add("0");
                DsCargar.Tables["0"].Columns.Add("IND", Type.GetType("System.String"));
                DsCargar.Tables["0"].Columns.Add("TIPOID", Type.GetType("System.String"));
                DsCargar.Tables["0"].Columns.Add("ID", Type.GetType("System.String"));
                DsCargar.Tables["0"].Columns.Add("IDSINDIGIT    ", Type.GetType("System.String"));
                DsCargar.Tables["0"].Columns.Add("OBLIG", Type.GetType("System.String"));
                DsCargar.Tables["0"].Columns.Add("SALDOCAP", Type.GetType("System.String"));
                DsCargar.Tables["0"].Columns.Add("PROVISION", Type.GetType("System.String"));
                DsCargar.Tables["0"].Columns.Add("DIASMORA", Type.GetType("System.String"));
                DsCargar.Tables["0"].Columns.Add("CALIF", Type.GetType("System.String"));
                DsCargar.Tables["0"].Columns.Add("AÑO_MES", Type.GetType("System.String"));
                DsCargar.Tables["0"].Columns.Add("REEST", Type.GetType("System.String"));
                DsCargar.Tables["0"].Columns.Add("TGTIA", Type.GetType("System.String"));
                DsCargar.Tables["0"].Columns.Add("CGTIA", Type.GetType("System.String"));
                sv.DeInfoCalificaciones(1, false);

                //AdpExcel = new OleDbDataAdapter("select IND,TIPOID,ID,IDSINDIGIT, OBLIG, SALDOCAP,PROVISION, DIASMORA,CALIF, AÑO_MES,REEST,TGTIA,CGTIA from [BASE_PI$]", CExcel);
                AdpExcel = new OleDbDataAdapter("select * from [BASE_PI$]", CExcel);
                DS.Tables["Excel"].Clear();
                AdpExcel.Fill(DS.Tables["Excel"]);

                if (DS.Tables["Excel"].Rows.Count > 0)
                {
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["StrCredito"].ConnectionString))
                    {
                        bulkCopy.BulkCopyTimeout = 600; // in seconds
                        bulkCopy.DestinationTableName = "CPagoInternoData";

                        bulkCopy.ColumnMappings.Add("IND", "IND");
                        bulkCopy.ColumnMappings.Add("TIPOID", "TIPOID");
                        bulkCopy.ColumnMappings.Add("ID", "ID");
                        bulkCopy.ColumnMappings.Add("IDSINDIGIT", "IDSINDIGIT");
                        bulkCopy.ColumnMappings.Add("OBLIG", "OBLIG");
                        bulkCopy.ColumnMappings.Add("SALDOCAP", "SALDOCAP");
                        bulkCopy.ColumnMappings.Add("PROVISION", "PROVISION");
                        bulkCopy.ColumnMappings.Add("DIASMORA", "DIASMORA");
                        bulkCopy.ColumnMappings.Add("CALIF", "CALIF");
                        bulkCopy.ColumnMappings.Add("AÑO_MES", "ANIO_MES");
                        bulkCopy.ColumnMappings.Add("REEST", "REEST");
                        bulkCopy.ColumnMappings.Add("TGTIA", "TGTIA");
                        bulkCopy.ColumnMappings.Add("CGTIA", "CGTIA");
                        bulkCopy.WriteToServer(DS.Tables["Excel"]);
                    }
                    int valor = DS.Tables["Excel"].Rows.Count;
                    Response.Write("<script>alert('Información Cargada Correctamente')</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Falta la Hoja BASE_PI')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Archivo No Contiene Hojas')</script>");
        }

    }
    protected void btnGeneraCalificacion_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        DataSet dts = new DataSet();
        Datos sv = new Datos();
        string AnioPeriodo, mesPeriodo, Periodo;

        ds = sv.SePeriodos(0);
        Periodo = ds.Tables[0].Rows[0]["Anio_Mes"].ToString();
        AnioPeriodo = Periodo.Substring(0, 4);
        mesPeriodo = Periodo.Substring(4, 2);
        if (chkActivaCalifIndividual.Checked == false)
        {
            dts = sv.SeCPagoInternoData(true);

            if (dts.Tables[0].Rows.Count != 0)
            {
                if (Periodo == dts.Tables[0].Rows[0]["ANIO_MES"].ToString())
                {
                    sv.SECPIData(int.Parse(dts.Tables[0].Rows[0]["ANIO_MES"].ToString()), int.Parse(Session["IdUsuario"].ToString()), false, "", Convert.ToInt32(Session["IdPais"].ToString()));
                    Response.Write("<script>alert('Se realizo la calificación de acuerdo a los registros subidos previamente')</script>");
                    sv.DeInfoCalificaciones(1, false);
                }
                else
                {
                    Response.Write("<script>alert('La Informacion que desea Calificar no pertenece a un periodo valido')</script>");
                    sv.DeInfoCalificaciones(1, false);
                }
            }
            else
            {
                Response.Write("<script>alert('No se encontro ningun registro para realizar el calculo de la caliciacion actual')</script>");
            }
        }
        else
        {
            dts = sv.SeCPagoInternoData(false);

            if (dts.Tables[0].Rows.Count != 0)
            {
                if (Periodo == dts.Tables[0].Rows[0]["ANIO_MES"].ToString())
                {
                    sv.SECPIData(int.Parse(dts.Tables[0].Rows[0]["ANIO_MES"].ToString()), int.Parse(Session["IdUsuario"].ToString()), true,"", Convert.ToInt32(Session["IdPais"].ToString()));
                    Response.Write("<script>alert('Se realizo la calificación de la información cargada manualmente')</script>");
                    LimpiarCalificacion();
                    sv.DelDatosxEmpresa(0, "EliminaCPI", "", Convert.ToInt32(Session["IdPais"].ToString()));
                    CargarDatosManuales();
                    //sv.DeInfoCalificaciones(1);
                }
                else
                {
                    Response.Write("<script>alert('La Informacion que desea Calificar no pertenece a un periodo valido')</script>");
                    // sv.DeInfoCalificaciones(1);
                }
            }
            else
            {
                Response.Write("<script>alert('No se encontro ningun registro para realizar el calculo de la caliciacion actual')</script>");
            }
        }


    }

    protected void chkActivaCalifIndividual_CheckedChanged(object sender, EventArgs e)
    {
        if (chkActivaCalifIndividual.Checked == true)
        {
            PanelCalifManual.Visible = true;
            Button1.Enabled = false;
        }
        else
        {
            PanelCalifManual.Visible = false;
            Button1.Enabled = true;
            LimpiarCalificacion();
        }
    }

    protected void LimpiarCalificacion()
    {
        txtNitCalif.Text = "";
        txtSaldoCalif.Text = "";
        txtDiasMOraCalif.Text = "";
        txtcalif.Text = "";
        CmbAnioCalif.SelectedValue = "-1";
        cmbMescalif.SelectedValue = "-1";
        txtReessCalif.Text = "";
        CmbTipoGarnat.SelectedValue = "-1";
        txtCGtiaCalif.Text = "";
    }

    protected void btnAgregarempresa_Click(object sender, EventArgs e)
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();
        string Periodo;

        ds = sv.SePeriodos(0);
        Periodo = ds.Tables[0].Rows[0]["Anio_Mes"].ToString();

        if (txtNitCalif.Text == "" || txtSaldoCalif.Text == "")
        {
            Response.Write("<script>alert('Todos los campos son obligatorios')</script>");
            return;
        }
        else if (txtDiasMOraCalif.Text == "" || txtcalif.Text == "")
        {
            Response.Write("<script>alert('Todos los campos son obligatorios')</script>");
            return;
        }
        else if (CmbAnioCalif.SelectedValue == "-1" || cmbMescalif.SelectedValue == "-1")
        {
            Response.Write("<script>alert('Debe seleccionar el año y/o el mes')</script>");
            return;
        }

        string Aniomes = CmbAnioCalif.SelectedItem.Text + cmbMescalif.SelectedItem.Text;
        if (Periodo == Aniomes)
        {
            if (CmbTipoGarnat.SelectedValue != "-1")
            {
                sv.InCPIData(long.Parse(txtNitCalif.Text), Decimal.Parse(txtSaldoCalif.Text), int.Parse(txtDiasMOraCalif.Text), txtcalif.Text, int.Parse(Aniomes), txtReessCalif.Text, CmbTipoGarnat.SelectedValue, txtCGtiaCalif.Text, long.Parse(Session["IdUsuario"].ToString()), true);
                LimpiarCalificacion();
                CargarDatosManuales();
                Response.Write("<script>alert('Información agregada correctamente')</script>");
            }
            else
            {
                Response.Write("<script>alert('Debe seleccionar el tipo de garantia')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('No pertenece a un periodo valido')</script>");
        }

    }

    protected void CargarDatosManuales()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = sv.SeCPagoInternoData(false); ;
        GrvCPIManual.DataSource = ds.Tables[0].DefaultView;
        GrvCPIManual.DataBind();
        ds.Clear();

    }
}