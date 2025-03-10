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

public partial class Cabezote : System.Web.UI.Page
{


         protected void Page_Load(object sender, EventArgs e)
    {


        if (Page.IsPostBack == false)
        {
            

    //    if (Session["IDusuario"] == null)
    //    {
    //        Response.Redirect("Salir.aspx");
    //    }
  
          //lbUsuario.Text = Session["Usuario"].ToString();

       

    //Datos sv = new Datos();   
    //DataSet ds = new DataSet();
    //DataSet dsDatos = new DataSet();
	 
    //int i = 0;
    //int k = 0;
	 
    //this.Menu1.Items.Clear();




    //ds = sv.Menu1(int.Parse(Session["IdPerfil"].ToString()));

	 
	 
    //for (i = 0; i < ds.Tables[0].Rows.Count; i++) {
    //    MenuItem ms = new MenuItem();
    //    ms.Text = ds.Tables[0].Rows[i]["menu"].ToString();
    //    this.Menu1.Items.Add(ms);

    //    dsDatos = sv.Menu2(int.Parse(Session["IdPerfil"].ToString()), int.Parse(ds.Tables[0].Rows[i]["Orden1"].ToString()));
	   
	   
	 
    //    for (k = 0; k < dsDatos.Tables[0].Rows.Count; k++) {
    //        MenuItem ms01 = new MenuItem();
    //        ms01.Text = dsDatos.Tables[0].Rows[k]["Submenu"].ToString();
    //        ms01.NavigateUrl = dsDatos.Tables[0].Rows[k]["Pagina"].ToString();
    //        this.Menu1.Items[i].ChildItems.Add(ms01);
    //    }
    //    dsDatos.Clear();
    //}
	 
    //ds.Clear();
    //
             
    
   }
    }
         protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
         {


          string url = Session["PaginaInicio"].ToString();
          Response.Write("<script>");
          Response.Write("window.parent.location.href='" + url + "';");
          Response.Write("</script>");


         }
         protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
         {
             string url = Session["PaginaInicio"].ToString();
             Response.Write("<script>");
             Response.Write("window.parent.location.href='" + url + "';");
             Response.Write("</script>");
         }
}

