using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;

public partial class GCCalificacionCualitativa : System.Web.UI.Page
{
    double PonFinal;
    long HisEncuest;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IDusuario"] == null)
        {
            Response.Redirect("Salir.aspx");
        }
        if (Page.IsPostBack == false)
        {
            Datos sv = new Datos();
            if (!sv.ComValidaPaginaPerfil(int.Parse(Session["IdPerfil"].ToString()), Request.Url.Segments[Request.Url.Segments.Length - 1]))
            {
                Response.Redirect("Salir.aspx");
            }

            LLenarDatos();
        }
        else
        {
            Label2.Visible = false;
        }
    }

    private void LLenarDatos()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = sv.CualitativaSeleccion();
        ds.Tables[0].Rows.Add("-1", "Seleccione>>");
        this.CmbCalificacionCualitativa.DataSource = ds.Tables[0].DefaultView;
        this.CmbCalificacionCualitativa.SelectedValue = "-1";
        this.CmbCalificacionCualitativa.DataTextField = "NomCualitativa";
        this.CmbCalificacionCualitativa.DataValueField = "IdEncCualitativa";
        this.CmbCalificacionCualitativa.DataBind();
        ds.Clear();


    }

    private void GrillaLlenar()
    {

        Datos sv = new Datos();
        DataSet ds = new DataSet();
        DataSet dts = new DataSet();
        DataSet dsPollQuestion = null;
        DataTable dt = new DataTable();
        DataRow dr = dt.NewRow();

        dt.Rows.Add(dr);
        int IdEncuesta, IdPregunta, IdRespuesta;
        string Nombre, Pregunta, respuesta;
        decimal Puntaje, Puntaje1, Puntaje3;
        DataTable dtName = new DataTable();
        dtName.Columns.Add("Variable");

        dts = sv.AgrupacionCualitativa(true, 0, int.Parse(CmbCalificacionCualitativa.SelectedValue.ToString()));
        if (dts.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drAgrup in dts.Tables[0].Rows)
            {
                IdEncuesta = Convert.ToInt32(drAgrup[0].ToString());
                Nombre = drAgrup[1].ToString();
                dtName.Rows.Add(Nombre);
                Puntaje3 = Convert.ToDecimal(drAgrup[2].ToString());

                dsPollQuestion = sv.PreguntasLista(true, IdEncuesta);

                foreach (DataRow drPQAct in dsPollQuestion.Tables[0].Rows)
                {
                    IdPregunta = Convert.ToInt32(drPQAct[0].ToString());
                    Pregunta = drPQAct[2].ToString();
                    Puntaje = Convert.ToDecimal(drPQAct[1].ToString());
                    ds = sv.RespuestasLista(IdPregunta, true);

                    foreach (DataRow drPAAct in ds.Tables[0].Rows)
                    {
                        IdRespuesta = Convert.ToInt32(drPAAct[0].ToString());
                        respuesta = drPAAct[1].ToString();
                        Puntaje1 = Convert.ToDecimal(drPAAct[2].ToString());
                    }
                }


            }

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            GridEncuesta.DataSource = dts.Tables[0].DefaultView; //dtName;
            GridEncuesta.DataBind();
            this.GridEncuesta.Columns[0].Visible = false;
            this.GridEncuesta.Columns[3].Visible = false;
            this.GridEncuesta.Columns[4].Visible = false;
            // }

        }


    }

    private void buscarGestor()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();
        string empresa = txtBuscarEmpresa.Text;

        if (empresa == "")
        {
            Response.Write("<script>alert('Debe Ingresar el nit o nombre de la empresa')</script>");
        }
        else
        {
            ds = sv.BencBuscarEmpresa(empresa, 2, Convert.ToInt32(Session["IdPais"].ToString()));

            if (ds.Tables[0].Rows.Count > 0)
            {

                GridEmpresas.DataSource = ds.Tables[0].DefaultView;
                GridEmpresas.DataBind();
                GridEmpresas.Columns[0].Visible = true;
                PanelEncuesta.Visible = false;
                CmbCalificacionCualitativa.Visible = false;
                lblTpEncuesta.Visible = false;

            }
            else
            {
                Response.Write("<script>alert('No se encontro la Empresa')</script>");

            }


        }


    }

    protected void GridEmpresas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();

        switch (e.CommandName)
        {
            case "Seleccionar":
                string Empresa;

                int IdSector = 0;
                Empresa = e.CommandArgument.ToString();
                HidEmpresa.Value = Convert.ToString(Empresa);
                ds = sv.BencEmpresaDatos(Empresa, Convert.ToInt32(Session["IdPais"].ToString()));
                GridEmpresas.DataSource = ds.Tables[0].DefaultView;
                GridEmpresas.DataBind();
                if (Convert.ToString(ds.Tables[0].Rows[0]["IdSector"]) != "")
                {
                    IdSector = int.Parse(ds.Tables[0].Rows[0]["IdSector"].ToString());
                }
                ds = sv.ComSectores(IdSector, 2, Convert.ToInt32(Session["IdPais"].ToString()));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(ds.Tables[0].Rows[0]["IdCCualitativa"]) != "")
                    {
                        CmbCalificacionCualitativa.Enabled = false;
                        CmbCalificacionCualitativa.SelectedValue = ds.Tables[0].Rows[0]["IdCCualitativa"].ToString();
                        CargarInfCualitativa(int.Parse(CmbCalificacionCualitativa.SelectedValue));
                    }
                    else
                    {
                        CmbCalificacionCualitativa.SelectedValue = "-1";
                        CmbCalificacionCualitativa.Enabled = true;
                    }
                }
                else
                {
                    CmbCalificacionCualitativa.SelectedValue = "-1";
                    CmbCalificacionCualitativa.Enabled = true;
                }
                lblTpEncuesta.Visible = true;
                CmbCalificacionCualitativa.Visible = true;

                break;
            default:
                break;
        }


    }

    protected void CargarInfCualitativa(int TipoCalificacion)
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();
        DataSet dts = new DataSet();

        dts = sv.AgrupacionCualitativa(true, 0, TipoCalificacion);
        if (dts.Tables[0].Rows.Count > 0)
        {
            ds = sv.HistoricoCualitativa(HidEmpresa.Value, TipoCalificacion, Convert.ToInt32(Session["IdPais"].ToString()));
            if (ds.Tables[0].Rows.Count > 0)
            {
                Label2.Visible = true;
                GrvHistoricoEncuestas.Visible = true;
                GrvHistoricoEncuestas.DataSource = ds.Tables[0].DefaultView;
                GrvHistoricoEncuestas.DataBind();
            }
            else
            {
                GrvHistoricoEncuestas.Visible = false;
            }
            GrillaLlenar();
            PanelEncuesta.Visible = true;
            GrvSeleccionEncuesta.Visible = false;
            lblTotPon.Visible = false;
            txtTotalPonderado.Visible = false;
            GridEncuesta.Visible = true;
            BtnGuardar.Visible = true;
            BtnVolver.Visible = false;
            GridEmpresas.Columns[0].Visible = false;


            ds.Clear();
        }
        else
        {
            PanelEncuesta.Visible = false;
            GrvSeleccionEncuesta.Visible = false;
            lblTotPon.Visible = false;
            txtTotalPonderado.Visible = false;
            GridEncuesta.Visible = false;
            BtnGuardar.Visible = false;
            BtnVolver.Visible = false;
            GridEmpresas.Columns[0].Visible = false;
        }


    }

    protected void CmbCalificacionCualitativa_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarInfCualitativa(int.Parse(CmbCalificacionCualitativa.SelectedValue));
    }

    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {
        foreach (GridViewRow row in GridEncuesta.Rows)
        {
            Label MostrarPuntaje = (Label)row.FindControl("lblGuardaResp") as Label;
            DropDownList ddlTest = (DropDownList)row.FindControl("ddlTest") as DropDownList;
            MostrarPuntaje.Text = ddlTest.SelectedItem.Text;
            ddlTest.Visible = false;
        }
        if (GridEncuesta.Visible == true)
        {
            exportarexcel(this.GridEncuesta);
        }
        else
        {
            exportarexcel(this.GrvSeleccionEncuesta);
        }
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
        Response.AddHeader("Content-Disposition", "attachment;filename=Informacion_Cualitativa.xls");
        Response.Charset = "UTF-8";
        Response.ContentEncoding = Encoding.Default;
        Response.Write(sb.ToString());
        
        ApplicationInstance.CompleteRequest();

    }

    protected void ddlRespuesta_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button18_Click(object sender, EventArgs e)
    {
        buscarGestor();
    }

    protected void GridEncuesta_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Datos sv = new Datos();
            DataSet ds = new DataSet();

            DropDownList ddlRespuesta = (e.Row.FindControl("ddlRespuesta") as DropDownList);
            Label Puntaje = (e.Row.FindControl("ddlRespuesta") as Label);
            if (ddlRespuesta != null)
            {
                int IdEncuesta = Convert.ToInt32(GridEncuesta.DataKeys[e.Row.RowIndex]["IdVariable"].ToString());
                ds = sv.RespuestasLista(IdEncuesta, true);
                ds.Tables[0].Rows.Add("-1", "--Seleccione una opcion--");
                ddlRespuesta.DataSource = ds.Tables[0].DefaultView;
                ddlRespuesta.SelectedValue = "-1";
                ddlRespuesta.DataTextField = "Respuesta";
                ddlRespuesta.DataValueField = "IdRespuesta";
                ddlRespuesta.DataBind();
            }


        }

    }

    protected void BtnGuardar_Click(object sender, ImageClickEventArgs e)
    {
        int Contestado = 0;
        foreach (GridViewRow row in GridEncuesta.Rows)
        {
            int IdRespuesta = Convert.ToInt32(((DropDownList)row.FindControl("ddlRespuesta")).SelectedItem.Value);
            if (IdRespuesta == -1)
            {
                Contestado++;
            }
        }
        if (Contestado != 0)
        {
            Response.Write("<script>alert('Todas las Preguntas de la encuesta tiene que ser contestadas')</script>");
        }
        else
        {
            GuardarCualitativa();
            GrillaLlenar();
        }
    }

    public void GuardarCualitativa()
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();
        DataSet dts = new DataSet();
        DataSet dtss = new DataSet();
        int Contestas = 1;
        long Pond = 0;
        string Empresa = "";
        double ValorPond = 0, VarTotal = 0, pesoAgrupacion = 0, pesoAgrup = 0; ;
        int NumAgrupacion = 1;

        foreach (GridViewRow row in GridEncuesta.Rows)
        {
            int IdAgrupacion = int.Parse(GridEncuesta.DataKeys[row.RowIndex]["IdAgrupacion"].ToString());
            dts = sv.AgrupacionCualitativa(false, IdAgrupacion, 0);
            pesoAgrupacion = double.Parse(dts.Tables[0].Rows[0]["Peso"].ToString());

            int IdVariable = int.Parse(GridEncuesta.DataKeys[row.RowIndex]["IdVariable"].ToString());
            dtss = sv.PreguntasLista(false, IdVariable);
            double pesoVariable = double.Parse(dtss.Tables[0].Rows[0]["Peso"].ToString());

            int valor = Convert.ToInt32(((DropDownList)row.FindControl("ddlRespuesta")).SelectedItem.Value);
            ds = sv.RespuestasLista(valor, false);

            if (NumAgrupacion == IdAgrupacion)
            {
                ValorPond = (double.Parse(ds.Tables[0].Rows[0]["Factor"].ToString()) * pesoVariable) / 100;
                VarTotal = VarTotal + ValorPond;
            }
            else
            {
                VarTotal = (VarTotal * pesoAgrup) / 100;
                PonFinal = PonFinal + VarTotal;
                VarTotal = 0;
                ValorPond = (double.Parse(ds.Tables[0].Rows[0]["Factor"].ToString()) * pesoVariable) / 100;
                VarTotal = VarTotal + ValorPond;
            }
            NumAgrupacion = IdAgrupacion;
            pesoAgrup = pesoAgrupacion;


        }

        VarTotal = (VarTotal * pesoAgrupacion) / 100;
        PonFinal = PonFinal + VarTotal;


        foreach (GridViewRow row in GridEncuesta.Rows)
        {
            Empresa = HidEmpresa.Value.ToString();
            int IdAgrupacion = int.Parse(GridEncuesta.DataKeys[row.RowIndex]["IdAgrupacion"].ToString());
            int IdVariable = int.Parse(GridEncuesta.DataKeys[row.RowIndex]["IdVariable"].ToString());
            int Respuesta = int.Parse(((DropDownList)row.FindControl("ddlRespuesta")).SelectedItem.Value);
            string Descripcion = ((DropDownList)row.FindControl("ddlRespuesta")).SelectedItem.Text;
            string FechaCracion = DateTime.Now.ToString();

            if (Contestas == 1)
            {
                string fechaCualit = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
                Pond = sv.PondCualitativa(int.Parse(CmbCalificacionCualitativa.SelectedValue.ToString()), CmbCalificacionCualitativa.SelectedItem.Text, Empresa, Decimal.Parse(PonFinal.ToString()), FechaCracion, 1, int.Parse(Session["IDusuario"].ToString()), Convert.ToInt32(Session["IdPais"].ToString()));
            }
            sv.RespustaCualitativa(IdAgrupacion, IdVariable, Respuesta, Empresa, Pond, Convert.ToInt32(Session["IdPais"].ToString()));
            Contestas++;
        }

        Label2.Visible = true;
        GrvHistoricoEncuestas.Visible = true;
        ds = sv.HistoricoCualitativa(Empresa, int.Parse(CmbCalificacionCualitativa.SelectedValue.ToString()), Convert.ToInt32(Session["IdPais"].ToString()));
        GrvHistoricoEncuestas.DataSource = ds.Tables[0].DefaultView;
        GrvHistoricoEncuestas.DataBind();
        ds.Clear();

    }

    protected void GrvHistoricoEncuestas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Datos sv = new Datos();
        DataSet ds = new DataSet();
        DataSet dts = new DataSet();

        switch (e.CommandName)
        {
            case "Seleccionar":
                long HisEncuesta = Convert.ToInt64(e.CommandArgument);
                HidSeleccionEncuesta.Value = Convert.ToString(HisEncuesta);
                ds = sv.CualitativaFinal(HisEncuesta);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    HidNombreUsuario.Value = Convert.ToString(ds.Tables[0].Rows[0]["Usuario"]);
                    GrvSeleccionEncuesta.DataSource = ds.Tables[0].DefaultView;
                    GrvSeleccionEncuesta.DataBind();
                    HisEncuest = HisEncuesta;

                    GrvSeleccionEncuesta.Visible = true;
                    //lblTotPon.Visible = true;
                    //txtTotalPonderado.Visible = true;
                    GridEncuesta.Visible = false;
                    BtnGuardar.Visible = false;
                    BtnVolver.Visible = true;
                    PanelEncuesta.Visible = true;
                    txtTotalPonderado.Text = Convert.ToString(ds.Tables[0].Rows[0]["Ponderado"]);
                    Label2.Visible = true;
                }

                break;
            default:
                break;
        }
        this.GrvSeleccionEncuesta.Columns[0].Visible = false;
        this.GrvSeleccionEncuesta.Columns[1].Visible = true;

    }

    protected void BtnVolver_Click(object sender, ImageClickEventArgs e)
    {
        GrillaLlenar();
        GrvSeleccionEncuesta.Visible = false;

        lblTotPon.Visible = false;
        txtTotalPonderado.Visible = false;
        GridEncuesta.Visible = true;
        BtnGuardar.Visible = true;
        BtnVolver.Visible = false;
    }




}