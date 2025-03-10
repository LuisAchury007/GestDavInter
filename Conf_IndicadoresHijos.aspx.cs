using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Encoder = Microsoft.Security.Application.Encoder;

public partial class Conf_IndicadoresHijos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IDusuario"] == null)
        {
            Response.Redirect("Salir.aspx");
        }

        if (Page.IsPostBack == false)
        {
            LLenarDatosIndicadores();
            HidIndicadorNuevo.Value = "0";
        }
    }

    private void LLenarDatosIndicadores()
    {
        Datos sv = new Datos();

        DataSet ds = new DataSet();
        ds = sv.SeMDIndicadores(int.Parse(Encoder.HtmlEncode(Request.QueryString["IdIndicador"])), 0, 2, 0);
        this.grvIndicadoresHijos.DataSource = ds.Tables[0].DefaultView;
        this.grvIndicadoresHijos.DataBind();
        ds.Clear();

        ds = sv.SeMDIndicadores(0, 0, 3, int.Parse(Encoder.HtmlEncode(Request.QueryString["IdIndicador"])));
        HidIdIndicador.Value = ds.Tables[0].Rows[0]["CodIndicador"].ToString();
        ds.Clear();

    }

    protected void CmbIndicadorPadre_SelectedIndexChanged(object sender, EventArgs e)
    {
        LLenarDatosIndicadores();
    }

    protected void grvIndicadoresHijos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Datos sv = new Datos();

            DataSet ds = new DataSet();
            CheckBox chkActivo = (e.Row.FindControl("chkActivo") as CheckBox);
            int IdIndicador = Convert.ToInt32(grvIndicadoresHijos.DataKeys[e.Row.RowIndex]["IdIndicador"].ToString());
            ds = sv.SeMDIndicadores(0, 0, 3, IdIndicador);
            chkActivo.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Activo"]);

        }
    }

    protected void grvIndicadoresHijos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index;
        Datos sv = new Datos();

        DataSet ds = new DataSet();
        DataSet dts = new DataSet();
        int Idmodelo = 0;
        Decimal Peso, PesoParcial, PesoParcialAnio, SumaTotal = 0, SumaTotalParcial = 0, SumaTotalParcialAnio = 0;
        switch (e.CommandName)
        {
            case "Editar":
                foreach (GridViewRow row in grvIndicadoresHijos.Rows)
                {
                    Idmodelo = Convert.ToInt32(grvIndicadoresHijos.DataKeys[row.RowIndex]["IdModelo"].ToString());
                }
                ds = sv.SeMDIndicadores(int.Parse(Encoder.HtmlEncode(Request.QueryString["IdIndicador"])), Idmodelo, 4, 0);
                SumaTotal = Decimal.Parse(ds.Tables[0].Rows[0]["TotalPesos"].ToString());
                SumaTotalParcial = Decimal.Parse(ds.Tables[0].Rows[0]["TotalPesosParcial"].ToString());
                SumaTotalParcialAnio = Decimal.Parse(ds.Tables[0].Rows[0]["TotalPesosParcialAnio"].ToString());

                index = Convert.ToInt16(e.CommandArgument);
                ds = sv.SeMDIndicadores(0, 0, 3, index);
                Peso = Decimal.Parse(ds.Tables[0].Rows[0]["Peso"].ToString());
                SumaTotal = SumaTotal - Peso;
                Peso = Peso * 100;
                txtPeso.Text = Peso.ToString("N0");
                txtNomIndicador.Text = Convert.ToString(ds.Tables[0].Rows[0]["Indicador"]);
                PesoParcial = Decimal.Parse(ds.Tables[0].Rows[0]["PesoParcial"].ToString());
                SumaTotalParcial = SumaTotalParcial - PesoParcial;
                PesoParcial = PesoParcial * 100;
                txtPesoParcial.Text = PesoParcial.ToString("N0");
                PesoParcialAnio = Decimal.Parse(ds.Tables[0].Rows[0]["PesoParcialAnio"].ToString());
                SumaTotalParcialAnio = SumaTotalParcialAnio - PesoParcialAnio;
                PesoParcialAnio = PesoParcialAnio * 100;
                txtPesoParcialAnio.Text = PesoParcialAnio.ToString("N0");
                txtDesTecho.Text = ds.Tables[0].Rows[0]["DesviacionTecho"].ToString();
                txtDesPiso.Text = ds.Tables[0].Rows[0]["DesviacionPiso"].ToString();
                txtOrden.Text = ds.Tables[0].Rows[0]["Orden"].ToString();
                TxtMantener.Text = ds.Tables[0].Rows[0]["Mantener"].ToString();
                CmbIndicadores.SelectedValue = ds.Tables[0].Rows[0]["TipoIndicador"].ToString();

                if (CmbIndicadores.SelectedValue == "3")
                {
                    txtValorFijo.Visible = true;
                    txtValorFijo.Text = ds.Tables[0].Rows[0]["ValorFijo"].ToString();
                }
                else
                {
                    txtValorFijo.Visible = false;
                    txtValorFijo.Text = "0";
                }

                this.ChkEstado.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Activo"]);
                ds.Clear();
                this.HidIndicadorNuevo.Value = index.ToString();
                HidSumaTotal.Value = Convert.ToString(SumaTotal);
                HidSumaTotalParcial.Value = Convert.ToString(SumaTotalParcial);
                HidSumaTotalParcialAnual.Value = Convert.ToString(SumaTotalParcialAnio);
                break;
            case "Eliminar":
                index = Convert.ToInt32(e.CommandArgument);
                int Valor = sv.DelMDIndicadores(int.Parse(Encoder.HtmlEncode(Request.QueryString["IdIndicador"])), index);
                LLenarDatosIndicadores();
                LimpiarCampos();
                Response.Write("<script>alert('Operación Eliminada')</script>");
                break;
            default:
                break;
        }

    }

    protected void ImgGuardarDias_Click(object sender, ImageClickEventArgs e)
    {
        DataSet ds = new DataSet();
        Datos sv = new Datos();

        int Idmodelo = 0, Contador = 0;
        Decimal Peso, PesoParcial, PesoParcialAnio, totalValor = 0, SumaTotalParcial = 0, SumaTotalParcialAnio = 0;
        string tabla = "", Atributos = "", tablaAnual = "", AtributosAnual = "", tablaParcial = "", AtributosParcial = "", Mensaje = "";
        Peso = Decimal.Parse(txtPeso.Text);
        Peso = Peso / 100;
        PesoParcial = Decimal.Parse(txtPesoParcial.Text);
        PesoParcial = PesoParcial / 100;
        PesoParcialAnio = Decimal.Parse(txtPesoParcialAnio.Text);
        PesoParcialAnio = PesoParcialAnio / 100;
        if (CmbIndicadores.SelectedValue != "-1")
        {
            int TipoSeleccion = int.Parse(CmbIndicadores.SelectedValue);
            switch (TipoSeleccion)
            {
                case 1:
                    tabla = "select @valor2 = DaviUser.F_ValorIndicadorSector(";
                    tablaParcial = "select @valor2 = DaviUser.F_ValorIndicadorSector(";
                    tablaAnual = "select @valor2 = DaviUser.F_ValorIndicadorSector(";
                    Atributos = HidIdIndicador.Value + ", @NIT,@Anio)";
                    AtributosParcial = HidIdIndicador.Value + ", @NIT,SUBSTRING (CAST(@Anio AS varchar(6)) ,1 ,4) - 1)";
                    AtributosAnual = HidIdIndicador.Value + ", @NIT,SUBSTRING (CAST(@Anio AS varchar(6)) ,1 ,4) - 1)";
                    break;
                case 2:
                    tabla = "select @valor2 = DaviUser.F_ValorIndicador(";
                    tablaParcial = "select @valor2 = DaviUser.F_ValorIndicadorParcialHijo(";
                    tablaAnual = "select @valor2 = DaviUser.F_ValorIndicador(";
                    Atributos = HidIdIndicador.Value + ", @NIT, @Anio-1)";
                    AtributosParcial = HidIdIndicador.Value + ", @NIT, @Anio)";
                    AtributosAnual = HidIdIndicador.Value + ", @NIT, SUBSTRING(CAST(@Anio AS varchar(6)) ,1 ,4) - 1)";
                    break;
                case 3:
                    tabla = "select @valor2 =";
                    Atributos = txtValorFijo.Text.Replace(",", ".");
                    tablaParcial = "select @valor2 =";
                    AtributosParcial = txtValorFijo.Text.Replace(",", ".");
                    tablaAnual = "select @valor2 =";
                    AtributosAnual = txtValorFijo.Text.Replace(",", ".");
                    break;
                default:
                    break;
            }
            if (HidIndicadorNuevo.Value == "0")
            {
                foreach (GridViewRow row in grvIndicadoresHijos.Rows)
                {
                    Idmodelo = Convert.ToInt32(grvIndicadoresHijos.DataKeys[row.RowIndex]["IdModelo"].ToString());
                    Contador++;
                }
                if (Contador > 0)
                {
                    ds = sv.SeMDIndicadores(int.Parse(Encoder.HtmlEncode(Request.QueryString["IdIndicador"])), Idmodelo, 4, 0);
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

                sv.InMDIndicadores(int.Parse(Encoder.HtmlEncode(Request.QueryString["IdModelo"])), txtNomIndicador.Text, int.Parse(Encoder.HtmlEncode(Request.QueryString["IdIndicador"])), tabla + Atributos, tablaParcial + AtributosParcial, Peso, PesoParcial, Decimal.Parse(txtDesTecho.Text), Decimal.Parse(txtDesPiso.Text), true, true, false, 0, "", 0, false, tablaAnual + AtributosAnual, PesoParcialAnio, false, int.Parse(this.txtOrden.Text), 0, int.Parse(CmbIndicadores.SelectedValue), float.Parse(txtValorFijo.Text), decimal.Parse(TxtMantener.Text));
                LLenarDatosIndicadores();
                LimpiarCampos();
                Response.Write("<script>alert('Los datos se guardaron correctamente," + Mensaje + "')</script>");
            }
            else
            {
                totalValor = Decimal.Parse(HidSumaTotal.Value) + Peso;
                SumaTotalParcial = Decimal.Parse(HidSumaTotalParcial.Value) + PesoParcial;
                SumaTotalParcialAnio = Decimal.Parse(HidSumaTotalParcialAnual.Value) + PesoParcialAnio;
                if (totalValor > 1 || SumaTotalParcial > 1 || SumaTotalParcialAnio > 1)
                {
                    Response.Write("<script>alert('No puede Ingresar el valor del peso ya que superaria la suma total de todos los Indicadores')</script>");
                }
                else
                {
                    sv.InMDIndicadores(int.Parse(Encoder.HtmlEncode(Request.QueryString["IdModelo"])), txtNomIndicador.Text, int.Parse(HidIndicadorNuevo.Value), tabla + Atributos, tablaParcial + AtributosParcial, Peso, PesoParcial, Decimal.Parse(txtDesTecho.Text), Decimal.Parse(txtDesPiso.Text), ChkEstado.Checked, false, false, 0, "", 0, false, tablaAnual + AtributosAnual, PesoParcialAnio, false, int.Parse(this.txtOrden.Text), 0, int.Parse(CmbIndicadores.SelectedValue), float.Parse(txtValorFijo.Text), decimal.Parse(TxtMantener.Text));
                    LLenarDatosIndicadores();
                    LimpiarCampos();
                    Response.Write("<script>alert('Datos Actualizados Correctamente')</script>");
                }
            }
        }
        else
        {
            Response.Write("<script>alert('Debe Seleccionar una opción de registro')</script>");
        }

    }

    protected void ImgLimpiarDias_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarCampos();
    }

    protected void LimpiarCampos()
    {
        txtPeso.Text = "";
        txtPesoParcial.Text = "";
        txtDesTecho.Text = "";
        txtDesPiso.Text = "";
        ChkEstado.Checked = false;
        HidIndicadorNuevo.Value = "0";
        HidSumaTotal.Value = "0";
        HidSumaTotalParcial.Value = "0";
        HidSumaTotalParcialAnual.Value = "0";
        txtValorFijo.Text = "0";
        txtValorFijo.Visible = false;
        CmbIndicadores.SelectedValue = "-1";
        txtNomIndicador.Text = "";
        txtPesoParcialAnio.Text = "";
        txtOrden.Text = "";
        TxtMantener.Text = "";
    }

    protected void CmbIndicadores_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CmbIndicadores.SelectedValue == "3")
        {
            txtValorFijo.Visible = true;
        }
        else
        {
            txtValorFijo.Visible = false;
            txtValorFijo.Text = "0";
        }
    }
}