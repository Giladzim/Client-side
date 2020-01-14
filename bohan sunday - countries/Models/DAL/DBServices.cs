using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using WebApplication1.Models;


public class DBServices
{
    public SqlDataAdapter da;
    public DataTable dt;

    public DBServices()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public SqlConnection connect(String conString)
    {

        // read the connection string from the configuration file
        string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }
    private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

        return cmd;
    }


    public Country getCountryByName(string name)
    {
        Country c = new Country();
        SqlConnection con = null;

        try
        {
            con = connect("countriesDBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM Countries where cname = '" + name + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            if (dr.Read())
            {
                c.Id = Convert.ToInt32(dr["id"]);
                c.Name = (string)dr["cname"];
                c.Lang = (string)dr["lang"];
                c.Continent = (string)dr["continent"];
                return c;
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }

    }

    

        public List<Country> getCountryByCont(string cont)
    {
        List <Country> countriesList = new List<Country>();
        SqlConnection con = null;

        try
        {
            con = connect("countriesDBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM Countries where continent = '" + cont + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {
                Country c = new Country();
                c.Id = Convert.ToInt32(dr["id"]);
                c.Name = (string)dr["cname"];
                c.Lang = (string)dr["lang"];
                c.Continent = (string)dr["continent"];
                countriesList.Add(c);
            }
            return countriesList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }

    }






    public void updateCountries(Country c)
    {

        SqlConnection con = null;

        try
        {
            con = connect("countriesDBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            string selectSTR = "UPDATE Countries SET lang='" + c.Lang + "', continent='" + c.Continent + "' WHERE cname='" + c.Name + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            // get a reader

        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }

    }


}
