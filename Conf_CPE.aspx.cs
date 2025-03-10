using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

public partial class Conf_CPE : System.Web.UI.Page
{
    public string segmentState = "collapse";
    public string macroState = "collapse";

    void Page_Init(object sender, EventArgs e)
    {
        if (Session.IsNewSession)
        {
            // Force session to be created;
            // otherwise the session ID changes on every request.
            Session["ForceSession"] = DateTime.Now;
        }
        // 'Sign' the viewstate with the current session.
        this.ViewStateUserKey = Session.SessionID;
        if (Page.EnableViewState)
        {
            // Make sure ViewState wasn't passed on the querystring.
            // This helps prevent one-click attacks.
            if (!string.IsNullOrEmpty(Request.Params["__VIEWSTATE"]) &&
              string.IsNullOrEmpty(Request.Form["__VIEWSTATE"]))
            {
                throw new Exception("Viewstate existed, but not on the form.");
            }
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IDusuario"] == null)
        {
            Response.Redirect("Salir.aspx");
        }

        if (Page.IsPostBack == false)
        {
            HPeriodoID.Value = "0";
            LLenarDatosGrillaCalificacion();
            LLenarDatosGrillaPeriodo();
        }
    }

    private void LLenarDatosGrillaCalificacion()
    {
        Datos sv = new Datos();

        DataSet ds = new DataSet();
        ds = sv.SeCPECalificacion(0, 1);
        this.grvCPECalificacion.DataSource = ds.Tables[0].DefaultView;
        this.grvCPECalificacion.DataBind();
        ds.Clear();

    }

    private void LLenarDatosGrillaPeriodo()
    {
        Datos sv = new Datos();

        DataSet ds = new DataSet();
        ds = sv.SeCPEPeriodo(0, 3);
        this.grvCPEPeriodo.DataSource = ds.Tables[0].DefaultView;
        this.grvCPEPeriodo.DataBind();
        ds.Clear();

    }

    protected void grvCPECalificacion_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Datos sv = new Datos();

            DataSet ds = new DataSet();
            TextBox TxtFactorCalificacion = (e.Row.FindControl("TxtFactorCalificacion") as TextBox);
            CheckBox chkEstadoRespt = (e.Row.FindControl("chkEstadoRespt") as CheckBox);
            TextBox pisoCPE = (e.Row.FindControl("textPisoCPE") as TextBox);

            int IdCpECalificacion = Convert.ToInt32(grvCPECalificacion.DataKeys[e.Row.RowIndex]["IdCpECalificacion"].ToString());
            ds = sv.SeCPECalificacion(IdCpECalificacion, 2);
            TxtFactorCalificacion.Text = Convert.ToString(ds.Tables[0].Rows[0]["Factor"]);
            chkEstadoRespt.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Estado"]);
            pisoCPE.Text = Convert.ToString(ds.Tables[0].Rows[0]["PisoCPE"]);

        }
    }

    protected void grvCPEPeriodo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Datos sv = new Datos();

            DataSet ds = new DataSet();
            TextBox TxtPeriodoPeso = (e.Row.FindControl("TxtPeriodoPeso") as TextBox);
            CheckBox chkEstadoRespt = (e.Row.FindControl("chkEstadoRespt") as CheckBox);

            int IdCpEPeriodo = Convert.ToInt32(grvCPEPeriodo.DataKeys[e.Row.RowIndex]["IdCpEPeriodo"].ToString());
            ds = sv.SeCPEPeriodo(IdCpEPeriodo, 2);
            TxtPeriodoPeso.Text = Convert.ToString(ds.Tables[0].Rows[0]["Peso"]);
            chkEstadoRespt.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Estado"]);

        }
    }

    protected void grvCPECalificacion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        long index;
        Datos sv = new Datos();

        switch (e.CommandName)
        {
            case "Editar":
                index = Convert.ToInt16(e.CommandArgument);
                DataSet ds = new DataSet();
                string factor;
                ds = sv.SeCPECalificacion(int.Parse(index.ToString()), 2);
                this.txtCalificacion.Text = Convert.ToString(ds.Tables[0].Rows[0]["Calificacion"]);
                HidCalificacion.Value = Convert.ToString(ds.Tables[0].Rows[0]["Calificacion"]);
                this.chkEstadoEstadoDias.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Estado"]);
                HidEstadoEstadoDias.Value = Convert.ToString(ds.Tables[0].Rows[0]["Estado"]);
                factor = Convert.ToString(ds.Tables[0].Rows[0]["Factor"]);
                HidFactorCPE.Value = Convert.ToString(ds.Tables[0].Rows[0]["Factor"]);
                factor = factor.Replace(".", ",").ToString();
                this.txtFactorCPE.Text = factor;
                this.txtPisoCPE.Text = Convert.ToString(ds.Tables[0].Rows[0]["PisoCPE"]).Replace(".", ",").ToString();
                ds.Clear();


                this.HCalificacionID.Value = index.ToString();
                this.HCalificacionNUevo.Value = "false";
                break;
            default:
                break;
        }
        macroState = "in";

    }

    protected void grvCPEPeriodo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        long index;
        Datos sv = new Datos();

        switch (e.CommandName)
        {
            case "Editar":
                index = Convert.ToInt16(e.CommandArgument);
                DataSet ds = new DataSet();
                ds = sv.SeCPEPeriodo(int.Parse(index.ToString()), 2);
                this.txtPeriodo.Text = Convert.ToString(ds.Tables[0].Rows[0]["Periodo"]);
                HidPeriodo1.Value = Convert.ToString(ds.Tables[0].Rows[0]["Periodo"]);
                this.chkEstadoPeriodo.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Estado"]);
                HidEstado4.Value = Convert.ToString(ds.Tables[0].Rows[0]["Estado"]);
                this.txtPesoCPE.Text = Convert.ToString(ds.Tables[0].Rows[0]["Peso"]);
                HidPeso2.Value = Convert.ToString(ds.Tables[0].Rows[0]["Peso"]);
                this.HdPespCPE.Value = Convert.ToString(ds.Tables[0].Rows[0]["Peso"]);
                HidFactor3.Value = Convert.ToString(ds.Tables[0].Rows[0]["FactorCPE"]);
                ds.Clear();

                this.HPeriodoID.Value = index.ToString();
                this.HPeriodoNuevo.Value = "false";
                break;
            default:
                break;
        }
        segmentState = "in";

    }

    protected void ImgGuardarCalificacion_Click(object sender, ImageClickEventArgs e)
    {
        string pesoCalificacion, PisoCPE;
        Datos sv = new Datos();

        if (txtFactorCPE.Text != "0")
        {
            if (HCalificacionNUevo.Value == "true")
            {
                pesoCalificacion = txtFactorCPE.Text.Trim();
                PisoCPE = txtPisoCPE.Text.Trim();
                pesoCalificacion = pesoCalificacion.Replace(".", ",").ToString();
                PisoCPE = PisoCPE.Replace(".", ",").ToString();

                if (Convert.ToDecimal(pesoCalificacion) >= 0 && Convert.ToDecimal(pesoCalificacion) <= 1)
                {
                    sv.InCPECalificacion(this.txtCalificacion.Text, Convert.ToDecimal(pesoCalificacion), this.chkEstadoEstadoDias.Checked, Convert.ToDecimal(PisoCPE));
                    String DescripcionAudit = "Insercion datos calificación: " + Convert.ToString(this.txtCalificacion.Text) + ". Factor:" + Convert.ToDecimal(this.txtFactorCPE.Text) + ". Piso CPE:" + Convert.ToDecimal(this.txtPisoCPE.Text);
                    sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCPE.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

                    LimpiarFactorCalificacion();
                    LLenarDatosGrillaCalificacion();
                    macroState = "in";
                    Response.Write("<script>alert('Datos guardados correctamente')</script>");
                }
                else
                {
                    macroState = "in";
                    Response.Write("<script>alert('El valor del factor no puede ser menor a 0 o mayor a 1')</script>");
                }
            }
            else
            {
                pesoCalificacion = txtFactorCPE.Text.Trim();
                PisoCPE = txtPisoCPE.Text.Trim();
                pesoCalificacion = pesoCalificacion.Replace(".", ",").ToString();
                PisoCPE = PisoCPE.Replace(".", ",").ToString();
                if (Convert.ToDecimal(pesoCalificacion) >= 0 && Convert.ToDecimal(pesoCalificacion) <= 1)
                {
                    sv.UpCPECalificacion(this.txtCalificacion.Text, Convert.ToDecimal(pesoCalificacion), this.chkEstadoEstadoDias.Checked, int.Parse(this.HCalificacionID.Value), 1, Convert.ToDecimal(PisoCPE));

                    String DescripcionAudit = "Actualización datos calificación:" + Convert.ToString(this.txtCalificacion.Text) + ". Calificación anterior: " + this.HidCalificacion.Value + ". Nuevo Factor: " + Convert.ToString(this.txtFactorCPE.Text) + ". Factor anterior: " + Convert.ToDecimal(this.HidFactorCPE.Value) + ". Estado Anterior:" + HidEstadoEstadoDias.Value + ". Estado actual:" + chkEstadoEstadoDias.Checked;
                    sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCPE.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

                    LimpiarFactorCalificacion();
                    LLenarDatosGrillaCalificacion();
                    macroState = "in";
                    Response.Write("<script>alert('Datos actualizados correctamente')</script>");
                }
                else
                {
                    macroState = "in";
                    Response.Write("<script>alert('El valor del factor no puede ser menor a 0 o mayor a 1')</script>");
                }
            }
        }

    }

    protected void ImgGuardarPeriodo_Click(object sender, ImageClickEventArgs e)
    {
        Datos sv = new Datos();

        decimal ValorFactor = 0;
        string pesoPeriodo;
        int SumaTotalPesos = int.Parse(txtPesoCPE.Text), SumaTotalPesosANT = 0;

        if (chkEstadoPeriodo.Checked == false)
        {
            txtPesoCPE.Text = "0";
        }
        foreach (GridViewRow row in grvCPEPeriodo.Rows)
        {
            int IdCpEPeriodo = Convert.ToInt32(grvCPEPeriodo.DataKeys[row.RowIndex]["IdCpEPeriodo"].ToString());
            TextBox TxtPeriodoPeso = (row.FindControl("TxtPeriodoPeso") as TextBox);

            if (IdCpEPeriodo == int.Parse(this.HPeriodoID.Value))
            {
                TxtPeriodoPeso.Text = "0";
            }
            pesoPeriodo = TxtPeriodoPeso.Text.Trim();
            pesoPeriodo = pesoPeriodo.Replace(".", ",").ToString();
            SumaTotalPesos = SumaTotalPesos + int.Parse(TxtPeriodoPeso.Text);
        }

        if (HPeriodoNuevo.Value == "true")
        {
            sv.InCPEPeriodo(this.txtPeriodo.Text, int.Parse(txtPesoCPE.Text), this.chkEstadoPeriodo.Checked, 0);
            String DescripcionAudit = "Insercion datos Periodo: " + Convert.ToString(this.txtPeriodo.Text) + ". Peso:" + Convert.ToDecimal(this.txtPesoCPE.Text);
            sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCPE.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);
            LLenarDatosGrillaPeriodo();
            Response.Write("<script>alert('Datos guardados correctamente')</script>");
        }
        else
        {
            if (txtPesoCPE.Text != "")
            {
                SumaTotalPesosANT = SumaTotalPesos;
                SumaTotalPesos = SumaTotalPesos - int.Parse(this.HdPespCPE.Value);
                sv.UpCPEPeriodo(this.txtPeriodo.Text, 0, this.chkEstadoPeriodo.Checked, int.Parse(txtPesoCPE.Text), int.Parse(this.HPeriodoID.Value), 1);

                String DescripcionAudit = "Actualización datos periodo:" + Convert.ToString(this.txtPeriodo.Text) + ". Periodo anterior: " + this.HidPeriodo1.Value + ". Nuevo peso: " + Convert.ToString(this.txtPesoCPE.Text) + ". Peso anterior: " + Convert.ToDecimal(this.HidPeso2.Value) + ". Factor nuevo:" + HidFactor3.Value + ". Estado Anterior:" + HidEstado4.Value + ". Estado actual:" + chkEstadoPeriodo.Checked;
                sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCPE.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

                LLenarDatosGrillaPeriodo();
                Response.Write("<script>alert('Datos actualizados correctamente')</script>");
            }
        }

        foreach (GridViewRow row in grvCPEPeriodo.Rows)
        {
            TextBox TxtPeriodoPeso = (row.FindControl("TxtPeriodoPeso") as TextBox);
            pesoPeriodo = TxtPeriodoPeso.Text.Trim();
            pesoPeriodo = pesoPeriodo.Replace(".", ",").ToString();
            int IdCpEPeriodo = Convert.ToInt32(grvCPEPeriodo.DataKeys[row.RowIndex]["IdCpEPeriodo"].ToString());
            ValorFactor = Decimal.Parse(pesoPeriodo) / SumaTotalPesosANT;

            if (Convert.ToDecimal(pesoPeriodo) >= 0)
            {
                Datos sd = new Datos();
                sd.UpCPEPeriodo("", ValorFactor, true, int.Parse(pesoPeriodo), int.Parse(IdCpEPeriodo.ToString()), 2);
            }
        }
        LimpiarPeriodo();
        LLenarDatosGrillaPeriodo();
        segmentState = "in";

    }

    private void LimpiarFactorCalificacion()
    {
        this.txtCalificacion.Text = "";
        this.chkEstadoEstadoDias.Checked = false;
        this.txtFactorCPE.Text = "";
        this.txtPisoCPE.Text = "";
        this.HCalificacionNUevo.Value = "true";
        LinkGuardaRest.Visible = true;
        LinkGuardaRestTotal.Visible = false;
    }

    private void LimpiarPeriodo()
    {
        this.txtPeriodo.Text = "";
        this.chkEstadoPeriodo.Checked = false;
        this.HPeriodoNuevo.Value = "true";
        this.txtPesoCPE.Text = "";
        LinkActualizaPeso.Visible = true;
        LinkGuardaPeso.Visible = false;
    }

    protected void LinkGuardaRest_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grvCPECalificacion.Rows)
        {
            TextBox TxtFactorCalificacion = ((TextBox)row.FindControl("TxtFactorCalificacion"));
            TxtFactorCalificacion.Enabled = true;
        }
        LinkGuardaRestTotal.Visible = true;
        LinkGuardaRest.Visible = false;
        macroState = "in";
    }

    protected void LinkActualizaPeso_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grvCPEPeriodo.Rows)
        {
            TextBox TxtPeriodoPeso = ((TextBox)row.FindControl("TxtPeriodoPeso"));
            TxtPeriodoPeso.Enabled = true;
        }
        LinkGuardaPeso.Visible = true;
        LinkActualizaPeso.Visible = false;
        segmentState = "in";
    }

    protected void LinkGuardaRestTotal_Click(object sender, EventArgs e)
    {
        int Inactivos = 0;
        string pesoCalificacion;
        Datos sv = new Datos();

        foreach (GridViewRow row in grvCPECalificacion.Rows)
        {
            Boolean chkEstadoRespt = Boolean.Parse(((CheckBox)row.FindControl("chkEstadoRespt")).Checked.ToString());
            TextBox TxtFactorCalificacion = (row.FindControl("TxtFactorCalificacion") as TextBox);
            pesoCalificacion = TxtFactorCalificacion.Text.Trim();
            pesoCalificacion = pesoCalificacion.Replace(".", ",").ToString();
            if (chkEstadoRespt == false && Convert.ToDecimal(pesoCalificacion) != 0)
            {
                Inactivos++;
            }
        }
        if (Inactivos == 0)
        {
            foreach (GridViewRow row in grvCPECalificacion.Rows)
            {
                TextBox TxtFactorCalificacion = (row.FindControl("TxtFactorCalificacion") as TextBox);
                pesoCalificacion = TxtFactorCalificacion.Text.Trim();
                pesoCalificacion = pesoCalificacion.Replace(".", ",").ToString();

                var regex = @"\d+\,\d{4}";
                var match = Regex.Match(pesoCalificacion, regex, RegexOptions.IgnoreCase);

                if (match.Success)
                {
                    int IdCpECalificacion = Convert.ToInt32(grvCPECalificacion.DataKeys[row.RowIndex]["IdCpECalificacion"].ToString());
                    if (Convert.ToDecimal(pesoCalificacion) >= 0 && Convert.ToDecimal(pesoCalificacion) <= 1)
                    {
                        sv.UpCPECalificacion("", Convert.ToDecimal(pesoCalificacion), true, int.Parse(IdCpECalificacion.ToString()), 2, 0);
                    }
                    else
                    {
                        Response.Write("<script>alert('El valor del factor no puede ser menor a 0 o mayor a 1')</script>");
                        segmentState = "in";
                    }
                }
                else
                {
                    Response.Write("<script>alert('El valor del factor debe contener 1 entero y 4 decimales acompañados de una coma.')</script>");
                }
                TextBox Txtpeso = ((TextBox)row.FindControl("TxtFactorCalificacion"));
                Txtpeso.Enabled = false;
            }
        }
        else
        {
            Response.Write("<script>alert('A las opciones desactivadas no se le pueden asignar valores')</script>");
            segmentState = "in";
        }

        LimpiarFactorCalificacion();
        LLenarDatosGrillaCalificacion();
        LinkGuardaRestTotal.Visible = false;
        LinkGuardaRest.Visible = true;
        macroState = "in";

    }

    protected void LinkGuardaPeso_Click(object sender, EventArgs e)
    {
        int Inactivos = 0, SumaTotalPesos = 0;
        string pesoPeriodo;
        decimal ValorFactor = 0;
        Datos sv = new Datos();

        foreach (GridViewRow row in grvCPEPeriodo.Rows)
        {
            Boolean chkEstadoRespt = Boolean.Parse(((CheckBox)row.FindControl("chkEstadoRespt")).Checked.ToString());
            TextBox TxtPeriodoPeso = (row.FindControl("TxtPeriodoPeso") as TextBox);
            pesoPeriodo = TxtPeriodoPeso.Text.Trim();
            pesoPeriodo = pesoPeriodo.Replace(".", ",").ToString();
            if (chkEstadoRespt == false && Convert.ToDecimal(pesoPeriodo) != 0)
            {
                Inactivos++;
            }
            SumaTotalPesos = SumaTotalPesos + int.Parse(TxtPeriodoPeso.Text);
        }
        if (Inactivos == 0)
        {
            foreach (GridViewRow row in grvCPEPeriodo.Rows)
            {
                TextBox TxtPeriodoPeso = (row.FindControl("TxtPeriodoPeso") as TextBox);
                pesoPeriodo = TxtPeriodoPeso.Text.Trim();
                pesoPeriodo = pesoPeriodo.Replace(".", ",").ToString();
                int IdCpIPeriodo = Convert.ToInt32(grvCPEPeriodo.DataKeys[row.RowIndex]["IdCpEPeriodo"].ToString());
                ValorFactor = Decimal.Parse(pesoPeriodo) / SumaTotalPesos;

                if (Convert.ToDecimal(pesoPeriodo) >= 0)
                {
                    sv.UpCPEPeriodo("", ValorFactor, true, int.Parse(pesoPeriodo), int.Parse(IdCpIPeriodo.ToString()), 2);

                }
                else
                {
                    Response.Write("<script>alert('El Valor del peso no puede ser menor a 0 ')</script>");
                }

                TextBox TxtPeriodo = ((TextBox)row.FindControl("TxtPeriodoPeso"));
                TxtPeriodo.Enabled = false;
            }
        }
        else
        {
            Response.Write("<script>alert('Las opciones desactivadas no se le pueden asignar valores')</script>");
        }

        LimpiarPeriodo();
        LLenarDatosGrillaPeriodo();
        LinkGuardaPeso.Visible = false;
        LinkActualizaPeso.Visible = true;
        segmentState = "in";

    }

    protected void ImgLimpiarCalificacion_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarFactorCalificacion();
        macroState = "in";
    }

    protected void ImgLimpiarPeriodo_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarPeriodo();
        segmentState = "in";
    }

    protected void linkEditaPisoCPE_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grvCPECalificacion.Rows)
        {
            TextBox pisoCPE = ((TextBox)row.FindControl("textPisoCPE"));
            pisoCPE.Enabled = true;
        }
        linkGuardaPisoCPE.Visible = true;
        linkEditaPisoCPE.Visible = false;
        macroState = "in";
    }

    protected void linkGuardaPisoCPE_Click(object sender, EventArgs e)
    {
        int Inactivos = 0;
        string PisoCPE;
        Datos sv = new Datos();

        foreach (GridViewRow row in grvCPECalificacion.Rows)
        {
            Boolean chkEstadoRespt = Boolean.Parse(((CheckBox)row.FindControl("chkEstadoRespt")).Checked.ToString());
            TextBox pisoCPE = (row.FindControl("textPisoCPE") as TextBox);
            PisoCPE = pisoCPE.Text.Trim();
            PisoCPE = PisoCPE.Replace(".", ",").ToString();
            if (chkEstadoRespt == false && Convert.ToDecimal(PisoCPE) != 0)
            {
                Inactivos++;
            }
        }
        if (Inactivos == 0)
        {
            foreach (GridViewRow row in grvCPECalificacion.Rows)
            {
                TextBox TxtFactorCalificacion = (row.FindControl("textPisoCPE") as TextBox);
                PisoCPE = TxtFactorCalificacion.Text.Trim();
                PisoCPE = PisoCPE.Replace(".", ",").ToString();

                var regex = @"\d+\,\d{4}";
                var match = Regex.Match(PisoCPE, regex, RegexOptions.IgnoreCase);

                if (match.Success)
                {
                    int IdCpECalificacion = Convert.ToInt32(grvCPECalificacion.DataKeys[row.RowIndex]["IdCpECalificacion"].ToString());

                    sv.UpCPECalificacion("", 0, true, int.Parse(IdCpECalificacion.ToString()), 3, decimal.Parse(PisoCPE));
                }
                else
                {
                    Response.Write("<script>alert('El valor del factor debe contener 1 entero y 4 decimales acompañados de una coma.')</script>");
                }
                TextBox TxtCPE = ((TextBox)row.FindControl("TxtFactorCalificacion"));
                TxtCPE.Enabled = false;
            }
        }
        else
        {
            Response.Write("<script>alert('A las opciones desactivadas no se le pueden asignar valores')</script>");
        }

        LimpiarFactorCalificacion();
        LLenarDatosGrillaCalificacion();
        linkGuardaPisoCPE.Visible = false;
        linkEditaPisoCPE.Visible = true;
        macroState = "in";

    }
}