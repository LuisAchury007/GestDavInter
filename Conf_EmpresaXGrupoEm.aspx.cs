using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Encoder = Microsoft.Security.Application.Encoder;

public partial class Conf_EmpresaXGrupoEm : System.Web.UI.Page
{
    DataSet Dscompleto;
    DataSet Dscompleto3;
    DataView vista = new DataView();
    string[] listaEmpresas = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IDusuario"] == null)
        {
            Response.Redirect("Salir.aspx");
        }

        if (Convert.ToBoolean(Session["CrearEmpresaGE"]) == false)
        {
            LinkBtnContacto.Visible = false;
        }

        if (Page.IsPostBack == false)
        {
            llenargrupoXEmpresas(int.Parse(Encoder.HtmlEncode(Request.QueryString["IdGrupoEm"])));
            llenarInfo();
        }
        else
        {
            llenarlista();
            if (GridEmpresas.Rows.Count > 0)
            {
                Dscompleto = (DataSet)ViewState["DscompletoState"];
                GridEmpresas.DataSource = Dscompleto.Tables[0];
                GridEmpresas.DataBind();
            }

            if (grvEmpXGrupoEmp.Rows.Count > 0)
            {
                foreach (GridViewRow row in grvEmpXGrupoEmp.Rows)
                {
                    GridView grvEmpresas = (GridView)row.FindControl("grvEmpresas");
                    Dscompleto3 = (DataSet)ViewState["DscompletoState3"];
                    grvEmpresas.DataSource = Dscompleto3.Tables[0];
                    grvEmpresas.DataBind();
                }
            }
        }
    }

    protected void llenarInfo()
    {
        DataSet dts = new DataSet();
        Datos sv = new Datos();

        dts = sv.SeTipoIdentificacion(1, 0);
        this.CmbTipoIdentificacion.DataSource = dts.Tables[0].DefaultView;
        this.CmbTipoIdentificacion.DataTextField = "Identificacion";
        this.CmbTipoIdentificacion.DataValueField = "IdTipIdentificacion";
        this.CmbTipoIdentificacion.DataBind();
        dts.Clear();

        dts = sv.SeTipoEmpresa();
        this.cmbTipoSociedad.DataSource = dts.Tables[0].DefaultView;
        this.cmbTipoSociedad.DataTextField = "TipoEmpresa";
        this.cmbTipoSociedad.DataValueField = "IdTipoEmpresa";
        this.cmbTipoSociedad.DataBind();
        dts.Clear();

        dts = sv.SePais(4, "");
        this.CmbPaisFilial.DataSource = dts.Tables[0].DefaultView;
        this.CmbPaisFilial.DataTextField = "Pais";
        this.CmbPaisFilial.DataValueField = "CodPais";
        this.CmbPaisFilial.DataBind();
        dts.Clear();


        dts = sv.tiposSegmentos();
        this.cmbBanca.DataSource = dts.Tables[0].DefaultView;
        this.cmbBanca.DataTextField = "Segmento";
        this.cmbBanca.DataValueField = "IdSegmento";
        this.cmbBanca.DataBind();
        dts.Clear();

        dts = sv.CredParametrosGE(1, 1);
        dts.Tables[0].Rows.Add("-1", " Seleccione--");
        vista = dts.Tables[0].DefaultView;
        vista.Sort = "IdParametroGE ASC";

        this.CmbRazonesComponen.DataSource = vista;
        this.CmbRazonesComponen.DataTextField = "ParametrosGE";
        this.CmbRazonesComponen.DataValueField = "IdParametroGE";
        this.CmbRazonesComponen.DataBind();
        dts.Clear();

        dts = sv.ComSectores(0, 1, Convert.ToInt32(Session["IdPais"].ToString()));
        dts.Tables[0].Rows.Add("-1", "Seleccione>>");
        vista = dts.Tables[0].DefaultView;
        vista.Sort = "IdSector ASC";

        this.CmbSector.DataSource = vista;
        this.CmbSector.DataTextField = "Sector";
        this.CmbSector.DataValueField = "IdSector";
        this.CmbSector.DataBind();

    }

    public void llenarlista()
    {
        int i = 0;
        int contador = 1;

        for (i = 0; i < this.GridEmpresas.Rows.Count; i++)
        {

            if (((CheckBox)this.GridEmpresas.Rows[i].Cells[0].Controls[1]).Checked)
            {
                Array.Resize(ref listaEmpresas, contador);
                listaEmpresas[contador - 1] = GridEmpresas.DataKeys[i].Value.ToString();
                contador += 1;
            }
        }

    }

    protected void Page_PreRender(object sender, System.EventArgs e)
    {
        this.ViewState.Add("DscompletoState", Dscompleto);
        this.ViewState.Add("DscompletoState3", Dscompleto3);
    }

    protected void GridEmpresas_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = GridEmpresas.DataSource as DataTable;
        DataView dataView = new DataView(dataTable);

        GridViewSortExpression = e.SortExpression;
        int pageIndex = GridEmpresas.PageIndex;
        GridEmpresas.DataSource = SortDataTable(dataView, false);
        GridEmpresas.DataBind();
        GridEmpresas.PageIndex = pageIndex;
    }

    protected void grvEmpresas_Sorting(object sender, GridViewSortEventArgs e)
    {
        foreach (GridViewRow row in grvEmpXGrupoEmp.Rows)
        {
            GridView grvEmpresas = (GridView)row.FindControl("grvEmpresas");
            DataTable dataTable = grvEmpresas.DataSource as DataTable;
            DataView dataView = new DataView(dataTable);
            GridViewSortExpression = e.SortExpression;
            int pageIndex = grvEmpXGrupoEmp.PageIndex;
            grvEmpresas.DataSource = SortDataTable(dataView, false);
            grvEmpresas.DataBind();
            grvEmpresas.PageIndex = pageIndex;
        }
    }

    protected void GridEmpresas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataTable dataTable = GridEmpresas.DataSource as DataTable;
        DataSet ds = new DataSet();
        Datos sv = new Datos();
        string GrupoEm = "";
        int i = 0;
        DataView dataView = new DataView(dataTable);
        GridEmpresas.DataSource = SortDataTable(dataView, true);
        // Calculate the current page number. 
        GridEmpresas.PageIndex = e.NewPageIndex;
        // Reset selected index 
        GridEmpresas.SelectedIndex = -1;
        GridEmpresas.DataBind();
        string IdEmpresa;
        foreach (GridViewRow row in GridEmpresas.Rows)
        {

            IdEmpresa = GridEmpresas.DataKeys[row.RowIndex]["NIT"].ToString();// long.Parse(cmbCliente1.SelectedValue);
            ds = sv.BencEmpresaDatos(IdEmpresa, Convert.ToInt32(Session["IdPais"].ToString()));
            if (ds.Tables[0].Rows.Count > 0)
            {
                GrupoEm = ds.Tables[0].Rows[0]["GrupoEmpresarial"].ToString();
                GridEmpresas.Rows[i].ToolTip = "Esta empresa pertenece al grupo económico: " + GrupoEm;
            }

            i++;
        }

        // Identificar en qué página estás
        int currentPageIndex = e.NewPageIndex + 1; // Sumar 1 porque los índices comienzan en 0
        Label1.Text = "Página actual: " + currentPageIndex.ToString();
    }

    protected void grvEmpresas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        foreach (GridViewRow row in grvEmpXGrupoEmp.Rows)
        {
            GridView grvEmpresas = (GridView)row.FindControl("grvEmpresas");
            Label Label11 = (Label)row.FindControl("Label11");
            DataTable dataTable = grvEmpresas.DataSource as DataTable;
            DataView dataView = new DataView(dataTable);
            grvEmpresas.DataSource = SortDataTable(dataView, true);
            // Calculate the current page number. 
            grvEmpresas.PageIndex = e.NewPageIndex;
            // Reset selected index 
            grvEmpresas.SelectedIndex = -1;
            grvEmpresas.DataBind();

            // Identificar en qué página estás
            int currentPageIndex = e.NewPageIndex + 1; // Sumar 1 porque los índices comienzan en 0
            Label11.Text = "Página actual: " + currentPageIndex.ToString();
        }
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

    protected void btnBuscarEmp_Click(object sender, EventArgs e)
    {
        buscarGestor();
        GridEmpresas.Visible = true;
        txtAntecedentes.Text = "";
        txtAntecedentes.Visible = false;
        LblComentarioEliminacion.Visible = false;
    }

    private void buscarGestor()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();
        int i = 0;
        string IdEmpresa;
        string GrupoEm;

        string empresa = txtBuscarEmpresa.Text;

        if (empresa == "")
        {
            Response.Write("<script>alert('Debe Ingresar el No. Documento o nombre de la empresa')</script>");
        }
        else
        {
            ds = sv.BencBuscarEmpresa(empresa, 2, Convert.ToInt32(Session["IdPais"].ToString()));

            if (ds.Tables[0].Rows.Count > 0)
            {
                GridEmpresas.DataSource = ds.Tables[0].DefaultView;
                GridEmpresas.DataBind();
                GridEmpresas.Columns[0].Visible = true;
                Dscompleto = ds;

                foreach (GridViewRow row in GridEmpresas.Rows)
                {

                    IdEmpresa =GridEmpresas.DataKeys[row.RowIndex]["NIT"].ToString();// long.Parse(cmbCliente1.SelectedValue);
                    ds = sv.BencEmpresaDatos(IdEmpresa, Convert.ToInt32(Session["IdPais"].ToString()));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GrupoEm = ds.Tables[0].Rows[0]["GrupoEmpresarial"].ToString();
                        GridEmpresas.Rows[i].ToolTip = "Esta empresa pertenece al grupo económico: " + GrupoEm;
                    }

                    i++;
                }
            }
            else
            {
                Response.Write("<script>alert('No se encontro la Empresa')</script>");
            }
        }

    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]

    public static List<string> SearchClients2(string prefixText, int count)
    {
        Datos sv = new Datos();
        DataSet dsDatos = new DataSet();
        DataView vista = new DataView();

        dsDatos = sv.SePais(5, prefixText.Trim());
        vista = dsDatos.Tables[0].DefaultView;
        vista.Sort = "Pais ASC";

        DataTable dt = new DataTable();
        dt = vista.ToTable();

        List<string> list = new List<string>();

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            //  list.Add("" + dt.Rows[i].ItemArray[1]);
            list.Add(dt.Rows[i].ItemArray[0] + " - " + dt.Rows[i].ItemArray[1]);
        }
        return list;
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

    protected void grvEmpXGrupoEmp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int IdGrupoEm = Convert.ToInt32(grvEmpXGrupoEmp.DataKeys[e.Row.RowIndex]["IdGrupoEm"].ToString());
            GridView grvEmpresas = (GridView)e.Row.FindControl("grvEmpresas");
            ds = sv.SeGrupoEmpxEmpresas(IdGrupoEm, 2, Convert.ToInt32(Session["IdPais"].ToString()));
            grvEmpresas.DataSource = ds.Tables[0].DefaultView;
            grvEmpresas.DataBind();
            Dscompleto3 = ds;
            //ds.Clear();
        }

    }

    protected void Limpiar()
    {
        txtBuscarEmpresa.Text = "";
        GridEmpresas.Visible = false;
        txtAntecedentes.Text = "";
        txtAntecedentes.Visible = false;
        LblComentarioEliminacion.Visible = false;
        ImgGuardarPeriodo.Enabled = true;
        CmbRazonesComponen.SelectedValue = "-1";
    }

    protected void ImgGuardarPeriodo_Click(object sender, ImageClickEventArgs e)
    {
        Datos sv = new Datos();
        DataSet dts = new DataSet();
        DataSet ds = new DataSet();
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            if ((listaEmpresas != null))
            {
                if (CmbRazonesComponen.SelectedValue != "-1")
                {
                    int CantCodigo = listaEmpresas.Length;
                    for (int z = 0; z < CantCodigo; z++)
                    {
                        string dato = listaEmpresas[z];

                        CambiaEmpGrupo(dato);
                    }

                    llenargrupoXEmpresas(int.Parse(Encoder.HtmlEncode(Request.QueryString["IdGrupoEm"])));
                    Limpiar();
                    Response.Write("<script>alert('Datos asociados Correctamente')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Debe seleccionar una razón por la cual compone Grupo')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Debe seleccionar un grupo económico')</script>");
            }
        }

    }

    protected void actualizaEmpresa(string NIt)
    {
        Datos sv = new Datos();

        sv.UpDatosEmpresa(1, NIt, CmbPaisFilial.SelectedValue, 1, Convert.ToInt32(Session["IdPais"].ToString()));
        sv.UpDatosEmpresa(3, NIt, "", int.Parse(cmbBanca.SelectedValue), Convert.ToInt32(Session["IdPais"].ToString()));

    }

    protected void CambiaEmpGrupo(string dato)
    {
        DataSet ds = new DataSet();
        Datos sv = new Datos();
        string GrupoEmpresarial = "", GrupoEmpresarialAct = "";

        ds = sv.BencEmpresaDatos(dato, Convert.ToInt32(Session["IdPais"].ToString()));
        if (ds.Tables[0].Rows.Count > 0)
        {
            GrupoEmpresarial = ds.Tables[0].Rows[0]["GrupoEmpresarial"].ToString();
        }

        sv.InGrupoEmpresaria("", true, 3, int.Parse(Encoder.HtmlEncode(Request.QueryString["IdGrupoEm"])), dato, "", 0);

        ds = sv.SeGrupoEmpresarial(Convert.ToInt32(Encoder.HtmlEncode(Request.QueryString["IdGrupoEm"])), 2, "");
        if (ds.Tables[0].Rows.Count > 0)
        {
            GrupoEmpresarialAct = ds.Tables[0].Rows[0]["GrupoEmpresarial"].ToString();
        }



        String DescripcionAudit = "Asociaciòn de empresa a un grupo económico con No. Documento" + Convert.ToString(dato) + "; Grupo origen: " + GrupoEmpresarial +
        " ; Grupo destino: " + GrupoEmpresarialAct + "; Razón por la cual compone Grupo: " + CmbRazonesComponen.SelectedItem.Text +
         "; Comentarios adicionales que sustenten la novedad: " + txtComentarioSolicitud.Text;

        sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, "Configurar Grupos Económicos", Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);
    }

    protected void llenargrupoXEmpresas(int IdGrupoEmpresarial)
    {
        Datos sv = new Datos();

        DataSet dts = new DataSet();
        dts = sv.SeGrupoEmpxEmpresas(IdGrupoEmpresarial, 1, Convert.ToInt32(Session["IdPais"].ToString()));
        if (dts.Tables[0].Rows.Count > 0)
        {
            grvEmpXGrupoEmp.DataSource = dts.Tables[0].DefaultView;
            grvEmpXGrupoEmp.DataBind();
        }

    }

    protected void ImgLimpiarPeriodo_Click(object sender, ImageClickEventArgs e)
    {
        Limpiar();
    }

    protected void grvEmpresas_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();
        DataSet Data = new DataSet();
        Boolean DiligenciaRib = false;
        string NIT=""; 
        long Selecc = 0, IdRIB = 0;
        foreach (GridViewRow row in grvEmpXGrupoEmp.Rows)
        {
            GridView grvEmpresas = (GridView)row.FindControl("grvEmpresas");
            NIT = grvEmpresas.DataKeys[e.RowIndex].Value.ToString();
        }


        if (txtAntecedentes.Text == "")
        {
            txtAntecedentes.Visible = true;
            ImgGuardarPeriodo.Enabled = false;
            LblComentarioEliminacion.Visible = true;
            Response.Write("<script>alert('Debe adjuntar un mensaje especificando el motivo por el cual desasocia la empresa')</script>");
            return;
        }
        else
        {
            if (CmbRazonesComponen.SelectedValue != "-1")
            {
                EliminaEmpresa(NIT, Convert.ToInt32(Session["IdPais"].ToString()));
            }
            else
            {
                Response.Write("<script>alert('Debe seleccionar una razón por la cual componen o no grupo .')</script>");
            }
        }

    }

    protected void EliminaEmpresa(string NIT, int IdPais)
    {
        Datos sv = new Datos();

        sv.InGrupoEmpresaria("", true, 3, 0, NIT, "", 0);
        String DescripcionAudit = "Se desasocia la empresa con No. Documento" + Convert.ToString(NIT) + " ; Tipo novedad: " + Convert.ToString(this.txtAntecedentes.Text) + " ; Razón por la cual componen o no el grupo: " + CmbRazonesComponen.SelectedItem.Text +
        "; Comentarios adicionales que sustenten la novedad: " + txtComentarioSolicitud.Text;
        sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, "Configurar Grupos Económicos", Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

        llenargrupoXEmpresas(int.Parse(Encoder.HtmlEncode(Request.QueryString["IdGrupoEm"])));
        Response.Write("<script>alert('Empresa desasociada del grupo')</script>");
        txtAntecedentes.Visible = false;
        txtAntecedentes.Text = "";
        LblComentarioEliminacion.Visible = false;
        ImgGuardarPeriodo.Enabled = true;
    }

    protected void LinkBtnContacto_Click(object sender, EventArgs e)
    {
        pnlCrearEmp.Visible = true;
        txtBuscarEmpresa.Enabled = false;
        btnBuscarEmp.Enabled = false;
        ImgGuardarPeriodo.Visible = false;
        ImgLimpiarPeriodo.Visible = false;
        TxtNit.Text = "";
        TxtNitConDigito.Text = "";
        TxtNitDigitoNew.Text = "";
        txtrazonsocial.Text = "";

        txtAntecedentes.Text = "";
        txtAntecedentes.Visible = false;
        LblComentarioEliminacion.Visible = false;
    }

    protected void LimpiaEmpNueva_Click(object sender, ImageClickEventArgs e)
    {
        limpiaEmpresa();
    }

    protected void BtnGuardarEmpNueva_Click(object sender, ImageClickEventArgs e)
    {
        Datos sv = new Datos();
        DataSet dsDatos = new DataSet();
        DataSet ds = new DataSet();
        string Fecha = Convert.ToString(DateTime.Now), GrupoEmpresarialAct = "";
        int Existe = 0;
        dsDatos = sv.GcredEmpresaDatosPorRazonSocialLista(TxtNit.Text, "", Convert.ToInt32(Session["IdPais"].ToString()));
        if (dsDatos.Tables[0].Rows.Count > 0)
        {
            Existe = 1;
        }

        if (Existe != 1)
        {
            if (int.Parse(CmbTipoIdentificacion.SelectedValue) == 3)
            {
                sv.CredEmpresaInser(TxtNit.Text, txtrazonsocial.Text, "", int.Parse(cmbTipoSociedad.SelectedValue), "", "", "", 11001, "", "", "", "", "", "", "", Fecha, "", "", int.Parse(CmbTipoIdentificacion.SelectedValue), TxtNitDigitoNew.Text, Convert.ToInt32(Session["IdPais"].ToString()),"", this.txtPaisActividad.Text.Trim().Split('-')[0], int.Parse(CmbSector.SelectedValue));
            }
            else if (int.Parse(CmbTipoIdentificacion.SelectedValue) == 3)
            {
                sv.CredEmpresaInser(TxtNit.Text, txtrazonsocial.Text, "", int.Parse(cmbTipoSociedad.SelectedValue), "", "", "", 11001, "", "", "", "", "", "", "", Fecha, "", "", int.Parse(CmbTipoIdentificacion.SelectedValue), TxtNitDigitoNew.Text, Convert.ToInt32(Session["IdPais"].ToString()), txtConsecutivoNew.Text, this.txtPaisActividad.Text.Trim().Split('-')[0], int.Parse(CmbSector.SelectedValue));
            }
            else
            {
                sv.CredEmpresaInser(TxtNit.Text, txtrazonsocial.Text, "", int.Parse(cmbTipoSociedad.SelectedValue), "", "", "", 11001, "", "", "", "", "", "", "", Fecha, "", "", int.Parse(CmbTipoIdentificacion.SelectedValue), TxtNitConDigito.Text, Convert.ToInt32(Session["IdPais"].ToString()),"", this.txtPaisActividad.Text.Trim().Split('-')[0], int.Parse(CmbSector.SelectedValue));
            }
            actualizaEmpresa(TxtNit.Text);

            sv.InGrupoEmpresaria("", true, 3, int.Parse(Encoder.HtmlEncode(Request.QueryString["IdGrupoEm"])), TxtNit.Text, "", 0);


            ds = sv.SeGrupoEmpresarial(Convert.ToInt32(Encoder.HtmlEncode(Request.QueryString["IdGrupoEm"])), 2, "");
            if (ds.Tables[0].Rows.Count > 0)
            {
                GrupoEmpresarialAct = ds.Tables[0].Rows[0]["GrupoEmpresarial"].ToString();
            }

            String DescripcionAudit = "Asociaciòn de empresa a un grupo económico con No. Documento" + Convert.ToString(TxtNit.Text) + " ; Grupo destino: " + GrupoEmpresarialAct;
            sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, "Configurar Grupos Económicos", Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);
        }

        llenargrupoXEmpresas(int.Parse(Encoder.HtmlEncode(Request.QueryString["IdGrupoEm"])));
        limpiaEmpresa();
        if (Existe != 1)
        {
            Response.Write("<script>alert('Empresa asociada a grupo económico')</script>");
        }
        else
        {
            Response.Write("<script>alert('Empresa ya existente en el sistema')</script>");
        }

    }

    protected void limpiaEmpresa()
    {
        pnlCrearEmp.Visible = false;
        txtBuscarEmpresa.Enabled = true;
        btnBuscarEmp.Enabled = true;
        ImgGuardarPeriodo.Visible = true;
        ImgLimpiarPeriodo.Visible = true;
        TxtNit.Text = "";
        TxtNitConDigito.Text = "";
        TxtNitDigitoNew.Text = "";
        txtConsecutivoNew.Text = "";
        txtrazonsocial.Text = "";
    }

    protected void CmbTipoIdentificacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(CmbTipoIdentificacion.SelectedValue) == 3)
        {
            TxtNit.Enabled = true;
            TxtNitDigitoNew.Visible = true;
            TxtNitConDigito.Visible = false;
            TxtNit.MaxLength = 9;
            txtConsecutivoNew.Text = "";
            DivCons.Visible = false;
            txtConsecutivoNew.Enabled = true;
        }
        else if (Convert.ToInt32(CmbTipoIdentificacion.SelectedValue) == 13)
        {
            txtConsecutivoNew.Text = "";
            DivCons.Visible = true;
            txtConsecutivoNew.Enabled = false;

            TxtNit.Enabled = false;
            TxtNitConDigito.Visible = false;
            TxtNit.MaxLength = 9;
            CargarConsecutivo();
        }
        else
        {
            TxtNit.Enabled = true;
            TxtNitDigitoNew.Visible = false;
            TxtNitConDigito.Visible = true;
            TxtNit.MaxLength = 30;
            txtConsecutivoNew.Text = "";
            DivCons.Visible = false;
            txtConsecutivoNew.Enabled = true;
        }
    }

    protected void CargarConsecutivo()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();
        string Consecutivo = "";
        int Pais = int.Parse(Session["IdPais"].ToString());
        long consecutivo = 0;
        switch (Pais)
        {
            case 1:
                Consecutivo = "SV";
                break;
            case 2:
                Consecutivo = "HN";
                break;
            case 3:
                Consecutivo = "CR";
                break;
            case 4:
                Consecutivo = "PA";
                break;

        }

        ds = sv.SeConsecutivoEmp(1, Pais);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToString(ds.Tables[0].Rows[0]["Consecutivo"]) != "")
            {
                consecutivo = Convert.ToInt64(ds.Tables[0].Rows[0]["Consecutivo"]);
            }
        }

        Consecutivo = Consecutivo + Convert.ToString(consecutivo + 1);
        txtConsecutivoNew.Text = Consecutivo;
        TxtNit.Text = Consecutivo;


    }

    protected void TxtNitDigitoNew_TextChanged(object sender, EventArgs e)
    {
        String Nit = TxtNitDigitoNew.Text;
        Int32 Numero = Nit.Length - 1;

        Int32[] Multiplicando = new Int32[9];
        Int32[] Multiplicador = { 3, 7, 13, 17, 19, 23, 29, 37, 41 };
        Int32[] Producto = new Int32[9];

        Int64 TotalSuma = 0;
        Int64 Residuo = 0;

        for (int i = 0; i < Nit.Length; i++)
        {
            Multiplicando[i] = Convert.ToInt32(Nit.ToCharArray()[Numero].ToString());
            Numero--;
            Producto[i] = Multiplicando[i] * Multiplicador[i];

            TotalSuma = TotalSuma + Producto[i];
        }
        Residuo = TotalSuma % 11;

        if (Residuo == 1 || Residuo == 0)
        {
            TxtNitDigitoNew.Text = TxtNitDigitoNew.Text + Residuo.ToString();
        }
        else
        {
            TxtNitDigitoNew.Text = TxtNitDigitoNew.Text + Convert.ToInt32((Residuo - 11) * -1);
        }
    }

}