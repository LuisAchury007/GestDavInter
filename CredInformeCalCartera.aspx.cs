using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data.OleDb;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;


public partial class CredInformeCalCartera : System.Web.UI.Page
{
    dsPrincipalPage inicio = new dsPrincipalPage();
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IDusuario"] == null)
        {
            Response.Redirect("Salir.aspx");
        }
        


    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]

    public static List<string> SearchClients(string prefixText, int count, int IdPais)
    {
        Datos sv = new Datos();
        DataSet dsDatos = new DataSet();
        DataView vista = new DataView();
        List<string> list = new List<string>();

        dsDatos = sv.ListaEmpresasNit(prefixText.Trim(), IdPais);
        vista = dsDatos.Tables[0].DefaultView;
        vista.Sort = "RazonSocial ASC";

        DataTable dt = new DataTable();
        dt = vista.ToTable();



        for (int i = 0; i < dt.Rows.Count; i++)
        {
            list.Add(dt.Rows[i].ItemArray[0] + " - " + dt.Rows[i].ItemArray[1]);
        }


        return list;
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        Datos sv = new Datos();
        Funciones fun = new Funciones();
        DataSet ds = new DataSet();

        int n;
        Boolean Auxiliar = chkAuxiliar.Checked;
        //String nit = "";
        //var isNumber = int.TryParse(this.txtEmpre.Text.Trim().Split('-')[0], out n);
        //if (this.txtEmpre.Text != "" && isNumber == true)
        //{
        //    nit = this.txtEmpre.Text.Trim().Split('-')[0];


        ds = sv.CredCalCartera(Auxiliar);

        string filename;
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (fun.ExportExcellDataset(int.Parse(Session["IDusuario"].ToString()), ds, Request.ServerVariables["APPL_PHYSICAL_PATH"]))
            {
                filename = "Report" + Session["IDusuario"].ToString() + ".xls";

                string filepath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Archivos\Datos\" + filename;

                filename = "Report.xls";
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                Response.Flush();
                Response.WriteFile(filepath);
                
                ApplicationInstance.CompleteRequest();
            }
            ds.Clear();
        }

        //}
        //else
        //{
        //    Response.Write("<script>alert('Debe seleccionar una empresa')</script>");
        //}

    }
}