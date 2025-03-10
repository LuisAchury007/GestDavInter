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
using CarlosAg.ExcelXmlWriter;
using System.Text.RegularExpressions;

public partial class CredCargueEsClienteEmp : System.Web.UI.Page
{
    public string macroState = "collapse";
    DataSet DsErrores = new DataSet();

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
            macroState = "in";

        }
        else
        {
            DsErrores = (DataSet)ViewState["DscompletoState"];
        }
    }

    protected void Page_PreRender(object sender, System.EventArgs e)
    {
        this.ViewState.Add("DscompletoState", DsErrores);
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
                case ".XLSX":
                case ".XLSM":
                case ".XLS":
                    FileUpload1.SaveAs(ruta + FileUpload1.FileName);
                    ValidarAchivo(ruta + FileUpload1.FileName, extension.ToUpper());
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
        macroState = "in";

    }

    private void ValidarAchivo(string archivo, string Formato)
    {
        Datos sv = new Datos();
        OleDbConnection CExcel = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivo + ";Extended Properties='Excel 12.0 Macro;HDR=YES'");
        //OleDbConnection CExcel;
        //if (Formato == ".XLS")
        //{
        //    CExcel = new OleDbConnection(@"Provider = Microsoft.jet.oledb.4.0; Data Source= " + archivo + "; Extended Properties= 'Excel 8.0;hdr=yes;imex=1'");
        //}
        //else
        //{
        //    CExcel = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivo + ";Extended Properties='Excel 12.0 Macro;HDR=YES;imex=1'");
        //}
        CExcel.Open();
        DataTable dt = CExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

        if (dt != null)
        {
            String[] excelSheets = new String[dt.Rows.Count];
            String HojasBuscar = "EmpresaCliente$";
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
                DataSet DsCargar = new DataSet();

                DsCargar.Tables.Add("0");
                DsCargar.Tables["0"].Columns.Add("Nit", Type.GetType("System.String"));
                DsCargar.Tables["0"].Columns.Add("EsCliente", Type.GetType("System.String"));

                this.ListValidacion.BackColor = Color.White;
                this.ListValidacion.Items.Clear();
                this.ListValidacion.Visible = false;
                this.ImageButton7.Visible = false;

                if (DsErrores.Tables.Count == 0)
                {
                    DsErrores.Tables.Add("0");
                    DsErrores.Tables["0"].Columns.Add("Dato", Type.GetType("System.String"));
                    DsErrores.Tables["0"].Columns.Add("Error", Type.GetType("System.String"));
                }
                else
                {
                    DsErrores.Tables["0"].Clear();
                }
                /*se ejecuta la consulta a la hoha de excel*/
                OleDbDataAdapter AdpExcel = new OleDbDataAdapter("Select Nit,EsCliente from [EmpresaCliente$]", CExcel);
                /*se carga el resultadao en el dataset*/
                DataSet DS = new DataSet();
                DS.Tables.Add("Excel");
                AdpExcel.Fill(DS.Tables["Excel"]);

                for (int i = 0; i < DS.Tables["Excel"].Rows.Count; i++)
                {
                    if (int.Parse(DS.Tables["Excel"].Rows[i]["EsCliente"].ToString()) < 0 || int.Parse(DS.Tables["Excel"].Rows[i]["EsCliente"].ToString()) > 1)
                    {
                        this.ListValidacion.Items.Add("El parametro EsCliente para el NIT  " + DS.Tables["Excel"].Rows[i]["Nit"].ToString() + " debe ser 0 o 1 ");

                        DataRow row = DsErrores.Tables["0"].NewRow();
                        row["Dato"] = DS.Tables["Excel"].Rows[i]["NIT"].ToString();
                        row["Error"] = " El pararametro EsCliente: " + DS.Tables["Excel"].Rows[i]["EsCliente"].ToString() + " No Es Valido Para Cargar al Sistema";
                        DsErrores.Tables["0"].Rows.Add(row);
                        DsErrores.Tables["0"].AcceptChanges();
                    }
                }

                if (DS.Tables["Excel"].Rows.Count > 0)
                {
                    for (int i = 0; i < DS.Tables["Excel"].Rows.Count; i++)
                    {

                        DataRow rowCargar = DsCargar.Tables["0"].NewRow();
                        rowCargar["Nit"] = DS.Tables["Excel"].Rows[i]["Nit"].ToString();
                        rowCargar["EsCliente"] = DS.Tables["Excel"].Rows[i]["EsCliente"].ToString();

                        DsCargar.Tables["0"].Rows.Add(rowCargar);
                        DsCargar.Tables["0"].AcceptChanges();

                    }

                    if (DsCargar.Tables["0"].Rows.Count > 0)
                    {
                        for (int i = 0; i < DsCargar.Tables["0"].Rows.Count; i++)
                        {
                            sv.UpDatosEmpresa(4, DsCargar.Tables["0"].Rows[i]["Nit"].ToString(), "", int.Parse(DsCargar.Tables["0"].Rows[i]["EsCliente"].ToString()), Convert.ToInt32(Session["IdPais"].ToString()));
                        }

                        macroState = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */

                        if (this.ListValidacion.Items.Count == 0)
                        {

                            Response.Write("<script>alert('Información Cargada Correctamente')</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Se cargaron solamente los registros válidos')</script>");
                            this.ListValidacion.BackColor = Color.Yellow;
                            this.ListValidacion.Visible = true;
                            this.ImageButton7.Visible = true;
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Ningún registro es válido para cargar al sistema')</script>");
                        this.ListValidacion.BackColor = Color.Red;
                        this.ListValidacion.Visible = true;
                        this.ImageButton7.Visible = true;
                    }
                    DS.Clear();
                }
                else
                {
                    Response.Write("<script>alert('Archivo No Contiene Registros')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Falta la Hoja EmpresaCliente Con la Información Correspondiente')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Archivo No Contiene Hojas')</script>");
        }

    }

    public void GenerarArchivos(string name, DataSet dsDatos)
    {

        string NomArchivo = "Listado" + int.Parse(Session["IDusuario"].ToString()) + ".xls";
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
        book.Properties.Author = "GestorCC";
        book.Properties.Title = "Gestor Comercial y de Credito";
        book.Properties.Created = DateTime.Now;

        #region "Centrar encabezados en negrilla en Excel | Agustín David Cruz González (22/Jul/2014)."

        // Add some styles to the Workbook
        WorksheetStyle style = book.Styles.Add("Cabecera");
        style.Font.Bold = true;
        style.Alignment.Horizontal = StyleHorizontalAlignment.Center;

        //Bordes y color de encabezados | Agustín David Cruz González (22/Jul/2014).
        style.Interior.Pattern = StyleInteriorPattern.Solid;
        style.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
        style.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
        style.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
        style.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
        style.Interior.Color = "#D7E4BC";

        #endregion

        #region "Estilo para contenido | Agustín David Cruz González (22/Jul/2014)."

        WorksheetStyle style2 = book.Styles.Add("Contenido");
        style2.Interior.Pattern = StyleInteriorPattern.Solid;
        style2.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
        style2.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
        style2.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
        style2.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);

        #endregion

        // Add a Worksheet with some data
        Worksheet sheet = book.Worksheets.Add(name);
        WorksheetRow row = sheet.Table.Rows.Add();

        row.Index = 1;

        for (int i = 0; i < dsDatos.Tables[0].Columns.Count; i++)
        {
            row.Cells.Add(new WorksheetCell(dsDatos.Tables[0].Columns[i].ColumnName, "Cabecera"));
        }

        for (int i = 0; i < dsDatos.Tables[0].Rows.Count; i++)
        {
            row = sheet.Table.Rows.Add();

            for (int j = 0; j < dsDatos.Tables[0].Columns.Count; j++)
            {
                row.Cells.Add(new WorksheetCell(Convert.ToString(dsDatos.Tables[0].Rows[i][j]), "Contenido"));
            }
        }

        book.Save(destFile);

        dsDatos.Clear();

        Response.Clear();
        Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + NomArchivo);
        Response.Flush();
        Response.WriteFile(destFile);

        ApplicationInstance.CompleteRequest();

    }

    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {
        GenerarArchivos("Errores", DsErrores);
    }
}