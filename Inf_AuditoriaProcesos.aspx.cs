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

public partial class Inf_AuditoriaProcesos : System.Web.UI.Page
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
            CargarCombo();
        }
        else
        {
            Dscompleto = (DataSet)ViewState["DscompletoState"];
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Funciones fun = new Funciones();
        string filename;
        Datos sv = new Datos();
        DataSet ds = new DataSet();

       
            ds = sv.SeDatosAuditoria(this.cmbModulos.SelectedItem.ToString(), this.txtFechaI.Text, this.txtFechaF.Text);

            if (ds.Tables[0].Rows.Count > 0)
            {

                if (fun.CrearReport(int.Parse(Session["IDusuario"].ToString()), Request.ServerVariables["APPL_PHYSICAL_PATH"], ds))
                {
                    filename = "Report" + Session["IDusuario"].ToString() + ".xls";
                    string filepath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Archivos\Datos\" + filename;

                    filename = "Report.xls";
                    Response.Clear();
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                    Response.Flush();
                    Response.WriteFile(filepath);
                /*  Response.SuppressContent = true;
                  ApplicationInstance.CompleteRequest();*/
                Response.End();
            }
            }
            else
            {
                Response.Write("<script>alert('No hay registros almacenados para la fecha " + txtFechaI.Text + ".')</script>");
            }
     

    }

    protected void CargarCombo()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();
        DataView vista = new DataView();
        
            ds = sv.SeMenuOpcionesAuditoria(1);
            ds.Tables[0].Rows.Add("-1", " Seleccione");
            vista = ds.Tables[0].DefaultView;
            vista.Sort = "IdOpcion ASC";

            this.cmbModulos.DataSource = vista;
            this.cmbModulos.SelectedValue = "-1";
            this.cmbModulos.DataTextField = "OpcionAplicativo";
            this.cmbModulos.DataValueField = "IdOpcion";
 			this.cmbModulos.DataBind();
       
        ds.Clear();
    }

    protected void cmbModulos_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarDatosAuditoria(this.cmbModulos.SelectedItem.ToString(), this.txtFechaI.Text, this.txtFechaF.Text);
    }
    
    protected void CargarDatosAuditoria(String opcion, String fecha , String fechaF)
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();
       
            ds = sv.SeDatosAuditoria(opcion, fecha, fechaF); 
            GridLista.DataSource = ds.Tables[0].DefaultView;
            GridLista.DataBind();
            Dscompleto = new DataSet();
            Dscompleto = ds;
      
    }
    
    /* INICIO PAGINADOR Y ORDENADOR DE GRIDVIEW */
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
        GridLista.DataSource = SortDataTable(Dscompleto.Tables[0].DefaultView, true);
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
        GridViewSortExpression = e.SortExpression;
        int pageIndex = GridLista.PageIndex;
        GridLista.DataSource = SortDataTable(Dscompleto.Tables[0].DefaultView, false);
        GridLista.DataBind();
        GridLista.PageIndex = pageIndex;
    }
    /* FIN PAGINADOR Y ORDENADOR DE GRIDVIEW */


}