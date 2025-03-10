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
using System.Diagnostics;

public partial class CGFormCPE : System.Web.UI.Page
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
        }
    }

    protected void EliminaIndividual()
    {
        Datos sv = new Datos();

        sv.DeInfoCalificaciones(2, true);

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
            //try
            //{
            string fileName = Server.HtmlEncode(FileUpload1.FileName);
            string extension = System.IO.Path.GetExtension(fileName);

            switch (extension.ToUpper())
            {
                case ".TXT":
                    FileUpload1.SaveAs(ruta + FileUpload1.FileName);
                    ValidarAchivo(ruta + FileUpload1.FileName, FileUpload1.FileName, extension.ToUpper());
                    chkForAntiguo.Checked = false;
                    break;
                default:
                    Response.Write("<script>alert('Debe ser un archivo plano')</script>");
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
        Datos sv = new Datos();
        Funciones fun = new Funciones();
        DataSet ds = new DataSet();
        DataSet dts = new DataSet();
        DataSet dss = new DataSet();
        DataTable tabla = new DataTable();

        //Para agregar las columnas y darles un nombre haremos lo siguiente:
        tabla.Columns.Add("TIPO_INDENTIFICACION");
        tabla.Columns.Add("IDENTIFICACION");
        tabla.Columns.Add("NOMBRE_ENTIDAD");
        tabla.Columns.Add("CAL_COMERCIAL");
        tabla.Columns.Add("VAL_TOT_COMERCIAL");
        tabla.Columns.Add("PAR_COMERCIAL");
        tabla.Columns.Add("CAL_ARR_COMERCIAL");
        tabla.Columns.Add("PERIODO_TRIMESTRE");

        tabla.Columns.Add("PAR_ARRAS_COMERCIAL");
        tabla.Columns.Add("TIP_GARANTIA");
        tabla.Columns.Add("MONEDA");

        string Anio_Mes, TipoIdentificacion, Nit, NombreEmpresa, Calificacion, Saldo, ParComercial, CalRRComercial = "", ParArrastreComercial, TipoGarantia, Moneda;

        List<string> list = new List<string>();
        using (StreamReader reader = new StreamReader(archivo, false))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                list.Add(line); // Add to list.
                Console.WriteLine(line); // Write to console.

                string sTexto = line;
                int cantCaracter = sTexto.Length;

                Anio_Mes = sTexto.Substring(0, 6);
                TipoIdentificacion = sTexto.Substring(6, 2);
                Nit = sTexto.Substring(8, 15);
                Nit = string.Format("{0,10:G}", Convert.ToInt64(Nit));
                NombreEmpresa = sTexto.Substring(23, 60);
                Calificacion = sTexto.Substring(83, 1);
                Saldo = sTexto.Substring(84, 16);
                Saldo = string.Format("{0,10:G}", Convert.ToInt64(Saldo));
                Decimal Saldov = Convert.ToInt64(Saldo);
                Saldov = Saldov / 1000;
                Saldo = string.Format("{0,10:G}", Saldov);
                ParComercial = sTexto.Substring(100, 3);

                if (cantCaracter >= 105)
                {
                    CalRRComercial = sTexto.Substring(103, 1);
                }

                if (chkForAntiguo.Checked == true)
                {
                    ParArrastreComercial = "";
                    TipoGarantia = "";
                    Moneda = "";
                }
                else
                {
                    ParArrastreComercial = sTexto.Substring(103, 2);
                    TipoGarantia = sTexto.Substring(105, 6);
                    Moneda = sTexto.Substring(111, 2);
                }

                DataRow fila = tabla.NewRow();

                fila["TIPO_INDENTIFICACION"] = TipoIdentificacion;
                fila["IDENTIFICACION"] = Nit;
                fila["NOMBRE_ENTIDAD"] = NombreEmpresa;
                fila["CAL_COMERCIAL"] = Calificacion;
                fila["VAL_TOT_COMERCIAL"] = Saldo;
                fila["PAR_COMERCIAL"] = ParComercial;
                fila["CAL_ARR_COMERCIAL"] = CalRRComercial;
                fila["PERIODO_TRIMESTRE"] = Anio_Mes;

                fila["PAR_ARRAS_COMERCIAL"] = ParArrastreComercial;
                fila["TIP_GARANTIA"] = TipoGarantia;
                fila["MONEDA"] = Moneda;
                tabla.Rows.Add(fila);
            }
        }
        sv.DeInfoCalificaciones(2, false);
        DataTable dtInsertRows = tabla;
        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["StrCredito"].ConnectionString))
        {
            bulkCopy.BulkCopyTimeout = 600; // in seconds
            bulkCopy.DestinationTableName = "CPagoExternoData";

            bulkCopy.ColumnMappings.Add("TIPO_INDENTIFICACION", "TIPO_INDENTIFICACION");
            bulkCopy.ColumnMappings.Add("IDENTIFICACION", "IDENTIFICACION");
            bulkCopy.ColumnMappings.Add("NOMBRE_ENTIDAD", "NOMBRE_ENTIDAD");
            bulkCopy.ColumnMappings.Add("CAL_COMERCIAL", "CAL_COMERCIAL");
            bulkCopy.ColumnMappings.Add("VAL_TOT_COMERCIAL", "VAL_TOT_COMERCIAL");
            bulkCopy.ColumnMappings.Add("PAR_COMERCIAL", "PAR_COMERCIAL");
            bulkCopy.ColumnMappings.Add("CAL_ARR_COMERCIAL", "CAL_ARR_COMERCIAL");
            bulkCopy.ColumnMappings.Add("PERIODO_TRIMESTRE", "PERIODO_TRIMESTRE");
            bulkCopy.ColumnMappings.Add("PAR_ARRAS_COMERCIAL", "PAR_ARRAS_COMERCIAL");
            bulkCopy.ColumnMappings.Add("TIP_GARANTIA", "TIP_GARANTIA");
            bulkCopy.ColumnMappings.Add("MONEDA", "MONEDA");
            bulkCopy.WriteToServer(dtInsertRows);
        }

        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["StrCredito"].ConnectionString))
        {
            bulkCopy.BulkCopyTimeout = 600; // in seconds
            bulkCopy.DestinationTableName = "CPagoExternoHist";

            bulkCopy.ColumnMappings.Add("TIPO_INDENTIFICACION", "TIPO_INDENTIFICACION");
            bulkCopy.ColumnMappings.Add("IDENTIFICACION", "IDENTIFICACION");
            bulkCopy.ColumnMappings.Add("NOMBRE_ENTIDAD", "NOMBRE_ENTIDAD");
            bulkCopy.ColumnMappings.Add("CAL_COMERCIAL", "CAL_COMERCIAL");
            bulkCopy.ColumnMappings.Add("VAL_TOT_COMERCIAL", "VAL_TOT_COMERCIAL");
            bulkCopy.ColumnMappings.Add("PAR_COMERCIAL", "PAR_COMERCIAL");
            bulkCopy.ColumnMappings.Add("CAL_ARR_COMERCIAL", "CAL_ARR_COMERCIAL");
            bulkCopy.ColumnMappings.Add("PERIODO_TRIMESTRE", "PERIODO_TRIMESTRE");
            bulkCopy.ColumnMappings.Add("PAR_ARRAS_COMERCIAL", "PAR_ARRAS_COMERCIAL");
            bulkCopy.ColumnMappings.Add("TIP_GARANTIA", "TIP_GARANTIA");
            bulkCopy.ColumnMappings.Add("MONEDA", "MONEDA");
            bulkCopy.WriteToServer(dtInsertRows);
        }
        Response.Write("<script>alert('Información cargada correctamente')</script>");

    }

    protected void btnGeneraCalificacion_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        DataSet dts = new DataSet();
        Datos sv = new Datos();
        string AnioPeriodo, mesPeriodo, Periodo;
        int restaAnio = 0, RestaMes = 0;

        dts = sv.SePeriodos(0);
        Periodo = dts.Tables[0].Rows[0]["Anio_Mes"].ToString();
        AnioPeriodo = Periodo.Substring(0, 4);
        mesPeriodo = Periodo.Substring(4, 2);

        if (mesPeriodo == "01")
        {
            restaAnio = int.Parse(AnioPeriodo) - 1;
            AnioPeriodo = Convert.ToString(restaAnio);
            mesPeriodo = "12";
            Periodo = restaAnio + mesPeriodo;
        }
        else
        {
            RestaMes = int.Parse(mesPeriodo) - 1;
            mesPeriodo = Convert.ToString(RestaMes);
            if (mesPeriodo.Length < 2)
            {
                mesPeriodo = "0" + mesPeriodo;
            }
            Periodo = AnioPeriodo + mesPeriodo;
        }

        if (chkActivaCalifIndividual.Checked == false)
        {
            ds = sv.SeCPagoExternoData(1);

            if (ds.Tables[0].Rows.Count != 0)
            {
                if (Periodo == ds.Tables[0].Rows[0]["PERIODO_TRIMESTRE"].ToString())
                {
                    sv.SECPEData(int.Parse(ds.Tables[0].Rows[0]["PERIODO_TRIMESTRE"].ToString()), int.Parse(Session["IdUsuario"].ToString()), false, "", Convert.ToInt32(Session["IdPais"].ToString()));
                    Response.Write("<script>alert('Se realizo la calificación de acuerdo a los registros subidos previamente')</script>");
                    //     sv.DeInfoCalificaciones(2,false);
                }
                else
                {
                    Response.Write("<script>alert('La información que desea calificar no pertenece a un periodo valido')</script>");
                    sv.DeInfoCalificaciones(2, false);
                }
            }
            else
            {
                Response.Write("<script>alert('No se encontro ningún registro para realizar el cálculo de la calificación actual')</script>");
            }
        }
        else
        {
            ds = sv.SeCPagoExternoData(2);

            if (ds.Tables[0].Rows.Count != 0)
            {
                if (Periodo == ds.Tables[0].Rows[0]["PERIODO_TRIMESTRE"].ToString())
                {
                    sv.SECPEData(int.Parse(ds.Tables[0].Rows[0]["PERIODO_TRIMESTRE"].ToString()), int.Parse(Session["IdUsuario"].ToString()), true, "", Convert.ToInt32(Session["IdPais"].ToString()));
                    Response.Write("<script>alert('Se realizo la calificación de la información cargada manualmente')</script>");
                    LimpiarCalificacion();
                    sv.DelDatosxEmpresa(0, "EliminaCPE", "", Convert.ToInt32(Session["IdPais"].ToString()));
                    CargarDatosManuales();
                }
                else
                {
                    Response.Write("<script>alert('La información que desea calificar no pertenece a un período valido')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('No se encontró ningún registro para realizar el cálculo de la calificación actual')</script>");
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
        txtNomEntidad.Text = "";
        txtParArasComercial.Text = "";
        txtTipoGarant.Text = "";
        txtMoneda.Text = "";
        chkForAntiguo.Checked = false;
    }

    protected void btnAgregarempresa_Click(object sender, EventArgs e)
    {
        Datos sv = new Datos();
        DataSet dts = new DataSet();

        string AnioPeriodo, mesPeriodo, Periodo;
        int restaAnio = 0, RestaMes = 0;


        dts = sv.SePeriodos(0);
        Periodo = dts.Tables[0].Rows[0]["Anio_Mes"].ToString();
        AnioPeriodo = Periodo.Substring(0, 4);
        mesPeriodo = Periodo.Substring(4, 2);

        if (mesPeriodo == "01")
        {
            restaAnio = int.Parse(AnioPeriodo) - 1;
            AnioPeriodo = Convert.ToString(restaAnio);
            mesPeriodo = "12";
            Periodo = restaAnio + mesPeriodo;
        }
        else
        {
            RestaMes = int.Parse(mesPeriodo) - 1;
            mesPeriodo = Convert.ToString(RestaMes);
            if (mesPeriodo.Length < 2)
            {
                mesPeriodo = "0" + mesPeriodo;
            }
            Periodo = AnioPeriodo + mesPeriodo;
        }

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
        if (Aniomes == Periodo)
        {
            sv.InCPEData(long.Parse(txtNitCalif.Text), txtNomEntidad.Text, txtcalif.Text, Decimal.Parse(txtSaldoCalif.Text), int.Parse(txtDiasMOraCalif.Text), int.Parse(Aniomes), long.Parse(Session["IdUsuario"].ToString()), true, txtParArasComercial.Text, txtTipoGarant.Text, txtMoneda.Text);
            CargarDatosManuales();
            LimpiarCalificacion();
            Response.Write("<script>alert('Información agregada correctamente')</script>");
        }
        else
        {
            Response.Write("<script>alert('No pertenece a un período valido')</script>");
        }

    }

    protected void CargarDatosManuales()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = sv.SeCPagoExternoData(2);
        GrvCPIManual.DataSource = ds.Tables[0].DefaultView;
        GrvCPIManual.DataBind();
        ds.Clear();

    }
}