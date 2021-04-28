using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm
{
    public partial class Intro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //    string chuoistring = "server=DESKTOP-8M2NJ75;database=Java5;integrated security=true";
            //    SqlConnection connect = new SqlConnection(chuoistring);
            //    connect.Open();
            //    string sql = "select name from sys.databases";
            //    SqlCommand command = new SqlCommand(sql, connect);
            //    SqlDataReader reader = command.ExecuteReader();
            //    connect.Close();
            
         }
        protected void btnStart_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("AdminTableDesignView.aspx?name=" + cbNameDatabase.SelectedValue);
        }
            //string conStr = "Data Source=DESKTOP-8M2NJ75;Initial Catalog=Java5;User ID=sa;Password=123456";

            //SqlDataAdapter adapter = new SqlDataAdapter("select name from sys.databases", new SqlConnection(conStr));
            //DataTable dt = new System.Data.DataTable();
            //adapter.Fill(dt);

            //cbDatabase = "IL";

            //comboBox1.DataSource = dt;

        }

   
}