using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Inf_CalificacionMasiva : System.Web.UI.Page
{
    DataSet Dscompleto;

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
            txtFechaI.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now.AddDays(-30));
            txtFechaF.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);

            GrillaLlenar();
        }
        else
        {
            Dscompleto = (DataSet)ViewState["DscompletoState"];
            //GridLista.DataSource = Dscompleto.Tables[0];
            //GridLista.DataBind();
        }


    }

    private void GrillaLlenar()
    {

        Datos sv = new Datos();
        DataSet ds = new DataSet();
        Funciones fun = new Funciones();


        ds = sv.CredCaliMasivaxFecha(fun.Cononica(txtFechaI.Text), fun.Cononica(txtFechaF.Text));

        GridLista.DataSource = ds.Tables[0].DefaultView;
        GridLista.DataBind();
        Dscompleto = ds;

        // ds.Clear();
    }

    protected void Page_PreRender(object sender, System.EventArgs e)
    {
        this.ViewState.Add("DscompletoState", Dscompleto);
    }

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

    public static DataTable DataViewAsDataTable(DataView dv)
    {
        DataTable dt = dv.Table.Clone();
        foreach (DataRowView drv in dv)
            dt.ImportRow(drv.Row);
        return dt;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        GrillaLlenar();
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

        Funciones fun = new Funciones();
        string filename;

        if (fun.CrearReport(int.Parse(Session["IDusuario"].ToString()), Request.ServerVariables["APPL_PHYSICAL_PATH"], Dscompleto))
        {

            filename = "Report" + Session["IDusuario"].ToString() + ".xls";

            string filepath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Archivos\Datos\" + filename;

            filename = "Report.xls";
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.Flush();
            Response.WriteFile(filepath);
            
            ApplicationInstance.CompleteRequest();

        }

    }

    protected void GridLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        long index;
        Datos sv = new Datos();
        DataSet DataS = new DataSet();
        Funciones fun = new Funciones();
        string filename;

        switch (e.CommandName)
        {
            case "CFinal":
                index = long.Parse(e.CommandArgument.ToString());
                DataS = sv.CredCfinalxInfo(0, index, 1);
                if (fun.ExportExcellDataset(int.Parse(Session["IDusuario"].ToString()), DataS, Request.ServerVariables["APPL_PHYSICAL_PATH"]))
                {
                    filename = "Report" + Session["IDusuario"].ToString() + ".xls";
                    string filepath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Archivos\Datos\" + filename;

                    //filename = "Report.xls";
                    //Response.Clear();
                    //Response.ContentType = "application/octet-stream";
                    //Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                    //Response.Flush();
                    //Response.WriteFile(filepath);

                    //ApplicationInstance.CompleteRequest();

                    FileInfo fi = new FileInfo(filepath);
                    long sz = fi.Length;

                    filename = "Report.xls";
                    Response.Clear();
                    Response.ClearContent();
                    Response.ContentType = "application/vnd.ms-excel.sheet.macroEnabled.12";
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                    Response.AddHeader("Content-Length", sz.ToString("F0"));
                    Response.TransmitFile(filepath);

                    Response.Flush();

                    ApplicationInstance.CompleteRequest();

                }

                DataS.Clear();

                break;

            case "log":

                index = long.Parse(e.CommandArgument.ToString());
                DataS = sv.CredCfinalxInfo(index);
                if (fun.ExportExcellDataset(int.Parse(Session["IDusuario"].ToString()), DataS, Request.ServerVariables["APPL_PHYSICAL_PATH"]))
                {
                    filename = "Report" + Session["IDusuario"].ToString() + ".xls";
                    string filepath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Archivos\Datos\" + filename;

                    //filename = "Report.xls";
                    //Response.Clear();
                    //Response.ContentType = "application/octet-stream";
                    //Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                    //Response.Flush();
                    //Response.WriteFile(filepath);

                    //ApplicationInstance.CompleteRequest();

                    FileInfo fi = new FileInfo(filepath);
                    long sz = fi.Length;

                    filename = "Report.xls";
                    Response.Clear();
                    Response.ClearContent();
                    Response.ContentType = "application/vnd.ms-excel.sheet.macroEnabled.12";
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                    Response.AddHeader("Content-Length", sz.ToString("F0"));
                    Response.TransmitFile(filepath);

                    Response.Flush();

                    ApplicationInstance.CompleteRequest();

                }


                DataS.Clear();

                break;
            default:

                break;
        }
    }


}