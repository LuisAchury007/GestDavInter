using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Conf_CCualitativa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IDusuario"] == null)
        {
            Response.Redirect("Salir.aspx");
        }
        if (Page.IsPostBack == false)
        {
            LLenarDatosGrilla();
            LLenarDatosCualitativa();
            LLenarDatosAgrupaciones();
            LLenarDatosVariables();
        }
    }

    private void LLenarDatosGrilla()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = sv.Encuesta(0, 2);
        this.GridEncCualitativa.DataSource = ds.Tables[0].DefaultView;
        this.GridEncCualitativa.DataBind();
        ds.Clear();

    }

    private void LLenarDatosAgrupacion()
    {
        Datos sv = new Datos();
        DataSet dts = new DataSet();

        if (CmbEncuesta.SelectedValue != "-1")
        {
            dts = sv.Agrupacion(int.Parse(CmbEncuesta.SelectedValue.ToString()), 1);
            this.GridAgrupaciones.DataSource = dts.Tables[0].DefaultView;
            this.GridAgrupaciones.DataBind();
            pnlAgrupaciones.Visible = true;
            dts.Clear();
        }
        else
        {
            pnlAgrupaciones.Visible = false;
        }
        TabContainer1.ActiveTab = TabContainer1.Tabs[1];

    }

    private void LLenarDatosVariable()
    {
        Datos sv = new Datos();
        DataSet dts = new DataSet();

        if (CmbAgrupacion.SelectedValue != "-1")
        {
            dts = sv.Variables(int.Parse(CmbAgrupacion.SelectedValue.ToString()), 1);
            this.GridVariables.DataSource = dts.Tables[0].DefaultView;
            this.GridVariables.DataBind();
            pnlVariables.Visible = true;
            dts.Clear();
        }
        else
        {
            pnlVariables.Visible = false;
        }
        TabContainer1.ActiveTab = TabContainer1.Tabs[2];

    }

    private void LLenarDatosRespuesta()
    {
        Datos sv = new Datos();
        DataSet dts = new DataSet();

        if (CmbVariables.SelectedValue != "-1")
        {
            dts = sv.Respuestas(int.Parse(CmbVariables.SelectedValue.ToString()), 1);
            this.GridRespuestas.DataSource = dts.Tables[0].DefaultView;
            this.GridRespuestas.DataBind();
            dts.Clear();
            pnlRespuestas.Visible = true;
        }
        else
        {
            pnlRespuestas.Visible = false;
        }
        TabContainer1.ActiveTab = TabContainer1.Tabs[3];

    }

    private void LLenarDatosCualitativa()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = sv.CualitativaSeleccion();
        ds.Tables[0].Rows.Add("-1", "Seleccione>>");
        this.CmbEncuesta.DataSource = ds.Tables[0].DefaultView;
        this.CmbEncuesta.SelectedValue = "-1";
        this.CmbEncuesta.DataTextField = "NomCualitativa";
        this.CmbEncuesta.DataValueField = "IdEncCualitativa";
        this.CmbEncuesta.DataBind();
        ds.Clear();

    }

    private void LLenarDatosAgrupaciones()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = sv.Agrupacion(0, 2);
        ds.Tables[0].Rows.Add("-1", "Seleccione>>");
        this.CmbAgrupacion.DataSource = ds.Tables[0].DefaultView;
        this.CmbAgrupacion.SelectedValue = "-1";
        this.CmbAgrupacion.DataTextField = "Agrupacion";
        this.CmbAgrupacion.DataValueField = "IdAgrupacion";
        this.CmbAgrupacion.DataBind();
        ds.Clear();


    }

    private void LLenarDatosVariables()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = sv.Variables(0, 2);
        ds.Tables[0].Rows.Add("-1", "-1", "Seleccione>>");
        this.CmbVariables.DataSource = ds.Tables[0].DefaultView;
        this.CmbVariables.SelectedValue = "-1";
        this.CmbVariables.DataTextField = "Variable";
        this.CmbVariables.DataValueField = "IdVariable";
        this.CmbVariables.DataBind();
        ds.Clear();

    }

    protected void GridEncCualitativa_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        long index;
        Datos sv = new Datos();

        switch (e.CommandName)
        {
            case "Editar":
                index = Convert.ToInt16(e.CommandArgument);
                DataSet ds = new DataSet();
                ds = sv.Encuesta(int.Parse(index.ToString()), 1);

                this.txtNombre.Text = Convert.ToString(ds.Tables[0].Rows[0]["NomCualitativa"]);
                HidNombre1.Value = Convert.ToString(ds.Tables[0].Rows[0]["NomCualitativa"]);
                this.txtDescripción.Text = Convert.ToString(ds.Tables[0].Rows[0]["DescCualitativa"]);
                HidDescripcion2.Value = Convert.ToString(ds.Tables[0].Rows[0]["DescCualitativa"]);
                this.chkEstado.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Estado"]);
                HidEstacoEncuesta3.Value = Convert.ToString(ds.Tables[0].Rows[0]["Estado"]);

                ds.Clear();
                this.HEncuestaID.Value = index.ToString();
                this.HEncuestaNueva.Value = "false";

                break;
            default:
                break;
        }

    }

    protected void GridAgrupaciones_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        long index;
        Datos sv = new Datos();

        switch (e.CommandName)
        {
            case "Editar":
                index = Convert.ToInt16(e.CommandArgument);
                DataSet ds = new DataSet();
                string PesoAgrup;
                ds = sv.Agrupacion(int.Parse(index.ToString()), 3);
                this.txtAgrupacion.Text = Convert.ToString(ds.Tables[0].Rows[0]["Agrupacion"]);
                HidAgrupacion1.Value = Convert.ToString(ds.Tables[0].Rows[0]["Agrupacion"]);
                PesoAgrup = Convert.ToString(ds.Tables[0].Rows[0]["Peso"]);
                HidPesoAgrupacion2.Value = Convert.ToString(ds.Tables[0].Rows[0]["Peso"]);
                PesoAgrup = PesoAgrup.Replace(",", ".").ToString();
                this.txtPesoAgrupacion.Text = PesoAgrup;
                HidAgrupacionPeso.Value = PesoAgrup;
                this.chkAgrupacion.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Estado"]);
                HiddchkAgrupacion3.Value = Convert.ToString(ds.Tables[0].Rows[0]["Estado"]);

                ds.Clear();
                this.HAgrupacionID.Value = index.ToString();
                this.HAgrupacionNuevo.Value = "false";
                break;
            default:
                break;
        }

    }

    protected void GridVariables_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        long index;
        Datos sv = new Datos();

        switch (e.CommandName)
        {
            case "Editar":
                index = Convert.ToInt16(e.CommandArgument);
                DataSet ds = new DataSet();
                string PesoVar;
                ds = sv.Variables(int.Parse(index.ToString()), 3);
                this.txtVAriable.Text = Convert.ToString(ds.Tables[0].Rows[0]["Variable"]);
                HidVAriable1.Value = Convert.ToString(ds.Tables[0].Rows[0]["Variable"]);
                PesoVar = Convert.ToString(ds.Tables[0].Rows[0]["Peso"]);
                HidPesoVariable2.Value = Convert.ToString(ds.Tables[0].Rows[0]["Peso"]);
                PesoVar = PesoVar.Replace(",", ".").ToString();
                HidPesoVariable.Value = PesoVar;
                this.txtPesoVariable.Text = PesoVar;
                this.chkVariable.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Estado"]);
                HidchkVariable.Value = Convert.ToString(ds.Tables[0].Rows[0]["Estado"]);

                ds.Clear();

                this.HVariableID.Value = index.ToString();
                this.HVariableNUeva.Value = "false";
                break;
            default:
                break;
        }

    }

    protected void GridRespuestas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        long index;
        Datos sv = new Datos();

        switch (e.CommandName)
        {
            case "Editar":
                index = Convert.ToInt16(e.CommandArgument);
                DataSet ds = new DataSet();
                string PesoResp;
                ds = sv.Respuestas(int.Parse(index.ToString()), 2);
                this.txtRespuesta.Text = Convert.ToString(ds.Tables[0].Rows[0]["Respuesta"]);
                HidRespuesta1.Value = Convert.ToString(ds.Tables[0].Rows[0]["Respuesta"]);
                PesoResp = Convert.ToString(ds.Tables[0].Rows[0]["Factor"]);
                HidFactor2.Value = Convert.ToString(ds.Tables[0].Rows[0]["Factor"]);
                PesoResp = PesoResp.Replace(",", ".").ToString();
                this.txtFactor.Text = PesoResp;
                HiDPeso.Value = Convert.ToString(ds.Tables[0].Rows[0]["Factor"]);
                this.chkEstadoRespuesta.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Estado"]);
                HidEstadoRespuesta3.Value = Convert.ToString(ds.Tables[0].Rows[0]["Estado"]);
                ds.Clear();

                this.HRespuestaID.Value = index.ToString();
                this.HRespuestaNueva.Value = "false";
                break;
            default:
                break;
        }

    }

    protected void CmbEncuesta_SelectedIndexChanged(object sender, EventArgs e)
    {
        LLenarDatosAgrupacion();
        LinkBtnAgrupacion.Visible = true;
        LinkBGuardar.Visible = false;
    }

    protected void CmbAgrupacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        LLenarDatosVariable();
        LinkBGuardarPesoVariable.Visible = true;
        LinkBGuardarPesoTotal.Visible = false;
    }

    protected void CmbVariables_SelectedIndexChanged(object sender, EventArgs e)
    {
        LLenarDatosRespuesta();
        LinkGuardaRest.Visible = true;
        LinkGuardaRestTotal.Visible = false;
    }

    protected void BtnGuardaEncuesta_Click(object sender, ImageClickEventArgs e)
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        if (HEncuestaNueva.Value == "true")
        {
            sv.InEncCualitativa(this.txtNombre.Text, this.txtDescripción.Text, this.chkEstado.Checked);

            String DescripcionAudit = "Insercion datos encuesta cualitativa: " + Convert.ToString(this.txtNombre.Text) + ". Desccripción:" + Convert.ToString(this.txtDescripción.Text) + ". Estado: " + chkEstado.Checked;
            sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCCualitativa.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

            LimpiarEncuestaCualitativa();
            LLenarDatosGrilla();
        }
        else
        {
            if (this.chkEstado.Checked == false)
            {
                ds = sv.Encuesta(int.Parse(this.HEncuestaID.Value), 3);

                if (Convert.ToInt32(ds.Tables[0].Rows[0]["Existe"]) > 0)
                {
                    Response.Write("<script>alert('No se puede inactivar esta encuesta, ya que esta relacionada a un sector')</script>");
                    return;
                }
            }
                
            sv.UpEncCualitativa(this.txtNombre.Text, this.txtDescripción.Text, this.chkEstado.Checked, int.Parse(this.HEncuestaID.Value));



            String DescripcionAudit = "Actualización datos encuesta cualitativa:" + Convert.ToString(this.txtNombre.Text) + ". Nombre anterior: " + this.HidNombre1.Value + ". Nueva descripción: " + Convert.ToString(this.txtDescripción.Text) + ". Descripción anterior: " + Convert.ToString(this.HidDescripcion2.Value) + ". Estado Anterior:" + HidEstacoEncuesta3.Value + ". Estado actual:" + chkEstado.Checked;
            sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCCualitativa.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

            LimpiarEncuestaCualitativa();
            LLenarDatosGrilla();
        }
        LLenarDatosCualitativa();

    }

    protected void ImgGuardarAgrupacion_Click(object sender, ImageClickEventArgs e)
    {
        Datos sv = new Datos();

        if (CmbEncuesta.SelectedValue != "-1")
        {

            Decimal TotalPesos = decimal.Parse(txtPesoAgrupacion.Text);
            string pesoAgrupacion;
            foreach (GridViewRow row in GridAgrupaciones.Rows)
            {
                TextBox TxtpesoVAgru = (row.FindControl("Txtpeso") as TextBox);
                pesoAgrupacion = TxtpesoVAgru.Text.Trim();
                pesoAgrupacion = pesoAgrupacion.Replace(".", ",").ToString();
                TotalPesos = TotalPesos + Convert.ToDecimal(pesoAgrupacion);
            }

            if (HAgrupacionNuevo.Value == "true")
            {
                if (TotalPesos == 100)
                {
                    sv.InAgrupacion(this.txtAgrupacion.Text, decimal.Parse(txtPesoAgrupacion.Text), this.chkAgrupacion.Checked, int.Parse(CmbEncuesta.SelectedValue));

                    String DescripcionAudit = "Insercion datos agrupación: " + Convert.ToString(this.txtAgrupacion.Text) + ". Peso:" + Convert.ToString(this.txtPesoAgrupacion.Text) + ". Estado: " + chkAgrupacion.Checked;
                    sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCCualitativa.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

                    LimpiarAgrupacion();
                    LLenarDatosAgrupacion();
                    LLenarDatosAgrupaciones();
                    Response.Write("<script>alert('Datos Guardados Correctamente')</script>");
                }
                else
                {
                    Response.Write("<script>alert('La sumatoria de los Pesos no puede ser diferente de 100')</script>");
                }
            }
            else
            {
                TotalPesos = TotalPesos - Decimal.Parse(HidAgrupacionPeso.Value);
                if (TotalPesos == 100)
                {
                    sv.UpAgrupacion(this.txtAgrupacion.Text, decimal.Parse(this.txtPesoAgrupacion.Text), this.chkAgrupacion.Checked, int.Parse(CmbEncuesta.SelectedValue), int.Parse(this.HAgrupacionID.Value), 1);

                    String DescripcionAudit = "Actualización datos agrupación:" + Convert.ToString(this.txtAgrupacion.Text) + ". Agrupación anterior: " + this.HidAgrupacion1.Value + ". Peso actual : " + Convert.ToString(this.txtPesoAgrupacion.Text) + ". Peso anterior: " + Convert.ToString(this.HidPesoAgrupacion2.Value) + ". Estado Anterior:" + HiddchkAgrupacion3.Value + ". Estado actual:" + chkAgrupacion.Checked;
                    sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCCualitativa.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

                    LimpiarAgrupacion();
                    LLenarDatosAgrupacion();
                    LLenarDatosAgrupaciones();
                    Response.Write("<script>alert('Datos Actualizacos Correctamente')</script>");
                }
                else
                {
                    Response.Write("<script>alert('La sumatoria de los Pesos no puede ser diferente de 100')</script>");
                }
            }
        }
        else
        {
            Response.Write("<script>alert('Debe Seleccionar una encuesta para guardar')</script>");
        }

    }

    protected void ImgButtonVariable_Click(object sender, ImageClickEventArgs e)
    {
        Datos sv = new Datos();

        if (CmbAgrupacion.SelectedValue != "-1")
        {
            Decimal TotalPesos = Decimal.Parse(txtPesoVariable.Text);
            string pesoVariable;
            foreach (GridViewRow row in GridVariables.Rows)
            {
                TextBox TxtpesoVar = (row.FindControl("TxtpesoVar") as TextBox);
                pesoVariable = TxtpesoVar.Text.Trim();
                pesoVariable = pesoVariable.Replace(".", ",").ToString();
                TotalPesos = TotalPesos + Convert.ToDecimal(pesoVariable);
            }

            if (HVariableNUeva.Value == "true")
            {
                if (TotalPesos == 100)
                {

                    sv.InVariables(this.txtVAriable.Text, 0, this.chkVariable.Checked, int.Parse(CmbAgrupacion.SelectedValue));

                    String DescripcionAudit = "Insercion datos variable: " + Convert.ToString(this.txtVAriable.Text) + ". Peso:" + Convert.ToString(this.txtPesoVariable.Text) + ". Estado: " + chkVariable.Checked;
                    sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCCualitativa.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

                    LimpiarVariable();
                    LLenarDatosVariable();
                    LLenarDatosVariables();
                    Response.Write("<script>alert('Datos Guardados Correctamente')</script>");
                }
                else
                {
                    Response.Write("<script>alert('La sumatoria de los Pesos no puede ser diferente de 100')</script>");
                }
            }
            else
            {
                TotalPesos = TotalPesos - Decimal.Parse(HidPesoVariable.Value);
                if (TotalPesos == 100)
                {
                    sv.UpVariables(this.txtVAriable.Text, decimal.Parse(this.txtPesoVariable.Text), this.chkVariable.Checked, int.Parse(CmbAgrupacion.SelectedValue), int.Parse(this.HVariableID.Value), 1);

                    String DescripcionAudit = "Actualización datos variable:" + Convert.ToString(this.txtVAriable.Text) + ". Variable anterior: " + this.HidVAriable1.Value + ". Peso actual : " + Convert.ToString(this.txtPesoVariable.Text) + ". Peso anterior: " + Convert.ToString(this.HidPesoVariable2.Value) + ". Estado Anterior:" + HidchkVariable.Value + ". Estado actual:" + chkVariable.Checked;
                    sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCCualitativa.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

                    LimpiarVariable();
                    LLenarDatosVariable();
                    LLenarDatosVariables();
                    Response.Write("<script>alert('Datos Actualizacos Correctamente')</script>");
                }
                else
                {
                    Response.Write("<script>alert('La sumatoria de los Pesos no puede ser diferente de 100')</script>");
                }
            }
        }

    }

    protected void ImgGuardarRespuesta_Click(object sender, ImageClickEventArgs e)
    {
        Datos sv = new Datos();

        if (CmbVariables.SelectedValue != "-1")
        {
            string pesoRespuesta2;
            pesoRespuesta2 = txtFactor.Text.Trim();
            pesoRespuesta2 = pesoRespuesta2.Replace(".", ",").ToString();

            if (HRespuestaNueva.Value == "true")
            {
                if (Convert.ToDecimal(pesoRespuesta2) >= 1 && Convert.ToDecimal(pesoRespuesta2) <= 3)
                {
                    sv.InRespuestas(this.txtRespuesta.Text, Convert.ToDecimal(pesoRespuesta2), this.chkEstadoRespuesta.Checked, int.Parse(CmbVariables.SelectedValue));

                    String DescripcionAudit = "Insercion datos respuestas: " + Convert.ToString(this.txtRespuesta.Text) + ". Factor:" + Convert.ToString(this.txtFactor.Text) + ". Estado: " + chkEstadoRespuesta.Checked;
                    sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCCualitativa.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

                    LimpiarRespuesta();
                    LLenarDatosRespuesta();
                    Response.Write("<script>alert('Datos Guardados Correctamente')</script>");
                }
                else
                {
                    Response.Write("<script>alert('El Valor del peso no puede ser menor a 1 o mayor a 3')</script>");
                }
            }
            else
            {
                if (Convert.ToDecimal(pesoRespuesta2) >= 1 && Convert.ToDecimal(pesoRespuesta2) <= 3)
                {
                    sv.UpRespuestas(this.txtRespuesta.Text, Convert.ToDecimal(pesoRespuesta2), this.chkEstadoRespuesta.Checked, int.Parse(CmbVariables.SelectedValue), int.Parse(this.HRespuestaID.Value), 1);

                    String DescripcionAudit = "Actualizacion datos respuestas:" + Convert.ToString(this.txtRespuesta.Text) + ". Respuesta anterior: " + this.HidRespuesta1.Value + ". Factor actual : " + Convert.ToString(this.txtFactor.Text) + ". Factor anterior: " + Convert.ToString(this.HidFactor2.Value) + ". Estado Anterior:" + HidEstadoRespuesta3.Value + ". Estado actual:" + chkEstadoRespuesta.Checked;
                    sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCCualitativa.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

                    LimpiarRespuesta();
                    LLenarDatosRespuesta();
                    Response.Write("<script>alert('Datos Actualizacos Correctamente')</script>");
                }
                else
                {
                    Response.Write("<script>alert('El Valor del peso no puede ser menor a 1 o mayor a 3')</script>");
                }
            }
        }
        else
        {
            Response.Write("<script>alert('Debe Seleccionar una Variable para guardar')</script>");
        }

    }

    private void LimpiarEncuestaCualitativa()
    {
        this.txtNombre.Text = "";
        this.txtDescripción.Text = "";
        this.chkEstado.Checked = false;
        this.HEncuestaID.Value = "0";
        this.HEncuestaNueva.Value = "true";
        LinkBtnAgrupacion.Visible = true;
        LinkBGuardar.Visible = false;
    }

    private void LimpiarAgrupacion()
    {
        this.txtAgrupacion.Text = "";
        this.txtPesoAgrupacion.Text = "";
        this.chkAgrupacion.Checked = false;
        this.HAgrupacionNuevo.Value = "true";
        this.HAgrupacionID.Value = "0";
        LinkBGuardarPesoVariable.Visible = true;
        LinkBGuardarPesoTotal.Visible = false;
    }

    private void LimpiarVariable()
    {
        this.txtVAriable.Text = "";
        this.txtPesoVariable.Text = "";
        this.txtPesoVariable.Text = "";
        this.chkVariable.Checked = false;
        this.HVariableNUeva.Value = "true";
        this.HVariableID.Value = "0";
        LinkGuardaRest.Visible = true;
        LinkGuardaRestTotal.Visible = false;
    }

    private void LimpiarRespuesta()
    {
        this.txtRespuesta.Text = "";
        this.txtFactor.Text = "";
        this.chkEstadoRespuesta.Checked = false;
        this.HRespuestaNueva.Value = "true";
        this.HRespuestaID.Value = "0";
        LinkGuardaRest.Visible = true;
        LinkGuardaRestTotal.Visible = false;
    }

    protected void ImgLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarEncuestaCualitativa();
    }

    protected void ImgLimpiarAgrupacion_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarAgrupacion();
    }

    protected void ImgLimpiaVariable_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarVariable();
    }

    protected void ImgLimpiarRespuesta_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarRespuesta();
    }

    protected void GridAgrupaciones_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Datos sv = new Datos();

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataSet ds = new DataSet();
            TextBox Txtpeso = (e.Row.FindControl("Txtpeso") as TextBox);
            CheckBox chkEstadoAgru = (e.Row.FindControl("chkEstadoAgru") as CheckBox);

            int IdAgrupacion = Convert.ToInt32(GridAgrupaciones.DataKeys[e.Row.RowIndex]["IdAgrupacion"].ToString());
            ds = sv.Agrupacion(IdAgrupacion, 3);
            Txtpeso.Text = Convert.ToString(ds.Tables[0].Rows[0]["Peso"]);
            chkEstadoAgru.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Estado"]);
        }

    }

    protected void GridVariables_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Datos sv = new Datos();

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataSet ds = new DataSet();
            TextBox TxtpesoVar = (e.Row.FindControl("TxtpesoVar") as TextBox);
            CheckBox chkEstadoVar = (e.Row.FindControl("chkEstadoVar") as CheckBox);

            int IdVariable = Convert.ToInt32(GridVariables.DataKeys[e.Row.RowIndex]["IdVariable"].ToString());
            ds = sv.Variables(IdVariable, 3);
            TxtpesoVar.Text = Convert.ToString(ds.Tables[0].Rows[0]["Peso"]);
            chkEstadoVar.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Estado"]);
        }

    }

    protected void GridRespuestas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Datos sv = new Datos();

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataSet ds = new DataSet();
            TextBox TxtpesoRespuesta = (e.Row.FindControl("TxtpesoRespuesta") as TextBox);
            CheckBox chkEstadoRespt = (e.Row.FindControl("chkEstadoRespt") as CheckBox);

            int IdRespuesta = Convert.ToInt32(GridRespuestas.DataKeys[e.Row.RowIndex]["IdRespuesta"].ToString());
            ds = sv.Respuestas(IdRespuesta, 2);
            TxtpesoRespuesta.Text = Convert.ToString(ds.Tables[0].Rows[0]["Factor"]);
            chkEstadoRespt.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Estado"]);
        }

    }

    protected void LinkBtnAgrupacion_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridAgrupaciones.Rows)
        {
            TextBox Txtpeso = ((TextBox)row.FindControl("Txtpeso"));
            Txtpeso.Enabled = true;
        }
        LinkBGuardar.Visible = true;
        LinkBtnAgrupacion.Visible = false;
    }

    protected void LinkBGuardarPesoVariable_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridVariables.Rows)
        {
            TextBox TxtpesoVar = ((TextBox)row.FindControl("TxtpesoVar"));
            TxtpesoVar.Enabled = true;
        }
        LinkBGuardarPesoTotal.Visible = true;
        LinkBGuardarPesoVariable.Visible = false;
    }

    protected void LinkGuardaRest_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridRespuestas.Rows)
        {
            TextBox TxtpesoRespuesta = ((TextBox)row.FindControl("TxtpesoRespuesta"));
            TxtpesoRespuesta.Enabled = true;
        }
        LinkGuardaRestTotal.Visible = true;
        LinkGuardaRest.Visible = false;
    }

    protected void LinkBGuardar_Click(object sender, EventArgs e)
    {
        Decimal TotalPesos = 0, Inactivos = 0;
        string pesoAgrupacion;
        Datos sv = new Datos();

        foreach (GridViewRow row in GridAgrupaciones.Rows)
        {
            TextBox TxtpesoVAgru = (row.FindControl("Txtpeso") as TextBox);
            pesoAgrupacion = TxtpesoVAgru.Text.Trim();
            pesoAgrupacion = pesoAgrupacion.Replace(".", ",").ToString();
            Boolean chkEstadoAgru = Boolean.Parse(((CheckBox)row.FindControl("chkEstadoAgru")).Checked.ToString());
            TotalPesos = TotalPesos + Convert.ToDecimal(pesoAgrupacion);
            if (chkEstadoAgru == false && Convert.ToDecimal(pesoAgrupacion) != 0)
            {
                Inactivos++;
            }
        }
        if (TotalPesos == 100)
        {
            if (Inactivos == 0)
            {
                foreach (GridViewRow row in GridAgrupaciones.Rows)
                {
                    TextBox TxtpesoAgru = (row.FindControl("Txtpeso") as TextBox);
                    pesoAgrupacion = TxtpesoAgru.Text.Trim();
                    pesoAgrupacion = pesoAgrupacion.Replace(".", ",").ToString();
                    int IdAgrupacion = Convert.ToInt32(GridAgrupaciones.DataKeys[row.RowIndex]["IdAgrupacion"].ToString());
                    if (Convert.ToDecimal(pesoAgrupacion) >= 0 && Convert.ToDecimal(pesoAgrupacion) <= 100)
                    {
                        sv.UpAgrupacion("", Convert.ToDecimal(pesoAgrupacion), true, 0, int.Parse(IdAgrupacion.ToString()), 2);
                    }
                    else
                    {
                        Response.Write("<script>alert('El Valor del peso no puede ser menor a 0 o mayor a 100')</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Las Agrupaciones desactivadas no se le pueden asignar valores')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('La sumatoria de los Pesos no puede ser diferente de 100')</script>");
        }

        foreach (GridViewRow row in GridAgrupaciones.Rows)
        {
            TextBox Txtpeso = ((TextBox)row.FindControl("Txtpeso"));
            Txtpeso.Enabled = false;
        }
        LimpiarAgrupacion();
        LLenarDatosAgrupacion();
        LinkBGuardar.Visible = false;
        LinkBtnAgrupacion.Visible = true;

    }

    protected void LinkBGuardarPesoTotal_Click(object sender, EventArgs e)
    {
        Decimal TotalPesos = 0, Inactivos = 0;
        string pesoVariable;
        Datos sv = new Datos();

        foreach (GridViewRow row in GridVariables.Rows)
        {
            TextBox TxtpesoVar = (row.FindControl("TxtpesoVar") as TextBox);
            pesoVariable = TxtpesoVar.Text.Trim();
            pesoVariable = pesoVariable.Replace(".", ",").ToString();
            Boolean chkEstadoVar = Boolean.Parse(((CheckBox)row.FindControl("chkEstadoVar")).Checked.ToString());
            TotalPesos = TotalPesos + Convert.ToDecimal(pesoVariable);
            if (chkEstadoVar == false && Convert.ToDecimal(pesoVariable) != 0)
            {
                Inactivos++;
            }
        }
        if (TotalPesos == 100)
        {
            if (Inactivos == 0)
            {
                foreach (GridViewRow row in GridVariables.Rows)
                {
                    TextBox TxtpesoVar = (row.FindControl("TxtpesoVar") as TextBox);
                    pesoVariable = TxtpesoVar.Text.Trim();
                    pesoVariable = pesoVariable.Replace(".", ",").ToString();
                    int IdVariable = Convert.ToInt32(GridVariables.DataKeys[row.RowIndex]["IdVariable"].ToString());
                    if (Convert.ToDecimal(pesoVariable) >= 0 && Convert.ToDecimal(pesoVariable) <= 100)
                    {
                        sv.UpVariables("", Convert.ToDecimal(pesoVariable), true, 0, int.Parse(IdVariable.ToString()), 2);
                    }
                    else
                    {
                        Response.Write("<script>alert('El Valor del peso no puede ser menor a 0 o mayor a 100')</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Las Variables desactivadas no se le pueden asignar valores')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('La sumatoria de los Pesos no puede ser diferente de 100')</script>");
        }

        foreach (GridViewRow row in GridVariables.Rows)
        {
            TextBox Txtpeso = ((TextBox)row.FindControl("TxtpesoVar"));
            Txtpeso.Enabled = false;
        }
        LimpiarVariable();
        LLenarDatosVariable();
        LinkBGuardarPesoTotal.Visible = false;
        LinkBGuardarPesoVariable.Visible = true;

    }

    protected void LinkGuardaRestTotal_Click(object sender, EventArgs e)
    {
        int Inactivos = 0;
        string pesoRespuesta;
        Datos sv = new Datos();

        foreach (GridViewRow row in GridRespuestas.Rows)
        {
            Boolean chkEstadoResp = Boolean.Parse(((CheckBox)row.FindControl("chkEstadoRespt")).Checked.ToString());
            TextBox TxtpesoRespuesta = (row.FindControl("TxtpesoRespuesta") as TextBox);
            pesoRespuesta = TxtpesoRespuesta.Text.Trim();
            pesoRespuesta = pesoRespuesta.Replace(".", ",").ToString();
            if (chkEstadoResp == false && Convert.ToDecimal(pesoRespuesta) != 0)
            {
                Inactivos++;
            }
        }
        if (Inactivos == 0)
        {
            foreach (GridViewRow row in GridRespuestas.Rows)
            {
                TextBox TxtpesoRespuesta = (row.FindControl("TxtpesoRespuesta") as TextBox);
                pesoRespuesta = TxtpesoRespuesta.Text.Trim();
                pesoRespuesta = pesoRespuesta.Replace(".", ",").ToString();
                int IdRespuesta = Convert.ToInt32(GridRespuestas.DataKeys[row.RowIndex]["IdRespuesta"].ToString());
                if (Convert.ToDecimal(pesoRespuesta) >= 0 && Convert.ToDecimal(pesoRespuesta) <= 3)
                {
                    sv.UpRespuestas("", Convert.ToDecimal(pesoRespuesta), true, 0, int.Parse(IdRespuesta.ToString()), 2);
                }
                else
                {
                    Response.Write("<script>alert('El Valor del peso no puede ser menor a 0 o mayor a 3')</script>");
                }
                TextBox Txtpeso = ((TextBox)row.FindControl("TxtpesoRespuesta"));
                Txtpeso.Enabled = false;
            }
        }
        else
        {
            Response.Write("<script>alert('Las Respuestas desactivadas no se le pueden asignar valores')</script>");
        }

        LimpiarRespuesta();
        LLenarDatosRespuesta();
        LinkGuardaRestTotal.Visible = false;
        LinkGuardaRest.Visible = true;

    }

    protected void GridEncCualitativa_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Datos sv = new Datos();

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataSet ds = new DataSet();
            int IdEncuesta = Convert.ToInt32(GridEncCualitativa.DataKeys[e.Row.RowIndex]["IdEncCualitativa"].ToString());
            CheckBox chkEstadoEncuesta = (e.Row.FindControl("chkEstadoEncuesta") as CheckBox);
            ds = sv.Encuesta(IdEncuesta, 1);
            chkEstadoEncuesta.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Estado"]);
        }

    }
}