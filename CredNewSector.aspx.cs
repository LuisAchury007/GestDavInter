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

public partial class CredNewSector : System.Web.UI.Page
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
            this.HidSectores.Value = "0";

            LLenarDatosGrillaSectores();
            LLenarDatos();

        }
        else
        {
            Dscompleto = (DataSet)ViewState["DscompletoState"];

        }


    }

    protected void Page_PreRender(object sender, System.EventArgs e)
    {
        this.ViewState.Add("DscompletoState", Dscompleto);
    }

    public void LLenarDatos()
    {
        Datos sv = new Datos();
        DataSet dts = new DataSet();
        DataView vista = new DataView();


        dts = sv.SEPucModelo("PUC", true, 1);
        dts.Tables[0].Rows.Add("-1", "Seleccione>>");
        vista = dts.Tables[0].DefaultView;
        vista.Sort = "IdCuenta ASC";

        cmbCuenta.DataSource = vista;
        cmbCuenta.DataTextField = "Cuenta";
        cmbCuenta.DataValueField = "IdCuenta";
        cmbCuenta.DataBind();
        dts.Clear();

        dts = sv.SEPucModelo("Modelo", true, 1);
        dts.Tables[0].Rows.Add("-1", "Seleccione>>");
        vista = dts.Tables[0].DefaultView;
        vista.Sort = "IdModelo ASC";

        CmbModelo.DataSource = vista;
        CmbModelo.DataTextField = "Modelo";
        CmbModelo.DataValueField = "IdModelo";
        CmbModelo.DataBind();
        dts.Clear();


        dts = sv.CualitativaSeleccion();
        dts.Tables[0].Rows.Add("-1", "Seleccione>>");
        CmbCalificacionCualitativa.DataSource = dts.Tables[0].DefaultView;
        CmbCalificacionCualitativa.SelectedValue = "-1";
        CmbCalificacionCualitativa.DataTextField = "NomCualitativa";
        CmbCalificacionCualitativa.DataValueField = "IdEncCualitativa";
        CmbCalificacionCualitativa.DataBind();
        dts.Clear();


    }

    private void LLenarDatosGrillaSectores()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = sv.ComSectores(0, 1, Convert.ToInt32(Session["IdPais"].ToString()));
        grvSectores.DataSource = ds.Tables[0].DefaultView;
        grvSectores.DataBind();
        Dscompleto = ds;




    }

    protected void ImageButton20_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarText();
    }

    protected void ImageButton19_Click(object sender, ImageClickEventArgs e)
    {
        Datos sv = new Datos();
        TextBox txt = new TextBox();
        int Modelo = int.Parse(CmbModelo.SelectedValue) != -1 ? int.Parse(CmbModelo.SelectedValue) : 1;
        int Cualitativa = int.Parse(CmbCalificacionCualitativa.SelectedValue) != -1 ? int.Parse(CmbCalificacionCualitativa.SelectedValue) : 1;




        string Factor = txtFactor.Text.Trim();
        Factor = Factor.Replace(".", ",").ToString();
        //if (CmbCalificacionCualitativa.SelectedValue != "-1")
        //{
            if (HidSectores.Value == "0")
            {

                sv.InSectoresTodos(1, int.Parse(txtCodSector.Text), txtSector.Text, chkManofacturero.Checked, int.Parse(txtCiiuDefault.Text), int.Parse(cmbCuenta.SelectedValue), Decimal.Parse(txtValotPyme.Text), Decimal.Parse(txtValorEmp.Text), Decimal.Parse(txtValorCoorp.Text), Modelo, DateTime.Now, Decimal.Parse(Factor.ToString()), Cualitativa, Convert.ToInt32(Session["IdPais"].ToString()));

                String DescripcionAudit = "Insercion datos Sectores: " + Convert.ToString(this.txtCodSector.Text) + ". Sector:" + Convert.ToString(this.txtSector.Text) + ". Cuenta: " + cmbCuenta.SelectedItem.Text + ". CIIU default" + txtCiiuDefault.Text + ". Cuenta" + cmbCuenta.SelectedItem.Text + ". Formulario Cualitativo" + CmbCalificacionCualitativa.SelectedItem.Text;
                sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblSectores.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);


                Response.Write("<script>alert('Sector Creado')</script>");
            }
            else
            {
                sv.InSectoresTodos(2, int.Parse(HidSectores.Value), txtSector.Text, chkManofacturero.Checked, int.Parse(txtCiiuDefault.Text), int.Parse(cmbCuenta.SelectedValue), Decimal.Parse(txtValotPyme.Text), Decimal.Parse(txtValorEmp.Text), Decimal.Parse(txtValorCoorp.Text), Modelo, DateTime.Now, Decimal.Parse(Factor.ToString()), Cualitativa, Convert.ToInt32(Session["IdPais"].ToString()));
                HidSectores.Value = "0";

                String DescripcionAudit = "Actualizacion datos Sectores: " + Convert.ToString(this.txtCodSector.Text) + ". Sector:" + Convert.ToString(this.txtSector.Text) + ". Cuenta: " + cmbCuenta.SelectedItem.Text + ". CIIU default" + txtCiiuDefault.Text + ". Cuenta" + cmbCuenta.SelectedItem.Text + ". Formulario Cualitativo" + CmbCalificacionCualitativa.SelectedItem.Text;
                sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblSectores.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

                Response.Write("<script>alert('Sector Actualizado')</script>");
            }
            LLenarDatosGrillaSectores();



            LimpiarText();
        //}
        //else
        //{
        //    Response.Write("<script>alert('No ha seleccionado ningun formulario Cualitativo')</script>");
        //}


    }

    private void LimpiarText()
    {

        txtCodSector.Enabled = true;
        txtCodSector.Text = "";
        txtSector.Enabled = true;
        txtSector.Text = "";
        chkManofacturero.Checked = false;
        cmbCuenta.SelectedValue = "-1";
        txtCiiuDefault.Text = "";
        txtValotPyme.Text = "";
        txtValorEmp.Text = "";
        txtValorCoorp.Text = "";
        CmbModelo.SelectedValue = "-1";
        txtFactor.Text = "";
        CmbCalificacionCualitativa.SelectedValue = "-1";
        HidSectores.Value = "0";
    }

    protected void grvSectores_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index;
        Boolean estadoCualitativa = false;
        // Boolean Calcular= false, Manufac = false;
        Datos sv = new Datos();

        switch (e.CommandName)
        {
            case "Editar":
                index = Convert.ToInt32(e.CommandArgument);
                DataSet ds = new DataSet();
                Decimal ValorPyme, ValorEmp, ValorCoorp;
                string Factor;
                ds = sv.ComSectores(index, 2, Convert.ToInt32(Session["IdPais"].ToString()));
                txtCodSector.Enabled = false;
                //txtSector.Enabled = false;
                this.txtCodSector.Text = Convert.ToString(ds.Tables[0].Rows[0]["IdSector"]);
                this.txtSector.Text = Convert.ToString(ds.Tables[0].Rows[0]["Sector"]);
                this.chkManofacturero.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["ManoFacturero"]);
                this.txtCiiuDefault.Text = Convert.ToString(ds.Tables[0].Rows[0]["CIIUDefault"]);
                this.cmbCuenta.SelectedValue = ds.Tables[0].Rows[0]["IdCuenta"].ToString() != "" ? ds.Tables[0].Rows[0]["IdCuenta"].ToString() : "-1";
                if (Convert.ToString(ds.Tables[0].Rows[0]["Estado"]) != "")
                {
                    estadoCualitativa = Convert.ToBoolean(ds.Tables[0].Rows[0]["Estado"]);
                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["IdCCualitativa"]) != "")
                {
                    if (estadoCualitativa == false)
                    {
                        CmbCalificacionCualitativa.SelectedValue = "-1";
                    }
                    else
                    {
                        CmbCalificacionCualitativa.SelectedValue = ds.Tables[0].Rows[0]["IdCCualitativa"].ToString();
                    }
                }
                else
                {
                    CmbCalificacionCualitativa.SelectedValue = "-1";
                }
                ValorPyme = Convert.ToDecimal(ds.Tables[0].Rows[0]["ValorPyme"].ToString() != "" ? ds.Tables[0].Rows[0]["ValorPyme"].ToString() : "0");
                txtValotPyme.Text = ValorPyme.ToString("N0");
                ValorEmp = Convert.ToDecimal(ds.Tables[0].Rows[0]["ValorEmpresarial"].ToString() != "" ? ds.Tables[0].Rows[0]["ValorEmpresarial"].ToString() : "0");
                txtValorEmp.Text = ValorEmp.ToString("N0");
                ValorCoorp = Convert.ToDecimal(ds.Tables[0].Rows[0]["ValorCoorporativo"].ToString() != "" ? ds.Tables[0].Rows[0]["ValorCoorporativo"].ToString() : "0");
                txtValorCoorp.Text = ValorCoorp.ToString("N0");
                //try
                //{
                //  this.CmbModelo.SelectedValue = ds.Tables[0].Rows[0]["IdModelo"].ToString() != "" ? ds.Tables[0].Rows[0]["IdModelo"].ToString() : "-1";

                //}
                // catch 
                //  {
                CmbModelo.SelectedValue = "-1";
                // }
                Factor = ds.Tables[0].Rows[0]["Factor"].ToString().Replace(",", ".");
                this.txtFactor.Text = Convert.ToString(Factor);
                ds.Clear();
                this.HidSectores.Value = index.ToString();
                break;
            default:
                break;
        }


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DataView vista = null;
        string filtro = null;


        if (this.txtBuscar.Text.Trim() != "")
        {

            filtro = "Sector like '%" + txtBuscar.Text + "%'";
            vista = new DataView(Dscompleto.Tables[0]);
            vista.RowFilter = filtro;


            DataSet dsFiltered = new DataSet(); //create a new dataset
            dsFiltered.Tables.Add(DataViewAsDataTable(vista)); //fill the dataset with the sorted results

            grvSectores.DataSource = dsFiltered.Tables[0];
            grvSectores.DataBind();



        }

    }

    public static DataTable DataViewAsDataTable(DataView dv)
    {
        DataTable dt = dv.Table.Clone();
        foreach (DataRowView drv in dv)
            dt.ImportRow(drv.Row);
        return dt;
    }

    protected void grvSectores_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataTable dataTable = grvSectores.DataSource as DataTable;
        DataView dataView = new DataView(dataTable);
        grvSectores.DataSource = SortDataTable(Dscompleto.Tables[0].DefaultView, true);
        // Calculate the current page number. 
        grvSectores.PageIndex = e.NewPageIndex;
        // Reset selected index 
        grvSectores.SelectedIndex = -1;
        grvSectores.DataBind();

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

    public string GridViewSortDirection
    {

        get
        {
            object o = ViewState["SortDirection"];
            return ((o == null) ? "ASC" : Convert.ToString(o));
        }
        set { ViewState["SortDirection"] = value; }
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

    public string GridViewSortExpression
    {
        get
        {
            object o = ViewState["SortExpression"];
            return ((o == null) ? string.Empty : Convert.ToString(o));
        }
        set { ViewState["SortExpression"] = value; }
    }

    protected void grvSectores_Sorting(object sender, GridViewSortEventArgs e)
    {
        GridViewSortExpression = e.SortExpression;
        int pageIndex = grvSectores.PageIndex;
        grvSectores.DataSource = SortDataTable(Dscompleto.Tables[0].DefaultView, false);
        grvSectores.DataBind();
        grvSectores.PageIndex = pageIndex;
    }
}
