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

public partial class CredCargueEmpresa : System.Web.UI.Page
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

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
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
                case ".XLSM":
                case ".XLS":
                    FileUpload1.SaveAs(ruta + FileUpload1.FileName);
                    ValidarAchivo(ruta + FileUpload1.FileName, extension.ToUpper(), FileUpload1.FileName);
                    break;
                default:
                    Response.Write("<script>alert('Debe ser un archivo de excel XLSM o XLS')</script>");
                    break;
            }
            /* }
             catch (Exception ex)
             {
                 Response.Write("<script>alert('ERROR: ' " + ex.Message.ToString() + ")</script>");
             }*/
        }
        else
        {
            Response.Write("<script>alert('No ha especificado archivo.')</script>");
            return;
        }

    }

    private void ValidarAchivo(string ArchivoRuta, string Formato, string NombreArchivo)
    {
        Datos sv = new Datos();

        string Nit = "";
        string Canedana;
        int IdDivisa;
        //OleDbConnection CExcel;
        OleDbConnection CExcel = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ArchivoRuta + ";Extended Properties='Excel 12.0 Macro;HDR=YES'");
        /*se hace referencia al sistem .data.OLEDB*/
        //if (Formato == ".XLS")
        //    CExcel = new OleDbConnection(@"Provider = Microsoft.jet.oledb.4.0; Data Source= " + ArchivoRuta + "; Extended Properties= 'Excel 8.0;hdr=yes;imex=1'");
        //else
        //    CExcel = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ArchivoRuta + ";Extended Properties='Excel 12.0 Macro;HDR=YES'");

        /*se ejecuta la consulta a la hoha de excel*/

        CExcel.Open();
        DataTable dt = CExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

        if (dt != null)
        {
            String[] excelSheets = new String[dt.Rows.Count];
            String[] HojasBuscar = { "RC$", "'Estados Financieros$'", "'Balances y Proyecciones$'", "Resumen$" };
            int x = 0;

            foreach (DataRow row in dt.Rows)
            {
                excelSheets[x] = row["TABLE_NAME"].ToString();
                x++;
            }

            int cuantos = 0;

            for (int i = 0; i < HojasBuscar.Length; i++)
            {
                for (int j = 0; j < excelSheets.Length; j++)
                {
                    if (excelSheets[j] == HojasBuscar[i])
                    {
                        cuantos++;
                        break;
                    }
                }
            }

            CExcel.Close();

            if (cuantos >= 4)
            {
                
               
                /*se carga el resultadao en el dataset*/
                DataSet DS = new DataSet();
                DataSet DSnit = new DataSet();
                
                Boolean Correcto = true;
                
                OleDbDataAdapter AdpExcel = new OleDbDataAdapter("Select * from [Validacion$]", CExcel);
                DSnit.Tables.Add("Excel");
                DS.Tables.Add("Excel");
                AdpExcel.Fill(DS.Tables["Excel"]);

                for (int y = 0; y < DS.Tables["Excel"].Rows.Count; y++)
                {
                    for (int i = 0; i < DS.Tables["Excel"].Columns.Count; i++)
                    {
                        if (DS.Tables["Excel"].Rows[y][i].ToString().Trim().Length > 1)
                        {
                            if (DS.Tables["Excel"].Rows[y][i].ToString().ToUpper().Trim() != "OK")
                            {
                                Response.Write("<script>alert('" + DS.Tables["Excel"].Rows[y][i].ToString() + "')</script>");
                                Correcto = false;
                            }
                        }
                    }
                }
                if (Correcto)
                {

                    Boolean TasaOk = true;
                    string MensajeMoneda = "";

                    DS.Tables["Excel"].Clear();

                    AdpExcel = new OleDbDataAdapter("Select distinct Anio, Moneda, NombreMoneda from [NitAnioNIIF$] where anio <> 1900", CExcel);

                    AdpExcel.Fill(DS.Tables["Excel"]);

                    if (DS.Tables["Excel"].Rows.Count > 0)
                    {
                        for (int y = 0; y < DS.Tables["Excel"].Rows.Count; y++)
                        {
                            Boolean existe;

                            existe = sv.ExisteConversion(Convert.ToInt32(Session["IdPais"].ToString()), int.Parse(DS.Tables["Excel"].Rows[y]["Anio"].ToString()), int.Parse(DS.Tables["Excel"].Rows[y]["Moneda"].ToString()));

                            if (!existe)
                            {
                                TasaOk = false;
                                MensajeMoneda = MensajeMoneda + "No Existe Tasa Convesion: " + DS.Tables["Excel"].Rows[y]["NombreMoneda"].ToString() + " Periodo: " + DS.Tables["Excel"].Rows[y]["Anio"].ToString() + "  ##  ";
                            }

                        }

                    }

                    if (TasaOk)
                    {
                        DSnit.Tables["Excel"].Clear();

                        AdpExcel = new OleDbDataAdapter("Select NIT,RazonSocial,Sigla,IdTipoSociedad,ObjetoSocial,RepresentanteLegal,Cargo,IdCiudad,Direccion,Telefono,Fax,AA,NumMatricula,Email,Website,FechaFundacion,Ley1116,ListaClinton,Ciiu,Importador,Exportador,RevisorFiscal,IdFuente,Moneda from [Caratula$]", CExcel);

                        AdpExcel.Fill(DSnit.Tables["Excel"]);

                        if (DSnit.Tables["Excel"].Rows.Count > 0)
                        {
                            for (int y = 0; y < DSnit.Tables["Excel"].Rows.Count; y++)
                            {
                                Nit = DSnit.Tables["Excel"].Rows[y]["NIT"].ToString();
                                IdDivisa = int.Parse(DSnit.Tables["Excel"].Rows[y]["Moneda"].ToString());

                                string CadenaVigencias = "";
                                string CadenaParcial = "";
                                long id;

                                DS.Tables["Excel"].Clear();
                                AdpExcel = new OleDbDataAdapter("select DISTINCT  Anio from [BalancesAnuales$] where Anio <> 1900 AND NIT ='" + Nit +"'", CExcel);
                                AdpExcel.Fill(DS.Tables["Excel"]);

                                if (DS.Tables["Excel"].Rows.Count > 0)
                                {
                                    for (int i = 0; i < DS.Tables["Excel"].Rows.Count; i++)
                                    {
                                        CadenaVigencias = CadenaVigencias + " - " + DS.Tables["Excel"].Rows[i]["Anio"].ToString();
                                    }
                                }
                                // Auditoria Parcial

                                DS.Tables["Excel"].Clear();
                                AdpExcel = new OleDbDataAdapter("select DISTINCT  Anio from [BalancesMensuales$] where Anio <> 1900 AND NIT ='" + Nit + "'", CExcel);
                                AdpExcel.Fill(DS.Tables["Excel"]);

                                if (DS.Tables["Excel"].Rows.Count > 0)
                                {
                                    for (int i = 0; i < DS.Tables["Excel"].Rows.Count; i++)
                                    {
                                        CadenaParcial = CadenaParcial + " - " + DS.Tables["Excel"].Rows[i]["Anio"].ToString();
                                    }
                                }

                                id = sv.IngresaAuditoriaCargue(int.Parse(Session["IDusuario"].ToString()), Nit, CadenaVigencias, CadenaParcial, Convert.ToInt32(Session["IdPais"].ToString()), NombreArchivo);


                                string targetPath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Archivos\\ModeloHistorico\\" + Nit; //@"C:\Users\Public\TestFolder\SubDir";

                                // Use Path class to manipulate file and directory paths.

                                string fileName = System.IO.Path.GetFileNameWithoutExtension(NombreArchivo) + "-" + id + System.IO.Path.GetExtension(NombreArchivo);


                                string destFile = System.IO.Path.Combine(targetPath, fileName);

                                if (!System.IO.Directory.Exists(targetPath))
                                {
                                    System.IO.Directory.CreateDirectory(targetPath);
                                }

                                // To copy a file to another location and 
                                // overwrite the destination file if it already exists.
                                System.IO.File.Copy(ArchivoRuta, destFile, true);


                                DataSet DSArchivos = new DataSet();

                                DSArchivos = sv.GCredAuditoriaModeloPlantillaXDel(Nit, Convert.ToInt32(Session["IdPais"].ToString()));

                                for (int i = 0; i < DSArchivos.Tables[0].Rows.Count; i++)
                                {

                                    string ruta = null;

                                    ruta = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "Archivos\\ModeloHistorico\\" + DSArchivos.Tables[0].Rows[i]["Nit"].ToString() + "\\" + DSArchivos.Tables[0].Rows[i]["NombreArchivo"].ToString();

                                    System.IO.File.Delete(ruta);

                                    sv.CredActualizaLogCargue(long.Parse(DSArchivos.Tables[0].Rows[i]["Id"].ToString()), 2);

                                }

                                AdpExcel = new OleDbDataAdapter("select DISTINCT  Anio from [BalancesAnuales$] where Anio <> 1900 AND Nit='" + Nit + "'", CExcel);
                                AdpExcel.Fill(DS.Tables["Excel"]);

                                if (DS.Tables["Excel"].Rows.Count > 0)
                                {
                                    for (int i = 0; i < DS.Tables["Excel"].Rows.Count; i++)
                                    {
                                        sv.EliminarBalanceAnio(Nit, int.Parse(DS.Tables["Excel"].Rows[i]["Anio"].ToString()), Convert.ToInt32(Session["IdPais"].ToString()));
                                    }
                                }

                                DS.Tables["Excel"].Clear();
                                AdpExcel = new OleDbDataAdapter("select IdCuenta,Nit,Anio,Valor,Valor2 from [BalancesAnuales$] where Anio <> 1900 AND Nit='" + Nit + "'", CExcel);
                                AdpExcel.Fill(DS.Tables["Excel"]);

                                if (DS.Tables["Excel"].Rows.Count > 0)
                                {
                                    for (int i = 0; i < DS.Tables["Excel"].Rows.Count; i++)
                                    {
                                        Canedana = Convert.ToString(DS.Tables["Excel"].Rows[i]["Valor2"].ToString());
                                        Canedana = Canedana.Replace(".", ",");

                                        sv.IngresaBalance(Nit, int.Parse(DS.Tables["Excel"].Rows[i]["Anio"].ToString()), int.Parse(DS.Tables["Excel"].Rows[i]["IdCuenta"].ToString()), decimal.Parse(Canedana), Convert.ToInt32(Session["IdPais"].ToString()), IdDivisa);
                                    }
                                }
                                // Parcial

                                DS.Tables["Excel"].Clear();
                                AdpExcel = new OleDbDataAdapter("select DISTINCT  Anio from [BalancesMensuales$] where Anio <> 1900 AND Nit='" + Nit + "'", CExcel);
                                AdpExcel.Fill(DS.Tables["Excel"]);

                                if (DS.Tables["Excel"].Rows.Count > 0)
                                {
                                    for (int i = 0; i < DS.Tables["Excel"].Rows.Count; i++)
                                    {
                                        sv.EliminarBalanceAnioParcial(Nit, int.Parse(DS.Tables["Excel"].Rows[i]["Anio"].ToString()), Convert.ToInt32(Session["IdPais"].ToString()));
                                    }
                                }

                                DS.Tables["Excel"].Clear();

                                AdpExcel = new OleDbDataAdapter("select IdCuenta,NIT,Anio,Valor,Valor2 from [BalancesMensuales$] where Anio <> 1900 AND Nit='" + Nit + "'", CExcel);
                                AdpExcel.Fill(DS.Tables["Excel"]);

                                if (DS.Tables["Excel"].Rows.Count > 0)
                                {
                                    for (int i = 0; i < DS.Tables["Excel"].Rows.Count; i++)
                                    {
                                        Canedana = Convert.ToString(DS.Tables["Excel"].Rows[i]["Valor2"].ToString());
                                        Canedana = Canedana.Replace(".", ",");
                                        sv.IngresaBalanceParcial(Nit, int.Parse(DS.Tables["Excel"].Rows[i]["Anio"].ToString()), int.Parse(DS.Tables["Excel"].Rows[i]["IdCuenta"].ToString()), decimal.Parse(Canedana), Convert.ToInt32(Session["IdPais"].ToString()), IdDivisa);
                                    }
                                }

                                DS.Tables["Excel"].Clear();

                                Boolean Resultado = false;

                                AdpExcel = new OleDbDataAdapter("select Nit, Anio, Niif, Parcial, Meses,Auditado,TipoAuditado from [NitAnioNIIF$] where Nit='" + Nit +"'", CExcel);
                                AdpExcel.Fill(DS.Tables["Excel"]);

                                if (DS.Tables["Excel"].Rows.Count > 0)
                                {
                                    for (int i = 0; i < DS.Tables["Excel"].Rows.Count; i++)
                                    {
                                        sv.IngresaNitAnio(Nit, int.Parse(DS.Tables["Excel"].Rows[i]["Anio"].ToString()), Boolean.Parse(DS.Tables["Excel"].Rows[i]["Niif"].ToString()), Boolean.Parse(DS.Tables["Excel"].Rows[i]["Parcial"].ToString()), Convert.ToInt32(Session["IdPais"].ToString()), int.Parse(DS.Tables["Excel"].Rows[i]["Meses"].ToString()), int.Parse(DS.Tables["Excel"].Rows[i]["TipoAuditado"].ToString()));

                                        if (Boolean.Parse(DS.Tables["Excel"].Rows[i]["Parcial"].ToString()))
                                        {
                                            Resultado = sv.CredCalculaEmpresaAnioParcial(Nit, 1, int.Parse(DS.Tables["Excel"].Rows[i]["Anio"].ToString()), Convert.ToInt32(Session["IdPais"].ToString()));
                                        }
                                        else
                                        {
                                            Resultado = sv.CredCalculaEmpresaAnio(Nit, 1, int.Parse(DS.Tables["Excel"].Rows[i]["Anio"].ToString()), Convert.ToInt32(Session["IdPais"].ToString()));
                                        }
                                    }
                                }

                                DS.Tables["Excel"].Clear();
                                DSArchivos.Clear();


                                sv.CredEmpresaInser(DSnit.Tables["Excel"].Rows[y]["NIT"].ToString(), DSnit.Tables["Excel"].Rows[y]["RazonSocial"].ToString(), DSnit.Tables["Excel"].Rows[y]["Sigla"].ToString(), int.Parse(DSnit.Tables["Excel"].Rows[y]["IdTipoSociedad"].ToString()), DSnit.Tables["Excel"].Rows[y]["ObjetoSocial"].ToString(), DSnit.Tables["Excel"].Rows[y]["RepresentanteLegal"].ToString(), DSnit.Tables["Excel"].Rows[y]["Cargo"].ToString(), int.Parse(DSnit.Tables["Excel"].Rows[y]["IdCiudad"].ToString()), DSnit.Tables["Excel"].Rows[y]["Direccion"].ToString(), DSnit.Tables["Excel"].Rows[y]["Telefono"].ToString(), DSnit.Tables["Excel"].Rows[y]["Fax"].ToString(), DSnit.Tables["Excel"].Rows[y]["AA"].ToString(), DSnit.Tables["Excel"].Rows[y]["NumMatricula"].ToString(), DSnit.Tables["Excel"].Rows[y]["Email"].ToString(), DSnit.Tables["Excel"].Rows[y]["Website"].ToString(), DSnit.Tables["Excel"].Rows[y]["FechaFundacion"].ToString(), DSnit.Tables["Excel"].Rows[y]["Ciiu"].ToString(), DSnit.Tables["Excel"].Rows[y]["RevisorFiscal"].ToString(), 3, "", Convert.ToInt32(Session["IdPais"].ToString()), "", "", -1);

                                DS.Tables["Excel"].Clear();
                                AdpExcel = new OleDbDataAdapter("select NIT,CedulaAccionista,NombreAccionista,ParticipacionAccionista,IdTipoDocumento from [Accionistas$] where NombreAccionista <> '' AND NIT ='" + Nit + "'", CExcel);
                                AdpExcel.Fill(DS.Tables["Excel"]);
                                //  
                                if (DS.Tables["Excel"].Rows.Count > 0)
                                {
                                    sv.EliminaAccionistas(Nit, Convert.ToInt32(Session["IdPais"].ToString()));

                                    for (int i = 0; i < DS.Tables["Excel"].Rows.Count; i++)
                                    {
                                        sv.IngresaAccionistas(Nit, DS.Tables["Excel"].Rows[i]["CedulaAccionista"].ToString(), DS.Tables["Excel"].Rows[i]["NombreAccionista"].ToString(), float.Parse(DS.Tables["Excel"].Rows[i]["ParticipacionAccionista"].ToString()), Convert.ToInt32(DS.Tables["Excel"].Rows[i]["IdTipoDocumento"].ToString()), Convert.ToInt32(Session["IdPais"].ToString()));
                                    }
                                }


                                DS.Tables["Excel"].Clear();
                                AdpExcel = new OleDbDataAdapter("select Nit,NombreJunta,DocumentoJunta,CargoJunta,IdTipoEjecutivo,IdTipoDocumento from [Juntas$] where NombreJunta <> '' AND NIT ='" + Nit + "'", CExcel);
                                AdpExcel.Fill(DS.Tables["Excel"]);
                                //  
                                if (DS.Tables["Excel"].Rows.Count > 0)
                                {
                                    sv.DeEstrucAdmimistrativa("", "TodoJunta", Nit, Convert.ToInt32(Session["IdPais"].ToString()));

                                    for (int i = 0; i < DS.Tables["Excel"].Rows.Count; i++)
                                    {
                                        sv.IngresaEjecutivo(Nit, DS.Tables["Excel"].Rows[i]["DocumentoJunta"].ToString(), DS.Tables["Excel"].Rows[i]["NombreJunta"].ToString(), DS.Tables["Excel"].Rows[i]["CargoJunta"].ToString(), Convert.ToInt32(DS.Tables["Excel"].Rows[i]["IdTipoEjecutivo"].ToString()), "", Convert.ToInt32(DS.Tables["Excel"].Rows[i]["IdTipoDocumento"].ToString()), Convert.ToInt32(Session["IdPais"].ToString()));
                                    }
                                }


                                DS.Tables["Excel"].Clear();
                                //Segmentar
                                sv.CredSegmentar(Nit, Convert.ToInt32(Session["IdPais"].ToString()));
                             
                                sv.CredActualizaLogCargue(id, 1);
                            }
                            Response.Write("<script>alert('Empresa Cargada Correctamente.')</script>");
                        }

                    }
                    else
                    {
                        Response.Write("<script>alert('" + MensajeMoneda + "')</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Faltan Hojas Para Subir la Informacion Cominuquese con su administrador para que le entregue una nueva maqueta')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Archivo No Contiene Hojas')</script>");
        }
        System.IO.File.Delete(ArchivoRuta);

    }





}
