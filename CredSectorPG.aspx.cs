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
using CarlosAg.ExcelXmlWriter;
using Encoder = Microsoft.Security.Application.Encoder;


public partial class BencSectorPG : System.Web.UI.Page
{
    DataSet Dscompleto;
    DataSet Dscompleto2;
    string[] lista;
    double[] lista2;
    DataSet dsSec = new DataSet();
    DataSet dsSec2 = new DataSet();

    int IdIndicador;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (CmbIndicadores.SelectedValue != "")
        {
            IdIndicador = int.Parse(CmbIndicadores.SelectedValue);
        }
        else
        {
            IdIndicador = 90001;
        }

        if (Page.IsPostBack == false)
        {
            llenardatos();

        }
        else
        {
            if (HiEmpresas.Value != "0")
            {
                llenarlistaEmpresa();
                Dscompleto = (DataSet)ViewState["DscompletoState"];
                grvEmpresaLista.DataSource = Dscompleto.Tables[0];
                grvEmpresaLista.DataBind();

                llenarlista2();
                Dscompleto2 = (DataSet)ViewState["Dscompleto2State"];
                Gridlista2.DataSource = Dscompleto2.Tables[0];
                Gridlista2.DataBind();
            }


        }

    }

    private void llenardatos()
    {

        Datos sv = new Datos();
        DataView vista = new DataView();
        DataSet ds = new DataSet();

        ds = sv.ComSectores(0, 1, Convert.ToInt32(Session["IdPais"].ToString()));
        ds.Tables[0].Rows.Add("-1", "Seleccione>>");
        vista = ds.Tables[0].DefaultView;
        vista.Sort = "IdSector ASC";

        this.cmbSector.DataSource = vista;
        this.cmbSector.DataTextField = "Sector";
        this.cmbSector.DataValueField = "IdSector";
        this.cmbSector.DataBind();
        ds.Clear();

        ds = sv.CredIndicadores(1);
        this.CmbIndicadores.DataSource = ds.Tables[0].DefaultView;
        this.CmbIndicadores.DataTextField = "Diminutivo";
        this.CmbIndicadores.DataValueField = "IdIndicador";
        this.CmbIndicadores.DataBind();
        this.CmbIndicadores.SelectedValue = IdIndicador.ToString();
        ds.Clear();

        HiEmpresas.Value = "0";



    }

    public void llenarlistaEmpresa()
    {
        int i = 0;
        int contador = 1;
        for (i = 0; i < this.grvEmpresaLista.Rows.Count; i++)
        {
            //En la posición 13 es en donde se encuentra el control Check.
            if (((CheckBox)this.grvEmpresaLista.Rows[i].Cells[0].Controls[1]).Checked)
            {
                Array.Resize(ref lista, (contador));
                lista[contador - 1] = this.grvEmpresaLista.Rows[i].Cells[1].Text;
                contador += 1;
            }
        }

    }

    public void llenarlista2()
    {
        int i = 0;
        int contador = 1;
        for (i = 0; i < this.Gridlista2.Rows.Count; i++)
        {
            //En la posición 13 es en donde se encuentra el control Check.
            if (((CheckBox)this.Gridlista2.Rows[i].Cells[0].Controls[1]).Checked)
            {
                Array.Resize(ref lista2, (contador));
                lista2[contador - 1] = double.Parse(this.Gridlista2.Rows[i].Cells[1].Text);
                contador += 1;
            }
        }

    }

    protected void Page_PreRender(object sender, System.EventArgs e)
    {
        this.ViewState.Add("DscompletoState", Dscompleto);
        this.ViewState.Add("Dscompleto2State", Dscompleto2);
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
        DataTable dataTable = grvEmpresaLista.DataSource as DataTable;
        DataView dataView = new DataView(dataTable);


        grvEmpresaLista.DataSource = SortDataTable(dataView, true);
        // Calculate the current page number. 
        grvEmpresaLista.PageIndex = e.NewPageIndex;


        // Reset selected index 
        grvEmpresaLista.SelectedIndex = -1;

        grvEmpresaLista.DataBind();
        // Identificar en qué página estás
        int currentPageIndex = e.NewPageIndex + 1; // Sumar 1 porque los índices comienzan en 0
        Label2.Text = "Página actual: " + currentPageIndex.ToString();


        TabContainer1.ActiveTab = TabContainer1.Tabs[3];


    }

    protected void Grid2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataTable dataTable = Gridlista2.DataSource as DataTable;
        DataView dataView = new DataView(dataTable);

        Gridlista2.DataSource = SortDataTable(dataView, true);
        // Calculate the current page number. 
        Gridlista2.PageIndex = e.NewPageIndex;


        // Reset selected index 
        Gridlista2.SelectedIndex = -1;

        Gridlista2.DataBind();

        // Identificar en qué página estás
        int currentPageIndex = e.NewPageIndex + 1; // Sumar 1 porque los índices comienzan en 0
        Label1.Text = "Página actual: " + currentPageIndex.ToString();

        TabContainer1.ActiveTab = TabContainer1.Tabs[4];


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
        DataTable dataTable = grvEmpresaLista.DataSource as DataTable;


        DataView dataView = new DataView(dataTable);

        GridViewSortExpression = e.SortExpression;
        int pageIndex = grvEmpresaLista.PageIndex;
        grvEmpresaLista.DataSource = SortDataTable(dataView, false);
        grvEmpresaLista.DataBind();
        grvEmpresaLista.PageIndex = pageIndex;

    }

    protected void Grid2_Sorting(object sender, System.Web.UI.WebControls.GridViewSortEventArgs e)
    {
        DataTable dataTable = Gridlista2.DataSource as DataTable;


        DataView dataView = new DataView(dataTable);

        GridViewSortExpression = e.SortExpression;
        int pageIndex = Gridlista2.PageIndex;
        Gridlista2.DataSource = SortDataTable(dataView, false);
        Gridlista2.DataBind();
        Gridlista2.PageIndex = pageIndex;


    }

    private void GrillaLlenar()
    {

        Datos sv = new Datos();
        DataSet DataS = new DataSet();

        DataS = sv.BencBalancePygSector(int.Parse(cmbSector.SelectedValue), false, this.CmbAgregado.SelectedValue, Convert.ToInt32(Session["IdPais"].ToString()));


        int cuantos = 0;
        int j = 0;
        int i = 0;

        cuantos = DataS.Tables[0].Columns.Count;


        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("PERDIDAS Y GANANCIAS", typeof(string)));

        for (i = 3; i < cuantos; i++)
        {
            dt.Columns.Add(new DataColumn(DataS.Tables[0].Columns[i].ColumnName, typeof(string)));
        }


        for (i = 0; i < DataS.Tables[0].Rows.Count; i++)
        {
            dr = dt.NewRow();

            dr["PERDIDAS Y GANANCIAS"] = DataS.Tables[0].Rows[i][1];

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


        GridLista.Columns.Clear();

        GridLista.DataSource = dt;

        GridLista.DataBind();


        if (GridLista.Rows.Count > 0)
        {
            GridLista.HeaderRow.HorizontalAlign = HorizontalAlign.Center;

            GridLista.ControlStyle.Font.Size = 10;


            for (j = 0; j < GridLista.Rows.Count; j++)
            {
                for (i = 1; i < dt.Columns.Count; i++)
                {

                    GridLista.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Right;
                }
            }


            string texto = null;
            for (i = 0; i < GridLista.Rows.Count; i++)
            {
                texto = GridLista.Rows[i].Cells[0].Text.Trim();
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
                        GridLista.Rows[i].ControlStyle.BackColor = System.Drawing.Color.Gainsboro;
                        GridLista.Rows[i].ControlStyle.Font.Size = 10;
                        GridLista.Rows[i].ControlStyle.Font.Bold = true;
                        break;
                    case "UTILIDAD BRUTA":
                    case "UTILIDAD OPERACIONAL":
                    case "UTILIDAD NETA ANTES DE IMPUESTOS":
                    case "GANANCIAS ó PERDIDAS":
                        GridLista.Rows[i].ControlStyle.BackColor = System.Drawing.Color.Gray;
                        GridLista.Rows[i].ControlStyle.Font.Size = 10;
                        GridLista.Rows[i].ControlStyle.Font.Bold = true;
                        break;


                }
            }



        }


        DataS.Clear();




    }

    private void GrillaLlenarEmpresas()
    {

        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = sv.BencEmpresasLista(int.Parse(cmbSector.SelectedValue));

        grvEmpresaLista.DataSource = ds.Tables[0].DefaultView;
        grvEmpresaLista.DataBind();
        Dscompleto = new DataSet();
        Dscompleto = ds;
        // ds.Clear();
        HiEmpresas.Value = "1";



    }

    private void GrillaLlenaRanking()
    {


        Datos sv = new Datos();
        DataSet ds = new DataSet();

        ds = sv.CredRankingSector(int.Parse(cmbSector.SelectedValue), int.Parse(this.CmbIndicadores.SelectedValue));



        int cuantos = 0;
        int i = 0;

        cuantos = ds.Tables[0].Columns.Count;

        if (this.Gridlista2.Columns.Count < 4)
        {
            for (i = 2; i < cuantos; i++)
            {

                BoundField lobColumnBound;

                //Crear Columna:
                lobColumnBound = new BoundField();
                lobColumnBound.DataField = ds.Tables[0].Columns[i].ColumnName;  // del Origen de datos
                lobColumnBound.HeaderText = ds.Tables[0].Columns[i].ColumnName;
                lobColumnBound.SortExpression = ds.Tables[0].Columns[i].ColumnName;
                lobColumnBound.ItemStyle.HorizontalAlign = HorizontalAlign.Right;

                if (i % 2 == 1)
                {
                    lobColumnBound.DataFormatString = "{0:N}";
                }



                Gridlista2.Columns.Add(lobColumnBound);

            }
        }


        Gridlista2.DataSource = ds.Tables[0].DefaultView;
        Gridlista2.DataBind();
        Dscompleto2 = new DataSet();
        Dscompleto2 = ds;
        // ds.Clear();





    }

    private void GrillaLlenarBalance()
    {

        Datos sv = new Datos();
        DataSet DataS = new DataSet();

        DataS = sv.BencBalancePygSector(int.Parse(cmbSector.SelectedValue), true, this.CmbAgregado.SelectedValue, Convert.ToInt32(Session["IdPais"].ToString()));





        int cuantos = 0;
        int j = 0;
        int i = 0;

        cuantos = DataS.Tables[0].Columns.Count;


        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("BALANCE", typeof(string)));

        for (i = 3; i < cuantos; i++)
        {
            dt.Columns.Add(new DataColumn(DataS.Tables[0].Columns[i].ColumnName, typeof(string)));
        }


        for (i = 0; i < DataS.Tables[0].Rows.Count; i++)
        {
            dr = dt.NewRow();

            dr["BALANCE"] = DataS.Tables[0].Rows[i][1];

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


        GridListaBalance.Columns.Clear();

        GridListaBalance.DataSource = dt;

        GridListaBalance.DataBind();


        if (GridListaBalance.Rows.Count > 0)
        {
            GridListaBalance.HeaderRow.HorizontalAlign = HorizontalAlign.Center;

            GridListaBalance.ControlStyle.Font.Size = 10;


            for (j = 0; j < GridListaBalance.Rows.Count; j++)
            {
                for (i = 1; i < dt.Columns.Count; i++)
                {

                    GridListaBalance.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Right;
                }
            }



            string texto = null;
            for (i = 0; i < GridListaBalance.Rows.Count; i++)
            {
                texto = GridListaBalance.Rows[i].Cells[0].Text.Trim();
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
                        GridListaBalance.Rows[i].ControlStyle.BackColor = System.Drawing.Color.Gainsboro;
                        GridListaBalance.Rows[i].ControlStyle.Font.Size = 10;
                        //GridListaBalance.Rows[i].ControlStyle.Font.Bold = true;
                        break;
                    case "TOTAL ACTIVO CORRIENTE":
                    case "TOTAL ACTIVO NO CORRIENTE":
                    case "TOTAL PASIVO CORRIENTE":
                    case "TOTAL PASIVO LARGO PLAZO":
                        GridListaBalance.Rows[i].ControlStyle.BackColor = System.Drawing.Color.Gainsboro;
                        GridListaBalance.Rows[i].ControlStyle.Font.Size = 10;
                        GridListaBalance.Rows[i].ControlStyle.Font.Bold = true;
                        break;
                    case "TOTAL ACTIVO":
                    case "TOTAL PASIVO":
                    case "TOTAL PATRIMONIO":
                    case "TOTAL PASIVO Y PATRIMONIO":
                        GridListaBalance.Rows[i].ControlStyle.BackColor = System.Drawing.Color.Gray;
                        GridListaBalance.Rows[i].ControlStyle.Font.Size = 10;
                        GridListaBalance.Rows[i].ControlStyle.Font.Bold = true;
                        break;


                }
            }



        }

        DataS.Clear();


    }

    private void GrillaLlenarIndicadores()
    {

        Datos sv = new Datos();
        DataSet DataS = new DataSet();

        DataS = sv.BencIndicadoresSector(int.Parse(cmbSector.SelectedValue), 1, this.CmbAgregadoIndicador.SelectedValue, Convert.ToInt32(Session["IdPais"].ToString()));




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
        //GridListaInidicadores.Columns.Clear();

        GridListaInidicadores.DataSource = dt;

        GridListaInidicadores.DataBind();

        if (GridListaInidicadores.Rows.Count > 0)
        {
            string texto = null;

            GridListaInidicadores.HeaderRow.HorizontalAlign = HorizontalAlign.Center;

            GridListaInidicadores.ControlStyle.Font.Size = 10;

            GridListaInidicadores.Rows[0].ControlStyle.BackColor = System.Drawing.Color.Gray;
            GridListaInidicadores.Rows[0].ControlStyle.Font.Size = 10;
            GridListaInidicadores.Rows[0].ControlStyle.Font.Bold = true;


            for (j = 0; j < GridListaInidicadores.Rows.Count; j++)
            {
                for (i = 1; i < dt.Columns.Count; i++)
                {

                    GridListaInidicadores.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Right;

                }
            }

            for (i = 0; i < GridListaInidicadores.Rows.Count; i++)
            {
                texto = GridListaInidicadores.Rows[i].Cells[0].Text.Trim();
                switch (texto)
                {
                    case "P&G":
                    case "BALANCE":
                    case "ENDEUDAMIENTO":
                    case "EFICIENCIA":
                    case "LIQUIDEZ":
                    case "Z-SCORE":
                    case "COBERTURA":
                        GridListaInidicadores.Rows[i].ControlStyle.BackColor = System.Drawing.Color.Gray;
                        GridListaInidicadores.Rows[i].ControlStyle.Font.Size = 11;
                        GridListaInidicadores.Rows[i].ControlStyle.Font.Bold = true;

                        //GridListaInidicadores.Rows[i].Cells[0]. = false;

                        break;
                }
            }
        }


        DataS.Clear();




    }

    private void GrillaLlenarFlujo()
    {

        Datos sv = new Datos();
        DataSet DataS = new DataSet();

        DataS = sv.BencIndicadoresSector(int.Parse(cmbSector.SelectedValue), 4, this.CmbAgregadoFlujo.SelectedValue, Convert.ToInt32(Session["IdPais"].ToString()));

        int cuantos = 0;
        int j = 0;
        int i = 0;


        cuantos = DataS.Tables[0].Columns.Count;


        DataTable dt = new DataTable();
        DataRow dr;



        dt.Columns.Add(new DataColumn("Flujo De Caja", typeof(string)));

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
                dr["Flujo De Caja"] = DataS.Tables[0].Rows[i][4].ToString().Trim().ToUpper();
                titulo = DataS.Tables[0].Rows[i][4].ToString().Trim();
                dt.Rows.Add(dr);
                dr = dt.NewRow();

            }

            dr["Flujo De Caja"] = DataS.Tables[0].Rows[i][1];

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
        GridListaFlujo.Columns.Clear();

        GridListaFlujo.DataSource = dt;

        GridListaFlujo.DataBind();

        if (GridListaFlujo.Rows.Count > 0)
        {
            string texto = null;

            GridListaFlujo.HeaderRow.HorizontalAlign = HorizontalAlign.Center;

            GridListaFlujo.ControlStyle.Font.Size = 10;

            GridListaFlujo.Rows[0].ControlStyle.BackColor = System.Drawing.Color.Gray;
            GridListaFlujo.Rows[0].ControlStyle.Font.Size = 10;
            GridListaFlujo.Rows[0].ControlStyle.Font.Bold = true;


            for (j = 0; j < GridListaFlujo.Rows.Count; j++)
            {
                for (i = 1; i < dt.Columns.Count; i++)
                {

                    GridListaFlujo.Rows[j].Cells[i].HorizontalAlign = HorizontalAlign.Right;

                }
            }

            for (i = 0; i < GridListaFlujo.Rows.Count; i++)
            {
                texto = GridListaFlujo.Rows[i].Cells[0].Text.Trim();
                switch (texto)
                {
                    case "CAJA INICIAL":
                    case "CAJA DE VENTAS":
                    case "CAJA PARA PRODUCIR":
                    case "CAJA PARA OPERAR":
                    case "FLUJO DE CAJA OPERATIVO":
                    case "INVERSIONES EN ACTIVOS":
                    case "FLUJO DE CAJA LIBRE":
                    case "FINANCIEROS":
                    case "FLUJO DE CAJA":
                        GridListaFlujo.Rows[i].ControlStyle.BackColor = System.Drawing.Color.Gray;
                        GridListaFlujo.Rows[i].ControlStyle.Font.Size = 10;
                        GridListaFlujo.Rows[i].ControlStyle.Font.Bold = true;
                        break;
                }
            }
        }


        DataS.Clear();



    }

    protected void OkButton_Click(object sender, EventArgs e)
    {

        if (this.MisSectores.CheckedNodes.Count > 0)
        {
            if ((lista != null))
            {
                foreach (TreeNode item in MisSectores.CheckedNodes)
                {
                    for (int i = 0; i < lista.Length; i++)
                    {
                        Datos sv = new Datos();
                        sv.CredCopiaEmpSector(lista[i].ToString(), int.Parse(item.Value));

                    }

                    Datos sv2 = new Datos();

                    sv2.CredCalculaBalanceSector(int.Parse(item.Value), 0, Convert.ToInt32(Session["IdPais"].ToString()));
                    sv2.CredCalculaBalanceSector(int.Parse(item.Value), 1, Convert.ToInt32(Session["IdPais"].ToString()));
                    sv2.CredCalculaSector(int.Parse(item.Value), 1, Convert.ToInt32(Session["IdPais"].ToString()));


                }
            }

            this.ModalPopupExtender.Hide();
            Response.Write("<script>alert('Empresas Copiadas')</script>");
        }
        else
        {

            this.ModalPopupExtender.Hide();
            Response.Write("<script>alert('Debe Seleccionar Un Sector')</script>");
        }


    }

    private TreeNode CrearNodosHijo(int indicePadre, TreeNode nodePadre)
    {


        DataView dataViewHijos = null;
        // Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
        dataViewHijos = new DataView(dsSec.Tables[0]);
        dataViewHijos.RowFilter = dsSec.Tables[0].Columns["SectorPadre"].ColumnName + " = " + indicePadre.ToString();
        TreeNode nuevoNodo = new TreeNode();
        //TreeNode nuevoDevolver = new TreeNode();
        // Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
        foreach (DataRowView dataRowCurrent in dataViewHijos)
        {
            nuevoNodo = new TreeNode(dataRowCurrent["Sector"].ToString(), dataRowCurrent["IdSector"].ToString());
            nuevoNodo.SelectAction = TreeNodeSelectAction.Expand;
            nuevoNodo.ChildNodes.Add(CrearNodosHijo(Int32.Parse(dataRowCurrent["IdSector"].ToString()), nuevoNodo));
            nodePadre.ChildNodes.Add(nuevoNodo);
        }
        return nodePadre;


    }

    protected void CmbAgregado_SelectedIndexChanged(object sender, EventArgs e)
    {
        GrillaLlenar();
        TabContainer1.ActiveTab = TabContainer1.Tabs[2];
    }

    protected void CmbAgregadoBalance_SelectedIndexChanged(object sender, EventArgs e)
    {
        GrillaLlenarBalance();
    }

    protected void CmbAgregadoIndicador_SelectedIndexChanged(object sender, EventArgs e)
    {
        GrillaLlenarIndicadores();
        TabContainer1.ActiveTab = TabContainer1.Tabs[1];
    }

    protected void CmbIndicadores_SelectedIndexChanged(object sender, EventArgs e)
    {
        IdIndicador = int.Parse(CmbIndicadores.SelectedValue);
        GrillaLlenaRanking();

        TabContainer1.ActiveTab = TabContainer1.Tabs[4];
    }

    protected void CmbAgregadoFlujo_SelectedIndexChanged(object sender, EventArgs e)
    {
        GrillaLlenarFlujo();
        TabContainer1.ActiveTab = TabContainer1.Tabs[5];
    }

    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {
        Exportarexcel(GridLista);
    }

    protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
    {

        Datos sv = new Datos();
        DataSet dsDatos = new DataSet();

        dsDatos = sv.BencEmpresasListaExportarData(int.Parse(Encoder.HtmlEncode(Request.QueryString["IdSector"])));

        string NomArchivo = "Listado" + int.Parse(Session["IDusuario"].ToString()) + ".xls";
        string targetPath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Archivos\Datos";
        string destFile = System.IO.Path.Combine(targetPath, NomArchivo);



        Workbook book = new Workbook();

        // Specify which Sheet should be opened and the size of window by default

        book.ExcelWorkbook.ActiveSheetIndex = 1;
        book.ExcelWorkbook.WindowTopX = 100;
        book.ExcelWorkbook.WindowTopY = 200;
        book.ExcelWorkbook.WindowHeight = 7000;
        book.ExcelWorkbook.WindowWidth = 8000;

        // Some optional properties of the Document
        book.Properties.Author = "Luis Achury";
        book.Properties.Title = "Gestor Comercial y de Credito";
        book.Properties.Created = DateTime.Now;

        #region "Centrar encabezados en negrilla en Excel | Agustín David Cruz González (16/Jul/2014)."

        // Add some styles to the Workbook
        WorksheetStyle style = book.Styles.Add("Cabecera");
        style.Font.Bold = true;
        style.Alignment.Horizontal = StyleHorizontalAlignment.Center;

        //Bordes y color de encabezados | Agustín David Cruz González (16/Jul/2014).
        style.Interior.Pattern = StyleInteriorPattern.Solid;
        style.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
        style.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
        style.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
        style.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
        style.Interior.Color = "#D7E4BC";

        #endregion

        #region "Estilo para contenido | Agustín David Cruz González (16/Jul/2014)."

        WorksheetStyle style2 = book.Styles.Add("Contenido");
        style2.Interior.Pattern = StyleInteriorPattern.Solid;
        style2.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
        style2.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
        style2.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
        style2.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);

        #endregion

        // Add a Worksheet with some data
        Worksheet sheet = book.Worksheets.Add("Lista");
        WorksheetRow row = sheet.Table.Rows.Add();

        row.Index = 1;

        for (int i = 0; i < dsDatos.Tables[0].Columns.Count; i++)
        {
            row.Cells.Add(new WorksheetCell(dsDatos.Tables[0].Columns[i].ColumnName, "Cabecera"));
        }
        row.Cells.RemoveAt(0);//Quita la columna de IdSector para no exportarla


        for (int i = 0; i < dsDatos.Tables[0].Rows.Count; i++)
        {
            row = sheet.Table.Rows.Add();

            for (int j = 0; j < dsDatos.Tables[0].Columns.Count; j++)
            {
                row.Cells.Add(new WorksheetCell(Convert.ToString(dsDatos.Tables[0].Rows[i][j]), "Contenido"));
            }
            row.Cells.RemoveAt(0);//Quita la columna de IdSector para no exportarla
        }


        book.Save(destFile);

        dsDatos.Clear();

        Response.Clear();
        Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + NomArchivo);
        Response.Flush();
        Response.WriteFile(destFile);
        
        ApplicationInstance.CompleteRequest();



    }

    protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
    {
        Exportarexcel(GridLista);
    }

    protected void ImageButton10_Click(object sender, ImageClickEventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        System.IO.StringWriter sw = new System.IO.StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        Page page = new Page();
        HtmlForm form = new HtmlForm();

        #region "Manejar paginación de la grilla | Agustín David Cruz González (16/Jul/2014)."

        Gridlista2.AllowPaging = false; //Se establece AllowPaging en false para obtener todos los registros de la grilla y no solo los de la hoja actual.
        Gridlista2.DataBind(); //Se enlaza la grilla con el origen de datos
        Gridlista2.EnableViewState = true; //Mantener el estado actual de la grilla.
        Gridlista2.Columns[0].Visible = false; // Ocultar columna de checks para no exportarla.

        #endregion

        // Deshabilitar la validación de eventos, sólo asp.net 2
        page.EnableEventValidation = false;

        // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
        page.DesignerInitialize();

        page.Controls.Add(form);
        form.Controls.Add(Gridlista2);

        page.RenderControl(htw);

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=data.xls");
        Response.Charset = "UTF-8";

        Response.Cache.SetCacheability(HttpCacheability.NoCache); // Se deshabilita el cache | Agustín David Cruz González (16/Jul/2014).

        Response.ContentEncoding = Encoding.Default;
        Response.Write(sb.ToString());
        
        ApplicationInstance.CompleteRequest();

        #region "Dejar la grilla como estaba | Agustín David Cruz González (16/Jul/2014)."

        Gridlista2.AllowPaging = true; // Se vuelve a dejar la grilla en el estado original de paginación (AllowPaging = true)
        Gridlista2.DataBind(); // Se vuelve a enlazar la grilla.

        #endregion
    }

    protected void ImageButton11_Click(object sender, ImageClickEventArgs e)
    {
        Exportarexcel(GridListaInidicadores);
    }

    protected void ImageButton12_Click(object sender, ImageClickEventArgs e)
    {
        Exportarexcel(GridListaFlujo);
    }

    protected void Exportarexcel(GridView Grid)
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
        Response.AddHeader("Content-Disposition", "attachment;filename=data.xls");
        Response.Charset = "UTF-8";
        Response.ContentEncoding = Encoding.Default;
        Response.Write(sb.ToString());
        
        ApplicationInstance.CompleteRequest();

    }

    private DataTable ObtenerDatos()
    {
        DataTable tblDatos = new DataTable();

        tblDatos.Columns.Add(new DataColumn("Zonas", Type.GetType("System.String")));
        tblDatos.Columns.Add(new DataColumn("Porcentaje", Type.GetType("System.String")));

        tblDatos.Rows.Add(new object[] { "Norte", "20" });
        tblDatos.Rows.Add(new object[] { "Sur", "35" });
        tblDatos.Rows.Add(new object[] { "Este", "30" });
        tblDatos.Rows.Add(new object[] { "Oeste", "15" });

        return tblDatos;
    }

    protected void cmbSector_SelectedIndexChanged(object sender, EventArgs e)
    {
        //     GrillaLlenarBalance();
        GrillaLlenar();
        GrillaLlenarEmpresas();
        GrillaLlenaRanking();
        GrillaLlenarIndicadores();
        GrillaLlenarFlujo();


    }
}
