using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
public partial class Conf_GEmpresarial : System.Web.UI.Page
{
    DataSet Dscompleto;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IDusuario"] == null)
        {
            Response.Redirect("Salir.aspx");
        }

        if (Convert.ToBoolean(Session["CrearEmpresaGE"]) == false)
        {
            ImgGuardarGEmp.Visible = false;
            ImgLimpiarDias.Visible = false;
        }

        if (Page.IsPostBack == false)
        {
            LLenarDatos();
        }
        else
        {
            Dscompleto = (DataSet)ViewState["DscompletoState"];
        }
    }

    protected void Page_PreRender(object sender, System.EventArgs e)
    {
        this.ViewState.Add("DscompletoState", Dscompleto);
    }

    protected void grvGEmpresarial_Sorting(object sender, GridViewSortEventArgs e)
    {
        GridViewSortExpression = e.SortExpression;
        int pageIndex = grvGEmpresarial.PageIndex;
        grvGEmpresarial.DataSource = SortDataTable(Dscompleto.Tables[0].DefaultView, false);
        grvGEmpresarial.DataBind();
        grvGEmpresarial.PageIndex = pageIndex;
    }

    protected void grvGEmpresarial_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataTable dataTable = grvGEmpresarial.DataSource as DataTable;
        DataView dataView = new DataView(dataTable);
        grvGEmpresarial.DataSource = SortDataTable(Dscompleto.Tables[0].DefaultView, true);
        // Calculate the current page number. 
        grvGEmpresarial.PageIndex = e.NewPageIndex;
        // Reset selected index 
        grvGEmpresarial.SelectedIndex = -1;
        grvGEmpresarial.DataBind();

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

    public string GridViewSortExpression
    {
        get
        {
            object o = ViewState["SortExpression"];
            return ((o == null) ? string.Empty : Convert.ToString(o));
        }
        set { ViewState["SortExpression"] = value; }
    }

    public void LLenarDatos()
    {
        Datos sv = new Datos();
        DataView vista = new DataView();
        DataSet dts = new DataSet();

        HidGrupoEm.Value = "0";
        dts = sv.SeGrupoEmpresarial(1, 1, "");
        if (dts.Tables[0].Rows.Count > 0)
        {
            grvGEmpresarial.DataSource = dts.Tables[0].DefaultView;
            grvGEmpresarial.DataBind();
            Dscompleto = dts;
        }

        dts = sv.CredSectorLimiteGE(1,1);
        dts.Tables[0].Rows.Add("-1", " Seleccione--");
        vista = dts.Tables[0].DefaultView;
        vista.Sort = "IdSectorGE ASC";

        this.CmbSectorLimiteGE.DataSource = vista;
        this.CmbSectorLimiteGE.DataTextField = "SectorGE";
        this.CmbSectorLimiteGE.DataValueField = "IdSectorGE";
        this.CmbSectorLimiteGE.DataBind();
        dts.Clear();

    }

    protected void btnBuscarGEconomico_Click(object sender, EventArgs e)
    {
        buscarGrupoEconomico();
    }

    private void buscarGrupoEconomico()
    {
        Datos sv = new Datos();

        DataSet ds = new DataSet();
        string GrupóEmp = txtBuscarGrupo.Text;

        if (GrupóEmp == "")
        {
            LLenarDatos();
        }
        else
        {
            ds = sv.SeGrupoEmpresarial(1, 4, GrupóEmp);

            if (ds.Tables[0].Rows.Count > 0)
            {
                grvGEmpresarial.DataSource = ds.Tables[0].DefaultView;
                grvGEmpresarial.DataBind();
                Dscompleto = ds;
            }
            else
            {
                Response.Write("<script>alert('No se encontro grupo económico')</script>");
            }
        }

    }

    public static DataTable DataViewAsDataTable(DataView dv)
    {
        DataTable dt = dv.Table.Clone();
        foreach (DataRowView drv in dv)
            dt.ImportRow(drv.Row);
        return dt;
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

    public string GridViewSortDirection
    {
        get
        {
            object o = ViewState["SortDirection"];
            return ((o == null) ? "ASC" : Convert.ToString(o));
        }
        set { ViewState["SortDirection"] = value; }
    }

    protected void grvGEmpresarial_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Datos sv = new Datos();

            DataSet ds = new DataSet();
            int IdGrupoEm = Convert.ToInt32(grvGEmpresarial.DataKeys[e.Row.RowIndex]["IdGrupoEm"].ToString());
            CheckBox chkEstadoGrupo = (e.Row.FindControl("chkEstadoGrupo") as CheckBox);
            ds = sv.SeGrupoEmpresarial(IdGrupoEm, 2, "");
            chkEstadoGrupo.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Estado"]);


        }
    }

    protected void LimpiarGrupoEmpresarial()
    {
        txtGrupoEmp.Text = "";
        chkEstadoEstado.Checked = false;
        HidGrupoEm.Value = "0";
        txtIdGrupoEm.Text = "";
        txtGrupoEmp.Text = "";
        txtIdGrupoEm.Enabled = true;
        txtBuscarGrupo.Text = "";
        txtAntecedentes.Text = "";
        txtAntecedentes.Visible = false;
        CmbSectorLimiteGE.SelectedValue = "-1";
        LblComentarioEliminacion.Visible = false;
        txtCodGEconomico.Enabled = true;
    }

    protected void Limpiar()
    {
        txtBuscarGrupo.Text = "";
    }

    protected void ImgLimpiarDias_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarGrupoEmpresarial();
    }

    protected void ImgGuardarDias_Click(object sender, ImageClickEventArgs e)
    {
        Datos sv = new Datos();
        int ExisteGrupo = 0;
        if (CmbSectorLimiteGE.SelectedValue != "-1")
        {
            if (HidGrupoEm.Value == "0")
            {

                ExisteGrupo = sv.CreValidaGruposEconomicos(1, txtCodGEconomico.Text.Trim());
                if (ExisteGrupo == 0)
                {
                    ExisteGrupo = sv.CreValidaGruposEconomicos(2, this.txtGrupoEmp.Text.Trim());
                    if (ExisteGrupo == 0)
                    {
                        int Valor = sv.InGrupoEmpresaria(this.txtGrupoEmp.Text.ToUpper(), chkEstadoEstado.Checked, 1, int.Parse(txtIdGrupoEm.Text), "", txtCodGEconomico.Text, int.Parse(CmbSectorLimiteGE.SelectedValue));
                        if (Valor == 0)
                        {
                            String DescripcionAudit = "Inserción de nuevo grupo económico: " + Convert.ToString(this.txtIdGrupoEm.Text) + "; Codigo grupo económico: " + txtCodGEconomico.Text + "; Grupo económico:" + Convert.ToString(this.txtGrupoEmp.Text.ToUpper()) +
                            "; Sector Límite GE: "+ CmbSectorLimiteGE.SelectedItem.Text;
                            sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCPI.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);
                            Response.Write("<script>alert('Datos Guardados Correctamente')</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('El ID de este grupo económico ya esta asociado a otro grupo en el sistema')</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Ya existe en el sistema un grupo económico con este nombre')</script>");
                    }

                }
                else
                {
                    Response.Write("<script>alert('Ya existe en el sistema un grupo económico con este código')</script>");
                }


            }
            else
            {
                int Valor = sv.InGrupoEmpresaria(this.txtGrupoEmp.Text.ToUpper(), chkEstadoEstado.Checked, 2, int.Parse(HidGrupoEm.Value), "", txtCodGEconomico.Text, int.Parse(CmbSectorLimiteGE.SelectedValue));

                String DescripcionAudit = "Actualización grupo económico:" + Convert.ToString(this.txtIdGrupoEm.Text) + "; Grupo económico anterior: " + this.HidGrupoEmpresarial.Value + "; Nuevo nombre Grupo Empresarial : " + Convert.ToString(this.txtGrupoEmp.Text.ToUpper()) +
                    "; Codigo del grupo anterior: " + HidCodGEmp.Value + "; Codigo del grupo actual: " + txtCodGEconomico.Text + "; Sector Límite GE: anterior: " + HidSectorLim.Value + "; Sector Límite GE: actual: " + CmbSectorLimiteGE.SelectedItem.Text;

                sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCPI.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

                Response.Write("<script>alert('Datos Actualizados Correctamente')</script>");
            }
            buscarGrupoEconomico();
            LimpiarGrupoEmpresarial();
        }
        else
        {
            Response.Write("<script>alert('Debe seleccionar Sector Límite GE')</script>");
        }

    }

    protected void ImgLimpiarPeriodo_Click(object sender, ImageClickEventArgs e)
    {
        Limpiar();
    }

    protected void grvGEmpresarial_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();
        string Mensaje, grupoEm;
        txtBuscarGrupo.Text = "";
        switch (e.CommandName)
        {
            case "Editar":
                int IdGrupoEm;
                IdGrupoEm = Convert.ToInt32(e.CommandArgument);
                ds = sv.SeGrupoEmpresarial(IdGrupoEm, 2, "");
                txtIdGrupoEm.Text = Convert.ToString(IdGrupoEm);
                txtIdGrupoEm.Enabled = false;
                txtGrupoEmp.Text = Convert.ToString(ds.Tables[0].Rows[0]["GrupoEmpresarial"]);
                HidGrupoEmpresarial.Value = Convert.ToString(ds.Tables[0].Rows[0]["GrupoEmpresarial"]);
                txtCodGEconomico.Text = Convert.ToString(ds.Tables[0].Rows[0]["CodGEconomico"]);
                if (txtCodGEconomico.Text == "")
                { txtCodGEconomico.Enabled = true; }
                else
                { txtCodGEconomico.Enabled = false; }
                HidCodGEmp.Value= Convert.ToString(ds.Tables[0].Rows[0]["CodGEconomico"]);

                chkEstadoEstado.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Estado"]);
                if (Convert.ToString(ds.Tables[0].Rows[0]["IdSectorGE"]) != "")
                {
                    CmbSectorLimiteGE.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["IdSectorGE"]);
                    HidSectorLim.Value = CmbSectorLimiteGE.SelectedItem.Text;
                }
                HidGrupoEm.Value = Convert.ToString(IdGrupoEm);
                break;
            case "Eliminar":
                IdGrupoEm = Convert.ToInt32(e.CommandArgument);
                ds = sv.SeGrupoEmpresarial(IdGrupoEm, 2, "");
                grupoEm = Convert.ToString(ds.Tables[0].Rows[0]["GrupoEmpresarial"]);

                if (txtAntecedentes.Text == "")
                {
                    Mensaje = "Debe adjuntar un mensaje especificando el motivo de eliminación";
                    txtAntecedentes.Visible = true;
                    LblComentarioEliminacion.Visible = true;
                    Response.Write("<script>alert('" + Mensaje + "')</script>");
                    return;
                }
                else
                {
                    int Valor = sv.DeGrupoEmpresarial(IdGrupoEm);

                    if (Valor == 0)
                    {
                        String DescripcionAudit = "Eliminacion grupo económico:" + Convert.ToString(grupoEm) + " ; Motivo: " + Convert.ToString(this.txtAntecedentes.Text);
                        sv.In_Auditoria_Aplicativo(Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, lblParametrosCPI.Text, Request.ServerVariables["REMOTE_ADDR"], DescripcionAudit);

                        Mensaje = "Grupo empresarial eliminado";
                    }
                    else
                    {
                        Mensaje = "No se puede eliminar el grupo empresarial, tiene empresas atadas";
                    }
                    buscarGrupoEconomico();
                    LimpiarGrupoEmpresarial();
                    Response.Write("<script>alert('" + Mensaje + "')</script>");
                }
                break;
            default:
                break;
        }

    }

    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {
        Funciones fun = new Funciones();
        string filename;

        Datos sv = new Datos();

        DataSet DataS = new DataSet();

        DataS = sv.SeGrupoEmpresarial(1, 5, "");

        if (fun.ExportExcellDataset(int.Parse(Session["IDusuario"].ToString()), DataS, Request.ServerVariables["APPL_PHYSICAL_PATH"]))
        {
            filename = "Report" + Session["IDusuario"].ToString() + ".xls";

            string filepath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Archivos\Datos\" + filename;

            /*    filename = "Report.xls";
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                Response.Flush();
                Response.WriteFile(filepath);
                Response.SuppressContent = true;
                ApplicationInstance.CompleteRequest();*/

            filename = "Report.xls";
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.Flush();
            Response.WriteFile(filepath);
            Response.End();
        }
        DataS.Clear();

    }
}