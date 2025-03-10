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

public partial class Conf_DatosMacros : System.Web.UI.Page
{
    /*Se declaran variables publicas para evitar el cierre del acordeon correspondiente al realizar el postback en los DropDownList de la pagina*/
    public string segmentState = "collapse";
    public string lvlRiskState = "collapse";
    public string macroState = "collapse";
    public string lvlRiskState2 = "collapse";
    public string lvlRiskState9 = "collapse";
    public string lvlRiskState10 = "collapse";
    public string lvlRiskState11 = "collapse";
    public string RParameters = "collapse";
    public string ForExchange = "collapse";
    public string ConvForExchange = "collapse";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            Datos sv = new Datos();
            if (!sv.ComValidaPaginaPerfil(int.Parse(Session["IdPerfil"].ToString()), Request.Url.Segments[Request.Url.Segments.Length - 1]))
            {
                Response.Redirect("Salir.aspx");
            }
            LlenarDatos();
        }
    }

    private void LlenarDatos()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();
        DataView vista = new DataView();

        //ds = sv.DatosPaisCliente(int.Parse(Session["IdPais"].ToString()));

        //TxtCualitativa.Text = int.Parse(ds.Tables[0].Rows[0]["MesesCualitativa"].ToString()).ToString();
        //TxtRestucturado.Text = decimal.Parse(ds.Tables[0].Rows[0]["Reest"].ToString()).ToString();
        //TxtLey1116.Text = decimal.Parse(ds.Tables[0].Rows[0]["Ley1116"].ToString()).ToString();
        //TxtListClinton.Text = decimal.Parse(ds.Tables[0].Rows[0]["ListaClinton"].ToString()).ToString();
        //TxtDisolucion.Text = decimal.Parse(ds.Tables[0].Rows[0]["Disolucion"].ToString()).ToString();
        //TxtPisoDisolucion.Text = decimal.Parse(ds.Tables[0].Rows[0]["PisoDisolucion"].ToString()).ToString();
        //TxtEFDesactualizados.Text = decimal.Parse(ds.Tables[0].Rows[0]["EFDesactualizados"].ToString()).ToString();

        //if (ds.Tables[0].Rows[0]["ValorCastigo"].ToString() != "")
        //{
        //    TxtValorCastigo.Text = decimal.Parse(ds.Tables[0].Rows[0]["ValorCastigo"].ToString()).ToString();
        //    this.HidValorCastigo.Value = decimal.Parse(ds.Tables[0].Rows[0]["ValorCastigo"].ToString()).ToString();
        //}
        //else
        //{
        //    TxtValorCastigo.Text = "0";
        //    this.HidValorCastigo.Value = "0";
        //}

        //if (ds.Tables[0].Rows[0]["TRMDia"].ToString() != "")
        //{
        //    txtTRM.Text = decimal.Parse(ds.Tables[0].Rows[0]["TRMDia"].ToString()).ToString();
        //    this.hdfTRMDia.Value = decimal.Parse(ds.Tables[0].Rows[0]["TRMDia"].ToString()).ToString();
        //}
        //else
        //{
        //    txtTRM.Text = "0";
        //    this.hdfTRMDia.Value = "0";
        //}
        //this.hdfMCualitativa.Value = int.Parse(ds.Tables[0].Rows[0]["MesesCualitativa"].ToString()).ToString();
        //this.hdfCrRestucturado.Value = decimal.Parse(ds.Tables[0].Rows[0]["Reest"].ToString().Replace(".", ",")).ToString();
        //this.hdfLey1116.Value = decimal.Parse(ds.Tables[0].Rows[0]["Ley1116"].ToString().Replace(".", ",")).ToString();
        //this.hdfListClinton.Value = decimal.Parse(ds.Tables[0].Rows[0]["ListaClinton"].ToString().Replace(".", ",")).ToString();

        //txtSegmento.Text = "";
        //txtSumarCFinal.Text = "";
        //txtNivRiesgo.Text = "";
        //txtValRiesgo.Text = "";

        //#region nuevos campos
        ///*INICIO: 27-09-2018 - David Alzate - Nuevos Campos */
        ///*PISO REESTRUCTURACION*/
        //if (ds.Tables[0].Rows[0]["PisoReest"].ToString() != "")
        //{
        //    txtPisoReest.Text = decimal.Parse(ds.Tables[0].Rows[0]["PisoReest"].ToString().Replace(".", ",")).ToString();
        //    this.hdfPisoReest.Value = decimal.Parse(ds.Tables[0].Rows[0]["PisoReest"].ToString().Replace(".", ",")).ToString();
        //}
        //else
        //{
        //    txtPisoReest.Text = "0,0000";
        //    this.hdfPisoReest.Value = "0,0000";
        //}

        ///*PISO LEY 1116*/
        //if (ds.Tables[0].Rows[0]["PisoLey1116"].ToString() != "")
        //{
        //    txtPiso1116.Text = decimal.Parse(ds.Tables[0].Rows[0]["PisoLey1116"].ToString().Replace(".", ",")).ToString();
        //    this.hdfPiso1116.Value = decimal.Parse(ds.Tables[0].Rows[0]["PisoLey1116"].ToString().Replace(".", ",")).ToString();
        //}
        //else
        //{
        //    txtPiso1116.Text = "0,0000";
        //    this.hdfPiso1116.Value = "0,0000";
        //}

        ///*PISO LISTA CLINTON*/
        //if (ds.Tables[0].Rows[0]["PisoListaClinton"].ToString() != "")
        //{
        //    txtPisoClinton.Text = decimal.Parse(ds.Tables[0].Rows[0]["PisoListaClinton"].ToString().Replace(".", ",")).ToString();
        //    this.hdfPisoClinton.Value = decimal.Parse(ds.Tables[0].Rows[0]["PisoListaClinton"].ToString().Replace(".", ",")).ToString();
        //}
        //else
        //{
        //    txtPisoClinton.Text = "0,0000";
        //    this.hdfPisoClinton.Value = "0,0000";
        //}
        ///*PISO CASTIGO*/
        //if (ds.Tables[0].Rows[0]["PisoCastigo"].ToString() != "")
        //{
        //    txtPisoCastigo.Text = decimal.Parse(ds.Tables[0].Rows[0]["PisoCastigo"].ToString().Replace(".", ",")).ToString();
        //    this.hdfPisoCastigo.Value = decimal.Parse(ds.Tables[0].Rows[0]["PisoCastigo"].ToString().Replace(".", ",")).ToString();
        //}
        //else
        //{
        //    txtPisoCastigo.Text = "0,0000";
        //    this.hdfPisoCastigo.Value = "0,0000";
        //}

        /*FIN: 27-09-2018 - David Alzate - Nuevos Campos */
      //  #endregion


       // ds.Clear();

        /* INICIO: David Alzate 18/08/2017 - Asunto se llenan los dropdown de segmento y nivel riesgo para editar los parametros de cada tabla */
        //ds = sv.tiposSegmentos();
        //ds.Tables[0].Rows.Add("-1", " Seleccione Segmento");
        //vista = ds.Tables[0].DefaultView;
        //vista.Sort = "Segmento ASC";

        //this.cmbSegmento.DataSource = vista;
        //this.cmbSegmento.SelectedValue = "-1";
        //this.cmbSegmento.DataTextField = "Segmento";
        //this.cmbSegmento.DataValueField = "IdSegmento";
        //this.cmbSegmento.DataBind();
        //ds.Clear();

        //ds = sv.DatosNivRiesgo(1, 0);
        //grNivelRiesgo.DataSource = ds.Tables[0].DefaultView;
        //grNivelRiesgo.DataBind();
        //ds.Clear();
        ///* FIN: David Alzate 18/08/2017 */

        //ds = sv.SeOpcionesNivRiesgoParam(1, 1, 0);
        //grCondicionEsp.DataSource = ds.Tables[0].DefaultView;
        //grCondicionEsp.DataBind();
        //ds.Clear();

        //ds = sv.SeOpcionesNivRiesgoParam(2, 1, 0);
        //GridInstancia.DataSource = ds.Tables[0].DefaultView;
        //GridInstancia.DataBind();
        //ds.Clear();

        //ds = sv.SeOpcionesNivRiesgoParam(3, 1, 0);
        //grvResponsables.DataSource = ds.Tables[0].DefaultView;
        //grvResponsables.DataBind();
        //ds.Clear();

        //ds = sv.SeParametrosR(1, "");
        //GridParametrosR.DataSource = ds.Tables[0].DefaultView;
        //GridParametrosR.DataBind();
        //ds.Clear();

        ds = sv.DivisaLista(0, 2);
        GridDivisas.DataSource = ds.Tables[0].DefaultView;
        GridDivisas.DataBind();
        ds.Clear();
    }

    #region Vetos Globales
    //protected void guardarVetos_Click(object sender, ImageClickEventArgs e)
    //{
    //    Datos sv = new Datos();

    //    sv.Up_DatosPaisCliente(int.Parse(Session["IdPais"].ToString()), int.Parse(this.TxtCualitativa.Text),
    //        decimal.Parse(this.TxtRestucturado.Text),
    //        decimal.Parse(this.TxtLey1116.Text),
    //        decimal.Parse(this.TxtListClinton.Text),
    //        decimal.Parse(TxtValorCastigo.Text),
    //        decimal.Parse(txtPisoReest.Text),
    //        decimal.Parse(txtPiso1116.Text),
    //        decimal.Parse(txtPisoClinton.Text),
    //        decimal.Parse(txtPisoCastigo.Text),
    //        decimal.Parse(TxtDisolucion.Text),
    //        decimal.Parse(TxtEFDesactualizados.Text), decimal.Parse(TxtPisoDisolucion.Text)
    //        );

    //    /* INICIO: David Alzate 04/09/2017 - ASUNTO: Se agrega Auditoria para control de movimientos en el aplicativo*/
    //    String DescripcionAudit = "Actualización de Datos Macro: Meses Cualitativa Anterior: " + this.hdfMCualitativa.Value +
    //        ". Credito Reestructurado Anterior: " + this.hdfCrRestucturado.Value +
    //        ". Valor Ley 1116 Anterior: " + this.hdfLey1116.Value +
    //        ". Valor Lista Clinton Anterior: " + this.hdfListClinton.Value +
    //        ". Valor Castigo Anterior: " + this.HidValorCastigo.Value +
    //        /* Nuevos Campos */
    //        ". Piso Reestructuracion Anterior: " + this.hdfPisoReest.Value +
    //        ". Piso Ley 1116 Anterior: " + this.hdfPiso1116.Value +
    //        ". Piso Lista Clinton Anterior: " + this.hdfPisoClinton.Value +
    //        ". Piso Castigo Anterior: " + this.hdfPisoCastigo.Value +
    //        /* Datos Nuevos*/
    //        ". Nuevo Meses Cualitativa: " + this.TxtCualitativa.Text +
    //        ". Nuevo Credito Reestructurado: " + this.TxtRestucturado.Text +
    //        ". Nuevo Valor Ley 1116: " + this.TxtLey1116.Text +
    //        ". Nuevo Valor Lista Clinton: " + this.TxtListClinton.Text +
    //        ". Nuevo Valor Castigo : " + this.TxtValorCastigo.Text +
    //        /* Nuevos Campos */
    //        ". Nuevo Piso Reestructuracion: " + this.txtPisoReest.Text +
    //        ". Nuevo Piso Ley 1116: " + this.txtPiso1116.Text +
    //        ". Nuevo Piso Lista Clinton: " + this.txtPisoClinton.Text +
    //        ". Nuevo Piso Castigo: " + this.txtPisoCastigo.Text +
    //         ". Nuevo Piso Ley 1116: " + this.txtPiso1116.Text +
    //        ". Nuevo Piso Lista Clinton: " + this.txtPisoClinton.Text +
    //        ". Nuevo Piso Castigo: " + this.txtPisoCastigo.Text +

    //        ". EEFF Desactualizados: " + this.TxtEFDesactualizados.Text +
    //        ". Nuevo valor Disolucion: " + this.TxtDisolucion.Text +
    //        ". Nuevo Piso Disolucion: " + this.TxtPisoDisolucion.Text;

    //    sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblTituloTblsParam.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);
    //    /* FIN: David Alzate 04/09/2017 */

    //    Response.Write("<script>alert('Minimo y Maximo de Macro Actualizado')</script>");
    //    macroState = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
    //    LlenarDatos();

    //}
    #endregion

    #region Segmento
    //protected void cmbSegmento_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Datos sv = new Datos();
    //    DataSet ds = new DataSet();

    //    if (cmbSegmento.SelectedValue != "-1")/*Se agrega condicional para borrar las cajas de texto si no selecciona opcion alguna */
    //    {
    //        ds = sv.DatosSegmento(Convert.ToInt32(cmbSegmento.SelectedValue));
    //        this.txtSegmento.Text = Convert.ToString(ds.Tables[0].Rows[0]["Segmento"]);
    //        this.txtSumarCFinal.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["SumarCFinal"]).ToString();
    //        this.hdfSumaCalFAnt.Value = Convert.ToDecimal(ds.Tables[0].Rows[0]["SumarCFinal"]).ToString();
    //        if (ds.Tables[0].Rows[0]["PisoSegmento"].ToString() != "")
    //        {
    //            txtPisoSegmento.Text = decimal.Parse(ds.Tables[0].Rows[0]["PisoSegmento"].ToString()).ToString();
    //            this.hdfPisoSegmento.Value = decimal.Parse(ds.Tables[0].Rows[0]["PisoSegmento"].ToString()).ToString();
    //        }
    //        else
    //        {
    //            txtPisoSegmento.Text = "0,0000";
    //            this.hdfPisoSegmento.Value = "0,0000";
    //        }

    //        ds.Clear();
    //    }
    //    else
    //    {
    //        txtSegmento.Text = "";
    //        txtSumarCFinal.Text = "";
    //        hdfSumaCalFAnt.Value = "";
    //        txtPisoSegmento.Text = "";
    //        hdfPisoSegmento.Value = "";
    //    }
    //    segmentState = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */

    //}
    //protected void guardarSegmento_Click(object sender, ImageClickEventArgs e)
    //{
    //    Datos sv = new Datos();

    //    sv.Up_DatosSegmento(Convert.ToInt32(cmbSegmento.SelectedValue), Convert.ToString(this.txtSegmento.Text), decimal.Parse(this.txtSumarCFinal.Text), decimal.Parse(this.txtPisoSegmento.Text));

    //    /* INICIO: David Alzate 04/09/2017 - ASUNTO: Se agrega Auditoria para control de movimientos en el aplicativo*/
    //    String DescripcionAudit = "Actualización de Riesgo por Tamaño, Nombre Segmento Anterior: " + this.cmbSegmento.SelectedItem.Text + ". Suma Calificación Final Anterior: " + this.hdfSumaCalFAnt.Value + ". Piso Segmento Anterior: " + this.hdfPisoSegmento.Value + ". Nuevo Nombre de Segmento: " + Convert.ToString(this.txtSegmento.Text) + ". Nueva Suma Calificación Final: " + decimal.Parse(this.txtSumarCFinal.Text) + ". Nuevo Piso Segmento: " + decimal.Parse(this.txtPisoSegmento.Text);
    //    sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblTituloTblsParam.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);
    //    /* FIN: David Alzate 04/09/2017 */


    //    txtPisoSegmento.Text = "";
    //    hdfPisoSegmento.Value = "";
    //    Response.Write("<script>alert('Nombre y suma calificación final de segmento actualizados')</script>");
    //    segmentState = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
    //    LlenarDatos();

    //}
    #endregion

    #region Nivel Riesgo
    //protected void grNivelRiesgo_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    string index;
    //    Datos sv = new Datos();
    //    DataSet ds = new DataSet();

    //    switch (e.CommandName)
    //    {
    //        case "Editar":
    //            index = Convert.ToString(e.CommandArgument);
    //            ds = sv.DatosNivRiesgo(2, Convert.ToInt32(index));

    //            this.txtNivRiesgo.Text = Convert.ToString(ds.Tables[0].Rows[0]["NivelRiego"]);
    //            this.txtValRiesgo.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["Valor"]).ToString();
    //            chkNivelRiesgo.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Activo"]);

    //            hdfNivRId.Value = index.ToString();
    //            hdfNivelRiesgo.Value = Convert.ToString(ds.Tables[0].Rows[0]["NivelRiego"]);
    //            hdfValorAnterior.Value = Convert.ToDecimal(ds.Tables[0].Rows[0]["Valor"]).ToString();
    //            hdfNivRAct.Value = Convert.ToString(ds.Tables[0].Rows[0]["Activo"]);
    //            hdfNivelRNuevo.Value = "false";

    //            if (ds.Tables[0].Rows[0]["PisoNivelRiego"].ToString() != "")
    //            {
    //                txtPisoNivRies.Text = decimal.Parse(ds.Tables[0].Rows[0]["PisoNivelRiego"].ToString()).ToString();
    //                hdfPisoNivRies.Value = decimal.Parse(ds.Tables[0].Rows[0]["PisoNivelRiego"].ToString()).ToString();
    //            }
    //            else
    //            {
    //                txtPisoNivRies.Text = "0,0000";
    //                hdfPisoNivRies.Value = "0,0000";
    //            }

    //            ds.Clear();
    //            lvlRiskState = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
    //            break;
    //        default:
    //            break;
    //    }
    //}

    //protected void guardarNivRiesgo_Click(object sender, ImageClickEventArgs e)
    //{
    //    Datos sv = new Datos();
    //    String DescripcionAudit;

    //    if (hdfNivelRNuevo.Value == "true")
    //    {
    //        sv.In_DatosNivRiesgo(Convert.ToString(txtNivRiesgo.Text), decimal.Parse(txtValRiesgo.Text), decimal.Parse(txtPisoNivRies.Text), chkNivelRiesgo.Checked);

    //        /* INICIO: David Alzate 04/09/2017 - ASUNTO: Se agrega Auditoria para control de movimientos en el aplicativo*/
    //        DescripcionAudit = "Inserción de Nivel Riesgo: Nombre: " + Convert.ToString(txtNivRiesgo.Text) + "; Valor: " + decimal.Parse(txtValRiesgo.Text) + "; Piso Nivel Riesgo: " + decimal.Parse(this.txtPisoNivRies.Text) + "; Estado: " + chkNivelRiesgo.Checked.ToString();
    //        sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblTituloTblsParam.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);
    //        /* FIN: David Alzate 04/09/2017 */
    //        LimpiarText();
    //        LlenarDatos();
    //        Response.Write("<script>alert(Nivel de riesgo creada')</script>");
    //    }
    //    else
    //    {
    //        sv.Up_DatosNivRiesgo(Convert.ToInt32(hdfNivRId.Value), Convert.ToString(txtNivRiesgo.Text), decimal.Parse(txtValRiesgo.Text), decimal.Parse(txtPisoNivRies.Text), chkNivelRiesgo.Checked);

    //        /* INICIO: David Alzate 04/09/2017 - ASUNTO: Se agrega Auditoria para control de movimientos en el aplicativo*/
    //        DescripcionAudit = "Actualización Nivel de Riesgo, Nombre Anterior: " + hdfNivelRiesgo.Value + "; Valor Anterior: " + hdfValorAnterior.Value + "; Piso Nivel Riesgo Anterior: " + hdfPisoNivRies.Value + "; Estado Anterior: " + hdfNivRAct.Value + "; Nuevo Nombre: " + Convert.ToString(txtNivRiesgo.Text) + "; Nuevo Valor: " + decimal.Parse(this.txtValRiesgo.Text) + "; Nuevo Piso Nivel Riesgo: " + decimal.Parse(this.txtPisoNivRies.Text) + "; Estado Nuevo: " + chkNivelRiesgo.Checked;
    //        sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblTituloTblsParam.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);
    //        /* FIN: David Alzate 04/09/2017 */

    //        sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblTituloTblsParam.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

    //        LimpiarText();
    //        LlenarDatos();

    //        Response.Write("<script>alert('Nivel de riesgo actualizado')</script>");
    //    }
    //    lvlRiskState = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
    //}
    #endregion

    #region TRM
    //protected void ImgGuardarTRM_Click(object sender, ImageClickEventArgs e)
    //{
    //    Datos sv = new Datos();

    //    sv.Up_TrmDia(int.Parse(Session["IdPais"].ToString()), decimal.Parse(this.txtTRM.Text));

    //    //String DescripcionAudit = "Actualización de TRM del dia: Valor anteriorr: " + this.hdfTRMDia.Value +  ". Nuevo Vaslor del TRM: " + this.txtTRM.Text;

    //    sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblTituloTblsParam.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);
    //    /* FIN: David Alzate 04/09/2017 */


    //    Response.Write("<script>alert('TRM del dia Actualizada')</script>");
    //    lvlRiskState2 = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
    //    LlenarDatos();

    //}
    #endregion

    #region Instancia
    //protected void GridInstancia_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    string index;
    //    Datos sv = new Datos();
    //    DataSet ds = new DataSet();

    //    switch (e.CommandName)
    //    {
    //        case "Editar":
    //            index = Convert.ToString(e.CommandArgument);
    //            ds = sv.SeOpcionesNivRiesgoParam(2, 2, Convert.ToInt32(index));

    //            this.txtInstancia.Text = Convert.ToString(ds.Tables[0].Rows[0]["Instancia"].ToString()).ToString();
    //            this.chkInstancia.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Activo"].ToString());

    //            this.RequiredFieldValidator11.Enabled = false;

    //            hdfInstId.Value = index.ToString();
    //            hdfInstancia.Value = Convert.ToString(ds.Tables[0].Rows[0]["Instancia"]);
    //            hdfInstAct.Value = Convert.ToString(ds.Tables[0].Rows[0]["Activo"]);
    //            hdfInstNueva.Value = "false";

    //            ds.Clear();
    //            lvlRiskState10 = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
    //            break;
    //        default:
    //            break;
    //    }
    //}
    //protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    //{
    //    Datos sv = new Datos();
    //    String DescripcionAudit;

    //    if (hdfInstNueva.Value == "true")
    //    {
    //        sv.InOpcionesNivRiesgo(Convert.ToString(this.txtInstancia.Text), 2, chkInstancia.Checked);

    //        /* INICIO: David Alzate 04/09/2017 - ASUNTO: Se agrega Auditoria para control de movimientos en el aplicativo*/
    //        DescripcionAudit = "Inserción de Nivel Riesgo: Instancia: " + Convert.ToString(this.txtInstancia.Text) + "; Estado: " + Convert.ToString(chkInstancia.Checked);
    //        sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblTituloTblsParam.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);
    //        /* FIN: David Alzate 04/09/2017 */
    //        LimpiarText();
    //        LlenarDatos();

    //        Response.Write("<script>alert(Instancia creada')</script>");
    //    }
    //    else
    //    {
    //        sv.UpOpcionesNivRiesgo(2, Convert.ToInt32(hdfInstId.Value), this.txtInstancia.Text, chkInstancia.Checked);

    //        DescripcionAudit = "Actualización Instancia especial;" +
    //                           " Instancia actual: " + Convert.ToString(txtInstancia.Text) + "; Estado actual: " + Convert.ToString(this.chkInstancia.Checked) +
    //                           " Instancia anterior: " + this.hdfInstancia.Value + "; Estado anterior: " + Convert.ToString(this.hdfInstAct.Value);
    //        sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblTituloTblsParam.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

    //        LimpiarText();
    //        LlenarDatos();
    //        Response.Write("<script>alert('Instancia actualizada')</script>");
    //    }
    //    lvlRiskState10 = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
    //}
    #endregion

    #region Responsables
    //protected void grvResponsables_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    string index;
    //    Datos sv = new Datos();
    //    DataSet ds = new DataSet();

    //    switch (e.CommandName)
    //    {
    //        case "Editar":
    //            index = Convert.ToString(e.CommandArgument);
    //            ds = sv.SeOpcionesNivRiesgoParam(3, 2, Convert.ToInt32(index));

    //            this.txtResponsable.Text = Convert.ToString(ds.Tables[0].Rows[0]["Responsable"].ToString()).ToString();
    //            this.chkResponsable.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Activo"].ToString());

    //            this.RequiredFieldValidator11.Enabled = false;

    //            hdfRespId.Value = index.ToString();
    //            hdfResponsable.Value = Convert.ToString(ds.Tables[0].Rows[0]["Responsable"]);
    //            hdfRespAct.Value = Convert.ToString(ds.Tables[0].Rows[0]["Activo"]);
    //            hdfRespNueva.Value = "false";

    //            ds.Clear();
    //            lvlRiskState11 = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
    //            break;
    //        default:
    //            break;
    //    }
    //}
    //protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    //{
    //    Datos sv = new Datos();
    //    String DescripcionAudit;

    //    if (hdfRespNueva.Value == "true")
    //    {
    //        sv.InOpcionesNivRiesgo(Convert.ToString(this.txtResponsable.Text), 3, chkResponsable.Checked);

    //        /* INICIO: David Alzate 04/09/2017 - ASUNTO: Se agrega Auditoria para control de movimientos en el aplicativo*/
    //        DescripcionAudit = "Inserción de Nivel Riesgo: Responsable: " + Convert.ToString(this.txtResponsable.Text);
    //        sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblTituloTblsParam.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);
    //        /* FIN: David Alzate 04/09/2017 */
    //        LimpiarText();
    //        LlenarDatos();

    //        Response.Write("<script>alert(Responsable creado')</script>");
    //    }
    //    else
    //    {
    //        sv.UpOpcionesNivRiesgo(3, Convert.ToInt32(hdfRespId.Value), this.txtResponsable.Text, chkResponsable.Checked);

    //        DescripcionAudit = "Actualización Responsable;" +
    //                           " Responsable actual: " + Convert.ToString(txtResponsable.Text) + "; Estado actual: " + Convert.ToString(this.chkResponsable.Checked) +
    //                           " Responsable anterior: " + this.hdfResponsable.Value + "; Estado anterior: " + Convert.ToString(this.hdfRespAct.Value);
    //        sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblTituloTblsParam.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

    //        LimpiarText();
    //        LlenarDatos();

    //        Response.Write("<script>alert('Responsable actualizado')</script>");
    //    }
    //    lvlRiskState11 = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
    //}
    #endregion

    #region ParametrosR
    //protected void GridParametrosR_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    string index;
    //    Datos sv = new Datos();
    //    DataSet ds = new DataSet();

    //    switch (e.CommandName)
    //    {
    //        case "Editar":
    //            index = Convert.ToString(e.CommandArgument);
    //            ds = sv.SeParametrosR(2, index);

    //            this.txtR.Text = Convert.ToString(ds.Tables[0].Rows[0]["R"].ToString()).ToString();
    //            this.txtPiso.Text = decimal.Parse(ds.Tables[0].Rows[0]["Piso"].ToString()).ToString();
    //            this.txtTecho.Text = decimal.Parse(ds.Tables[0].Rows[0]["Techo"].ToString()).ToString();

    //            this.rfvTxtR.Enabled = false;
    //            this.rfvTxtPiso.Enabled = false;
    //            this.rfvTxtTecho.Enabled = false;

    //            hdfR.Value = index.ToString();
    //            hdfRPiso.Value = Convert.ToString(ds.Tables[0].Rows[0]["Piso"]);
    //            hdfRTecho.Value = Convert.ToString(ds.Tables[0].Rows[0]["Techo"]);
    //            HRNueva.Value = "false";
    //            ds.Clear();
    //            RParameters = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
    //            break;
    //        case "Eliminar":
    //            index = Convert.ToString(e.CommandArgument);
    //            //sv.UsuarioEliminar(index);



    //            sv.DeParametrosR(index);

    //            String DescripcionAudit = "Eliminación Parametro R: R: " + Convert.ToString(index);
    //            sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblTituloTblsParam.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

    //            LimpiarText();
    //            LlenarDatos();

    //            Response.Write("<script>alert('Parametro Eliminado')</script>");
    //            RParameters = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
    //            break;
    //        default:
    //            break;
    //    }

    //}
    //protected void ImageButton19_Click(object sender, ImageClickEventArgs e)
    //{
    //    Datos sv = new Datos();
    //    String DescripcionAudit;
    //    if (HRNueva.Value == "true")
    //    {
    //        sv.InParametrosR(this.txtR.Text, decimal.Parse(this.txtPiso.Text), decimal.Parse(this.txtTecho.Text));

    //        /* INICIO: David Alzate 04/09/2017 - ASUNTO: Se agrega Auditoria para control de movimientos en el aplicativo*/
    //        DescripcionAudit = "Inserción Parametro R: R: " + Convert.ToString(this.txtR.Text) + ". Piso:" + Convert.ToString(this.txtPiso.Text) + ". Techo:" + Convert.ToString(this.txtTecho.Text);
    //        sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblTituloTblsParam.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);
    //        /* FIN: David Alzate 04/09/2017 */
    //        LimpiarText();
    //        LlenarDatos();

    //        Response.Write("<script>alert('Parametro R creado')</script>");
    //    }
    //    else
    //    {
    //        sv.UpParametrosR(this.hdfR.Value, this.txtR.Text, decimal.Parse(this.txtPiso.Text), decimal.Parse(this.txtTecho.Text));

    //        DescripcionAudit = "Actualización Parametro R." +
    //                           " R actual: " + Convert.ToString(txtR.Text) + ". Piso actual : " + Convert.ToString(this.txtPiso.Text) + ". Techo actual : " + Convert.ToString(this.txtTecho.Text) +
    //                           " R anterior: " + this.hdfR.Value + ". Piso anterior: " + Convert.ToString(this.hdfRPiso.Value) + ". Techo Anterior:" + Convert.ToString(this.hdfRTecho.Value);
    //        sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblTituloTblsParam.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

    //        LimpiarText();
    //        LlenarDatos();

    //        Response.Write("<script>alert('Parametro R Actualizado')</script>");
    //    }
    //    RParameters = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
    //}
    protected void ImageButton20_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarText();
        RParameters = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
    }
    #endregion

    #region Condiciones Especiales
    //protected void grCondicionEsp_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    string index;
    //    Datos sv = new Datos();
    //    DataSet ds = new DataSet();

    //    switch (e.CommandName)
    //    {
    //        case "Editar":
    //            index = Convert.ToString(e.CommandArgument);
    //            ds = sv.SeOpcionesNivRiesgoParam(1, 2, Convert.ToInt32(index));

    //            this.txtCondEspecial.Text = Convert.ToString(ds.Tables[0].Rows[0]["ConEspecial"].ToString()).ToString();
    //            this.chkCondEspecial.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Activo"].ToString());

    //            this.RequiredFieldValidator11.Enabled = false;

    //            hdfCondId.Value = index.ToString();
    //            hdfCondEsp.Value = Convert.ToString(ds.Tables[0].Rows[0]["ConEspecial"]);
    //            hdfCondAct.Value = Convert.ToString(ds.Tables[0].Rows[0]["Activo"]);
    //            hdfCondNueva.Value = "false";

    //            ds.Clear();
    //            lvlRiskState9 = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
    //            break;
    //        default:
    //            break;
    //    }
    //}
    //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    //{
    //    Datos sv = new Datos();
    //    String DescripcionAudit;

    //    if (hdfCondNueva.Value == "true")
    //    {
    //        sv.InOpcionesNivRiesgo(Convert.ToString(this.txtCondEspecial.Text), 1, chkCondEspecial.Checked);

    //        /* INICIO: David Alzate 04/09/2017 - ASUNTO: Se agrega Auditoria para control de movimientos en el aplicativo*/
    //        DescripcionAudit = "Inserción de Nivel Riesgo: Condición especial: " + Convert.ToString(this.txtCondEspecial.Text) + "; Estado: " + Convert.ToString(chkCondEspecial.Checked);
    //        sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblTituloTblsParam.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);
    //        /* FIN: David Alzate 04/09/2017 */
    //        LimpiarText();
    //        LlenarDatos();

    //        Response.Write("<script>alert(Condición especial creada')</script>");
    //    }
    //    else
    //    {
    //        sv.UpOpcionesNivRiesgo(1, Convert.ToInt32(hdfCondId.Value), this.txtCondEspecial.Text, chkCondEspecial.Checked);

    //        DescripcionAudit = "Actualización Condición especial;" +
    //                           " Condición especial actual: " + Convert.ToString(txtCondEspecial.Text) + "; Estado actual: " + Convert.ToString(this.chkCondEspecial.Checked) +
    //                           " Condición especial anterior: " + this.hdfCondEsp.Value + "; Estado anterior: " + Convert.ToString(this.hdfCondAct.Value);
    //        sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblTituloTblsParam.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

    //        LimpiarText();
    //        LlenarDatos();

    //        Response.Write("<script>alert('Condición especial actualizada')</script>");
    //    }
    //    lvlRiskState9 = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
    //}
    #endregion

    #region Divisas
    protected void GridDivisas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index;
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        switch (e.CommandName)
        {
            case "Editar":
                index = int.Parse(e.CommandArgument.ToString());
                ds = sv.DivisaLista(index, 3);
                txtIdDiv.Text = ds.Tables[0].Rows[0]["IdDivisa"].ToString().ToString();
                txtCodDiv.Text = ds.Tables[0].Rows[0]["codigo"].ToString().ToString();
                txtCodUiafDiv.Text = ds.Tables[0].Rows[0]["coduiaf"].ToString().ToString();
                txtDescDiv.Text = ds.Tables[0].Rows[0]["divisa"].ToString().ToString();

                hdfDiv.Value = index.ToString();
                hdfIdDiv.Value = Convert.ToString(ds.Tables[0].Rows[0]["IdDivisa"]);
                hdfCodDiv.Value = Convert.ToString(ds.Tables[0].Rows[0]["codigo"]);
                hdfCodUiafDiv.Value = Convert.ToString(ds.Tables[0].Rows[0]["coduiaf"]);
                hdfDescDiv.Value = Convert.ToString(ds.Tables[0].Rows[0]["divisa"]);

                hdfDivNew.Value = "false";
                ds.Clear();
                ForExchange = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
                break;
            case "Eliminar":
                index = int.Parse(e.CommandArgument.ToString());
                //sv.UsuarioEliminar(index);

                sv.DeParametrosDivisa(index);

                String DescripcionAudit = "Eliminación Parametro Divisa: Id Divisa: " + Convert.ToString(index);
                sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblTituloTblsParam.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

                LimpiarText();
                LlenarDatos();

                Response.Write("<script>alert('Parametro Divisa Eliminado')</script>");
                ForExchange = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
                break;
            default:
                break;
        }

    }
    protected void imgBtnGuardaDiv_Click(object sender, ImageClickEventArgs e)
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();
        String DescripcionAudit;
        if (hdfDivNew.Value == "true")
        {
            ds = sv.DivisaLista(int.Parse(txtIdDiv.Text), 3);
            if (ds.Tables[0].Rows.Count == 0)
            {
                sv.InParametrosDivisa(int.Parse(txtIdDiv.Text), txtCodDiv.Text, int.Parse(txtCodUiafDiv.Text), txtDescDiv.Text);

                /* INICIO: David Alzate 24/06/2020 - ASUNTO: Se agrega Auditoria para control de movimientos en el aplicativo*/
                DescripcionAudit = "Inserción Parametro Divisa: Id Divisa: " + Convert.ToString(txtIdDiv.Text) + ". Código: " +
                    Convert.ToString(txtCodDiv.Text) + ". Código UIAF: " + Convert.ToString(txtCodUiafDiv.Text) + ". Divisa: " + Convert.ToString(txtDescDiv.Text);

                sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblTituloTblsParam.Text,
                    Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);
                /* FIN: David Alzate 24/06/2020 */
                LimpiarText();
                LlenarDatos();

                Response.Write("<script>alert('Parametro Divisa creado')</script>");
            }
            else
            {
                Response.Write("<script>alert('El Id Divisa ya existe')</script>");
            }
        }
        else
        {
            sv.UpParametrosDivisa(int.Parse(txtIdDiv.Text), txtCodDiv.Text, int.Parse(txtCodUiafDiv.Text), txtDescDiv.Text, int.Parse(hdfIdDiv.Value));

            DescripcionAudit = "Actualización Parametro Divisas." +
                               " Id Divisa actual: " + Convert.ToString(txtIdDiv.Text) + ". Código actual : " + Convert.ToString(this.txtCodDiv.Text) +
                               ". Código UIAF actual : " + Convert.ToString(this.txtCodUiafDiv.Text) + ". Divisa actual : " + Convert.ToString(this.txtDescDiv.Text) +

                               " Id Divisa anterior: " + this.hdfIdDiv.Value + ". Código anterior: " + Convert.ToString(this.hdfCodDiv.Value) +
                               ". Código UIAF Anterior:" + Convert.ToString(this.hdfCodUiafDiv.Value) + ". Divisa Anterior:" + Convert.ToString(this.hdfDescDiv.Value);

            sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblTituloTblsParam.Text,
                Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

            LimpiarText();
            LlenarDatos();

            Response.Write("<script>alert('Parametro Divisa Actualizado')</script>");
        }
        ForExchange = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
    }
    protected void imgBtnClearDiv_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarText();
        ForExchange = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
    }
    #endregion

    #region Conversión Divisas    
    int periodoConv = 0;

    protected void btnBuscaConv_Click(object sender, EventArgs e)
    {
        BuscaConversion();
    }

    protected void BuscaConversion()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();
        periodoConv = int.Parse(txtPeriodoDiv.Text);

        ds = sv.SeDivisasXAnio(int.Parse(Session["IdPais"].ToString()), periodoConv, 0, 1);
        GridConvxDivisa.DataSource = ds.Tables[0].DefaultView;
        GridConvxDivisa.DataBind();
        GridConvxDivisa.Visible = true;
        imgBtnGuardaConDiv.Visible = true;
        imgBtnClearConDiv.Visible = true;
        ConvForExchange = "in";
        foreach (GridViewRow row in GridConvxDivisa.Rows)
        {
            TextBox txtConversion = ((TextBox)row.FindControl("txtConversion"));
            txtConversion.Enabled = true;
        }
    }

    protected void GridConvxDivisa_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Datos sv = new Datos();
            DataSet ds = new DataSet();

            int IdDivisa = Convert.ToInt32(GridConvxDivisa.DataKeys[e.Row.RowIndex]["IdDivisa"].ToString());
            TextBox txtConversion = (e.Row.FindControl("txtConversion") as TextBox);
            ImageButton imgBtnEliminaConv = (e.Row.FindControl("imgBtnEliminaConv") as ImageButton);
            ds = sv.SeDivisasXAnio(int.Parse(Session["IdPais"].ToString()), periodoConv, IdDivisa, 2);

            txtConversion.Text = Convert.ToString(ds.Tables[0].Rows[0]["Conversion"].ToString() != "" ? ds.Tables[0].Rows[0]["Conversion"].ToString() : "0");
            if (ds.Tables[0].Rows[0]["Conversion"].ToString() == "") { imgBtnEliminaConv.Visible = false; } else { imgBtnEliminaConv.Visible = true; }
        }
    }

    protected void imgBtnGuardaConDiv_Click(object sender, ImageClickEventArgs e)
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();
        foreach (GridViewRow row in GridConvxDivisa.Rows)
        {
            int IdDivisa = Convert.ToInt32(GridConvxDivisa.DataKeys[row.RowIndex]["IdDivisa"].ToString());
            TextBox txtConversion = ((TextBox)row.FindControl("txtConversion"));
            if (txtPeriodoDiv.Text != "")
            {
                if (txtConversion.Text != "")
                {
                    if (decimal.Parse(txtConversion.Text) != 0)
                    {
                        string Conversion = txtConversion.Text.Trim();
                        Conversion = Conversion.Replace(".", ",").ToString();

                        if (txtConversion.Text.Length == 17 && (!txtConversion.Text.Contains(",")))
                        {
                            Response.Write("<script>alert('Puede ingresar máximo 16 enteros o máximo 8 enteros y 8 decimales separados con una coma')</script>");
                        }
                        else
                        {
                            sv.UpConversionDivisasxPais(int.Parse(Session["IdPais"].ToString()), int.Parse(txtPeriodoDiv.Text), IdDivisa, Convert.ToDecimal(Conversion));
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('Debe ingresar el campo Conversión')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Debe ingresar el periodo')</script>");
            }
            //LimpiarText();
        }        
        Response.Write("<script>alert('Conversión de Divisas Actualizado')</script>");
        BuscaConversion();
        ConvForExchange = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
    }

    protected void GridConvxDivisa_RowCommand(object sender, GridViewCommandEventArgs e)

    {
        int index;
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        switch (e.CommandName)
        {
            case "Eliminar":
                index = int.Parse(e.CommandArgument.ToString());

                if (txtPeriodoDiv.Text != "")
                {
                    ds = sv.DeConvDivisasxAnioPais(int.Parse(Session["IdPais"].ToString()), int.Parse(txtPeriodoDiv.Text), index);

                    if (int.Parse(ds.Tables[0].Rows[0][0].ToString()) == 1)
                    {
                        Response.Write("<script>alert('Conversión de divisa eliminada')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('La conversión de divisa no existe en el sistema')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Debe ingresar el periodo')</script>");
                }
                BuscaConversion();
                ConvForExchange = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
                break;
            default:
                break;
        }
    }

    protected void imgBtnClearConDiv_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarText();

        ConvForExchange = "in";/*Linea para evitar el cierre de la pestaña en la pagina al realizar postback */
    }
    #endregion


    private void LimpiarText()
    {
        //this.txtR.Text = "";
        //this.txtPiso.Text = "";
        //this.txtTecho.Text = "";
        //this.HRNueva.Value = "true";

        //this.rfvTxtR.Enabled = true;
        //this.rfvTxtPiso.Enabled = true;
        //this.rfvTxtTecho.Enabled = true;

        //this.txtCondEspecial.Text = "";
        //this.chkCondEspecial.Checked = false;

        //hdfCondId.Value = "";
        //hdfCondEsp.Value = "";
        //hdfCondAct.Value = "";
        //hdfCondNueva.Value = "true";

        //this.txtInstancia.Text = "";
        //chkInstancia.Checked = false;

        //hdfInstId.Value = "";
        //hdfInstancia.Value = "";
        //hdfInstAct.Value = "";
        //hdfInstNueva.Value = "true";

        //this.txtResponsable.Text = "";
        //chkResponsable.Checked = false;

        //hdfRespId.Value = "";
        //hdfResponsable.Value = "";
        //hdfRespAct.Value = "";
        //hdfRespNueva.Value = "true";

        //txtNivRiesgo.Text = "";
        //txtValRiesgo.Text = "";
        //txtPisoNivRies.Text = "";
        //chkNivelRiesgo.Checked = false;

        //hdfNivRId.Value = "";
        //hdfNivelRiesgo.Value = "";
        //hdfValorAnterior.Value = "";
        //hdfPisoNivRies.Value = "";
        //hdfNivRAct.Value = "";
        //hdfNivelRNuevo.Value = "true";

        txtIdDiv.Text = "";
        txtCodDiv.Text = "";
        txtCodUiafDiv.Text = "";
        txtDescDiv.Text = "";

        hdfDiv.Value = "";
        hdfIdDiv.Value = "";
        hdfCodDiv.Value = "";
        hdfCodUiafDiv.Value = "";
        hdfDescDiv.Value = "";
        hdfDivNew.Value = "true";

        txtPeriodoDiv.Text = "";
        GridConvxDivisa.Visible = false;
        imgBtnGuardaConDiv.Visible = false;
        imgBtnClearConDiv.Visible = false;
    }

}

