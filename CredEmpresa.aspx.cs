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
using System.Text;
using System.IO;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using Encoder = Microsoft.Security.Application.Encoder;

public partial class BencEmpresa : System.Web.UI.Page
{
    DataSet Dscompleto;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            LLenardatos();
            DatosEmpresa();
            ejecutivos();
            accionistas();
            Indicadores();
            Balance();
            PyG();
            BalanceParcial();
            IndicadoresParciales();
            PyGParcial();
            PyGParcialCuentaAnualizada();
            Auditoria();
            //AuditoriasNITANIO();
            LLenarDatos();
            //CargarCPI();
            //CargarCPE();
            //CargarCFinal();
            //CargarCalFinal();
            //CargarCFinanciera();
            AchivosCargue();
            CargarPestanas();
        }
        else
        {
            Dscompleto = (DataSet)ViewState["DscompletoState"];
        }
    }


    protected void cmbDivisa_SelectedIndexChanged(object sender, EventArgs e)
    {
        Indicadores();
        Balance();
        PyG();
        BalanceParcial();
        IndicadoresParciales();
        PyGParcial();
        PyGParcialCuentaAnualizada();
    }


    private void LLenardatos()
    {
        Datos sv = new Datos();

        DataSet ds = new DataSet();

        ds = sv.DivisaLista(0, 1);

        this.cmbDivisa.DataSource = ds.Tables[0].DefaultView;
        this.cmbDivisa.DataTextField = "divisa";
        this.cmbDivisa.DataValueField = "IdDivisa";
        this.cmbDivisa.DataBind();

        this.cmbDivisa.SelectedValue = Session["Divisa"].ToString();

    }


    protected void Page_PreRender(object sender, System.EventArgs e)
    {
        this.ViewState.Add("DscompletoState", Dscompleto);
    }

    protected void CargarPestanas()
    {
        DataSet ds = new DataSet();

        Datos sv = new Datos();
        int Perfil = int.Parse(Session["IdPerfil"].ToString());
        ds = sv.ExistePerfilXPestana(Perfil, 0, 2);
        for (int a = 0; a < ds.Tables[0].Rows.Count; a++)
        {
            if (TabPanel1.ID == Convert.ToString(ds.Tables[0].Rows[a]["Nombre"]))
            {
                TabPanel1.Visible = true;
            }
            //if (TabCualitativa.ID == Convert.ToString(ds.Tables[0].Rows[a]["Nombre"]))
            //{
            //    TabCualitativa.Visible = true;
            //}
            //if (TabCPI.ID == Convert.ToString(ds.Tables[0].Rows[a]["Nombre"]))
            //{
            //    TabCPI.Visible = true;
            //}
            //if (TabCPE.ID == Convert.ToString(ds.Tables[0].Rows[a]["Nombre"]))
            //{
            //    TabCPE.Visible = true;
            //}
            //if (TabPanel4.ID == Convert.ToString(ds.Tables[0].Rows[a]["Nombre"]))
            //{
            //    TabPanel4.Visible = true;
            //}
            if (TabPanel5.ID == Convert.ToString(ds.Tables[0].Rows[a]["Nombre"]))
            {
                TabPanel5.Visible = true;
            }
            if (TabPanel7.ID == Convert.ToString(ds.Tables[0].Rows[a]["Nombre"]))
            {
                TabPanel7.Visible = true;
            }
            if (TabPanel2.ID == Convert.ToString(ds.Tables[0].Rows[a]["Nombre"]))
            {
                TabPanel2.Visible = true;
            }
            if (TabPanel8.ID == Convert.ToString(ds.Tables[0].Rows[a]["Nombre"]))
            {
                TabPanel8.Visible = true;
            }
            if (TabPanel3.ID == Convert.ToString(ds.Tables[0].Rows[a]["Nombre"]))
            {
                TabPanel3.Visible = true;
            }
            //if (TabPanel6.ID == Convert.ToString(ds.Tables[0].Rows[a]["Nombre"]))
            //{
            //    TabPanel6.Visible = true;
            //}
        }

    }

    private void LLenarDatos()
    {
        Datos sv = new Datos();

        DataSet ds = new DataSet();
        DataView vista = new DataView();

        ds = sv.CualitativaSeleccion();
        ds.Tables[0].Rows.Add("-1", "Seleccione>>");
        vista = ds.Tables[0].DefaultView;
        vista.Sort = "IdEncCualitativa ASC";

        //this.CmbCalificacionCualitativa.DataSource = vista;
        //this.CmbCalificacionCualitativa.SelectedValue = "-1";
        //this.CmbCalificacionCualitativa.DataTextField = "NomCualitativa";
        //this.CmbCalificacionCualitativa.DataValueField = "IdEncCualitativa";
        //this.CmbCalificacionCualitativa.DataBind();

        ds.Clear();

        //ds = sv.CredCFinanciera(Encoder.HtmlEncode(Request.QueryString["Nit"]), 1, Convert.ToInt32(Session["IdPais"].ToString()));

        //this.CmbCFinan.DataSource = ds.Tables[0].DefaultView;
        //this.CmbCFinan.DataTextField = "Resul";
        //this.CmbCFinan.DataValueField = "Llave";
        //this.CmbCFinan.DataBind();
        //ds.Clear();

        //if (this.CmbCFinan.Items.Count > 0)
        //{
        //    string index = this.CmbCFinan.SelectedValue;
        //    Char delimiter = ',';
        //    string[] valor = index.Split(delimiter);
        //    CargarCFinancieraDetalle(int.Parse(valor[0]), int.Parse(valor[1]));
        //}

    }

    private void accionistas()
    {
        Datos sv = new Datos();

        DataSet DataS = new DataSet();
        DataS = sv.BencAccionistasEmpresa(Encoder.HtmlEncode(Request.QueryString["Nit"]), 1, Convert.ToInt32(Session["IdPais"].ToString()));


        GridAccionistas.DataSource = DataS.Tables[0].DefaultView;
        GridAccionistas.DataBind();

        DataS.Clear();

    }

    private void DatosEmpresa()
    {
        Datos sv = new Datos();

        DataSet DataS = new DataSet();
        DataS = sv.BencEmpresaDatos(Encoder.HtmlEncode(Request.QueryString["Nit"]), Convert.ToInt32(Session["IdPais"].ToString()));

        this.lbRazon.Text = Convert.ToString(Convert.ToString(DataS.Tables[0].Rows[0]["NIT"] + " - " + DataS.Tables[0].Rows[0]["RazonSocial"]));
        int IdGrupoEm = Convert.ToInt32(DataS.Tables[0].Rows[0]["IdGrupoEm"]);
        //if (IdGrupoEm != 0)
        //{
        //    this.lblGEconomico.Text = Convert.ToString(DataS.Tables[0].Rows[0]["GrupoEmpresarial"]);
        //}
        //else
        //{
        //    this.lblGEconomico.Text = "No compone Grupo Económico";
        //}

        //this.lbApartado.Text = Convert.ToString(DataS.Tables[0].Rows[0]["AA"]);
        this.lbCiudad.Text = Convert.ToString(DataS.Tables[0].Rows[0]["Ciudad"]);
        this.lbCorreo.Text = Convert.ToString(DataS.Tables[0].Rows[0]["Email"]);
        //this.lbFax.Text = Convert.ToString(DataS.Tables[0].Rows[0]["Fax"]);
        this.lbFundacion.Text = Convert.ToString(DataS.Tables[0].Rows[0]["FechaFundacion"]);
        this.lbObjeto.Text = Convert.ToString(DataS.Tables[0].Rows[0]["ObjetoSocial"]);
        this.lbRepresentante.Text = Convert.ToString(DataS.Tables[0].Rows[0]["RepresentanteLegal"]);
        this.lbRevisor.Text = Convert.ToString(DataS.Tables[0].Rows[0]["RevisorFiscal"]);
        //this.lbTelefono.Text = Convert.ToString(DataS.Tables[0].Rows[0]["Telefono"]);
        this.lbSector.Text = Convert.ToString(DataS.Tables[0].Rows[0]["Sector"]);

        this.lbSigla.Text = Convert.ToString(DataS.Tables[0].Rows[0]["Sigla"]);
        this.lbCargo.Text = Convert.ToString(DataS.Tables[0].Rows[0]["Cargo"]);
        this.lbNumMatricula.Text = Convert.ToString(DataS.Tables[0].Rows[0]["NumMatricula"]);
        this.lbWebsite.Text = Convert.ToString(DataS.Tables[0].Rows[0]["Website"]);
        this.lbCiiu.Text = Convert.ToString(DataS.Tables[0].Rows[0]["Ciiu"]);
        this.lbTipoSociedad.Text = Convert.ToString(DataS.Tables[0].Rows[0]["TipoEmpresa"]);
        this.lbFuente.Text = Convert.ToString(DataS.Tables[0].Rows[0]["Fuente"]);
        //  this.lbLey1116.Text = Convert.ToString(DataS.Tables[0].Rows[0]["Concordato"].ToString());

        //if (Convert.ToBoolean(DataS.Tables[0].Rows[0]["Reest"].ToString()))
        //{
        //    this.lbCreReest.Text = "Si";
        //}
        //else
        //{
        //    this.lbCreReest.Text = "No";
        //}

        if (Convert.ToBoolean(DataS.Tables[0].Rows[0]["EsCliente"].ToString()))
        {
            this.lblEsCliente.Text = "Si";
        }
        else
        {
            this.lblEsCliente.Text = "No";
        }

        // this.lbNivRiesgo.Text = Convert.ToString(DataS.Tables[0].Rows[0]["NivelRiego"]);
        //if (DataS.Tables[0].Rows[0]["FechaActualizacion"].ToString() != "")
        //{
        //    this.lblFechaUltR.Text = Convert.ToString(Convert.ToDateTime(DataS.Tables[0].Rows[0]["FechaActualizacion"]).ToShortDateString());
        //}
        //this.lbVRPublicada.Text = Convert.ToString(DataS.Tables[0].Rows[0]["RAnual"]);
        //lblEEFF.Text = Convert.ToString(DataS.Tables[0].Rows[0]["EEFFRPub"]);

        //if (Boolean.Parse(DataS.Tables[0].Rows[0]["ListaClinton"].ToString()))
        //{
        //    this.lbListaClin.Text = "Si";
        //}
        //else
        //{
        //    this.lbListaClin.Text = "No";
        //}

        //if (Boolean.Parse(DataS.Tables[0].Rows[0]["Importador"].ToString()))
        //{
        //    this.lbImportador.Text = "Si";
        //}
        //else
        //{
        //    this.lbImportador.Text = "No";
        //}

        //if (Boolean.Parse(DataS.Tables[0].Rows[0]["Exportador"].ToString()))
        //{
        //    this.lbExportador.Text = "Si";
        //}
        //else
        //{
        //    this.lbExportador.Text = "No";
        //}

        if (int.Parse(Convert.ToString(DataS.Tables[0].Rows[0]["Ley1116"])) > 1)
        {
            this.lbConcordato.Text = Convert.ToString(DataS.Tables[0].Rows[0]["Concordato"].ToString());
            this.lbConcordato.Visible = true;
        }
        else
        {
            this.lbConcordato.Visible = false;
        }

        DataS.Clear();

        DataS = sv.DatosPaisCliente(Convert.ToInt32(Session["IdPais"].ToString()));

        //this.lbFechaLey.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Parse(DataS.Tables[0].Rows[0]["FechaLey1116"].ToString()));
        //this.lbFechaClinto.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Parse(DataS.Tables[0].Rows[0]["FechaOfac"].ToString()));

        DataS.Clear();

    }

    private void ejecutivos()
    {
        Datos sv = new Datos();

        DataSet DataS = new DataSet();
        DataS = sv.BencEjecutivosEmp(Encoder.HtmlEncode(Request.QueryString["Nit"]), 1, Convert.ToInt32(Session["IdPais"].ToString()));

        GridEjecutivos.DataSource = DataS.Tables[0].DefaultView;
        GridEjecutivos.DataBind();

        DataS.Clear();

    }
    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {

        StringBuilder sb = new StringBuilder();
        System.IO.StringWriter sw = new System.IO.StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        Page page = new Page();
        HtmlForm form = new HtmlForm();

        // Deshabilitar la validación de eventos, sólo asp.net 2
        page.EnableEventValidation = false;

        // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
        page.DesignerInitialize();

        page.Controls.Add(form);
        form.Controls.Add(this.GridEjecutivos);

        page.RenderControl(htw);

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=data.xls");
        Response.Charset = "UTF-8";
        Response.ContentEncoding = Encoding.Default;
        Response.Write(sb.ToString());

        ApplicationInstance.CompleteRequest();

    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        exportarexcel(this.GridAccionistas);
    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        exportarexcel(this.GridIndicadores);
    }

    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        exportarexcel(this.GridBalance);
    }

    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {
        exportarexcel(this.GridPyG);
    }

    protected void ImageButton11_Click(object sender, ImageClickEventArgs e)
    {
        exportarexcel(this.GridCuentaAnualiza);
    }
    private void exportarexcel(GridView Grid)
    {

        StringBuilder sb = new StringBuilder();
        System.IO.StringWriter sw = new System.IO.StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        Page page = new Page();
        HtmlForm form = new HtmlForm();

        // Deshabilitar la validación de eventos, sólo asp.net 2
        page.EnableEventValidation = false;

        // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
        page.DesignerInitialize();

        page.Controls.Add(form);
        form.Controls.Add(Grid);

        page.RenderControl(htw);

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=InfEmpresa.xls");
        Response.Charset = "UTF-8";
        Response.ContentEncoding = Encoding.Default;
        Response.Write(sb.ToString());

        ApplicationInstance.CompleteRequest();

    }

    private void Indicadores()
    {
        Datos sv = new Datos();

        DataSet DataS = new DataSet();

        DataS = sv.BencIndicadoresEmpresa(Encoder.HtmlEncode(Request.QueryString["Nit"]), int.Parse(Encoder.HtmlEncode(Request.QueryString["IdSector"])), Convert.ToInt32(Session["IdPais"].ToString()), Convert.ToInt32(this.cmbDivisa.SelectedValue));

        if (DataS.Tables.Count > 0)
        {
            int cuantos = 0;
            int j = 0;
            int i = 0;

            cuantos = DataS.Tables[0].Columns.Count;

            DataTable dt = new DataTable();
            DataRow dr;

            dt.Columns.Add(new DataColumn("INDICADORES", typeof(string)));

            for (i = 6; i < cuantos; i++)
            {
                dt.Columns.Add(new DataColumn(DataS.Tables[0].Columns[i].ColumnName, typeof(string)));
            }

            string titulo = "0";

            for (i = 0; i < DataS.Tables[0].Rows.Count; i++)
            {
                dr = dt.NewRow();
                if (titulo.Trim() != DataS.Tables[0].Rows[i][4].ToString().Trim())
                {
                    dr["INDICADORES"] = DataS.Tables[0].Rows[i][4].ToString().Trim().ToUpper();
                    titulo = DataS.Tables[0].Rows[i][4].ToString().Trim();
                    dt.Rows.Add(dr);
                    dr = dt.NewRow();
                }

                dr["INDICADORES"] = DataS.Tables[0].Rows[i][1];

                for (j = 6; j < cuantos; j++)
                {
                    if (object.ReferenceEquals(DataS.Tables[0].Rows[i][j], DBNull.Value))
                    {
                        dr[DataS.Tables[0].Columns[j].ColumnName] = "-";
                    }
                    else
                    {
                        dr[DataS.Tables[0].Columns[j].ColumnName] = DataS.Tables[0].Rows[i][2].ToString() + String.Format("{0:N}", DataS.Tables[0].Rows[i][j]) + DataS.Tables[0].Rows[i][3].ToString();
                    }
                }
                dt.Rows.Add(dr);
            }

            //Eliminar Columnas Actuales(Opcional):
            GridIndicadores.Columns.Clear();

            GridIndicadores.DataSource = dt;

            GridIndicadores.DataBind();

            if (GridIndicadores.Rows.Count > 0)
            {
                string texto = null;

                GridIndicadores.HeaderRow.HorizontalAlign = HorizontalAlign.Center;

                GridIndicadores.ControlStyle.Font.Size = 10;

                GridIndicadores.Rows[0].ControlStyle.BackColor = System.Drawing.Color.Gray;
                GridIndicadores.Rows[0].ControlStyle.Font.Size = 11;
                GridIndicadores.Rows[0].ControlStyle.Font.Bold = true;

                for (j = 0; j < GridIndicadores.Rows.Count; j++)
                {
                    for (i = 1; i < dt.Columns.Count; i++)
                    {
                        GridIndicadores.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Right;
                    }
                }

                for (i = 0; i < GridIndicadores.Rows.Count; i++)
                {
                    texto = GridIndicadores.Rows[i].Cells[0].Text.Trim();
                    switch (texto)
                    {
                        case "P&G":
                        case "BALANCE":
                        case "ENDEUDAMIENTO":
                        case "EFICIENCIA":
                        case "LIQUIDEZ":
                        case "Z-SCORE":
                        case "COBERTURA":
                            GridIndicadores.Rows[i].ControlStyle.BackColor = System.Drawing.Color.Gray;
                            GridIndicadores.Rows[i].ControlStyle.Font.Size = 11;
                            GridIndicadores.Rows[i].ControlStyle.Font.Bold = true;
                            break;
                    }
                }
            }
        }
        DataS.Clear();

    }

    private void IndicadoresParciales()
    {
        Datos sv = new Datos();

        DataSet DataS = new DataSet();

        DataS = sv.BencIndicadoresParciales(Encoder.HtmlEncode(Request.QueryString["Nit"]), int.Parse(Encoder.HtmlEncode(Request.QueryString["IdSector"])), Convert.ToInt32(Session["IdPais"].ToString()), Convert.ToInt32(this.cmbDivisa.SelectedValue));

        if (DataS.Tables.Count > 0)
        {
            int cuantos = 0;
            int j = 0;
            int i = 0;

            cuantos = DataS.Tables[0].Columns.Count;

            DataTable dt = new DataTable();
            DataRow dr;

            dt.Columns.Add(new DataColumn("INDICADORES", typeof(string)));

            for (i = 6; i < cuantos; i++)
            {
                dt.Columns.Add(new DataColumn(DataS.Tables[0].Columns[i].ColumnName, typeof(string)));
            }

            string titulo = "0";

            for (i = 0; i < DataS.Tables[0].Rows.Count; i++)
            {
                dr = dt.NewRow();
                if (titulo.Trim() != DataS.Tables[0].Rows[i][4].ToString().Trim())
                {
                    dr["INDICADORES"] = DataS.Tables[0].Rows[i][4].ToString().Trim().ToUpper();
                    titulo = DataS.Tables[0].Rows[i][4].ToString().Trim();
                    dt.Rows.Add(dr);
                    dr = dt.NewRow();
                }

                dr["INDICADORES"] = DataS.Tables[0].Rows[i][1];

                for (j = 6; j < cuantos; j++)
                {
                    if (object.ReferenceEquals(DataS.Tables[0].Rows[i][j], DBNull.Value))
                    {
                        dr[DataS.Tables[0].Columns[j].ColumnName] = "-";
                    }
                    else
                    {
                        dr[DataS.Tables[0].Columns[j].ColumnName] = DataS.Tables[0].Rows[i][2].ToString() + String.Format("{0:N}", DataS.Tables[0].Rows[i][j]) + DataS.Tables[0].Rows[i][3].ToString();
                    }
                }
                dt.Rows.Add(dr);
            }

            //Eliminar Columnas Actuales(Opcional):
            GridIndParcial.Columns.Clear();

            GridIndParcial.DataSource = dt;

            GridIndParcial.DataBind();

            if (GridIndParcial.Rows.Count > 0)
            {
                string texto = null;

                GridIndParcial.HeaderRow.HorizontalAlign = HorizontalAlign.Center;

                GridIndParcial.ControlStyle.Font.Size = 10;

                GridIndParcial.Rows[0].ControlStyle.BackColor = System.Drawing.Color.Gray;
                GridIndParcial.Rows[0].ControlStyle.Font.Size = 11;
                GridIndParcial.Rows[0].ControlStyle.Font.Bold = true;

                for (j = 0; j < GridIndParcial.Rows.Count; j++)
                {
                    for (i = 1; i < dt.Columns.Count; i++)
                    {
                        GridIndParcial.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Right;
                    }
                }

                for (i = 0; i < GridIndParcial.Rows.Count; i++)
                {
                    texto = GridIndParcial.Rows[i].Cells[0].Text.Trim();
                    switch (texto)
                    {
                        case "P&G":
                        case "BALANCE":
                        case "ENDEUDAMIENTO":
                        case "EFICIENCIA":
                        case "LIQUIDEZ":
                        case "Z-SCORE":
                        case "COBERTURA":
                            GridIndParcial.Rows[i].ControlStyle.BackColor = System.Drawing.Color.Gray;
                            GridIndParcial.Rows[i].ControlStyle.Font.Size = 11;
                            GridIndParcial.Rows[i].ControlStyle.Font.Bold = true;
                            break;
                    }
                }
            }
        }
        else
        {
            this.TabPanel8.Visible = false;
        }

        DataS.Clear();

    }

    private void IndicadoresCuentasAnualiza()
    {
        Datos sv = new Datos();

        DataSet DataS = new DataSet();

        DataS = sv.BencIndicadoresParciales(Encoder.HtmlEncode(Request.QueryString["Nit"]), int.Parse(Encoder.HtmlEncode(Request.QueryString["IdSector"])), Convert.ToInt32(Session["IdPais"].ToString()), Convert.ToInt32(this.cmbDivisa.SelectedValue));

        if (DataS.Tables.Count > 0)
        {
            int cuantos = 0;
            int j = 0;
            int i = 0;

            cuantos = DataS.Tables[0].Columns.Count;

            DataTable dt = new DataTable();
            DataRow dr;

            dt.Columns.Add(new DataColumn("INDICADORES", typeof(string)));

            for (i = 6; i < cuantos; i++)
            {
                dt.Columns.Add(new DataColumn(DataS.Tables[0].Columns[i].ColumnName, typeof(string)));
            }

            string titulo = "0";

            for (i = 0; i < DataS.Tables[0].Rows.Count; i++)
            {
                dr = dt.NewRow();
                if (titulo.Trim() != DataS.Tables[0].Rows[i][4].ToString().Trim())
                {
                    dr["INDICADORES"] = DataS.Tables[0].Rows[i][4].ToString().Trim().ToUpper();
                    titulo = DataS.Tables[0].Rows[i][4].ToString().Trim();
                    dt.Rows.Add(dr);
                    dr = dt.NewRow();
                }

                dr["INDICADORES"] = DataS.Tables[0].Rows[i][1];

                for (j = 6; j < cuantos; j++)
                {
                    if (object.ReferenceEquals(DataS.Tables[0].Rows[i][j], DBNull.Value))
                    {
                        dr[DataS.Tables[0].Columns[j].ColumnName] = "-";
                    }
                    else
                    {
                        dr[DataS.Tables[0].Columns[j].ColumnName] = DataS.Tables[0].Rows[i][2].ToString() + String.Format("{0:N}", DataS.Tables[0].Rows[i][j]) + DataS.Tables[0].Rows[i][3].ToString();
                    }
                }
                dt.Rows.Add(dr);
            }

            //Eliminar Columnas Actuales(Opcional):
            GridIndParcial.Columns.Clear();

            GridIndParcial.DataSource = dt;

            GridIndParcial.DataBind();

            if (GridIndParcial.Rows.Count > 0)
            {
                string texto = null;

                GridIndParcial.HeaderRow.HorizontalAlign = HorizontalAlign.Center;

                GridIndParcial.ControlStyle.Font.Size = 10;

                GridIndParcial.Rows[0].ControlStyle.BackColor = System.Drawing.Color.Gray;
                GridIndParcial.Rows[0].ControlStyle.Font.Size = 11;
                GridIndParcial.Rows[0].ControlStyle.Font.Bold = true;

                for (j = 0; j < GridIndParcial.Rows.Count; j++)
                {
                    for (i = 1; i < dt.Columns.Count; i++)
                    {
                        GridIndParcial.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Right;
                    }
                }

                for (i = 0; i < GridIndParcial.Rows.Count; i++)
                {
                    texto = GridIndParcial.Rows[i].Cells[0].Text.Trim();
                    switch (texto)
                    {
                        case "P&G":
                        case "BALANCE":
                        case "ENDEUDAMIENTO":
                        case "EFICIENCIA":
                        case "LIQUIDEZ":
                        case "Z-SCORE":
                        case "COBERTURA":
                            GridIndParcial.Rows[i].ControlStyle.BackColor = System.Drawing.Color.Gray;
                            GridIndParcial.Rows[i].ControlStyle.Font.Size = 11;
                            GridIndParcial.Rows[i].ControlStyle.Font.Bold = true;
                            break;
                    }
                }
            }
        }
        else
        {
            this.TabPanel8.Visible = false;
        }

        DataS.Clear();

    }

    //private void AuditoriasNITANIO()
    //{
    //    Datos sv = new Datos();

    //    DataSet DataS = new DataSet();
    //    DataS = sv.BencBalanceAuditados(1);
    //    GridAuditado.DataSource = DataS;
    //    GridAuditado.DataBind();
    //    DataS.Clear();

    //    DataS = sv.BencBalanceAuditados(2);
    //    GridAuditadoPar.DataSource = DataS;
    //    GridAuditadoPar.DataBind();
    ////    DataS.Clear();
    //}


    private void Balance()
    {
        Datos sv = new Datos();

        DataSet DataS = new DataSet();

        DataS = sv.BencBalancePyG(Encoder.HtmlEncode(Request.QueryString["Nit"]), 1, Convert.ToInt32(Session["IdPais"].ToString()), Convert.ToInt32(this.cmbDivisa.SelectedValue));

        if (DataS.Tables.Count > 0)
        {

            int cuantos = 0;
            int j = 0;
            int i = 0;

            cuantos = DataS.Tables[0].Columns.Count;

            DataTable dt = new DataTable();
            DataRow dr;

            dt.Columns.Add(new DataColumn("BALANCE GENERAL", typeof(string)));

            for (i = 3; i < cuantos; i++)
            {
                dt.Columns.Add(new DataColumn(DataS.Tables[0].Columns[i].ColumnName, typeof(string)));
            }

            for (i = 0; i < DataS.Tables[0].Rows.Count; i++)
            {
                dr = dt.NewRow();
                dr["BALANCE GENERAL"] = DataS.Tables[0].Rows[i][1];

                for (j = 3; j < cuantos; j++)
                {
                    if (object.ReferenceEquals(DataS.Tables[0].Rows[i][j], DBNull.Value))
                    {
                        dr[DataS.Tables[0].Columns[j].ColumnName] = "-";
                    }
                    else
                    {
                        dr[DataS.Tables[0].Columns[j].ColumnName] = String.Format("{0:N}", DataS.Tables[0].Rows[i][j]);
                    }
                }
                dt.Rows.Add(dr);
            }

            GridBalance.Columns.Clear();

            GridBalance.DataSource = dt;

            GridBalance.DataBind();

            if (GridBalance.Rows.Count > 0)
            {
                GridBalance.HeaderRow.HorizontalAlign = HorizontalAlign.Center;

                GridBalance.ControlStyle.Font.Size = 10;

                for (j = 0; j < GridBalance.Rows.Count; j++)
                {
                    for (i = 1; i < dt.Columns.Count; i++)
                    {
                        GridBalance.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Right;
                    }
                }

                string texto = null;
                for (i = 0; i < GridBalance.Rows.Count; i++)
                {
                    texto = GridBalance.Rows[i].Cells[0].Text.Trim();
                    switch (texto)
                    {
                        case "Inventarios":
                        case "SUBTOTAL DISPONIBLE":
                        case "SUBTOTAL INVERSIONES":
                        case "SUBTOTAL DEUDORES COMERCIALES":
                        case "SUBTOTAL CUENTAS POR COBRAR":
                        case "SUBTOTAL DIFERIDOS":
                        case "SUBTOTAL OTROS ACTIVOS CORRIENTES":
                        case "SUBTOTAL PLANTA Y EQUIPO":
                        case "SUBTOTAL DEUDORES (L.P.)":
                        case "SUBTOTAL INVERSIONES (L.P.)":
                        case "SUBTOTAL DIFERIDO":
                        case "SUBTOTAL INTANGIBLES":
                        case "SUBTOTAL OTROS ACTIVOS":
                        case "SUBTOTAL VALORIZACIONES":
                        case "SUBTOTAL OBLIGACIONES FINANCIERAS":
                        case "SUBTOTAL PROVEEDORES":
                        case "SUBTOTAL CUENTAS POR PAGAR":
                        case "SUBTOTAL IMPUESTOS GRAVAMENES Y TASAS":
                        case "SUBTOTAL OBLIGACIONES LABORALES":
                        case "SUBTOTAL ESTIMADOS Y PROVISIONES":
                        case "SUBTOTAL OTROS PASIVOS CORRIENTES":
                        case "SUBTOTAL OBLIGACIONES FINANCIERAS (L.P.)":
                        case "SUBTOTAL CUENTAS POR PAGAR (L.P.)":
                        case "SUBTOTAL OTROS PASIVOS L.P.":
                        case "SUBTOTAL CAPITAL SOCIAL":
                        case "SUBTOTAL SUPERAVIT DE CAPITAL":
                        case "SUBTOTAL RESERVAS":
                        case "SUBTOTAL REVALORIZACIONES":
                        case "DIVIDEN O PARTC. DECRETADAS EN ACC.O CUOTAS":
                        case "RESULTADOS DEL EJERCICIO":
                        case "RESULTADOS DE EJERCICIOS ANTERIORES":
                        case "SUPERAVIT POR VALORIZACIONES":
                        case "TOTAL CUENTAS DE ORDEN":
                            GridBalance.Rows[i].ControlStyle.BackColor = System.Drawing.Color.Gainsboro;
                            GridBalance.Rows[i].ControlStyle.Font.Size = 10;
                            //GridBalance.Rows[i].ControlStyle.Font.Bold = true;
                            break;
                        case "TOTAL ACTIVO CORRIENTE":
                        case "TOTAL ACTIVO NO CORRIENTE":
                        case "TOTAL PASIVO CORRIENTE":
                        case "TOTAL PASIVO LARGO PLAZO":
                            GridBalance.Rows[i].ControlStyle.BackColor = System.Drawing.Color.Gainsboro;
                            GridBalance.Rows[i].ControlStyle.Font.Size = 10;
                            GridBalance.Rows[i].ControlStyle.Font.Bold = true;
                            break;
                        case "TOTAL ACTIVO":
                        case "TOTAL PASIVO":
                        case "TOTAL PATRIMONIO":
                        case "TOTAL PASIVO Y PATRIMONIO":
                            GridBalance.Rows[i].ControlStyle.BackColor = System.Drawing.Color.Gray;
                            GridBalance.Rows[i].ControlStyle.Font.Size = 10;
                            GridBalance.Rows[i].ControlStyle.Font.Bold = true;
                            break;
                    }
                }
            }
        }
        DataS.Clear();

    }

    protected void GridBalance_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet dsAnioAudit = new DataSet();
        Datos sv = new Datos();
        if (e.Row.RowType == DataControlRowType.Header)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                int esnumero = 0;
                if (int.TryParse(e.Row.Cells[i].Text.ToString(), out esnumero))
                {
                    dsAnioAudit = sv.CredNitAnioAuditado(Encoder.HtmlEncode(Request.QueryString["Nit"]), Convert.ToInt32(Session["IdPais"].ToString()), Convert.ToInt32(e.Row.Cells[i].Text));
                    if (dsAnioAudit.Tables.Count > 0)
                    {
                        if (dsAnioAudit.Tables[0].Rows.Count > 0)
                        {
                            if (Int32.Parse(dsAnioAudit.Tables[0].Rows[0]["TipoAuditado"].ToString()) == 3)
                            {
                                e.Row.Cells[i].Text = e.Row.Cells[i].Text + " (No Au)";
                                e.Row.Cells[i].ToolTip = dsAnioAudit.Tables[0].Rows[0]["NomTipoAuditado"].ToString();

                            }
                            else
                            {
                                e.Row.Cells[i].Text = e.Row.Cells[i].Text + " (Au)";
                                e.Row.Cells[i].ToolTip = dsAnioAudit.Tables[0].Rows[0]["NomTipoAuditado"].ToString();
                            }
                        }
                    }
                }
            }
        }
    }
       
    private void PyG()
    {
        Datos sv = new Datos();

        DataSet DataS = new DataSet();
        DataS = sv.BencBalancePyG(Encoder.HtmlEncode(Request.QueryString["Nit"]), 0, Convert.ToInt32(Session["IdPais"].ToString()), Convert.ToInt32(this.cmbDivisa.SelectedValue));
        if (DataS.Tables.Count > 0)
        {

            int cuantos = 0;
            int j = 0;
            int i = 0;

            cuantos = DataS.Tables[0].Columns.Count;

            DataTable dt = new DataTable();
            DataRow dr;

            dt.Columns.Add(new DataColumn("ESTADO DE RESULTADOS", typeof(string)));

            for (i = 3; i < cuantos; i++)
            {
                dt.Columns.Add(new DataColumn(DataS.Tables[0].Columns[i].ColumnName, typeof(string)));
            }

            for (i = 0; i < DataS.Tables[0].Rows.Count; i++)
            {
                dr = dt.NewRow();

                dr["ESTADO DE RESULTADOS"] = DataS.Tables[0].Rows[i][1];

                for (j = 3; j < cuantos; j++)
                {
                    if (object.ReferenceEquals(DataS.Tables[0].Rows[i][j], DBNull.Value))
                    {
                        dr[DataS.Tables[0].Columns[j].ColumnName] = "-";
                    }
                    else
                    {
                        dr[DataS.Tables[0].Columns[j].ColumnName] = String.Format("{0:N}", DataS.Tables[0].Rows[i][j]);
                    }
                }
                dt.Rows.Add(dr);
            }

            GridPyG.Columns.Clear();
            GridPyG.DataSource = dt;
            GridPyG.DataBind();

            if (GridPyG.Rows.Count > 0)
            {
                GridPyG.HeaderRow.HorizontalAlign = HorizontalAlign.Center;
                GridPyG.ControlStyle.Font.Size = 10;

                for (j = 0; j < GridPyG.Rows.Count; j++)
                {
                    for (i = 1; i < dt.Columns.Count; i++)
                    {
                        GridPyG.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Right;
                    }
                }

                string texto = null;
                for (i = 0; i < GridPyG.Rows.Count; i++)
                {
                    texto = GridPyG.Rows[i].Cells[0].Text.Trim();
                    switch (texto)
                    {
                        case "Ventas Netas":
                        case "COSTOS":
                        case "SUBTOTAL GASTOS OP. ADMON.":
                        case "SUBTOTAL GASTOS OP. VENTAS":
                        case "SUBTOTAL OTROS INGRESOS NO OPERAC.":
                        case "Financieros - Intereses":
                        case "SUBTOTAL OTROS GASTOS NO OPERAC.":
                        case "Corrección Monetaria":
                        case "Menos Provisión Impuesto":
                            GridPyG.Rows[i].ControlStyle.BackColor = System.Drawing.Color.Gainsboro;
                            GridPyG.Rows[i].ControlStyle.Font.Size = 10;
                            GridPyG.Rows[i].ControlStyle.Font.Bold = true;
                            break;
                        case "UTILIDAD BRUTA":
                        case "UTILIDAD OPERACIONAL":
                        case "UTILIDAD NETA ANTES DE IMPUESTOS":
                        case "GANANCIAS ó PERDIDAS":
                            GridPyG.Rows[i].ControlStyle.BackColor = System.Drawing.Color.Gray;
                            GridPyG.Rows[i].ControlStyle.Font.Size = 10;
                            GridPyG.Rows[i].ControlStyle.Font.Bold = true;
                            break;
                    }
                }
            }

        }
        DataS.Clear();

    }

    private void BalanceParcial()
    {
        Datos sv = new Datos();

        DataSet DataS = new DataSet();
        DataS = sv.BencBalancePyGParcial(Encoder.HtmlEncode(Request.QueryString["Nit"]), 1, Convert.ToInt32(Session["IdPais"].ToString()), Convert.ToInt32(this.cmbDivisa.SelectedValue));

        if (DataS.Tables[0].Rows.Count > 0)
        {
            int cuantos = 0;
            int j = 0;
            int i = 0;

            cuantos = DataS.Tables[0].Columns.Count;

            DataTable dt = new DataTable();
            DataRow dr;

            dt.Columns.Add(new DataColumn("BALANCE GENERAL", typeof(string)));

            for (i = 3; i < cuantos; i++)
            {
                dt.Columns.Add(new DataColumn(DataS.Tables[0].Columns[i].ColumnName, typeof(string)));
            }

            for (i = 0; i < DataS.Tables[0].Rows.Count; i++)
            {
                dr = dt.NewRow();
                dr["BALANCE GENERAL"] = DataS.Tables[0].Rows[i][1];

                for (j = 3; j < cuantos; j++)
                {
                    if (object.ReferenceEquals(DataS.Tables[0].Rows[i][j], DBNull.Value))
                    {
                        dr[DataS.Tables[0].Columns[j].ColumnName] = "-";
                    }
                    else
                    {
                        dr[DataS.Tables[0].Columns[j].ColumnName] = String.Format("{0:N}", DataS.Tables[0].Rows[i][j]);
                    }
                }
                dt.Rows.Add(dr);
            }

            GridBalanceParcial.Columns.Clear();
            GridBalanceParcial.DataSource = dt;
            GridBalanceParcial.DataBind();

            if (GridBalanceParcial.Rows.Count > 0)
            {
                GridBalanceParcial.HeaderRow.HorizontalAlign = HorizontalAlign.Center;
                GridBalanceParcial.ControlStyle.Font.Size = 10;

                for (j = 0; j < GridBalanceParcial.Rows.Count; j++)
                {
                    for (i = 1; i < dt.Columns.Count; i++)
                    {
                        GridBalanceParcial.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Right;
                    }
                }

                string texto = null;
                for (i = 0; i < GridBalanceParcial.Rows.Count; i++)
                {
                    texto = GridBalanceParcial.Rows[i].Cells[0].Text.Trim();
                    switch (texto)
                    {
                        case "SUBTOTAL DISPONIBLE":
                        case "TOTAL DEUDORES COMERCIALES":
                        case "TOTAL OTROS DEUDORES":
                        case "SUBTOTAL INVENTARIOS":
                        case "SUBTOTAL DIFERIDO":
                        case "SUBTOTAL CUENTAS POR PAGAR":
                        case "IMPUESTOS GRAVAMENES Y TASAS":
                        case "OBLIGACIONES LABORALES":
                        case "SUBTOTAL PASIVOS ESTIMAD. Y PROVIS.":
                        case "SUBTOTAL OTROS PASIVOS":
                        case "SUBTOTAL BONOS Y PAPELES COMERCIA.":
                        case "SUBTOTAL CAPITAL SOCIAL":
                        case "SUBTOTAL SUPERAVIT DE CAPITAL":
                        case "RESERVAS":
                        case "REVALORIZACION DEL PATRIMONIO":
                        case "DIVIDEN. O PARTC. DECRET. EN ACC.O CUOTAS":
                        case "RESULTADOS DEL EJERCICIO":
                        case "RESULTADOS DE EJERCICIOS ANTERIORES":
                        case "SUPERAVIT POR VALORIZACIONES":
                        case "INVERSIONES":
                        case "DIFERIDOS":
                            GridBalanceParcial.Rows[i].ControlStyle.BackColor = System.Drawing.Color.Gainsboro;
                            GridBalanceParcial.Rows[i].ControlStyle.Font.Size = 10;
                            //GridBalance.Rows[i].ControlStyle.Font.Bold = true;
                            break;
                        case "TOTAL ACTIVO CORRIENTE":
                        case "TOTAL ACTIVO NO CORRIENTE":
                        case "TOTAL PASIVO CORRIENTE":
                        case "TOTAL PASIVO NO CORRIENTE":
                            GridBalanceParcial.Rows[i].ControlStyle.BackColor = System.Drawing.Color.Gainsboro;
                            GridBalanceParcial.Rows[i].ControlStyle.Font.Size = 10;
                            GridBalanceParcial.Rows[i].ControlStyle.Font.Bold = true;
                            break;
                        case "TOTAL ACTIVO":
                        case "TOTAL PASIVO":
                        case "TOTAL PATRIMONIO":
                        case "TOTAL PASIVO Y PATRIMONIO":
                            GridBalanceParcial.Rows[i].ControlStyle.BackColor = System.Drawing.Color.Gray;
                            GridBalanceParcial.Rows[i].ControlStyle.Font.Size = 10;
                            GridBalanceParcial.Rows[i].ControlStyle.Font.Bold = true;
                            break;
                    }
                }
            }
        }
        else
        {
            this.TabPanel2.Visible = false;
        }
        DataS.Clear();

    }

    /*protected void GridBalanceParcial_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet dsAnioAudit = new DataSet();
        Datos sv = new Datos();
        if (e.Row.RowType == DataControlRowType.Header)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                int esnumero = 0;
                if (int.TryParse(e.Row.Cells[i].Text.ToString(), out esnumero))
                {
                    dsAnioAudit = sv.CredNitAnioAuditado(Encoder.HtmlEncode(Request.QueryString["Nit"]), Convert.ToInt32(Session["IdPais"].ToString()), Convert.ToInt32(e.Row.Cells[i].Text));
                    if (dsAnioAudit.Tables.Count > 0)
                    {
                        if (dsAnioAudit.Tables[0].Rows.Count > 0)
                        {
                            if (bool.Parse(dsAnioAudit.Tables[0].Rows[0]["Auditado"].ToString()) == true)
                            {
                                e.Row.Cells[i].Text = e.Row.Cells[i].Text + " (Au)";
                                e.Row.Cells[i].ToolTip = "Auditado";
                            }
                            else
                            {
                                e.Row.Cells[i].Text = e.Row.Cells[i].Text + " (No Au)";
                                e.Row.Cells[i].ToolTip = "No Auditado";
                            }
                        }
                    }
                }
            }
        }
    }*/

    private void PyGParcial()
    {
        Datos sv = new Datos();

        DataSet DataS = new DataSet();
        DataS = sv.BencBalancePyGParcial(Encoder.HtmlEncode(Request.QueryString["Nit"]), 0, Convert.ToInt32(Session["IdPais"].ToString()), Convert.ToInt32(this.cmbDivisa.SelectedValue));

        if (DataS.Tables[0].Rows.Count > 0)
        {
            int cuantos = 0;
            int j = 0;
            int i = 0;

            cuantos = DataS.Tables[0].Columns.Count;

            DataTable dt = new DataTable();
            DataRow dr;

            dt.Columns.Add(new DataColumn("ESTADO DE RESULTADOS", typeof(string)));

            for (i = 3; i < cuantos; i++)
            {
                dt.Columns.Add(new DataColumn(DataS.Tables[0].Columns[i].ColumnName, typeof(string)));
            }

            for (i = 0; i < DataS.Tables[0].Rows.Count; i++)
            {
                dr = dt.NewRow();
                dr["ESTADO DE RESULTADOS"] = DataS.Tables[0].Rows[i][1];

                for (j = 3; j < cuantos; j++)
                {
                    if (object.ReferenceEquals(DataS.Tables[0].Rows[i][j], DBNull.Value))
                    {
                        dr[DataS.Tables[0].Columns[j].ColumnName] = "-";
                    }
                    else
                    {
                        dr[DataS.Tables[0].Columns[j].ColumnName] = String.Format("{0:N}", DataS.Tables[0].Rows[i][j]);
                    }
                }
                dt.Rows.Add(dr);
            }

            GridPyGParcial.Columns.Clear();
            GridPyGParcial.DataSource = dt;
            GridPyGParcial.DataBind();

            if (GridPyGParcial.Rows.Count > 0)
            {
                GridPyGParcial.HeaderRow.HorizontalAlign = HorizontalAlign.Center;
                GridPyGParcial.ControlStyle.Font.Size = 10;

                for (j = 0; j < GridPyGParcial.Rows.Count; j++)
                {
                    for (i = 1; i < dt.Columns.Count; i++)
                    {
                        GridPyGParcial.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Right;
                    }
                }

                string texto = null;
                for (i = 0; i < GridPyGParcial.Rows.Count; i++)
                {
                    texto = GridPyGParcial.Rows[i].Cells[0].Text.Trim();
                    switch (texto)
                    {
                        case "UTILIDAD BRUTA":
                        case "UTILIDAD OPERACIONAL":
                        case "UTILIDAD ANTES DE IMPUESTOS Y AJUSTES X INFLACION":
                            GridPyGParcial.Rows[i].ControlStyle.BackColor = System.Drawing.Color.Gainsboro;
                            GridPyGParcial.Rows[i].ControlStyle.Font.Size = 10;
                            GridPyGParcial.Rows[i].ControlStyle.Font.Bold = true;
                            break;
                        case "GANANCIAS Y PERDIDAS":
                            GridPyGParcial.Rows[i].ControlStyle.BackColor = System.Drawing.Color.Gray;
                            GridPyGParcial.Rows[i].ControlStyle.Font.Size = 10;
                            GridPyGParcial.Rows[i].ControlStyle.Font.Bold = true;
                            break;
                    }
                }
            }
        }
        DataS.Clear();

    }

    protected void ImageButton25_Click(object sender, ImageClickEventArgs e)
    {
        DescargarArchivo(Encoder.HtmlEncode(Request.QueryString["Nit"]));
    }

    private void DescargarArchivo(String NITDescarga)
    {

        Funciones fun = new Funciones();
        string filename;
        string path = Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Archivos\Modelo\" + Session["IdPais"].ToString() + @"\";
        filename = "Modelo" + NITDescarga + "_" + Session["IDusuario"].ToString() + ".xlsm";

        string targetPath = path + "Generados\\";
        string sourceFile = System.IO.Path.Combine(path, "Modelo.xlsm");
        string destFile = System.IO.Path.Combine(targetPath, filename);

        System.IO.File.Copy(sourceFile, destFile, true);

        if (fun.CrearCaratula(NITDescarga, destFile, true, Convert.ToInt32(Session["IdPais"].ToString()), Convert.ToInt32(this.cmbDivisa.SelectedValue), this.cmbDivisa.SelectedItem.ToString(), Session["Pais"].ToString()))
        {
            string filepath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Archivos\" + Session["Carpeta"] + @"\Modelo\" + Session["IdPais"].ToString() + @"\Generados\" + filename;

            FileInfo fi = new FileInfo(filepath);
            long sz = fi.Length;

            filename = "Modelo" + NITDescarga + ".xlsm";
            Response.Clear();
            Response.ClearContent();
            Response.ContentType = "application/vnd.ms-excel.sheet.macroEnabled.12";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.AddHeader("Content-Length", sz.ToString("F0"));
            Response.TransmitFile(filepath);

            Response.Flush();

            ApplicationInstance.CompleteRequest();
        }

    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        exportarexcel(this.GridBalanceParcial);
    }

    protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
    {
        exportarexcel(this.GridAuditoria);
    }

    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        exportarexcel(this.GridPyGParcial);
    }

    protected void ImageButton22_Click1(object sender, ImageClickEventArgs e)
    {
        //exportarexcel(this.GrvSeleccionEncuesta);
    }

    public bool IsPar(int Number)
    {
        if (Number % 2 == 0) return true;
        else
            return false;
    }

    private void Auditoria()
    {
        Datos sv = new Datos();

        DataSet DataS = new DataSet();
        DataS = sv.AuditoriaxNit(Encoder.HtmlEncode(Request.QueryString["Nit"]), Convert.ToInt32(Session["IdPais"].ToString()), 1);

        GridAuditoria.DataSource = DataS.Tables[0].DefaultView;
        GridAuditoria.DataBind();

        DataS.Clear();

    }
    //protected void GrvHistoricoEncuestas_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    Datos sv = new Datos();

    //    DataSet ds = new DataSet();
    //    DataSet dts = new DataSet();
    //    switch (e.CommandName)
    //    {
    //        case "Seleccionar":
    //            long HisEncuesta = Convert.ToInt64(e.CommandArgument);
    //            ds = sv.CualitativaFinal(HisEncuesta);
    //            if (ds.Tables[0].Rows.Count > 0)
    //            {
    //                txtTotalPonderado.Text = Convert.ToString(ds.Tables[0].Rows[0]["Ponderado"]);
    //                GrvSeleccionEncuesta.DataSource = ds.Tables[0].DefaultView;
    //                GrvSeleccionEncuesta.DataBind();

    //                GrvSeleccionEncuesta.Visible = true;
    //                lblTotPon.Visible = true;
    //                txtTotalPonderado.Visible = true;
    //                PanelEncuesta.Visible = true;
    //                ImageButton22.Visible = true;
    //                Label2.Visible = true;
    //                GrvSeleccionEncuesta.Visible = true;
    //            }

    //            break;
    //        default:
    //            break;
    //    }
    //    this.GrvSeleccionEncuesta.Columns[0].Visible = false;
    //    this.GrvSeleccionEncuesta.Columns[1].Visible = true;

    //}

    //protected void CmbCalificacionCualitativa_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DataSet ds = new DataSet();

    //    Datos sv = new Datos();
    //    ds = sv.HistoricoCualitativa(Encoder.HtmlEncode(Request.QueryString["Nit"]).ToString(), int.Parse(CmbCalificacionCualitativa.SelectedValue.ToString()), Convert.ToInt32(Session["IdPais"].ToString()));
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        GrvHistoricoEncuestas.DataSource = ds.Tables[0].DefaultView;
    //        GrvHistoricoEncuestas.DataBind();
    //        ds.Clear();
    //        PanelEncuesta.Visible = true;
    //        GrvSeleccionEncuesta.Visible = false;
    //    }
    //    else
    //    {
    //        ImageButton22.Visible = false;
    //        PanelEncuesta.Visible = false;
    //        GrvSeleccionEncuesta.Visible = false;
    //    }
    //    TabContainer1.ActiveTab = TabContainer1.Tabs[1];

    //}

    //protected void GrvSeleccionEncuesta_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    Decimal Total = Decimal.Parse(txtTotalPonderado.Text.ToString());
    //    if (e.Row.RowType == DataControlRowType.Footer)
    //    {
    //        e.Row.Cells[1].Text = "TOTAL";
    //        e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
    //        e.Row.Cells[2].Text = Total.ToString();
    //        e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
    //        e.Row.Font.Bold = true;
    //    }
    //}

    //CPI
    //protected void CargarCPI()
    //{
    //    Datos sv = new Datos();

    //    DataSet DataS = new DataSet();
    //    DataS = sv.SeCPagoInterno(Encoder.HtmlEncode(Request.QueryString["Nit"]), 1, Convert.ToInt32(Session["IdPais"].ToString()));

    //    GridView1.DataSource = DataS.Tables[0].DefaultView;
    //    GridView1.DataBind();

    //}



    public DataSet FlipDataSet(DataSet my_DataSet)
    {
        DataSet ds = new DataSet();


        foreach (DataTable dt in my_DataSet.Tables)
        {
            DataTable table = new DataTable();
            for (int i = 0; i <= dt.Rows.Count; i++)
            {
                table.Columns.Add(Convert.ToString(i));
            }
            DataRow r = null;
            for (int k = 0; k < dt.Columns.Count; k++)
            {
                r = table.NewRow();
                r[0] = dt.Columns[k].ToString();
                for (int j = 1; j <= dt.Rows.Count; j++)
                    r[j] = dt.Rows[j - 1][k];
                table.Rows.Add(r);
            }
            ds.Tables.Add(table);
        }

        return ds;
    }

    public DataSet FlipDataSet2(DataSet my_DataSet)
    {
        DataSet ds = new DataSet();

        foreach (DataTable dt in my_DataSet.Tables)
        {
            DataTable table = new DataTable();
            for (int i = 0; i <= dt.Rows.Count; i++)
            {
                table.Columns.Add(Convert.ToString(i));
            }
            DataRow r = null;
            for (int k = 0; k < dt.Columns.Count; k++)
            {
                r = table.NewRow();
                r[0] = dt.Columns[k].ToString();
                for (int j = 1; j <= dt.Rows.Count; j++)
                    r[j] = dt.Rows[j - 1][k];
                table.Rows.Add(r);
            }
            ds.Tables.Add(table);
        }

        return ds;
    }


    //protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
    //{
    //    exportarexcel(this.GridView1);
    //}

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
        }
    }

    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Font.Bold = true;
            e.Row.HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
        }
    }

    //CPE
    //protected void CargarCPE()
    //{
    //    Datos sv = new Datos();

    //    DataSet DataS = new DataSet();
    //    DataS = sv.SeCPagoExterno(Encoder.HtmlEncode(Request.QueryString["Nit"]), 1, Convert.ToInt32(Session["IdPais"].ToString()));

    //    GridViewCPE1.DataSource = DataS.Tables[0].DefaultView;
    //    GridViewCPE1.DataBind();

    //}

    //protected void CargarCFinal()
    //{
    //    Datos sv = new Datos();

    //    DataSet DataS = new DataSet();
    //    DataS = sv.CredCFinalPublica(Encoder.HtmlEncode(Request.QueryString["Nit"]), Convert.ToInt32(Session["IdPais"].ToString()));

    //    GridViewCFinal.DataSource = DataS.Tables[0].DefaultView;
    //    GridViewCFinal.DataBind();

    //}

    //protected void CargarCFinanciera()
    //{
    //    Datos sv = new Datos();

    //    DataSet DataS = new DataSet();
    //    DataS = sv.CredCFinanciera(Encoder.HtmlEncode(Request.QueryString["Nit"]), 0, Convert.ToInt32(Session["IdPais"].ToString()));

    //    GridCFinanciera.DataSource = DataS.Tables[0].DefaultView;
    //    GridCFinanciera.DataBind();

    //}

    //protected void CargarCFinancieraDetalle(int anio, int tipo)
    //{
    //    Datos sv = new Datos();

    //    DataSet DataS = new DataSet();
    //    DataS = sv.CredCFinancieraDetalle(Encoder.HtmlEncode(Request.QueryString["Nit"]), anio, tipo, Convert.ToInt32(Session["IdPais"].ToString()));

    //    GridCFinancieraDetalle.DataSource = DataS.Tables[0].DefaultView;
    //    GridCFinancieraDetalle.DataBind();

    //}

    //protected void CmbCFinan_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string index = this.CmbCFinan.SelectedValue;
    //    Char delimiter = ',';
    //    string[] valor = index.Split(delimiter);
    //    CargarCFinancieraDetalle(int.Parse(valor[0]), int.Parse(valor[1]));

    //    TabContainer1.ActiveTab = TabContainer1.Tabs[10];
    //}

    //protected void ImageButton15_Click(object sender, ImageClickEventArgs e)
    //{
    //    exportarexcel(this.GridViewCPE1);
    //}

    //protected void ImageButton16_Click(object sender, ImageClickEventArgs e)
    //{
    //    exportarexcel(this.GridViewCFinal);
    //}

    //protected void ImageButton99_Click(object sender, ImageClickEventArgs e)
    //{
    //    exportarexcel(this.GridView1);
    //}

    protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Datos sv = new Datos();

            DataSet ds = new DataSet();
            DataSet dts = new DataSet();
            int IdGarantias = 0;
            string IdCpInterno = DataBinder.Eval(e.Row.DataItem, "IdCpInterno").ToString();
            Label lblGarantia = (e.Row.FindControl("lblGarantia") as Label);

            ds = sv.SeCPagoInterno(IdCpInterno, 3, Convert.ToInt32(Session["IdPais"].ToString()));
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["IdGarantia"].ToString() != "")
                {
                    IdGarantias = int.Parse(ds.Tables[0].Rows[0]["IdGarantia"].ToString());

                    dts = sv.SelTipGarantias(2, IdGarantias);
                    if (dts.Tables[0].Rows.Count > 0)
                    {
                        lblGarantia.Text = dts.Tables[0].Rows[0]["TipGarantia"].ToString();
                    }
                }
            }

        }
    }

    private void PyGParcialCuentaAnualizada()
    {
        Datos sv = new Datos();

        DataSet DataS = new DataSet();
        DataS = sv.BencBalancePyGCuentaAnualizada(Encoder.HtmlEncode(Request.QueryString["Nit"]), Convert.ToInt32(Session["IdPais"].ToString()), Convert.ToInt32(this.cmbDivisa.SelectedValue));

        if (DataS.Tables[0].Rows.Count > 0)
        {
            int cuantos = 0;
            int j = 0;
            int i = 0;

            cuantos = DataS.Tables[0].Columns.Count;

            DataTable dt = new DataTable();
            DataRow dr;

            dt.Columns.Add(new DataColumn("Cuentas sin anualizar", typeof(string)));

            for (i = 3; i < cuantos; i++)
            {
                dt.Columns.Add(new DataColumn(DataS.Tables[0].Columns[i].ColumnName, typeof(string)));
            }

            for (i = 0; i < DataS.Tables[0].Rows.Count; i++)
            {
                dr = dt.NewRow();
                dr["Cuentas sin anualizar"] = DataS.Tables[0].Rows[i][1];

                for (j = 3; j < cuantos; j++)
                {
                    if (object.ReferenceEquals(DataS.Tables[0].Rows[i][j], DBNull.Value))
                    {
                        dr[DataS.Tables[0].Columns[j].ColumnName] = "-";
                    }
                    else
                    {
                        dr[DataS.Tables[0].Columns[j].ColumnName] = String.Format("{0:N}", DataS.Tables[0].Rows[i][j]);
                    }
                }
                dt.Rows.Add(dr);
            }

            GridCuentaAnualiza.Columns.Clear();
            GridCuentaAnualiza.DataSource = dt;
            GridCuentaAnualiza.DataBind();

            if (GridCuentaAnualiza.Rows.Count > 0)
            {
                GridCuentaAnualiza.HeaderRow.HorizontalAlign = HorizontalAlign.Center;
                GridCuentaAnualiza.ControlStyle.Font.Size = 10;

                for (j = 0; j < GridCuentaAnualiza.Rows.Count; j++)
                {
                    for (i = 1; i < dt.Columns.Count; i++)
                    {
                        GridCuentaAnualiza.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Right;
                    }
                }


            }
        }
        DataS.Clear();

    }

    //protected void CargarCalFinal()
    //{
    //    Datos sv = new Datos();

    //    DataSet DataS = new DataSet();
    //    DataS = sv.CredCalFinal(Encoder.HtmlEncode(Request.QueryString["Nit"]), Convert.ToInt32(Session["IdPais"].ToString()));

    //    gvCalFinal.DataSource = DataS.Tables[0].DefaultView;
    //    gvCalFinal.DataBind();
    //    Dscompleto = new DataSet();
    //    Dscompleto = DataS;


    //    cmbTipoGrafica.Attributes.Add("onchange", "javascript:CambioGrafica();");

    //}

    //protected void gvCalFinal_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    cmbTipoGrafica.SelectedValue = "1";
    //    int index = Convert.ToInt32(e.CommandArgument);
    //    GridViewRow selectedRow = gvCalFinal.Rows[index];

    //    int periodo = int.Parse(gvCalFinal.DataKeys[selectedRow.RowIndex].Values["Anio_Mes"].ToString());
    //    Datos sv = new Datos();
    //    DataSet dsGraficaCalR = new DataSet();
    //    DataSet dsCuantDet = new DataSet();

    //    dsGraficaCalR = Dscompleto;

    //    //DataSet dsCuantDetExiste = new DataSet();

    //    if (int.Parse(gvCalFinal.DataKeys[selectedRow.RowIndex].Values["Anio_Mes"].ToString()) > 0)
    //    {
    //        #region R Anual

    //        if (e.CommandName == "Select_RAnual")
    //        {
    //            #region Grafica Calificacion R
    //            string[] x1 = new string[5];
    //            decimal[] y1 = new decimal[5];
    //            x1[0] = "C. Cualitativa";
    //            x1[1] = "C. Cuantitativa";
    //            x1[2] = "CPI o Veto";
    //            x1[3] = "C. Sector";
    //            x1[4] = "V. Exogenas (Total Suma)";
    //            y1[0] = decimal.Parse(dsGraficaCalR.Tables[0].Rows[selectedRow.RowIndex][11].ToString());
    //            y1[1] = decimal.Parse(dsGraficaCalR.Tables[0].Rows[selectedRow.RowIndex][12].ToString());
    //            y1[2] = decimal.Parse(dsGraficaCalR.Tables[0].Rows[selectedRow.RowIndex][15].ToString());
    //            y1[3] = decimal.Parse(dsGraficaCalR.Tables[0].Rows[selectedRow.RowIndex][16].ToString());
    //            y1[4] = decimal.Parse(dsGraficaCalR.Tables[0].Rows[selectedRow.RowIndex][17].ToString());

    //            Chart1.Series[0].Points.DataBindXY(x1, y1);
    //            Chart1.Series[0].IsValueShownAsLabel = true;
    //            Chart1.Titles.Add("NewTitle");
    //            Chart1.Titles[0].Text = "Calificación R";
    //            Chart1.Titles[0].DockedToChartArea = "";
    //            Chart1.Titles["Title1"].Font = new System.Drawing.Font("Arial", 20F);
    //            Chart1.ChartAreas["ChartArea1"].AxisX2.LineWidth = 0;
    //            Chart1.ChartAreas[0].AxisX.InterlacedColor = System.Drawing.Color.DarkGray;
    //            Chart1.ChartAreas[0].AxisY.InterlacedColor = System.Drawing.Color.DarkGray;
    //            Chart1.ChartAreas[0].AxisY.LineWidth = 0;
    //            Chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
    //            Chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
    //            Chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
    //            Chart1.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
    //            Chart1.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
    //            #endregion

    //            #region Grafica Cuantitativa SE COMENTAREA POR AHORA
    //            /*
    //            for (int fila = 0; fila < gvCalFinal.Rows.Count; fila++)
    //            {
    //                string anio = Convert.ToString(int.Parse(gvCalFinal.DataKeys[fila].Values["Anio_Mes"].ToString()));
    //                dsCuantDet = sv.CredCFinancieraDetalle(Encoder.HtmlEncode(Request.QueryString["Nit"]), int.Parse(anio.Substring(0, anio.Length - 2)), 0);

    //                if (dsCuantDet.Tables[0].Rows.Count > 0)
    //                {
    //                    dsCuantDetExiste = dsCuantDet;
    //                    break;
    //                }
    //            }



    //            string anio = Convert.ToString(periodo);
    //            dsCuantDet = sv.CredCFinancieraDetalle(Encoder.HtmlEncode(Request.QueryString["Nit"]), int.Parse(anio.Substring(0, anio.Length - 2)), 0);

    //            DataRow[] result = dsCuantDetExiste.Tables[0].Select("CodIndicador > 0");

    //            string[] x1 = new string[result.Length];
    //            decimal[] y1 = new decimal[result.Length];

    //            for (int i = 0; i < result.Length; i++)
    //            {
    //                x1[i] = result[i]["Indicador"].ToString();
    //                y1[i] = decimal.Parse(result[i]["Valor"].ToString());
    //            }

    //            Chart2.Series[0].Points.DataBindXY(x1, y1);
    //            Chart2.Series[0].IsValueShownAsLabel = true;
    //            Chart2.Titles.Add("NewTitle");
    //            Chart2.Titles[0].Text = "C. Cuantitativa";
    //            Chart2.Titles[0].DockedToChartArea = "";
    //            Chart2.Titles["Title1"].Font = new System.Drawing.Font("Arial", 20F);
    //            Chart2.ChartAreas["ChartArea1"].AxisX2.LineWidth = 0;
    //            Chart2.ChartAreas[0].AxisX.InterlacedColor = System.Drawing.Color.DarkGray;
    //            Chart2.ChartAreas[0].AxisY.InterlacedColor = System.Drawing.Color.DarkGray;
    //            Chart2.ChartAreas[0].AxisY.LineWidth = 0;
    //            Chart2.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
    //            Chart2.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
    //            Chart2.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
    //            Chart2.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
    //            Chart2.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
    //            Chart2.ChartAreas[0].AxisX.IsLabelAutoFit = false;
    //            Chart2.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
    //            */
    //            #endregion
    //        }
    //        #endregion

    //        #region R Parcial
    //        if (e.CommandName == "Select_RParciales")
    //        {
    //            #region Grafica Calificacion R
    //            string[] x2 = new string[5];
    //            decimal[] y2 = new decimal[5];
    //            x2[0] = "C. Cualitativa";
    //            x2[1] = "C. Cuantitativa";
    //            x2[2] = "CPI o Veto";
    //            x2[3] = "C. Sector";
    //            x2[4] = "V. Exogenas (Total Suma)";
    //            y2[0] = decimal.Parse(dsGraficaCalR.Tables[0].Rows[selectedRow.RowIndex][11].ToString());
    //            y2[1] = decimal.Parse(dsGraficaCalR.Tables[0].Rows[selectedRow.RowIndex][13].ToString());
    //            y2[2] = decimal.Parse(dsGraficaCalR.Tables[0].Rows[selectedRow.RowIndex][15].ToString());
    //            y2[3] = decimal.Parse(dsGraficaCalR.Tables[0].Rows[selectedRow.RowIndex][16].ToString());
    //            y2[4] = decimal.Parse(dsGraficaCalR.Tables[0].Rows[selectedRow.RowIndex][17].ToString());

    //            Chart1.Series[0].Points.DataBindXY(x2, y2);
    //            Chart1.Series[0].IsValueShownAsLabel = true;
    //            Chart1.Titles.Add("NewTitle");
    //            Chart1.Titles[0].Text = "Calificación R";
    //            Chart1.Titles[0].DockedToChartArea = "";
    //            Chart1.Titles["Title1"].Font = new System.Drawing.Font("Arial", 20F);
    //            Chart1.ChartAreas["ChartArea1"].AxisX2.LineWidth = 0;
    //            Chart1.ChartAreas[0].AxisX.InterlacedColor = System.Drawing.Color.DarkGray;
    //            Chart1.ChartAreas[0].AxisY.InterlacedColor = System.Drawing.Color.DarkGray;
    //            Chart1.ChartAreas[0].AxisY.LineWidth = 0;
    //            Chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
    //            Chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
    //            Chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
    //            Chart1.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
    //            Chart1.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
    //            #endregion

    //            #region Cuantitativa SE COMENTAREA POR AHORA YA QUE SE VISUALIZARA EN LA CALIFICACION FINANCIERA
    //            /*
    //            int contador;
    //            for (int fila = 0; fila < gvCalFinal.Rows.Count; fila++)
    //            {
    //                string anio = gvCalFinal.DataKeys[fila].Values["Anio_Mes"].ToString();
    //                contador = int.Parse(anio.Substring(4));
    //                for (int retro = 0; retro < contador; retro++)
    //                {
    //                    int per;
    //                    //string anio = gvCalFinal.DataKeys[fila].Values["Anio_Mes"].ToString();
    //                    if (contador <= 9) { per = int.Parse(anio.Substring(0, anio.Length - 1) + contador); }
    //                    else { per = int.Parse(anio.Substring(0, anio.Length - 2) + contador); }

    //                    dsCuantDet = sv.CredCFinancieraDetalle(Encoder.HtmlEncode(Request.QueryString["Nit"]), per, 1);

    //                    if (dsCuantDet.Tables[0].Rows.Count > 0)
    //                    {
    //                        dsCuantDetExiste = dsCuantDet;
    //                        break;
    //                    }
    //                    else { contador--; }
    //                }

    //                if (dsCuantDetExiste.Tables.Count > 0)
    //                {
    //                    if (dsCuantDetExiste.Tables[0].Rows.Count > 0) { break; }
    //                }
    //            }

    //            #region Grafica Cuantitativa
    //            /*string anio = Convert.ToString(periodo);
    //            dsCuantDet = sv.CredCFinancieraDetalle(Encoder.HtmlEncode(Request.QueryString["Nit"]), periodo, 1);
    //            */
    //            /*
    //            if (dsCuantDetExiste.Tables.Count > 0)
    //            {
    //                DataRow[] result = dsCuantDetExiste.Tables[0].Select("CodIndicador > 0");

    //                string[] x1 = new string[result.Length];
    //                decimal[] y1 = new decimal[result.Length];

    //                for (int i = 0; i < result.Length; i++)
    //                {
    //                    x1[i] = result[i]["Indicador"].ToString();
    //                    y1[i] = decimal.Parse(result[i]["Valor"].ToString());
    //                }

    //                Chart2.Series[0].Points.DataBindXY(x1, y1);
    //                Chart2.Series[0].IsValueShownAsLabel = true;
    //                Chart2.Titles.Add("NewTitle");
    //                Chart2.Titles[0].Text = "C. Cuantitativa";
    //                Chart2.Titles[0].DockedToChartArea = "";
    //                Chart2.Titles["Title1"].Font = new System.Drawing.Font("Arial", 20F);
    //                Chart2.ChartAreas["ChartArea1"].AxisX2.LineWidth = 0;
    //                Chart2.ChartAreas[0].AxisX.InterlacedColor = System.Drawing.Color.DarkGray;
    //                Chart2.ChartAreas[0].AxisY.InterlacedColor = System.Drawing.Color.DarkGray;
    //                Chart2.ChartAreas[0].AxisY.LineWidth = 0;
    //                Chart2.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
    //                Chart2.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
    //                Chart2.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
    //                Chart2.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
    //                Chart2.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
    //                Chart2.ChartAreas[0].AxisX.IsLabelAutoFit = false;
    //                Chart2.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
    //            }
    //            #endregion
    //            */
    //            #endregion
    //        }
    //        #endregion

    //        #region R Parcial Anual
    //        if (e.CommandName == "Select_RParcialAnual")
    //        {
    //            #region Grafica Calificacion R

    //            string[] x3 = new string[5];
    //            decimal[] y3 = new decimal[5];
    //            x3[0] = "C. Cualitativa";
    //            x3[1] = "C. Cuantitativa";
    //            x3[2] = "CPI o Veto";
    //            x3[3] = "C. Sector";
    //            x3[4] = "V. Exogenas (Total Suma)";
    //            y3[0] = decimal.Parse(dsGraficaCalR.Tables[0].Rows[selectedRow.RowIndex][11].ToString());
    //            y3[1] = decimal.Parse(dsGraficaCalR.Tables[0].Rows[selectedRow.RowIndex][14].ToString());
    //            y3[2] = decimal.Parse(dsGraficaCalR.Tables[0].Rows[selectedRow.RowIndex][15].ToString());
    //            y3[3] = decimal.Parse(dsGraficaCalR.Tables[0].Rows[selectedRow.RowIndex][16].ToString());
    //            y3[4] = decimal.Parse(dsGraficaCalR.Tables[0].Rows[selectedRow.RowIndex][17].ToString());

    //            Chart1.Series[0].Points.DataBindXY(x3, y3);
    //            Chart1.Series[0].IsValueShownAsLabel = true;
    //            Chart1.Titles.Add("NewTitle");
    //            Chart1.Titles[0].Text = "Calificación R";
    //            Chart1.Titles[0].DockedToChartArea = "";
    //            Chart1.Titles["Title1"].Font = new System.Drawing.Font("Arial", 20F);
    //            Chart1.ChartAreas["ChartArea1"].AxisX2.LineWidth = 0;
    //            Chart1.ChartAreas[0].AxisX.InterlacedColor = System.Drawing.Color.DarkGray;
    //            Chart1.ChartAreas[0].AxisY.InterlacedColor = System.Drawing.Color.DarkGray;
    //            Chart1.ChartAreas[0].AxisY.LineWidth = 0;
    //            Chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
    //            Chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
    //            Chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
    //            Chart1.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
    //            Chart1.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
    //            #endregion

    //            #region Parcial Cuantitativa SE COMENTAREA POR AHORA YA QUE SE VISUALIZARA EN LA CALIFICACION FINANCIERA
    //            /*
    //            int contador;
    //            for (int fila = 0; fila < gvCalFinal.Rows.Count; fila++)
    //            {
    //                string anio = gvCalFinal.DataKeys[fila].Values["Anio_Mes"].ToString();
    //                contador = int.Parse(anio.Substring(4));

    //                for (int retro = 0; retro < contador; retro++)
    //                {
    //                    int per;
    //                    //string anio = gvCalFinal.DataKeys[fila].Values["Anio_Mes"].ToString();
    //                    if (contador <= 9) { per = int.Parse(anio.Substring(0, anio.Length - 1) + contador); }
    //                    else { per = int.Parse(anio.Substring(0, anio.Length - 2) + contador); }

    //                    dsCuantDet = sv.CredCFinancieraDetalle(Encoder.HtmlEncode(Request.QueryString["Nit"]), per, 2);

    //                    if (dsCuantDet.Tables[0].Rows.Count > 0)
    //                    {
    //                        dsCuantDetExiste = dsCuantDet;
    //                        break;
    //                    }
    //                    else { contador--; }
    //                }

    //                if (dsCuantDetExiste.Tables.Count > 0)
    //                {
    //                    if (dsCuantDetExiste.Tables[0].Rows.Count > 0) { break; }
    //                }
    //            }

    //            #region Grafica Cuantitativa

    //            /*string anio = Convert.ToString(periodo);
    //            dsCuantDet = sv.CredCFinancieraDetalle(Encoder.HtmlEncode(Request.QueryString["Nit"]), periodo, 2);
    //            */
    //            /*
    //            if (dsCuantDetExiste.Tables.Count > 0)
    //            {
    //                DataRow[] result = dsCuantDetExiste.Tables[0].Select("CodIndicador > 0");

    //                string[] x1 = new string[result.Length];
    //                decimal[] y1 = new decimal[result.Length];

    //                for (int i = 0; i < result.Length; i++)
    //                {
    //                    x1[i] = result[i]["Indicador"].ToString();
    //                    y1[i] = decimal.Parse(result[i]["Valor"].ToString());
    //                }

    //                Chart2.Series[0].Points.DataBindXY(x1, y1);
    //                Chart2.Series[0].IsValueShownAsLabel = true;
    //                Chart2.Titles.Add("NewTitle");
    //                Chart2.Titles[0].Text = "C. Cuantitativa";
    //                Chart2.Titles[0].DockedToChartArea = "";
    //                Chart2.Titles["Title1"].Font = new System.Drawing.Font("Arial", 20F);
    //                Chart2.ChartAreas["ChartArea1"].AxisX2.LineWidth = 0;
    //                Chart2.ChartAreas[0].AxisX.InterlacedColor = System.Drawing.Color.DarkGray;
    //                Chart2.ChartAreas[0].AxisY.InterlacedColor = System.Drawing.Color.DarkGray;
    //                Chart2.ChartAreas[0].AxisY.LineWidth = 0;
    //                Chart2.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
    //                Chart2.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
    //                Chart2.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
    //                Chart2.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
    //                Chart2.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
    //                Chart2.ChartAreas[0].AxisX.IsLabelAutoFit = false;
    //                Chart2.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
    //            }
    //            #endregion
    //        */
    //            #endregion
    //        }
    //        #endregion

    //        #region V. Exogenas
    //        dsCuantDet = sv.CredCFinancieraDetalle(Encoder.HtmlEncode(Request.QueryString["Nit"]), periodo, 0, Convert.ToInt32(Session["IdPais"].ToString()));

    //        string[] x0 = new string[6];
    //        decimal[] y0 = new decimal[6];
    //        x0[0] = "Ley 1116";
    //        x0[1] = "Reestructurados";
    //        x0[2] = "Lista Clinton";
    //        x0[3] = "Castigo";
    //        x0[4] = "Segmento";
    //        x0[5] = "Nivel Riesgo";
    //        y0[0] = decimal.Parse(dsGraficaCalR.Tables[0].Rows[selectedRow.RowIndex]["ValorLey1116"].ToString());
    //        y0[1] = decimal.Parse(dsGraficaCalR.Tables[0].Rows[selectedRow.RowIndex]["ValorReest"].ToString());
    //        y0[2] = decimal.Parse(dsGraficaCalR.Tables[0].Rows[selectedRow.RowIndex]["ValorListaClinton"].ToString());
    //        y0[3] = decimal.Parse(dsGraficaCalR.Tables[0].Rows[selectedRow.RowIndex]["ValorCastigo"].ToString());
    //        y0[4] = decimal.Parse(dsGraficaCalR.Tables[0].Rows[selectedRow.RowIndex]["ValorSegmento"].ToString());
    //        y0[5] = decimal.Parse(dsGraficaCalR.Tables[0].Rows[selectedRow.RowIndex]["ValorNivelRiego"].ToString());

    //        Chart3.Series[0].Points.DataBindXY(x0, y0);
    //        Chart3.Series[0].IsValueShownAsLabel = true;
    //        Chart3.Titles.Add("NewTitle");
    //        Chart3.Titles[0].Text = "V. Exogenas";
    //        Chart3.Titles[0].DockedToChartArea = "";
    //        Chart3.Titles["Title1"].Font = new System.Drawing.Font("Arial", 20F);
    //        Chart3.ChartAreas["ChartArea1"].AxisX2.LineWidth = 0;
    //        Chart3.ChartAreas[0].AxisX.InterlacedColor = System.Drawing.Color.DarkGray;
    //        Chart3.ChartAreas[0].AxisY.InterlacedColor = System.Drawing.Color.DarkGray;
    //        Chart3.ChartAreas[0].AxisY.LineWidth = 0;
    //        Chart3.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
    //        Chart3.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
    //        Chart3.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
    //        Chart3.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
    //        Chart3.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
    //        Chart3.ChartAreas[0].AxisX.IsLabelAutoFit = false;
    //        Chart3.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
    //        #endregion

    //        dsCuantDet.Clear();
    //        //dsCuantDetExiste.Clear();
    //    }
    //    TabContainer1.ActiveTab = TabContainer1.Tabs[4];
    //    this.ModalPopupExtender.Show();
    //}

    protected void GridCFinancieraDetalle_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false; // hides the first column
    }

    //protected void imgBtnGrafica_Click(object sender, ImageClickEventArgs e)
    //{
    //    Datos sv = new Datos();
    //    DataSet dsCuantParcialDet = new DataSet();

    //    string index = this.CmbCFinan.SelectedValue;
    //    Char delimiter = ',';
    //    string[] valor = index.Split(delimiter);


    //    if (int.Parse(valor[1]) == 0)
    //    {
    //        #region Anual

    //        dsCuantParcialDet = sv.CredCFinancieraDetalle(Encoder.HtmlEncode(Request.QueryString["Nit"]), int.Parse(valor[0]), int.Parse(valor[1]), Convert.ToInt32(Session["IdPais"].ToString()));

    //        DataRow[] resultAnual = dsCuantParcialDet.Tables[0].Select("CodIndicador > 0");

    //        string[] x1 = new string[resultAnual.Length];
    //        decimal[] y1 = new decimal[resultAnual.Length];

    //        for (int i = 0; i < resultAnual.Length; i++)
    //        {
    //            x1[i] = resultAnual[i]["Indicador"].ToString();
    //            y1[i] = decimal.Parse(resultAnual[i]["Valor"].ToString());
    //        }

    //        Chart2.Series[0].Points.DataBindXY(x1, y1);
    //        Chart2.Series[0].IsValueShownAsLabel = true;
    //        Chart2.Titles.Add("NewTitle");
    //        Chart2.Titles[0].Text = "C. Cuantitativa";
    //        Chart2.Titles[0].DockedToChartArea = "";
    //        Chart2.Titles["Title1"].Font = new System.Drawing.Font("Arial", 20F);
    //        Chart2.ChartAreas["ChartArea1"].AxisX2.LineWidth = 0;
    //        Chart2.ChartAreas[0].AxisX.InterlacedColor = System.Drawing.Color.DarkGray;
    //        Chart2.ChartAreas[0].AxisY.InterlacedColor = System.Drawing.Color.DarkGray;
    //        Chart2.ChartAreas[0].AxisY.LineWidth = 0;
    //        Chart2.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
    //        Chart2.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
    //        Chart2.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
    //        Chart2.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
    //        Chart2.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
    //        Chart2.ChartAreas[0].AxisX.IsLabelAutoFit = false;
    //        Chart2.ChartAreas[0].AxisX.LabelStyle.Angle = 45;

    //        #endregion
    //    }
    //    else if (int.Parse(valor[1]) == 1)
    //    {
    //        #region Parcial Parcial
    //        dsCuantParcialDet = sv.CredCFinancieraDetalle(Encoder.HtmlEncode(Request.QueryString["Nit"]), int.Parse(valor[0]), int.Parse(valor[1]), Convert.ToInt32(Session["IdPais"].ToString()));

    //        if (dsCuantParcialDet.Tables.Count > 0)
    //        {
    //            DataRow[] resultPar = dsCuantParcialDet.Tables[0].Select("CodIndicador > 0");

    //            string[] x1 = new string[resultPar.Length];
    //            decimal[] y1 = new decimal[resultPar.Length];

    //            for (int i = 0; i < resultPar.Length; i++)
    //            {
    //                x1[i] = resultPar[i]["Indicador"].ToString();
    //                y1[i] = decimal.Parse(resultPar[i]["Valor"].ToString());
    //            }

    //            Chart2.Series[0].Points.DataBindXY(x1, y1);
    //            Chart2.Series[0].IsValueShownAsLabel = true;
    //            Chart2.Titles.Add("NewTitle");
    //            Chart2.Titles[0].Text = "C. Cuantitativa";
    //            Chart2.Titles[0].DockedToChartArea = "";
    //            Chart2.Titles["Title1"].Font = new System.Drawing.Font("Arial", 20F);
    //            Chart2.ChartAreas["ChartArea1"].AxisX2.LineWidth = 0;
    //            Chart2.ChartAreas[0].AxisX.InterlacedColor = System.Drawing.Color.DarkGray;
    //            Chart2.ChartAreas[0].AxisY.InterlacedColor = System.Drawing.Color.DarkGray;
    //            Chart2.ChartAreas[0].AxisY.LineWidth = 0;
    //            Chart2.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
    //            Chart2.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
    //            Chart2.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
    //            Chart2.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
    //            Chart2.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
    //            Chart2.ChartAreas[0].AxisX.IsLabelAutoFit = false;
    //            Chart2.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
    //        }
    //        #endregion
    //    }
    //    else
    //    {
    //        #region Parcial Anual

    //        dsCuantParcialDet = sv.CredCFinancieraDetalle(Encoder.HtmlEncode(Request.QueryString["Nit"]), int.Parse(valor[0]), int.Parse(valor[1]), Convert.ToInt32(Session["IdPais"].ToString()));

    //        if (dsCuantParcialDet.Tables.Count > 0)
    //        {
    //            DataRow[] resultParAn = dsCuantParcialDet.Tables[0].Select("CodIndicador > 0");

    //            string[] x1 = new string[resultParAn.Length];
    //            decimal[] y1 = new decimal[resultParAn.Length];

    //            for (int i = 0; i < resultParAn.Length; i++)
    //            {
    //                x1[i] = resultParAn[i]["Indicador"].ToString();
    //                y1[i] = decimal.Parse(resultParAn[i]["Valor"].ToString());
    //            }

    //            Chart2.Series[0].Points.DataBindXY(x1, y1);
    //            Chart2.Series[0].IsValueShownAsLabel = true;
    //            Chart2.Titles.Add("NewTitle");
    //            Chart2.Titles[0].Text = "C. Cuantitativa";
    //            Chart2.Titles[0].DockedToChartArea = "";
    //            Chart2.Titles["Title1"].Font = new System.Drawing.Font("Arial", 20F);
    //            Chart2.ChartAreas["ChartArea1"].AxisX2.LineWidth = 0;
    //            Chart2.ChartAreas[0].AxisX.InterlacedColor = System.Drawing.Color.DarkGray;
    //            Chart2.ChartAreas[0].AxisY.InterlacedColor = System.Drawing.Color.DarkGray;
    //            Chart2.ChartAreas[0].AxisY.LineWidth = 0;
    //            Chart2.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
    //            Chart2.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
    //            Chart2.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
    //            Chart2.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
    //            Chart2.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
    //            Chart2.ChartAreas[0].AxisX.IsLabelAutoFit = false;
    //            Chart2.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
    //        }
    //        #endregion
    //    }

    //    TabContainer1.ActiveTab = TabContainer1.Tabs[10];
    //    this.ModalPopupExtender1.Show();

    //}

    private void AchivosCargue()
    {
        Datos sv = new Datos();
        DataSet DataS = new DataSet();

        DataS = sv.AuditoriaxNit(Request.QueryString["Nit"], Convert.ToInt32(Session["IdPais"].ToString()), 1);

        this.GridCargues.DataSource = DataS.Tables[0].DefaultView;
        this.GridCargues.DataBind();

        DataS.Clear();

    }

    protected void GridArchivos_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        string filename;
        string filepath;


        switch (e.CommandName)
        {


            case "VerArchivoCargues":

                filename = e.CommandArgument.ToString();

                filepath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Archivos\\ModeloHistorico\\" + Request.QueryString["Nit"] + "\\" + filename;


                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                Response.Flush();
                Response.WriteFile(filepath);
                Response.End();
                break;


        }
    }

}

