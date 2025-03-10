using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

public partial class Conf_CPI : System.Web.UI.Page
{

    public string segmentState = "collapse";
    public string lvlRiskState = "collapse";
    public string macroState = "collapse";
    public string lvlRiskState2 = "collapse";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IDusuario"] == null)
        {
            Response.Redirect("Salir.aspx");
        }

        if (Page.IsPostBack == false)
        {
            HidIdRegla.Value = "0";
            HPeriodoID.Value = "0";
            LLenarDatosGrillaMora();
            LLenarDatosGrillaPeriodo();
            LLenarDatosGrillaRegla();
        }
    }

    private void LLenarDatosGrillaMora()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = sv.SeCPIDiasMora(0, 1);
        this.grvCPIDiasMora.DataSource = ds.Tables[0].DefaultView;
        this.grvCPIDiasMora.DataBind();
        ds.Clear();

    }

    private void LLenarDatosGrillaPeriodo()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = sv.SeCPIPeriodo(0, 3);
        this.grvCCIPeriodo.DataSource = ds.Tables[0].DefaultView;
        this.grvCCIPeriodo.DataBind();
        ds.Clear();

    }

    private void LLenarDatosGrillaRegla()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = sv.SeCPIRegla(0, 1);
        this.grvRegla.DataSource = ds.Tables[0].DefaultView;
        this.grvRegla.DataBind();
        ds.Clear();

    }



    protected void grvCPIDiasMora_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Datos sv = new Datos();
            DataSet ds = new DataSet();

            TextBox TxtFactorMora = (e.Row.FindControl("TxtFactorMora") as TextBox);
            CheckBox chkEstadoRespt = (e.Row.FindControl("chkEstadoRespt") as CheckBox);

            int IdRespuesta = Convert.ToInt32(grvCPIDiasMora.DataKeys[e.Row.RowIndex]["IdCpIDiasMora"].ToString());
            ds = sv.SeCPIDiasMora(IdRespuesta, 2);
            TxtFactorMora.Text = Convert.ToString(ds.Tables[0].Rows[0]["Factor"]);
            chkEstadoRespt.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Estado"]);

        }
    }

    protected void grvCCIPeriodo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Datos sv = new Datos();
            DataSet ds = new DataSet();

            TextBox TxtPeriodoPeso = (e.Row.FindControl("TxtPeriodoPeso") as TextBox);
            CheckBox chkEstadoRespt = (e.Row.FindControl("chkEstadoRespt") as CheckBox);

            int IdRespuesta = Convert.ToInt32(grvCCIPeriodo.DataKeys[e.Row.RowIndex]["IdCpIPeriodo"].ToString());
            ds = sv.SeCPIPeriodo(IdRespuesta, 2);
            TxtPeriodoPeso.Text = Convert.ToString(ds.Tables[0].Rows[0]["Peso"]);
            chkEstadoRespt.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Estado"]);

        }
    }

    protected void grvCPIDiasMora_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        long index;
        Datos sv = new Datos();

        switch (e.CommandName)
        {
            case "Editar":
                index = Convert.ToInt16(e.CommandArgument);
                DataSet ds = new DataSet();
                string factor;
                ds = sv.SeCPIDiasMora(int.Parse(index.ToString()), 2);
                this.txtAlturaMora.Text = Convert.ToString(ds.Tables[0].Rows[0]["AlturaMora"]);
                HidAlturaMora.Value = Convert.ToString(ds.Tables[0].Rows[0]["AlturaMora"]);
                this.txtValturaMora.Text = Convert.ToString(ds.Tables[0].Rows[0]["VAlturaMora"]);
                HidValturaMora.Value = Convert.ToString(ds.Tables[0].Rows[0]["VAlturaMora"]);
                this.chkEstadoEstadoDias.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Estado"]);
                HidEstadoDias.Value = Convert.ToString(ds.Tables[0].Rows[0]["Estado"]);
                factor = Convert.ToString(ds.Tables[0].Rows[0]["Factor"]);
                HidFactorCPI.Value = Convert.ToString(ds.Tables[0].Rows[0]["Factor"]);
                this.txtFactorCPI.Text = factor;
                ds.Clear();


                this.HDiasMoraID.Value = index.ToString();
                this.HDiasMOraNUevo.Value = "false";


                break;
            default:
                break;
        }
        macroState = "in";

    }

    protected void grvCCIPeriodo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        long index;
        Datos sv = new Datos();

        switch (e.CommandName)
        {
            case "Editar":
                index = Convert.ToInt16(e.CommandArgument);
                DataSet ds = new DataSet();
                ds = sv.SeCPIPeriodo(int.Parse(index.ToString()), 2);
                this.txtPeriodo.Text = Convert.ToString(ds.Tables[0].Rows[0]["Periodo"]);
                HidPeriodo.Value = Convert.ToString(ds.Tables[0].Rows[0]["Periodo"]);
                this.chkEstadoPeriodo.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Estado"]);
                this.txtPesoCPI.Text = Convert.ToString(ds.Tables[0].Rows[0]["Peso"]);
                this.HdPespCPI.Value = Convert.ToString(ds.Tables[0].Rows[0]["Peso"]);
                HidPesoCPI2.Value = Convert.ToString(ds.Tables[0].Rows[0]["Peso"]);
                HidEstadoCPI2.Value = Convert.ToString(ds.Tables[0].Rows[0]["Estado"]);
                HidFactorCPI2.Value = Convert.ToString(ds.Tables[0].Rows[0]["FactorCPI"]);
                ds.Clear();

                this.HPeriodoID.Value = index.ToString();
                this.HPeriodoNuevo.Value = "false";
                break;
            default:
                break;
        }
        segmentState = "in";

    }

    protected void ImgGuardarDias_Click(object sender, ImageClickEventArgs e)
    {
        string pesoMora;
        Datos sv = new Datos();

        if (txtValturaMora.Text != "0")
        {
            if (HDiasMOraNUevo.Value == "true")
            {
                pesoMora = txtFactorCPI.Text.Trim();
                pesoMora = pesoMora.Replace(".", ",").ToString();
                if (Convert.ToDecimal(pesoMora) >= 0 && Convert.ToDecimal(pesoMora) <= 3)
                {
                    sv.InCPIDiasMora(this.txtAlturaMora.Text, int.Parse(this.txtValturaMora.Text), this.chkEstadoEstadoDias.Checked, Convert.ToDecimal(pesoMora));

                    String DescripcionAudit = "Inserción factor dias de mora: " + Convert.ToString(this.txtAlturaMora.Text) + ". Valor altura mora:" + Convert.ToDecimal(this.txtValturaMora.Text) + ".Factor:" + Convert.ToDecimal(this.txtFactorCPI.Text) + ".Estado:" + chkEstadoEstadoDias.Checked;
                    sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCPI.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

                    LimpiarFactorDias();
                    LLenarDatosGrillaMora();

                    Response.Write("<script>alert('Datos guardados correctamente')</script>");
                }
                else
                {
                    Response.Write("<script>alert('El valor del Factor no puede ser menor a 1 o mayor a 3')</script>");
                }
            }
            else
            {
                pesoMora = txtFactorCPI.Text.Trim();
                pesoMora = pesoMora.Replace(".", ",").ToString();
                if (Convert.ToDecimal(pesoMora) >= 0 && Convert.ToDecimal(pesoMora) <= 3)
                {
                    sv.UpCPIDiasMora(this.txtAlturaMora.Text, Convert.ToDecimal(pesoMora), this.chkEstadoEstadoDias.Checked, int.Parse(txtValturaMora.Text), int.Parse(this.HDiasMoraID.Value), 1);


                    String DescripcionAudit = "Actualización factor dias de mora:" + Convert.ToString(this.txtAlturaMora.Text) + ". Factor dias mora anterior: " + this.HidAlturaMora.Value + ". Nuevo Valor: " + Convert.ToString(this.txtValturaMora.Text) + ". Valor anterior: " + Convert.ToDecimal(this.HidValturaMora.Value) + ". Factor CPI anterior:" +
                        Convert.ToDecimal(this.HidFactorCPI.Value) + ". Factor CPI Actual:" + Convert.ToDecimal(this.txtFactorCPI.Text) + ". Estado Anterior:" + HidEstadoDias.Value + ". Estado actual:" + chkEstadoEstadoDias.Checked;
                    sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCPI.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

                    LimpiarFactorDias();
                    LLenarDatosGrillaMora();
                    macroState = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
                    Response.Write("<script>alert('Datos actualizados correctamente')</script>");
                }
                else
                {
                    Response.Write("<script>alert('El valor del factor no puede ser menor a 1 o mayor a 3')</script>");
                }
            }
        }
        else
        {
            Response.Write("<script>alert('Valor de altura mora no puede ser 0')</script>");
        }

    }

    protected void ImgGuardarPeriodo_Click(object sender, ImageClickEventArgs e)
    {
        string pesoPeriodo;
        decimal ValorFactor = 0;
        int SumaTotalPesos = int.Parse(txtPesoCPI.Text), SumatotalPesoANt = 0;
        Datos sv = new Datos();

        if (chkEstadoPeriodo.Checked == false)
        {
            txtPesoCPI.Text = "0";
        }

        foreach (GridViewRow row in grvCCIPeriodo.Rows)
        {
            int IdCpIPeriodo = Convert.ToInt32(grvCCIPeriodo.DataKeys[row.RowIndex]["IdCpIPeriodo"].ToString());
            TextBox TxtPeriodoPeso = (row.FindControl("TxtPeriodoPeso") as TextBox);
            if (IdCpIPeriodo == int.Parse(this.HPeriodoID.Value))
            {
                TxtPeriodoPeso.Text = "0";
            }
            pesoPeriodo = TxtPeriodoPeso.Text.Trim();
            pesoPeriodo = pesoPeriodo.Replace(".", ",").ToString();
            SumaTotalPesos = SumaTotalPesos + int.Parse(TxtPeriodoPeso.Text);
        }

        if (HPeriodoNuevo.Value == "true")
        {
            if (txtPesoCPI.Text != "")
            {
                sv.InCPIPeriodo(this.txtPeriodo.Text, int.Parse(txtPesoCPI.Text), this.chkEstadoPeriodo.Checked, 0);

                String DescripcionAudit = "Insercion de Periodo: " + Convert.ToString(this.txtPeriodo.Text) + ". Peso CPI:" + Convert.ToDecimal(this.txtPesoCPI.Text) + ". Factor: " + HidFactorCPI2.Value + ". Estado:" + chkEstadoPeriodo.Checked;
                sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCPI.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);


                LLenarDatosGrillaPeriodo();
                Response.Write("<script>alert('Datos guardados correctamente')</script>");
            }
        }
        else
        {
            if (txtPesoCPI.Text != "")
            {
                SumatotalPesoANt = SumaTotalPesos;
                SumaTotalPesos = SumaTotalPesos - int.Parse(this.HdPespCPI.Value);
                sv.UpCPIPeriodo(this.txtPeriodo.Text, 0, this.chkEstadoPeriodo.Checked, int.Parse(txtPesoCPI.Text), int.Parse(this.HPeriodoID.Value), 1);

                String DescripcionAudit = "Actualización de periodo:" + Convert.ToString(this.txtPeriodo.Text) + ". Periodo anterior: " + this.HidPeriodo.Value + ". Nuevo peso CPI: " + Convert.ToString(this.txtPesoCPI.Text) + ". Peso CPI anterior: " + Convert.ToDecimal(this.HidPesoCPI2.Value) + ". Factor anterior:" +
                       Convert.ToDecimal(this.HidFactorCPI2.Value) + ". Factor Actual:" + Convert.ToDecimal(this.HidFactorCPI2.Value) + ". Estado Anterior:" + HidEstadoCPI2.Value + ". Estado actual:" + chkEstadoPeriodo.Checked;
                sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCPI.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

                LLenarDatosGrillaPeriodo();
                Response.Write("<script>alert('Datos actualizados correctamente')</script>");
            }
        }
        foreach (GridViewRow row in grvCCIPeriodo.Rows)
        {
            TextBox TxtPeriodoPeso = (row.FindControl("TxtPeriodoPeso") as TextBox);
            pesoPeriodo = TxtPeriodoPeso.Text.Trim();
            pesoPeriodo = pesoPeriodo.Replace(".", ",").ToString();
            int IdCpIPeriodo = Convert.ToInt32(grvCCIPeriodo.DataKeys[row.RowIndex]["IdCpIPeriodo"].ToString());
            ValorFactor = Decimal.Parse(pesoPeriodo) / SumatotalPesoANt;

            if (Convert.ToDecimal(pesoPeriodo) >= 0)
            {
                Datos sd = new Datos();
                sd.UpCPIPeriodo("", ValorFactor, true, int.Parse(pesoPeriodo), int.Parse(IdCpIPeriodo.ToString()), 2);
            }
        }
        LimpiarPeriodo();
        LLenarDatosGrillaPeriodo();
        segmentState = "in";

    }

    private void LimpiarFactorDias()
    {
        this.txtAlturaMora.Text = "";
        this.txtValturaMora.Text = "";
        txtFactorCPI.Text = "";
        this.chkEstadoEstadoDias.Checked = false;
        this.HDiasMOraNUevo.Value = "true";
        LinkGuardaRest.Visible = true;
        LinkGuardaRestTotal.Visible = false;
    }

    private void LimpiarPeriodo()
    {
        this.txtPeriodo.Text = "";
        this.txtPesoCPI.Text = "";
        this.chkEstadoPeriodo.Checked = false;
        this.HPeriodoNuevo.Value = "true";
        LinkActualizaPeso.Visible = true;
        LinkGuardaPeso.Visible = false;
    }

    private void LimpiarCPIRegla()
    {
        this.txtCalSARC.Text = "";
        this.txtCalfVector.Text = "";
        this.txtPisoCPI.Text = "";
        this.HidIdRegla.Value = "0";
        this.HidPisoCPI.Value = "0";
        this.txtVarableCfinal.Text = "";
        ChkEstadoRegla.Checked = false;
    }



    protected void LinkGuardaRest_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grvCPIDiasMora.Rows)
        {
            TextBox TxtFactorMora = ((TextBox)row.FindControl("TxtFactorMora"));
            TxtFactorMora.Enabled = true;
        }
        LinkGuardaRestTotal.Visible = true;
        LinkGuardaRest.Visible = false;

        macroState = "in";
    }

    protected void LinkActualizaPeso_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grvCCIPeriodo.Rows)
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
        string pesoMora;
        Datos sv = new Datos();

        foreach (GridViewRow row in grvCPIDiasMora.Rows)
        {
            Boolean chkEstadoRespt = Boolean.Parse(((CheckBox)row.FindControl("chkEstadoRespt")).Checked.ToString());
            TextBox TxtFactorMora = (row.FindControl("TxtFactorMora") as TextBox);
            pesoMora = TxtFactorMora.Text.Trim();

            pesoMora = pesoMora.Replace(".", ",").ToString();
            if (chkEstadoRespt == false && Convert.ToDecimal(pesoMora) != 0)
            {
                Inactivos++;
            }
        }

        if (Inactivos == 0)
        {
            foreach (GridViewRow row in grvCPIDiasMora.Rows)
            {
                TextBox TxtFactorMora = (row.FindControl("TxtFactorMora") as TextBox);
                pesoMora = TxtFactorMora.Text.Trim();
                pesoMora = pesoMora.Replace(".", ",").ToString();

                var regex = @"\d+\,\d{4}";
                var match = Regex.Match(pesoMora, regex, RegexOptions.IgnoreCase);

                if (match.Success)
                {
                    int IdCpIDiasMora = Convert.ToInt32(grvCPIDiasMora.DataKeys[row.RowIndex]["IdCpIDiasMora"].ToString());
                    if (Convert.ToDecimal(pesoMora) >= 1 && Convert.ToDecimal(pesoMora) <= 3)
                    {
                        sv.UpCPIDiasMora("", Convert.ToDecimal(pesoMora), true, 0, int.Parse(IdCpIDiasMora.ToString()), 2);
                    }
                    else
                    {
                        Response.Write("<script>alert('El valor del factor no puede ser menor a 1 o mayor a 3')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('El valor del factor debe contener 1 entero y 4 decimales acompañados de una coma.')</script>");
                }
                TextBox Txtpeso = ((TextBox)row.FindControl("TxtFactorMora"));
                Txtpeso.Enabled = false;
            }
        }
        else
        {
            Response.Write("<script>alert('Las opciones desactivadas no se le pueden asignar valores')</script>");
        }
        LimpiarFactorDias();
        LLenarDatosGrillaMora();
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

        foreach (GridViewRow row in grvCCIPeriodo.Rows)
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
            foreach (GridViewRow row in grvCCIPeriodo.Rows)
            {
                TextBox TxtPeriodoPeso = (row.FindControl("TxtPeriodoPeso") as TextBox);
                pesoPeriodo = TxtPeriodoPeso.Text.Trim();
                pesoPeriodo = pesoPeriodo.Replace(".", ",").ToString();
                int IdCpIPeriodo = Convert.ToInt32(grvCCIPeriodo.DataKeys[row.RowIndex]["IdCpIPeriodo"].ToString());
                ValorFactor = Decimal.Parse(pesoPeriodo) / SumaTotalPesos;

                if (Convert.ToDecimal(pesoPeriodo) >= 0)
                {
                    sv.UpCPIPeriodo("", ValorFactor, true, int.Parse(pesoPeriodo), int.Parse(IdCpIPeriodo.ToString()), 2);
                }
                else
                {
                    Response.Write("<script>alert('El valor del peso no puede ser menor a 0 ')</script>");
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

    protected void ImgLimpiarDias_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarFactorDias();
        LLenarDatosGrillaMora();
        macroState = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
    }

    protected void ImgLimpiarPeriodo_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarPeriodo();
        LLenarDatosGrillaPeriodo();
        segmentState = "in";
    }

    protected void grvRegla_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        long index;
        Datos sv = new Datos();
        switch (e.CommandName)
        {
            case "Editar":
                index = Convert.ToInt16(e.CommandArgument);
                DataSet ds = new DataSet();
                ds = sv.SeCPIRegla(int.Parse(index.ToString()), 2);
                this.txtCalSARC.Text = Convert.ToString(ds.Tables[0].Rows[0]["Letra"]);
                HidCalSARC.Value = Convert.ToString(ds.Tables[0].Rows[0]["Letra"]);
                // this.txtDiasMora.Text = Convert.ToString(ds.Tables[0].Rows[0]["DiasMora"]);
                this.txtCalfVector.Text = Convert.ToString(ds.Tables[0].Rows[0]["Calificacion"]);
                this.txtVarableCfinal.Text = Convert.ToString(ds.Tables[0].Rows[0]["Valor"]);
                HidCalfVector.Value = Convert.ToString(ds.Tables[0].Rows[0]["Calificacion"]);
                ChkEstadoRegla.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Estado"]);
                this.HidIdRegla.Value = Convert.ToString(index);
                this.txtPisoCPI.Text = Convert.ToString(ds.Tables[0].Rows[0]["PisoCPI"]);
                this.HidPisoCPI.Value = Convert.ToString(ds.Tables[0].Rows[0]["PisoCPI"]);
                ds.Clear();

                this.HPeriodoID.Value = index.ToString();
                break;
            default:
                break;
        }
        lvlRiskState = "in";

    }

    protected void btnDelRegla_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarCPIRegla();
        lvlRiskState = "in";
    }

    protected void btnGuardaRegla_Click(object sender, ImageClickEventArgs e)
    {
        Datos sv = new Datos();

        if (HidIdRegla.Value == "0")
        {
            sv.InCPIRegla(this.txtCalSARC.Text, 0, decimal.Parse(txtCalfVector.Text), true, 0, decimal.Parse(txtVarableCfinal.Text), ChkEstadoRegla.Checked, decimal.Parse(txtPisoCPI.Text));

            String DescripcionAudit = "Insercion regla especial para calificacion: " + Convert.ToString(this.txtCalSARC.Text) + ". Calificacion del vector:" + Convert.ToDecimal(this.txtCalfVector.Text) + ". Piso CPI:" + Convert.ToDecimal(this.txtCalfVector.Text);
            sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCPI.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

            LLenarDatosGrillaRegla();
            Response.Write("<script>alert('Datos guardados correctamente')</script>");
        }
        else
        {
            sv.InCPIRegla(this.txtCalSARC.Text, 0, decimal.Parse(txtCalfVector.Text), false, int.Parse(HidIdRegla.Value), decimal.Parse(txtVarableCfinal.Text), ChkEstadoRegla.Checked, decimal.Parse(txtPisoCPI.Text));

            String DescripcionAudit = "Actualizacion regla especial para calificacion: " + Convert.ToString(this.txtCalSARC.Text) + ". Valor Anterior: " + Convert.ToString(HidCalSARC.Value) + ". Calificacion del vector:" + Convert.ToDecimal(this.txtCalfVector.Text) + ". Calificacion anterior del vector :" + Convert.ToDecimal(this.HidCalfVector.Value) + ". Piso CPI:" + Convert.ToDecimal(this.txtCalfVector.Text) + ". Piso CPI Anterior:" + Convert.ToDecimal(this.HidPisoCPI.Value);
            sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCPI.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

            LLenarDatosGrillaRegla();
            Response.Write("<script>alert('Datos actualizados correctamente')</script>");
        }
        LimpiarCPIRegla();
        lvlRiskState = "in";

    }







    protected void grvRegla_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Datos sv = new Datos();

            DataSet ds = new DataSet();
            CheckBox chkEstadoRegla = (e.Row.FindControl("chkEstadoRegla") as CheckBox);

            int IdRegla = Convert.ToInt32(grvRegla.DataKeys[e.Row.RowIndex]["IdReglaCpI"].ToString());
            ds = sv.SeCPIRegla(IdRegla, 2);
            chkEstadoRegla.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Estado"]);

        }
    }


}