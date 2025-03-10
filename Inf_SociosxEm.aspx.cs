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
using System.Text.RegularExpressions;

public partial class Inf_SociosxEm : System.Web.UI.Page
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

    #region Descargue Lista Empresas

    protected void ExportaPorEmpresa()
    {
        DataSet dsDatos1 = new DataSet();
        DataSet dsDatos2 = new DataSet();
        DataSet dsDatos3 = new DataSet();
        Datos sv = new Datos();

        dsDatos1 = sv.BencEmpresaDatos(TxtNit.Text, Convert.ToInt32(Session["IdPais"].ToString()));
        if (dsDatos1.Tables[0].Rows.Count > 0)
        {

            #region Variables y Propiedades
            string NomArchivo = "Coincidencias_Encontradas_" + dsDatos1.Tables[0].Rows[0]["NIT"] + "_" + dsDatos1.Tables[0].Rows[0]["RazonSocial"] + "_" + int.Parse(Session["IDusuario"].ToString()) + ".xls";
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
            #endregion


            #region "Centrar encabezados en negrilla en Excel | Agustín David Cruz González (24/Jun/2014)."

            // Add some styles to the Workbook
            WorksheetStyle style = book.Styles.Add("Cabecera");
            style.Font.Bold = true;
            style.Alignment.Horizontal = StyleHorizontalAlignment.Center;

            //Bordes y color de encabezados | Agustín David Cruz González (24/Jun/2014).
            style.Interior.Pattern = StyleInteriorPattern.Solid;
            style.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            style.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            style.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            style.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            style.Interior.Color = "#D7E4BC";

            #endregion

            #region "Estilo para contenido | Agustín David Cruz González (24/Jun/2014)."

            WorksheetStyle style2 = book.Styles.Add("Contenido");
            style2.Interior.Pattern = StyleInteriorPattern.Solid;
            style2.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            style2.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            style2.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            style2.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);

            #endregion

            #region Bloque Accionistas

            DataTable table2 = new DataTable("Tabla2");
            table2.Columns.Add(new DataColumn("GrupoEmpresarial", typeof(string)));
            table2.Columns.Add(new DataColumn("NIT", typeof(string)));
            table2.Columns.Add(new DataColumn("RazonSocial", typeof(string)));
            table2.Columns.Add(new DataColumn("nombre", typeof(string)));
            table2.Columns.Add(new DataColumn("Participacion", typeof(string)));
            table2.Columns.Add(new DataColumn("Documento", typeof(string)));
            table2.Columns.Add(new DataColumn("cedula", typeof(string)));

            for (int i = 0; i < dsDatos1.Tables[0].Rows.Count; i++)
            {
                dsDatos2 = sv.BencAccionistasEmpresa(TxtNit.Text, 2, Convert.ToInt32(Session["IdPais"].ToString()));
                for (int b = 0; b < dsDatos2.Tables[0].Rows.Count; b++)
                {
                    DataRow Fila1 = table2.NewRow();
                    Fila1["GrupoEmpresarial"] = dsDatos2.Tables[0].Rows[b]["GrupoEmpresarial"].ToString();
                    Fila1["NIT"] = dsDatos2.Tables[0].Rows[b]["NIT"].ToString();
                    Fila1["RazonSocial"] = dsDatos2.Tables[0].Rows[b]["RazonSocial"].ToString();
                    Fila1["nombre"] = dsDatos2.Tables[0].Rows[b]["nombre"].ToString();
                    Fila1["Participacion"] = dsDatos2.Tables[0].Rows[b]["Participacion"].ToString();
                    Fila1["Documento"] = dsDatos2.Tables[0].Rows[b]["Documento"].ToString();
                    Fila1["cedula"] = dsDatos2.Tables[0].Rows[b]["cedula"].ToString();

                    table2.Rows.Add(Fila1);
                }
            }

            DataSet ldsDatos2 = new DataSet();
            ldsDatos2.Tables.Add(table2);

            if (ldsDatos2 != null)
            {
                Worksheet sheetAccClinton = book.Worksheets.Add("Accionistas");
                WorksheetRow rowAccClinton = sheetAccClinton.Table.Rows.Add();

                rowAccClinton.Index = 1;

                for (int a = 0; a < ldsDatos2.Tables[0].Columns.Count; a++)
                {
                    rowAccClinton.Cells.Add(new WorksheetCell(ldsDatos2.Tables[0].Columns[a].ColumnName, "Cabecera"));
                }

                for (int a = 0; a < ldsDatos2.Tables[0].Rows.Count; a++)
                {
                    rowAccClinton = sheetAccClinton.Table.Rows.Add();

                    for (int j = 0; j < ldsDatos2.Tables[0].Columns.Count; j++)
                    {
                        rowAccClinton.Cells.Add(new WorksheetCell(Convert.ToString(ldsDatos2.Tables[0].Rows[a][j]), "Contenido"));
                    }
                }
                ldsDatos2.Clear();
            }
            #endregion

            #region Bloque Junta Directiva
            DataTable table = new DataTable("Tabla1");
            table.Columns.Add(new DataColumn("GrupoEmpresarial", typeof(string)));
            table.Columns.Add(new DataColumn("Nit", typeof(string)));
            table.Columns.Add(new DataColumn("RazonSocial", typeof(string)));
            table.Columns.Add(new DataColumn("Nombre", typeof(string)));
            table.Columns.Add(new DataColumn("TipoEjecutivo", typeof(string)));
            table.Columns.Add(new DataColumn("TipoDocumento", typeof(string)));
            table.Columns.Add(new DataColumn("Documento", typeof(string)));

            for (int z = 0; z < dsDatos1.Tables[0].Rows.Count; z++)
            {
                dsDatos3 = sv.BencEjecutivosEmp(TxtNit.Text, 2, Convert.ToInt32(Session["IdPais"].ToString()));
                for (int b = 0; b < dsDatos3.Tables[0].Rows.Count; b++)
                {
                    DataRow Fila = table.NewRow();
                    Fila["GrupoEmpresarial"] = dsDatos3.Tables[0].Rows[b]["GrupoEmpresarial"].ToString();
                    Fila["Nit"] = dsDatos3.Tables[0].Rows[b]["Nit"].ToString();
                    Fila["RazonSocial"] = dsDatos3.Tables[0].Rows[b]["RazonSocial"].ToString();
                    Fila["Nombre"] = dsDatos3.Tables[0].Rows[b]["Nombre"].ToString();
                    Fila["TipoEjecutivo"] = dsDatos3.Tables[0].Rows[b]["TipoEjecutivo"].ToString();
                    Fila["TipoDocumento"] = dsDatos3.Tables[0].Rows[b]["TipoDocumento"].ToString();
                    Fila["Documento"] = dsDatos3.Tables[0].Rows[b]["Documento"].ToString();
                    table.Rows.Add(Fila);
                }
            }

            DataSet ldsDatos = new DataSet();
            ldsDatos.Tables.Add(table);

            if (ldsDatos != null)
            {
                Worksheet sheetJunDClinton = book.Worksheets.Add("Junta Directiva");
                WorksheetRow rowJunDClinton = sheetJunDClinton.Table.Rows.Add();
                rowJunDClinton.Index = 1;

                for (int i = 0; i < ldsDatos.Tables[0].Columns.Count; i++)
                {
                    rowJunDClinton.Cells.Add(new WorksheetCell(ldsDatos.Tables[0].Columns[i].ColumnName, "Cabecera"));
                }

                for (int i = 0; i < ldsDatos.Tables[0].Rows.Count; i++)
                {
                    rowJunDClinton = sheetJunDClinton.Table.Rows.Add();

                    for (int j = 0; j < ldsDatos.Tables[0].Columns.Count; j++)
                    {
                        rowJunDClinton.Cells.Add(new WorksheetCell(Convert.ToString(ldsDatos.Tables[0].Rows[i][j]), "Contenido"));
                    }
                }
                ldsDatos.Clear();
            }

            dsDatos1.Clear();

            #endregion

            book.Save(destFile);

            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + NomArchivo);
            Response.Flush();
            Response.WriteFile(destFile);
            Response.End();
        }
        else
        {
            Response.Write("<script>alert('El nit ingresado no existe')</script>");
        }

    }

    protected void ExportaTodo()
    {
        DataSet dsDatos1 = new DataSet();
        DataSet dsDatos2 = new DataSet();
        DataSet dsDatos3 = new DataSet();
        Datos sv = new Datos();

        #region Variables y Propiedades
        string NomArchivo = "Coincidencias_Encontradas_" +  "_" + int.Parse(Session["IDusuario"].ToString()) + ".xls";
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
        #endregion


        #region "Centrar encabezados en negrilla en Excel | Agustín David Cruz González (24/Jun/2014)."

        // Add some styles to the Workbook
        WorksheetStyle style = book.Styles.Add("Cabecera");
        style.Font.Bold = true;
        style.Alignment.Horizontal = StyleHorizontalAlignment.Center;

        //Bordes y color de encabezados | Agustín David Cruz González (24/Jun/2014).
        style.Interior.Pattern = StyleInteriorPattern.Solid;
        style.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
        style.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
        style.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
        style.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
        style.Interior.Color = "#D7E4BC";

        #endregion

        #region "Estilo para contenido | Agustín David Cruz González (24/Jun/2014)."

        WorksheetStyle style2 = book.Styles.Add("Contenido");
        style2.Interior.Pattern = StyleInteriorPattern.Solid;
        style2.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
        style2.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
        style2.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
        style2.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);

        #endregion

        #region Bloque Accionistas

        DataTable table2 = new DataTable("Tabla2");
        table2.Columns.Add(new DataColumn("GrupoEmpresarial", typeof(string)));
        table2.Columns.Add(new DataColumn("NIT", typeof(string)));
        table2.Columns.Add(new DataColumn("RazonSocial", typeof(string)));
        table2.Columns.Add(new DataColumn("nombre", typeof(string)));
        table2.Columns.Add(new DataColumn("Participacion", typeof(string)));
        table2.Columns.Add(new DataColumn("Documento", typeof(string)));
        table2.Columns.Add(new DataColumn("cedula", typeof(string)));

       
            dsDatos2 = sv.BencAccionistasEmpresa("", 3, Convert.ToInt32(Session["IdPais"].ToString()));
            for (int b = 0; b < dsDatos2.Tables[0].Rows.Count; b++)
            {
                DataRow Fila1 = table2.NewRow();
                Fila1["GrupoEmpresarial"] = dsDatos2.Tables[0].Rows[b]["GrupoEmpresarial"].ToString();
                Fila1["NIT"] = dsDatos2.Tables[0].Rows[b]["NIT"].ToString();
                Fila1["RazonSocial"] = dsDatos2.Tables[0].Rows[b]["RazonSocial"].ToString();
                Fila1["nombre"] = dsDatos2.Tables[0].Rows[b]["nombre"].ToString();
                Fila1["Participacion"] = dsDatos2.Tables[0].Rows[b]["Participacion"].ToString();
                Fila1["Documento"] = dsDatos2.Tables[0].Rows[b]["Documento"].ToString();
                Fila1["cedula"] = dsDatos2.Tables[0].Rows[b]["cedula"].ToString();

                table2.Rows.Add(Fila1);
            }
       

        DataSet ldsDatos2 = new DataSet();
        ldsDatos2.Tables.Add(table2);

        if (ldsDatos2 != null)
        {
            Worksheet sheetAccClinton = book.Worksheets.Add("Accionistas");
            WorksheetRow rowAccClinton = sheetAccClinton.Table.Rows.Add();

            rowAccClinton.Index = 1;

            for (int a = 0; a < ldsDatos2.Tables[0].Columns.Count; a++)
            {
                rowAccClinton.Cells.Add(new WorksheetCell(ldsDatos2.Tables[0].Columns[a].ColumnName, "Cabecera"));
            }

            for (int a = 0; a < ldsDatos2.Tables[0].Rows.Count; a++)
            {
                rowAccClinton = sheetAccClinton.Table.Rows.Add();

                for (int j = 0; j < ldsDatos2.Tables[0].Columns.Count; j++)
                {
                    rowAccClinton.Cells.Add(new WorksheetCell(Convert.ToString(ldsDatos2.Tables[0].Rows[a][j]), "Contenido"));
                }
            }
            ldsDatos2.Clear();
        }
        #endregion

        #region Bloque Junta Directiva
        DataTable table = new DataTable("Tabla1");
        table.Columns.Add(new DataColumn("GrupoEmpresarial", typeof(string)));
        table.Columns.Add(new DataColumn("Nit", typeof(string)));
        table.Columns.Add(new DataColumn("RazonSocial", typeof(string)));
        table.Columns.Add(new DataColumn("Nombre", typeof(string)));
        table.Columns.Add(new DataColumn("TipoEjecutivo", typeof(string)));
        table.Columns.Add(new DataColumn("TipoDocumento", typeof(string)));
        table.Columns.Add(new DataColumn("Documento", typeof(string)));


        dsDatos3 = sv.BencEjecutivosEmp("", 3, Convert.ToInt32(Session["IdPais"].ToString()));
            for (int b = 0; b < dsDatos3.Tables[0].Rows.Count; b++)
            {
                DataRow Fila = table.NewRow();
                Fila["GrupoEmpresarial"] = dsDatos3.Tables[0].Rows[b]["GrupoEmpresarial"].ToString();
                Fila["Nit"] = dsDatos3.Tables[0].Rows[b]["Nit"].ToString();
                Fila["RazonSocial"] = dsDatos3.Tables[0].Rows[b]["RazonSocial"].ToString();
                Fila["Nombre"] = dsDatos3.Tables[0].Rows[b]["Nombre"].ToString();
                Fila["TipoEjecutivo"] = dsDatos3.Tables[0].Rows[b]["TipoEjecutivo"].ToString();
                Fila["TipoDocumento"] = dsDatos3.Tables[0].Rows[b]["TipoDocumento"].ToString();
                Fila["Documento"] = dsDatos3.Tables[0].Rows[b]["Documento"].ToString();
                table.Rows.Add(Fila);
            }
        

        DataSet ldsDatos = new DataSet();
        ldsDatos.Tables.Add(table);

        if (ldsDatos != null)
        {
            Worksheet sheetJunDClinton = book.Worksheets.Add("Junta Directiva");
            WorksheetRow rowJunDClinton = sheetJunDClinton.Table.Rows.Add();
            rowJunDClinton.Index = 1;

            for (int i = 0; i < ldsDatos.Tables[0].Columns.Count; i++)
            {
                rowJunDClinton.Cells.Add(new WorksheetCell(ldsDatos.Tables[0].Columns[i].ColumnName, "Cabecera"));
            }

            for (int i = 0; i < ldsDatos.Tables[0].Rows.Count; i++)
            {
                rowJunDClinton = sheetJunDClinton.Table.Rows.Add();

                for (int j = 0; j < ldsDatos.Tables[0].Columns.Count; j++)
                {
                    rowJunDClinton.Cells.Add(new WorksheetCell(Convert.ToString(ldsDatos.Tables[0].Rows[i][j]), "Contenido"));
                }
            }
            ldsDatos.Clear();
        }

        dsDatos1.Clear();

        #endregion

        book.Save(destFile);

        Response.Clear();
        Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + NomArchivo);
        Response.Flush();
        Response.WriteFile(destFile);
        Response.End();


    }

    protected void btExportar_Click(object sender, EventArgs e)
    {
        if (ChkSociostodos.Checked == false)
        {
            ExportaPorEmpresa();
        }
        else
        {
            ExportaTodo();
        }
    }
    #endregion
}