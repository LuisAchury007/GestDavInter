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
using System.Data.OleDb;

public partial class Inf_ReportRiesgoTxt : System.Web.UI.Page
{
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
            txtFechaI.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now.AddDays(-30));
            txtFechaF.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
            LlenarDatos();
        }


    }

    /*  protected void Button5_Click(object sender, EventArgs e)
      {

          string ruta = "";
          string linea;
          StreamWriter Escribir;

          DataSet DataS = new DataSet();
          DataSet DS = new DataSet();




          if (DataS.Tables[0].Rows.Count > 0)
          {
              DS = sv.ReportesCampos(14);

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
                   //   cadena = cadena.Replace(".", "").ToString();
                      cadena = cadena.Replace("<b>", " ").ToString();
                      cadena = cadena.Replace("</b>.", "");

                      cadena.Trim();
                      if (j == 0)
                      {
                          linea = linea + cadena;
                      }
                      else
                      {
                          linea = linea + "æ" + cadena;
                      }
                  }
                  if (CmbOriginacion.SelectedValue == "1")
                  {
                      Escribir.WriteLine(linea);
                  }
                  else
                  {
                      while (linea.Contains("  "))
                      {
                          linea = linea.Replace("  ", "");
                      }

                      //Escribir.WriteLine(linea = linea.Replace(" ", ""));
                      Escribir.WriteLine(linea);
                  }
              }
              Escribir.Close();

              ListarArchivos();

              Response.Write("<script>alert('Archivo Generado')</script>");
          }
          else
          {
              Response.Write("<script>alert('Consulta no tiene Registros para Generar Archivo')</script>");
          }


          Response.Clear();
          Response.ContentType = "application/octet-stream";
          Response.AddHeader("Content-Disposition", "attachment; filename=" + NombreArchivo);
          Response.Flush();
          Response.WriteFile(ruta);
          Response.End();



      }*/


    private string Blancos(string cadena, int tamano, Boolean Valor)
    {
        cadena = cadena.Replace("\n", "");
        cadena = cadena.Replace("\r", ",");

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

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSet DataS = new DataSet();
        string NombreArchivo;

        switch (int.Parse(this.cmbReportes.SelectedValue))
        {
            case 1:
                NombreArchivo = "Accionistas.txt";
                DataS = EjecutarFuncion(int.Parse(this.cmbReportes.SelectedValue));
                GenerarTxt(NombreArchivo, DataS);
                break;

            case 2:
                NombreArchivo = "Balances" + this.cmbanio.SelectedValue.ToString() + ".txt";
                DataS = EjecutarFuncion(int.Parse(this.cmbReportes.SelectedValue));
                GenerarTxt(NombreArchivo, DataS);
                break;
            case 3:
                NombreArchivo = "Indicadores" + this.cmbanio.SelectedValue.ToString() + ".txt";
                DataS = EjecutarFuncion(int.Parse(this.cmbReportes.SelectedValue));
                GenerarTxt(NombreArchivo, DataS);
                break;
            case 4:
                NombreArchivo = "BalancesParciales.txt";
                DataS = EjecutarFuncion(int.Parse(this.cmbReportes.SelectedValue));
                GenerarTxt(NombreArchivo, DataS);
                break;
            case 5:
                NombreArchivo = "IndicadoresParciales.txt";
                DataS = EjecutarFuncion(int.Parse(this.cmbReportes.SelectedValue));
                GenerarTxt(NombreArchivo, DataS);
                break;
            case 6:
                NombreArchivo = "Originacion.txt";
                DataS = EjecutarFuncion(int.Parse(this.cmbReportes.SelectedValue));
                GenerarTxt(NombreArchivo, DataS);
                break;
            case 7:
                NombreArchivo = "NivelesRiesgo.txt";
                DataS = EjecutarFuncion(int.Parse(this.cmbReportes.SelectedValue));
                GenerarTxt(NombreArchivo, DataS);
                break;
            case 8:
                NombreArchivo = "RyNivel.txt";
                DataS = EjecutarFuncion(int.Parse(this.cmbReportes.SelectedValue));
                GenerarTxt(NombreArchivo, DataS);
                break;
            default:
                this.cmbanio.Visible = false;
                this.Lanio.Visible = false;
                break;
        }
    }

    private DataSet EjecutarFuncion(int funcion)
    {
        Datos sv = new Datos();
        DataSet DataS = new DataSet();

        switch (funcion)
        {
        /*   case 1:
                DataS = sv.AccionistasRepresentateTxt();
                break;*/
            case 2:
                DataS = sv.BalancesTxt(int.Parse(this.cmbanio.SelectedValue), Convert.ToInt32(Session["IdPais"].ToString()));
                break;
            case 3:
                DataS = sv.IndicadoresTxt(int.Parse(this.cmbanio.SelectedValue));
                break;
            case 4:
                DataS = sv.BalancesParcialesTxt(Convert.ToInt32(Session["IdPais"].ToString()));
                break;
            case 5:
                DataS = sv.IndicadoresParcialesTxt();
                break;
        /*    case 6:
                DataS = sv.SeReportesOriginacion();
                break;*/
            case 7:
                DataS = sv.SeDatosNivelesRiesgo("", 4, Convert.ToString(txtFechaI.Text), Convert.ToString(txtFechaF.Text), 1, Convert.ToInt32(Session["IdPais"].ToString()));
                break;
            case 8:
                DataS = sv.RyNivel();
                break;

        }

        return DataS;
    }



    private void LlenarDatos()
    {
        Datos sv = new Datos();
        DataSet DataS = new DataSet();

        DataS = sv.GCredVegencia(Convert.ToInt32(Session["IdPais"].ToString()), 0); ;

        this.cmbanio.DataSource = DataS.Tables[0].DefaultView;
        this.cmbanio.DataTextField = "Anio";
        this.cmbanio.DataValueField = "Anio";
        this.cmbanio.DataBind();

        DataS.Clear();

    }


    protected void cmbReportes_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (int.Parse(this.cmbReportes.SelectedValue))
        {
            case 3:
            case 2:
                this.cmbanio.Visible = true;
                this.Lanio.Visible = true;
                break;
            case 7:
                lblDesde.Visible = true;
                lblHasta.Visible = true;
                txtFechaI.Visible = true;
                txtFechaF.Visible = true;
                ImageButton27.Visible = true;
                ImageButton2.Visible = true;
                break;
            default:
                this.cmbanio.Visible = false;
                this.Lanio.Visible = false;
                lblDesde.Visible = false;
                lblHasta.Visible = false;
                txtFechaI.Visible = false;
                txtFechaF.Visible = false;
                ImageButton27.Visible = false;
                ImageButton2.Visible = false;
                break;
        }
    }


    private void GenerarTxt(string NombreArchivo, DataSet DataS)
    {

        string ruta = "";
        string linea;
        StreamWriter Escribir;



        if (DataS.Tables[0].Rows.Count > 0)
        {

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

            }

            //  Escribir = File.CreateText(ruta);
            Escribir = new StreamWriter(ruta, false, System.Text.Encoding.Default);

            for (int i = 0; i < DataS.Tables[0].Rows.Count; i++)
            {
                linea = "";
                for (int j = 0; j < DataS.Tables[0].Columns.Count; j++)
                {
                    string cadena = DataS.Tables[0].Rows[i][j].ToString().Trim();
                    cadena = cadena.Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace("\t", "");
                    cadena.Trim();
                    if (j == 0)
                    {
                        linea = linea + cadena;
                    }
                    else
                    {
                        linea = linea + "æ" + cadena;
                    }
                }

                Escribir.WriteLine(linea);
            }
            Escribir.Close();


        }
        else
        {
            Response.Write("<script>alert('Consulta no tiene Registros para Generar Archivo')</script>");
        }

        Response.Clear();
        Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + NombreArchivo);
        Response.Flush();
        Response.WriteFile(ruta);
        Response.End();

    }
}