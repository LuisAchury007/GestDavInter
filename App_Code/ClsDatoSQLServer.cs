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
using System.Data.Sql;
using System.Data.SqlClient;


/// <summary>
/// Descripción breve de ClsDatoSQLServer
/// </summary>
public class ClsDatoSQLServer
{


    public DataSet CreateDataSetBench(SqlCommand sqlCmd)
    {

        SqlConnection ConComercial = new SqlConnection(ConfigurationManager.ConnectionStrings["StrCredito"].ConnectionString);

        ConComercial.Open();
        sqlCmd.Connection = ConComercial;

        //Se le define el tiempo de espera en segundos para la consulta,
        //el valor default es 30 segundos.
        //Si una consulta es muy compleja podria ser que dure mucho en retornar los datos,
        //por eso le definimos el tiempo de respuesta en bastantes segundos
        sqlCmd.CommandTimeout = 3600;
     

        //SqlAdapter utiliza el SqlCommand para llenar el Dataset
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = sqlCmd;
        //Se llena el dataset
        DataSet ds = new DataSet();

        sda.Fill(ds);
        ConComercial.Close();
        return ds;

    }

    public void ejecutarcomandoBench(SqlCommand sqlCmd)
    {
        SqlConnection ConComercial = new SqlConnection(ConfigurationManager.ConnectionStrings["StrCredito"].ConnectionString);

        sqlCmd.Connection = ConComercial;
        sqlCmd.CommandTimeout = 3600;

        ConComercial.Open();
        sqlCmd.ExecuteNonQuery();
        ConComercial.Close();
    }

    public SqlDataAdapter CreateSqlDataAdapter(SqlCommand sqlCmd)
    {

        SqlConnection ConComercial = new SqlConnection(ConfigurationManager.ConnectionStrings["StrCredito"].ConnectionString);

        ConComercial.Open();
        sqlCmd.Connection = ConComercial;

        //Se le define el tiempo de espera en segundos para la consulta,
        //el valor default es 30 segundos.
        //Si una consulta es muy compleja podria ser que dure mucho en retornar los datos,
        //por eso le definimos el tiempo de respuesta en bastantes segundos
        sqlCmd.CommandTimeout = 3600;


        //SqlAdapter utiliza el SqlCommand para llenar el Dataset
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = sqlCmd;
        //Se llena el dataset
        //DataSet ds = new DataSet();

        //sda.Fill(ds);
        ConComercial.Close();
        return sda;

    }
}
