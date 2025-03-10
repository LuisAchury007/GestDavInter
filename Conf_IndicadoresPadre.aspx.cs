using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Conf_IndicadoresPadre : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IDusuario"] == null)
        {
            Response.Redirect("Salir.aspx");
        }

        if (Page.IsPostBack == false)
        {
            LLenarDatos();
            HidIndicadorNuevo.Value = "0";
        }
    }

    public void LLenarDatos()
    {
        Datos sv = new Datos();

        DataSet dts = new DataSet();
        DataView vista = new DataView();

        dts = sv.SEPucModelo("Modelo", true, 1);
        dts.Tables[0].Rows.Add("-1", "Seleccione>>");
        vista = dts.Tables[0].DefaultView;
        vista.Sort = "IdModelo ASC";

        this.CmbModelo.DataSource = vista;
        this.CmbModelo.DataTextField = "Modelo";
        this.CmbModelo.DataValueField = "IdModelo";
        this.CmbModelo.DataBind();
        dts.Clear();

        dts = sv.CredIndicadores(1);
        dts.Tables[0].Rows.Add("-1", "Seleccione>>");
        vista = dts.Tables[0].DefaultView;
        vista.Sort = "IdIndicador ASC";

        this.CmbIndicadores.DataSource = vista;
        this.CmbIndicadores.DataTextField = "Diminutivo";
        this.CmbIndicadores.DataValueField = "IdIndicador";
        this.CmbIndicadores.DataBind();
        dts.Clear();

    }

    private void LLenarDatosIndicadores()
    {
        Datos sv = new Datos();

        DataSet ds = new DataSet();
        ds = sv.SeMDIndicadores(0, int.Parse(CmbModelo.SelectedValue), 1, 0);
        this.grvIndicadoresPadre.DataSource = ds.Tables[0].DefaultView;
        this.grvIndicadoresPadre.DataBind();
        ds.Clear();

    }

    protected void ImgGuardarDias_Click(object sender, ImageClickEventArgs e)
    {
        DataSet ds = new DataSet();
        Datos sv = new Datos();

        int Idmodelo = 0, Contador = 0;
        Decimal Peso, PesoParcial, PesoParcialAnio, totalValor = 0, SumaTotalParcial = 0, SumaTotalParcialAnio = 0;
        string Mensaje = "";
        Peso = Decimal.Parse(txtPeso.Text);
        Peso = Peso / 100;
        PesoParcial = Decimal.Parse(txtPesoParcial.Text);
        PesoParcial = PesoParcial / 100;
        PesoParcialAnio = Decimal.Parse(txtPesoParcialAnio.Text);
        PesoParcialAnio = PesoParcialAnio / 100;
        if (CmbIndicadores.SelectedValue != "-1" && CmbModelo.SelectedValue != "-1")
        {
            if (HidIndicadorNuevo.Value == "0")
            {
                foreach (GridViewRow row in grvIndicadoresPadre.Rows)
                {
                    Idmodelo = Convert.ToInt32(grvIndicadoresPadre.DataKeys[row.RowIndex]["IdModelo"].ToString());
                    Contador++;
                }
                if (Contador > 0)
                {
                    ds = sv.SeMDIndicadores(0, Idmodelo, 4, 0);
                    totalValor = Decimal.Parse(ds.Tables[0].Rows[0]["TotalPesos"].ToString());
                    SumaTotalParcial = Decimal.Parse(ds.Tables[0].Rows[0]["TotalPesosParcial"].ToString());
                    SumaTotalParcialAnio = Decimal.Parse(ds.Tables[0].Rows[0]["TotalPesosParcialAnio"].ToString());
                }
                totalValor = totalValor + Peso;
                SumaTotalParcial = SumaTotalParcial + PesoParcial;
                SumaTotalParcialAnio = SumaTotalParcialAnio + PesoParcialAnio;

                if (totalValor > 1 && SumaTotalParcial > 1)
                {
                    Peso = 0;
                    PesoParcial = 0;
                    Mensaje = "Tanto el peso como el peso parcial se guardaron en 0 , redistribuya los pesos de los indicadores para poder modificarlos";
                }
                else if (totalValor > 1)
                {
                    Peso = 0;
                    Mensaje = "El peso se guardo en 0 , redistribuya los pesos de los indicadores para poder modificarlos";

                }
                else if (SumaTotalParcial > 1)
                {
                    PesoParcial = 0;
                    Mensaje = "El peso parcial se guardo en 0 , redistribuya los pesos de los indicadores para poder modificarlos";
                }
                else if (SumaTotalParcialAnio > 1)
                {
                    PesoParcialAnio = 0;
                    Mensaje = "El peso parcial Año se guardo en 0 , redistribuya los pesos de los indicadores para poder modificarlos";
                }

                sv.InMDIndicadores(int.Parse(CmbModelo.SelectedValue), txtNomIndicador.Text, 0, "select @valor = DaviUser.F_ValorIndicador(" + CmbIndicadores.SelectedValue + ", @NIT, @Anio)", "select @valor = DaviUser.F_ValorIndicadorParcial(" + CmbIndicadores.SelectedValue + ", @NIT, @Anio)", Peso, PesoParcial, 0, 0, true, true, chkVeto.Checked, Decimal.Parse(txtValorVeto.Text), CmbVetoComparador.SelectedValue, int.Parse(txtVetoDefault.Text), chkAfectaFinal.Checked, "select @valor = DaviUser.F_ValorIndicadorParcial(" + CmbIndicadores.SelectedValue + ", @NIT, @Anio)", PesoParcialAnio, ChkDesendente.Checked, int.Parse(this.txtOrden.Text), int.Parse(CmbIndicadores.SelectedValue), 0, 0, 0);
                Response.Write("<script>alert('Los datos se guardaron correctamente," + Mensaje + "')</script>");
                LimpiarCampos();

                LLenarDatosIndicadores();
            }
            else
            {
                totalValor = Decimal.Parse(HidSumaTotal.Value) + Peso;
                SumaTotalParcial = Decimal.Parse(HidSumaTotalParcial.Value) + PesoParcial;
                SumaTotalParcialAnio = Decimal.Parse(HidSumaTotalParcialAnio.Value) + PesoParcialAnio;

                if (totalValor > 1 || SumaTotalParcial > 1 || SumaTotalParcialAnio > 1)
                {
                    Response.Write("<script>alert('No puede Ingresar el valor del peso ya que superaria la suma total de todos los Indicadores')</script>");
                }
                else
                {
                    sv.InMDIndicadores(int.Parse(CmbModelo.SelectedValue), txtNomIndicador.Text, int.Parse(HidIndicadorNuevo.Value), "select @valor = DaviUser.F_ValorIndicador(" + CmbIndicadores.SelectedValue + ", @NIT, @Anio)", "select @valor = DaviUser.F_ValorIndicadorParcial(" + CmbIndicadores.SelectedValue + ", @NIT, @Anio)", Peso, PesoParcial, 0, 0, ChkEstado.Checked, false, chkVeto.Checked, Decimal.Parse(txtValorVeto.Text), CmbVetoComparador.SelectedValue, int.Parse(txtVetoDefault.Text), chkAfectaFinal.Checked, "select @valor = DaviUser.F_ValorIndicadorParcial(" + CmbIndicadores.SelectedValue + ", @NIT, @Anio)", PesoParcialAnio, ChkDesendente.Checked, int.Parse(this.txtOrden.Text), int.Parse(CmbIndicadores.SelectedValue), 0, 0, 0);
                    LLenarDatosIndicadores();
                    LimpiarCampos();
                    Response.Write("<script>alert('Datos Actualizados Correctamente')</script>");
                }
            }
        }
        else
        {
            Response.Write("<script>alert('Debe Seleccionar información de modelo o Indicador')</script>");
        }

    }

    protected void LimpiarCampos()
    {
        CmbIndicadores.SelectedValue = "-1";
        txtPeso.Text = "";
        txtPesoParcial.Text = "";
        txtPesoParcialAnio.Text = "";
        ChkEstado.Checked = false;
        chkVeto.Checked = false;
        chkAfectaFinal.Checked = false;
        ChkDesendente.Checked = false;
        txtValorVeto.Text = "";
        CmbVetoComparador.SelectedValue = "";
        txtVetoDefault.Text = "";
        HidIndicadorNuevo.Value = "0";
        HidSumaTotal.Value = "0";
        txtNomIndicador.Text = "";
        txtOrden.Text = "";
    }

    protected void CmbModelo_SelectedIndexChanged(object sender, EventArgs e)
    {
        LLenarDatosIndicadores();
    }

    protected void grvIndicadoresPadre_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Datos sv = new Datos();

            DataSet ds = new DataSet();
            CheckBox chkDesc = (e.Row.FindControl("chkDesc") as CheckBox);
            CheckBox chkVeto = (e.Row.FindControl("chkVeto") as CheckBox);
            CheckBox chkActivo = (e.Row.FindControl("chkActivo") as CheckBox);
            CheckBox chkAfectaFinal = (e.Row.FindControl("chkAfectaFinal") as CheckBox);

            int IdIndicador = Convert.ToInt32(grvIndicadoresPadre.DataKeys[e.Row.RowIndex]["IdIndicador"].ToString());
            ds = sv.SeMDIndicadores(0, 0, 3, IdIndicador);
            chkDesc.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Descendente"]);
            chkVeto.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Veto"]);
            chkActivo.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Activo"]);
            chkAfectaFinal.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["AfectaFinal"]);

        }
    }

    protected void grvIndicadoresPadre_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index;
        Datos sv = new Datos();

        DataSet ds = new DataSet();
        DataSet dts = new DataSet();
        int Idmodelo = 0;
        string Mensaje;
        Decimal Peso, PesoParcial, PesoParcialAnio, SumaTotal = 0, SumaTotalParcial = 0, SumaTotalParcialAnio = 0;
        //long ValorVeto;
        switch (e.CommandName)
        {
            case "Editar":
                foreach (GridViewRow row in grvIndicadoresPadre.Rows)
                {
                    Idmodelo = Convert.ToInt32(grvIndicadoresPadre.DataKeys[row.RowIndex]["IdModelo"].ToString());
                }

                ds = sv.SeMDIndicadores(0, Idmodelo, 4, 0);
                SumaTotal = Decimal.Parse(ds.Tables[0].Rows[0]["TotalPesos"].ToString());
                SumaTotalParcial = Decimal.Parse(ds.Tables[0].Rows[0]["TotalPesosParcial"].ToString());
                SumaTotalParcialAnio = Decimal.Parse(ds.Tables[0].Rows[0]["TotalPesosParcialAnio"].ToString());

                index = Convert.ToInt32(e.CommandArgument);
                ds = sv.SeMDIndicadores(0, 0, 3, index);
                Peso = Decimal.Parse(ds.Tables[0].Rows[0]["Peso"].ToString());
                SumaTotal = SumaTotal - Peso;
                Peso = Peso * 100;
                txtPeso.Text = Peso.ToString("N0");
                PesoParcial = Decimal.Parse(ds.Tables[0].Rows[0]["PesoParcial"].ToString());
                SumaTotalParcial = SumaTotalParcial - PesoParcial;
                PesoParcial = PesoParcial * 100;
                txtPesoParcial.Text = PesoParcial.ToString("N0");
                PesoParcialAnio = Decimal.Parse(ds.Tables[0].Rows[0]["PesoParcialAnio"].ToString());
                SumaTotalParcialAnio = SumaTotalParcialAnio - PesoParcialAnio;
                PesoParcialAnio = PesoParcialAnio * 100;
                txtPesoParcialAnio.Text = PesoParcialAnio.ToString("N0");
                txtValorVeto.Text = ds.Tables[0].Rows[0]["VetoValor"].ToString();
                txtVetoDefault.Text = ds.Tables[0].Rows[0]["VetoDefault"].ToString();
                txtOrden.Text = ds.Tables[0].Rows[0]["Orden"].ToString();

                txtNomIndicador.Text = Convert.ToString(ds.Tables[0].Rows[0]["Indicador"]);
                CmbVetoComparador.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["VetoComparador"]);
                ChkEstado.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Activo"]);
                chkVeto.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Veto"]);
                ChkDesendente.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Descendente"]);
                chkAfectaFinal.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["AfectaFinal"]);

                CmbIndicadores.SelectedValue = ds.Tables[0].Rows[0]["CodIndicador"].ToString();
                ds.Clear();
                this.HidIndicadorNuevo.Value = index.ToString();
                HidSumaTotal.Value = Convert.ToString(SumaTotal);
                HidSumaTotalParcial.Value = Convert.ToString(SumaTotalParcial);
                HidSumaTotalParcialAnio.Value = Convert.ToString(SumaTotalParcialAnio);
                break;
            case "Eliminar":
                index = Convert.ToInt32(e.CommandArgument);
                int Valor = sv.DelMDIndicadores(0, index);
                if (Valor == 0)
                {
                    Mensaje = "Operación Eliminada";
                }
                else
                {
                    Mensaje = "No se pudo eliminar este indicador , tiene indicadores hijos relacionados";
                }
                LLenarDatosIndicadores();
                LimpiarCampos();
                Response.Write("<script>alert('" + Mensaje + "')</script>");
                break;
            default:
                break;
        }

    }

    protected void ImgLimpiarDias_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarCampos();
    }
}