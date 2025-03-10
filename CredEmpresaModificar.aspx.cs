using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text.RegularExpressions;
using CarlosAg.ExcelXmlWriter;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.OleDb;
using System.Drawing;
using System.Data.SqlClient;

using Encoder = Microsoft.Security.Application.Encoder;
public partial class CredEmpresaModificar : System.Web.UI.Page
{
    public string macroState1 = "collapse";
    public string macroState2 = "collapse";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            llenarInfo();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        GrillaLlenar();
        macroState2 = "in";

    }

    protected void llenarInfo()
    {
        DataSet dts = new DataSet();
        Datos sv = new Datos();
        DataView vista = new DataView();

        dts = sv.SeTipoIdentificacion(1, 0);
        this.CmbTipoIdentificacion.DataSource = dts.Tables[0].DefaultView;
        this.CmbTipoIdentificacion.DataTextField = "Identificacion";
        this.CmbTipoIdentificacion.DataValueField = "IdTipIdentificacion";
        this.CmbTipoIdentificacion.DataBind();
        dts.Clear();

        dts = sv.SeTipoEmpresa();
        this.cmbTipoSociedadNew.DataSource = dts.Tables[0].DefaultView;
        this.cmbTipoSociedadNew.DataTextField = "TipoEmpresa";
        this.cmbTipoSociedadNew.DataValueField = "IdTipoEmpresa";
        this.cmbTipoSociedadNew.DataBind();
        dts.Clear();
               
        dts = sv.Ciudad(0, 1, Convert.ToInt32(Session["IdPais"].ToString()));
        this.cmbCiudad.DataSource = dts.Tables[0].DefaultView;
        this.cmbCiudad.DataTextField = "Ciudad";
        this.cmbCiudad.DataValueField = "IdCiudad";
        this.cmbCiudad.DataBind();

        this.cmbCiudadNew.DataSource = dts.Tables[0].DefaultView;
        this.cmbCiudadNew.DataTextField = "Ciudad";
        this.cmbCiudadNew.DataValueField = "IdCiudad";
        this.cmbCiudadNew.DataBind();
        dts.Clear();

        dts = sv.ComSectores(0, 1, Convert.ToInt32(Session["IdPais"].ToString()));
        dts.Tables[0].Rows.Add("-1", "Seleccione>>");
        vista = dts.Tables[0].DefaultView;
        vista.Sort = "IdSector ASC";

        this.CmbSector.DataSource = vista;
        this.CmbSector.DataTextField = "Sector";
        this.CmbSector.DataValueField = "IdSector";
        this.CmbSector.DataBind();

        
    }


  

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]

    public static List<string> SearchClients2(string prefixText, int count)
    {
        Datos sv = new Datos();
        DataSet dsDatos = new DataSet();
        DataView vista = new DataView();

        dsDatos = sv.SePais(5, prefixText.Trim());
        vista = dsDatos.Tables[0].DefaultView;
        vista.Sort = "Pais ASC";

        DataTable dt = new DataTable();
        dt = vista.ToTable();

        List<string> list = new List<string>();

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            //  list.Add("" + dt.Rows[i].ItemArray[1]);
            list.Add(dt.Rows[i].ItemArray[0] + " - " + dt.Rows[i].ItemArray[1]);
        }
        return list;
    }

    private void GrillaLlenar()
    {
        Datos sv = new Datos();

        DataSet ds = new DataSet();
        ds = sv.BencBuscarEmpresa(this.txtBuscar.Text, 4, Convert.ToInt32(Session["IdPais"].ToString()));

        GridEmpresas.DataSource = ds.Tables[0].DefaultView;
        GridEmpresas.DataBind();

    }

    private void LimpiarText()
    {
        this.TxtRazon.Text = "";
        this.TxtSigla.Text = "";
        this.TxtRepresentante.Text = "";
        this.TxtDireccion.Text = "";
        this.TxtFax.Text = "";
        this.TxtTelefono.Text = "";
        this.TxtAA.Text = "";
        this.TxtMatricula.Text = "";
        this.TxtWebSite.Text = "";
        this.TxtCiiu.Text = "";
        this.TxtMail.Text = "";
        this.HidNit.Value = "0";
        txtNItEit.Text = "";
        HidTipoID.Value = "0";
        HidConsecutivo.Value = "0";
        GridEmpresas.DataBind();
    }


    private void LimpiarText2()
    {
        this.TxtNitNew.Text = "";
        this.txtrazonsocialNew.Text = "";
        this.txtSiglaNew.Text = "";
        this.txtRepresentanteNew.Text = "";
        this.txtCargoNew.Text = "";
        this.txtrevisorfiscalNew.Text = "";
        this.txtDireccionNew.Text = "";
        this.txtTelefonoNew.Text = "";
        this.txtNumMatriculaNew.Text = "";
        this.txtMailNew.Text = "";
        txtConsecutivoNew.Text = "";
        txtPaisActividad.Text = "";

        this.txtWebNew.Text = "";
        this.txtciiuNew.Text = "";
        this.txtFechaNew.Text = "";
        this.txtobjetosocialNew.Text = "";





    }
    protected void ImageButton19_Click(object sender, ImageClickEventArgs e)
    {
        if (HidNit.Value != "")
        {
            Datos sv = new Datos();
            DataSet dsDatos = new DataSet();
            if (HidTipoID.Value == "13")
            {
                dsDatos = sv.BencEmpresaDatos(txtNItEit.Text.TrimEnd(), Convert.ToInt32(Session["IdPais"].ToString()));
                if (dsDatos.Tables[0].Rows.Count > 0)
                {
                    Response.Write("<script>alert('Este NIT ya esta registrado en el sistema. \\n ¡Favor revisar!')</script>");

                }
                else
                {
                    sv.ActualizarEmpresa(txtNItEit.Text.TrimEnd(), this.TxtRazon.Text.ToUpper(), this.TxtSigla.Text.ToUpper(), this.TxtRepresentante.Text.ToUpper(), this.TxtDireccion.Text.ToUpper(), this.TxtTelefono.Text, this.TxtFax.Text, this.TxtAA.Text, this.TxtMatricula.Text, this.TxtMail.Text, this.TxtWebSite.Text, this.TxtCiiu.Text, ChkEsCliente.Checked, Convert.ToInt32(Session["IdPais"].ToString()), int.Parse(this.cmbCiudad.SelectedValue),HidConsecutivo.Value, int.Parse(HidTipoID.Value));
                    LimpiarText();
                }
            }
            else
            {
                sv.ActualizarEmpresa(this.HidNit.Value, this.TxtRazon.Text.ToUpper(), this.TxtSigla.Text.ToUpper(), this.TxtRepresentante.Text.ToUpper(), this.TxtDireccion.Text.ToUpper(), this.TxtTelefono.Text, this.TxtFax.Text, this.TxtAA.Text, this.TxtMatricula.Text, this.TxtMail.Text, this.TxtWebSite.Text, this.TxtCiiu.Text, ChkEsCliente.Checked, Convert.ToInt32(Session["IdPais"].ToString()), int.Parse(this.cmbCiudad.SelectedValue),HidConsecutivo.Value, int.Parse(HidTipoID.Value));
                LimpiarText();
            }


            macroState2 = "in";
            Response.Write("<script>alert('Empresa Actualizada')</script>");

        }
    }

    protected void ImageButton20_Click(object sender, ImageClickEventArgs e)
    {
        macroState2 = "in";
        LimpiarText();
    }

    protected void GridLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string index;
        Datos sv = new Datos();

        DataSet ds = new DataSet();
        switch (e.CommandName)
        {
            case "Editar":
                index = e.CommandArgument.ToString();
                ds = sv.BencEmpresaDatos(index, Convert.ToInt32(Session["IdPais"].ToString()));
                this.TxtRazon.Text = Convert.ToString(ds.Tables[0].Rows[0]["RazonSocial"]);
                this.TxtSigla.Text = Convert.ToString(ds.Tables[0].Rows[0]["Sigla"]);
                this.TxtRepresentante.Text = Convert.ToString(ds.Tables[0].Rows[0]["RepresentanteLegal"]);
                this.TxtDireccion.Text = Convert.ToString(ds.Tables[0].Rows[0]["Direccion"]);
                this.TxtTelefono.Text = Convert.ToString(ds.Tables[0].Rows[0]["Telefono"]);
                this.TxtFax.Text = Convert.ToString(ds.Tables[0].Rows[0]["Fax"]);
                this.TxtAA.Text = Convert.ToString(ds.Tables[0].Rows[0]["AA"]);
                this.TxtMatricula.Text = Convert.ToString(ds.Tables[0].Rows[0]["NumMatricula"]);
                this.TxtWebSite.Text = Convert.ToString(ds.Tables[0].Rows[0]["Website"]);
                this.TxtCiiu.Text = Convert.ToString(ds.Tables[0].Rows[0]["Ciiu"]);
                this.TxtMail.Text = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                this.ChkEsCliente.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["EsCliente"]);
                this.cmbCiudad.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["IdCiudad"]);
                txtNItEit.Text = Convert.ToString(ds.Tables[0].Rows[0]["NIT"]);
                HidConsecutivo.Value = Convert.ToString(ds.Tables[0].Rows[0]["Consecutivo"]);
                HidTipoID.Value = Convert.ToString(ds.Tables[0].Rows[0]["IdTipIdentifiacion"]);
                ds.Clear();

                if (HidTipoID.Value == "13")
                {
                    DivEdit.Visible = true;

                }
                else
                {
                    DivEdit.Visible = false;
                }

                HidNit.Value = index.ToString();
                break;
            default:
                break;
        }
        macroState2 = "in";

    }

    protected void LimpiaEmpNueva_Click(object sender, ImageClickEventArgs e)
    {
        //GridEmpresas.Visible = true;
        //Label1.Visible = true;
        //txtBuscar.Visible = true;
        //Button1.Visible = true;
        //TxtNitNew.Text = "";
        //txtrazonsocialNew.Text = "";
        txtConsecutivoNew.Text = "";
        txtPaisActividad.Text = "";
        macroState1 = "in";
        LimpiarText2();

    }



    protected void BtnGuardarEmpNueva_Click(object sender, ImageClickEventArgs e)
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();
        DataSet dsDatos = new DataSet();
        //string Fecha = Convert.ToString(DateTime.Now);

        string NIT = "";
        if (TxtNitNew.Text.TrimEnd() != "")
        {
            NIT = this.TxtNitNew.Text;
        }

        dsDatos = sv.BencEmpresaDatos(NIT, Convert.ToInt32(Session["IdPais"].ToString()));
        if (dsDatos.Tables[0].Rows.Count > 0)
        {
            Response.Write("<script>alert('Este No. Documento ya esta registrado en el sistema. \\n ¡Favor revisar!')</script>");

        }
        else
        {
            if (Convert.ToInt32(CmbTipoIdentificacion.SelectedValue) != 13)
            {
                sv.CredEmpresaInser(this.TxtNitNew.Text.TrimEnd(), txtrazonsocialNew.Text.ToUpper(), txtSiglaNew.Text, int.Parse(cmbTipoSociedadNew.SelectedValue), txtobjetosocialNew.Text, txtRepresentanteNew.Text, txtCargoNew.Text, int.Parse(this.cmbCiudadNew.SelectedValue), txtDireccionNew.Text, txtTelefonoNew.Text, "", "", txtNumMatriculaNew.Text, txtMailNew.Text, txtWebNew.Text, txtFechaNew.Text, txtciiuNew.Text, txtrevisorfiscalNew.Text, int.Parse(CmbTipoIdentificacion.SelectedValue), "", Convert.ToInt32(Session["IdPais"].ToString()),"", this.txtPaisActividad.Text.Trim().Split('-')[0],int.Parse(CmbSector.SelectedValue));
            }
            else if (Convert.ToInt32(CmbTipoIdentificacion.SelectedValue) == 13)
            {

                sv.CredEmpresaInser(this.TxtNitNew.Text.TrimEnd(), txtrazonsocialNew.Text.ToUpper(), txtSiglaNew.Text, int.Parse(cmbTipoSociedadNew.SelectedValue), txtobjetosocialNew.Text, txtRepresentanteNew.Text, txtCargoNew.Text, int.Parse(this.cmbCiudadNew.SelectedValue), txtDireccionNew.Text, txtTelefonoNew.Text, "", "", txtNumMatriculaNew.Text, txtMailNew.Text, txtWebNew.Text, txtFechaNew.Text, txtciiuNew.Text, txtrevisorfiscalNew.Text, int.Parse(CmbTipoIdentificacion.SelectedValue), "", Convert.ToInt32(Session["IdPais"].ToString()), txtConsecutivoNew.Text, this.txtPaisActividad.Text.Trim().Split('-')[0],int.Parse(CmbSector.SelectedValue));
            }

            sv.InGrupoEmpresaria("", true, 3, 0, this.TxtNitNew.Text.TrimEnd(), "", 0);
            GridEmpresas.Visible = true;
            Label1.Visible = true;
            txtBuscar.Visible = true;
            Button1.Visible = true;
            TxtNitNew.Enabled = true;
            LimpiarText2();
            Response.Write("<script>alert('Empresa creada')</script>");
        }



        macroState1 = "in";


    }

    protected void CargarConsecutivo()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();
        string Consecutivo = "";
        int Pais = int.Parse(Session["IdPais"].ToString());
        long consecutivo = 0;
        switch (Pais)
        {
            case 1:
                Consecutivo = "SV";
                break;
            case 2:
                Consecutivo = "HN";
                break;
            case 3:
                Consecutivo = "CR";
                break;
            case 4:
                Consecutivo = "PA";
                break;

        }

        ds = sv.SeConsecutivoEmp(1, Pais);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToString(ds.Tables[0].Rows[0]["Consecutivo"]) != "")
            {
                consecutivo = Convert.ToInt64(ds.Tables[0].Rows[0]["Consecutivo"]);
            }
        }
        Consecutivo = Consecutivo + Convert.ToString(consecutivo + 1);
        txtConsecutivoNew.Text = Consecutivo;
        TxtNitNew.Text = Consecutivo.TrimEnd();


    }

    protected void CmbTipoIdentificacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        macroState1 = "in";
        if (Convert.ToInt32(CmbTipoIdentificacion.SelectedValue) == 13)
        {
            txtConsecutivoNew.Text = "";
            DivCons.Visible = true;
            txtConsecutivoNew.Enabled = false;
            TxtNitNew.Enabled = false;
            CargarConsecutivo();
        }
        else
        {
            txtConsecutivoNew.Text = "";
            DivCons.Visible = false;
            txtConsecutivoNew.Enabled = true;
            TxtNitNew.Enabled = true;
        }
       
    }

    //protected void TxtNitDigitoNew_TextChanged(object sender, EventArgs e)
    //{
    //    macroState1 = "in";
    //    String Nit = TxtNitDigitoNew.Text;
    //    Int32 Numero = Nit.Length - 1;

    //    Int32[] Multiplicando = new Int32[9];
    //    Int32[] Multiplicador = { 3, 7, 13, 17, 19, 23, 29, 37, 41 };
    //    Int32[] Producto = new Int32[9];

    //    Int64 TotalSuma = 0;
    //    Int64 Residuo = 0;

    //    for (int i = 0; i < Nit.Length; i++)
    //    {
    //        Multiplicando[i] = Convert.ToInt32(Nit.ToCharArray()[Numero].ToString());
    //        Numero--;
    //        Producto[i] = Multiplicando[i] * Multiplicador[i];

    //        TotalSuma = TotalSuma + Producto[i];
    //    }
    //    Residuo = TotalSuma % 11;

    //    if (Residuo == 1 || Residuo == 0)
    //    {
    //        TxtNitDigitoNew.Text = TxtNitDigitoNew.Text + Residuo.ToString();
    //    }
    //    else
    //    {
    //        TxtNitDigitoNew.Text = TxtNitDigitoNew.Text + Convert.ToInt32((Residuo - 11) * -1);
    //    }
    //}


   
}
