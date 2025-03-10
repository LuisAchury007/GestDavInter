using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Conf_DatosEmpresa : System.Web.UI.Page
{
    DataSet Dscompleto;
    public string segmentState = "collapse";
    public string lvlRiskState = "collapse";
    public string macroState = "collapse";
    public string lvlRiskState2 = "collapse";
    public string lvlRiskState22 = "collapse";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IDusuario"] == null)
        {
            Response.Redirect("Salir.aspx");
        }

        if (Page.IsPostBack == false)
        {
            HCodPaisesID.Value = "0";
            HDTipoIdentificacionID.Value = "0";
            HidTipoBancaID.Value = "0";
            LLenarDatosGrillaPaises();
            LLenarDatosTipoIdentificacion();
            LLenarDatosBanca();
            LLenarDatosSectorGE();
            LLenarDatosParametrosGE();
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

    private void LLenarDatosGrillaPaises()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = sv.SePais(4, "");
        this.grvPaises.DataSource = ds.Tables[0].DefaultView;
        this.grvPaises.DataBind();
        Dscompleto = ds;

    }

    private void LLenarDatosBanca()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = sv.tiposSegmentos();
        this.GriBanca.DataSource = ds.Tables[0].DefaultView;
        this.GriBanca.DataBind();

    }

    private void LLenarDatosTipoIdentificacion()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = sv.SeTipoIdentificacion(1, 0);
        this.grvTipoIdentificacion.DataSource = ds.Tables[0].DefaultView;
        this.grvTipoIdentificacion.DataBind();

    }

    private void LLenarDatosSectorGE()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = sv.CredSectorLimiteGE(1, 2);
        this.GrvSectoresGE.DataSource = ds.Tables[0].DefaultView;
        this.GrvSectoresGE.DataBind();

    }

    private void LLenarDatosParametrosGE()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = sv.CredParametrosGE(1, 2);
        this.GrvParametrosGE.DataSource = ds.Tables[0].DefaultView;
        this.GrvParametrosGE.DataBind();

    }

    protected void grvPaises_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Datos sv = new Datos();

            DataSet ds = new DataSet();
            CheckBox chkFilial = (e.Row.FindControl("chkFilial") as CheckBox);

            string CodPais = grvPaises.DataKeys[e.Row.RowIndex]["CodPais"].ToString();
            ds = sv.SePais(2, CodPais);
            chkFilial.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Filial"]);

        }
    }

    protected void GrvSectoresGE_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Datos sv = new Datos();

            DataSet ds = new DataSet();
            CheckBox chkEstado = (e.Row.FindControl("chkEstado") as CheckBox);

            int Sector = Convert.ToInt32(GrvSectoresGE.DataKeys[e.Row.RowIndex]["IdSectorGE"]);
            ds = sv.CredSectorLimiteGE(Sector,3 );
            chkEstado.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Estado"]);

        }
    }

    protected void GrvParametrosGE_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Datos sv = new Datos();

            DataSet ds = new DataSet();
            CheckBox chkEstado = (e.Row.FindControl("chkEstado") as CheckBox);

            int Parametro = Convert.ToInt32(GrvParametrosGE.DataKeys[e.Row.RowIndex]["IdParametroGE"]);
            ds = sv.CredParametrosGE(Parametro, 3);
            chkEstado.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Estado"]);

        }
    }

    protected void grvPaises_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataTable dataTable = grvPaises.DataSource as DataTable;
        DataView dataView = new DataView(dataTable);
        grvPaises.DataSource = SortDataTable(Dscompleto.Tables[0].DefaultView, true);
        // Calculate the current page number. 
        grvPaises.PageIndex = e.NewPageIndex;
        // Reset selected index 
        grvPaises.SelectedIndex = -1;
        grvPaises.DataBind();

        // Identificar en qué página estás
        int currentPageIndex = e.NewPageIndex + 1; // Sumar 1 porque los índices comienzan en 0
        Label1.Text = "Página actual: " + currentPageIndex.ToString();
        macroState = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
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

    public string GridViewSortDirection
    {
        get
        {
            object o = ViewState["SortDirection"];
            return ((o == null) ? "ASC" : Convert.ToString(o));
        }
        set { ViewState["SortDirection"] = value; }
    }

    protected void grvPaises_Sorting(object sender, GridViewSortEventArgs e)
    {
        GridViewSortExpression = e.SortExpression;
        int pageIndex = grvPaises.PageIndex;
        grvPaises.DataSource = SortDataTable(Dscompleto.Tables[0].DefaultView, false);
        grvPaises.DataBind();
        grvPaises.PageIndex = pageIndex;
    }

    protected void btnBuscarGEconomico_Click(object sender, EventArgs e)
    {
        buscarPais();
        macroState = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
    }

    private void buscarPais()
    {
        Datos sv = new Datos();

        DataSet ds = new DataSet();
        string GrupóEmp = txtBuscarGrupo.Text;

        if (GrupóEmp == "")
        {
            LLenarDatosGrillaPaises();
        }
        else
        {
            ds = sv.SePais(3, GrupóEmp);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grvPaises.DataSource = ds.Tables[0].DefaultView;
                grvPaises.DataBind();
                Dscompleto = ds;
            }
            else
            {
                Response.Write("<script>alert('No se encontro Pais')</script>");
            }
        }

    }

    protected void grvPaises_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string index;
        Datos sv = new Datos();

        switch (e.CommandName)
        {
            case "Editar":
                index = Convert.ToString(e.CommandArgument);
                DataSet ds = new DataSet();
                ds = sv.SePais(2, index);
                this.txtCodPais.Text = Convert.ToString(ds.Tables[0].Rows[0]["CodPais"]);
                txtCodPais.Enabled = false;
                HidCodPais.Value = Convert.ToString(ds.Tables[0].Rows[0]["CodPais"]);
                this.txtPais.Text = Convert.ToString(ds.Tables[0].Rows[0]["Pais"]);
                HidPais.Value = Convert.ToString(ds.Tables[0].Rows[0]["Pais"]);
                this.chkFilial.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Filial"]);
                HidFilial.Value = Convert.ToString(ds.Tables[0].Rows[0]["Filial"]);
                ds.Clear();
                this.HCodPaisesID.Value = index.ToString();
                macroState = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
                break;
            default:
                break;
        }

    }

    protected void GrvSectoresGE_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index;
        Datos sv = new Datos();
        DataSet ds = new DataSet();
        switch (e.CommandName)
        {
            case "Editar":
                index = Convert.ToInt32(e.CommandArgument);
                ds = sv.CredSectorLimiteGE(index, 3);
                this.txtSectorGE.Text = Convert.ToString(ds.Tables[0].Rows[0]["SectorGE"]);
                HidSectorGENom.Value = Convert.ToString(ds.Tables[0].Rows[0]["SectorGE"]);
                this.chkEstadoSector.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Estado"]);
                if (chkEstadoSector.Checked == true)
                { HidchkEstadoSector.Value = "Activo"; }
                else
                { HidchkEstadoSector.Value = "Inactivo"; }

                this.HidSectorGE.Value = index.ToString();
                lvlRiskState2 = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
                ds.Clear();
                break;
            default:
                break;
        }

    }

    protected void GrvParametrosGE_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index;
        Datos sv = new Datos();
        DataSet ds = new DataSet();
        switch (e.CommandName)
        {
            case "Editar":
                index = Convert.ToInt32(e.CommandArgument);
                ds = sv.CredParametrosGE(index, 3);
                txtParametroGE.Text = Convert.ToString(ds.Tables[0].Rows[0]["ParametrosGE"]);
                HidNomParametroGC.Value = Convert.ToString(ds.Tables[0].Rows[0]["ParametrosGE"]);
                ChkParamGE.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Estado"]);
                if (ChkParamGE.Checked == true)
                { HidEstadoParamGE.Value = "Activo"; }
                else
                { HidEstadoParamGE.Value = "Inactivo"; }

                HiParametroGE.Value = index.ToString();
                lvlRiskState22 = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
                ds.Clear();
                break;
            default:
                break;
        }

    }

    protected void grvTipoIdentificacion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index;
        Datos sv = new Datos();

        switch (e.CommandName)
        {
            case "Editar":
                index = Convert.ToInt32(e.CommandArgument);
                DataSet ds = new DataSet();
                ds = sv.SeTipoIdentificacion(2, index);
                this.txtIdentificacion.Text = Convert.ToString(ds.Tables[0].Rows[0]["Identificacion"]);
                this.txtCodIdentificacion.Text = Convert.ToString(ds.Tables[0].Rows[0]["CodDavivienda"]);
                HidIdentificacion.Value = Convert.ToString(ds.Tables[0].Rows[0]["Identificacion"]);
                txtCodIdentificacion.Enabled = false;
                ds.Clear();
                this.HDTipoIdentificacionID.Value = index.ToString();
                segmentState = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
                break;
            default:
                break;
        }

    }

    protected void GriBanca_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Datos sv = new Datos();
        int index;

        switch (e.CommandName)
        {
            case "Editar":
                index = Convert.ToInt32(e.CommandArgument);
                DataSet ds = new DataSet();
                ds = sv.SeTipoIdentificacion(3, index);
                this.txtBanca.Text = Convert.ToString(ds.Tables[0].Rows[0]["Segmento"]);
                HidBanca.Value = Convert.ToString(ds.Tables[0].Rows[0]["Segmento"]);
                HiValorBanca.Value = Convert.ToString(ds.Tables[0].Rows[0]["SumarCFinal"]);
                ds.Clear();
                this.HidTipoBancaID.Value = index.ToString();
                lvlRiskState = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
                break;
            default:
                break;
        }

    }

    private void LimpiarPaises()
    {
        this.txtCodPais.Text = "";
        txtCodPais.Enabled = true;
        this.txtPais.Text = "";
        this.chkFilial.Checked = false;
        this.HCodPaisesID.Value = "0";
    }

    private void LimpiarTipoIdnetifiacion()
    {
        this.txtIdentificacion.Text = "";
        this.HDTipoIdentificacionID.Value = "0";
        this.txtCodIdentificacion.Text = "";
        txtCodIdentificacion.Enabled = true;
    }

    private void LimpiarBanca()
    {
        this.txtBanca.Text = "";
        this.HidTipoBancaID.Value = "0";
        this.HiValorBanca.Value = "0";
    }

    private void LimpiarSectoresGE()
    {
        this.txtSectorGE.Text = "";
        this.chkEstadoSector.Checked = false;
        this.HidSectorGE.Value = "0";
    }

    private void LimpiarParametrosGE()
    {
        this.txtParametroGE.Text = "";
        this.ChkParamGE.Checked = false;
        this.HiParametroGE.Value = "0";
    }

    protected void ImgLimpiarPais_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarPaises();
        macroState = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
    }

    protected void ImgLimpiarPeriodo_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarTipoIdnetifiacion();
        segmentState = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarBanca();
        lvlRiskState = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
    }

    protected void imgLimpiaSectorGE_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarSectoresGE();
        lvlRiskState2 = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
    }

    protected void ImgVolverParamGE_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarParametrosGE();
        lvlRiskState22 = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
    }

    protected void ImgGuardarPais_Click(object sender, ImageClickEventArgs e)
    {
        Datos sv = new Datos();

        if (HCodPaisesID.Value == "0")
        {
            int Valor = sv.InPaises(this.txtCodPais.Text.Trim(), this.txtPais.Text, true, 1);
            if (Valor != 0)
            {
                Response.Write("<script>alert('Ya existe un pasi con ese codigo registrado en el sistema')</script>");
            }
            else
            {
                String DescripcionAudit = "Inserción Nuevo Pais: " + Convert.ToString(this.txtCodPais.Text) + ". Nombre pais:" + Convert.ToString(this.txtPais.Text) + ".Filial:" + chkFilial.Checked;
                sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCPI.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

                 Response.Write("<script>alert('Datos Guardados Correctamente')</script>");
            }
        }
        else
        {
            int Valor = sv.InPaises(this.txtCodPais.Text.Trim(), this.txtPais.Text, chkFilial.Checked, 2);

            String DescripcionAudit = "Actualización de pais:" + Convert.ToString(this.txtCodPais.Text) + ". Pais anterior: " + this.HidPais.Value + ". Nuevo pais: " + Convert.ToString(this.txtPais.Text) + ". Estado filial anterior: " + HidFilial.Value + ". Estado filial actual:" +
                    chkFilial.Checked;
            sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCPI.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);
                    
            Response.Write("<script>alert('Datos actualizados correctamente')</script>");

        }
        LimpiarPaises();
        LLenarDatosGrillaPaises();

        macroState = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */

    }

    protected void ImgGuardarTipoIdentificacion_Click(object sender, ImageClickEventArgs e)
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        if (HDTipoIdentificacionID.Value == "0")
        {
            ds = sv.SeTipoIdentificacion(2, int.Parse(txtCodIdentificacion.Text));
            if (ds.Tables[0].Rows.Count > 0)
            {
                Response.Write("<script>alert('Este Número de identificación ya existe en el sistema')</script>");
                return;
            }


            sv.InTipoIdentificacion(this.txtIdentificacion.Text, 1, 1, int.Parse(txtCodIdentificacion.Text));
            String DescripcionAudit = "Inserción Nuevo Tipo de identificación: " + Convert.ToString(this.txtIdentificacion.Text);
            sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCPI.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

             Response.Write("<script>alert('Datos Guardados Correctamente')</script>");
        }
        else
        {
            sv.InTipoIdentificacion(this.txtIdentificacion.Text, 2, int.Parse(HDTipoIdentificacionID.Value), int.Parse(txtCodIdentificacion.Text));

            String DescripcionAudit = "Actualización de Tipo de identificacion:" + Convert.ToString(this.txtIdentificacion.Text) + ". Identificacion anterior: " + this.HidIdentificacion.Value;
            sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCPI.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

           Response.Write("<script>alert('Datos actualizados correctamente')</script>");
        }
        LimpiarTipoIdnetifiacion();
        LLenarDatosTipoIdentificacion();
        segmentState = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */

    }

    protected void imgGuardaBanca_Click(object sender, ImageClickEventArgs e)
    {
        Datos sv = new Datos();

        if (HidTipoBancaID.Value == "0")
        {
            sv.InTipoIdentificacion(this.txtBanca.Text, 3, 1, 1);
            String DescripcionAudit = "Inserción Nueva Banca: " + Convert.ToString(this.txtBanca.Text);
            sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCPI.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

            Response.Write("<script>alert('Datos Guardados Correctamente')</script>");
        }
        else
        {
            sv.Up_DatosSegmento(int.Parse(HidTipoBancaID.Value), txtBanca.Text, 0, 0);

            String DescripcionAudit = "Actualización de Banca:" + Convert.ToString(this.txtBanca.Text) + ". Banca Anterior: " + this.HidBanca.Value;
            sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCPI.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

            Response.Write("<script>alert('Datos actualizados correctamente')</script>");

        }
        LLenarDatosBanca();
        LimpiarBanca();
        lvlRiskState = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */

    }

    protected void imgGuardaSectorGE_Click(object sender, ImageClickEventArgs e)
    {
        Datos sv = new Datos();

        if (HidSectorGE.Value == "0")
        {
             sv.InSectorLimiteGE(1,this.txtSectorGE.Text.Trim(), chkEstadoSector.Checked,1);

            String DescripcionAudit = "Inserción Nuevo Sector GE: " + Convert.ToString(this.txtSectorGE.Text) + ".Estado" + chkEstadoSector.Checked;
            sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCPI.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

            Response.Write("<script>alert('Datos Guardados Correctamente')</script>");
        }
        else
        {
            sv.InSectorLimiteGE(int.Parse(HidSectorGE.Value), txtSectorGE.Text.Trim(), chkEstadoSector.Checked, 2);

            String DescripcionAudit = "Actualizaciòn Sector GE:" + Convert.ToString(this.txtSectorGE.Text) + ". Sector GE anterior: " + this.HidSectorGENom.Value +  ". Estado  anterior: " + HidchkEstadoSector.Value + ". Estado  actual:" +
                    chkEstadoSector.Checked;
            sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCPI.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

            Response.Write("<script>alert('Datos actualizados correctamente')</script>");

        }

        LimpiarSectoresGE();
        LLenarDatosSectorGE();
        lvlRiskState2 = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */

    }

    protected void ImgGuardaParamGE_Click(object sender, ImageClickEventArgs e)
    {
        Datos sv = new Datos();

        if (HiParametroGE.Value == "0")
        {
            sv.InParametrosGE(1, this.txtParametroGE.Text.Trim(), ChkParamGE.Checked, 1);

            String DescripcionAudit = "Inserción razones por la cual componen o no grupo Econòmico: " + Convert.ToString(this.txtParametroGE.Text) + ".Estado" + ChkParamGE.Checked;
            sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCPI.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

            Response.Write("<script>alert('Datos Guardados Correctamente')</script>");
        }
        else
        {
            sv.InParametrosGE(int.Parse(HiParametroGE.Value), txtParametroGE.Text.Trim(), ChkParamGE.Checked, 2);

            String DescripcionAudit = "Actualizaciòn razones por la cual componen o no grupo Econòmico:" + Convert.ToString(this.txtParametroGE.Text) + ". Sector GE anterior: " + this.HidNomParametroGC.Value + ". Estado  anterior: " + HidEstadoParamGE.Value + ". Estado  actual:" +
                    ChkParamGE.Checked;
            sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCPI.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

            Response.Write("<script>alert('Datos actualizados correctamente')</script>");

        }

        LimpiarParametrosGE();
        LLenarDatosParametrosGE();
        lvlRiskState22 = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */

    }


}