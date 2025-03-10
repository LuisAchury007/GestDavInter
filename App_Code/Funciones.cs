using System;
using System.Data;
using System.Configuration;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using CarlosAg.ExcelXmlWriter;
using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Security.Permissions;
using Microsoft.Win32.SafeHandles;
using System.Runtime.ConstrainedExecution;


using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Security;



/// <summary>
/// Descripción breve de Funciones
/// </summary>
public class Funciones
{

    // Variables para impersonateValidUser

    public const int LOGON32_LOGON_INTERACTIVE = 2;
    public const int LOGON32_PROVIDER_DEFAULT = 0;

    WindowsImpersonationContext impersonationContext;

    [DllImport("advapi32.dll")]
    public static extern int LogonUserA(String lpszUserName,
    String lpszDomain,
    String lpszPassword,
    int dwLogonType,
    int dwLogonProvider,
    ref IntPtr phToken);
    [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int DuplicateToken(IntPtr hToken,
    int impersonationLevel,
    ref IntPtr hNewToken);

    [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool RevertToSelf();

    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public static extern bool CloseHandle(IntPtr handle);

    // Fin para impersonateValidUser

    public Funciones()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public bool IsValidEmail(string strIn)
    {
        // Return true if strIn is in valid e-mail format.
        return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
    }

    public string Cononica(string fecha)
    {
        char[] delimitador = { '/' };
        string canonica;
        string[] array;

        array = fecha.Split(delimitador);

        canonica = array[2] + '/' + array[1] + '/' + array[0];

        return canonica;
    }

    public string ToEncriptar(string str)
    {
        string Cadena = str;
        Byte[] bclave = new UnicodeEncoding().GetBytes(Cadena);

        bclave = new SHA1CryptoServiceProvider().ComputeHash(bclave);
        string enclave = Convert.ToBase64String(bclave);

        return enclave;
    }

    public Boolean CrearInfoEmpParcial(int IDUser, string path, int IdPais)
    {

        string NomArchivo = "Parcial" + IDUser + ".xls";
        DataSet DataS = new DataSet();

        //string fileName = "Datos.xls";
        //string sourcePath = path + @"Archivos";
        string targetPath = path + @"Archivos\Datos";


        // Use Path class to manipulate file and directory paths.
        //  string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
        string destFile = System.IO.Path.Combine(targetPath, NomArchivo);

        //  System.IO.File.Copy(sourceFile, destFile, true);

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

        #region "Centrar encabezados en negrilla en Excel | Agustín David Cruz González (16/Jul/2014)."

        // Add some styles to the Workbook
        WorksheetStyle style = book.Styles.Add("Cabecera");
        style.Font.Bold = true;
        style.Alignment.Horizontal = StyleHorizontalAlignment.Center;

        //Bordes y color de encabezados | Agustín David Cruz González (16/Jul/2014).
        style.Interior.Pattern = StyleInteriorPattern.Solid;
        style.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
        style.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
        style.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
        style.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
        style.Interior.Color = "#D7E4BC";

        #endregion

        #region "Estilo para contenido | Agustín David Cruz González (16/Jul/2014)."

        WorksheetStyle style2 = book.Styles.Add("Contenido");
        style2.Interior.Pattern = StyleInteriorPattern.Solid;
        style2.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
        style2.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
        style2.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
        style2.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);

        #endregion

        Datos sv = new Datos();

        // Años       
        DataS = sv.CredEmpresasConParcial(IdPais);

        // Add a Worksheet with some data
        Worksheet sheet = book.Worksheets.Add("Empresas");

        WorksheetRow row = sheet.Table.Rows.Add();
        // Skip one row, and add some text
        row.Index = 1;
        row.Cells.Add(new WorksheetCell("NIT", "Cabecera"));
        row.Cells.Add(new WorksheetCell("RazonSocial", "Cabecera"));
        row.Cells.Add(new WorksheetCell("Ciiu", "Cabecera"));
        row.Cells.Add(new WorksheetCell("Sector", "Cabecera"));
        row.Cells.Add(new WorksheetCell("Vigencia", "Cabecera"));


        // Generate 30 rows
        for (int i = 0; i < DataS.Tables[0].Rows.Count; i++)
        {
            row = sheet.Table.Rows.Add();
            row.Cells.Add(new WorksheetCell(Convert.ToString(DataS.Tables[0].Rows[i]["NIT"]), "Contenido"));
            row.Cells.Add(new WorksheetCell(Convert.ToString(DataS.Tables[0].Rows[i]["RazonSocial"]), "Contenido"));
            row.Cells.Add(new WorksheetCell(Convert.ToString(DataS.Tables[0].Rows[i]["Ciiu"]), "Contenido"));
            row.Cells.Add(new WorksheetCell(Convert.ToString(DataS.Tables[0].Rows[i]["Sector"]), "Contenido"));
            row.Cells.Add(new WorksheetCell(Convert.ToString(DataS.Tables[0].Rows[i]["Vigencia"]), DataType.Number, "Contenido"));
        }

        DataS.Clear();

        book.Save(destFile);
        return true;

    }

    public Boolean CrearReport(int IDUser, string path, DataSet DataS)
    {
        string NomArchivo = "Report" + IDUser + ".xls";

        //string fileName = "Datos.xls";
        //string sourcePath = path + @"Archivos";
        string targetPath = path + @"Archivos\Datos";

        // Use Path class to manipulate file and directory paths.
        //  string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
        string destFile = System.IO.Path.Combine(targetPath, NomArchivo);

        //  System.IO.File.Copy(sourceFile, destFile, true);

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

        #region "Centrar encabezados en negrilla en Excel | Agustín David Cruz González (16/Jul/2014)."

        // Add some styles to the Workbook
        WorksheetStyle style = book.Styles.Add("Cabecera");
        style.Font.Bold = true;
        style.Alignment.Horizontal = StyleHorizontalAlignment.Center;

        //Bordes y color de encabezados | Agustín David Cruz González (16/Jul/2014).
        style.Interior.Pattern = StyleInteriorPattern.Solid;
        style.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
        style.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
        style.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
        style.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
        style.Interior.Color = "#D7E4BC";

        #endregion

        #region "Estilo para contenido | Agustín David Cruz González (16/Jul/2014)."

        WorksheetStyle style2 = book.Styles.Add("Contenido");
        style2.Interior.Pattern = StyleInteriorPattern.Solid;
        style2.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
        style2.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
        style2.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
        style2.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);

        #endregion

        Datos sv = new Datos();

        // Add a Worksheet with some data
        Worksheet sheet = book.Worksheets.Add("Reporte");

        WorksheetRow row = sheet.Table.Rows.Add();
        // Skip one row, and add some text
        row.Index = 1;

        if (DataS != null)
        {
            for (int i = 0; i < DataS.Tables[0].Columns.Count; i++)
            {
                row.Cells.Add(new WorksheetCell(DataS.Tables[0].Columns[i].ColumnName, "Cabecera"));
            }

            for (int i = 0; i < DataS.Tables[0].Rows.Count; i++)
            {
                row = sheet.Table.Rows.Add();

                for (int j = 0; j < DataS.Tables[0].Columns.Count; j++)
                {
                    row.Cells.Add(new WorksheetCell(Convert.ToString(DataS.Tables[0].Rows[i][j]), "Contenido"));
                }
            }
            DataS.Clear();
        }
        book.Save(destFile);
        return true;

    }


