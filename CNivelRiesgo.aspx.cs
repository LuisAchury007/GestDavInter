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
using System.Data.OleDb;
using System.Drawing;
public partial class CNivelRiesgo : System.Web.UI.Page
{

    DataSet Dscompleto;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IDusuario"] == null)
        {
            Response.Redirect("Salir.aspx");
        }

        if (Page.IsPostBack == false)
        {
            Datos sv = new Datos();
            //if (!sv.ComValidaPaginaPerfil(int.Parse(Session["IdPerfil"].ToString()), Request.Url.Segments[Request.Url.Segments.Length - 1]))
            //{
            //    Response.Redirect("Salir.aspx");
            //}
            CargarCombo();
        }
        else
        {
            Dscompleto = (DataSet)ViewState["DscompletoState"];
        }
    }

    protected void btnSubirValid_Click(object sender, EventArgs e)
    {
        Datos sv = new Datos();
        string ruta;

        ruta = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Archivos\\Carguemo\\";

        //bool existe = Directory.Exists(ruta);
        DirectoryInfo DIR = new DirectoryInfo(ruta);

        if (!DIR.Exists)
        {
            DIR.Create();
        }

        if (FileUpload1.HasFile)
        {
            //try
            //{
            string fileName = Server.HtmlEncode(FileUpload1.FileName);
            string extension = System.IO.Path.GetExtension(fileName);

            switch (extension.ToUpper())
            {
                case ".XLSX":
                    FileUpload1.SaveAs(ruta + FileUpload1.FileName);
                    ValidarAchivo(ruta + FileUpload1.FileName);
                    break;
                default:
                    Response.Write("<script>alert('Debe cargar un archivo de excel')</script>");
                    break;
            }
            /* }
             catch (Exception ex)
             {
                 MsgBox1.ShowMessage("ERROR:  " + ex.Message.ToString());
             }*/
        }
        else
        {
            Response.Write("<script>alert('No ha especificado ningún archivo')</script>");
            return;
        }

    }

    private void ValidarAchivo(string archivo)
    {

        //Boolean existe;
        Int64 NitNoExiste = 0, NitVacio = 0;
        Datos sv = new Datos();
        Funciones fun = new Funciones();
        int valor;

        /*se hace referencia al sistem .data.OLEDB*/
        OleDbConnection CExcel = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivo + ";Extended Properties='Excel 12.0 Macro;HDR=YES'");

        CExcel.Open();

        DataTable dt = CExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

        if (dt != null)
        {
            String[] excelSheets = new String[dt.Rows.Count];
            String HojasBuscar = "T_Cambios_Nivel$";

            int x = 0;
            foreach (DataRow row in dt.Rows)
            {
                excelSheets[x] = row["TABLE_NAME"].ToString();
                x++;
            }

            int cuantos = 0;
            for (int j = 0; j < excelSheets.Length; j++)
            {
                if (excelSheets[j] == HojasBuscar)
                {
                    cuantos++;
                    break;
                }
            }

            CExcel.Close();

            if (cuantos == 1)
            {
                /*se ejecuta la consulta a la hoha de excel*/
                OleDbDataAdapter AdpExcel = new OleDbDataAdapter("select Distinct Nit_9 from [T_Cambios_Nivel$]", CExcel);
                /*se carga el resultadao en el dataset*/
                DataSet DS = new DataSet();
                DS.Tables.Add("Excel");
                AdpExcel.Fill(DS.Tables["Excel"]);

                this.ListValidacion.BackColor = Color.White;
                this.ListValidacion.Items.Clear();
                this.ListValidacion.Visible = false;

                //for (int i = 0; i < DS.Tables["Excel"].Rows.Count; i++)
                //{
                //    existe = sv.CredValidaNitCliente(long.Parse(DS.Tables["Excel"].Rows[i]["Nit_9"].ToString()));

                //    if (existe == false)
                //    {
                //        this.ListValidacion.BackColor = Color.Red;
                //        this.ListValidacion.Visible = true;
                //        this.ListValidacion.Items.Add("La empresa: " + DS.Tables["Excel"].Rows[i]["Nit_9"].ToString() + " No Existe");
                //    }
                //}

                //if (this.ListValidacion.Items.Count == 0)
                //{
                AdpExcel = new OleDbDataAdapter("select Fecha_Actualización, Nit_9,Nombre_Empresa, Id_Nivel_Riesgo,Nivel_Riesgo, Condiciones_Esp, Instancia, Responsable, Observaciones, Fecha_Acta from [T_Cambios_Nivel$]", CExcel);
                /*se carga el resultadao en el dataset*/
                DS.Tables["Excel"].Clear();
                AdpExcel.Fill(DS.Tables["Excel"]);

                //  sv.DeCarNivelRiesgo();

                for (int i = 0; i < DS.Tables["Excel"].Rows.Count; i++)
                {

                    valor = sv.SeValidaCargueNRiesgo(1, int.Parse(DS.Tables["Excel"].Rows[i]["Condiciones_Esp"].ToString()));

                    if (valor == 0)
                    {

                        this.ListValidacion.BackColor = Color.Red;
                        this.ListValidacion.Visible = true;
                        this.ListValidacion.Items.Add("El valor de condiciones especiales para el NIT  " + DS.Tables["Excel"].Rows[i]["Nit_9"].ToString() + " no existe en el sistema ");
                    }

                    valor = sv.SeValidaCargueNRiesgo(2, int.Parse(DS.Tables["Excel"].Rows[i]["Instancia"].ToString()));

                    if (valor == 0)
                    {

                        this.ListValidacion.BackColor = Color.Red;
                        this.ListValidacion.Visible = true;
                        this.ListValidacion.Items.Add("El codigo de Instancia para el NIT  " + DS.Tables["Excel"].Rows[i]["Nit_9"].ToString() + " no existe en el sistema ");
                    }

                    valor = sv.SeValidaCargueNRiesgo(3, int.Parse(DS.Tables["Excel"].Rows[i]["Responsable"].ToString()));

                    if (valor == 0)
                    {

                        this.ListValidacion.BackColor = Color.Red;
                        this.ListValidacion.Visible = true;
                        this.ListValidacion.Items.Add("El codigo de responsable para el NIT  " + DS.Tables["Excel"].Rows[i]["Nit_9"].ToString() + " no existe en el sistema ");
                    }

                    if (valor != 0)
                    {
                        if (DS.Tables["Excel"].Rows[i]["Nit_9"].ToString() == "") { NitVacio = +1; }


                        if (DS.Tables["Excel"].Rows[i]["Fecha_Actualización"].ToString() == "") { NitVacio = +1; }
                        if (DS.Tables["Excel"].Rows[i]["Nit_9"].ToString() == "") { NitVacio = +1; }
                        if (DS.Tables["Excel"].Rows[i]["Id_Nivel_Riesgo"].ToString() == "") { NitVacio = +1; }
                        if (DS.Tables["Excel"].Rows[i]["Condiciones_Esp"].ToString() == "") { NitVacio = +1; }
                        if (DS.Tables["Excel"].Rows[i]["Instancia"].ToString() == "") { NitVacio = +1; }
                        if (DS.Tables["Excel"].Rows[i]["Responsable"].ToString() == "") { NitVacio = +1; }
                        if (DS.Tables["Excel"].Rows[i]["Observaciones"].ToString() == "") { NitVacio = +1; }
                        if (DS.Tables["Excel"].Rows[i]["Fecha_Acta"].ToString() == "") { NitVacio = +1; }

                        if (NitVacio == 0)
                        {
                            NitNoExiste = sv.CPublicaNivelRiesgo(
                                DS.Tables["Excel"].Rows[i]["Fecha_Actualización"].ToString(),
                                DS.Tables["Excel"].Rows[i]["Nit_9"].ToString(),
                                Convert.ToInt32(DS.Tables["Excel"].Rows[i]["Id_Nivel_Riesgo"].ToString()),
                                Convert.ToInt32(DS.Tables["Excel"].Rows[i]["Condiciones_Esp"].ToString()),
                                Convert.ToInt32(DS.Tables["Excel"].Rows[i]["Instancia"].ToString()),
                                Convert.ToInt32(DS.Tables["Excel"].Rows[i]["Responsable"].ToString()),
                                DS.Tables["Excel"].Rows[i]["Observaciones"].ToString(),
                                DS.Tables["Excel"].Rows[i]["Fecha_Acta"].ToString(),
                                1, int.Parse(Session["IDusuario"].ToString()), DateTime.Now, Convert.ToInt32(Session["IdPais"].ToString())/*SE ENVIA 1 PARA EL TIPO DE CARGUE MASIVO*/);

                            sv.Up_EmpresaNivelRiesgo(
                                DS.Tables["Excel"].Rows[i]["Nit_9"].ToString(),
                                Convert.ToInt32(DS.Tables["Excel"].Rows[i]["Id_Nivel_Riesgo"].ToString()), Convert.ToInt32(Session["IdPais"].ToString())
                                );
                        }

                        if (NitNoExiste != 0)
                        {
                            this.ListValidacion.BackColor = Color.Red;
                            this.ListValidacion.Visible = true;
                            this.ListValidacion.Items.Add("La empresa: " + DS.Tables["Excel"].Rows[i]["Nit_9"].ToString() + " No Existe");
                        }

                        if (NitVacio > 0)
                        {
                            this.ListValidacion.BackColor = Color.Red;
                            this.ListValidacion.Visible = true;
                            this.ListValidacion.Items.Add("Hay campos vacios en la fila: " + (i + 2) + " verifique por favor");
                        }

                    }
                }

                String DescripcionAudit = "Actualización de registros por nuevo cargue de Nivel de Riesgo; Modo: MASIVO.";
                sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblTituloCNRiesgo.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);


                if (ListValidacion.Items.Count == 0)
                {
                    Response.Write("<script>alert('Información cargada correctamente')</script>");
                    lnkExportarErrores.Visible = false;
                }
                else
                {
                    Response.Write("<script>alert('Se cargaron solamente los registros validos')</script>");
                    lnkExportarErrores.Visible = true;
                }
                //}
                //else
                //{
                //    Response.Write("<script>alert('Archivo no valido')</script>");
                //}
            }
            else
            {
                Response.Write("<script>alert('Falta la hoja T_Cambios_Nivel')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('El archivo no contiene hojas')</script>");
        }
        //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "newFunc", "return CloseLoader();", true);

    }

    protected void chkActivaNRiesgoManual_CheckedChanged(object sender, EventArgs e)
    {
        if (chkActivaNRiesgoManual.Checked == true)
        {
            PanelNRiesgoManual.Visible = true;
            btnSubirValid.Enabled = false;
        }
        else
        {
            PanelNRiesgoManual.Visible = false;
            btnSubirValid.Enabled = true;
            LimpiarNivelRiesgo();
        }
    }

    protected void LimpiarNivelRiesgo()
    {
        //txtFechaNRi.Text = "";
        txtNitNRi.Text = "";
        cmbNivRiesgo.SelectedValue = "-1";
        CmbCondicionEspecial.SelectedValue = "-1";
        CmbInstancia.SelectedValue = "-1";
        CmbResponsable.SelectedValue = "-1";
        txtObsNRi.Text = "";
        txtFecActaNRi.Text = "";
        GridLista.DataBind();
        //GridLista.Visible = false;
    }

    protected void btnGuardarNRi_Click(object sender, EventArgs e)
    {
        Datos sv = new Datos();

        sv.CPublicaNivelRiesgo(null,
        this.txtNitNRi.Text,
        Convert.ToInt32(this.cmbNivRiesgo.SelectedValue),
        Convert.ToInt32(this.CmbCondicionEspecial.SelectedValue),
        Convert.ToInt32(this.CmbInstancia.SelectedValue),
        Convert.ToInt32(this.CmbResponsable.SelectedValue),
        this.txtObsNRi.Text,
        this.txtFecActaNRi.Text,
        2, int.Parse(Session["IDusuario"].ToString()), DateTime.Now, Convert.ToInt32(Session["IdPais"].ToString())  /*SE ENVIA 2 PARA EL TIPO DE CARGUE MANUAL*/);

        sv.Up_EmpresaNivelRiesgo(
                         this.txtNitNRi.Text,
                          Convert.ToInt32(this.cmbNivRiesgo.SelectedValue), Convert.ToInt32(Session["IdPais"].ToString())
                          );

        String DescripcionAudit = "Actualización registro en cargue de Nivel de Riesgo; Modo: MANUAL para el NIT: " + this.txtNitNRi.Text + "; Observaciones: " + txtObsNRi.Text;
        sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblTituloCNRiesgo.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

        LimpiarNivelRiesgo();

        Response.Write("<script>alert('Información cargada correctamente')</script>");

    }

    protected void CargarCombo()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();
        DataView vista = new DataView();

        ds = sv.tiposNivelRiesgo();
        ds.Tables[0].Rows.Add("-1", " Seleccione");
        vista = ds.Tables[0].DefaultView;
        vista.Sort = "IdNivelRiego ASC";

        this.cmbNivRiesgo.DataSource = vista;
        this.cmbNivRiesgo.SelectedValue = "-1";
        this.cmbNivRiesgo.DataTextField = "NivelRiego";
        this.cmbNivRiesgo.DataValueField = "IdNivelRiego";
        this.cmbNivRiesgo.DataBind();
        ds.Clear();

        ds = sv.SeOpcionesNivRiesgo(1);
        ds.Tables[0].Rows.Add("-1", " Seleccione");
        vista = ds.Tables[0].DefaultView;
        vista.Sort = "IdConEspecial ASC";

        this.CmbCondicionEspecial.DataSource = vista;
        this.CmbCondicionEspecial.SelectedValue = "-1";
        this.CmbCondicionEspecial.DataTextField = "ConEspecial";
        this.CmbCondicionEspecial.DataValueField = "IdConEspecial";
        this.CmbCondicionEspecial.DataBind();
        ds.Clear();

        ds = sv.SeOpcionesNivRiesgo(2);
        ds.Tables[0].Rows.Add("-1", " Seleccione");
        vista = ds.Tables[0].DefaultView;
        vista.Sort = "IdInstancia ASC";

        this.CmbInstancia.DataSource = vista;
        this.CmbInstancia.SelectedValue = "-1";
        this.CmbInstancia.DataTextField = "Instancia";
        this.CmbInstancia.DataValueField = "IdInstancia";
        this.CmbInstancia.DataBind();
        ds.Clear();

        ds = sv.SeOpcionesNivRiesgo(3);
        ds.Tables[0].Rows.Add("-1", " Seleccione");
        vista = ds.Tables[0].DefaultView;
        vista.Sort = "IdResponsable ASC";

        this.CmbResponsable.DataSource = vista;
        this.CmbResponsable.SelectedValue = "-1";
        this.CmbResponsable.DataTextField = "Responsable";
        this.CmbResponsable.DataValueField = "IdResponsable";
        this.CmbResponsable.DataBind();
        ds.Clear();

    }

    protected void lnkExportarErrores_Click(object sender, EventArgs e)
    {
        Funciones fun = new Funciones();
        string filename;
        Datos sv = new Datos();
        String nitEmpresa;
        DataTable dt = new DataTable();

        String[] matriz = new String[ListValidacion.Items.Count + 1];

        for (int i = 0; i < ListValidacion.Items.Count; i++)
        {
            nitEmpresa = ListValidacion.Items[i].ToString();
            matriz[i] = nitEmpresa.Split(' ')[2];
        }

        dt.Columns.Add("NIT");
        foreach (string value in matriz)
        {
            dt.Rows.Add(value);
        }

        DataSet ds = new DataSet();
        ds.Tables.Add(dt);

        if (ds.Tables[0].Rows.Count > 0)
        {
            if (fun.CrearReport(int.Parse(Session["IDusuario"].ToString()), Request.ServerVariables["APPL_PHYSICAL_PATH"], ds))
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
        }

    }

    protected void txtNitNRi_TextChanged(object sender, EventArgs e)
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();
        if (txtNitNRi.Text != "" && txtNitNRi.Text != " ")
        {
            ds = sv.SeDatosNivelesRiesgo(txtNitNRi.Text, 2, Convert.ToString(DateTime.Now), Convert.ToString(DateTime.Now), 2, Convert.ToInt32(Session["IdPais"].ToString()));
            GridLista.DataSource = ds.Tables[0].DefaultView;
            GridLista.DataBind();
            GridLista.Visible = true;
            Dscompleto = new DataSet();
            Dscompleto = ds;

        }
    }
    
    #region INICIO PAGINADOR Y ORDENADOR DE GRIDVIEW */
    protected void Page_PreRender(object sender, System.EventArgs e)
    {
        this.ViewState.Add("DscompletoState", Dscompleto);
    }

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
        GridViewSortExpression = e.SortExpression;
        int pageIndex = GridLista.PageIndex;
        GridLista.DataSource = SortDataTable(Dscompleto.Tables[0].DefaultView, false);
        GridLista.DataBind();
        GridLista.PageIndex = pageIndex;
    }
    #endregion FIN PAGINADOR Y ORDENADOR DE GRIDVIEW */
}