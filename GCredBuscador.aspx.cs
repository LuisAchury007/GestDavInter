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
using Encoder = Microsoft.Security.Application.Encoder;

public partial class GCredBuscador : System.Web.UI.Page
{
    string[] lista;
    int[] listaSector;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IDusuario"] == null)
        {
            Response.Redirect("Salir.aspx");
        }


        if (Page.IsPostBack == false)
        {

            buscarGestor();
        }
        //else
        //{
        //    llenarlista();
        //}

    }

    //public void llenarlista()
    //{
    //    int i = 0;
    //    int contador = 1;
    //    for (i = 0; i < this.GridEmpresas.Rows.Count; i++)
    //    {
    //        //En la posición 13 es en donde se encuentra el control Check.
    //        if (((CheckBox)this.GridEmpresas.Rows[i].Cells[0].Controls[1]).Checked)
    //        {
    //            Array.Resize(ref lista, contador);
    //            Array.Resize(ref listaSector, contador);
    //            DataKey MisKey = GridEmpresas.DataKeys[i];
    //            lista[contador - 1] = MisKey.Values["NIT"].ToString();
    //            listaSector[contador - 1] = int.Parse(MisKey.Values["IdSector"].ToString());

    //            // lista[contador - 1] = double.Parse(GridEmpresas.DataKeys[i].Value.ToString()); //double.Parse(this.GridEmpresas.Rows[i].Cells[1].Text);
    //            contador += 1;
    //        }
    //    }

    //    contador = 1;



    //}

    private void buscarGestor()
    {


        Datos sv = new Datos();
        DataSet ds = new DataSet();

     /*   ds = sv.BencBuscarEmpresa(Encoder.HtmlEncode(Request.QueryString["Buscar"]), 1, Convert.ToInt32(Session["IdPais"].ToString()));
        GridEmpresas.DataSource = ds.Tables[0].DefaultView;
        GridEmpresas.DataBind();
        ds.Clear();*/

        ds = sv.BencBuscarEmpresa(Encoder.HtmlEncode(Request.QueryString["Buscar"]), 2, Convert.ToInt32(Session["IdPais"].ToString()));
        GridEmpresaCom.DataSource = ds.Tables[0].DefaultView;
        GridEmpresaCom.DataBind();


    }

    //protected void OkButton_Ejecutivo(object sender, ImageClickEventArgs e)
    //{

    //    Datos sv = new Datos();
    //    DataSet ds = new DataSet();

    //    this.ModalPopupExtender2.Hide();
    //    Response.Write("<script>alert('Empresas Exportadas a Su Gestor De Credito')</script>");


    //}

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        if ((lista != null))
        {

            for (int i = 0; i < lista.Length; i++)
            {

                sv.UpEmpresaCliente(lista[i].ToString(), Convert.ToInt32(Session["IdPais"].ToString()));



            }
        }


        this.ModalPopupExtender2.Hide();
        Response.Write("<script>alert('Empresas añadidas correctamente')</script>");

    }
}
