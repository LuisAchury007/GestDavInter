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

public partial class ComCambioClave : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Request["Obligatorio"] != null))
        {
            this.Label1.Text = "Para Poder Continuar debe cambiar su clave";
        }
        else
        {
            this.Label1.Text = "Cambiar la clave";
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string cadena;
        string clave;
        Funciones fun = new Funciones();

        clave = TxtClaveCon.Text.Trim();

        if (TxtClave.Text.Trim() != TxtClaveCon.Text.Trim())
        {
            Response.Write("<script>alert('La nueva clave tienen que ser iguales')</script>");
            return;
        }

        cadena = TxtClaveCon.Text.Trim().Substring(0, 1);

        if (System.Text.RegularExpressions.Regex.IsMatch("1234567890", cadena, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
        {
            Response.Write("<script>alert('El Primer caracter no puede ser numerico')</script>");
            return;
        }

        if (CaracterSeguidos(clave))
        {
            Response.Write("<script>alert('No Pueden haber dos caracteres iguales seguidos')</script>");
            return;
        }

        if (ContieneMayusculas(clave) == false)
        {
            Response.Write("<script>alert('Debe Contener por lo menos un caracter en mayusculas')</script>");
            return;
        }

        if (ContieneMinuscula(clave) == false)
        {
            Response.Write("<script>alert('Debe Contener por lo menos un caracter en minuscula')</script>");
            return;
        }

        if (ContienNumeros(clave) == false)
        {
            Response.Write("<script>alert('Debe Contener por lo menos un Numero')</script>");
            return;
        }

        Datos sv = new Datos();
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
                Response.Write("<script>alert('" + cadena + " No se permite en la contraseña')</script>");
                vetado = true;
                break;
            }
        }

        if (vetado)
            return;

        ds.Clear();
        ds = sv.HistorialClave(int.Parse(Session["IDusuario"].ToString()), fun.ToEncriptar(this.TxtClave.Text.Trim()));

        if (ds.Tables[0].Rows.Count > 0)
        {
            Response.Write("<script>alert('Esta Clave Ya Fue Utilizada Puede ser utilizada despues de 6 iteraciones')</script>");
            return;
        }
        int resultado;

        resultado = sv.CambiarClave(int.Parse(Session["IDusuario"].ToString()), fun.ToEncriptar(this.TxtClaveAnt.Text.Trim()), fun.ToEncriptar(this.TxtClave.Text.Trim()));

        if (resultado == 1)
        {
            Response.Write("<script>alert('Clave Actualizada Correctamente')</script>");

            if ((Request["Obligatorio"] == "1"))
            {
                Server.Transfer("Logon.aspx");
            }
        }
        else
        {
            Response.Write("<script>alert('Clave Actual es Incorrecta')</script>");
        }

    }

    private Boolean CaracterSeguidos(string str)
    {
        Boolean Seguidos = false;

        string primera = str.Substring(0, 1);
        string segunda = str.Substring(1, 1);
        //string tercera;

        for (int i = 2; i < str.Length; i++)
        {
            //  tercera = str.Substring(i, 1);
            segunda = str.Substring(i, 1);
            if ((primera == segunda)) // & (segunda == tercera))
            {
                Seguidos = true;
                break;
            }
            primera = segunda;
            //   segunda = tercera;
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
}
