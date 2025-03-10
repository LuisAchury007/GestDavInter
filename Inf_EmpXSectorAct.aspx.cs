using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text.RegularExpressions;




public partial class Inf_EmpXSectorAct : System.Web.UI.Page
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

            LLenardatos();
        }
        else
        {
            Dscompleto = (DataSet)ViewState["DscompletoState"];

            if (HidTipoBusqueda.Value != "0")
            {
                grvProyecPendiente.DataSource = Dscompleto.Tables[0];
                grvProyecPendiente.DataBind();
            }
        }
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

    protected void grvProyecPendiente_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataTable dataTable = grvProyecPendiente.DataSource as DataTable;
        DataView dataView = new DataView(dataTable);
        grvProyecPendiente.DataSource = SortDataTable(dataView, true);
        // Calculate the current page number. 
        grvProyecPendiente.PageIndex = e.NewPageIndex;
        // Reset selected index 
        grvProyecPendiente.SelectedIndex = -1;
        grvProyecPendiente.DataBind();

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
        DataTable dataTable = grvProyecPendiente.DataSource as DataTable;


        DataView dataView = new DataView(dataTable);

        GridViewSortExpression = e.SortExpression;
        int pageIndex = grvProyecPendiente.PageIndex;
        grvProyecPendiente.DataSource = SortDataTable(dataView, false);
        grvProyecPendiente.DataBind();
        grvProyecPendiente.PageIndex = pageIndex;


    }

    public static DataTable DataViewAsDataTable(DataView dv)
    {
        DataTable dt = dv.Table.Clone();
        foreach (DataRowView drv in dv)
            dt.ImportRow(drv.Row);
        return dt;
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

    protected void Button5_Click(object sender, EventArgs e)
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();
        HidTipoBusqueda.Value = "1";

        ds = sv.BencEmpresasLista(int.Parse(cmbSectores.SelectedValue));

        grvProyecPendiente.DataSource = ds.Tables[0].DefaultView;
        grvProyecPendiente.DataBind();
        Dscompleto = ds;

        // ds.Clear();
    }

    protected void grvProyecPendiente_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Datos sv = new Datos();
            DataSet ds = new DataSet();

            int IdGrupoEm = 0;
            string IdEmpresa = DataBinder.Eval(e.Row.DataItem, "NIT").ToString();
            Label lbllGrupoempresarial = (e.Row.FindControl("lbllGrupoempresarial") as Label);


            ds = sv.BencEmpresaDatos(IdEmpresa, Convert.ToInt32(Session["IdPais"].ToString()));
            if (ds.Tables[0].Rows.Count > 0)
            {
                IdGrupoEm = int.Parse(ds.Tables[0].Rows[0]["IdGrupoEm"].ToString());

                if (IdGrupoEm == 0)
                {
                    lbllGrupoempresarial.Text = ds.Tables[0].Rows[0]["RazonSocial"].ToString();
                }
                else
                {
                    lbllGrupoempresarial.Text = ds.Tables[0].Rows[0]["GrupoEmpresarial"].ToString();
                }

            }

        }
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
}