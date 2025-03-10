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

public partial class Conf_Perfiles : System.Web.UI.Page
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
            HNuevo.Value = "true";

        }
        else
        {
            Dscompleto = (DataSet)ViewState["DscompletoState"];
            // GridLista.DataSource = Dscompleto.Tables[0].DefaultView;
            // GridLista.DataBind();
        }
    }

    private void GrillaLlenar()
    {
        Datos sv = new Datos();

        DataSet ds = new DataSet();
        ds = sv.Perfiles();

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

    private void LimpiarText()
    {
        this.TxtPerfil.Text = "";
     //   this.CheckBox1.Checked = false;
        //this.CheckBox2.Checked = false;
        //this.CheckBox3.Checked = false;
        //this.CheckBox4.Checked = false;
        //this.CheckBox5.Checked = false;
        this.CheckBox7.Checked = false;
        this.HNuevo.Value = "true";
        this.TxtPagina.Text = "";
    }

    protected void GridLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index;
        Datos sv = new Datos();

        switch (e.CommandName)
        {
            case "Editar":
                index = Convert.ToInt16(e.CommandArgument);
                DataSet ds = new DataSet();
                ds = sv.PerfilDatos(index);

                this.TxtPerfil.Text = Convert.ToString(ds.Tables[0].Rows[0]["Perfil"]);
                this.TxtPagina.Text = Convert.ToString(ds.Tables[0].Rows[0]["PaginaInicio"]);
               // this.CheckBox1.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["VerInfoFinanciera"]);
               /* this.CheckBox2.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["VerRib"]);
                this.CheckBox3.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["VerAsignados"]);
                this.CheckBox4.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["EnviaMControl"]);
                this.CheckBox5.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["EnviaCoordinador"]);
               // this.CheckBox6.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["HabilitaFirma"]);*/
                this.CheckBox7.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["CrearEmpresaGE"]);

                ds.Clear();

                HIdPerfil.Value = index.ToString();
                HNuevo.Value = "false";
                break;
            case "Eliminar":
                index = Convert.ToInt16(e.CommandArgument);
                sv.PerfilEliminar(index);

                LimpiarText();
                GrillaLlenar();
                Response.Write("<script>alert('Perfil Eliminado')</script>");
                break;
            default:
                break;
        }

    }

    protected void ImageButton19_Click(object sender, ImageClickEventArgs e)
    {
        Datos sv = new Datos();

        if (HNuevo.Value == "true")
        {
            sv.PerfilIngresar(this.TxtPerfil.Text, this.TxtPagina.Text,false, false,false,false,false, false, this.CheckBox7.Checked);

            LimpiarText();
            GrillaLlenar();
            Response.Write("<script>alert('Perfil Creado')</script>");
        }
        else
        {
            sv.PerfilActualiza(int.Parse(this.HIdPerfil.Value), this.TxtPerfil.Text, this.TxtPagina.Text, false, false, false, false, false, false, this.CheckBox7.Checked);

            LimpiarText();
            GrillaLlenar();
            Response.Write("<script>alert('Perfil Actualizado')</script>");
        }

    }

    protected void ImageButton20_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarText();
    }

    protected void GridLista_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Datos sv = new Datos();

            DataSet ds = new DataSet();
            int Perfil = Convert.ToInt32(GridLista.DataKeys[e.Row.RowIndex]["IdPerfil"]);
           // CheckBox chkVerInfoFinanciera = (e.Row.FindControl("chkVerInfoFinanciera") as CheckBox);
            //CheckBox chkVerRib = (e.Row.FindControl("chkVerRib") as CheckBox);
            //CheckBox chkVerAsignados = (e.Row.FindControl("chkVerAsignados") as CheckBox);
            //CheckBox chkEnviaMControl = (e.Row.FindControl("chkEnviaMControl") as CheckBox);
            //CheckBox chkEnviaCoordinador = (e.Row.FindControl("chkEnviaCoordinador") as CheckBox);
           // CheckBox chkHabilitaFirma = (e.Row.FindControl("chkHabilitaFirma") as CheckBox);
            CheckBox chkCrearEmpresaGE = (e.Row.FindControl("chkCrearEmpresaGE") as CheckBox);

            ds = sv.PerfilDatos(Perfil);
          //  chkVerInfoFinanciera.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["VerInfoFinanciera"]);
            //chkVerRib.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["VerRib"]);
            //chkVerAsignados.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["VerAsignados"]);
            //chkEnviaMControl.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["EnviaMControl"]);
            //chkEnviaCoordinador.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["EnviaCoordinador"]);

           
            chkCrearEmpresaGE.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["CrearEmpresaGE"]);

        }
    }
}
