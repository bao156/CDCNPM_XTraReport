using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        public static string databases = "";
        public static KetNoi connect;
        protected void Page_Load(object sender, EventArgs e)
        {
            WebForm3.databases = Request.QueryString["name"];
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           Response.Write(CreateCommand());
        }
        private static string CreateCommand()
        {
            string Output = "";
            string queryString = "select Password From Users";
            string connectionString= @"Data Source=DESKTOP-8M2NJ75;Initial Catalog=Java5 ;User ID=sa;Password=123456";
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataReader dataReader;
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Output = Output + dataReader.GetValue(0) + "</br>";
                }

                return Output;
               
            }
        }

        private static List<string> GetTableDatabase(string database)
        {
            List<String> itemlist = new List<string>();
            if (KetNoi.Connect(database) == 0) return itemlist ;
           
            string queryString = "select name from sys.tables";
            SqlDataReader dataReader= KetNoi.ExecSqlDataReader(queryString);
            while (dataReader.Read())
             {
                    string Output = ""+dataReader.GetValue(0);
                    itemlist.Add(Output);
             }

                return itemlist;

         }

        public static List<String> getListTable()
        {
            return GetTableDatabase(WebForm3.databases);
        }
        


    }
}