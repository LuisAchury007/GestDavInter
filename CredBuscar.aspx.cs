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

public partial class CredBuscar : System.Web.UI.Page
{
    DataSet Dscompleto;
    DataSet Dscompleto2;
    double[] lista;
    DataSet dsSec = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            buscar();
        }
        else
        {
            llenarlista();
            Dscompleto = (DataSet)ViewState["DscompletoState"];
            GridEmpresas.DataSource = Dscompleto.Tables[0];
            GridEmpresas.DataBind();
        }
    }

    private void buscar()
    {
        Datos sv = new Datos();

        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();

        ds = sv.BencBuscarEmpresa(Encoder.HtmlEncode(Request.QueryString["Buscar"]), 1, Convert.ToInt32(Session["IdPais"].ToString()));
        GridEmpresas.DataSource = ds.Tables[0].DefaultView;
        GridEmpresas.DataBind();

        Dscompleto = new DataSet();
        Dscompleto = ds;

        ds2 = sv.BencBuscarAccionista(Encoder.HtmlEncode(Request.QueryString["Buscar"]), Convert.ToInt32(Session["IdPais"].ToString()));
        GridAccionistas.DataSource = ds2.Tables[0].DefaultView;
        GridAccionistas.DataBind();

        Dscompleto2 = new DataSet();
        Dscompleto2 = ds2;

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
                lista[contador - 1] = long.Parse(GridEmpresas.DataKeys[i].Value.ToString());
                contador += 1;
            }
        }

        for (i = 0; i < this.GridAccionistas.Rows.Count; i++)
        {
            if (((CheckBox)this.GridAccionistas.Rows[i].Cells[0].Controls[1]).Checked)
            {
                Array.Resize(ref lista, contador);
                lista[contador - 1] = long.Parse(GridAccionistas.DataKeys[i].Value.ToString());
                contador += 1;
            }
        }
    }

    protected void Page_PreRender(object sender, System.EventArgs e)
    {
        this.ViewState.Add("DscompletoState", Dscompleto);
        this.ViewState.Add("DscompletoState", Dscompleto2);
    }

    protected void OkButton_Click(object sender, EventArgs e)
    {
        Datos sv = new Datos();

        if (this.MisSectores.CheckedNodes.Count > 0)
        {
            if ((lista != null))
            {
                foreach (TreeNode item in MisSectores.CheckedNodes)
                {
                    for (int i = 0; i < lista.Length; i++)
                    {
                        sv.CredCopiaEmpSector(lista[i].ToString(), int.Parse(item.Value));
                    }

                    Datos sv2 = new Datos();
                    sv.CredCalculaBalanceSector(int.Parse(item.Value), 0, Convert.ToInt32(Session["IdPais"].ToString()));
                    sv.CredCalculaBalanceSector(int.Parse(item.Value), 1, Convert.ToInt32(Session["IdPais"].ToString()));
                    sv2.CredCalculaSector(int.Parse(item.Value), 1, Convert.ToInt32(Session["IdPais"].ToString()));
                }
            }

            this.ModalPopupExtender.Hide();
            Response.Write("<script>alert('Empresas Copiadas)</script>");
        }
        else
        {
            this.ModalPopupExtender.Hide();
            Response.Write("<script>alert('Debe Seleccionar Un Sector')</script>");
        }

    }

    private TreeNode CrearNodosHijo(int indicePadre, TreeNode nodePadre)
    {

        DataView dataViewHijos = null;
        // Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
        dataViewHijos = new DataView(dsSec.Tables[0]);
        dataViewHijos.RowFilter = dsSec.Tables[0].Columns["SectorPadre"].ColumnName + " = " + indicePadre.ToString();
        TreeNode nuevoNodo = new TreeNode();
        //TreeNode nuevoDevolver = new TreeNode();
        // Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
        foreach (DataRowView dataRowCurrent in dataViewHijos)
        {
            nuevoNodo = new TreeNode(dataRowCurrent["Sector"].ToString(), dataRowCurrent["IdSector"].ToString());
            nuevoNodo.SelectAction = TreeNodeSelectAction.Expand;
            nuevoNodo.ChildNodes.Add(CrearNodosHijo(Int32.Parse(dataRowCurrent["IdSector"].ToString()), nuevoNodo));
            nodePadre.ChildNodes.Add(nuevoNodo);
        }

        return nodePadre;
    }


}
