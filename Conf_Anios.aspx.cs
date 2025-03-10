using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Conf_Anios : System.Web.UI.Page
{
    DataSet Dscompleto;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {

            Datos sv = new Datos();
            if (!sv.ComValidaPaginaPerfil(int.Parse(Session["IdPerfil"].ToString()), Request.Url.Segments[Request.Url.Segments.Length - 1]))
            {
                Response.Redirect("Salir.aspx");
            }
            GrillaLlenar();
        }
        else
        {
            Dscompleto = (DataSet)ViewState["DscompletoState"];
        }
    }

    private void GrillaLlenar()
    {
        Datos sv = new Datos();
        DataSet dts = new DataSet();

        dts = sv.SePeriodos(4);

        GrvPeriodos.DataSource = dts.Tables[0];
        GrvPeriodos.DataBind();
        Dscompleto = dts;
        GrvPeriodos.Columns[3].Visible = false;
        HidPeriodos.Value = "0";

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

    protected void GrvPeriodos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrvPeriodos.DataSource = SortDataTable(Dscompleto.Tables[0].DefaultView, true);
        // Calculate the current page number. 
        GrvPeriodos.PageIndex = e.NewPageIndex;
        // Reset selected index 
        GrvPeriodos.SelectedIndex = -1;
        GrvPeriodos.DataBind();
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



    protected void GrvPeriodos_Sorting(object sender, System.Web.UI.WebControls.GridViewSortEventArgs e)
    {
        GridViewSortExpression = e.SortExpression;
        // int pageIndex = GridLista.PageIndex;
        //  GrvPeriodos.DataSource = SortDataTable(Dscompleto.Tables[0].DefaultView, false);
        //  GrvPeriodos.DataBind();
        //   GrvPeriodos.PageIndex = pageIndex;
    }

    private void LimpiarText()
    {

        this.TxtAnio2.Text = "";
        HidPeriodos.Value = "0";
        TxtAnio2.Enabled = true;
        ChkOficial2.Checked = false;
    }

    protected void GrvPeriodos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index;
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        switch (e.CommandName)
        {
            case "Editar":
                index = int.Parse(e.CommandArgument.ToString());
                ds = sv.SePeriodos(index);
                TxtAnio2.Text = ds.Tables[0].Rows[0]["Anio_Mes"].ToString();
                ChkOficial2.Checked = Boolean.Parse(ds.Tables[0].Rows[0]["EstadoPeriodo"].ToString());
                HidPeriodos.Value = Convert.ToString(index);
                break;
            case "Eliminar":
                index = int.Parse(e.CommandArgument.ToString());
                sv.PeridosEliminar(index);
                GrillaLlenar();
                Response.Write("<script>alert('Perido Eliminado')</script>");
                break;
            default:
                break;
        }

    }
    protected void ImageButton20_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarText();
    }

    protected void ImageButton21_Click(object sender, ImageClickEventArgs e)
    {
        Datos sv = new Datos();
        if (HidPeriodos.Value == "0")
        {
            sv.PeridosIngresa(int.Parse(this.TxtAnio2.Text), this.ChkOficial2.Checked, true, Convert.ToInt32(Session["IdPais"].ToString()));
        }
        else
        {
            sv.PeridosIngresa(int.Parse(HidPeriodos.Value), this.ChkOficial2.Checked, false, Convert.ToInt32(Session["IdPais"].ToString()));
        }
        LimpiarText();
        GrillaLlenar();

        Response.Write("<script>alert('Periodo Creado')</script>");

    }

    protected void ImageButton22_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarText();
    }
}
