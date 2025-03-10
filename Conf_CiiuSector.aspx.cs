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

public partial class Conf_CiiuSector : System.Web.UI.Page
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
            LLenardatos();
            GrillaLlenar();
        }
        else
        {
            Dscompleto = (DataSet)ViewState["DscompletoState"];
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

        ds.Clear();

        ds = sv.CiiuLista();

        this.CmbCiiu.DataSource = ds.Tables[0].DefaultView;
        this.CmbCiiu.DataTextField = "Nombre";
        this.CmbCiiu.DataValueField = "Ciiu";
        this.CmbCiiu.DataBind();

        ds.Clear();

    }



    private void GrillaLlenar()
    {
        Datos sv = new Datos();

        DataSet ds = new DataSet();
        ds = sv.CiiuSectorLista();

        GridLista.DataSource = ds.Tables[0];
        GridLista.DataBind();
        Dscompleto = new DataSet();
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

    protected void GridLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string index;
        Datos sv = new Datos();

        DataSet ds = new DataSet();

        switch (e.CommandName)
        {
            case "Eliminar":
                index = e.CommandArgument.ToString();
                char delimiterDestinos = '#';
                string[] arr;

                arr = index.Split(delimiterDestinos);

                sv.EliminarSectorCiiu(int.Parse(arr[1].ToString()), int.Parse(arr[0].ToString()));
                GrillaLlenar();
                Response.Write("<script>alert('Sector Ciiu Eliminado')</script>");
                break;
            default:
                break;
        }

    }

    protected void ImageButton19_Click(object sender, ImageClickEventArgs e)
    {
        Datos sv = new Datos();
        int resultado;

        resultado = sv.InsertaSectorCiiu(int.Parse(this.cmbSectores.SelectedValue), int.Parse(this.CmbCiiu.SelectedValue));
        GrillaLlenar();

        if (resultado == 1)
        {
            Response.Write("<script>alert('Sector y Ciiu Ingresados')</script>");
        }
        else if (resultado == 0)
        {
            Response.Write("<script>alert('Sector y Ciiu ya Existe')</script>");
        }
        else if (resultado == 2)
        {
            Response.Write("<script>alert('Ciiu ya Existe Para otro Sector')</script>");
        }

    }

    private void filtrar()
    {
        Datos sv = new Datos();

        DataView vista = null;
        string filtro = null;

        if (this.txtBuscar.Text.Trim() != "")
        {
            filtro = "CONVERT(Ciiu, 'System.String') like '%" + txtBuscar.Text + "%' or Nombre like '%" + txtBuscar.Text + "%' or Sector like '%" + txtBuscar.Text + "%' or  CONVERT(IdSector, 'System.String')  like '%" + txtBuscar.Text + "%'";
            vista = new DataView(Dscompleto.Tables[0]);
            vista.RowFilter = filtro;

            DataSet dsFiltered = new DataSet(); //create a new dataset
            dsFiltered.Tables.Add(DataViewAsDataTable(vista)); //fill the dataset with the sorted results

            GridLista.DataSource = dsFiltered.Tables[0];
            GridLista.DataBind();
        }
        else
        {
            GridLista.DataSource = Dscompleto.Tables[0];
            GridLista.DataBind();
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        filtrar();
    }

    public static DataTable DataViewAsDataTable(DataView dv)
    {
        DataTable dt = dv.Table.Clone();
        foreach (DataRowView drv in dv)
            dt.ImportRow(drv.Row);
        return dt;
    }

}
