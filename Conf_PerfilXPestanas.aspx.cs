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

public partial class Conf_PerfilXPestanas : System.Web.UI.Page
{
    int[] lista = null;
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
            llenarlista();
        }
    }

    private void LLenardatos()
    {

        Datos sv = new Datos();

        DataSet ds = new DataSet();

        ds = sv.Perfiles();

        this.CmbPerfil.DataSource = ds.Tables[0].DefaultView;
        this.CmbPerfil.DataTextField = "Perfil";
        this.CmbPerfil.DataValueField = "IdPerfil";
        this.CmbPerfil.DataBind();

    }

    public void llenarlista()
    {
        int i = 0;
        int contador = 1;
        for (i = 0; i < this.GridLista.Rows.Count; i++)
        {
            if (((CheckBox)this.GridLista.Rows[i].Cells[0].Controls[1]).Checked)
            {
                Array.Resize(ref lista, contador);
                lista[contador - 1] = int.Parse(GridLista.DataKeys[i].Value.ToString());
                contador += 1;
            }
        }
    }

    protected void Page_PreRender(object sender, System.EventArgs e)
    {
        this.ViewState.Add("DscompletoState", Dscompleto);
    }

    protected void Grid_Sorting(object sender, System.Web.UI.WebControls.GridViewSortEventArgs e)
    {
        GridViewSortExpression = e.SortExpression;
        int pageIndex = GridLista.PageIndex;
        GridLista.DataSource = SortDataTable(Dscompleto.Tables[0].DefaultView, false);
        GridLista.DataBind();
        GridLista.PageIndex = pageIndex;
        Checkalo();
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

    private void GrillaLlenar()
    {
        Datos sv = new Datos();

        DataSet ds = new DataSet();

        ds = sv.PestanasXPerfiles();

        GridLista.DataSource = ds.Tables[0].DefaultView;
        GridLista.DataBind();

        Dscompleto = new DataSet();
        Dscompleto = ds;
        Checkalo();

    }

    private void Checkalo()
    {
        Datos sv = new Datos();

        DataSet ds2 = new DataSet();

        int i = 0;
        for (i = 0; i < GridLista.Rows.Count; i++)
        {
            int valor = 0;
            valor = int.Parse(GridLista.DataKeys[i].Value.ToString());

            ds2 = sv.ExistePerfilXPestana(int.Parse(this.CmbPerfil.SelectedValue), valor, 1);

            if (ds2.Tables[0].Rows.Count > 0)
            {
                ((CheckBox)this.GridLista.Rows[i].Cells[0].Controls[1]).Checked = true;
            }
            ds2.Clear();
        }

    }

    protected void ImageButton19_Click(object sender, ImageClickEventArgs e)
    {
        Datos sv = new Datos();

        sv.IngresaMenuPestana(int.Parse(this.CmbPerfil.SelectedValue), 0, 2);

        int i = 0;
        int IdMenu = 0;
        if ((lista != null))
        {
            for (i = 0; i < lista.Length; i++)
            {
                IdMenu = int.Parse(lista[i].ToString());
                sv.IngresaMenuPestana(int.Parse(this.CmbPerfil.SelectedValue), IdMenu, 1);
            }
        }

    }

    protected void CmbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
    {
        GrillaLlenar();
    }
}