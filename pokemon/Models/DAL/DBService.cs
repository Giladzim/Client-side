
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;
using WebApplication1.Models;

public class DBService
{
    public SqlDataAdapter da;
    public DataTable dt;

    public DBService()
    {

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

    

        public int insert(Pokemon poke)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("pokemonDBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = BuildInsertCommand(poke);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //--------------------------------------------------------------------
    // Build the Insert command String
    //--------------------------------------------------------------------
    private String BuildInsertCommand(Pokemon poke)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', '{1}' ,{2}, {3})", poke.Name, poke.Image, Convert.ToInt32(poke.Hp), Convert.ToInt32(poke.Attack));
        String prefix = "INSERT INTO pokemon_2020 " + "(pName, Image, Hp ,Attack)";
        command = prefix + sb.ToString();

        return command;
    }

    public List<Pokemon> getPokemons()
    {
        List<Pokemon> pokesList = new List<Pokemon>();
        SqlConnection con = null;

        try
        {
            con = connect("pokemonDBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "SELECT * FROM pokemon_2020";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                Pokemon p = new Pokemon();

                p.Id = Convert.ToInt32(dr["Id"]);
                p.Name = (string)dr["pName"];
                p.Hp = Convert.ToInt32(dr["Hp"]);
                p.Attack = Convert.ToInt32(dr["Attack"]);
                p.Image = (string)dr["Image"];
                pokesList.Add(p);
            }

            return pokesList;
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

    

         public void updatePokemon(Pokemon poke)
    {
        
        SqlConnection con = null;

        try
        {
            con = connect("pokemonDBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            string selectSTR = "UPDATE pokemon_2020 SET Hp='" + poke.Hp + "' WHERE id='" + poke.Id+"'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

           
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
