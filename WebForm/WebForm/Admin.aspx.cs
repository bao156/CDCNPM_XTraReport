using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm
{
   
    public partial class Admin : System.Web.UI.Page
    {
        public static string databases = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Admin.databases = Request.QueryString["name"];
        }


        private static List<string> GetTableDatabase(string database)
        {
            List<String> itemlist = new List<string>();
            if (KetNoi.Connect(database) == 0) return itemlist;

            string queryString = "select name from sys.tables";
            SqlDataReader dataReader = KetNoi.ExecSqlDataReader(queryString);
            while (dataReader.Read())
            {
                string Output = "" + dataReader.GetValue(0);
                itemlist.Add(Output);
            }

            return itemlist;

        }

        public static List<String> getListTable()
        {
            return GetTableDatabase(Admin.databases);
        }


    }
}