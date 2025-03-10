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


public partial class CredEliminarFinal : System.Web.UI.Page
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
        ds = sv.BencBuscarEmpresa(this.txtBuscar.Text, 5, Convert.ToInt32(Session["IdPais"].ToString()));

        GridEmpresas.DataSource = ds.Tables[0].DefaultView;
        GridEmpresas.DataBind();

    }

    protected void GridLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Datos sv = new Datos();

        DataSet ds = new DataSet();

        switch (e.CommandName)
        {
            case "Eliminar":
                string index = e.CommandArgument.ToString();
                char delimiterDestinos = '#';
                string[] arr;

                arr = index.Split(delimiterDestinos);
                sv.EliminarBalanceAnio(arr[0].ToString(), int.Parse(arr[1].ToString()), Convert.ToInt32(Session["IdPais"].ToString()));
                sv.EliminarIndicadorXAnio(arr[0].ToString(), int.Parse(arr[1].ToString()), Convert.ToInt32(Session["IdPais"].ToString()));
                GrillaLlenar();
                break;
            default:
                break;
        }

    }
}