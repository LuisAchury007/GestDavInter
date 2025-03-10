using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;

public partial class GCTipoGarantias : System.Web.UI.Page
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
            llenarTipoGarantia();
            HidGarantia.Value = "0";
        }
        else
        {
                Dscompleto = (DataSet)ViewState["DscompletoState"];
                //GrvTipGarantias.DataSource = Dscompleto.Tables[0];
                //GrvTipGarantias.DataBind();
    
        }
    }

    protected void Page_PreRender(object sender, System.EventArgs e)
    {
        this.ViewState.Add("DscompletoState", Dscompleto);
    }
       
    protected void GrvTipGarantias_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataTable dataTable = GrvTipGarantias.DataSource as DataTable;
        DataView dataView = new DataView(dataTable);
        GrvTipGarantias.DataSource = SortDataTable(Dscompleto.Tables[0].DefaultView, true);
        // Calculate the current page number. 
        GrvTipGarantias.PageIndex = e.NewPageIndex;
        // Reset selected index 
        GrvTipGarantias.SelectedIndex = -1;
        GrvTipGarantias.DataBind();

        // Identificar en qué página estás
        int currentPageIndex = e.NewPageIndex + 1; // Sumar 1 porque los índices comienzan en 0
        Label2.Text = "Página actual: " + currentPageIndex.ToString();


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

    protected void GridEmpresas_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = GrvTipGarantias.DataSource as DataTable;
        DataView dataView = new DataView(dataTable);

        GridViewSortExpression = e.SortExpression;
        int pageIndex = GrvTipGarantias.PageIndex;
        GrvTipGarantias.DataSource = SortDataTable(dataView, false);
        GrvTipGarantias.DataBind();
        GrvTipGarantias.PageIndex = pageIndex;
    }

    protected void llenarTipoGarantia()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();
        
            ds = sv.SelTipGarantias(1, 0);
            GrvTipGarantias.DataSource = ds.Tables[0].DefaultView;
            GrvTipGarantias.DataBind();
            Dscompleto = ds;
        
       // ds.Clear();
    }

    protected void GrvTipGarantias_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();
        
            switch (e.CommandName)
            {
                case "Editar":
                    int IdTipGarantia;
                    IdTipGarantia = Convert.ToInt16(e.CommandArgument);
                    ds = sv.SelTipGarantias(2, IdTipGarantia);
                    txtIdTipoGarantia.Text = Convert.ToString(ds.Tables[0].Rows[0]["IdTipGarantia"]);
                    txtIdTipoGarantia.Enabled = false;
                    txtTipGarantias.Text = Convert.ToString(ds.Tables[0].Rows[0]["TipGarantia"]);
                    HidGarantias.Value = Convert.ToString(ds.Tables[0].Rows[0]["TipGarantia"]);
                    txtFactor.Text = Convert.ToString(ds.Tables[0].Rows[0]["Factor"]);
                    HidFactor.Value = Convert.ToString(ds.Tables[0].Rows[0]["Factor"]);
                    if (HidFactor.Value == "")
                    {
                        HidFactor.Value = "0";
                    }
                    HidGarantia.Value = Convert.ToString(IdTipGarantia);
                    break;
                case "Eliminar":
                    IdTipGarantia = Convert.ToInt16(e.CommandArgument);
                    sv.DelTipGarantias(IdTipGarantia);
                    ds = sv.SelTipGarantias(1, 0);
                    GrvTipGarantias.DataSource = ds.Tables[0].DefaultView;
                    GrvTipGarantias.DataBind();
                    LimpiarDatos();
                    Response.Write("<script>alert('Información Eliminada')</script>");

                    break;
                default:
                    break;
            }
      
    }

    protected void btnVolverGarantia_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarDatos();
    }

    protected void btnGuardaGarantia_Click(object sender, ImageClickEventArgs e)
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        
            if (HidGarantia.Value == "0")
            {
                int resultado = sv.InTipGarantias(int.Parse(txtIdTipoGarantia.Text), txtTipGarantias.Text, txtFactor.Text, 0, 0);
                if (resultado == 0)
                {
                    String DescripcionAudit = "Inserción tipo garantias: " + Convert.ToString(this.txtTipGarantias.Text) + ". Factor: " + Convert.ToDecimal(this.txtFactor.Text);
                    sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, Label1.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);
                }
                else
                {
                    Response.Write("<script>alert('El Id que esta ingresando ya se encuentra asignado')</script>");
                }
            }
            else
            {
                sv.UpTipGarantias(txtTipGarantias.Text, txtFactor.Text, 0, 0, int.Parse(HidGarantia.Value));

                String DescripcionAudit = "Actualización tipo garantias: " + Convert.ToString(this.txtTipGarantias.Text) + ".Tipo garantia anterior: " + this.HidGarantias.Value + ". Nuevo factor: " + Convert.ToDecimal(this.txtFactor.Text) + ". Factor anterior:" +
                Convert.ToDecimal(this.HidFactor.Value);
                sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, Label1.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

                HidGarantia.Value = "0";
            }

            ds = sv.SelTipGarantias(1, 0);
            GrvTipGarantias.DataSource = ds.Tables[0].DefaultView;
            GrvTipGarantias.DataBind();
            LimpiarDatos();
       
    }

    protected void LimpiarDatos()
    {
        HidGarantia.Value = "0";
        txtTipGarantias.Text = "";
        txtFactor.Text = "";
        txtIdTipoGarantia.Text = "";
        txtIdTipoGarantia.Enabled = true;
  
    }

    protected void GrvTipGarantias_Sorting(object sender, GridViewSortEventArgs e)
    {
        GridViewSortExpression = e.SortExpression;
        int pageIndex = GrvTipGarantias.PageIndex;
        GrvTipGarantias.DataSource = SortDataTable(Dscompleto.Tables[0].DefaultView, false);
        GrvTipGarantias.DataBind();
        GrvTipGarantias.PageIndex = pageIndex;
    }
}