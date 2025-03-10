using System;
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

public partial class CredSectorCalcula : System.Web.UI.Page
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
            GrillaLlenar();
        }

    }

    private void GrillaLlenar()
    {

        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = sv.CredSectoresPorCalcular(Convert.ToInt32(Session["IdPais"].ToString()));

        GridLista.DataSource = ds.Tables[0];
        GridLista.DataBind();

        // ds.Clear();




    }

    protected void GridLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        int index;
        Datos sv = new Datos();

        switch (e.CommandName)
        {

            case "Calcular":
                index = int.Parse(e.CommandArgument.ToString());

                sv.CredCalculaBalanceSector(index, 0, Convert.ToInt32(Session["IdPais"].ToString()));
                sv.CredCalculaBalanceSector(index, 1, Convert.ToInt32(Session["IdPais"].ToString()));

                sv.CredCalculaSector(index, 1, Convert.ToInt32(Session["IdPais"].ToString()));

                GrillaLlenar();

                Response.Write("<script>alert('Sector Calculado')</script>");

                break;
            default:

                break;
        }


    }

}
