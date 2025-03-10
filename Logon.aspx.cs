using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Logon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnIniciarSesion_Click(object sender, EventArgs e)
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();
        Funciones fun = new Funciones();
        string varIp;

        var username = aes.Aes128Ctr.DecryptA(xmjgl.Value);
        var password = aes.Aes128Ctr.DecryptA(tzwqk.Value);

        //var username = ET3202.Text;
        //var password = Y123CV05.Text;

        if (username == "keyError" && password == "keyError")
        {
            Response.Write("<script>alert('Usuario y/o clave no Validos')</script>");
        }
        else
        {
            ds = sv.ValidarUsuario(username.Trim(), fun.ToEncriptar(password.Trim()));
           //  ds = sv.ValidarUsuario(username.Trim(), password.Trim());

            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["IDusuario"] = ds.Tables[0].Rows[0]["IdUsuario"];
                Session["IdPerfil"] = ds.Tables[0].Rows[0]["IdPerfil"];
                Session["Usuario"] = ds.Tables[0].Rows[0]["Usuario"];
                Session["PaginaInicio"] = ds.Tables[0].Rows[0]["PaginaInicio"];
                Session["VerInfoFinanciera"] = ds.Tables[0].Rows[0]["VerInfoFinanciera"];
                Session["VerRib"] = ds.Tables[0].Rows[0]["VerRib"];
                Session["VerAsignados"] = ds.Tables[0].Rows[0]["VerAsignados"];
                Session["CrearEmpresaGE"] = ds.Tables[0].Rows[0]["CrearEmpresaGE"];
                Session["Nombre"] = ds.Tables[0].Rows[0]["Nombre"];

                varIp = Request.ServerVariables["REMOTE_ADDR"];
                sv.AuditoriaInseta(int.Parse(Session["IDusuario"].ToString()), varIp, true);

                sv.UsuarioIntentos(int.Parse(Session["IDusuario"].ToString()));

                System.Web.Security.FormsAuthentication.SetAuthCookie(username.Trim(), true);

                /* DAVID ALZATE CAMBIO PARA SEGURIDAD EN COOKIES */
                if (Response.Cookies.Count > 0)
                {
                    foreach (string s in Response.Cookies.AllKeys)
                    {
                        if (s == FormsAuthentication.FormsCookieName || s.ToLower() == "asp.net_sessionid")//"asp.net_sessionid".Equals(s, StringComparison.InvariantCultureIgnoreCase) || "s".Equals(s, StringComparison.InvariantCultureIgnoreCase))
                        {
                            Response.Cookies[s].Secure = true;
                        }
                    }
                }

                if ((int.Parse(ds.Tables[0].Rows[0]["Dias"].ToString()) > 29) | (Boolean.Parse(ds.Tables[0].Rows[0]["CambiarObligatorio"].ToString())))
                {
                    Response.Redirect("ComCambioClave.aspx?Obligatorio=1");
                }
                else
                {
                    ds.Clear();
                    ds = sv.UsuarioPais(int.Parse(Session["IDusuario"].ToString()));

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        Response.Write("<script>alert('Usuario Sin Pais')</script>");
                        
                    }
                    else
                    {
                        string Cadena;
                        Cadena = ds.Tables[0].Rows[0]["ID"].ToString();
                        char delimiterDestinos = '|';
                        string[] arr;
                        arr = Cadena.Split(delimiterDestinos);
                       

                        if (ds.Tables[0].Rows.Count == 1)
                        {
                            Session["IdPais"] = Convert.ToInt32(arr[0]) ;
                            Session["Divisa"] = Convert.ToInt32(arr[1]);
                            Session["Pais"] = ds.Tables[0].Rows[0]["Pais"];

                            Response.Redirect(Session["PaginaInicio"].ToString());
                            
                        }
                        else
                        {
                            this.cmbPais.DataSource = ds.Tables[0].DefaultView;
                            this.cmbPais.DataTextField = "Pais";
                            this.cmbPais.DataValueField = "ID";
                            this.cmbPais.DataBind();
                            this.ModalPopupExtender.Show();

                        }


                        

                    }
                }
            }
            else
            {
                varIp = Request.ServerVariables["REMOTE_ADDR"];
                sv.IngresosFallido(username.Trim(), varIp);
                ds.Clear();

                ds = sv.ValidarUsuarioBloqueado(username.Trim());

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (int.Parse(ds.Tables[0].Rows[0]["IdEstUsuario"].ToString()) == 2)
                    {
                        Response.Write("<script>alert('Usuario Bloqueado')</script>");
                    }
                    else if (int.Parse(ds.Tables[0].Rows[0]["IdEstUsuario"].ToString()) == 3)
                    {
                        Response.Write("<script>alert('Usuario Inactivo')</script>");
                    }
                    else if (int.Parse(ds.Tables[0].Rows[0]["IdEstUsuario"].ToString()) == 4)
                    {
                        Response.Write("<script>alert('Usuario Retirado')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Usuario y Clave No Valida')</script>");
                }
            }
        }

        ds.Clear();
    }


    protected void OkButton_Click(object sender, EventArgs e)
    {
        // Global.IdMarcroSectorBD = int.Parse(cmbMacroSector.SelectedValue);
        // System.Web.Security.FormsAuthentication.SetAuthCookie(this.txtUsuario.Text.Trim(), true);

        string Cadena;
        Cadena = cmbPais.SelectedValue;
        char delimiterDestinos = '|';
        string[] arr;
        arr = Cadena.Split(delimiterDestinos);

        Session["IdPais"] = Convert.ToInt32(arr[0]);
        Session["Divisa"] = Convert.ToInt32(arr[1]);
        Session["Pais"] = cmbPais.SelectedItem.Text;


       Response.Redirect(Session["PaginaInicio"].ToString());

    }
}
