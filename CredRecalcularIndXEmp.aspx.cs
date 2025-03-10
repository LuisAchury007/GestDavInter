using System;
using System.Activities.Expressions;
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

public partial class CredRecalcularIndXEmp : System.Web.UI.Page
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
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        GrillaLlenar();
    }

    private void GrillaLlenar()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = sv.BencBuscarEmpresa(this.txtBuscar.Text, 2, Convert.ToInt32(Session["IdPais"].ToString()));
        GridEmpresas.DataSource = ds.Tables[0].DefaultView;
        GridEmpresas.DataBind();

    }
    protected void GridEmpresas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string Nit;
        Datos sv = new Datos();
        DataSet ds = new DataSet();
        Boolean Resultado = false;
        int valorSeleccionado = 0;
        int ultimosDosDigitos = 0;
        if (CmbAnio.SelectedValue.ToString() != "")
        {
             valorSeleccionado = int.Parse(CmbAnio.SelectedValue);
             ultimosDosDigitos = valorSeleccionado % 100;
        }

        switch (e.CommandName)
        {
            case "Recalcular":
                Nit = e.CommandArgument.ToString();
                if (CmbAnioPeriodo.SelectedValue != "-1")
                { 
                    
                        if (CmbAnioPeriodo.SelectedValue != "1")
                        {
                            if (sv.CredSeVerificarExistenciaBalances(Nit, int.Parse(CmbAnio.SelectedValue), Convert.ToInt32(Session["IdPais"].ToString())) == true)
                            {
                                ds = sv.CredValidarPeriodo(Convert.ToInt32(Session["IdPais"].ToString()), Nit, Convert.ToInt32(CmbAnio.SelectedValue));

                                if (ds.Tables[0].Rows[0]["ExisteRegistro"].ToString() == "False")
                                {
                                    sv.IngresaNitAnio(Nit, int.Parse(CmbAnio.SelectedValue), false, true, Convert.ToInt32(Session["IdPais"].ToString()), ultimosDosDigitos, 3);
                                    Resultado = sv.CredCalculaEmpresaAnioParcial(Nit, 1, int.Parse(CmbAnio.SelectedValue), Convert.ToInt32(Session["IdPais"].ToString()));
                                }
                                else
                                {
                                    Resultado = sv.CredCalculaEmpresaAnioParcial(Nit, 1, int.Parse(CmbAnio.SelectedValue), Convert.ToInt32(Session["IdPais"].ToString()));
                                }
                                Response.Write("<script>alert('Preceso terminado')</script>");
                            }
                            else
                            {
                                Response.Write("<script>alert('la empresa no cuenta con cifras para el periodo seleccionado')</script>");
                            }
                        }
                        else
                        {
                            sv.CredCalculaEmpresa(Nit, 1, Convert.ToInt32(Session["IdPais"].ToString()));
                            Response.Write("<script>alert('Preceso terminado')</script>");
                        }
 
                }
                else
                {
                    Response.Write("<script>alert('Seleccione un periodo valido')</script>");
                }    
            break;

            default:

            break;
        }
    }

    protected void CmbAnioPeriodo_SelectedIndexChanged(object sender, EventArgs e)
    {

        DataSet Ds = new DataSet();
        Datos sv = new Datos();
        int Seleccion = int.Parse(CmbAnioPeriodo.SelectedValue);
        Label1.Visible = false;
        CmbAnio.Visible = false;

        if (Seleccion != -1)
        {
            if (Seleccion == 2)
            {
                Label1.Visible = true;
                CmbAnio.Visible = true;
                Ds = sv.GCredAniosPeriodos(Convert.ToInt32(Session["IdPais"].ToString()), Seleccion);
                CmbAnio.DataSource = Ds.Tables[0].DefaultView;
                CmbAnio.DataTextField = "Anio";
                CmbAnio.DataValueField = "Anio";
                CmbAnio.DataBind();
                Ds.Clear();
            }
        }

    }
}