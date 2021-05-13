using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebForm
{
    public partial class AdminLayout : System.Web.UI.MasterPage
    {

        public static HashSet<string> list = new HashSet<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            list = GetTableDatabase(KetNoi.database);

            DropDownList1.Attributes["border-radius"] = "8px";
            DropDownList1.Attributes["border-color"] = "#8a8a5c";

            foreach (string i in list)
            {
                Button btn = new Button();
                btn.Text = i;
                btn.Click += new EventHandler(btn_Click);
                btn.Style["width"] = "180px";
                btn.Style["height"] = "50px";
                btn.Style["border-radius"] = "8px";
                btn.Style["background-color"] = "#8cd9b3";
                btn.Style["border-color"] = "#40bf80";
                btn.Style["margin-left"] = "25px";
                btn.Style["color"] = "#ffffff";
                btn.Style["cursor"] = "pointer";

                PlaceHolder1.Controls.Add(new LiteralControl("<br />"));
                PlaceHolder1.Controls.Add(new LiteralControl("<br />"));
                PlaceHolder1.Controls.Add(new LiteralControl("<i class=\"fas fa-table\" style=\"font-size:23px;color:lightblue;text-shadow:2px 2px 4px #000000;\"></i>"));
                PlaceHolder1.Controls.Add(btn);
            }



        }


        protected void btn_Click(object sender, EventArgs e)
        {
            string table = ((sender) as Button).Text;
            KetNoi.listTable.Add(table);
            int count = 1;
            foreach (string i in KetNoi.listTable)
            {
                if (count == 1)
                {
                    KetNoi.url = KetNoi.listTable.Count.ToString() + "&table1=" + i;
                }
                if (count != 1)
                {
                    KetNoi.url += "&table" + count + "=" + i;
                }
                count++;
            }

            Response.Redirect("AdminTableDesignView.aspx?size=" + KetNoi.url);
        }
        public DropDownList dropDownListProperty
        {
            get
            {
                return DropDownList1;
            }
            set
            {
                DropDownList1 = value;
            }
        }
        private static HashSet<string> GetTableDatabase(string database)
        {
            HashSet<String> itemlist = new HashSet<string>();
            if (KetNoi.Connect(database) == 0) return itemlist;

            string queryString = "select name from sys.tables where is_ms_shipped=0";
            SqlDataReader dataReader = KetNoi.ExecSqlDataReader(queryString);
            while (dataReader.Read())
            {
                string Output = "" + dataReader.GetValue(0);
                itemlist.Add(Output);
            }

            return itemlist;

        }

    }
}