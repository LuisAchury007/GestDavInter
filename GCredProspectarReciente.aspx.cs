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
using CarlosAg.ExcelXmlWriter;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public partial class GCredProspectarReciente : System.Web.UI.Page
{
    public string macroState = "collapse";
    public string macroState2 = "collapse2";
    public string macroState3 = "collapse3";
    public long[] listaItems;
    List<long> elementos = new List<long>();
    string CadIndicadores = "";
    string CadCiudad = "";
    DataSet Dscompleto;
    DataSet dsSec = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["IDusuario"] == null)
        {
            Response.Redirect("Salir.aspx");
        }


        if (Page.IsPostBack == false)
        {

            llenardatos();
        }
        else
        {
            if (HiddenField1.Value == "True")
            {
                Dscompleto = (DataSet)this.ViewState["DscompletoState"];
                GridLista.DataSource = Dscompleto.Tables[0];
                GridLista.DataBind();
            }
        }


    }

    private void llenardatos()
    {

        Datos sv = new Datos();

        DataSet ds = new DataSet();
       
            int i = 0;

            TreeDatos.Nodes.Clear();

            TreeNode nodoPadre = new TreeNode();
            TreeNode nodoFinal = new TreeNode();

        // Lista de ciudades

        ds = sv.Ciudad(0, 1, Convert.ToInt32(Session["IdPais"].ToString()));

        nodoPadre = new TreeNode("Region", "0");
        nodoPadre.SelectAction = TreeNodeSelectAction.Expand;
        nodoPadre.ToolTip = "Seleccionar Region";



        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DataRow filaMacro = ds.Tables[0].Rows[i];
            nodoFinal = new TreeNode(filaMacro[1].ToString(), filaMacro[0].ToString());
            nodoFinal.SelectAction = TreeNodeSelectAction.None;
            nodoFinal.ToolTip = filaMacro[1].ToString();
            nodoPadre.ChildNodes.Add(nodoFinal);
        }
        TreeDatos.Nodes.Add(nodoPadre);

        ds.Clear();

        // Lista de Indicadores 

        ds = sv.CredIndicadores(1);

            nodoPadre = new TreeNode("Indicadores", "1");
            nodoPadre.SelectAction = TreeNodeSelectAction.Expand;
            nodoPadre.ToolTip = "Seleccionar Indicadores";


            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow filaMacro = ds.Tables[0].Rows[i];
                nodoFinal = new TreeNode(filaMacro[1].ToString(), filaMacro[0].ToString());
                nodoFinal.SelectAction = TreeNodeSelectAction.None;
                nodoFinal.ToolTip = filaMacro[1].ToString();
                nodoPadre.ChildNodes.Add(nodoFinal);
            }
            TreeDatos.Nodes.Add(nodoPadre);

            ds.Clear();




            // Lista de Balance 

            ds = sv.CredPuc(true);

            nodoPadre = new TreeNode("Balance", "2");
            nodoPadre.SelectAction = TreeNodeSelectAction.Expand;
            nodoPadre.ToolTip = "Seleccionar Balance";


            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow filaMacro = ds.Tables[0].Rows[i];
                nodoFinal = new TreeNode(filaMacro[1].ToString(), filaMacro[0].ToString());
                nodoFinal.SelectAction = TreeNodeSelectAction.None;
                nodoFinal.ToolTip = filaMacro[1].ToString();
                nodoPadre.ChildNodes.Add(nodoFinal);
            }
            TreeDatos.Nodes.Add(nodoPadre);

            ds.Clear();

            // Lista de P&G 

            ds = sv.CredPuc(false);

            nodoPadre = new TreeNode("P&G", "3");
            nodoPadre.SelectAction = TreeNodeSelectAction.Expand;
            nodoPadre.ToolTip = "Seleccionar Balance";


            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow filaMacro = ds.Tables[0].Rows[i];
                nodoFinal = new TreeNode(filaMacro[1].ToString(), filaMacro[0].ToString());
                nodoFinal.SelectAction = TreeNodeSelectAction.None;
                nodoFinal.ToolTip = filaMacro[1].ToString();
                nodoPadre.ChildNodes.Add(nodoFinal);
            }
            TreeDatos.Nodes.Add(nodoPadre);

            ds.Clear();



            TreeDatos.CollapseAll();
            TreeDatos.Font.Name = "Arial";
            ds.Clear();


        
    }

    protected void cargarInformacion()
    {
        int valor = 0;
        int total;

        total = ContarMarcador(TreeDatos.Nodes[1], valor);
        total = total + ContarMarcador(TreeDatos.Nodes[2], valor);
        total = total + ContarMarcador(TreeDatos.Nodes[3], valor);



        if (total > 0)
        {

            //        DisplayChildNodeText(TreeDatos.Nodes[1]);

            TableCell objCell = default(TableCell);
            TableRow objRow = default(TableRow);
            objRow = new TableRow();
            //objCell = new TableCell();
            //objCell.Text = "ID";
            //objCell.Width = 20;
            //objCell.BackColor = System.Drawing.Color.Bisque;
            //objRow.Cells.Add(objCell);
            objCell = new TableCell();
            objCell.Text = "INDICADOR";
            objCell.Width = 100;
            objCell.BackColor = System.Drawing.Color.DarkSeaGreen;
            objCell.Font.Name = "Arial";
            objCell.Font.Bold = true;
            objCell.HorizontalAlign = HorizontalAlign.Center;
            objCell.BorderStyle = BorderStyle.Solid;
            objCell.BorderWidth = 1;
            objRow.Cells.Add(objCell);
            objCell = new TableCell();
            objCell.Text = "PROMEDIO";
            objCell.Width = 100;
            objCell.BackColor = System.Drawing.Color.DarkSeaGreen;
            objCell.Font.Name = "Arial";
            objCell.Font.Bold = true;
            objCell.HorizontalAlign = HorizontalAlign.Center;
            objCell.BorderStyle = BorderStyle.Solid;
            objCell.BorderWidth = 1;
            objRow.Cells.Add(objCell);
            objCell = new TableCell();
            objCell.Text = "MINIMO";
            objCell.Width = 100;
            objCell.BackColor = System.Drawing.Color.DarkSeaGreen;
            objCell.Font.Name = "Arial";
            objCell.Font.Bold = true;
            objCell.HorizontalAlign = HorizontalAlign.Center;
            objCell.BorderStyle = BorderStyle.Solid;
            objCell.BorderWidth = 1;
            objRow.Cells.Add(objCell);
            objCell = new TableCell();
            objCell.Text = "MAXIMO";
            objCell.Width = 100;
            objCell.BackColor = System.Drawing.Color.DarkSeaGreen;
            objCell.Font.Name = "Arial";
            objCell.Font.Bold = true;
            objCell.HorizontalAlign = HorizontalAlign.Center;
            objCell.BorderStyle = BorderStyle.Solid;
            objCell.BorderWidth = 1;
            objRow.Cells.Add(objCell);
            TableDatos.Rows.Add(objRow);

            ValidaIndicador(TreeDatos.Nodes[1]);
            ValidaPuc(TreeDatos.Nodes[2]);
            ValidaPuc(TreeDatos.Nodes[3]);
            ValidaCiudad(TreeDatos.Nodes[0]);

            if (CadCiudad.Length > 0)
            {
                CadCiudad = CadCiudad.Substring(1, CadCiudad.Length - 1);
            }

            if (CadIndicadores.Length > 0)
            {
                CadIndicadores = CadIndicadores.Substring(1, CadIndicadores.Length - 1);
            }


            this.HdCiudad.Value = CadCiudad;
            this.HdIndicadores.Value = CadIndicadores;

            listaItems = elementos.ToArray();
            Session["listaItems"] = listaItems;



        }
        else
        {
            macroState = "in";
            macroState2 = "collapse";
            Response.Write("<script>alert('Debe Seleccionar al menos un Indicador o Cuenta')</script>");

        }
    }

    protected void cargarInformacionDinamica()
    {
        int valor = 0;
        int total;

        total = ContarMarcador(TreeDatos.Nodes[1], valor);
        total = total + ContarMarcador(TreeDatos.Nodes[2], valor);
        total = total + ContarMarcador(TreeDatos.Nodes[3], valor);



        if (total > 0)
        {

            //        DisplayChildNodeText(TreeDatos.Nodes[1]);

            TableCell objCell = default(TableCell);
            TableRow objRow = default(TableRow);
            objRow = new TableRow();
            //objCell = new TableCell();
            //objCell.Text = "ID";
            //objCell.Width = 20;
            //objCell.BackColor = System.Drawing.Color.Bisque;
            //objRow.Cells.Add(objCell);
            objCell = new TableCell();
            objCell.Text = "INDICADOR";
            objCell.Width = 100;
            objCell.BackColor = System.Drawing.Color.DarkSeaGreen;
            objCell.Font.Name = "Arial";
            objCell.Font.Bold = true;
            objCell.HorizontalAlign = HorizontalAlign.Center;
            objCell.BorderStyle = BorderStyle.Solid;
            objCell.BorderWidth = 1;
            objRow.Cells.Add(objCell);
            objCell = new TableCell();
            objCell.Text = "PROMEDIO";
            objCell.Width = 100;
            objCell.BackColor = System.Drawing.Color.DarkSeaGreen;
            objCell.Font.Name = "Arial";
            objCell.Font.Bold = true;
            objCell.HorizontalAlign = HorizontalAlign.Center;
            objCell.BorderStyle = BorderStyle.Solid;
            objCell.BorderWidth = 1;
            objRow.Cells.Add(objCell);
            objCell = new TableCell();
            objCell.Text = "MINIMO";
            objCell.Width = 100;
            objCell.BackColor = System.Drawing.Color.DarkSeaGreen;
            objCell.Font.Name = "Arial";
            objCell.Font.Bold = true;
            objCell.HorizontalAlign = HorizontalAlign.Center;
            objCell.BorderStyle = BorderStyle.Solid;
            objCell.BorderWidth = 1;
            objRow.Cells.Add(objCell);
            objCell = new TableCell();
            objCell.Text = "MAXIMO";
            objCell.Width = 100;
            objCell.BackColor = System.Drawing.Color.DarkSeaGreen;
            objCell.Font.Name = "Arial";
            objCell.Font.Bold = true;
            objCell.HorizontalAlign = HorizontalAlign.Center;
            objCell.BorderStyle = BorderStyle.Solid;
            objCell.BorderWidth = 1;
            objRow.Cells.Add(objCell);
            TableDatos.Rows.Add(objRow);

            ValidaIndicadorDinamico(TreeDatos.Nodes[1]);
            ValidaPuc(TreeDatos.Nodes[2]);
            ValidaPuc(TreeDatos.Nodes[3]);
            ValidaCiudad(TreeDatos.Nodes[0]);

            if (CadCiudad.Length > 0)
            {
                CadCiudad = CadCiudad.Substring(1, CadCiudad.Length - 1);
            }

            if (CadIndicadores.Length > 0)
            {
                CadIndicadores = CadIndicadores.Substring(1, CadIndicadores.Length - 1);
            }


            this.HdCiudad.Value = CadCiudad;
            this.HdIndicadores.Value = CadIndicadores;

            listaItems = elementos.ToArray();
            Session["listaItems"] = listaItems;



        }
        else
        {
            macroState = "in";
            macroState2 = "collapse";
            Response.Write("<script>alert('Debe Seleccionar al menos un Indicador o Cuenta')</script>");

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        macroState2 = "in";
        macroState3 = "collapse3";
        LimpiarCapos();
        cargarInformacion();
    }

    void DisplayChildNodeText(TreeNode node)
    {
        Message.Text += node.Text + "<br />";


        for (int i = 0; i < node.ChildNodes.Count; i++)
        {
            DisplayChildNodeText(node.ChildNodes[i]);
        }

    }

    int ContarMarcador(TreeNode node, int valor)
    {

        if (node.Checked == true)
        {

            valor = valor + 1;
            CadIndicadores = CadIndicadores + ',' + node.Value;
            ListBox1.Items.Add(node.Value);
            elementos.Add(long.Parse(node.Value));
        }

        for (int i = 0; i < node.ChildNodes.Count; i++)
        {

            valor = ContarMarcador(node.ChildNodes[i], valor);
        }

        return valor;
    }

    void ValidaIndicador(TreeNode node)
    {
        TableCell objCell = default(TableCell);
        TableRow objRow = default(TableRow);

        for (int i = 0; i < node.ChildNodes.Count; i++)
        {
            TreeNode hijo;
            hijo = node.ChildNodes[i];

            if (hijo.Checked == true)
            {

                Datos sv = new Datos();

                DataSet ds = new DataSet();
               
                    ds = sv.CredIndicadorMaxMinAux(0, int.Parse(hijo.Value), int.Parse(Session["IDusuario"].ToString()));

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objRow = new TableRow();

                        //Se crea una fila de la tabla

                        //objCell = new TableCell();
                        //objCell.Text = Convert.ToString(hijo.Value);
                        //objCell.BackColor = System.Drawing.Color.Beige;
                        //objRow.Cells.Add(objCell);

                        Label objeto = new Label();
                        objeto.ID = "Nombre" + "-" + Convert.ToString(hijo.Value);
                        objeto.Text = Convert.ToString(ds.Tables[0].Rows[0]["Nombre"].ToString());
                        objeto.EnableViewState = true;
                        objCell = new TableCell();
                        objCell.Controls.Add(objeto);
                        objCell.BackColor = System.Drawing.Color.Gainsboro;
                        objCell.Font.Name = "Arial";
                        objCell.Font.Bold = true;
                        objCell.HorizontalAlign = HorizontalAlign.Center;
                        objRow.Cells.Add(objCell);

                        Label Promedio = new Label();
                        Promedio.ID = "Promedio" + "-" + Convert.ToString(hijo.Value);
                        Promedio.Text = Math.Round(decimal.Parse(ds.Tables[0].Rows[0]["Promedio"].ToString())).ToString();
                        Promedio.EnableViewState = true;
                        objCell = new TableCell();
                        objCell.Controls.Add(Promedio);
                        objCell.Font.Name = "Arial";
                        objCell.HorizontalAlign = HorizontalAlign.Right;
                        objRow.Cells.Add(objCell);

                        TextBox Minimo = new TextBox();
                        Minimo.ID = "Minimo" + "-" + Convert.ToString(hijo.Value);
                        Minimo.Text = Math.Round(decimal.Parse(ds.Tables[0].Rows[0]["Minimo"].ToString())).ToString();
                        Minimo.Style["text-align"] = "Right";
                        Minimo.EnableViewState = true;
                        objCell = new TableCell();
                        objCell.Controls.Add(Minimo);
                        objCell.Font.Name = "Arial";
                        objCell.HorizontalAlign = HorizontalAlign.Right;
                        objRow.Cells.Add(objCell);

                        TextBox Maximo = new TextBox();
                        Maximo.ID = "Maximo" + "-" + Convert.ToString(hijo.Value);
                        Maximo.Text = Math.Round(decimal.Parse(ds.Tables[0].Rows[0]["Maximo"].ToString())).ToString();
                        Maximo.EnableViewState = true;
                        Maximo.Style["text-align"] = "Right";
                        objCell = new TableCell();
                        objCell.Controls.Add(Maximo);
                        objCell.Font.Name = "Arial";
                        objCell.HorizontalAlign = HorizontalAlign.Right;
                        objRow.Cells.Add(objCell);
                        TableDatos.Rows.Add(objRow);
                    }
                    else
                    {
                        int indice = elementos.FindIndex(x => x == int.Parse(hijo.Value));
                        if (indice > -1)
                        {
                            elementos.RemoveAt(indice);
                        }
                    }


                    ds.Clear();
                

            }



        }


    }

    void ValidaIndicadorDinamico(TreeNode node)
    {
        TableCell objCell = default(TableCell);
        TableRow objRow = default(TableRow);

        for (int i = 0; i < node.ChildNodes.Count; i++)
        {
            TreeNode hijo;
            hijo = node.ChildNodes[i];

            if (hijo.Checked == true)
            {

                Datos sv = new Datos();

                DataSet ds = new DataSet();
               
                    ds = sv.CredIndicadorMaxMinAux(0, int.Parse(hijo.Value), int.Parse(Session["IDusuario"].ToString()));

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objRow = new TableRow();

                        //Se crea una fila de la tabla

                        //objCell = new TableCell();
                        //objCell.Text = Convert.ToString(hijo.Value);
                        //objCell.BackColor = System.Drawing.Color.Beige;
                        //objRow.Cells.Add(objCell);

                        Label objeto = new Label();
                        objeto.ID = "Nombre" + "-" + Convert.ToString(hijo.Value);
                        objeto.Text = Convert.ToString(ds.Tables[0].Rows[0]["Nombre"].ToString());
                        objeto.EnableViewState = true;
                        objCell = new TableCell();
                        objCell.Controls.Add(objeto);
                        objCell.BackColor = System.Drawing.Color.Gainsboro;
                        objCell.Font.Name = "Arial";
                        objCell.Font.Bold = true;
                        objCell.HorizontalAlign = HorizontalAlign.Center;
                        objRow.Cells.Add(objCell);

                        Label Promedio = new Label();
                        Promedio.ID = "Promedio" + "-" + Convert.ToString(hijo.Value);
                        Promedio.Text = Math.Round(decimal.Parse(ds.Tables[0].Rows[0]["Promedio"].ToString())).ToString();
                        Promedio.EnableViewState = true;
                        objCell = new TableCell();
                        objCell.Controls.Add(Promedio);
                        objCell.Font.Name = "Arial";
                        objCell.HorizontalAlign = HorizontalAlign.Right;
                        objRow.Cells.Add(objCell);

                        TextBox Minimo = new TextBox();
                        Minimo.ID = "Minimo" + "-" + Convert.ToString(hijo.Value);
                        Minimo.Text = Math.Round(decimal.Parse(ds.Tables[0].Rows[0]["Minimo"].ToString())).ToString();
                        Minimo.Style["text-align"] = "Right";
                        Minimo.EnableViewState = true;
                        objCell = new TableCell();
                        objCell.Controls.Add(Minimo);
                        objCell.Font.Name = "Arial";
                        objCell.HorizontalAlign = HorizontalAlign.Right;
                        objRow.Cells.Add(objCell);

                        TextBox Maximo = new TextBox();
                        Maximo.ID = "Maximo" + "-" + Convert.ToString(hijo.Value);
                        Maximo.Text = Math.Round(decimal.Parse(ds.Tables[0].Rows[0]["Maximo"].ToString())).ToString();
                        Maximo.EnableViewState = true;
                        Maximo.Style["text-align"] = "Right";
                        objCell = new TableCell();
                        objCell.Controls.Add(Maximo);
                        objCell.Font.Name = "Arial";
                        objCell.HorizontalAlign = HorizontalAlign.Right;
                        objRow.Cells.Add(objCell);
                        TableDatos.Rows.Add(objRow);
                    }
                    else
                    {
                        int indice = elementos.FindIndex(x => x == int.Parse(hijo.Value));
                        if (indice > -1)
                        {
                            elementos.RemoveAt(indice);
                        }
                    }


                    ds.Clear();
               

            }



        }


    }

    void ValidaPuc(TreeNode node)
    {
        TableCell objCell = default(TableCell);
        TableRow objRow = default(TableRow);

        for (int i = 0; i < node.ChildNodes.Count; i++)
        {
            TreeNode hijo;
            hijo = node.ChildNodes[i];

            if (hijo.Checked == true)
            {

                Datos sv = new Datos();

                DataSet ds = new DataSet();
               
                    ds = sv.CredPucMaxMinAux(0, int.Parse(hijo.Value), int.Parse(Session["IDusuario"].ToString()), Convert.ToInt32(Session["IdPais"].ToString()));

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objRow = new TableRow();

                        //Se crea una fila de la tabla

                        //objCell = new TableCell();
                        //objCell.Text = Convert.ToString(hijo.Value);
                        //objCell.BackColor = System.Drawing.Color.Beige;
                        //objRow.Cells.Add(objCell);

                        Label objeto = new Label();
                        objeto.ID = "Nombre" + "-" + Convert.ToString(hijo.Value);
                        objeto.Text = Convert.ToString(ds.Tables[0].Rows[0]["Cuenta"].ToString());
                        objeto.EnableViewState = true;
                        objCell = new TableCell();
                        objCell.Controls.Add(objeto);
                        objCell.BackColor = System.Drawing.Color.Gainsboro;
                        objCell.Font.Name = "Arial";
                        objCell.Font.Bold = true;
                        objCell.HorizontalAlign = HorizontalAlign.Center;
                        objRow.Cells.Add(objCell);

                        Label Promedio = new Label();
                        Promedio.ID = "Promedio" + "-" + Convert.ToString(hijo.Value);
                        Promedio.Text = Math.Round(decimal.Parse(ds.Tables[0].Rows[0]["Promedio"].ToString())).ToString();
                        Promedio.EnableViewState = true;
                        objCell = new TableCell();
                        objCell.Controls.Add(Promedio);
                        objCell.Font.Name = "Arial";
                        objCell.HorizontalAlign = HorizontalAlign.Right;
                        objRow.Cells.Add(objCell);

                        TextBox Minimo = new TextBox();
                        Minimo.ID = "Minimo" + "-" + Convert.ToString(hijo.Value);
                        Minimo.Text = Math.Round(decimal.Parse(ds.Tables[0].Rows[0]["Minimo"].ToString())).ToString();
                        Minimo.Style["text-align"] = "Right";
                        Minimo.EnableViewState = true;
                        objCell = new TableCell();
                        objCell.Controls.Add(Minimo);
                        objCell.Font.Name = "Arial";
                        objCell.HorizontalAlign = HorizontalAlign.Right;
                        objRow.Cells.Add(objCell);

                        TextBox Maximo = new TextBox();
                        Maximo.ID = "Maximo" + "-" + Convert.ToString(hijo.Value);
                        Maximo.Text = Math.Round(decimal.Parse(ds.Tables[0].Rows[0]["Maximo"].ToString())).ToString();
                        Maximo.EnableViewState = true;
                        Maximo.Style["text-align"] = "Right";
                        objCell = new TableCell();
                        objCell.Controls.Add(Maximo);
                        objCell.Font.Name = "Arial";
                        objCell.HorizontalAlign = HorizontalAlign.Right;
                        objRow.Cells.Add(objCell);
                        TableDatos.Rows.Add(objRow);
                    }
                    else
                    {
                        int indice = elementos.FindIndex(x => x == int.Parse(hijo.Value));
                        if (indice > -1)
                        {
                            elementos.RemoveAt(indice);
                        }
                    }


                    ds.Clear();

              
            }



        }


    }

    void ValidaCiudad(TreeNode node)
    {

        for (int i = 0; i < node.ChildNodes.Count; i++)
        {
            TreeNode hijo;
            hijo = node.ChildNodes[i];

            if (hijo.Checked == true)
            {
                CadCiudad = CadCiudad + ',' + hijo.Value;

            }
        }

    }

    protected void LimpiarCapos()
    {
        Session["listaItems"] = null;
        GridLista.DataSource = null;
        GridLista.DataBind();
        elementos.Clear();
        DropDownList1.DataSource = null;
        DropDownList1.Items.Clear();
        // Dscompleto = null;

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        int contador2 = int.Parse(HidContador2.Value), Contador3 = 0;
        if (contador2 > 0)
        {
            macroState2 = "in";
            macroState3 = "collapse3";
            LimpiarCapos();
            cargarInformacion();
            macroState2 = "collapse2";
        }
        else
        {

            LimpiarCapos();
            cargarInformacionDinamica();
            macroState2 = "collapse2";
        }

        int NumColumnas = GridLista.Columns.Count - 1;

        if (NumColumnas > 3)
        {
            for (int z = 1; z <= NumColumnas; z++)
            {
                if (z > 3)
                {
                    // GridLista.Columns.RemoveAt(z);
                    GridLista.Columns[z].Visible = false;
                }
            }
        }

        long[] listaItems = (long[])Session["listaItems"];
        
        if (listaItems == null)
        {
            macroState = "in";
            return;
        }
        macroState3 = "in";
        int[] ListaIndic = new int[listaItems.Length];
        double[] IndicMin = new double[listaItems.Length];
        double[] IndicMax = new double[listaItems.Length];
        string[] NomIndic = new string[listaItems.Length];

        int i = 0;
        int j = 1;
        int y = 0;

        DataView vista = null;
        string ordenar = null;

        DataSet dsDatos = new DataSet();

        Boolean valido = true;




        for (i = 0; i < listaItems.Length; i++)
        {

            valido = isFloatNumber(Request.Form["ctl00$ContentPlaceHolder1$Minimo-" + listaItems[i].ToString()]);
            if (valido == false)
                break;


            valido = isFloatNumber(Request.Form["ctl00$ContentPlaceHolder1$Maximo-" + listaItems[i].ToString()]);
            if (valido == false)
                break;
        }



        if (valido)
        {


            for (i = 0; i < listaItems.Length; i++)
            {
                ListaIndic[i] = int.Parse(listaItems[i].ToString());
                IndicMin[i] = double.Parse(Request.Form["ctl00$ContentPlaceHolder1$Minimo-" + listaItems[i].ToString()]);
                IndicMax[i] = double.Parse(Request.Form["ctl00$ContentPlaceHolder1$Maximo-" + listaItems[i].ToString()]);
            }


            for (i = 0; i < listaItems.Length; i++)
            {
                Datos sv2 = new Datos();

                dsDatos = sv2.CredIndicadorNom(int.Parse(listaItems[i].ToString()));
                NomIndic[i] = dsDatos.Tables[0].Rows[0][0].ToString();
                dsDatos.Clear();

            }

            Datos sv = new Datos();


            dsDatos = sv.GCredProspectarReciente(this.HdIndicadores.Value, this.HdCiudad.Value, this.ChckArchivo.Checked, int.Parse(Session["IDusuario"].ToString()), Convert.ToInt32(Session["IdPais"].ToString()));


            int cuantos = 0;
            cuantos = dsDatos.Tables[0].Columns.Count;


            DataTable dt = new DataTable();
            DataRow dr = null;


            for (i = 0; i < cuantos; i++)
            {
                if (i > 22)
                {
                    dt.Columns.Add("C" + (i - 22));
                }
                dt.Columns.Add(new DataColumn(dsDatos.Tables[0].Columns[i].ColumnName, typeof(string)));
            }
            dt.Columns.Add("Cump");

            int indice = 0;
            int totalcum = 0;
            for (i = 0; i < dsDatos.Tables[0].Rows.Count; i++)
            {
                dr = dt.NewRow();
                totalcum = 0;
                for (j = 0; j < cuantos; j++)
                {
                    if (j > 22)
                    {
                        indice = 0;
                        for (y = 0; y < NomIndic.Length; y++)
                        {
                            if (NomIndic[y].Trim() == dsDatos.Tables[0].Columns[j].ColumnName.Trim())
                            {
                                indice = y;
                            }
                        }
                        if (!string.IsNullOrEmpty(Convert.ToString(dsDatos.Tables[0].Rows[i][j])))
                        {
                            if (double.Parse(dsDatos.Tables[0].Rows[i][j].ToString()) >= IndicMin[indice] & double.Parse(dsDatos.Tables[0].Rows[i][j].ToString()) <= IndicMax[indice])
                            {
                                dr["C" + (j - 22)] = "cum.gif";
                                totalcum = totalcum + 1;
                            }
                            else
                            {
                                dr["C" + (j - 22)] = "noCum.gif";
                            }
                        }
                        else
                        {
                            dr["C" + (j - 22)] = "noCum.gif";
                        }
                        if (object.ReferenceEquals(dsDatos.Tables[0].Rows[i][j], DBNull.Value))
                        {
                            dr[dsDatos.Tables[0].Columns[j].ColumnName] = "0.00";
                        }
                        else
                        {
                            dr[dsDatos.Tables[0].Columns[j].ColumnName] = dsDatos.Tables[0].Rows[i][j];
                        }
                    }
                    else
                    {
                        dr[dsDatos.Tables[0].Columns[j].ColumnName] = dsDatos.Tables[0].Rows[i][j];
                    }
                }
                dr["Cump"] = totalcum;
                dt.Rows.Add(dr);
            }



            //Objeto Columna:

            for (i = 23; i <= dt.Columns.Count - 2; i++)
            {
                if (i % 2 == 0)
                {
                    BoundField lobColumnBound = new BoundField();
                    lobColumnBound.DataField = dt.Columns[i].ColumnName;
                    lobColumnBound.HeaderText = dt.Columns[i].ColumnName;
                    lobColumnBound.ItemStyle.HorizontalAlign = HorizontalAlign.Right;

                    lobColumnBound.DataFormatString = "{0:N}";

                    GridLista.Columns.Add(lobColumnBound);

                }
                else
                {
                    ImageField tcl1 = new ImageField();
                    tcl1.DataImageUrlField = dt.Columns[i].ColumnName;
                    tcl1.DataImageUrlFormatString = "~/Grafix/{0}";
                    GridLista.Columns.Add(tcl1);

                }
            }


            ordenar = "Cump DESC";

            Contador3 = int.Parse(HidContador2.Value) + 1;
            HidContador2.Value = Convert.ToString(Contador3);



            HiddenField2.Value = ordenar;


            vista = dt.DefaultView;
            vista.Sort = ordenar;

            DataSet dsFiltered = new DataSet(); //create a new dataset
            dsFiltered.Tables.Add(DataViewAsDataTable(vista)); //fill the dataset with the sorted results

            GridLista.DataSource = dsFiltered.Tables[0];
            GridLista.DataBind();

            //DataTable dtf = new DataTable();
            //dtf = vista.Table;



            ListItem oItem1 = new ListItem("Todos ", "-1");
            DropDownList1.Items.Add(oItem1);

            for (i = 23; i <= cuantos; i++)
            {
                ListItem oItem = new ListItem("Cumplen " + (i - 23), (i - 23).ToString());
                DropDownList1.Items.Add(oItem);
            }


            Dscompleto = new DataSet();
            // Dscompleto.Tables.Add(dtf);
            // Dscompleto.Tables.Add(vista.Table);

            Dscompleto = dsFiltered;
            HiddenField1.Value = "True";


        }
        else
        {

            Button1_Click(sender, e);
            Response.Write("<script>alert('Los Mínimos y los Máximos son numericos y obligatorios')</script>");
        }

    }

    public void filtrar()
    {

        string filtro;


        if (DropDownList1.SelectedValue != "-1")
        {
            filtro = "Cump = " + DropDownList1.SelectedValue;
            DataView vista = new DataView(Dscompleto.Tables[0]);
            vista.Sort = HiddenField2.Value;
            vista.RowFilter = filtro;

            DataSet dsFiltered = new DataSet(); //create a new dataset
            dsFiltered.Tables.Add(DataViewAsDataTable(vista)); //fill the dataset with the sorted results

            GridLista.DataSource = dsFiltered.Tables[0];
            GridLista.DataBind();

            Session["listaItems"] = null;
            elementos.Clear();
        }
        else
        {
            //DataView vista = new DataView(Dscompleto.Tables[0]);
            //vista.Sort = HiddenField2.Value;
            //DataSet dsFiltered = new DataSet(); //create a new dataset
            //dsFiltered.Tables.Add(DataViewAsDataTable(vista)); //fill the dataset with the sorted results

            GridLista.DataSource = Dscompleto.Tables[0];
            GridLista.DataBind();
        }

        cargarInformacionDinamica();
        macroState3 = "in";
    }

    protected void Page_PreRender(object sender, System.EventArgs e)
    {
        this.ViewState.Add("DscompletoState", Dscompleto);
    }

    /*
       public string SortExpression
       {
           get { return (ViewState["SortExpression"] == null ? string.Empty : ViewState["SortExpression"].ToString()); }
           set { ViewState["SortExpression"] = value; }
       }

       public string SortDirection
       {
           get { return (ViewState["SortDirection"] == null ? string.Empty : ViewState["SortDirection"].ToString()); }
           set { ViewState["SortDirection"] = value; }
       }

       private string GetSortDirection(string sortExpression)
       {
           if (SortExpression == sortExpression)
           {
               if (SortDirection == "ASC")
                   SortDirection = "DESC";
               else if (SortDirection == "DESC")
                   SortDirection = "ASC";
               return SortDirection;
           }
           else
           {
               SortExpression = sortExpression;
               SortDirection = "ASC";
               return SortDirection;
           }
       }

       protected void Grid_Sorting(object sender, GridViewSortEventArgs e)
       {
           DataTable dataTable = GridLista.DataSource as DataTable;

           if (dataTable != null)
           {
               DataView dataView = new DataView(dataTable);
               dataView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);

               GridLista.DataSource = dataView;
               GridLista.DataBind();
           }
       }

       protected void Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
       {

        


           GridLista.PageIndex = e.NewPageIndex;
           GridLista.SelectedIndex = -1;
           GridLista.DataBind();

   

       }

     */

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
        DataTable dataTable = GridLista.DataSource as DataTable;
        DataView dataView = new DataView(dataTable);


        GridLista.DataSource = SortDataTable(dataView, true);
        // Calculate the current page number. 
        GridLista.PageIndex = e.NewPageIndex;


        // Reset selected index 
        GridLista.SelectedIndex = -1;

        GridLista.DataBind();
        cargarInformacionDinamica();
        macroState3 = "in";

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
        DataTable dataTable = GridLista.DataSource as DataTable;


        DataView dataView = new DataView(dataTable);

        GridViewSortExpression = e.SortExpression;
        int pageIndex = GridLista.PageIndex;
        GridLista.DataSource = SortDataTable(dataView, false);
        GridLista.DataBind();
        GridLista.PageIndex = pageIndex;

        cargarInformacionDinamica();
        macroState3 = "in";
    }



    public static DataTable DataViewAsDataTable(DataView dv)
    {
        DataTable dt = dv.Table.Clone();
        foreach (DataRowView drv in dv)
            dt.ImportRow(drv.Row);
        return dt;
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



    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {
        DataSet dsDatos = new DataSet();
        dsDatos = Dscompleto;

        for (int i = 0; i < dsDatos.Tables[0].Rows.Count; i++)
        {

            for (int j = 21; j < dsDatos.Tables[0].Columns.Count; j++)
            {
                if (dsDatos.Tables[0].Rows[i][j].ToString() == "cum.gif")
                {
                    dsDatos.Tables[0].Rows[i][j] = "SI";
                }
                else if (dsDatos.Tables[0].Rows[i][j].ToString() == "noCum.gif")
                {
                    dsDatos.Tables[0].Rows[i][j] = "NO";
                }


            }

        }


        string NomArchivo = "Prospectacion" + int.Parse(Session["IDusuario"].ToString()) + ".xls";
        string targetPath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + @"Archivos\Datos";
        string destFile = System.IO.Path.Combine(targetPath, NomArchivo);
        string Canedana;


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

        #region "Centrar encabezados en negrilla en Excel | Agustín David Cruz González (17/Jun/2014)."

        // Add some styles to the Workbook
        WorksheetStyle style = book.Styles.Add("Cabecera");
        style.Font.Bold = true;
        style.Alignment.Horizontal = StyleHorizontalAlignment.Center;

        //Bordes y color de encabezados | Agustín David Cruz González (03/Jun/2014).
        style.Interior.Pattern = StyleInteriorPattern.Solid;
        style.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
        style.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
        style.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
        style.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
        style.Interior.Color = "#D7E4BC";

        #endregion

        #region "Estilo para contenido | Agustín David Cruz González (17/Jun/2014)."

        WorksheetStyle style2 = book.Styles.Add("Contenido");
        style2.Interior.Pattern = StyleInteriorPattern.Solid;
        style2.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
        style2.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
        style2.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
        style2.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);

        #endregion

        // Add a Worksheet with some data
        Worksheet sheet = book.Worksheets.Add("Prospectacion");
        WorksheetRow row = sheet.Table.Rows.Add();

        row.Index = 1;

        for (int i = 0; i < dsDatos.Tables[0].Columns.Count; i++)
        {
            row.Cells.Add(new WorksheetCell(dsDatos.Tables[0].Columns[i].ColumnName, "Cabecera"));
        }


        for (int i = 0; i < dsDatos.Tables[0].Rows.Count; i++)
        {
            row = sheet.Table.Rows.Add();
            for (int j = 0; j < dsDatos.Tables[0].Columns.Count; j++)
            {
                if (j < 23)
                    row.Cells.Add(new WorksheetCell(Convert.ToString(dsDatos.Tables[0].Rows[i][j]), "Contenido"));
                else
                {

                    if (j % 2 == 0)
                    {
                        Canedana = Convert.ToString(dsDatos.Tables[0].Rows[i][j]);
                        Canedana = Canedana.Replace(",", ".");
                        row.Cells.Add(new WorksheetCell(Canedana.ToString(), DataType.Number));

                    }
                    else
                    {

                        row.Cells.Add(new WorksheetCell(Convert.ToString(dsDatos.Tables[0].Rows[i][j]), "Contenido"));

                    }
                }

            }



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



    static public bool isFloatNumber(string _numberText)
    {
        float Result = 0;
        bool numberResult = false;
        if (float.TryParse(_numberText, out Result))
        {
            numberResult = true;
        }
        return numberResult;
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        filtrar();
    }
}
