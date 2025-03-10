using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Conf_GCModelo : System.Web.UI.Page
{
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
            LLenarDatosModelo();
            hidModeloNuevo.Value = "0";
        }
    }

    private void LLenarDatosModelo()
    {
        Datos sv = new Datos();

        DataSet ds = new DataSet();
        ds = sv.SEPucModelo("Modelo", true, 1);
        this.grvModelo.DataSource = ds.Tables[0].DefaultView;
        this.grvModelo.DataBind();
        ds.Clear();

    }

    protected void ImgGuardarDias_Click(object sender, ImageClickEventArgs e)
    {
        Datos sv = new Datos();

        Decimal pesoCPIPyme, pesoFinancieraPyme, pesoSectorPyme, pesoCualitativaPyme;
        Decimal pesototalPyme;

        pesoCPIPyme = Decimal.Parse(txtPesoCPIPyme.Text.Trim());
        pesoFinancieraPyme = Decimal.Parse(txtCFinancieraPyme.Text.Trim());
        pesoSectorPyme = Decimal.Parse(txtPesoSectorPyme.Text.Trim());
        pesoCualitativaPyme = Decimal.Parse(PesoCCualitativaPyme.Text.Trim());
        pesototalPyme = pesoCPIPyme + pesoFinancieraPyme + pesoSectorPyme + pesoCualitativaPyme;

        Decimal pesoCPIEmpre, pesoFinancieraEmpre, pesoSectorEmpre, pesoCualitativaEmpre;
        Decimal pesototalEmpre;

        pesoCPIEmpre = Decimal.Parse(txtPesoCPIEmpre.Text.Trim());
        pesoFinancieraEmpre = Decimal.Parse(txtCFinancieraEmpre.Text.Trim());
        pesoSectorEmpre = Decimal.Parse(txtPesoSectorEmpre.Text.Trim());
        pesoCualitativaEmpre = Decimal.Parse(PesoCCualitativaEmpre.Text.Trim());
        pesototalEmpre = pesoCPIEmpre + pesoFinancieraEmpre + pesoSectorEmpre + pesoCualitativaEmpre;

        Decimal pesoCPICoorpo, pesoFinancieraCoorpo, pesoSectorCoorpo, pesoCualitativaCoorpo;
        Decimal pesototalCoorpo;

        pesoCPICoorpo = Decimal.Parse(txtPesoCPICoorpo.Text.Trim());
        pesoFinancieraCoorpo = Decimal.Parse(txtCFinancieraCoorpo.Text.Trim());
        pesoSectorCoorpo = Decimal.Parse(txtPesoSectorCoorpo.Text.Trim());
        pesoCualitativaCoorpo = Decimal.Parse(PesoCCualitativaCoorpo.Text.Trim());
        pesototalCoorpo = pesoCPICoorpo + pesoFinancieraCoorpo + pesoSectorCoorpo + pesoCualitativaCoorpo;

        if (pesototalPyme == 100 && pesototalEmpre == 100 && pesototalCoorpo == 100)
        {
            if (hidModeloNuevo.Value == "0")
            {
                sv.InModelo(0, this.txtModelos.Text, int.Parse(Session["IDusuario"].ToString()), false, pesoCPIPyme / 100, pesoFinancieraPyme / 100, pesoSectorPyme / 100, pesoCualitativaPyme / 100, pesoCPIEmpre / 100, pesoFinancieraEmpre / 100, pesoSectorEmpre / 100, pesoCualitativaEmpre / 100, pesoCPICoorpo / 100, pesoFinancieraCoorpo / 100, pesoSectorCoorpo / 100, pesoCualitativaCoorpo / 100, true);

                LLenarDatosModelo();
                Response.Write("<script>alert('Datos Guardados Correctamente')</script>");
            }
            else
            {
                sv.InModelo(int.Parse(hidModeloNuevo.Value), this.txtModelos.Text, int.Parse(Session["IDusuario"].ToString()), false, pesoCPIPyme / 100, pesoFinancieraPyme / 100, pesoSectorPyme / 100, pesoCualitativaPyme / 100, pesoCPIEmpre / 100, pesoFinancieraEmpre / 100, pesoSectorEmpre / 100, pesoCualitativaEmpre / 100, pesoCPICoorpo / 100, pesoFinancieraCoorpo / 100, pesoSectorCoorpo / 100, pesoCualitativaCoorpo / 100, false);

                LLenarDatosModelo();
                Response.Write("<script>alert('Datos Actualizados Correctamente')</script>");

            }
            LimpiarCampos();
        }
        else
        {
            Response.Write("<script>alert('El peso de pyme, empresarial y coorporativo debe sumar 100 cada uno')</script>");
        }

    }

    protected void ImgLimpiarDias_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarCampos();
    }

    protected void grvModelo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        long index;
        Datos sv = new Datos();

        DataSet ds = new DataSet();
        switch (e.CommandName)
        {
            case "Editar":
                index = Convert.ToInt16(e.CommandArgument);

                ds = sv.SEPucModelo("Modelo", false, int.Parse(index.ToString()));
                this.txtModelos.Text = Convert.ToString(ds.Tables[0].Rows[0]["Modelo"]);
                this.txtPesoCPIPyme.Text = Convert.ToString(Convert.ToDouble(ds.Tables[0].Rows[0]["PesoCPIPyme"]) * 100);
                this.txtCFinancieraPyme.Text = Convert.ToString(Convert.ToDouble(ds.Tables[0].Rows[0]["PesoFinancieraPyme"]) * 100);
                this.txtPesoSectorPyme.Text = Convert.ToString(Convert.ToDouble(ds.Tables[0].Rows[0]["PesoSectorPyme"]) * 100);
                this.PesoCCualitativaPyme.Text = Convert.ToString(Convert.ToDouble(ds.Tables[0].Rows[0]["PesoCualitativaPyme"]) * 100);
                this.txtPesoCPIEmpre.Text = Convert.ToString(Convert.ToDouble(ds.Tables[0].Rows[0]["PesoCPIEmpre"]) * 100);
                this.txtCFinancieraEmpre.Text = Convert.ToString(Convert.ToDouble(ds.Tables[0].Rows[0]["PesoFinancieraEmpre"]) * 100);
                this.txtPesoSectorEmpre.Text = Convert.ToString(Convert.ToDouble(ds.Tables[0].Rows[0]["PesoSectorEmpre"]) * 100);
                this.PesoCCualitativaEmpre.Text = Convert.ToString(Convert.ToDouble(ds.Tables[0].Rows[0]["PesoCualitativaEmpre"]) * 100);
                this.txtPesoCPICoorpo.Text = Convert.ToString(Convert.ToDouble(ds.Tables[0].Rows[0]["PesoCPICoorpo"]) * 100);
                this.txtCFinancieraCoorpo.Text = Convert.ToString(Convert.ToDouble(ds.Tables[0].Rows[0]["PesoFinancieraCoorpo"]) * 100);
                this.txtPesoSectorCoorpo.Text = Convert.ToString(Convert.ToDouble(ds.Tables[0].Rows[0]["PesoSectorCoorpo"]) * 100);
                this.PesoCCualitativaCoorpo.Text = Convert.ToString(Convert.ToDouble(ds.Tables[0].Rows[0]["PesoCualitativaCoorpo"]) * 100);

                this.hidModeloNuevo.Value = ds.Tables[0].Rows[0]["IdModelo"].ToString();
                ds.Clear();
                break;
            case "Activar":
                index = Convert.ToInt16(e.CommandArgument);

                int valida = sv.CredValidarModelo(int.Parse(index.ToString()));
                LLenarDatosModelo();
                if (valida == 1)
                    Response.Write("<script>alert('Modelo Activado')</script>");
                else
                    if (valida == 0)
                        Response.Write("<script>alert('Modelo no cumple con los parametros para activar')</script>");
                    else
                        if (valida == 2)
                            Response.Write("<script>alert('Modelo Desactivado')</script>");
                        else
                            if (valida == 3)
                                Response.Write("<script>alert('Modelo No se puede desactivar por que esta asignado a uno o varios sectores')</script>");
                break;

            case "Recalcular":
                index = Convert.ToInt16(e.CommandArgument);
                sv.CredRecalcularCF(int.Parse(index.ToString()));
                LLenarDatosModelo();
                Response.Write("<script>alert('En Proceso Nocturno se calificaran todas la empresas con Este Modelo ')</script>");
                break;
            default:
                break;
        }

    }
    protected void grvModelo_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        Datos sv = new Datos();

        DataSet ds = new DataSet();
        CheckBox chkEstadoModelo = (e.Row.FindControl("chkEstadoModelo") as CheckBox);
        if (e.Row.RowIndex > 0)
        {
            int IdModelo = Convert.ToInt32(grvModelo.DataKeys[e.Row.RowIndex]["IdModelo"].ToString());
            ds = sv.SEPucModelo("Modelo", false, IdModelo);
            chkEstadoModelo.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["IdEstado"]);
        }

    }

    protected void LimpiarCampos()
    {
        hidModeloNuevo.Value = "0";
        PesoCCualitativaPyme.Text = "";
        txtPesoSectorPyme.Text = "";
        txtCFinancieraPyme.Text = "";
        txtPesoCPIPyme.Text = "";
        txtModelos.Text = "";
        PesoCCualitativaEmpre.Text = "";
        txtPesoSectorEmpre.Text = "";
        txtCFinancieraEmpre.Text = "";
        txtPesoCPIEmpre.Text = "";
        PesoCCualitativaCoorpo.Text = "";
        txtPesoSectorCoorpo.Text = "";
        txtCFinancieraCoorpo.Text = "";
        txtPesoCPICoorpo.Text = "";
    }
}