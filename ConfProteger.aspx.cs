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
using System.Web.Configuration;

public partial class ConfProteger : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        if (this.TxtClaveAnt.Text == "Reset05")
        {
            Cifrar(false);
            Response.Write("<script>alert('Cadenas Desencriptadas')</script>");
        }
        else
            Response.Write("<script>alert('Clave No Valida')</script>");

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (this.TxtClaveAnt.Text == "Reset05")
        {
            Cifrar(true);
            Response.Write("<script>alert('Cadenas Encriptadas')</script>");
        }
        else
            Response.Write("<script>alert('Clave No Valida')</script>");
    }

    private void Cifrar(bool estado)
    {

        string ruta = Request.ApplicationPath;
        Configuration config = WebConfigurationManager.OpenWebConfiguration(ruta);
        ConfigurationSection seccion = config.ConnectionStrings;
        if (estado)
            seccion.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
        else
            seccion.SectionInformation.UnprotectSection();
        config.Save();


    }

}
