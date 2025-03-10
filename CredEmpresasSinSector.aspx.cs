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

public partial class CredEmpresasSinSector : System.Web.UI.Page
{

    DataSet Dscompleto;
   string[] lista;

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

            GrillaLlenar();
            LLenardatos();


        }
        else
        {
            llenarlista();
            Dscompleto = (DataSet)ViewState["DscompletoState"];
            GridLista.DataSource = Dscompleto.Tables[0];
            GridLista.DataBind();

        }


    }

    private void LLenardatos()
    {

        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = sv.CredSectoresCombo();

        this.cmbSectores.DataSource = ds.Tables[0].DefaultView;
        this.cmbSectores.DataTextField = "Sector";
        this.cmbSectores.DataValueField = "IdSector";
        this.cmbSectores.DataBind();

    }

    protected void Page_PreRender(object sender, System.EventArgs e)
    {
        this.ViewState.Add("DscompletoState", Dscompleto);
    }

    public void llenarlista()
    {
        // lista = null;
        int i = 0;
        int contador = 1;
        for (i = 0; i < this.GridLista.Rows.Count; i++)
        {
            //En la posición 13 es en donde se encuentra el control Check.
            if (((CheckBox)this.GridLista.Rows[i].Cells[0].Controls[1]).Checked)
            {
                Array.Resize(ref lista, (contador));
                lista[contador - 1] = this.GridLista.Rows[i].Cells[1].Text;
                contador += 1;
            }
        }
    }

    private void GrillaLlenar()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = sv.CredEmpresasSinSector(txtNitBuscar.Text, 1, Convert.ToInt32(Session["IdPais"].ToString()));
        GridLista.DataSource = ds.Tables[0].DefaultView;
        GridLista.DataBind();
        Dscompleto = new DataSet();
        Dscompleto = ds;
        // ds.Clear();
    }

    protected void OkButton_Click(object sender, EventArgs e)
    {
        Datos sv = new Datos();
        int i = 0;

        for (i = 0; i < lista.Length; i++)
        {

            sv.CredEmpresaSectorCambiar(lista[i], int.Parse(cmbSectores.SelectedValue), 99, Convert.ToInt32(Session["IdPais"].ToString()));

        }

        GrillaLlenar();

    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        //llenarlista();
        ds = sv.CredEmpresasSinSector(txtNitBuscar.Text, 2, Convert.ToInt32(Session["IdPais"].ToString()));
        GridLista.DataSource = ds.Tables[0].DefaultView;
        GridLista.DataBind();
    }

    #region Orden y Paginación Grid
    public string GridViewSortDirection
    {

        get
        {
            object o = ViewState["SortDirection"];
            return ((o == null) ? "ASC" : Convert.ToString(o));
        }
        set { ViewState["SortDirection"] = value; }
    }

    public string GridViewSortExpression
    {
        get
        {
            object o = ViewState["SortExpression"];
            return ((o == null) ? string.Empty : Convert.ToString(o));
        }
        set { ViewState["SortExpression"] = value; }
    }

    protected string GetSortDirection()
    {
        switch ((GridViewSortDirection))
        {

            case "ASC":
                GridViewSortDirection = "DESC";

                break;
            case "DESC":
                GridViewSortDirection = "ASC";

                break;
        }

        return GridViewSortDirection;

    }

    protected void Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataTable dataTable = GridLista.DataSource as DataTable;
        DataView dataView = new DataView(dataTable);


        GridLista.DataSource = SortDataTable(dataView, true);
        // Calculate the current page number. 
        GridLista.PageIndex = e.NewPageIndex;


        // Reset selected index 
        GridLista.SelectedIndex = -1;

        GridLista.DataBind();

        // Identificar en qué página estás
        int currentPageIndex = e.NewPageIndex + 1; // Sumar 1 porque los índices comienzan en 0
        Label1.Text = "Página actual: " + currentPageIndex.ToString();


    }

    protected DataView SortDataTable(DataView DataTable1, bool isPageIndexChanging)
    {
        if ((DataTable1 != null))
        {
            DataView vista = DataTable1;


            if ((!string.IsNullOrEmpty(GridViewSortExpression)))
            {
                if ((isPageIndexChanging))
                {
                    vista.Sort = GridViewSortExpression + " " + GridViewSortDirection;
                }
                else
                {
                    vista.Sort = GridViewSortExpression + " " + GetSortDirection();

                }
            }
            return vista;
        }
        else
        {
            return new DataView();
        }
    }

    protected void Grid_Sorting(object sender, System.Web.UI.WebControls.GridViewSortEventArgs e)
    {
        DataTable dataTable = GridLista.DataSource as DataTable;


        DataView dataView = new DataView(dataTable);

        GridViewSortExpression = e.SortExpression;
        int pageIndex = GridLista.PageIndex;
        GridLista.DataSource = SortDataTable(dataView, false);
        GridLista.DataBind();
        GridLista.PageIndex = pageIndex;


    }
    #endregion

    // ** 16-Julio-2014 ** --> Se copia y edita el método ImageButton7_Click
    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {
        DataSet dsDatos = new DataSet();
        dsDatos = Dscompleto;



        string NomArchivo = "EmpresasSinSector" + int.Parse(Session["IDusuario"].ToString()) + ".xls";
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
        Worksheet sheet = book.Worksheets.Add("Sin Sector");
        WorksheetRow row = sheet.Table.Rows.Add();

        row.Index = 1;

        for (int i = 0; i < dsDatos.Tables[0].Columns.Count; i++)
        {
            row.Cells.Add(new WorksheetCell(dsDatos.Tables[0].Columns[i].ColumnName, "Cabecera"));
        }
        //row.Cells.RemoveAt(2);//Quita la columna de IdAsunto para no exportarla
        //row.Cells.RemoveAt(5);//Quita la columna de IdContacto para no exportarla
        //row.Cells.RemoveAt(6);//Quita la columna de IdActividad para no exportarla


        for (int i = 0; i < dsDatos.Tables[0].Rows.Count; i++)
        {
            row = sheet.Table.Rows.Add();

            for (int j = 0; j < dsDatos.Tables[0].Columns.Count; j++)
            {
                row.Cells.Add(new WorksheetCell(Convert.ToString(dsDatos.Tables[0].Rows[i][j]), "Contenido"));
            }
            //row.Cells.RemoveAt(2);//Quita la columna de IdAsunto para no exportarla
            //row.Cells.RemoveAt(5);//Quita la columna de IdContacto para no exportarla
            //row.Cells.RemoveAt(6);//Quita la columna de IdActividad para no exportarla
        }


        book.Save(destFile);

        dsDatos.Clear();

        Response.Clear();
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + NomArchivo);
        Response.Flush();
        Response.WriteFile(destFile);

        ApplicationInstance.CompleteRequest();


    }
    //Fin método ImageButton7_Click ** Copiado y editado por Agustín David Cruz González **
}
