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
using System.IO;

public partial class CredGenerarArchivos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            LlenarDatos();
            ListarArchivos();
        }
    }

    private void LlenarDatos()
    {
        Datos sv = new Datos();
        DataSet DataS = new DataSet();
        DataS = sv.ReportesMac();
        DataView vista = new DataView();

        this.cmbReportes.DataSource = DataS.Tables[0].DefaultView;
        this.cmbReportes.DataTextField = "Reporte";
        this.cmbReportes.DataValueField = "IdReporte";
        this.cmbReportes.DataBind();

        DataS.Clear();

        DataS = sv.GCredVegencia(Convert.ToInt32(Session["IdPais"].ToString()), 0);

        int anioActual = DateTime.Now.Year;
        int anioMaximo = 2004;
        Boolean existe;

        for (int i = 0; i < DataS.Tables[0].Rows.Count; i++)
        {
            if (anioMaximo < int.Parse(DataS.Tables[0].Rows[i]["Anio"].ToString()))
                anioMaximo = int.Parse(DataS.Tables[0].Rows[i]["Anio"].ToString());
        }

        for (int i = anioMaximo; i <= anioActual; i++)
        {
            existe = false;
            for (int j = 0; j < DataS.Tables[0].Rows.Count; j++)
            {
                if (int.Parse(DataS.Tables[0].Rows[j]["Anio"].ToString()) == i)
                    existe = true;
            }

            if (existe == false)
                DataS.Tables[0].Rows.Add(i);
        }

        vista = DataS.Tables[0].DefaultView;
        vista.Sort = "Anio DESC";

        this.cmbanio.DataSource = vista;
        this.cmbanio.DataTextField = "Anio";
        this.cmbanio.DataValueField = "Anio";
        this.cmbanio.DataBind();

        DataS.Clear();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string NombreArchivo;
        string Funcion;
        string ruta;
        string linea;
        StreamWriter Escribir;

        Datos sv = new Datos();
        DataSet DataS = new DataSet();
        DataSet DS = new DataSet();

        DataS = sv.ReportesMacDatos(int.Parse(this.cmbReportes.SelectedValue));

        NombreArchivo = DataS.Tables[0].Rows[0]["NombreArchivo"].ToString();
        Funcion = DataS.Tables[0].Rows[0]["Funcion"].ToString();
        DataS.Clear();

        if (int.Parse(this.cmbReportes.SelectedValue) == 4)
            ValoresEspecial(NombreArchivo);
        else
        {
            DataS = EjecutarFuncion(Funcion);

            if (DataS.Tables[0].Rows.Count > 0)
            {
                DS = sv.ReportesCampos(int.Parse(this.cmbReportes.SelectedValue));

                int[] Campos = new int[DS.Tables[0].Rows.Count];
                Boolean[] Valor = new Boolean[DS.Tables[0].Rows.Count];

                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    Campos[i] = int.Parse(DS.Tables[0].Rows[i]["CaracteresNum"].ToString());
                    Valor[i] = Boolean.Parse(DS.Tables[0].Rows[i]["Valor"].ToString());
                }

                ruta = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Archivos\\Reportestxt\\";

                DirectoryInfo DIR = new DirectoryInfo(ruta);

                if (!DIR.Exists)
                {
                    DIR.Create();
                }

                ruta = ruta + NombreArchivo;

                if (File.Exists(ruta))
                {
                    System.IO.File.Delete(ruta);
                    ListarArchivos();
                }

                //  Escribir = File.CreateText(ruta);
                Escribir = new StreamWriter(ruta, false, System.Text.Encoding.Default);

                for (int i = 0; i < DataS.Tables[0].Rows.Count; i++)
                {
                    linea = "";
                    for (int j = 0; j < DataS.Tables[0].Columns.Count; j++)
                    {
                        string cadena = Blancos(DataS.Tables[0].Rows[i][j].ToString().Trim(), Campos[j], Valor[j]);
                        linea = linea + cadena;
                    }
                    Escribir.WriteLine(linea);
                }
                Escribir.Close();

                ListarArchivos();

                Response.Write("<script>alert('Archivo Generado')</script>");
            }
            else
            {
                Response.Write("<script>alert('Consulta no tiene Registros para Generar Archivo')</script>");
            }
        }

        // Reportestxt
    }

    private DataSet EjecutarFuncion(string funcion)
    {
        Datos sv = new Datos();
        DataSet DataS = new DataSet();

        switch (funcion)
        {
          /*  case "ReporCiudad":
                DataS = sv.ReporCiudad();
                break;*/
            case "ReporSector":
                DataS = sv.ReporSector();
                break;
         /*   case "ReporClientes":
                DataS = sv.ReporClientes();
                break;*/
            case "ReporValores":
                DataS = sv.ReporValores(int.Parse(this.cmbanio.SelectedValue), Convert.ToInt32(Session["IdPais"].ToString()));
                break;
            case "ReporPromPuc":
                DataS = sv.ReporPromedioSector(int.Parse(this.cmbanio.SelectedValue), Convert.ToInt32(Session["IdPais"].ToString()));
                break;
            case "ReporCIIU":
                DataS = sv.ReportesCiiu();
                break;
            case "ReporPuc":
                DataS = sv.ReportesPuc();
                break;
            case "ReporSectorCiiu":
                DataS = sv.ReportesSectorCiiu();
                break;
            case "ReporSectorCliente":
                DataS = sv.ReportesEmpresaSector();
                break;
        /*   case "ReporClientesActual":
                DataS = sv.ReporClientesActual(int.Parse(Session["IDusuario"].ToString()));
                break;*/
            case "ReporValoresActual":
                DataS = sv.ReporValoresActual(int.Parse(this.cmbanio.SelectedValue), int.Parse(Session["IDusuario"].ToString()), Convert.ToInt32(Session["IdPais"].ToString()));
                break;
            case "ReporSectorClienteActual":
                DataS = sv.ReportesEmpresaSectorActual(int.Parse(Session["IDusuario"].ToString()));
                break;
            case "ReporValoresParcial":
                DataS = sv.ReporValoresParcial(int.Parse(this.cmbanio.SelectedValue), int.Parse(Session["IDusuario"].ToString()), Convert.ToInt32(Session["IdPais"].ToString()));
                break;
        }

        return DataS;
    }

    private void ListarArchivos()
    {
        string ruta;
        ruta = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Archivos\\Reportestxt\\";

        DirectoryInfo dirInfo = new DirectoryInfo(ruta);

        if (!dirInfo.Exists)
        {
            dirInfo.Create();
        }

        FileInfo[] fileInfo = dirInfo.GetFiles("*.*", SearchOption.AllDirectories);

        GridArchivos.DataSource = fileInfo;
        GridArchivos.DataBind();
    }

    protected void GridArchivos_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Eliminar":
                string index = e.CommandArgument.ToString();
                string ruta = null;

                ruta = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Archivos\\Reportestxt\\" + index;
                System.IO.File.Delete(ruta);

                ListarArchivos();
                break;
            case "VerArchivo":

                string filename = e.CommandArgument.ToString();

                string filepath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Archivos\\Reportestxt\\" + filename;

                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                Response.TransmitFile(filepath);
                Response.Flush();
                Response.End();
                //ApplicationInstance.CompleteRequest();

                break;
        }
    }

    private string Blancos(string cadena, int tamano, Boolean Valor)
    {
        cadena = cadena.Replace("\n", "");

        if (Valor)
        {
            double valor = Math.Round(double.Parse(cadena), 2);
            cadena = valor.ToString();
            cadena = cadena.Replace(",", ".");

            int last = cadena.LastIndexOf(".");

            if (last == -1)
            {
                cadena = cadena + ".00";
            }
        }

        int cuantos = cadena.Length;
        if (cuantos < tamano)
        {
            for (int i = cuantos; i < tamano; i++)
            {
                cadena = cadena + " ";
            }
        }
        else
        {
            string retorno;
            retorno = cadena.Substring(0, tamano);
            cadena = retorno;
        }
        return cadena;
    }

    protected void cmbReportes_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (int.Parse(this.cmbReportes.SelectedValue))
        {
            case 4:
            case 5:
            case 11:
            case 13:
                this.cmbanio.Visible = true;
                this.Lanio.Visible = true;
                break;
            default:
                this.cmbanio.Visible = false;
                this.Lanio.Visible = false;
                break;
        }
    }

    private void ValoresEspecial(string NombreArchivo)
    {
        string ruta;
        string linea;
        StreamWriter Escribir;
        int contador = 0;

        Datos sv = new Datos();
        DataSet DataS = new DataSet();
        DataSet DataSEmpresas = new DataSet();
        DataSet DS = new DataSet();

        DataSEmpresas = sv.ReporEmpresaConBalance(int.Parse(this.cmbanio.SelectedValue), Convert.ToInt32(Session["IdPais"].ToString()));

        if (DataSEmpresas.Tables[0].Rows.Count > 0)
        {
            DS = sv.ReportesCampos(int.Parse(this.cmbReportes.SelectedValue));

            int[] Campos = new int[DS.Tables[0].Rows.Count];
            Boolean[] Valor = new Boolean[DS.Tables[0].Rows.Count];

            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
            {
                Campos[i] = int.Parse(DS.Tables[0].Rows[i]["CaracteresNum"].ToString());
                Valor[i] = Boolean.Parse(DS.Tables[0].Rows[i]["Valor"].ToString());
            }

            ruta = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Archivos\\Reportestxt\\" + NombreArchivo;

            if (File.Exists(ruta))
            {
                System.IO.File.Delete(ruta);
                ListarArchivos();
            }

            Escribir = new StreamWriter(ruta, false, System.Text.Encoding.Default);

            sv.LimpiaNitValores();
            for (int x = 0; x < DataSEmpresas.Tables[0].Rows.Count; x++)
            {
                sv.IngresaNitValores(DataSEmpresas.Tables[0].Rows[x]["NIT"].ToString().Trim(), Convert.ToInt32(Session["IdPais"].ToString()));
                contador++;

                if (contador == 7000)
                {
                    DataS = sv.ReporValoresXNit(int.Parse(this.cmbanio.SelectedValue));

                    for (int i = 0; i < DataS.Tables[0].Rows.Count; i++)
                    {
                        linea = "";
                        for (int j = 0; j < DataS.Tables[0].Columns.Count; j++)
                        {
                            string cadena = Blancos(DataS.Tables[0].Rows[i][j].ToString().Trim(), Campos[j], Valor[j]);
                            linea = linea + cadena;
                        }
                        Escribir.WriteLine(linea);
                    }

                    DataS.Clear();
                    contador = 0;
                    sv.LimpiaNitValores();
                }
            }

            if (contador > 0)
            {
                DataS = sv.ReporValoresXNit(int.Parse(this.cmbanio.SelectedValue));

                for (int i = 0; i < DataS.Tables[0].Rows.Count; i++)
                {
                    linea = "";
                    for (int j = 0; j < DataS.Tables[0].Columns.Count; j++)
                    {
                        string cadena = Blancos(DataS.Tables[0].Rows[i][j].ToString().Trim(), Campos[j], Valor[j]);
                        linea = linea + cadena;
                    }
                    Escribir.WriteLine(linea);
                }

                DataS.Clear();
                contador = 0;
                sv.LimpiaNitValores();
            }

            Escribir.Close();

            ListarArchivos();

            Response.Write("<script>alert('Archivo Generado')</script>");
        }
        else
        {
            Response.Write("<script>alert('Consulta no tiene Registros para Generar Archivo')</script>");
        }

    }
}