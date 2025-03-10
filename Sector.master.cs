using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class Sector : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = sv.CredCuentaEmpSector(int.Parse(Request["IdSector"]));

        this.Label1.Text = Request["NombreSec"] +  " (" + Convert.ToString(ds.Tables[0].Rows[0]["Cuantos"])  + " )";

    }
       

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("CredSectorIndicadores.aspx?IdSector=" + Request["IdSector"] + "&NombreSec=" + Request["NombreSec"]);
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("CredSectorPG.aspx?IdSector=" + Request["IdSector"] + "&NombreSec=" + Request["NombreSec"]);
    }

   
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Response.Redirect("CredEmpresasLista.aspx?IdSector=" + Request["IdSector"] + "&NombreSec=" + Request["NombreSec"]);
    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        Response.Redirect("CredSectorRanking.aspx?IdSector=" + Request["IdSector"] + "&NombreSec=" + Request["NombreSec"]);
    }
    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        Response.Redirect("CredSectorProspectar.aspx?IdSector=" + Request["IdSector"] + "&NombreSec=" + Request["NombreSec"]);
    }
    
    protected void LinkButton10_Click(object sender, EventArgs e)
    {
        Response.Redirect("CredNewSector.aspx");
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("CredSectorBalance.aspx?IdSector=" + Request["IdSector"] + "&NombreSec=" + Request["NombreSec"]);
    }
}