    public Boolean CrearCaratula(string nit, string destFile, Boolean Modelo, int IdPais, int IdDivisa, string Divisa, string Pais)
    {

        DataSet DataS = new DataSet();

        OleDbConnection CExcel;
        OleDbCommand objCmd;
        string CadenaConexion;
        //int Cantidades = 255;
        CadenaConexion = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + destFile + ";Extended Properties='Excel 12.0; HDR=YES'";
        string query;
        Datos sv = new Datos();

        DataS = sv.BencEmpresaDatos(nit, IdPais);
        CExcel = new OleDbConnection(CadenaConexion);
        CExcel.Open();

        for (int i = 0; i < DataS.Tables[0].Rows.Count; i++)
        {

            query = "INSERT INTO [Caratula1$](NIT, RazonSocial, RepresentanteLegal, RevisorFiscal, Direccion, Telefono, Ciudad, Fax, AA, FechaFundacion, ObjetoSocial, Email, Website, Sigla, TipoEmpresa, Cargo, IdCiudad, NumMatricula, ListaClinton, Ciiu, Importador, Exportador, IdTipoSociedad, Fuente, Concordato, Ley1116, CasaMatriz, VigSociedad, CalRiesgoEx, CotBolsa, IdGrupoEm, IdFuente, EsCliente, Comentarios, IdSector, IdSegmento, Sector, GrupoEmpresarial, Moneda, NombreMoneda,IdPais,Pais,PaisAct)" +
           "values(@NIT, @RazonSocial, @RepresentanteLegal, @RevisorFiscal, @Direccion, @Telefono, @Ciudad, @Fax, @AA, @FechaFundacion, @ObjetoSocial, @Email, @Website, @Sigla, @TipoEmpresa, @Cargo, @IdCiudad, @NumMatricula, @ListaClinton, @Ciiu, @Importador, @Exportador, @IdTipoSociedad, @Fuente, @Concordato, @Ley1116, @CasaMatriz, @VigSociedad, @CalRiesgoEx, @CotBolsa, @IdGrupoEm, @IdFuente, @EsCliente, @Comentarios, @IdSector, @IdSegmento, @Sector,@GrupoEmpresarial,@Moneda,@NombreMoneda,@IdPais,@Pais,@PaisAct)";

            objCmd = new OleDbCommand(query, CExcel);

            objCmd.Parameters.Add("@NIT", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["NIT"].ToString();
            objCmd.Parameters.Add("@RazonSocial", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["RazonSocial"].ToString();
            objCmd.Parameters.Add("@RepresentanteLegal", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["RepresentanteLegal"].ToString();
            objCmd.Parameters.Add("@RevisorFiscal", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["RevisorFiscal"].ToString();
            objCmd.Parameters.Add("@Direccion", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Direccion"].ToString();
            objCmd.Parameters.Add("@Telefono", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Telefono"].ToString();
            objCmd.Parameters.Add("@Ciudad", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Ciudad"].ToString();
            objCmd.Parameters.Add("@Fax", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Fax"].ToString();
            objCmd.Parameters.Add("@AA", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["AA"].ToString();
            objCmd.Parameters.Add("@FechaFundacion", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["FechaFundacion"].ToString();
            objCmd.Parameters.Add("@ObjetoSocial", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["ObjetoSocial"].ToString();
            objCmd.Parameters.Add("@Email", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Email"].ToString();
            objCmd.Parameters.Add("@Website", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Website"].ToString();
            objCmd.Parameters.Add("@Sigla", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Sigla"].ToString();
            objCmd.Parameters.Add("@TipoEmpresa", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["TipoEmpresa"].ToString();
            objCmd.Parameters.Add("@Cargo", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Cargo"].ToString();
            objCmd.Parameters.Add("@IdCiudad", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["IdCiudad"].ToString();
            objCmd.Parameters.Add("@NumMatricula", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["NumMatricula"].ToString();
            objCmd.Parameters.Add("@ListaClinton", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["ListaClinton"].ToString();
            objCmd.Parameters.Add("@Ciiu", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Ciiu"].ToString();
            objCmd.Parameters.Add("@Importador", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Importador"].ToString();
            objCmd.Parameters.Add("@Exportador", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Exportador"].ToString();
            objCmd.Parameters.Add("@IdTipoSociedad", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["IdTipoSociedad"].ToString();
            objCmd.Parameters.Add("@Fuente", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Fuente"].ToString();
            objCmd.Parameters.Add("@Concordato", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Concordato"].ToString();
            objCmd.Parameters.Add("@Ley1116", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Ley1116"].ToString();
            objCmd.Parameters.Add("@CasaMatriz", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["CasaMatriz"].ToString();
            objCmd.Parameters.Add("@VigSociedad", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["VigSociedad"].ToString();
            objCmd.Parameters.Add("@CalRiesgoEx", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["CalRiesgoEx"].ToString();
            objCmd.Parameters.Add("@CotBolsa", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["CotBolsa"].ToString();
            objCmd.Parameters.Add("@IdGrupoEm", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["IdGrupoEm"].ToString();
            objCmd.Parameters.Add("@IdFuente", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["IdFuente"].ToString();
            objCmd.Parameters.Add("@EsCliente", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["EsCliente"].ToString();
            objCmd.Parameters.Add("@Comentarios", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Comentarios"].ToString();
            objCmd.Parameters.Add("@IdSector", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["IdSector"].ToString();
            objCmd.Parameters.Add("@IdSegmento", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["IdSegmento"].ToString();
            objCmd.Parameters.Add("@Sector", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Sector"].ToString();
            objCmd.Parameters.Add("@GrupoEmpresarial", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["GrupoEmpresarial"].ToString();
            objCmd.Parameters.Add("@Moneda", OleDbType.VarChar).Value = IdDivisa.ToString();
            objCmd.Parameters.Add("@NombreMoneda", OleDbType.VarChar).Value = Divisa;
            objCmd.Parameters.Add("@IdPais", OleDbType.VarChar).Value = IdPais;
            objCmd.Parameters.Add("@Pais", OleDbType.VarChar).Value = Pais;
            objCmd.Parameters.Add("@PaisAct", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["PaisAct"].ToString();

            objCmd.ExecuteNonQuery();
            objCmd.Dispose();
        }

        DataS = sv.CredBalancTabla(nit, IdPais, IdDivisa);

        for (int i = 0; i < DataS.Tables[0].Rows.Count; i++)
        {
            query = "INSERT INTO [BalancesAnuales1$](Llave, IdCuenta, NIT, Anio, Valor)" +
           "values(@Llave,@IdCuenta,@NIT, @Anio, @Valor)";

            objCmd = new OleDbCommand(query, CExcel);
            objCmd.Parameters.Add("@Llave", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Llave"].ToString();
            objCmd.Parameters.Add("@IdCuenta", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["IdCuenta"].ToString();
            objCmd.Parameters.Add("@NIT", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["NIT"].ToString();
            objCmd.Parameters.Add("@Anio", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Anio"].ToString();
            objCmd.Parameters.Add("@Valor", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Valor"].ToString(); ;
            objCmd.ExecuteNonQuery();
            objCmd.Dispose();
        }

        DataS = sv.CredBalancParcialTabla(nit, IdPais, IdDivisa);

        for (int i = 0; i < DataS.Tables[0].Rows.Count; i++)
        {
            query = "INSERT INTO [BalancesMensuales1$](Llave, IdCuenta, NIT, Anio, Valor)" +
           "values(@Llave,@IdCuenta,@NIT, @Anio, @Valor)";

            objCmd = new OleDbCommand(query, CExcel);
            objCmd.Parameters.Add("@Llave", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Llave"].ToString();
            objCmd.Parameters.Add("@IdCuenta", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["IdCuenta"].ToString();
            objCmd.Parameters.Add("@NIT", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["NIT"].ToString();
            objCmd.Parameters.Add("@Anio", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Anio"].ToString();
            objCmd.Parameters.Add("@Valor", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Valor"].ToString(); ;
            objCmd.ExecuteNonQuery();
            objCmd.Dispose();
        }


        DataS = sv.CredNitAnio(nit, IdPais, IdDivisa);

        query = "INSERT INTO [NITANIONIIF1$](Llave, NIT, Anio, NIIF,Parcial,Auditado,DivisaConversion,Meses,TipoAuditado)" +
               "values(@Llave,@NIT, @Anio,@NIIF, @Parcial,@Auditado,@DivisaConversion,@Meses,@TipoAuditado)";

        for (int i = 0; i < DataS.Tables[0].Rows.Count; i++)
        {
            objCmd = new OleDbCommand(query, CExcel);

            objCmd.Parameters.Add("@Llave", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Llave"].ToString();
            objCmd.Parameters.Add("@NIT", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["NIT"].ToString();
            objCmd.Parameters.Add("@Anio", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Anio"].ToString();
            objCmd.Parameters.Add("@NIIF", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Niif"].ToString();
            objCmd.Parameters.Add("@Parcial", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Parcial"].ToString();
            objCmd.Parameters.Add("@Auditado", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Auditado"].ToString();
            objCmd.Parameters.Add("@DivisaConversion", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["DivisaConversion"].ToString();
            objCmd.Parameters.Add("@Meses", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Meses"].ToString();
            objCmd.Parameters.Add("@TipoAuditado", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["TipoAuditado"].ToString();
            objCmd.ExecuteNonQuery();
            objCmd.Dispose();
        }


        DataS = sv.BencAccionistasEmpresa(nit, 1, IdPais);


        query = "INSERT INTO [Accionistas1$](NIT, cedula, nombre, Participacion, IdTipoDocumento)" +
               "values(@NIT, @cedula, @nombre, @Participacion, @IdTipoDocumento)";

        for (int i = 0; i < DataS.Tables[0].Rows.Count; i++)
        {
            objCmd = new OleDbCommand(query, CExcel);

            objCmd.Parameters.Add("@NIT", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["NIT"].ToString(); ;
            objCmd.Parameters.Add("@cedula", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["cedula"].ToString(); ; ;
            objCmd.Parameters.Add("@nombre", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["nombre"].ToString();
            objCmd.Parameters.Add("@Participacion", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Participacion"].ToString();
            objCmd.Parameters.Add("@IdTipoDocumento", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["IdTipDocumento"].ToString();

            objCmd.ExecuteNonQuery();
            objCmd.Dispose();
        }

        DataS = sv.BencEjecutivosEmp(nit, 1, IdPais);



        query = "INSERT INTO [Ejecutivos1$](Nit,Documento,Nombre,Cargo,IdTipoEjecutivo,TipoEjecutivo)" +
           "VALUES(@Nit, @Documento, @Nombre, @Cargo,  @IdTipoEjecutivo, @TipoEjecutivo)";

        for (int i = 0; i < DataS.Tables[0].Rows.Count; i++)
        {
            objCmd = new OleDbCommand(query, CExcel);

            objCmd.Parameters.Add("@Nit", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Nit"].ToString(); ;
            objCmd.Parameters.Add("@Documento", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Documento"].ToString(); ; ;
            objCmd.Parameters.Add("@Nombre", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Nombre"].ToString();
            objCmd.Parameters.Add("@Cargo", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["Cargo"].ToString();
            objCmd.Parameters.Add("@IdTipoEjecutivo", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["IdTipoEjecutivo"].ToString();
            objCmd.Parameters.Add("@TipoEjecutivo", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["TipoEjecutivo"].ToString();


            objCmd.ExecuteNonQuery();
            objCmd.Dispose();
        }

        DataS.Clear();


        // Indicadores Empresa

        //string queryMacro;
        //string NombreColumnas;
        //string ColumnaSegunda;
        //int cuantos = 0;
        //int totalColumnas = 0;
        //string[] ColumnaIndicadores = { "Id", "Indicador", "anio1",  "anio2", "anio3", "anio4", "anio5", "anio6", "anio7", "anio8" };

        //int sector = 1;



        //DataS = sv.BencIndicadoresEmpresa(nit.ToString(), sector, IdPais, IdDivisa); 

        //NombreColumnas = "IdIndicador,Indicador";
        //ColumnaSegunda = "'IdIndicador','Indicador'";

        //cuantos = 2;

        //if (DataS.Tables[0].Columns.Count > 21)
        //    totalColumnas = 21;
        //else
        //    totalColumnas = DataS.Tables[0].Columns.Count;

        //for (int i = 5; i < totalColumnas; i++)
        //{
        //    NombreColumnas = NombreColumnas + "," + ColumnaIndicadores[i - 3];
        //    ColumnaSegunda = ColumnaSegunda + ",'" + DataS.Tables[0].Columns[i].ColumnName + "'";
        //    cuantos = cuantos + 1;
        //}

        //queryMacro = "INSERT INTO [Indicadores-Empresa$] (" + NombreColumnas + ") VALUES(";

        //query = queryMacro + ColumnaSegunda + ")";

        //CExcel = new OleDbConnection(CadenaConexion);

        //CExcel = new OleDbConnection(CadenaConexion);
        //CExcel.Open();

        //objCmd = new OleDbCommand(query, CExcel);
        //objCmd.ExecuteNonQuery();
        //objCmd.Dispose();






        //for (int i = 0; i < DataS.Tables[0].Rows.Count; i++)
        //{

        //    query = queryMacro + int.Parse(DataS.Tables[0].Rows[i]["IdIndicador"].ToString()) + ",'" + DataS.Tables[0].Rows[i]["Diminutivo"].ToString() + "'";

        //    for (int j = 5; j < totalColumnas; j++)
        //    {
        //        //Canedana = Convert.ToString(DataS.Tables[0].Rows[i][j]);
        //        //Canedana = Canedana.Replace(",", ".");
        //        query = query + ",'" + DataS.Tables[0].Rows[i][j] + "'";
        //    }
        //    query = query + ")";

        //    objCmd = new OleDbCommand(query, CExcel);
        //    objCmd.ExecuteNonQuery();
        //    objCmd.Dispose();




        //}

        //CExcel.Close();
        //CExcel.Dispose();

        //DataS.Clear();


        //query = "INSERT INTO [Endeudamiento$](NIT, NOMBRE, APLICATIVO, NEG, DIASMORA, VRMORA, PAGO_MINIM, SDOCAPITAL, SALDO_TOTAL, SALDO_M_E, MONEDA, INTERESES_, OTROSCARGOS, TASA_DE_IN, COMPAÑIA, FECHAAP, FECHAVTO, CORTE, MACROPRODUCTO, SEGMENTOCORP, EJECUTIVO, DETALLECASOESPECIAL, CALIFICACION, SALDOCAPITALCLIENTE,  MAXIMAMORACC,  NITSECUNDARIOPA, NOMBRESECUNDARIOPA, EJECUTIVOSECUNDARIOPA,  TIPODECARTERA, GRUPOECONOMICO, REGIONAL,  VALORPROVISION, PROVISION, ZONAGERENTE, REGIONALEJEC, INTCTES, REGIONALCORPORATIVA) " +
        //  " values(@NIT, @NOMBRE, @APLICATIVO, @NEG, @DIASMORA, @VRMORA, @PAGO_MINIM, @SDOCAPITAL, @SALDO_TOTAL, @SALDO_M_E, @MONEDA, @INTERESES_, @OTROSCARGOS, @TASA_DE_IN, COMPAÑIA, @FECHAAP, @FECHAVTO, @CORTE, @MACROPRODUCTO, @SEGMENTOCORP, @EJECUTIVO, @DETALLECASOESPECIAL, @CALIFICACION, @SALDOCAPITALCLIENTE,  @MAXIMAMORACC,  @NITSECUNDARIOPA, @NOMBRESECUNDARIOPA, @EJECUTIVOSECUNDARIOPA,  @TIPODECARTERA, @GRUPOECONOMICO, @REGIONAL,  @VALORPROVISION, @PROVISION, @ZONAGERENTE, @REGIONALEJEC, @INTCTES, @REGIONALCORPORATIVA)";

        //for (int i = 0; i < DataS.Tables[0].Rows.Count; i++)
        //{
        //    objCmd = new OleDbCommand(query, CExcel);



        //    objCmd.Parameters.Add("@NIT", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["NIT"].ToString();
        //    objCmd.Parameters.Add("@NOMBRE", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["NOMBRE"].ToString();
        //    objCmd.Parameters.Add("@APLICATIVO", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["APLICATIVO"].ToString();
        //    objCmd.Parameters.Add("@NEG", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["NEG"].ToString();
        //    objCmd.Parameters.Add("@DIASMORA", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["DIASMORA"].ToString(); ;
        //    objCmd.Parameters.Add("@VRMORA", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["VRMORA"].ToString();
        //    objCmd.Parameters.Add("@PAGO_MINIM", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["PAGO_MINIM"].ToString();
        //    objCmd.Parameters.Add("@SDOCAPITAL", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["SDOCAPITAL"].ToString();
        //    objCmd.Parameters.Add("@SALDO_TOTAL", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["SALDO_TOTAL"].ToString(); ;
        //    objCmd.Parameters.Add("@SALDO_M_E", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["SALDO_M_E"].ToString(); ; ;
        //    objCmd.Parameters.Add("@MONEDA", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["MONEDA"].ToString();
        //    objCmd.Parameters.Add("@INTERESES_", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["INTERESES_"].ToString();
        //    objCmd.Parameters.Add("@OTROSCARGOS", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["OTROSCARGOS"].ToString(); ;
        //    objCmd.Parameters.Add("@TASA_DE_IN", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["TASA_DE_IN"].ToString(); ; ;
        //    objCmd.Parameters.Add("@COMPAÑIA", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["COMPAÑIA"].ToString();
        //    objCmd.Parameters.Add("@FECHAAP", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["FECHAAP"].ToString();
        //    objCmd.Parameters.Add("@FECHAVTO", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["FECHAVTO"].ToString();
        //    objCmd.Parameters.Add("@CORTE", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["CORTE"].ToString();
        //    objCmd.Parameters.Add("@MACROPRODUCTO", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["MACROPRODUCTO"].ToString();
        //    objCmd.Parameters.Add("@SEGMENTOCORP", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["SEGMENTOCORP"].ToString();
        //    objCmd.Parameters.Add("@EJECUTIVO", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["EJECUTIVO"].ToString();
        //    objCmd.Parameters.Add("@DETALLECASOESPECIAL", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["DETALLECASOESPECIAL"].ToString();
        //    objCmd.Parameters.Add("@CALIFICACION", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["CALIFICACION"].ToString();
        //    objCmd.Parameters.Add("@SALDOCAPITALCLIENTE", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["SALDOCAPITALCLIENTE"].ToString();
        //    objCmd.Parameters.Add("@MAXIMAMORACC", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["MAXIMAMORACC"].ToString();
        //    objCmd.Parameters.Add("@NITSECUNDARIOPA", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["NITSECUNDARIOPA"].ToString();
        //    objCmd.Parameters.Add("@NOMBRESECUNDARIOPA", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["NOMBRESECUNDARIOPA"].ToString();
        //    objCmd.Parameters.Add("@EJECUTIVOSECUNDARIOPA", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["EJECUTIVOSECUNDARIOPA"].ToString();
        //    objCmd.Parameters.Add("@TIPODECARTERA", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["TIPODECARTERA"].ToString();
        //    objCmd.Parameters.Add("@GRUPOECONOMICO", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["GRUPOECONOMICO"].ToString();
        //    objCmd.Parameters.Add("@REGIONAL", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["REGIONAL"].ToString();
        //    objCmd.Parameters.Add("@VALORPROVISION", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["VALORPROVISION"].ToString();
        //    objCmd.Parameters.Add("@PROVISION", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["PROVISION"].ToString();
        //    objCmd.Parameters.Add("@ZONAGERENTE", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["ZONAGERENTE"].ToString();
        //    objCmd.Parameters.Add("@REGIONALEJEC", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["REGIONALEJEC"].ToString();
        //    objCmd.Parameters.Add("@INTCTES", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["INTCTES"].ToString();
        //    objCmd.Parameters.Add("@REGIONALCORPORATIVA", OleDbType.VarChar).Value = DataS.Tables[0].Rows[i]["REGIONALCORPORATIVA"].ToString();


        //    objCmd.ExecuteNonQuery();
        //    objCmd.Dispose();
        //}

        //DataS.Clear();

        CExcel.Close();
        CExcel.Dispose();

        return true;

    }

    public Boolean ExportExcellDataset(int IDUser, DataSet DataS, string path)
    {

        string NomArchivo = "Report" + IDUser + ".xls";

        //string fileName = "Datos.xls";
        //string sourcePath = path + @"Archivos";
        string targetPath = path + @"Archivos\Datos";

        // Use Path class to manipulate file and directory paths.
        //  string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
        string destFile = System.IO.Path.Combine(targetPath, NomArchivo);

        //  System.IO.File.Copy(sourceFile, destFile, true);

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

        #region "Centrar encabezados en negrilla en Excel | Agustín David Cruz González (16/Jul/2014)."

        // Add some styles to the Workbook
        WorksheetStyle style = book.Styles.Add("Cabecera");
        style.Font.Bold = true;
        style.Alignment.Horizontal = StyleHorizontalAlignment.Center;

        //Bordes y color de encabezados | Agustín David Cruz González (16/Jul/2014).
        style.Interior.Pattern = StyleInteriorPattern.Solid;
        style.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
        style.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
        style.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
        style.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
        style.Interior.Color = "#D7E4BC";

        #endregion

        #region "Estilo para contenido | Agustín David Cruz González (16/Jul/2014)."

        WorksheetStyle style2 = book.Styles.Add("Contenido");
        style2.Interior.Pattern = StyleInteriorPattern.Solid;
        style2.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
        style2.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
        style2.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
        style2.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);

        #endregion

        // Add a Worksheet with some data
        Worksheet sheet = book.Worksheets.Add("Datos");

        WorksheetRow row = sheet.Table.Rows.Add();
        // Skip one row, and add some text
        row.Index = 1;

        for (int i = 0; i < DataS.Tables[0].Columns.Count; i++)
        {
            row.Cells.Add(new WorksheetCell(DataS.Tables[0].Columns[i].ColumnName, "Cabecera"));
        }

        for (int i = 0; i < DataS.Tables[0].Rows.Count; i++)
        {
            row = sheet.Table.Rows.Add();
            for (int j = 0; j < DataS.Tables[0].Columns.Count; j++)
            {
                row.Cells.Add(new WorksheetCell(Convert.ToString(DataS.Tables[0].Rows[i][j]), "Contenido"));
            }
        }
        DataS.Clear();
        book.Save(destFile);
        return true;

    }

    private bool impersonateValidUser(String userName, String domain, String password)
    {

        WindowsIdentity tempWindowsIdentity;
        IntPtr token = IntPtr.Zero;
        IntPtr tokenDuplicate = IntPtr.Zero;

        if (RevertToSelf())
        {
            if (LogonUserA(userName, domain, password, LOGON32_LOGON_INTERACTIVE,
            LOGON32_PROVIDER_DEFAULT, ref token) != 0)
            {
                if (DuplicateToken(token, 2, ref tokenDuplicate) != 0)
                {
                    tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
                    impersonationContext = tempWindowsIdentity.Impersonate();
                    if (impersonationContext != null)
                    {
                        CloseHandle(token);
                        CloseHandle(tokenDuplicate);
                        return true;
                    }
                }
            }
        }
        if (token != IntPtr.Zero)
            CloseHandle(token);
        if (tokenDuplicate != IntPtr.Zero)
            CloseHandle(tokenDuplicate);
        return false;

    }

    private void undoImpersonation()
    {
        impersonationContext.Undo();
    }
}
