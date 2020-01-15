using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;
using teson.Models;

/// <summary>
/// DBServices is a class created by me to provides some DataBase Services
/// </summary>
public class DBservices
{
    public SqlDataAdapter da;
    public DataTable dt;
  //  public DataTable dtt;
  //  public DataTable dttt;

    public DBservices()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //--------------------------------------------------------------------------------------------------
    // This method creates a connection to the database according to the connectionString name in the web.config 
    //--------------------------------------------------------------------------------------------------
    public SqlConnection connect(String conString)
    {

        // read the connection string from the configuration file
        string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }

    //public int insert(Location loc)
    //{
    //    SqlConnection con;
    //    SqlCommand cmd;

    //    try
    //    {
    //        con = connect("orsegal");
    //    }
    //    catch (Exception ex)
    //    {
    //        throw (ex);
    //    }
    //    String cStr = BuildInsertCommand(loc);
    //    // cmd = CreatCommmand(cStr, con);
    //    cmd = CreateCommand(cStr, con);

    //    try
    //    {
    //        int numEffected = cmd.ExecuteNonQuery();
    //        return numEffected;
    //    }
    //    finally
    //    {
    //        if (con != null)
    //            con.Close();
    //    }
    //}
   
    //public int UpdateFavor(string id)
    //{
    //    SqlConnection con;
    //    SqlCommand cmd;

    //    try
    //    {

    //        con = connect("orsegal");
    //    }
    //    catch (Exception ex)
    //    {
    //        throw (ex);
    //    }
    //    String cStr = BuildInsertCommand(id);
    //    // cmd = CreatCommmand(cStr, con);
    //    cmd = CreateCommand(cStr, con);

    //    try
    //    {
    //        int numEffected = cmd.ExecuteNonQuery();
    //        return numEffected;
    //    }
    //    finally
    //    {
    //        if (con != null)
    //            con.Close();
    //    }
    //}
    //private String BuildInsertCommand(string id)
    //{
    //    String command;

    //    StringBuilder sb = new StringBuilder();
    //    int number = getFavor(id);


    //    String prefix1 = "UPDATE myFlights_2020 SET FavorCounter="+number+"+1 WHERE ID='"+id+"'";


    //    command = prefix1;

    //    return command;
    //}



    ////---------------------------------------------------------------------------------
    //// Create the SqlCommand
    ////---------------------------------------------------------------------------------
    ///
    public SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

        return cmd;
    }

    public int insert(Order o)
    {
        SqlConnection con = null;
        SqlCommand cmd;

        try
        {
            con = connect("orsegal");
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        string cStr = "";
        
            cStr = "INSERT INTO ORDERS(name,address,phonenumber,selfPickup,pizzaId) VALUES('" + o.Name + "','" + o.Address + "'," + Convert.ToInt32(o.Phonenumber) + ",'"+o.SelfPickup+"',"+Convert.ToInt16(o.PizzaId)+")";
        

        cmd = CreateCommand(cStr, con);

        try
        {
            int numEffected = cmd.ExecuteNonQuery();
            return numEffected;
        }
        finally
        {
            if (con != null)
                con.Close();
        }

    }

    public List<Order> getOrders()

    {
        List<Order> orderList = new List<Order>();
        SqlConnection con = null;
        try
        {
            con = connect("orsegal");
            string selectSTR = "SELECT * FROM Orders";
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                Order o = new Order();

                o.Id= Convert.ToInt16(dr["id"]);
                o.Name= Convert.ToString(dr["name"]);
                o.Address= Convert.ToString(dr["address"]);
                o.Phonenumber = Convert.ToString(dr["phonenumber"]);
                o.SelfPickup = Convert.ToBoolean(dr["selfPickup"]);
                o.PizzaId= Convert.ToInt16(dr["pizzaId"]);
                orderList.Add(o);
            }

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }

        return orderList;

    }

    public List<Pizza> GetPizza()
    {
        List<Pizza> pizzaList = new List<Pizza>();
        SqlConnection con = null;
        try
        {
            con = connect("orsegal");
            string selectSTR = "SELECT * FROM Pizza";
                    SqlCommand cmd = new SqlCommand(selectSTR, con);
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dr.Read())
            {
                Pizza p = new Pizza();
                p.Id = Convert.ToInt16(dr["id"]);
                p.Name = Convert.ToString(dr["name"]);
                p.Kosher = Convert.ToBoolean(dr["kosher"]);
                pizzaList.Add(p);
            }
                    
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }

        return pizzaList;
    }
   //public void updateBattle(List<string> battle)
   // {
   //     int id = Convert.ToInt16( battle[0]);
   //     int newHp = Convert.ToInt16(battle[1]);

   //     SqlConnection con = null;
   //     try
   //     {
   //         con = connect("orsegal");
   //         string selectSTR = "UPDATE pokemon_2020 SET Hp=" + newHp + "WHERE Id="+id;
   //         SqlCommand cmd = new SqlCommand(selectSTR, con);
   //         SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
   //      }
   //     catch (Exception ex)
   //     {
   //         throw (ex);
   //     }
   //     finally
   //     {
   //         if (con != null)
   //         {
   //             con.Close();
   //         }

   //     }

   // }
   // //public void updateData(Country c)
    //{
    //    SqlConnection con = null;
    //    try
    //    {
    //        con = connect("orsegal");
    //        string selectSTR = "UPDATE Countries_2020 SET lang='"+c.Lang+"', continent='"+c.Continent+"' WHERE cname='"+c.Name+"'";
    //        SqlCommand cmd = new SqlCommand(selectSTR, con);
    //        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
    //        while (dr.Read())
    //        {



    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw (ex);
    //    }
    //    finally
    //    {
    //        if (con != null)
    //        {
    //            con.Close();
    //        }

    //    }



    //}
    //public List<Flight> readFlights()
    //{
    //    List<Flight> flightList = new List<Flight>();
    //    SqlConnection con = null;
    //    try
    //    {
    //        con = connect("orsegal");
    //        string selectSTR = "SELECT * FROM MyFlights_2020";
    //        SqlCommand cmd = new SqlCommand(selectSTR, con);
    //        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
    //        while (dr.Read())
    //        {   // Read till the end of the data into a row
    //            Flight f = new Flight();
    //            List<string> al = new List<string>();
    //            List<string> r = new List<string>();

    //            // al.Add((string)dr["airline1"], (string)dr["airline2"], (string)dr["airline3"]);
    //            for (int i = 1; i < 5; i++)
    //            {
    //               if(Convert.ToString(dr["AirLine" + i])!="")
    //                    al.Add(Convert.ToString( dr["AirLine" + i]));
    //            }
    //            for (int i = 1; i < 5; i++)
    //            {
    //                if (Convert.ToString(dr["Stop" + i]) != "")
    //                    r.Add(Convert.ToString(dr["Stop" + i]));
    //            }


    //            f.AirLines = al; ////(string)dr["airline1"];
    //            f.Routes = r;
    //            f.Flyfrom= (string)dr["Flyfrom"];
    //            f.Flyto = (string)dr["Flyto"];
    //            f.Price = Convert.ToInt32(dr["Price"]);
    //            f.ATime = (string)dr["ArrivalTime"];
    //            f.DTime = (string)dr["DepartureTime"];
    //            f.Counter= Convert.ToInt32(dr["FavorCounter"]);
    //            f.Id= (string)dr["ID"];
    //            flightList.Add(f);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        // write to log
    //        throw (ex);
    //    }
    //    finally
    //    {
    //        if (con != null)
    //        {
    //            con.Close();
    //        }

    //    }
    //    return flightList;
    //}





}






