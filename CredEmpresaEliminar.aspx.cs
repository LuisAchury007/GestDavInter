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

public partial class CredEmpresaEliminar : System.Web.UI.Page
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

    protected void GridEmpresas_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Modificar":
                break;
            case "Eliminar":
                string index = e.CommandArgument.ToString();

                Datos sv = new Datos();

                DataSet ds = new DataSet();
                ds = sv.BencBuscarEmpresa(Convert.ToString(index), 2, Convert.ToInt32(Session["IdPais"].ToString()));


                sv.CredEmpresaEliminar(index, Convert.ToInt32(Session["IdPais"].ToString()));


                String DescripcionAudit = "Eliminación de Empresa : " + index + " - " + Convert.ToString(ds.Tables[0].Rows[0]["RazonSocial"].ToString()) +
                       ". Usuario que realizo la eliminación:" + Convert.ToString(Session["Nombre"].ToString()) +
                       " .Fecha Eliminación: " + DateTime.Now;
                sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, "Eliminación de Empresa", Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);





                GrillaLlenar();

                break;
        }
    }
}
