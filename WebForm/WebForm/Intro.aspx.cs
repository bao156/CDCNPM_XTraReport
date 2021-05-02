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
        public static string test = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
         }
        protected void btnStart_Click(object sender, EventArgs e)
        {
            KetNoi.listTable = new HashSet<string>();
            KetNoi.ObjectQueryList = new HashSet<ObjectQuery>();
            KetNoi.database = cbNameDatabase.SelectedValue;
            Response.Redirect("AdminTableDesignView.aspx?&size=0");
        }
      
 

    }

   
}