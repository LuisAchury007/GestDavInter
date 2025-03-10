using System;
using System.Data;
using System.Configuration;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;

/// <summary>
/// Descripción breve de Datos
/// </summary>
public class Datos
{
    public static ClsDatoSQLServer ClsSQL = new ClsDatoSQLServer();

    public void InLogErrores(string InnerExMensaje, string mensaje, Int32 Usuario)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "In_LogErrores";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@FechaError", SqlDbType.DateTime).Value = DateTime.Now;
        sqlCmd.Parameters.Add("@InnerExMensaje", SqlDbType.VarChar).Value = InnerExMensaje;
        sqlCmd.Parameters.Add("@MensajeError", SqlDbType.VarChar).Value = mensaje;
        sqlCmd.Parameters.Add("@Usuario", SqlDbType.Int).Value = Usuario;
        ClsSQL.ejecutarcomandoBench(sqlCmd);
    }

    public DataSet ValidarUsuario(string usuario, string clave)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_ValidaUsuario";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 50).Value = usuario;
        sqlCmd.Parameters.Add("@Clave", SqlDbType.NVarChar, 50).Value = clave;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet Menu1(int perfil)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_Menu1";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = perfil;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);
        return ds;
    }

    public DataSet Menu2(int perfil, int orden)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_Menu2";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Orden1", SqlDbType.Int).Value = orden;
        sqlCmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = perfil;

        ds = ClsSQL.CreateDataSetBench(sqlCmd);
        return ds;
    }

    public DataSet CiudadLista()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_Ciudad";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);
        return ds;
    }

    public DataSet CredSectoresCombo()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_SectorCombo";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);
        return ds;
    }

    public DataSet BencEmpresasLista(int IdSector)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_EmpresasLista";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdSector", SqlDbType.Int).Value = IdSector;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet BencIndicadoresSector(int IdSector, int IdGrupo, string Promedio, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "se_IndicadoresSec";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdSector", SqlDbType.VarChar).Value = IdSector;
        sqlCmd.Parameters.Add("@IdGrupo", SqlDbType.VarChar).Value = IdGrupo;
        sqlCmd.Parameters.Add("@agregado", SqlDbType.VarChar).Value = Promedio;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    public DataSet BencBalancePygSector(int IdSector, Boolean Balance, string agregado, int IdPais )
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "se_BalancePygSector";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdSector", SqlDbType.Int).Value = IdSector;
        sqlCmd.Parameters.Add("@Balance", SqlDbType.Bit).Value = Balance;
        sqlCmd.Parameters.Add("@agregado", SqlDbType.VarChar).Value = agregado;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

 
    public DataSet BencEmpresaDatos(string Nit, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_EmpresaDatos";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;

        ds = ClsSQL.CreateDataSetBench(sqlCmd);
        return ds;
    }

    public DataSet BencAccionistasEmpresa(string Nit, Int32 Seleccion, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "se_accionistas";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.VarChar).Value = Seleccion;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;

        ds = ClsSQL.CreateDataSetBench(sqlCmd);
        return ds;
    }

    public DataSet BencIndicadoresEmpresa(string Nit, int IdSector, int IdPais, int IdDivisa)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_IndicadoresEmp";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdSector", SqlDbType.VarChar).Value = IdSector;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.VarChar).Value = IdPais;
        sqlCmd.Parameters.Add("@IdDivisa", SqlDbType.VarChar).Value = IdDivisa;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);
        return ds;
    }

    public DataSet BencIndicadoresParciales(string Nit, int IdSector, int IdPais, int IdDivisa)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_IndicadoresParciales";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdSector", SqlDbType.VarChar).Value = IdSector;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.VarChar).Value = IdPais;
        sqlCmd.Parameters.Add("@IdDivisa", SqlDbType.VarChar).Value = IdDivisa;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);
        return ds;
    }

    public DataSet BencBalancePyG(string Nit, int Balance, int IdPais, int IdDivisa)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "se_BalancePyg";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Balance", SqlDbType.VarChar).Value = Balance;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.VarChar).Value = IdPais;
        sqlCmd.Parameters.Add("@IdDivisa", SqlDbType.VarChar).Value = IdDivisa;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);
        return ds;
    }

    public DataSet BencBalancePyGParcial(string Nit, int Balance, int IdPais, int IdDivisa)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_BalancePygParcial";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Balance", SqlDbType.VarChar).Value = Balance;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.VarChar).Value = IdPais;
        sqlCmd.Parameters.Add("@IdDivisa", SqlDbType.VarChar).Value = IdDivisa;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);
        return ds;
    }

    /// <summary>
    /// modificado para buscar enpresas que son cleitnes CCGC 15/02/2017
    /// </summary>
    /// <param name="buscar"></param>
    /// <returns></returns>
    public DataSet BencBuscarEmpresa(string buscar, int Seleccion, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_BuscarEmpresa";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Buscar", SqlDbType.VarChar).Value = buscar;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);
        return ds;
    }

    public DataSet BencBuscarAccionista(string buscar, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_BuscarAccionistas";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Buscar", SqlDbType.VarChar).Value = buscar;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);
        return ds;
    }

    public DataSet UsuariosLista()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_Usuarios";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);
        return ds;
    }

    public DataSet UsuariosDatos(int IdUsuario)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_UsuarioDatos";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);
        return ds;
    }

    public DataSet Perfiles()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_Perfil";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);
        return ds;
    }

    public void UsuarioActualiza(int IdUsuario, string Usuario, string Nombre, string Correo, string Cargo, string Telefono, string Celular, string Extension, int IdPerfil, Boolean Bloqueado, string Identificacion, int IdEstUsuario)
    {

        SqlCommand sqlCmd = new SqlCommand();

        sqlCmd.CommandText = "Up_Usuario";
        sqlCmd.CommandType = CommandType.StoredProcedure;

        sqlCmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
        sqlCmd.Parameters.Add("@Usuario", SqlDbType.NVarChar).Value = Usuario;
        sqlCmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = Nombre;
        sqlCmd.Parameters.Add("@Correo", SqlDbType.NVarChar).Value = Correo;
        sqlCmd.Parameters.Add("@Cargo", SqlDbType.NVarChar).Value = Cargo;
        sqlCmd.Parameters.Add("@Telefono", SqlDbType.NVarChar).Value = Telefono;
        sqlCmd.Parameters.Add("@Celular", SqlDbType.NVarChar).Value = Celular;
        sqlCmd.Parameters.Add("@Extension", SqlDbType.NVarChar).Value = Extension;
        sqlCmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = IdPerfil;
        sqlCmd.Parameters.Add("@Bloqueado", SqlDbType.Bit).Value = Bloqueado;
        sqlCmd.Parameters.Add("@Identificacion", SqlDbType.NVarChar).Value = Identificacion;
        sqlCmd.Parameters.Add("@IdEstUsuario", SqlDbType.Int).Value = IdEstUsuario;
        ClsSQL.ejecutarcomandoBench(sqlCmd);
    }

    public int UsuarioIngresar(string Usuario, string Clave, string Nombre, string Correo, string Cargo, string Telefono, string Celular, string Extension, int IdPerfil, Boolean Bloqueado, string Identificacion, int IdEstUsuario)
    {
        SqlCommand sqlCmd = new SqlCommand();
        int IdNewUsr = 0;
        sqlCmd.CommandText = "In_Usuario";
        sqlCmd.CommandType = CommandType.StoredProcedure;

        sqlCmd.Parameters.Add("@Usuario", SqlDbType.NVarChar).Value = Usuario;
        sqlCmd.Parameters.Add("@Clave", SqlDbType.NVarChar).Value = Clave;
        sqlCmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = Nombre;
        sqlCmd.Parameters.Add("@Correo", SqlDbType.NVarChar).Value = Correo;
        sqlCmd.Parameters.Add("@Cargo", SqlDbType.NVarChar).Value = Cargo;
        sqlCmd.Parameters.Add("@Telefono", SqlDbType.NVarChar).Value = Telefono;
        sqlCmd.Parameters.Add("@Celular", SqlDbType.NVarChar).Value = Celular;
        sqlCmd.Parameters.Add("@Extension", SqlDbType.NVarChar).Value = Extension;
        sqlCmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = IdPerfil;
        sqlCmd.Parameters.Add("@Bloqueado", SqlDbType.Bit).Value = Bloqueado;
        sqlCmd.Parameters.Add("@Identificacion", SqlDbType.NVarChar).Value = Identificacion;
        sqlCmd.Parameters.Add("@IdEstUsuario", SqlDbType.Int).Value = IdEstUsuario;
        sqlCmd.Parameters.Add("@IdNewUsr", SqlDbType.Int).Direction = ParameterDirection.Output;
        ClsSQL.ejecutarcomandoBench(sqlCmd);
        IdNewUsr = int.Parse(sqlCmd.Parameters["@IdNewUsr"].Value.ToString());

        return IdNewUsr;
    }
    public void UsuarioEliminar(int IdUsuario)
    {
        SqlCommand sqlCmd = new SqlCommand();

        sqlCmd.CommandText = "De_Usuario";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;

        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public DataSet CredRankingSector(int IdSector, int IdIndicador)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_Ranking";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdSector", SqlDbType.Int).Value = IdSector;
        sqlCmd.Parameters.Add("@IdIndicador", SqlDbType.Int).Value = IdIndicador;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet CredIndicadores(int IdGrupo)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_Indicadores";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdGrupo", SqlDbType.Int).Value = IdGrupo;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

   

    public DataSet CredNumEmpresasSectorAnio(int IdSector)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_NumEmpresas";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdSector", SqlDbType.VarChar).Value = IdSector;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public void CredSectorNew(string Sector, int SectorPadre, int IdCliente, Boolean ManoFacturero)
    {
        SqlCommand sqlCmd = new SqlCommand();

        sqlCmd.CommandText = "In_SectorNew";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Sector", SqlDbType.VarChar).Value = Sector;
        sqlCmd.Parameters.Add("@SectorPadre", SqlDbType.Int).Value = SectorPadre;
        sqlCmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = IdCliente;
        sqlCmd.Parameters.Add("@ManoFacturero", SqlDbType.Bit).Value = ManoFacturero;

        ClsSQL.ejecutarcomandoBench(sqlCmd);
    }

    public DataSet CredMisSectores(int IdCliente)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_MisSector";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = IdCliente;

        ds = ClsSQL.CreateDataSetBench(sqlCmd);
        return ds;
    }

    public void CredClonaSector(int IdSector, int IdSectorDest, int IdCliente)
    {
        SqlCommand sqlCmd = new SqlCommand();

        sqlCmd.CommandText = "In_ClonaSector";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdSector", SqlDbType.Int).Value = IdSector;
        sqlCmd.Parameters.Add("@IdSectorDest", SqlDbType.Int).Value = IdSectorDest;
        sqlCmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = IdCliente;

        ClsSQL.ejecutarcomandoBench(sqlCmd);
    }

    public DataSet CredPuc(Boolean balance)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_Puc";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Balance", SqlDbType.Bit).Value = balance;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);



        return ds;
    }

    public DataSet CredIndicadorMaxMinPro(int Anio, int IdIndicador, int IdSector)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_IndicadorMaxMinPro";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;
        sqlCmd.Parameters.Add("@IdIndicador", SqlDbType.Int).Value = IdIndicador;
        sqlCmd.Parameters.Add("@IdSector", SqlDbType.Int).Value = IdSector;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet CredPucMaxMinPro(int Anio, int IdCuenta, int IdSector, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_PucMaxMinPro";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;
        sqlCmd.Parameters.Add("@IdCuenta", SqlDbType.Int).Value = IdCuenta;
        sqlCmd.Parameters.Add("@IdSector", SqlDbType.Int).Value = IdSector;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);


        return ds;
    }

    public DataSet CredProspectar(int Anio, int IdSector, string CadIndicadores, string CadCiudad, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_Prospectar";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.NVarChar).Value = Anio;
        sqlCmd.Parameters.Add("@IdSector", SqlDbType.NVarChar).Value = IdSector;
        sqlCmd.Parameters.Add("@CadIndicadores", SqlDbType.NVarChar).Value = CadIndicadores;
        sqlCmd.Parameters.Add("@CadCiudad", SqlDbType.NVarChar).Value = CadCiudad;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet CredIndicadorNom(int IdIndicador)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_IndicadorNom";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdIndicador", SqlDbType.Int).Value = IdIndicador;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public void CredCopiaEmpSector(string Nit, int IdSectorDest)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_CopiaEmpSector";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdSectorDest", SqlDbType.Int).Value = IdSectorDest;

        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }


    public void CredCalculaBalanceSector(int IdSector, int Promedio, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_CalcularIndicadoresSector";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdSector", SqlDbType.Int).Value = IdSector;
        sqlCmd.Parameters.Add("@IdGrupo", SqlDbType.Bit).Value = Promedio;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void CredCalculaSector(int IdSector, int IdGrupo, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_CalcularIndicadoresSector";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdSector", SqlDbType.Int).Value = IdSector;
        sqlCmd.Parameters.Add("@IdGrupo", SqlDbType.Int).Value = IdGrupo;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public DataSet TipoEmpresa()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_TipoEmpresa";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    //05/10/20107
    public void CredEmpresaInser(string Nit, string RazonSocial, string Sigla, int IdTipoSociedad, string ObjetoSocial, string RepresentanteLegal, string Cargo, int IdCiudad, string Direccion, string Telefono, string Fax, string AA, string NumMatricula, string Email,
        string Website, string FechaFundacion, string Ciiu, string RevisorFiscal, int IdTipoIdentifiacion, string NitConDigito, int IdPais, string Consecutivo, string PaisActividad, int IdSectorN)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_EmpresaNew";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@RazonSocial", SqlDbType.NVarChar).Value = RazonSocial;
        sqlCmd.Parameters.Add("@Sigla", SqlDbType.NVarChar).Value = Sigla;
        sqlCmd.Parameters.Add("@RepresentanteLegal", SqlDbType.NVarChar).Value = RepresentanteLegal;
        sqlCmd.Parameters.Add("@RevisorFiscal", SqlDbType.NVarChar).Value = RevisorFiscal;
        sqlCmd.Parameters.Add("@Direccion", SqlDbType.NVarChar).Value = Direccion;
        sqlCmd.Parameters.Add("@Telefono", SqlDbType.NVarChar).Value = Telefono;
        sqlCmd.Parameters.Add("@IdCiudad", SqlDbType.Int).Value = IdCiudad;
        sqlCmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = Fax;
        sqlCmd.Parameters.Add("@AA", SqlDbType.NVarChar).Value = AA;
        sqlCmd.Parameters.Add("@FechaFundacion", SqlDbType.Date).Value = FechaFundacion;
        sqlCmd.Parameters.Add("@IdTipoSociedad", SqlDbType.Int).Value = IdTipoSociedad;
        sqlCmd.Parameters.Add("@ObjetoSocial", SqlDbType.NVarChar).Value = ObjetoSocial;
        sqlCmd.Parameters.Add("@Cargo", SqlDbType.NVarChar).Value = Cargo;
        sqlCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
        sqlCmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = Website;
        sqlCmd.Parameters.Add("@Ciiu", SqlDbType.NVarChar).Value = Ciiu;
        sqlCmd.Parameters.Add("@NumMatricula", SqlDbType.NVarChar).Value = NumMatricula;
        sqlCmd.Parameters.Add("@IdTipoIdentifiacion", SqlDbType.Int).Value = IdTipoIdentifiacion;
        sqlCmd.Parameters.Add("@NitConDigito", SqlDbType.NVarChar).Value = NitConDigito;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        sqlCmd.Parameters.Add("@Consecutivo", SqlDbType.NVarChar).Value = Consecutivo;
        sqlCmd.Parameters.Add("@PaisActividad", SqlDbType.NVarChar).Value = PaisActividad;
        sqlCmd.Parameters.Add("@IdSectorN", SqlDbType.Int).Value = IdSectorN;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void InSectoresTodos(int Seleccion, int IdSector, string Sector, Boolean ManoFacturero, int CIIUDefault, int IdCuenta, Decimal ValorPyme, Decimal ValorEmpresarial, Decimal ValorCoorporativo, int IdModelo, DateTime FechaActualizacion, Decimal Factor, int FormCuaitativo, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_SectoresTodos";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@IdSector", SqlDbType.Int).Value = IdSector;
        sqlCmd.Parameters.Add("@Sector", SqlDbType.VarChar).Value = Sector;
        sqlCmd.Parameters.Add("@ManoFacturero", SqlDbType.Bit).Value = ManoFacturero;
        sqlCmd.Parameters.Add("@CIIUDefault", SqlDbType.Int).Value = CIIUDefault;
        sqlCmd.Parameters.Add("@IdCuenta", SqlDbType.Int).Value = IdCuenta;
        sqlCmd.Parameters.Add("@ValorPyme", SqlDbType.Money).Value = ValorPyme;
        sqlCmd.Parameters.Add("@ValorEmpresarial", SqlDbType.Money).Value = ValorEmpresarial;
        sqlCmd.Parameters.Add("@ValorCoorporativo", SqlDbType.Money).Value = ValorCoorporativo;
        sqlCmd.Parameters.Add("@IdModelo", SqlDbType.Int).Value = IdModelo;
        sqlCmd.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime).Value = FechaActualizacion;
        sqlCmd.Parameters.Add("@Factor", SqlDbType.Decimal).Value = Factor;
        sqlCmd.Parameters.Add("@IdCCualitativa", SqlDbType.Int).Value = FormCuaitativo;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;

        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public DataSet CredCuentaEmpSector(int IdSector)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_CuentaEmpSector";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdSector", SqlDbType.Int).Value = IdSector;

        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet CredCuentaEmpSectorPro(int IdSector, int IdCliente)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_CuentaEmpSectorPro";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdSector", SqlDbType.Int).Value = IdSector;
        sqlCmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = IdCliente;

        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet ComSectores(int IdSector, int Seleccion, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_SectorTodos";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdSector", SqlDbType.Int).Value = IdSector;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet CredListaOfac(int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_ListaOfac";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public int CambiarClave(int IdUsuario, string Clave, string ClaveNew)
    {
        SqlCommand sqlCmd = new SqlCommand();
        int resul = 0;


        sqlCmd.CommandText = "Up_CambiarPass";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
        sqlCmd.Parameters.Add("@Clave", SqlDbType.NVarChar).Value = Clave;
        sqlCmd.Parameters.Add("@ClaveNew", SqlDbType.NVarChar).Value = ClaveNew;
        sqlCmd.Parameters.Add("@Resul", SqlDbType.Int).Direction = ParameterDirection.Output;
        ClsSQL.ejecutarcomandoBench(sqlCmd);
        resul = int.Parse(sqlCmd.Parameters["@Resul"].Value.ToString());

        return resul;
    }

    

    public DataSet CorreoLista(int tipo, long Idusuario)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_CorreoLista";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = tipo;
        sqlCmd.Parameters.Add("@Idusuario", SqlDbType.VarChar).Value = Idusuario;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public void AuditoriaInseta(int IdUsuario, string DireccionIP, Boolean Correcto)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_Auditoria";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
        sqlCmd.Parameters.Add("@DireccionIP", SqlDbType.NVarChar).Value = DireccionIP;
        sqlCmd.Parameters.Add("@Correcto", SqlDbType.Bit).Value = Correcto;

        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public DataSet EstadoConcordato()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_EstadoConcordato";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    

    //29/09/2017
   


    public void EliminaAccionistas(string Nit, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "De_AccionistaEmpresa";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void IngresaAccionistas(string Nit, string cedula, string nombre, float Participacion, int TipoDocumento, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_Accionista";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@cedula", SqlDbType.NVarChar).Value = cedula;
        sqlCmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;
        sqlCmd.Parameters.Add("@Participacion", SqlDbType.Real).Value = Participacion;
        sqlCmd.Parameters.Add("@TipoDocumento", SqlDbType.Int).Value = TipoDocumento;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);


    }

    //27/09/2017
    public void IngresaEjecutivo(string Nit, string cedula, string nombre, string Cargo, int IdTipoEjecutivo, string ActPricipal, int TipoDocumento, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_Ejecutivo";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@cedula", SqlDbType.NVarChar).Value = cedula;
        sqlCmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;
        sqlCmd.Parameters.Add("@Cargo", SqlDbType.NVarChar).Value = Cargo;
        sqlCmd.Parameters.Add("@IdTipoEjecutivo", SqlDbType.Int).Value = IdTipoEjecutivo;
        sqlCmd.Parameters.Add("@ActPricipal", SqlDbType.VarChar).Value = ActPricipal;
        sqlCmd.Parameters.Add("@TipoDocumento", SqlDbType.Int).Value = TipoDocumento;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    

    public void EliminarBalanceAnio(string Nit, int Anio, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "De_BalanceNitAnio";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void EliminarIndicadorXAnio(string Nit, int Anio, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "De_IndicadoresEmp";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void EliminarIndicadorParcialXAnio(string Nit, int Anio, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "De_IndicadoresEmpParcial";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void IngresaBalance(string Nit, int Anio, int IdCuenta, decimal Valor, int IdPais, int Divisa)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_Balance";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdCuenta", SqlDbType.Int).Value = IdCuenta;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;
        sqlCmd.Parameters.Add("@Valor", SqlDbType.Money).Value = Valor;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        sqlCmd.Parameters.Add("@Divisa", SqlDbType.Int).Value = Divisa;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void EliminarBalanceAnioParcial(string Nit, int Anio, int  IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "De_BalanceNitAnioParcial";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }


    public void IngresaBalanceParcial(string Nit, int Anio, int IdCuenta, decimal Valor, int IdPais, int Divisa)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_BalanceParcial";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdCuenta", SqlDbType.Int).Value = IdCuenta;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;
        sqlCmd.Parameters.Add("@Valor", SqlDbType.Money).Value = Valor;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        sqlCmd.Parameters.Add("@Divisa", SqlDbType.Int).Value = Divisa;



        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void IngresaNitAnio(string Nit, int Anio, Boolean NIIF, Boolean Parcial, int IdPais, int Meses, int TipoAuditado)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_NitAnio";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;
        sqlCmd.Parameters.Add("@NIIF", SqlDbType.Bit).Value = NIIF;
        sqlCmd.Parameters.Add("@Parcial", SqlDbType.Bit).Value = Parcial;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        sqlCmd.Parameters.Add("@Meses", SqlDbType.Int).Value = Meses;
        sqlCmd.Parameters.Add("@TipoAuditado", SqlDbType.Int).Value = TipoAuditado;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }
    public void EliminaNitTemporal(int Idusuario)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "De_NitTemporal";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Idusuario", SqlDbType.Int).Value = Idusuario;

        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void IngresaNitTemporal(string Nit, int Idusuario)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_NitTemporal";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Idusuario", SqlDbType.Int).Value = Idusuario;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public long CredCrearProceso(int IdUsuario)
    {
        long resul = 0;

        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_ProcesoCalificion";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
        sqlCmd.Parameters.Add("@IdProceso", SqlDbType.Int).Direction = ParameterDirection.Output;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

        resul = long.Parse(sqlCmd.Parameters["@IdProceso"].Value.ToString());

        return resul;
    }

    public void CredProcesoNit(long IdProceso, string Nit, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();

        sqlCmd.CommandText = "In_ProcesoCalificionNit";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdProceso", SqlDbType.NVarChar).Value = IdProceso;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void CredProcesar(int Id)
    {
        SqlCommand sqlCmd = new SqlCommand();

        sqlCmd.CommandText = "In_ProcesoEjecutar";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
        ClsSQL.ejecutarcomandoBench(sqlCmd);
    }


    public long IngresaAuditoriaCargue(int IdUsuario, string Nit, string CadenaVigencias, string CadenaParcial, int IdPais, string NombreArchivo)
    {
        SqlCommand sqlCmd = new SqlCommand();
        long id = 0;


        sqlCmd.CommandText = "In_AuditoriaCargue";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Vigencias", SqlDbType.NVarChar).Value = CadenaVigencias;
        sqlCmd.Parameters.Add("@Parciales", SqlDbType.NVarChar).Value = CadenaParcial;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        sqlCmd.Parameters.Add("@NombreArchivo", SqlDbType.NVarChar).Value = NombreArchivo;
        sqlCmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

        ClsSQL.ejecutarcomandoBench(sqlCmd);

        id = long.Parse(sqlCmd.Parameters["@Id"].Value.ToString());

        return id;
    }

    public void CredCalculaEmpresa(string Nit, int IdGrupo, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_CalcularIndicadoresEmp";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdGrupo", SqlDbType.Int).Value = IdGrupo;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;

        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public Boolean CredCalculaEmpresaAnio(string Nit, int IdGrupo, int Anio, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        Boolean Resultado = false;

        sqlCmd.CommandText = "In_CalcularIndicadoresEmpAnio";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdGrupo", SqlDbType.Int).Value = IdGrupo;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        sqlCmd.Parameters.Add("@Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
        ClsSQL.ejecutarcomandoBench(sqlCmd);
        Resultado = Boolean.Parse(sqlCmd.Parameters["@Resultado"].Value.ToString());

        return Resultado;

    }

    public Boolean CredCalculaEmpresaAnioParcial(string Nit, int IdGrupo, int Anio, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        Boolean Resultado = false;

        sqlCmd.CommandText = "In_CalcularIndicadoresEmpAnioPacial";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdGrupo", SqlDbType.Int).Value = IdGrupo;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        sqlCmd.Parameters.Add("@Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
        ClsSQL.ejecutarcomandoBench(sqlCmd);
        Resultado = Boolean.Parse(sqlCmd.Parameters["@Resultado"].Value.ToString());

        return Resultado;

    }

    public void CredCalculaCFinanciera(string Nit, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_FinnacieraEmp";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void CredSegmentar(string Nit, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "Up_SegmentarNit";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;

        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public DataSet CredSectoresPorCalcular(int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_SectorexCalcular";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    public DataSet Ciudad(int IdCiudad, int Seleccion, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_Ciudades";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdCiudad", SqlDbType.Int).Value = IdCiudad;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    public DataSet CredEmpresasSinSector(String Nit, Int32 Seleccion, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_EmpresasSinSector";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Buscar", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);
        return ds;
    }

    public void CredEmpresaSectorCambiar(string Nit, int IdSector, int IdSectorViejo, int  IdPais )
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "In_EmpresaSectorCambiar";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdSector", SqlDbType.Int).Value = IdSector;
        sqlCmd.Parameters.Add("@IdSectorAnterior", SqlDbType.Int).Value = IdSectorViejo;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public DataSet PalabrasVetada()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_PalabrasVetadas";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    public DataSet HistorialClave(int IdUsuario, string Clave)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_ClaveExistio";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
        sqlCmd.Parameters.Add("@Clave", SqlDbType.NVarChar).Value = Clave;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet UsuarioCombo()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_UsuarioCombo";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);


        return ds;
    }

    public DataSet UsuarioIngresos(int IdUsuario)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_UsuariosIngresos";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;

        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet AuditoriaCargues(int IdUsuario, string FechaI, string FechaF)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_AuditoCargue";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
        sqlCmd.Parameters.Add("@FechaI", SqlDbType.Date).Value = FechaI;
        sqlCmd.Parameters.Add("@FechaF", SqlDbType.Date).Value = FechaF;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet CredCaliMasivaxFecha(string FechaI, string FechaF)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_ProcesoCalificionxFecha";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@FechaI", SqlDbType.Date).Value = FechaI;
        sqlCmd.Parameters.Add("@FechaF", SqlDbType.Date).Value = FechaF;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet MenuPerfil(int IdPerfil)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_PerfilMenu";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = IdPerfil;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet UsuarioxPerfil(int IdPerfil)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_UsuariosxPerfil";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = IdPerfil;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet UsuarioxPerfil()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_Menus";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;


    }

    public DataSet ExistePerfilMenu(int IdPerfil, int IdMenu)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_ExistePerfilMenu";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = IdPerfil;
        sqlCmd.Parameters.Add("@IdMenu", SqlDbType.Int).Value = IdMenu;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public void EliminaMenuPerfil(int IdPerfil)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "De_MenuPerfil";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = IdPerfil;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void IngresaMenuPerfil(int IdPerfil, int IdMenu)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_MenuPerfil";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = IdPerfil;
        sqlCmd.Parameters.Add("@IdMenu", SqlDbType.Int).Value = IdMenu;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void PerfilEliminar(int IdPerfil)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "De_Perfil";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = IdPerfil;

        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public DataSet PerfilDatos(int IdPerfil)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_PerfilDatos";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = IdPerfil;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    //13/12/2018
    //15/02/2018
    public void PerfilIngresar(string Perfil, string PaginaInicio, Boolean VerInfoFinanciera, Boolean VerRib, Boolean VerRibAsignados, Boolean EnviaMControl, Boolean EnviaCoordinador, Boolean HabilitaFirma, Boolean CrearEmpresaGE)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "In_Perfil";
        sqlCmd.CommandType = CommandType.StoredProcedure;


        sqlCmd.Parameters.Add("@Perfil", SqlDbType.NVarChar).Value = Perfil;
        sqlCmd.Parameters.Add("@PaginaInicio", SqlDbType.NVarChar).Value = PaginaInicio;
        sqlCmd.Parameters.Add("@VerInfoFinanciera", SqlDbType.Bit).Value = VerInfoFinanciera;
        sqlCmd.Parameters.Add("@VerRib", SqlDbType.Bit).Value = VerRib;
        sqlCmd.Parameters.Add("@VerAsignados", SqlDbType.Bit).Value = VerRibAsignados;
        sqlCmd.Parameters.Add("@EnviaMControl", SqlDbType.Bit).Value = EnviaMControl;
        sqlCmd.Parameters.Add("@EnviaCoordinador", SqlDbType.Bit).Value = EnviaCoordinador;
        sqlCmd.Parameters.Add("@HabilitaFirma", SqlDbType.Bit).Value = HabilitaFirma;
        sqlCmd.Parameters.Add("@CrearEmpresaGE", SqlDbType.Bit).Value = CrearEmpresaGE;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }
    //13/12/2018
    public void PerfilActualiza(int IdPerfil, string Perfil, string PaginaInicio, Boolean VerInfoFinanciera, Boolean VerRib, Boolean VerRibAsignados, Boolean EnviaMControl, Boolean EnviaCoordinador, Boolean HabilitaFirma, Boolean CrearEmpresaGE)
    {
        SqlCommand sqlCmd = new SqlCommand();

        sqlCmd.CommandText = "Up_Perfil";
        sqlCmd.CommandType = CommandType.StoredProcedure;

        sqlCmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = IdPerfil;
        sqlCmd.Parameters.Add("@Perfil", SqlDbType.NVarChar).Value = Perfil;
        sqlCmd.Parameters.Add("@PaginaInicio", SqlDbType.NVarChar).Value = PaginaInicio;
        sqlCmd.Parameters.Add("@VerInfoFinanciera", SqlDbType.Bit).Value = VerInfoFinanciera;
        sqlCmd.Parameters.Add("@VerRib", SqlDbType.Bit).Value = VerRib;
        sqlCmd.Parameters.Add("@VerAsignados", SqlDbType.Bit).Value = VerRibAsignados;
        sqlCmd.Parameters.Add("@EnviaMControl", SqlDbType.Bit).Value = EnviaMControl;
        sqlCmd.Parameters.Add("@EnviaCoordinador", SqlDbType.Bit).Value = EnviaCoordinador;
        sqlCmd.Parameters.Add("@HabilitaFirma", SqlDbType.Bit).Value = HabilitaFirma;
        sqlCmd.Parameters.Add("@CrearEmpresaGE", SqlDbType.Bit).Value = CrearEmpresaGE;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public DataSet CredEstados(int Seleccion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_Estado";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

   

    public void Up_DiasVencimiento(int Dias)
    {
        SqlCommand sqlCmd = new SqlCommand();

        sqlCmd.CommandText = "Up_DiasVencimiento";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Dias", SqlDbType.Money).Value = Dias;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }


    public void UsuarioResetPass(int IdUsuario, string Usuario, string Nombre, string Correo, string Cargo, string Telefono, string Celular, string Extension, int IdPerfil, Boolean Bloqueado, string Identificacion, string Clave, int IdEstUsuario)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "Up_UsuarioPass";
        sqlCmd.CommandType = CommandType.StoredProcedure;

        sqlCmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
        sqlCmd.Parameters.Add("@Usuario", SqlDbType.NVarChar).Value = Usuario;
        sqlCmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = Nombre;
        sqlCmd.Parameters.Add("@Correo", SqlDbType.NVarChar).Value = Correo;
        sqlCmd.Parameters.Add("@Cargo", SqlDbType.NVarChar).Value = Cargo;
        sqlCmd.Parameters.Add("@Telefono", SqlDbType.NVarChar).Value = Telefono;
        sqlCmd.Parameters.Add("@Celular", SqlDbType.NVarChar).Value = Celular;
        sqlCmd.Parameters.Add("@Extension", SqlDbType.NVarChar).Value = Extension;
        sqlCmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = IdPerfil;
        sqlCmd.Parameters.Add("@Bloqueado", SqlDbType.Bit).Value = Bloqueado;
        sqlCmd.Parameters.Add("@Identificacion", SqlDbType.NVarChar).Value = Identificacion;
        sqlCmd.Parameters.Add("@Clave", SqlDbType.NVarChar).Value = Clave;
        sqlCmd.Parameters.Add("@IdEstUsuario", SqlDbType.Int).Value = IdEstUsuario;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void UsuarioIntentos(int IdUsuario)
    {

        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Up_IntentosUsuario";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void IngresosFallido(string Usuario, string DireccionIP)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "In_IngresoFallido";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Usuario", SqlDbType.NVarChar).Value = Usuario;
        sqlCmd.Parameters.Add("@DireccionIP", SqlDbType.NVarChar).Value = DireccionIP;
        ClsSQL.CreateDataSetBench(sqlCmd);

    }

    public DataSet AuditoriaxNit(string Nit, int IdPais, int IdOpcion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_AuditoriaxNit";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        sqlCmd.Parameters.Add("@Opcion", SqlDbType.Int).Value = IdOpcion;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet ConsultarCiiu(int Ciiu)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_SectorCiiu";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Ciiu", SqlDbType.Int).Value = Ciiu;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet CiiuSectorLista()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_SectorCiiuLista";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet CiiuLista()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_CiiuLista";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public int InsertaSectorCiiu(int IdSector, int Ciiu)
    {
        SqlCommand sqlCmd = new SqlCommand();
        int resul = 0;


        sqlCmd.CommandText = "In_SectorCiiu";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdSector", SqlDbType.Int).Value = IdSector;
        sqlCmd.Parameters.Add("@Ciiu", SqlDbType.NVarChar).Value = Ciiu;
        sqlCmd.Parameters.Add("@Resul", SqlDbType.Int).Direction = ParameterDirection.Output;
        ClsSQL.ejecutarcomandoBench(sqlCmd);
        resul = int.Parse(sqlCmd.Parameters["@Resul"].Value.ToString());

        return resul;
    }

    public void EliminarSectorCiiu(int IdSector, int Ciiu)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "De_SectorCiiu";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdSector", SqlDbType.Int).Value = IdSector;
        sqlCmd.Parameters.Add("@Ciiu", SqlDbType.NVarChar).Value = Ciiu;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void ActualizarEmpresa(string Nit, string RazonSocial, string Sigla, string RepresentanteLegal, string Direccion, string Telefono, string Fax, string AA, string NumMatricula, string Email, string Website, string Ciiu, Boolean EsCliente, int IdPais, int IdCiudad, string Consecutivo, int TipoId)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "Up_Empresa";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@RazonSocial", SqlDbType.NVarChar).Value = RazonSocial;
        sqlCmd.Parameters.Add("@Sigla", SqlDbType.NVarChar).Value = Sigla;
        sqlCmd.Parameters.Add("@RepresentanteLegal", SqlDbType.NVarChar).Value = RepresentanteLegal;
        sqlCmd.Parameters.Add("@Direccion", SqlDbType.NVarChar).Value = Direccion;
        sqlCmd.Parameters.Add("@Telefono", SqlDbType.NVarChar).Value = Telefono;
        sqlCmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = Fax;
        sqlCmd.Parameters.Add("@AA", SqlDbType.NVarChar).Value = AA;
        sqlCmd.Parameters.Add("@NumMatricula", SqlDbType.NVarChar).Value = NumMatricula;
        sqlCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
        sqlCmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = Website;
        sqlCmd.Parameters.Add("@Ciiu", SqlDbType.NVarChar).Value = Ciiu;
        sqlCmd.Parameters.Add("@EsCliente", SqlDbType.NVarChar).Value = EsCliente;
        sqlCmd.Parameters.Add("@IdCiudad", SqlDbType.NVarChar).Value = IdCiudad;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        sqlCmd.Parameters.Add("@Consecutivo", SqlDbType.VarChar).Value = Consecutivo;
        sqlCmd.Parameters.Add("@TipoId", SqlDbType.Int).Value = TipoId;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }





    public void PeridosIngresa(int Anio_Mes, Boolean EstadoPeriodo, Boolean Seleccion, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_Periodos";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Anio_Mes", SqlDbType.Int).Value = Anio_Mes;
        sqlCmd.Parameters.Add("@EstadoPeriodo", SqlDbType.Bit).Value = EstadoPeriodo;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Bit).Value = Seleccion;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void PeridosEliminar(int Anio_Mes)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "De_Periodos";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Anio_Mes", SqlDbType.Int).Value = Anio_Mes;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public DataSet CredIndicadorMaxMinAux(int Anio, int IdIndicador, int Idusuario)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_IndicadorMaxMinAux";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;
        sqlCmd.Parameters.Add("@IdIndicador", SqlDbType.Int).Value = IdIndicador;
        sqlCmd.Parameters.Add("@Idusuario", SqlDbType.Int).Value = Idusuario;

        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet CredPucMaxMinAux(int Anio, int IdCuenta, int Idusuario, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_PucMaxMinAux";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;
        sqlCmd.Parameters.Add("@IdCuenta", SqlDbType.Int).Value = IdCuenta;
        sqlCmd.Parameters.Add("@Idusuario", SqlDbType.Int).Value = Idusuario;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;

        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet CredProspectarAux(int Anio, string CadIndicadores, string CadCiudad, int IdUsuario, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_ProspectarAux";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.NVarChar).Value = Anio;
        sqlCmd.Parameters.Add("@CadIndicadores", SqlDbType.NVarChar).Value = CadIndicadores;
        sqlCmd.Parameters.Add("@CadCiudad", SqlDbType.NVarChar).Value = CadCiudad;
        sqlCmd.Parameters.Add("@IdUsuario", SqlDbType.NVarChar).Value = IdUsuario;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public void EliminarListaOfac(int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "De_ListaOfac";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void OfacIngresa(string Documento, string Nombre, string Observacion, string Numerico, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_ListaOfac";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Documento", SqlDbType.NVarChar).Value = Documento;
        sqlCmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = Nombre;
        sqlCmd.Parameters.Add("@Observacion", SqlDbType.NVarChar).Value = Observacion;
        sqlCmd.Parameters.Add("@Numerico", SqlDbType.NVarChar).Value = Numerico;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void ListaOfacActualiza(int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "Up_CampOfac";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void LimpiaLey1116()
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "Up_Ley1116";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void IngresaLey1116(string Nit, int Ley1116, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "Up_Ley1116New";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Ley1116", SqlDbType.NVarChar).Value = Ley1116;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void ActializaFechaLey1116(int Id)
    {
        SqlCommand sqlCmd = new SqlCommand();

        sqlCmd.CommandText = "Up_Ley1116Fecha";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
        ClsSQL.ejecutarcomandoBench(sqlCmd);
    }

    public void IngresaNitValores(string Nit, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_NitValores";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void LimpiaNitValores()
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "De_NitValores";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public DataSet CredEmpresasConParcial(int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_InfoEmpresasConParcial";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet CredBuscarEmpresaParcial(string buscar, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_BusEmpresasParcial";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Buscar", SqlDbType.VarChar).Value = buscar;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet ValidarUsuarioBloqueado(string usuario)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_ValidaUsuarioBloqueado";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 50).Value = usuario;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public void CredEmpresaEliminar(string Nit, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "De_Empresa";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void CredActualizaLogCargue(long Id, int Opcion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Up_AuditoriaCargue";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = Id;
        sqlCmd.Parameters.Add("@Opcion", SqlDbType.Int).Value = Opcion;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    /*   ** 16-Julio-2014 ** --> Se crea el método BencEmpresasListaExportarData.
         ** Creado por Agustín David Cruz González **           */

    public DataSet BencEmpresasListaExportarData(int IdSector)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_BencEmpresasListaExportar";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdSector", SqlDbType.Int).Value = IdSector;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    // Fin método BencEmpresasListaExportarData
    //Calificacion Cualitativa 02/11/2016

    public DataSet AgrupacionCualitativa(Boolean Seleccion, long IdAgrupacion, int IdEncCualitativa)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_AgrupacioinEncuesta";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@seleccion", SqlDbType.Bit).Value = Seleccion;
        sqlCmd.Parameters.Add("@IdAgrupacion", SqlDbType.Int).Value = IdAgrupacion;
        sqlCmd.Parameters.Add("@IdEncCualitativa", SqlDbType.Int).Value = IdEncCualitativa;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    public DataSet PreguntasLista(Boolean seleccion, int IdAgrupacion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_VariablesCualitativa";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@seleccion", SqlDbType.Bit).Value = seleccion;
        sqlCmd.Parameters.Add("@IdAgrupacion", SqlDbType.Int).Value = IdAgrupacion;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    public DataSet RespuestasLista(int IdVariable, Boolean seleccion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_RespuestaCualitativa";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdVariable", SqlDbType.Int).Value = IdVariable;
        sqlCmd.Parameters.Add("@seleccion", SqlDbType.Bit).Value = seleccion;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    public long PondCualitativa(int IdEncCualitativa, string Descripcion, string Nit, Decimal Puntaje, string FechaCreacion, int estado, int IdUsuario, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        long resul = 0;


        sqlCmd.CommandText = "In_PondCualitativa";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdEncCualitativa", SqlDbType.Int).Value = IdEncCualitativa;
        sqlCmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar).Value = Descripcion;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Puntaje", SqlDbType.Decimal).Value = Puntaje;
        sqlCmd.Parameters.Add("@FechaCreacion", SqlDbType.DateTime).Value = FechaCreacion;
        sqlCmd.Parameters.Add("@Estado", SqlDbType.Int).Value = estado;
        sqlCmd.Parameters.Add("@IdPonderado", SqlDbType.BigInt).Direction = ParameterDirection.Output;
        sqlCmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);
        resul = int.Parse(sqlCmd.Parameters["@IdPonderado"].Value.ToString());

        return resul;
    }

    public void RespustaCualitativa(int IdAgrupacion, int IdVariable, int IdRespuesta, string Nit, long IdPonderado, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_RespCualitativa";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdAgrupacion", SqlDbType.Int).Value = IdAgrupacion;
        sqlCmd.Parameters.Add("@IdVariable", SqlDbType.Int).Value = IdVariable;
        sqlCmd.Parameters.Add("@IdRespuesta", SqlDbType.Int).Value = IdRespuesta;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdPonderado", SqlDbType.NVarChar).Value = IdPonderado;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);


    }

    public DataSet HistoricoCualitativa(string IdEmpresa, int IdEncCualitativa, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_HistoricoCualitativa";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = IdEmpresa;
        sqlCmd.Parameters.Add("@IdEncCualitativa", SqlDbType.Int).Value = IdEncCualitativa;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    public DataSet CualitativaFinal(long Cualitativa)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_CualitativaTerminada";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Cualitativa", SqlDbType.NVarChar).Value = Cualitativa;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    //V2
    public DataSet CualitativaSeleccion()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_EncuestaCualitativa";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    //V3
    public DataSet Encuesta(int IdEncCualitativa, int Seleccion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_Encuesta";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdEncCualitativa", SqlDbType.Int).Value = IdEncCualitativa;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet Agrupacion(int IdEncCualitativa, int Seleccion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_Agrupacion";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdEncCualitativa", SqlDbType.Int).Value = IdEncCualitativa;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet Variables(int IdAgruapcion, int Seleccion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_Variables";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdAgrupacion", SqlDbType.Int).Value = IdAgruapcion;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet Respuestas(int IdVariable, int Seleccion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_Respuestas";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdVariable", SqlDbType.Int).Value = IdVariable;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public void InEncCualitativa(string NomCualitativa, string DescCualitativa, Boolean Estado)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_EncuestaCualitativa";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@NomCualitativa", SqlDbType.VarChar).Value = NomCualitativa;
        sqlCmd.Parameters.Add("@DescCualitativa", SqlDbType.VarChar).Value = DescCualitativa;
        sqlCmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void InAgrupacion(string Agrupacion, decimal Peso, Boolean Estado, int IdEncCualitativa)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_Agrupacion";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Agrupacion", SqlDbType.VarChar).Value = Agrupacion;
        sqlCmd.Parameters.Add("@Peso", SqlDbType.Decimal).Value = Peso;
        sqlCmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;
        sqlCmd.Parameters.Add("@IdEncCualitativa", SqlDbType.Int).Value = IdEncCualitativa;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void InVariables(string Variable, decimal Peso, Boolean Estado, int IdAgrupacion)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_Variables";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Variable", SqlDbType.VarChar).Value = Variable;
        sqlCmd.Parameters.Add("@Peso", SqlDbType.Decimal).Value = Peso;
        sqlCmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;
        sqlCmd.Parameters.Add("@IdAgrupacion", SqlDbType.Int).Value = IdAgrupacion;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void InRespuestas(string Respuesta, decimal Factor, Boolean Estado, int IdVariable)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_Respuestas";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Respuesta", SqlDbType.VarChar).Value = Respuesta;
        sqlCmd.Parameters.Add("@Factor", SqlDbType.Decimal).Value = Factor;
        sqlCmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;
        sqlCmd.Parameters.Add("@IdVariable", SqlDbType.Int).Value = IdVariable;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void UpEncCualitativa(string NomCualitativa, string DescCualitativa, Boolean Estado, int IdEncCualitativa)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "Up_EncuestaCualitativa";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@NomCualitativa", SqlDbType.VarChar).Value = NomCualitativa;
        sqlCmd.Parameters.Add("@DescCualitativa", SqlDbType.VarChar).Value = DescCualitativa;
        sqlCmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;
        sqlCmd.Parameters.Add("@IdEncCualitativa", SqlDbType.Int).Value = IdEncCualitativa;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void UpAgrupacion(string Agrupacion, decimal Peso, Boolean Estado, int IdEncCualitativa, int IdAgrupacion, int Seleccion)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "Up_Agrupacion";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Agrupacion", SqlDbType.VarChar).Value = Agrupacion;
        sqlCmd.Parameters.Add("@Peso", SqlDbType.Decimal).Value = Peso;
        sqlCmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;
        sqlCmd.Parameters.Add("@IdEncCualitativa", SqlDbType.Int).Value = IdEncCualitativa;
        sqlCmd.Parameters.Add("@IdAgrupacion", SqlDbType.Int).Value = IdAgrupacion;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void UpVariables(string Variable, decimal Peso, Boolean Estado, int IdAgrupacion, int IdVariable, int Seleccion)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "Up_Variables";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Variable", SqlDbType.VarChar).Value = Variable;
        sqlCmd.Parameters.Add("@Peso", SqlDbType.Decimal).Value = Peso;
        sqlCmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;
        sqlCmd.Parameters.Add("@IdAgrupacion", SqlDbType.Int).Value = IdAgrupacion;
        sqlCmd.Parameters.Add("@IdVariable", SqlDbType.Int).Value = IdVariable;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void UpRespuestas(string Respuesta, decimal Factor, Boolean Estado, int IdVariable, int IdRespuesta, int Seleccion)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "Up_Respuestas";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Respuesta", SqlDbType.VarChar).Value = Respuesta;
        sqlCmd.Parameters.Add("@Factor", SqlDbType.Decimal).Value = Factor;
        sqlCmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;
        sqlCmd.Parameters.Add("@IdVariable", SqlDbType.Int).Value = IdVariable;
        sqlCmd.Parameters.Add("@IdRespuesta", SqlDbType.Int).Value = IdRespuesta;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    //CPI CCG 28/11/2016
   

    public DataSet SeCPIDiasMora(int IdCPiDiasMora, int Seleccion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_CPIDiasMora";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdCpIDiasMora", SqlDbType.Decimal).Value = IdCPiDiasMora;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.BigInt).Value = Seleccion;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet SeCPIPeriodo(int IdCpIPeriodo, int Seleccion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_CPIPeriodo";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdCpIPeriodo", SqlDbType.Decimal).Value = IdCpIPeriodo;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.BigInt).Value = Seleccion;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet SeCPagoInterno(string Nit, int Seleccion, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_CPagoInterno";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.VarChar).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet SeCPagoInternoData(Boolean existe)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_CPagoInternoData";
        sqlCmd.Parameters.Add("@existe", SqlDbType.Bit).Value = existe;
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    //06/07/2017
    public void SECPIData(int anio, int IdUsuario, Boolean CalificaIndividual, string Nit, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_CPagoInterno";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
        sqlCmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
        sqlCmd.Parameters.Add("@CalificaIndividual", SqlDbType.Bit).Value = CalificaIndividual;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void InCPIDiasMora(string AlturaMora, int VAlturaMora, Boolean Estado, Decimal Factor)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_CPIDiasMora";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@AlturaMora", SqlDbType.VarChar).Value = AlturaMora;
        sqlCmd.Parameters.Add("@VAlturaMora", SqlDbType.Int).Value = VAlturaMora;
        sqlCmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;
        sqlCmd.Parameters.Add("@Factor", SqlDbType.Decimal).Value = Factor;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void InCPIPeriodo(string Periodo, int Peso, Boolean Estado, Decimal Factor)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_CPIPeriodo";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Periodo", SqlDbType.VarChar).Value = Periodo;
        sqlCmd.Parameters.Add("@Peso", SqlDbType.Int).Value = Peso;
        sqlCmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;
        sqlCmd.Parameters.Add("@Factor", SqlDbType.Decimal).Value = Factor;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void UpCPIDiasMora(string AlturaMora, decimal Factor, Boolean Estado, int VAlturaMora, int IdCpIDiasMora, int Seleccion)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "Up_CPIDiasMora";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@AlturaMora", SqlDbType.VarChar).Value = AlturaMora;
        sqlCmd.Parameters.Add("@Factor", SqlDbType.Decimal).Value = Factor;
        sqlCmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;
        sqlCmd.Parameters.Add("@VAlturaMora", SqlDbType.Int).Value = VAlturaMora;
        sqlCmd.Parameters.Add("@IdCpIDiasMora", SqlDbType.Int).Value = IdCpIDiasMora;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void UpCPIPeriodo(string Periodo, decimal Factor, Boolean Estado, int Peso, int IdCpIPeriodo, int Seleccion)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "Up_CPIPeriodo";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Periodo", SqlDbType.VarChar).Value = Periodo;
        sqlCmd.Parameters.Add("@Factor", SqlDbType.Decimal).Value = Factor;
        sqlCmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;
        sqlCmd.Parameters.Add("@Peso", SqlDbType.Int).Value = Peso;
        sqlCmd.Parameters.Add("@IdCpIPeriodo", SqlDbType.Int).Value = IdCpIPeriodo;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    //CPE CCG 05/12/2016
    //CPE CCG 06/07/2017
    public void SECPEData(int anio, int IdUsuario, Boolean CalificaIndividual, string Nit, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_CPagoExterno";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
        sqlCmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
        sqlCmd.Parameters.Add("@CalificaIndividual", SqlDbType.Bit).Value = CalificaIndividual;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public DataSet SeCPagoExterno(string Nit, int Seleccion, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_CPagoExterno";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet SeCPECalificacion(int IdCpECalificacion, int Seleccion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_CPECalificacion";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdCpECalificacion", SqlDbType.Decimal).Value = IdCpECalificacion;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.BigInt).Value = Seleccion;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet SeCPEPeriodo(int IdCpEPeriodo, int Seleccion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_CPEPeriodo";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdCpEPeriodo", SqlDbType.Decimal).Value = IdCpEPeriodo;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.BigInt).Value = Seleccion;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }


    public void InCPECalificacion(string Calificacion, Decimal Factor, Boolean Estado, Decimal PisoCPE)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_CPECalificacion";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Calificacion", SqlDbType.VarChar).Value = Calificacion;
        sqlCmd.Parameters.Add("@Factor", SqlDbType.Decimal).Value = Factor;
        sqlCmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;
        sqlCmd.Parameters.Add("@PisoCPE", SqlDbType.Money).Value = PisoCPE;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void UpCPECalificacion(string Calificacion, decimal Factor, Boolean Estado, int IdCpECalificacion, int Seleccion, decimal PisoCPE)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "Up_CPECalificacion";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Calificacion", SqlDbType.VarChar).Value = Calificacion;
        sqlCmd.Parameters.Add("@Factor", SqlDbType.Decimal).Value = Factor;
        sqlCmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;
        sqlCmd.Parameters.Add("@IdCpECalificacion", SqlDbType.Int).Value = IdCpECalificacion;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@PisoCPE", SqlDbType.Decimal).Value = PisoCPE;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void InCPEPeriodo(string Periodo, int Peso, Boolean Estado, Decimal FactorCPE)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_CPEPeriodo";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Periodo", SqlDbType.VarChar).Value = Periodo;
        sqlCmd.Parameters.Add("@Peso", SqlDbType.Int).Value = Peso;
        sqlCmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;
        sqlCmd.Parameters.Add("@FactorCPE", SqlDbType.Decimal).Value = FactorCPE;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void UpCPEPeriodo(string Periodo, decimal FactorCPE, Boolean Estado, int Peso, int IdCpEPeriodo, int Seleccion)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "Up_CPEPeriodo";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Periodo", SqlDbType.VarChar).Value = Periodo;
        sqlCmd.Parameters.Add("@FactorCPE", SqlDbType.Decimal).Value = FactorCPE;
        sqlCmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;
        sqlCmd.Parameters.Add("@Peso", SqlDbType.Int).Value = Peso;
        sqlCmd.Parameters.Add("@IdCpEPeriodo", SqlDbType.Int).Value = IdCpEPeriodo;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        ClsSQL.ejecutarcomandoBench(sqlCmd);


    }

    public DataSet SeCPagoExternoData(int existe)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_CPagoExternoData";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@existe", SqlDbType.Int).Value = existe;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet SePeriodos(int idOpcion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_Periodos";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@idOpcion", SqlDbType.Int).Value = idOpcion;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet CredCfinalxInfo(int Anio_Mes, long IdProceso, int IdOpcion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_CFinalxInfo";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Anio_Mes", SqlDbType.Int).Value = Anio_Mes;
        sqlCmd.Parameters.Add("@IdProceso", SqlDbType.Int).Value = IdProceso;
        sqlCmd.Parameters.Add("@IdOpcion", SqlDbType.Int).Value = IdOpcion;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet CredCfinalPublicaInfo(int IdOpcion, int Anio_Mes, string Nit, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_CFinalPublicaxInfo";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdOpcion", SqlDbType.Int).Value = IdOpcion;
        sqlCmd.Parameters.Add("@Anio_Mes", SqlDbType.Int).Value = Anio_Mes;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.Int).Value = Nit;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;

        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet CredCfinalPublicaUditoria(int IdOpcion, int Anio_Mes, string Nit, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_CFinalPublicaAuditoriaAuditoria";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdOpcion", SqlDbType.Int).Value = IdOpcion;
        sqlCmd.Parameters.Add("@Anio_Mes", SqlDbType.Int).Value = Anio_Mes;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.Int).Value = Nit;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet CredCfinalxInfo(long IdProceso)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_ProcesoCalificionNit";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdProceso", SqlDbType.Int).Value = IdProceso;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet DeInfoCalificaciones(int Seleccion, Boolean Masivo)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "De_InfoCalificaciones";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@Masivo", SqlDbType.Bit).Value = Masivo;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

   

    public int InTipGarantias(int IdTipGarantia, string TipGarantia, string Factor, long Cubrimiento, long Puntaje)
    {
        SqlCommand sqlCmd = new SqlCommand();
        int IdExiste = 0;


        sqlCmd.CommandText = "In_TipGarantias";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdTipGarantia", SqlDbType.VarChar).Value = IdTipGarantia;
        sqlCmd.Parameters.Add("@TipGarantia", SqlDbType.VarChar).Value = TipGarantia;
        sqlCmd.Parameters.Add("@Factor", SqlDbType.VarChar).Value = Factor;
        sqlCmd.Parameters.Add("@Cubrimiento", SqlDbType.VarChar).Value = Cubrimiento;
        sqlCmd.Parameters.Add("@Puntaje", SqlDbType.VarChar).Value = Puntaje;
        sqlCmd.Parameters.Add("@IdExiste", SqlDbType.Int).Direction = ParameterDirection.Output;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

        IdExiste = int.Parse(sqlCmd.Parameters["@IdExiste"].Value.ToString());

        return IdExiste;

    }

    public void UpTipGarantias(string TipGarantia, string Factor, long Cubrimiento, long Puntaje, int IdTipGarantia)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "Up_TipGarantias";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@TipGarantia", SqlDbType.VarChar).Value = TipGarantia;
        sqlCmd.Parameters.Add("@Factor", SqlDbType.VarChar).Value = Factor;
        sqlCmd.Parameters.Add("@Cubrimiento", SqlDbType.VarChar).Value = Cubrimiento;
        sqlCmd.Parameters.Add("@Puntaje", SqlDbType.VarChar).Value = Puntaje;
        sqlCmd.Parameters.Add("@IdTipGarantia", SqlDbType.Int).Value = IdTipGarantia;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }




    public void ComContactoNew(string Nit, string Nombre, string Cargo, string Pbx, string Mail, Boolean BancaInversion, string TelCelular, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_Contacto";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = Nombre;
        sqlCmd.Parameters.Add("@Cargo", SqlDbType.NVarChar).Value = Cargo;
        sqlCmd.Parameters.Add("@Pbx", SqlDbType.NVarChar).Value = Pbx;
        sqlCmd.Parameters.Add("@Mail", SqlDbType.NVarChar).Value = Mail;
        sqlCmd.Parameters.Add("@BancaInversion", SqlDbType.Bit).Value = BancaInversion;
        sqlCmd.Parameters.Add("@NumCelular", SqlDbType.VarChar).Value = TelCelular;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;

        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public DataSet ComEmpresaContactos(string Nit, Boolean Estado, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_EmpresaContactos";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Estado", SqlDbType.Int).Value = Estado;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public void ActualizaContactosEmpresa(string Nit, int IdContacto, string Nombre, string Cargo, string Pbx, string Mail, string Celular, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "Up_ContactoEmpresa";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdContacto", SqlDbType.NVarChar).Value = IdContacto;
        sqlCmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre;
        sqlCmd.Parameters.Add("@Cargo", SqlDbType.NVarChar).Value = Cargo;
        sqlCmd.Parameters.Add("@Pbx", SqlDbType.NVarChar).Value = Pbx;
        sqlCmd.Parameters.Add("@Mail", SqlDbType.NVarChar).Value = Mail;
        sqlCmd.Parameters.Add("@NumCelular", SqlDbType.VarChar).Value = Celular;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void IngresaEstrucAdmin(string Nit, long Documento, string Cargo, string nombre, string Antiguedad, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_EstrucAdmin";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Documento", SqlDbType.NVarChar).Value = Documento;
        sqlCmd.Parameters.Add("@Cargo", SqlDbType.NVarChar).Value = Cargo;
        sqlCmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;
        sqlCmd.Parameters.Add("@Antiguedad", SqlDbType.NVarChar).Value = Antiguedad;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;

        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void ActualizaEstrucAdmin(string Nit, long Documento, long DocumentoAnt, string Cargo, string nombre, string Antiguedad, string nombreAnt, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "Up_EstrucAdmin";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Documento", SqlDbType.NVarChar).Value = Documento;
        sqlCmd.Parameters.Add("@DocumentoAnt", SqlDbType.VarChar).Value = DocumentoAnt;
        sqlCmd.Parameters.Add("@Cargo", SqlDbType.NVarChar).Value = Cargo;
        sqlCmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;
        sqlCmd.Parameters.Add("@Antiguedad", SqlDbType.NVarChar).Value = Antiguedad;
        sqlCmd.Parameters.Add("@nombreAnt", SqlDbType.VarChar).Value = nombreAnt;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }


    
    public void DelDatosxEmpresa(int IdRib, string Dato, string Nit, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "De_DatosRibXEmpresa";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdRib", SqlDbType.Int).Value = IdRib;
        sqlCmd.Parameters.Add("@Dato", SqlDbType.VarChar).Value = Dato;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.CreateDataSetBench(sqlCmd);

    }

    public DataSet SeDatosCoXEmpresa(long RipxEmp, string Dato, long IdEmpresa)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_DatosCoXEmpresa";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdRib", SqlDbType.VarChar).Value = RipxEmp;
        sqlCmd.Parameters.Add("@Dato", SqlDbType.VarChar).Value = Dato;
        sqlCmd.Parameters.Add("@IdEmpresa", SqlDbType.VarChar).Value = IdEmpresa;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }




    //06/10/2017
    public DataSet SePais(int Seleccion, string CodPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_Pais";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@CodPais", SqlDbType.VarChar).Value = CodPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    public DataSet CredBalancTabla(string Nit, int IdPais, int IdDivisa)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_BalanceTabla";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        sqlCmd.Parameters.Add("@IdDivisa", SqlDbType.Int).Value = IdDivisa;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    public DataSet CredBalancParcialTabla(string Nit, int IdPais, int IdDivisa)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_BalanceParcialTabla";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        sqlCmd.Parameters.Add("@IdDivisa", SqlDbType.Int).Value = IdDivisa;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }




    public void UpAccionista(string cedula, string cedulaAnt, string nombre, float Participacion, int TipoDocumento, string NomAnt)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "Up_Accionista";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@cedula", SqlDbType.NVarChar).Value = cedula;
        sqlCmd.Parameters.Add("@cedulaAnt", SqlDbType.NVarChar).Value = cedulaAnt;
        sqlCmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;
        sqlCmd.Parameters.Add("@Participacion", SqlDbType.Real).Value = Participacion;
        sqlCmd.Parameters.Add("@TipoDocumento", SqlDbType.Int).Value = TipoDocumento;
        sqlCmd.Parameters.Add("@NomAnt", SqlDbType.VarChar).Value = NomAnt;
        ClsSQL.ejecutarcomandoBench(sqlCmd);


    }


    //modificado CCGC 23/03/2017
    

     

    //configurar modelo

    public DataSet SEPucModelo(string Seleccion, Boolean Valor, int IdModelo)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_PucModelo";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.VarChar).Value = Seleccion;
        sqlCmd.Parameters.Add("@Valor", SqlDbType.Bit).Value = Valor;
        sqlCmd.Parameters.Add("@IdModelo", SqlDbType.Int).Value = IdModelo;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    public void InModelo(int IdModelo, string Modelo, int IdUsuario, Boolean IdEstado, decimal PesoCPIPyme, decimal PesoFinancieraPyme, decimal PesoSectorPyme, decimal PesoCualitativaPyme, decimal PesoCPIEmpre, decimal PesoFinancieraEmpre, decimal PesoSectorEmpre, decimal PesoCualitativaEmpre, decimal PesoCPICoorpo, decimal PesoFinancieraCoorpo, decimal PesoSectorCoorpo, decimal PesoCualitativaCoorpo, Boolean seleccion)
    {

        SqlCommand sqlCmd = new SqlCommand();
        
        sqlCmd.CommandText = "In_Modelo";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdModelo", SqlDbType.Int).Value = IdModelo;
        sqlCmd.Parameters.Add("@Modelo", SqlDbType.VarChar).Value = Modelo;
        sqlCmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
        sqlCmd.Parameters.Add("@IdEstado", SqlDbType.Bit).Value = IdEstado;
        sqlCmd.Parameters.Add("@PesoCPIPyme", SqlDbType.Decimal).Value = PesoCPIPyme;
        sqlCmd.Parameters.Add("@PesoFinancieraPyme", SqlDbType.Decimal).Value = PesoFinancieraPyme;
        sqlCmd.Parameters.Add("@PesoSectorPyme", SqlDbType.Decimal).Value = PesoSectorPyme;
        sqlCmd.Parameters.Add("@PesoCualitativaPyme", SqlDbType.Decimal).Value = PesoCualitativaPyme;
        sqlCmd.Parameters.Add("@PesoCPIEmpre", SqlDbType.Decimal).Value = PesoCPIEmpre;
        sqlCmd.Parameters.Add("@PesoFinancieraEmpre", SqlDbType.Decimal).Value = PesoFinancieraEmpre;
        sqlCmd.Parameters.Add("PesoSectorEmpre", SqlDbType.Decimal).Value = PesoSectorEmpre;
        sqlCmd.Parameters.Add("PesoCualitativaEmpre", SqlDbType.Decimal).Value = PesoCualitativaEmpre;
        sqlCmd.Parameters.Add("PesoCPICoorpo", SqlDbType.Decimal).Value = PesoCPICoorpo;
        sqlCmd.Parameters.Add("PesoFinancieraCoorpo", SqlDbType.Decimal).Value = PesoFinancieraCoorpo;
        sqlCmd.Parameters.Add("PesoSectorCoorpo", SqlDbType.Decimal).Value = PesoSectorCoorpo;
        sqlCmd.Parameters.Add("PesoCualitativaCoorpo", SqlDbType.Decimal).Value = PesoCualitativaCoorpo;
        sqlCmd.Parameters.Add("seleccion", SqlDbType.Bit).Value = seleccion;

        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void InMDIndicadores(int IdModelo, string Indicador, int IdPadre, string Formula, string FormulaParcial, Decimal Peso, Decimal PesoParcial, Decimal DesviacionTecho, Decimal DesviacionPiso, Boolean Activo, Boolean Seleccion, Boolean Veto, Decimal VetoValor, string VetoComparador, int VetoDefault, Boolean AfectaFinal, string FormulaParcialAnio, Decimal PesoParcialAnio, Boolean Descendente, int orden, int CodIndicador, int TipoIndicador, float ValorFijo, decimal Mantener)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_MDIndicadores";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdModelo", SqlDbType.Int).Value = IdModelo;
        sqlCmd.Parameters.Add("@Indicador", SqlDbType.VarChar).Value = Indicador;
        sqlCmd.Parameters.Add("@IdPadre", SqlDbType.Int).Value = IdPadre;
        sqlCmd.Parameters.Add("@Formula", SqlDbType.VarChar).Value = Formula;
        sqlCmd.Parameters.Add("@FormulaParcial", SqlDbType.VarChar).Value = FormulaParcial;
        sqlCmd.Parameters.Add("@Peso", SqlDbType.Decimal).Value = Peso;
        sqlCmd.Parameters.Add("@PesoParcial", SqlDbType.Decimal).Value = PesoParcial;
        sqlCmd.Parameters.Add("@DesviacionTecho", SqlDbType.Money).Value = DesviacionTecho;
        sqlCmd.Parameters.Add("@DesviacionPiso", SqlDbType.Money).Value = DesviacionPiso;
        sqlCmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = Activo;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Bit).Value = Seleccion;
        sqlCmd.Parameters.Add("@Veto", SqlDbType.Bit).Value = Veto;
        sqlCmd.Parameters.Add("@VetoValor", SqlDbType.Money).Value = VetoValor;
        sqlCmd.Parameters.Add("@VetoComparador", SqlDbType.VarChar).Value = VetoComparador;
        sqlCmd.Parameters.Add("@VetoDefault", SqlDbType.Int).Value = VetoDefault;
        sqlCmd.Parameters.Add("@AfectaFinal", SqlDbType.Bit).Value = AfectaFinal;
        sqlCmd.Parameters.Add("@FormulaParcialAnio", SqlDbType.VarChar).Value = FormulaParcialAnio;
        sqlCmd.Parameters.Add("@PesoParcialAnio", SqlDbType.Decimal).Value = PesoParcialAnio;
        sqlCmd.Parameters.Add("@Descendente", SqlDbType.Decimal).Value = Descendente;
        sqlCmd.Parameters.Add("@orden", SqlDbType.Int).Value = orden;
        sqlCmd.Parameters.Add("@CodIndicador", SqlDbType.Int).Value = CodIndicador;
        sqlCmd.Parameters.Add("@TipoIndicador", SqlDbType.Int).Value = TipoIndicador;
        sqlCmd.Parameters.Add("@ValorFijo", SqlDbType.Money).Value = ValorFijo;
        sqlCmd.Parameters.Add("@Mantener", SqlDbType.Money).Value = Mantener;

        ClsSQL.ejecutarcomandoBench(sqlCmd);


    }

    public DataSet SeMDIndicadores(int IdPadre, int IdModelo, int Seleccion, int Indicador)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_MDIndicadores";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdPadre", SqlDbType.Int).Value = IdPadre;
        sqlCmd.Parameters.Add("@IdModelo", SqlDbType.Int).Value = IdModelo;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@Indicador", SqlDbType.Int).Value = Indicador;

        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    public void DelTipGarantias(long IdTipGarantia)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "De_TipGarantias";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdTipGarantia", SqlDbType.Int).Value = IdTipGarantia;
        ClsSQL.CreateDataSetBench(sqlCmd);

    }

    public int DelMDIndicadores(int IdPadre, int IdIndicador)
    {
        SqlCommand sqlCmd = new SqlCommand();
        int Valor = 0;


        sqlCmd.CommandText = "De_MDIndicadores";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdPadre", SqlDbType.Int).Value = IdPadre;
        sqlCmd.Parameters.Add("@IdIndicador", SqlDbType.Int).Value = IdIndicador;
        sqlCmd.Parameters.Add("@Valor", SqlDbType.Int).Direction = ParameterDirection.Output;
        ClsSQL.CreateDataSetBench(sqlCmd);

        Valor = int.Parse(sqlCmd.Parameters["@Valor"].Value.ToString());

        return Valor;

    }

    //informacion Nueva
    public void UpEmpresaCliente(string Nit, int IdPais)
    {

        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "Up_EmpresaCliente";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);



    }

    //21/06/2017
    public DataSet SeGrupoEmpresarial(int IdGrupoEmp, int Seleccion, string Buscar)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_GrupoEmpresarial";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdGrupoEmp", SqlDbType.Int).Value = IdGrupoEmp;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@Buscar", SqlDbType.VarChar).Value = Buscar;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet SeGrupoEmpxEmpresas(int IdGrupoEmp, int Seleccion, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_GrupoEmpxEmpresas";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdGrupoEmp", SqlDbType.Int).Value = IdGrupoEmp;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    //28/09/2017
    public int InGrupoEmpresaria(string GrupoEmpresarial, Boolean Estado, int Seleccion, int IdGrupoEmp, string IdEmpresa, string CodGrupo, int IdSectorGE)
    {
        SqlCommand sqlCmd = new SqlCommand();
        int Valor = 0;

        sqlCmd.CommandText = "In_GrupoEmpresarial";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@GrupoEmpresarial", SqlDbType.VarChar).Value = GrupoEmpresarial;
        sqlCmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@IdGrupoEmp", SqlDbType.Int).Value = IdGrupoEmp;
        sqlCmd.Parameters.Add("@IdEmpresa", SqlDbType.VarChar).Value = IdEmpresa;
        sqlCmd.Parameters.Add("@CodGrupo", SqlDbType.VarChar).Value = CodGrupo;
        sqlCmd.Parameters.Add("@IdSectorGE", SqlDbType.Int).Value = IdSectorGE;
        sqlCmd.Parameters.Add("@Valor", SqlDbType.Int).Direction = ParameterDirection.Output;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

        Valor = int.Parse(sqlCmd.Parameters["@Valor"].Value.ToString());

        return Valor;
    }


    public DataSet GcredEmpresaDatosPorRazonSocialLista(string Nit, String RazonSocial, int IdPais)
    {


        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_EmpresaDatosGCPorRazonSocialLista";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@RazonSocial", SqlDbType.VarChar).Value = RazonSocial;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;

        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet GcredEmpresaDatosPorRazonSocial(string Nit, String RazonSocial, int IdPais)
    {

        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_EmpresaDatosGCPorRazonSocial";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@RazonSocial", SqlDbType.VarChar).Value = RazonSocial;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;

        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }


    public DataSet CredNitAnio(string Nit, int IdPais, int IdDivisa)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_NitAnio";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        sqlCmd.Parameters.Add("@IdDivisa", SqlDbType.Int).Value = IdDivisa;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }






    public DataSet CredAniosProspectar(int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_AniosProspectar";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    public void DeEstrucAdmimistrativa(String Documento, string Dato, string Nit, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "De_EstrucAdmimistrativa";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Documento", SqlDbType.VarChar).Value = Documento;
        sqlCmd.Parameters.Add("@Dato", SqlDbType.VarChar).Value = Dato;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.CreateDataSetBench(sqlCmd);


    }

  

   

   

    public DataSet CredCFinalPublica(string Nit, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_CFinalPublica";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet CredCFinanciera(string Nit, int Seleccion, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_CFinancieraTotal";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet CredCFinancieraDetalle(string Nit, int Anio, int Tipo, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_CFinancieraDetalle";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;
        sqlCmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = Tipo;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public Boolean ComValidaPaginaPerfil(int IdPerfil, string pagina)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();
        int Cuantos = 0;
        //
        //{
        sqlCmd.CommandText = "Se_ValidaPaginaPerfil";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdPerfil", SqlDbType.VarChar).Value = IdPerfil;
        sqlCmd.Parameters.Add("@Pagina", SqlDbType.VarChar).Value = pagina;

        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        Cuantos = int.Parse(ds.Tables[0].Rows[0]["Cuantos"].ToString());

        //}
        //catch (Exception e)
        //{
        //    string InnerMensaje = "";
        //    string MensajeError = "";
        //    if (e.InnerException != null) { InnerMensaje = e.InnerException.ToString(); }
        //    if (e.Message != null) { MensajeError = e.Message.ToString(); }

        //    InnerMensaje = InnerMensaje + " - Pagina: Datos - Metodo: SeCCualitativaXEmp";

        //    InLogErrores(InnerMensaje, MensajeError); throw e;
        //}

        if (Cuantos > 0)
        {
            return true;
        }
        else
        {
            return false;
        }


    }
    
    public Boolean CredValidaNitCliente(string Nit, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();
        Boolean existe = false;



        sqlCmd.CommandText = "se_EmpresaDatos";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;

        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        if (ds.Tables[0].Rows.Count > 0)
            existe = true;

        return existe;


    }

    public Boolean CredValidaR(string R)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();
        Boolean existe = false;


        sqlCmd.CommandText = "Se_ValidaLetra";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@R", SqlDbType.NVarChar).Value = R;

        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        if (ds.Tables[0].Rows.Count > 0)
            existe = true;


        return existe;

    }

    public DataSet SelTipGarantias(int Seleccion, int IdTipGarantia)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_TipGarantias";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@IdTipGarantia", SqlDbType.Int).Value = IdTipGarantia;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }


    public DataSet BencEjecutivosEmp(string Nit, Int32 Seleccion, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "se_ejecutivosEmp";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;

        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }


    public int CredPeriodoActivo()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();
        int Period = 0;


        sqlCmd.CommandText = "Se_Periodos";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@idOpcion", SqlDbType.Int).Value = 3;

        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        if (ds.Tables[0].Rows.Count > 0)
            Period = int.Parse(ds.Tables[0].Rows[0]["Anio_Mes"].ToString());

        return Period;

    }

    public Boolean CredPublicarR(string Nit, int Anio_Mes, int IdUsuario, string RFinal, decimal Valor, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();

        Boolean RValida = false;


        sqlCmd.CommandText = "In_CFinalPublica";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Anio_Mes", SqlDbType.Int).Value = Anio_Mes;
        sqlCmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
        sqlCmd.Parameters.Add("@RFinal", SqlDbType.VarChar).Value = RFinal;
        sqlCmd.Parameters.Add("@Valor", SqlDbType.Money).Value = Valor;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        sqlCmd.Parameters.Add("@RValida", SqlDbType.Bit).Direction = ParameterDirection.Output;

        ClsSQL.ejecutarcomandoBench(sqlCmd);

        RValida = Boolean.Parse(sqlCmd.Parameters["@RValida"].Value.ToString());

        return RValida;
    }

    public int CredValidarModelo(int IdModelo)
    {
        SqlCommand sqlCmd = new SqlCommand();

        int Valida;


        sqlCmd.CommandText = "Se_ModeloActivo";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdModelo", SqlDbType.Int).Value = IdModelo;
        sqlCmd.Parameters.Add("@Valor", SqlDbType.Int).Direction = ParameterDirection.Output;

        ClsSQL.ejecutarcomandoBench(sqlCmd);

        Valida = int.Parse(sqlCmd.Parameters["@Valor"].Value.ToString());

        return Valida;
    }

    public void CredRecalcularCF(int IdModelo)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "Up_SectoresCalcularCFinanciera";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdModelo", SqlDbType.Int).Value = IdModelo;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public DataSet SeTipoEmpresa()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_TipoEmpresa";
        sqlCmd.CommandType = CommandType.StoredProcedure;

        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    

    
    //06/07/2017
    public DataSet SeCPIRegla(int IdReglaCpI, int Seleccion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_CPIRegla";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdReglaCpI", SqlDbType.Decimal).Value = IdReglaCpI;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.BigInt).Value = Seleccion;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }
    //06/07/2017
    public void InCPIData(long IDSINDIGIT, Decimal SALDOCAP, int DIASMORA, string CALIF, int ANIO_MES, string REEST, string TGTIA, string CGTIA, long Usuario, Boolean Manual)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_CPagoInternoData";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IDSINDIGIT", SqlDbType.VarChar).Value = IDSINDIGIT;
        sqlCmd.Parameters.Add("@SALDOCAP ", SqlDbType.Money).Value = SALDOCAP;
        sqlCmd.Parameters.Add("@DIASMORA", SqlDbType.Int).Value = DIASMORA;
        sqlCmd.Parameters.Add("@CALIF", SqlDbType.VarChar).Value = CALIF;
        sqlCmd.Parameters.Add("@ANIO_MES", SqlDbType.Int).Value = ANIO_MES;
        sqlCmd.Parameters.Add("@REEST", SqlDbType.VarChar).Value = REEST;
        sqlCmd.Parameters.Add("@TGTIA", SqlDbType.VarChar).Value = TGTIA;
        sqlCmd.Parameters.Add("@CGTIA", SqlDbType.VarChar).Value = CGTIA;
        sqlCmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario;
        sqlCmd.Parameters.Add("@DatoManual", SqlDbType.Bit).Value = Manual;
        ClsSQL.ejecutarcomandoBench(sqlCmd);


    }
    //06/07/2017
    public void InCPEData(long IDENTIFICACION, string NOMBRE_ENTIDAD, string CAL_COMERCIAL, Decimal VAL_TOT_COMERCIAL, int PAR_COMERCIAL, int ANIO_MES, long Usuario, Boolean DatoMAnual, string PAR_ARRAS_COMERCIAL, string TIP_GARANTIA, string MONEDA)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_CPagoExternoData";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IDENTIFICACION", SqlDbType.VarChar).Value = IDENTIFICACION;
        sqlCmd.Parameters.Add("@NOMBRE_ENTIDAD ", SqlDbType.VarChar).Value = NOMBRE_ENTIDAD;
        sqlCmd.Parameters.Add("@CAL_COMERCIAL", SqlDbType.VarChar).Value = CAL_COMERCIAL;
        sqlCmd.Parameters.Add("@VAL_TOT_COMERCIAL", SqlDbType.Money).Value = VAL_TOT_COMERCIAL;
        sqlCmd.Parameters.Add("@PAR_COMERCIAL", SqlDbType.Int).Value = PAR_COMERCIAL;
        sqlCmd.Parameters.Add("@PERIODO_TRIMESTRE", SqlDbType.Int).Value = ANIO_MES;
        sqlCmd.Parameters.Add("@PAR_ARRAS_COMERCIAL", SqlDbType.VarChar).Value = PAR_ARRAS_COMERCIAL;
        sqlCmd.Parameters.Add("@TIP_GARANTIA", SqlDbType.VarChar).Value = TIP_GARANTIA;
        sqlCmd.Parameters.Add("@MONEDA", SqlDbType.VarChar).Value = MONEDA;
        sqlCmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario;
        sqlCmd.Parameters.Add("@DatoManual", SqlDbType.Bit).Value = DatoMAnual;
        ClsSQL.ejecutarcomandoBench(sqlCmd);



    }
    //06/07/2017
    public void InCPIRegla(string Letra, int DiasMora, Decimal Calificacion, Boolean Seleccion, int IdReglaCpI, Decimal Valor, Boolean Estado, Decimal PisoCPI)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_CPIRegla";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Letra", SqlDbType.VarChar).Value = Letra;
        sqlCmd.Parameters.Add("@DiasMora", SqlDbType.Int).Value = DiasMora;
        sqlCmd.Parameters.Add("@Calificacion", SqlDbType.Decimal).Value = Calificacion;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Bit).Value = Seleccion;
        sqlCmd.Parameters.Add("@IdReglaCpI", SqlDbType.Int).Value = IdReglaCpI;
        sqlCmd.Parameters.Add("@Valor", SqlDbType.Decimal).Value = Valor;
        sqlCmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;
        sqlCmd.Parameters.Add("@PisoCPI", SqlDbType.Money).Value = PisoCPI;
        ClsSQL.ejecutarcomandoBench(sqlCmd);


    }
  

    public DataSet SeTRM()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_TRM";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    public void InTRM(Decimal TRM, DateTime FechaCreacion)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_TRM";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@TRM", SqlDbType.Decimal).Value = TRM;
        sqlCmd.Parameters.Add("@FechaCreacion", SqlDbType.DateTime).Value = FechaCreacion;
        ClsSQL.ejecutarcomandoBench(sqlCmd);


    }

    
  
    public void CredEmpresaRecalculaSector(string Nit, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "In_FinnacieraRecalcularEmp";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);


    }

    public DataSet DeCSectorial(int periodo)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "De_SectorCalificacion";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Anio_mes", SqlDbType.Int).Value = periodo;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    /* INICIO: David Alzate 18/08/2017 - Asunto: Nuevos metodos para las tablas parametricas de Segmentos y Nivel de Riesgo */
    public DataSet tiposSegmentos()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_TipoSegmento";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet DatosSegmento(Int32 idSegmento)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_DatosSegmento";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Id", SqlDbType.Int).Value = idSegmento;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    public void Up_DatosSegmento(Int32 Id, String Segmento, Decimal SumarCFinal, Decimal PisoSegmento)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "Up_DatosSegmento";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
        sqlCmd.Parameters.Add("@Segmento", SqlDbType.VarChar).Value = Segmento;
        sqlCmd.Parameters.Add("@SumarCFinal", SqlDbType.Money).Value = SumarCFinal;
        sqlCmd.Parameters.Add("@PisoSegmento", SqlDbType.Money).Value = PisoSegmento;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public DataSet tiposNivelRiesgo()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_TipoNivRiesgo";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet DatosNivRiesgo(Int32 Seleccion, Int32 idNivRiesgo)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_DatosNivRiesgo";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@Id", SqlDbType.Int).Value = idNivRiesgo;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);
        return ds;
    }

    public void Up_DatosNivRiesgo(Int32 Id, String NivelRiesgo, Decimal Valor, Decimal PisoNivelRiesgo, Boolean Activo)
    {
        SqlCommand sqlCmd = new SqlCommand();

        sqlCmd.CommandText = "Up_DatosNivRiesgo";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
        sqlCmd.Parameters.Add("@NivelRiesgo", SqlDbType.VarChar).Value = NivelRiesgo;
        sqlCmd.Parameters.Add("@Valor", SqlDbType.Decimal).Value = Valor;
        sqlCmd.Parameters.Add("@PisoNivRies", SqlDbType.Decimal).Value = PisoNivelRiesgo;
        sqlCmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = Activo;
        ClsSQL.ejecutarcomandoBench(sqlCmd);
    }
    /* FIN: David Alzate - Asunto */

    /* INICIO: David Alzate 24/08/2017 - Asunto: metodo para traer los datos de la tablas de calificacion sectorial */
    public DataSet SeCalifSectorial(string FechaCalif)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_CalificionSectorial";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@AnioMes", SqlDbType.Int).Value = FechaCalif;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }
    /* FIN: David Alzate */

    public DataSet IndicadoresSectorAnio(int IdSector, int IdGrupo, Boolean Promedio, int Anio, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_IndicadoresSecAnio";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdSector", SqlDbType.Int).Value = IdSector;
        sqlCmd.Parameters.Add("@IdGrupo", SqlDbType.Int).Value = IdGrupo;
        sqlCmd.Parameters.Add("@agregado", SqlDbType.Bit).Value = Promedio;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public void In_DatosNivRiesgo(String NivelRiesgo, Decimal Valor, Decimal PisoNivelRiesgo, Boolean Activo)
    {
        SqlCommand sqlCmd = new SqlCommand();

        sqlCmd.CommandText = "In_DatosNivRiesgo";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@NivelRiesgo", SqlDbType.VarChar).Value = NivelRiesgo;
        sqlCmd.Parameters.Add("@Valor", SqlDbType.Decimal).Value = Valor;
        sqlCmd.Parameters.Add("@PisoNivRies", SqlDbType.Decimal).Value = PisoNivelRiesgo;
        sqlCmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = Activo;
        ClsSQL.ejecutarcomandoBench(sqlCmd);
    }

    /* FIN: David Alzate 24/08/2017 */

    /* INICIO: David Alzate 06/09/2017 - Asunto: insercion datos para Auditoria de Aplicativo */
    public void In_Auditoria_Aplicativo(Int32 Idusuario, DateTime FechaSistema, String Opcion, String DirIP, String TipoModif)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_AuditoriaAplicativo";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Idusuario", SqlDbType.Int).Value = Idusuario;
        sqlCmd.Parameters.Add("@FechaSistema", SqlDbType.DateTime).Value = FechaSistema;
        sqlCmd.Parameters.Add("@Opcion", SqlDbType.VarChar).Value = Opcion;
        sqlCmd.Parameters.Add("@DirIP", SqlDbType.VarChar).Value = DirIP;
        sqlCmd.Parameters.Add("@TipoModif", SqlDbType.VarChar).Value = TipoModif;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    /* INICIO: David Alzate 14/09/2017 - Asunto: Actualizacion datos para ingreso de id de nivel y metodo Up_EmpresaNivelRiesgo para actualizar empresa en tabla empresas */

    public Int64 CPublicaNivelRiesgo(String Fecha_Actualización, string Nit_9, int Nivel_Riesgo, int Condiciones_Esp, int Instancia, int Responsable, String Observaciones, String Fecha_Acta, Int32 TipoCargue, long IdUsuario, DateTime FechaCargue, int IdPais)
    {
        Int64 Nit_NoExiste = 0;
        SqlCommand sqlCmd = new SqlCommand();

        sqlCmd.CommandText = "In_CarNivelRiesgo";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        //sqlCmd.Parameters.Add("@Fecha_Actualización", SqlDbType.DateTime).Value = Convert.ToDateTime(Fecha_Actualización).ToShortDateString().ToString();
        sqlCmd.Parameters.Add("@Nit_9", SqlDbType.VarChar).Value = Nit_9;
        sqlCmd.Parameters.Add("@Nivel_Riesgo", SqlDbType.Int).Value = Nivel_Riesgo;
        sqlCmd.Parameters.Add("@Condiciones_Esp", SqlDbType.Int).Value = Condiciones_Esp;
        sqlCmd.Parameters.Add("@Instancia", SqlDbType.Int).Value = Instancia;
        sqlCmd.Parameters.Add("@Responsable", SqlDbType.Int).Value = Responsable;
        sqlCmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = Observaciones;
        sqlCmd.Parameters.Add("@Fecha_Acta", SqlDbType.VarChar).Value = Fecha_Acta;
        sqlCmd.Parameters.Add("@TipoCargue", SqlDbType.VarChar).Value = TipoCargue;
        sqlCmd.Parameters.Add("@UsuarioCargue", SqlDbType.VarChar).Value = IdUsuario;
        sqlCmd.Parameters.Add("@FechaCargue", SqlDbType.DateTime).Value = FechaCargue;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        sqlCmd.Parameters.Add("@Nit_NoExiste", SqlDbType.BigInt).Direction = ParameterDirection.Output;

        ClsSQL.ejecutarcomandoBench(sqlCmd);
        Nit_NoExiste = long.Parse(sqlCmd.Parameters["@Nit_NoExiste"].Value.ToString());
        return Nit_NoExiste;
    }

    public void Up_EmpresaNivelRiesgo(string Nit_9, Int32 IdNivelRiesgo, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "Up_Riesgo_Empresa";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit_9;
        sqlCmd.Parameters.Add("@IdRiesgo", SqlDbType.Int).Value = IdNivelRiesgo;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    /* FIN: David Alzate 14/09/2017 */

    public void DeCarNivelRiesgo(int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "De_CarNivelRiesgo";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.CreateDataSetBench(sqlCmd);

    }


    public DataSet SeDatosNivelesRiesgo(string Nit, int Todos, string FechaI, string FechaF, Int32 Seleccion, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_DatosNivelesRiesgo";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Todos", SqlDbType.Int).Value = Todos;
        sqlCmd.Parameters.Add("@FechaI", SqlDbType.Date).Value = FechaI;
        sqlCmd.Parameters.Add("@FechaF", SqlDbType.Date).Value = FechaF;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet SeMenuOpcionesAuditoria(int Seleccion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_OpcionesMenuAuditoria";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet SeDatosAuditoria(String opcion, String fecha, String fechaF)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_DatosAuditoria";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@opcion", SqlDbType.VarChar).Value = opcion;
        sqlCmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = fecha;
        sqlCmd.Parameters.Add("@FechaF", SqlDbType.Date).Value = fechaF;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }
    /* FIN: David Alzate 06/09/2017 */

    /// <summary>
    /// Retorna una tabla con los datos del documento buscado en la validacion de SARC
    /// </summary>
    /// <param name="documento"></param>
    /// <returns>ds</returns>
    public DataSet SeValidacionSARC(String documento, String Nit, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_ValidacionSARC";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Documento", SqlDbType.VarChar).Value = documento;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    //26/09/2017
    public void Up_TrmDia(int Id, decimal TrmDia)
    {
        SqlCommand sqlCmd = new SqlCommand();

        sqlCmd.CommandText = "Up_TRMDia";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
        sqlCmd.Parameters.Add("@TrmDia", SqlDbType.Money).Value = TrmDia;
        ClsSQL.ejecutarcomandoBench(sqlCmd);
    }

    public int DeGrupoEmpresarial(int IdGrupoEm)
    {
        SqlCommand sqlCmd = new SqlCommand();
        int Valor = 0;


        sqlCmd.CommandText = "De_GrupoEmpresarial";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdGrupoEm", SqlDbType.Int).Value = IdGrupoEm;
        sqlCmd.Parameters.Add("@Valor", SqlDbType.Int).Direction = ParameterDirection.Output;
        ClsSQL.CreateDataSetBench(sqlCmd);

        Valor = int.Parse(sqlCmd.Parameters["@Valor"].Value.ToString());


        return Valor;

    }

  
    //05/10/2017
    public DataSet SeTipoIdentificacion(int Seleccion, int IdTipIdentificacion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_TipoIdentificacion";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@IdTipIdentificacion", SqlDbType.Int).Value = IdTipIdentificacion;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    //06/10/2017
    public void UpDatosEmpresa(int Seleccion, string Nit, string CodPais, int Dato, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "Up_DatosEmpresa";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@CodPais", SqlDbType.NVarChar).Value = CodPais;
        sqlCmd.Parameters.Add("@Dato", SqlDbType.Int).Value = Dato;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;


        ClsSQL.ejecutarcomandoBench(sqlCmd);


    }

    //06/10/2017
    public int SeDatosAgregarEmpresa(int Seleccion, string CodPais, long Dato)
    {
        SqlCommand sqlCmd = new SqlCommand();
        int resul = 0;


        sqlCmd.CommandText = "Se_DatosAgregarEmpresa";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@CodPais", SqlDbType.VarChar).Value = CodPais;
        sqlCmd.Parameters.Add("@Dato", SqlDbType.VarChar).Value = Dato;
        sqlCmd.Parameters.Add("@Valor", SqlDbType.BigInt).Direction = ParameterDirection.Output;
        ClsSQL.CreateDataSetBench(sqlCmd);

        resul = int.Parse(sqlCmd.Parameters["@Valor"].Value.ToString());


        return resul;
    }

    //06/10/2017
    public int InPaises(string CodPais, string Pais, Boolean Filial, int Seleccion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        int Valor = 0;


        sqlCmd.CommandText = "In_Paises";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@CodPais", SqlDbType.VarChar).Value = CodPais;
        sqlCmd.Parameters.Add("@Pais", SqlDbType.VarChar).Value = Pais;
        sqlCmd.Parameters.Add("@Filial", SqlDbType.Bit).Value = Filial;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@Valor", SqlDbType.Int).Direction = ParameterDirection.Output;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

        Valor = int.Parse(sqlCmd.Parameters["@Valor"].Value.ToString());

        return Valor;
    }

    //09/10/2017
    public void InTipoIdentificacion(string TipIdentificacion, int Seleccion, int IdTipoIdentificacion, int CodDavivienda)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_TipoIdentificacion";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@TipIdentificacion", SqlDbType.VarChar).Value = TipIdentificacion;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@IdTipoIdentificacion", SqlDbType.Int).Value = IdTipoIdentificacion;
        sqlCmd.Parameters.Add("@CodDavivienda", SqlDbType.Int).Value = CodDavivienda;
        ClsSQL.ejecutarcomandoBench(sqlCmd);


    }


    public DataSet InfEmpresaFinanciero(int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_EmpresasBalances";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

  
    public DataSet GCredProspectarReciente(string CadIndicadores, string CadCiudad, Boolean PorNit, int IdUsuario, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_ProspectarRecienteGCred";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@CadIndicadores", SqlDbType.NVarChar).Value = CadIndicadores;
        sqlCmd.Parameters.Add("@CadCiudad", SqlDbType.NVarChar).Value = CadCiudad;
        sqlCmd.Parameters.Add("@PorNit", SqlDbType.Bit).Value = PorNit;
        sqlCmd.Parameters.Add("@IdUsuario", SqlDbType.NVarChar).Value = IdUsuario;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;


    }

    public DataSet SeOpcionesNivRiesgo(int Seleccion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_OpcionesNivRiesgo";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    public void InOpcionesNivRiesgo(String OpNivelRiesgo, Int32 Seleccion, Boolean Activo)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_OpcionesNivRiesgo";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Decimal).Value = Seleccion;
        sqlCmd.Parameters.Add("@OpNivelRiesgo", SqlDbType.VarChar).Value = OpNivelRiesgo;
        sqlCmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = Activo;

        ClsSQL.ejecutarcomandoBench(sqlCmd);
    }


    public int SeValidaCargueNRiesgo(int Seleccion, int Dato)
    {
        SqlCommand sqlCmd = new SqlCommand();
        int resul = 0;


        sqlCmd.CommandText = "Se_ValidaCargueNRiesgo";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@Dato", SqlDbType.VarChar).Value = Dato;
        sqlCmd.Parameters.Add("@Valor", SqlDbType.BigInt).Direction = ParameterDirection.Output;
        ClsSQL.CreateDataSetBench(sqlCmd);

        resul = int.Parse(sqlCmd.Parameters["@Valor"].Value.ToString());

        return resul;
    }


    public long InGarantiaXActas(string Campo1, string Campo2, string Campo3, string Campo4, string Campo5, string Campo6, string Campo7, string Campo8, string Campo9, string Campo10,
         long OpcionesGarantia1, long IdUsuario, long IdEmpresa, long IdActa, long IdGarantRib, Boolean VieneRib, Boolean seleccion, int LimiteOperaciones, string Campo11)
    {
        SqlCommand sqlCmd = new SqlCommand();
        long resul = 0;


        sqlCmd.CommandText = "In_GarantiasActas";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Campo1", SqlDbType.VarChar).Value = Campo1;
        sqlCmd.Parameters.Add("@Campo2", SqlDbType.VarChar).Value = Campo2;
        sqlCmd.Parameters.Add("@Campo3", SqlDbType.VarChar).Value = Campo3;
        sqlCmd.Parameters.Add("@Campo4", SqlDbType.VarChar).Value = Campo4;
        sqlCmd.Parameters.Add("@Campo5", SqlDbType.VarChar).Value = Campo5;
        sqlCmd.Parameters.Add("@Campo6", SqlDbType.VarChar).Value = Campo6;
        sqlCmd.Parameters.Add("@Campo7", SqlDbType.VarChar).Value = Campo7;
        sqlCmd.Parameters.Add("@Campo8", SqlDbType.VarChar).Value = Campo8;
        sqlCmd.Parameters.Add("@Campo9", SqlDbType.VarChar).Value = Campo9;
        sqlCmd.Parameters.Add("@Campo10", SqlDbType.VarChar).Value = Campo10;
        sqlCmd.Parameters.Add("@OpcionesGarantia1", SqlDbType.VarChar).Value = OpcionesGarantia1;
        sqlCmd.Parameters.Add("@IdUsuario", SqlDbType.VarChar).Value = IdUsuario;
        sqlCmd.Parameters.Add("@IdEmpresa", SqlDbType.VarChar).Value = IdEmpresa;
        sqlCmd.Parameters.Add("@IdActa", SqlDbType.VarChar).Value = IdActa;
        sqlCmd.Parameters.Add("@IdGarantRib", SqlDbType.VarChar).Value = IdGarantRib;
        sqlCmd.Parameters.Add("@VieneRib", SqlDbType.VarChar).Value = VieneRib;
        sqlCmd.Parameters.Add("@seleccion", SqlDbType.Bit).Value = seleccion;
        sqlCmd.Parameters.Add("@LimiteOperaciones", SqlDbType.Int).Value = LimiteOperaciones;
        sqlCmd.Parameters.Add("@Campo11", SqlDbType.VarChar).Value = Campo11;
        sqlCmd.Parameters.Add("@IdGarantActa", SqlDbType.BigInt).Direction = ParameterDirection.Output;
        ClsSQL.ejecutarcomandoBench(sqlCmd);
        resul = int.Parse(sqlCmd.Parameters["@IdGarantActa"].Value.ToString());

        return resul;
    }

    
   
    public DataSet CreValidacionSARC(Decimal Valor)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_ValidaPuntajeSARC";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Especial", SqlDbType.Decimal).Value = Valor;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }
      

    public void ActualizaJuntaDirectiva(string Nit, string cedula, string cedulaAnt, string nombre, string Cargo, int IdTipoEjecutivo, string ActPricipal, string NomAnt, int TipoDocumento, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "Up_EmpresaEjecutivo";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@cedula", SqlDbType.NVarChar).Value = cedula;
        sqlCmd.Parameters.Add("@cedulaAnt", SqlDbType.VarChar).Value = cedulaAnt;
        sqlCmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;
        sqlCmd.Parameters.Add("@Cargo", SqlDbType.NVarChar).Value = Cargo;
        sqlCmd.Parameters.Add("@IdTipoEjecutivo", SqlDbType.Int).Value = IdTipoEjecutivo;
        sqlCmd.Parameters.Add("@ActPricipal", SqlDbType.VarChar).Value = ActPricipal;
        sqlCmd.Parameters.Add("@NomAnt", SqlDbType.VarChar).Value = NomAnt;
        sqlCmd.Parameters.Add("@TipoDocumento", SqlDbType.VarChar).Value = TipoDocumento;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);


    }

    public DataSet TipoDocumento()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_TipoDocumento";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

   

    public DataSet GCredVegenciaPacial(int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_VigenciaPacial";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;

        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;


    }


    public DataSet GCredVegencia(int IdPais, int Opcion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_Vigencia";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        sqlCmd.Parameters.Add("@Opcion", SqlDbType.Int).Value = Opcion;
        

        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;


    }





    public DataSet GCredPucMaxMinParcial(int Anio, int IdCuenta, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_PucMaxMinParcialGCred";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;
        sqlCmd.Parameters.Add("@IdCuenta", SqlDbType.Int).Value = IdCuenta;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);


        return ds;

    }

    public DataSet GCredProspectarParcial(int Anio, string CadIndicadores, string CadCiudad, Boolean PorNit, int IdUsuario, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_ProspectarParcialesGCred";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.NVarChar).Value = Anio;
        sqlCmd.Parameters.Add("@CadIndicadores", SqlDbType.NVarChar).Value = CadIndicadores;
        sqlCmd.Parameters.Add("@CadCiudad", SqlDbType.NVarChar).Value = CadCiudad;
        sqlCmd.Parameters.Add("@PorNit", SqlDbType.Bit).Value = PorNit;
        sqlCmd.Parameters.Add("@IdUsuario", SqlDbType.NVarChar).Value = IdUsuario;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);
        return ds;
    }

    public DataSet GCredProspectarReciente(string CadIndicadores, string CadCiudad, Boolean PorNit, int IdUsuario)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_ProspectarRecienteGCred";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@CadIndicadores", SqlDbType.NVarChar).Value = CadIndicadores;
        sqlCmd.Parameters.Add("@CadCiudad", SqlDbType.NVarChar).Value = CadCiudad;
        sqlCmd.Parameters.Add("@PorNit", SqlDbType.Bit).Value = PorNit;
        sqlCmd.Parameters.Add("@IdUsuario", SqlDbType.NVarChar).Value = IdUsuario;

        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;


    }

    public DataSet ReportesMac()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_ReportesMac";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    public DataSet ReportesMacDatos(int IdReporte)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_ReportesMacDatos";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdReporte", SqlDbType.Int).Value = IdReporte;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    public DataSet ReportesCampos(int IdReporte)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_ReportesCampos";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdReporte", SqlDbType.Int).Value = IdReporte;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    public DataSet ReporSector()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_ReporSectores";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    
    public DataSet ReporValores(int anio, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_ReporValores";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = anio;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    public DataSet ReporPromedioSector(int anio, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_ReporPromedioPuc";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = anio;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);


        return ds;
    }

    public DataSet ReportesCiiu()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_ReporCiiu";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    public DataSet ReportesPuc()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_ReporPuc";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    public DataSet ReportesSectorCiiu()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_ReporSectorCiiu";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    public DataSet ReportesEmpresaSector()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_ReporEmpresaSector";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

   

    public DataSet ReporValoresActual(int anio, int Idusuario, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_ReporValoresActual";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = anio;
        sqlCmd.Parameters.Add("@Idusuario", SqlDbType.Int).Value = Idusuario;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    public DataSet ReportesEmpresaSectorActual(int @Idusuario)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_ReporEmpresaSectorActual";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Idusuario", SqlDbType.Int).Value = @Idusuario;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    public DataSet ReporValoresParcial(int anio, int @Idusuario, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_ReporValoresParciales";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = anio;
        sqlCmd.Parameters.Add("@Idusuario", SqlDbType.Int).Value = @Idusuario;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;

        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    public DataSet ReporEmpresaConBalance(int anio, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_ReporEmpresaConBalance";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = anio;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);


        return ds;

    }

    public DataSet ReporValoresXNit(int anio)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_ReporValoresNit";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = anio;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet PestanasXPerfiles()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_PestanasCarpetaVirtual";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;


    }

    public DataSet ExistePerfilXPestana(int IdPerfil, int IdPestana, int Seleccion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_ExistePerfiXPestana";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = IdPerfil;
        sqlCmd.Parameters.Add("@IdPestana", SqlDbType.Int).Value = IdPestana;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    public void IngresaMenuPestana(int IdPerfil, int IdPestana, int Seleccion)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_MenuxPestana";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = IdPerfil;
        sqlCmd.Parameters.Add("@IdPestana", SqlDbType.Int).Value = IdPestana;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        ClsSQL.ejecutarcomandoBench(sqlCmd);


    }

    
      


    /*David Alzate 14/08/2017 - ASUNTO: Se agrega parametro datosEmpr que recibe un String para enviar al procedimiento y realice busqueda por Nit o razon social*/
    public DataSet ListaEmpresasNit(string datosEmpr, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_ListaEmpresasNit";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@datosEmpr", SqlDbType.VarChar, 255).Value = datosEmpr;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);


        return ds;
    }

    //31/05/2018

    //31/05/2018

    
   
    public void DeEstrucAdmin(string Nit, long Documento, string nombre, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "De_EstrucAdmin";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Documento", SqlDbType.NVarChar).Value = Documento;
        sqlCmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

   

    public DataSet SeCCualitativaXEmp(string Nit, int TipoEncuesta, int Seleccion, string FechaI, string FechaF, int Estado, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_CCualitativaXEmp";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@TipoEncuesta", SqlDbType.Int).Value = TipoEncuesta;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@FechaI", SqlDbType.Date).Value = FechaI;
        sqlCmd.Parameters.Add("@FechaF", SqlDbType.Date).Value = FechaF;
        sqlCmd.Parameters.Add("@Estado", SqlDbType.Int).Value = Estado;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet SeLogErrores()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_LogErrores";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet EstadoUsuario()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_EstadoUsuario";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }


    public DataSet BencBalancePyGCuentaAnualizada(string Nit, int IdPais, int IdDivisa)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_BalanceCuentasAnualizadas";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.VarChar).Value = IdPais;
        sqlCmd.Parameters.Add("@IdDivisa", SqlDbType.VarChar).Value = IdDivisa;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }


    public DataSet CredCalCartera(Boolean Auxiliar)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_CalCartera";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Auxiliar", SqlDbType.Bit).Value = Auxiliar;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }


    public DataSet CredIndicadorParcialMaxMinPro(int Anio, int IdIndicador)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_IndicadorParcialMaxMinPro";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;
        sqlCmd.Parameters.Add("@IdIndicador", SqlDbType.Int).Value = IdIndicador;
        //  sqlCmd.Parameters.Add("@IdSector", SqlDbType.Int).Value = IdSector;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet SeParametrosR(int Seleccion, string parametroR)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_ParametrosR";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@ParametroR", SqlDbType.NVarChar).Value = parametroR;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public void InParametrosR(string paramR, decimal paramPiso, decimal paramTecho)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "In_ParametrosR";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@ParamR", SqlDbType.NVarChar).Value = paramR;
        sqlCmd.Parameters.Add("@ParamPiso", SqlDbType.Decimal).Value = paramPiso;
        sqlCmd.Parameters.Add("@ParamTecho", SqlDbType.Decimal).Value = paramTecho;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void UpParametrosR(string rAnterior, string paramR, decimal paramPiso, decimal paramTecho)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "Up_ParametrosR";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@RAnterior", SqlDbType.NVarChar).Value = rAnterior;
        sqlCmd.Parameters.Add("@ParamR", SqlDbType.NVarChar).Value = paramR;
        sqlCmd.Parameters.Add("@ParamPiso", SqlDbType.Decimal).Value = paramPiso;
        sqlCmd.Parameters.Add("@ParamTecho", SqlDbType.Decimal).Value = paramTecho;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void DeParametrosR(string paramR)
    {
        SqlCommand sqlCmd = new SqlCommand();


        sqlCmd.CommandText = "De_ParametrosR";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@ParamR", SqlDbType.NVarChar).Value = paramR;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }


    public DataSet CredCalFinal(string Nit, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_CalificacionFinal";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }


    public DataSet BencBuscarUsuario(string buscar)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_BuscarUsuario";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Buscar", SqlDbType.VarChar).Value = buscar;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }
      



    public DataSet RyNivel()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_CFinalPublicaTxt";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

      

    public DataSet BalancesTxt(int Anio, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_BalancesTXT";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;

        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }


    public DataSet IndicadoresTxt(int Anio)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_IndicadoresTXT";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }



    public DataSet BalancesParcialesTxt(int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_BalancesParcialesTXT";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }


    public DataSet IndicadoresParcialesTxt()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_IndicadoresParcialesTXT";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }


    public void InParametrosGE(int IdParametroGE, string ParametrosGE, Boolean Estado, int Seleccion)
    {
        SqlCommand sqlCmd = new SqlCommand();

        sqlCmd.CommandText = "In_ParametrosGE";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdParametroGE", SqlDbType.Int).Value = IdParametroGE;
        sqlCmd.Parameters.Add("@ParametrosGE", SqlDbType.VarChar).Value = ParametrosGE;
        sqlCmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;
        sqlCmd.Parameters.Add("@seleccion", SqlDbType.Int).Value = Seleccion;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public void InSectorLimiteGE(int IdSectorGE, string SectorGE, Boolean Estado, int Seleccion)
    {
        SqlCommand sqlCmd = new SqlCommand();

        sqlCmd.CommandText = "In_SectorLimiteGE";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdSectorGE", SqlDbType.Int).Value = IdSectorGE;
        sqlCmd.Parameters.Add("@SectorGE", SqlDbType.VarChar).Value = SectorGE;
        sqlCmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;
        sqlCmd.Parameters.Add("@seleccion", SqlDbType.Int).Value = Seleccion;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

    }

    public DataSet CredParametrosGE(int IdParametroGE, int Seleccion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_ParametrosGE";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdParametroGE", SqlDbType.Int).Value = IdParametroGE;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }


    public DataSet CredSectorLimiteGE(int IdSectorGE, int Seleccion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_SectorLimiteGE";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdSectorGE", SqlDbType.Int).Value = IdSectorGE;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    public int CreValidaGruposEconomicos(int Seleccion, string GEmpresarial)
    {
        SqlCommand sqlCmd = new SqlCommand();

        int Valida;

        sqlCmd.CommandText = "Se_ValidaGruposEconomicos";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@GEmpresarial", SqlDbType.VarChar).Value = GEmpresarial;
        sqlCmd.Parameters.Add("@Valor", SqlDbType.Int).Direction = ParameterDirection.Output;

        ClsSQL.ejecutarcomandoBench(sqlCmd);

        Valida = int.Parse(sqlCmd.Parameters["@Valor"].Value.ToString());

        return Valida;
    }


    public DataSet SeOpcionesNivRiesgoParam(Int32 Seleccion, Int32 Opcion, Int32 Id)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_OpcionesNivRiesgoParam";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@Opcion", SqlDbType.Int).Value = Opcion;
        sqlCmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public void UpOpcionesNivRiesgo(Int32 Seleccion, Int32 Id, String OpNivelRiesgo, Boolean Activo)
    {
        SqlCommand sqlCmd = new SqlCommand();

        sqlCmd.CommandText = "Up_OpcionesNivRiesgo";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Decimal).Value = Seleccion;
        sqlCmd.Parameters.Add("@Id", SqlDbType.Decimal).Value = Id;
        sqlCmd.Parameters.Add("@OpNivelRiesgo", SqlDbType.VarChar).Value = OpNivelRiesgo;
        sqlCmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = Activo;

        ClsSQL.ejecutarcomandoBench(sqlCmd);
    }

    public DataSet UsuarioPais(int IdUsuario)
    {

        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();
               
        sqlCmd.CommandText = "Se_UsuarioPais";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);


        return ds;
    }

    public DataSet InUsuarioPais(int IdUsuario, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "In_PaisesxUsuario";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);
        return ds;
    }


    public DataSet PaisesLista()
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_PaisesLista";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);
        return ds;
    }

    public DataSet DivisaLista(int IdDivisa, int Seleccion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_Divisas";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdDivisa", SqlDbType.Int).Value = IdDivisa;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);
        return ds;
    }

    public int SeExisteUsuario(string Usuario, string Identificacion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        int Existe = 0;
        sqlCmd.CommandText = "Se_ExisteUsuario";
        sqlCmd.CommandType = CommandType.StoredProcedure;

        sqlCmd.Parameters.Add("@Usuario", SqlDbType.NVarChar).Value = Usuario;
        sqlCmd.Parameters.Add("@Identificacion", SqlDbType.NVarChar).Value = Identificacion;
        sqlCmd.Parameters.Add("@Existe", SqlDbType.Int).Direction = ParameterDirection.Output;
        ClsSQL.ejecutarcomandoBench(sqlCmd);
        Existe = int.Parse(sqlCmd.Parameters["@Existe"].Value.ToString());

        return Existe;
    }

    public Boolean ExisteConversion(int IdPais, int Anio, int Divisa)
    {
        SqlCommand sqlCmd = new SqlCommand();
        Boolean IdExiste = false;

               
        sqlCmd.CommandText = "Se_ConversionExiste";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;
        sqlCmd.Parameters.Add("@Divisa", SqlDbType.Int).Value = Divisa;
        sqlCmd.Parameters.Add("@existe", SqlDbType.Bit).Direction = ParameterDirection.Output;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

        IdExiste = Boolean.Parse(sqlCmd.Parameters["@existe"].Value.ToString());

        return IdExiste;

    }

    public string ExisteConversionNit(int IdPais, string Nit, int Divisa)
    {
        SqlCommand sqlCmd = new SqlCommand();
        string Cadena;


        sqlCmd.CommandText = "Se_ConversionXNit";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Divisa", SqlDbType.Int).Value = Divisa;
        sqlCmd.Parameters.Add("@Cadena", SqlDbType.NVarChar, 200).Direction = ParameterDirection.Output;
        ClsSQL.ejecutarcomandoBench(sqlCmd);

        Cadena = sqlCmd.Parameters["@Cadena"].Value.ToString();

        return Cadena;

    }


    public DataSet GCredAuditoriaModeloPlantillaXDel(string Nit, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_AuditoriaCargueXDel";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);
        return ds;


    }


    public DataSet DatosPaisCliente(int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_DatosPaisCliente";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Id", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }


    public void Up_DatosPaisCliente(int Id, decimal MesesCualitativa, decimal Reest, decimal Ley1116, decimal ListaClinton, decimal ValorCastigo,
        decimal pisoReest, decimal pisoLey1116, decimal pisoListaClinton, decimal pisoCastigo, decimal Disolucion, decimal EFDesactualizados, decimal PisoDisolucion)
    {
        SqlCommand sqlCmd = new SqlCommand();

        sqlCmd.CommandText = "Up_DatosPaisCliente";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
        sqlCmd.Parameters.Add("@MesesCualitativa", SqlDbType.Money).Value = MesesCualitativa;
        sqlCmd.Parameters.Add("@Reest", SqlDbType.Money).Value = Reest;
        sqlCmd.Parameters.Add("@Ley1116", SqlDbType.Money).Value = Ley1116;
        sqlCmd.Parameters.Add("@ListClinton", SqlDbType.Money).Value = ListaClinton;
        sqlCmd.Parameters.Add("@ValorCastigo", SqlDbType.Money).Value = ValorCastigo;
        sqlCmd.Parameters.Add("@PisoReest", SqlDbType.Money).Value = pisoReest;
        sqlCmd.Parameters.Add("@PisoLey1116", SqlDbType.Money).Value = pisoLey1116;
        sqlCmd.Parameters.Add("@PisoListaClinton", SqlDbType.Money).Value = pisoListaClinton;
        sqlCmd.Parameters.Add("@PisoCastigo", SqlDbType.Money).Value = pisoCastigo;
        sqlCmd.Parameters.Add("@Disolucion", SqlDbType.Money).Value = Disolucion;
        sqlCmd.Parameters.Add("@EFDesactualizados", SqlDbType.Money).Value = EFDesactualizados;
        sqlCmd.Parameters.Add("@PisoDisolucion", SqlDbType.Money).Value = PisoDisolucion;

        ClsSQL.ejecutarcomandoBench(sqlCmd);
    }

    public void DeParametrosDivisa(int IdDivisa)
    {
        SqlCommand sqlCmd = new SqlCommand();

        sqlCmd.CommandText = "De_ParametrosDivisa";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdDivisa", SqlDbType.Int).Value = IdDivisa;
        ClsSQL.ejecutarcomandoBench(sqlCmd);
    }

    public void InParametrosDivisa(int IdDivisa, String CodDivisa, int CodUiaf, String DescDivisa)
    {
        SqlCommand sqlCmd = new SqlCommand();

        sqlCmd.CommandText = "In_ParametrosDivisa";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdDivisa", SqlDbType.Int).Value = IdDivisa;
        sqlCmd.Parameters.Add("@CodDivisa", SqlDbType.NVarChar).Value = CodDivisa;
        sqlCmd.Parameters.Add("@CodUiaf", SqlDbType.Int).Value = CodUiaf;
        sqlCmd.Parameters.Add("@DescDivisa", SqlDbType.NVarChar).Value = DescDivisa;
        ClsSQL.ejecutarcomandoBench(sqlCmd);
    }

    public void UpParametrosDivisa(int IdDivisa, String CodDivisa, int CodUiaf, String DescDivisa, int IdDivisaAnt)
    {
        SqlCommand sqlCmd = new SqlCommand();

        sqlCmd.CommandText = "Up_ParametrosDivisa";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdDivisa", SqlDbType.Int).Value = IdDivisa;
        sqlCmd.Parameters.Add("@CodDivisa", SqlDbType.NVarChar).Value = CodDivisa;
        sqlCmd.Parameters.Add("@CodUiaf", SqlDbType.Int).Value = CodUiaf;
        sqlCmd.Parameters.Add("@DescDivisa", SqlDbType.NVarChar).Value = DescDivisa;
        sqlCmd.Parameters.Add("@IdDivisaAnt", SqlDbType.Int).Value = IdDivisaAnt;
        ClsSQL.ejecutarcomandoBench(sqlCmd);
    }

    public DataSet SeDivisasXAnio(int IdPais, int Anio, int IdDivisa, int Seleccion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_DivisasXAnio";
        sqlCmd.CommandType = CommandType.StoredProcedure;

        sqlCmd.Parameters.Add("@IdPais", SqlDbType.NVarChar).Value = IdPais;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;
        sqlCmd.Parameters.Add("@IdDivisa", SqlDbType.Int).Value = IdDivisa;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;

        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet UpConversionDivisasxPais(int IdPais, int Anio, int IdDivisa, decimal Conversion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Up_ConversionDivisasxPais";
        sqlCmd.CommandType = CommandType.StoredProcedure;

        sqlCmd.Parameters.Add("@IdPais", SqlDbType.NVarChar).Value = IdPais;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;
        sqlCmd.Parameters.Add("@IdDivisa", SqlDbType.Int).Value = IdDivisa;
        sqlCmd.Parameters.Add("@Conversion", SqlDbType.Decimal).Value = Conversion;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet DeConvDivisasxAnioPais(int IdPais, int Anio, int IdDivisa)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "De_ConvDivisasxAnioPais";
        sqlCmd.CommandType = CommandType.StoredProcedure;

        sqlCmd.Parameters.Add("@IdPais", SqlDbType.NVarChar).Value = IdPais;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;
        sqlCmd.Parameters.Add("@IdDivisa", SqlDbType.Int).Value = IdDivisa;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }


    public DataSet InfConvDivisasxPais(int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_InfoConversion";
        sqlCmd.CommandType = CommandType.StoredProcedure;

        sqlCmd.Parameters.Add("@IdPais", SqlDbType.NVarChar).Value = IdPais;

        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet SeConsecutivoEmp(int Seleccion, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_ConsecutivoEmp";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.Int).Value = Seleccion;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;

    }

    public DataSet BencBalanceAuditados(int Seleccion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_InfoAuditada";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Seleccion", SqlDbType.VarChar).Value = Seleccion;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);
        return ds;
    }


    public DataSet CredNitAnioAuditado(string Nit, int IdPais, int Anio)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();

        sqlCmd.CommandText = "Se_NitAnioAuditado";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;

        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;
    }

    public DataSet GCredAniosPeriodos(int IdPais, int Opcion)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();


        sqlCmd.CommandText = "Se_AniosPeriodos";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        sqlCmd.Parameters.Add("@Opcion", SqlDbType.Int).Value = Opcion;


        ds = ClsSQL.CreateDataSetBench(sqlCmd);

        return ds;


    }

    public Boolean CredSeVerificarExistenciaBalances(string Nit, int Anio, int IdPais)
    {
        SqlCommand sqlCmd = new SqlCommand();
        Boolean Resultado = false;

        sqlCmd.CommandText = "Se_VerificarExistenciaBalances";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.NVarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        sqlCmd.Parameters.Add("@Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
        ClsSQL.ejecutarcomandoBench(sqlCmd);
        Resultado = Boolean.Parse(sqlCmd.Parameters["@Resultado"].Value.ToString());

        return Resultado;

    }

    public DataSet CredValidarPeriodo(int IdPais, string Nit, int Periodo)
    {
        SqlCommand sqlCmd = new SqlCommand();
        DataSet ds = new DataSet();
        sqlCmd.CommandText = "Se_ValidarNitAnio";
        sqlCmd.CommandType = CommandType.StoredProcedure;
        sqlCmd.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
        sqlCmd.Parameters.Add("@Periodo", SqlDbType.Int).Value = Periodo;
        sqlCmd.Parameters.Add("@IdPais", SqlDbType.Int).Value = IdPais;
        ds = ClsSQL.CreateDataSetBench(sqlCmd);
        return ds;
    }

}
