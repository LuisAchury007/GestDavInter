using System;
using System.Collections;
using System.Collections.Generic;
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

public partial class Usuarios : System.Web.UI.Page
{
    DataSet Dscompleto;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            LLenardatos();
            GrillaLlenar();
            HNuevo.Value = "1";
        }
        else
        {
            Dscompleto = (DataSet)ViewState["DscompletoState"];
            // GridLista.DataSource = Dscompleto.Tables[0].DefaultView;
            // GridLista.DataBind();
        }
    }

    private void LLenardatos()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();
        DataView vista = new DataView();

        ds = sv.Perfiles();
        CmbPerfil.DataSource = ds.Tables[0].DefaultView;
        CmbPerfil.DataTextField = "Perfil";
        CmbPerfil.DataValueField = "IdPerfil";
        CmbPerfil.DataBind();

        ds.Clear();

        ds = sv.EstadoUsuario();
        CmbEstUsuario.DataSource = ds.Tables[0].DefaultView;
        CmbEstUsuario.DataTextField = "Estado";
        CmbEstUsuario.DataValueField = "IdEstado";
        CmbEstUsuario.DataBind();

        ds.Clear();

        ds = sv.PaisesLista();
        vista = ds.Tables[0].DefaultView;
        vista.Sort = "Pais ASC";
        ddlPaisesCliente.DataSource = vista;
        ddlPaisesCliente.DataTextField = "Pais";
        ddlPaisesCliente.DataValueField = "IdPais";
        ddlPaisesCliente.DataBind();

        ds.Clear();
    }

    private void GrillaLlenar()
    {
        Datos sv = new Datos();

        DataSet ds = new DataSet();
        ds = sv.UsuariosLista();

        GridLista.DataSource = ds.Tables[0];
        GridLista.DataBind();
        Dscompleto = new DataSet();
        Dscompleto = ds;
        GridLista.Columns[14].Visible = false;
        // ds.Clear();

    }

    protected void Page_PreRender(object sender, System.EventArgs e)
    {
        ViewState.Add("DscompletoState", Dscompleto);
    }
        
    private void buscarUsuario()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        LimpiarText();

        string Usuario = txtBuscarUsuario.Text;

        if (Usuario == "")
        {
            Response.Write("<script>alert('Debe Ingresar Identificación, nombre o usuario')</script>");
        }
        else
        {
            ds = sv.BencBuscarUsuario(Usuario);

            if (ds.Tables[0].Rows.Count > 0)
            {
                GridLista.DataSource = ds.Tables[0].DefaultView;
                GridLista.DataBind();
                GridLista.Columns[0].Visible = true;
                Dscompleto = ds;
            }
            else
            {
                Response.Write("<script>alert('No se encontro Usuario')</script>");
            }
        }
    }

    protected void btnBuscarUsuario_Click(object sender, EventArgs e)
    {
        buscarUsuario();
    }

    protected void ImageButton19_Click(object sender, ImageClickEventArgs e)
    {
        Funciones fun = new Funciones();
        Datos sv = new Datos();
        Boolean Bloqueo = false;
        DateTime fecha = DateTime.Now;
        List<int> CantPaises = new List<int>();
        int Existe = 0;
        int IdNewUser = 0;
        if (CmbEstUsuario.SelectedValue != "1")
        {
            Bloqueo = true;
        }

        foreach (System.Web.UI.WebControls.ListItem item in ddlPaisesCliente.Items)
        {
            if (item.Selected)
            {
                CantPaises.Add(int.Parse(item.Value));
            }
        }

        if (HNuevo.Value == "1" && CantPaises.Count > 0)
        {
            if (ValidaPass(txtClave.Text.Trim()))
            {
                Existe = sv.SeExisteUsuario(TxtUsuario.Text, TxtIdentificacion.Text);

                if (Existe == 0)
                {
                    IdNewUser = sv.UsuarioIngresar(TxtUsuario.Text, fun.ToEncriptar(txtClave.Text), TxtNombre.Text, TxtCorreo.Text, TxtCargo.Text, TxtTelefono.Text, TxtCelular.Text, TxtExtension.Text, int.Parse(CmbPerfil.SelectedValue), Bloqueo, TxtIdentificacion.Text, int.Parse(CmbEstUsuario.SelectedValue));

                    String DescripcionAudit = "Administración de usuarios-- Nueva creación de usuario:  " + Convert.ToString(TxtNombre.Text) + ". Estado del usuario  " + CmbEstUsuario.SelectedItem.Text + " .Usuario que realizo la creación: " + Convert.ToString(Session["Usuario"]) + " .Fecha: " + Convert.ToString(fecha);
                    sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, "Administracion de usuarios", Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

                    foreach (System.Web.UI.WebControls.ListItem item in ddlPaisesCliente.Items)
                    {
                        if (item.Selected)
                        {
                            sv.InUsuarioPais(IdNewUser, int.Parse(item.Value));
                        }
                    }

                    LimpiarText();
                    GrillaLlenar();

                    Response.Write("<script>alert('Usuario creado')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Ya existe un usuario registrado con este usuario o documento por favor verificar')</script>");
                }
            }
        }
        else if (HNuevo.Value == "0" && CantPaises.Count > 0)
        {
            sv.UsuarioActualiza(int.Parse(HIdUsuario.Value), TxtUsuario.Text, TxtNombre.Text, TxtCorreo.Text, TxtCargo.Text, TxtTelefono.Text, TxtCelular.Text, TxtExtension.Text, int.Parse(CmbPerfil.SelectedValue), Bloqueo, TxtIdentificacion.Text, int.Parse(CmbEstUsuario.SelectedValue));
            
            foreach (System.Web.UI.WebControls.ListItem item in ddlPaisesCliente.Items)
            {
                if (item.Selected)
                {
                    sv.InUsuarioPais(int.Parse(HIdUsuario.Value), int.Parse(item.Value));
                }
            }

            String DescripcionAudit = "Administración de usuarios-- Actualización de usuario  " + Convert.ToString(TxtNombre.Text) + " . Estado del usuario  " + CmbEstUsuario.SelectedItem.Text + " .Usuario que realizo la Actualización: " + Convert.ToString(Session["Usuario"]) + " .Fecha: " + Convert.ToString(fecha);
            sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, "Administracion de usuarios", Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

            LimpiarText();
            GrillaLlenar();

            Response.Write("<script>alert('Usuario actualizado')</script>");
        }
        else if (HNuevo.Value == "2")
        {
            if (ValidaPass(txtClave.Text.Trim()))
            {
                sv.UsuarioResetPass(int.Parse(HIdUsuario.Value), TxtUsuario.Text, TxtNombre.Text, TxtCorreo.Text, TxtCargo.Text, TxtTelefono.Text, TxtCelular.Text, TxtExtension.Text, int.Parse(CmbPerfil.SelectedValue), Bloqueo, TxtIdentificacion.Text, fun.ToEncriptar(txtClave.Text), int.Parse(CmbEstUsuario.SelectedValue));

                LimpiarText();
                GrillaLlenar();

                Response.Write("<script>alert('Usuario y clave actualizada')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Debe seleccionar al menos un país')</script>");
        }
    }

    protected void ImageButton20_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarText();
    }

    private void LimpiarText()
    {
        TxtNombre.Text = "";
        TxtCelular.Text = "";
        TxtCorreo.Text = "";
        TxtCargo.Text = "";
        TxtExtension.Text = "";
        TxtTelefono.Text = "";
        CmbEstUsuario.SelectedValue = "1";
        HNuevo.Value = "1";
        TxtUsuario.Text = "";
        TxtIdentificacion.Text = "";
        txtClave.Attributes.Add("Value", "");
        RequiredFieldValidator8.Enabled = true;
        RegularExpressionValidator3.Enabled = true;
        txtClave.ReadOnly = false;

        foreach (System.Web.UI.WebControls.ListItem item in ddlPaisesCliente.Items)
        {
            item.Selected = false;
        }
    }

    protected void GridLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index;
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        switch (e.CommandName)
        {
            case "Editar":
                index = Convert.ToInt16(e.CommandArgument);
                ds = sv.UsuariosDatos(index);

                TxtNombre.Text = Convert.ToString(ds.Tables[0].Rows[0]["Nombre"]);
                TxtCelular.Text = Convert.ToString(ds.Tables[0].Rows[0]["Celular"]);
                TxtCorreo.Text = Convert.ToString(ds.Tables[0].Rows[0]["Correo"]);
                TxtCargo.Text = Convert.ToString(ds.Tables[0].Rows[0]["Cargo"]);
                TxtExtension.Text = Convert.ToString(ds.Tables[0].Rows[0]["Extension"]);
                TxtUsuario.Text = Convert.ToString(ds.Tables[0].Rows[0]["Usuario"]);
                TxtTelefono.Text = Convert.ToString(ds.Tables[0].Rows[0]["Telefono"]);
                CmbEstUsuario.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["IdEstUsuario"]);
                CmbPerfil.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["IdPerfil"]);
                //              this.txtClave.Attributes.Add("Value", Convert.ToString(ds.Tables[0].Rows[0]["Clave"]));
                TxtIdentificacion.Text = Convert.ToString(ds.Tables[0].Rows[0]["Identificacion"]);
                txtClave.ReadOnly = true;
                RequiredFieldValidator8.Enabled = false;
                RegularExpressionValidator3.Enabled = false;
                ds.Clear();

                HIdUsuario.Value = index.ToString();
                HNuevo.Value = "0";


                ds = sv.UsuarioPais(index);
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    int IdPais = int.Parse(ds.Tables[0].Rows[x]["IdPais"].ToString());

                    foreach (System.Web.UI.WebControls.ListItem item in ddlPaisesCliente.Items)
                    {
                        if (IdPais == int.Parse(item.Value))
                        {
                            item.Selected = true;
                        }
                    }
                }

                break;
            case "Eliminar":
                index = Convert.ToInt16(e.CommandArgument);
                sv.UsuarioEliminar(index);

                LimpiarText();
                GrillaLlenar();
                Response.Write("<script>alert('Usuario Eliminado')</script>");
                break;
            case "Reset":

                index = Convert.ToInt16(e.CommandArgument);
                ds = sv.UsuariosDatos(index);

                TxtNombre.Text = Convert.ToString(ds.Tables[0].Rows[0]["Nombre"]);
                TxtCelular.Text = Convert.ToString(ds.Tables[0].Rows[0]["Celular"]);
                TxtCorreo.Text = Convert.ToString(ds.Tables[0].Rows[0]["Correo"]);
                TxtCargo.Text = Convert.ToString(ds.Tables[0].Rows[0]["Cargo"]);
                TxtExtension.Text = Convert.ToString(ds.Tables[0].Rows[0]["Extension"]);
                TxtUsuario.Text = Convert.ToString(ds.Tables[0].Rows[0]["Usuario"]);
                TxtTelefono.Text = Convert.ToString(ds.Tables[0].Rows[0]["Telefono"]);
                CmbEstUsuario.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["IdEstUsuario"]);
                CmbPerfil.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["IdPerfil"]);
                TxtIdentificacion.Text = Convert.ToString(ds.Tables[0].Rows[0]["Identificacion"]);

                txtClave.ReadOnly = false;
                RequiredFieldValidator8.Enabled = true;
                RegularExpressionValidator3.Enabled = true;

                ds.Clear();

                HIdUsuario.Value = index.ToString();
                HNuevo.Value = "2";
                break;
            default:
                break;
        }
    }

    #region Validaciones
    private Boolean ValidaPass(string str)
    {
        Funciones fun = new Funciones();
        string cadena;
        string clave;
        Datos sv = new Datos();
        clave = str;
        cadena = str.Substring(0, 1);

        if (System.Text.RegularExpressions.Regex.IsMatch("1234567890", cadena, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
        {
            Response.Write("<script>alert('El Primer caracter no puede ser numerico')</script>");
            return false;
        }

        if (CaracterSeguidos(clave))
        {
            Response.Write("<script>alert('No Pueden haber tres caracteres iguales seguidos')</script>");
            return false;
        }

        if (ContieneMayusculas(clave) == false)
        {
            Response.Write("<script>alert('Debe Contener por lo menos un caracter en mayusculas')</script>");
            return false;
        }

        if (ContieneMinuscula(clave) == false)
        {
            Response.Write("<script>alert('Debe Contener por lo menos un caracter en minuscula')</script>");
            return false;
        }

        if (ContienNumeros(clave) == false)
        {
            Response.Write("<script>alert('Debe Contener por lo menos un Numero')</script>");
            return false;
        }

        DataSet ds;
        Boolean vetado = false;
        DataRow dr;

        ds = sv.PalabrasVetada();
        dr = ds.Tables[0].NewRow();
        dr[0] = Session["Usuario"].ToString().Trim();
        ds.Tables[0].Rows.Add(dr);

        string[] arr;
        char[] delimiterDestinos = { ' ' };

        arr = Session["Nombre"].ToString().Trim().Split(delimiterDestinos);

        for (int i = 0; i < arr.Length - 1; i++)
        {
            dr = ds.Tables[0].NewRow();
            dr[0] = arr[i].ToString();
            ds.Tables[0].Rows.Add(dr);
        }

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cadena = ds.Tables[0].Rows[i]["Palabra"].ToString();
            if (System.Text.RegularExpressions.Regex.IsMatch(clave, cadena, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                Response.Write("<script>alert(" + cadena + " No se permite en la contraseña')</script>");
                vetado = true;
                break;
            }
        }

        if (vetado)
            return false;

        ds.Clear();
        if (HNuevo.Value != "1")
        {
            ds = sv.HistorialClave(int.Parse(HIdUsuario.Value), fun.ToEncriptar(clave));

            if (ds.Tables[0].Rows.Count > 0)
            {
                Response.Write("<script>alert('Esta Clave Ya Fue Utilizada Puede ser utilizada despues de 6 iteraciones')</script>");
                return false;
            }
        }
        return true;
    }

    private Boolean CaracterSeguidos(string str)
    {
        Boolean Seguidos = false;
        string primera = str.Substring(0, 1);
        string segunda = str.Substring(1, 1);
        //  string tercera;
        for (int i = 2; i < str.Length; i++)
        {
            // tercera = str.Substring(i, 1);
            segunda = str.Substring(i, 1);
            if ((primera == segunda)) //& (segunda == tercera))
            {
                Seguidos = true;
                break;
            }
            primera = segunda;
            //segunda = tercera;
        }
        return Seguidos;
    }

    private Boolean ContieneMayusculas(string str)
    {
        Boolean contiene = false;
        string cadena;
        for (int i = 0; i < str.Length; i++)
        {
            cadena = str.Substring(i, 1);
            if (System.Text.RegularExpressions.Regex.IsMatch("A,B,C,D,E,F,G,H,I,J,K,L,M,N,Ñ,O,P,Q,R,S,T,U,V,W,X,Y,Z", cadena))
            {
                contiene = true;
                break;
            }
        }
        return contiene;
    }

    private Boolean ContieneMinuscula(string str)
    {
        Boolean contiene = false;
        string cadena;
        for (int i = 0; i < str.Length; i++)
        {
            cadena = str.Substring(i, 1);
            if (System.Text.RegularExpressions.Regex.IsMatch("a,b,c,d,e,f,g,h,i,j,k,l,m,n,ñ,o,p,q,r,s,t,u,v,w,x,y,z", cadena))
            {
                contiene = true;
                break;
            }
        }
        return contiene;
    }

    private Boolean ContienNumeros(string str)
    {
        Boolean contiene = false;
        string cadena;
        for (int i = 0; i < str.Length; i++)
        {
            cadena = str.Substring(i, 1);
            if (System.Text.RegularExpressions.Regex.IsMatch("1,2,3,4,5,6,7,8,9,0", cadena))
            {
                contiene = true;
                break;
            }
        }
        return contiene;
    }
    #endregion

    #region Funciones GridView
    public string GridViewSortDirection
    {
        get
        {
            object o = ViewState["SortDirection"];
            return ((o == null) ? "ASC" : Convert.ToString(o));
        }
        set { ViewState["SortDirection"] = value; }
    }

    public string GridViewSortExpression
    {
        get
        {
            object o = ViewState["SortExpression"];
            return ((o == null) ? string.Empty : Convert.ToString(o));
        }
        set { ViewState["SortExpression"] = value; }
    }

    protected string GetSortDirection()
    {
        switch ((GridViewSortDirection))
        {
            case "ASC":
                GridViewSortDirection = "DESC";
                break;
            case "DESC":
                GridViewSortDirection = "ASC";
                break;
        }
        return GridViewSortDirection;
    }

    protected void Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Datos sv = new Datos();
        GridLista.DataSource = SortDataTable(Dscompleto.Tables[0].DefaultView, true);
        // Calculate the current page number. 
        GridLista.PageIndex = e.NewPageIndex;
        // Reset selected index 
        GridLista.SelectedIndex = -1;
        GridLista.DataBind();

        // Identificar en qué página estás
        int currentPageIndex = e.NewPageIndex + 1; // Sumar 1 porque los índices comienzan en 0
        Label1.Text = "Página actual: " + currentPageIndex.ToString();
    }

    protected DataView SortDataTable(DataView DataTable1, bool isPageIndexChanging)
    {
        if ((DataTable1 != null))
        {
            DataView vista = DataTable1;
            if ((!string.IsNullOrEmpty(GridViewSortExpression)))
            {
                if ((isPageIndexChanging))
                {
                    vista.Sort = GridViewSortExpression + " " + GridViewSortDirection;
                }
                else
                {
                    vista.Sort = GridViewSortExpression + " " + GetSortDirection();
                }
            }
            return vista;
        }
        else
        {
            return new DataView();
        }
    }

    protected void Grid_Sorting(object sender, System.Web.UI.WebControls.GridViewSortEventArgs e)
    {
        Datos sv = new Datos();
        GridViewSortExpression = e.SortExpression;
        int pageIndex = GridLista.PageIndex;
        GridLista.DataSource = SortDataTable(Dscompleto.Tables[0].DefaultView, false);
        GridLista.DataBind();
        GridLista.PageIndex = pageIndex;
    }
    #endregion
}
