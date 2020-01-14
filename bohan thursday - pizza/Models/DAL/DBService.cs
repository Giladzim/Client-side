using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;
using WebApplication1.Models;


namespace WebApplication1.Models.DAL
{
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


        public List<Pizza> getPizzas()
        {
            List<Pizza> pizzaList = new List<Pizza>();
            SqlConnection con = null;

            try
            {
                con = connect("pizzaDBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM Pizza";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    Pizza p = new Pizza();

                    p.Id= Convert.ToInt32(dr["id"]);
                    p.Name= (string)dr["name"];
                    p.Kosher = (bool)dr["kosher"];

                    pizzaList.Add(p);
                }

                return pizzaList;
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


        public int insert(Order order)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("pizzaDBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildInsertCommand(order);      // helper method to build the insert string

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
        private String BuildInsertCommand(Order order)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}' ,{2}, {3}, {4})", order.Name, order.Address, order.Phonenumber, Convert.ToInt32(order.SelfPickup), order.PizzaId);
            String prefix = "INSERT INTO Orders " + "(name, address, phonenumber, selfPickup, pizzaId) ";
            command = prefix + sb.ToString();

            return command;
        }


        
            public List<string> getOrdersPhones()
        {
            List<string> phones = new List<string>();
            SqlConnection con = null;

            try
            {
                con = connect("pizzaDBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT [phonenumber] FROM [Orders]";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    string p= (string)dr["phonenumber"];



                    phones.Add(p);
                }

                return phones;
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
}