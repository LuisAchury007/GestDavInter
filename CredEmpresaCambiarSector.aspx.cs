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

public partial class CredEmpresaCambiarSector : System.Web.UI.Page
{
    string[] lista = null;
    int[] IdSector = null;

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
            LLenardatos();
        }
        llenarlista();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        GrillaLlenar();
    }

    private void LLenardatos()
    {
        Datos sv = new Datos();

        DataSet ds = new DataSet();
        ds = sv.CredSectoresCombo();

        this.cmbSectores.DataSource = ds.Tables[0].DefaultView;
        this.cmbSectores.DataTextField = "Sector";
        this.cmbSectores.DataValueField = "IdSector";
        this.cmbSectores.DataBind();

    }

    public void llenarlista()
    {
        int i = 0;
        int contador = 1;
        for (i = 0; i < this.GridEmpresas.Rows.Count; i++)
        {
            if (((CheckBox)this.GridEmpresas.Rows[i].Cells[0].Controls[1]).Checked)
            {
                Array.Resize(ref lista, contador);
                Array.Resize(ref IdSector, contador);
                DataKey MisKey = GridEmpresas.DataKeys[i];
                lista[contador - 1] = MisKey.Values["NIT"].ToString();
                IdSector[contador - 1] = int.Parse(MisKey.Values["IdSector"].ToString());
                contador += 1;
            }
        }
    }


    protected void OkButton_Click(object sender, EventArgs e)
    {
        Datos sv = new Datos();
        if (lista != null)
        {
            int i = 0;
            for (i = 0; i < lista.Length; i++)
            {
                sv.CredEmpresaSectorCambiar(lista[i], int.Parse(cmbSectores.SelectedValue), IdSector[i], Convert.ToInt32(Session["IdPais"].ToString()));
            }
        }
        else 
        {
            Response.Write("<script>alert('Debe selecionar al menos una empresa')</script>");
        }

    }


    private void GrillaLlenar()
    {
        Datos sv = new Datos();

        DataSet ds = new DataSet();
        ds = sv.BencBuscarEmpresa(this.txtBuscar.Text, 2, Convert.ToInt32(Session["IdPais"].ToString()));

        GridEmpresas.DataSource = ds.Tables[0].DefaultView;
        GridEmpresas.DataBind();

    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }
}
