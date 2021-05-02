using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebForm
{
    public partial class TestTable : System.Web.UI.Page
    {
        HashSet<string> list;
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
             //   HtmlTableRow row = new HtmlTableRow();
               // HtmlTableCell cell1 = new HtmlTableCell();
             //   cell1.InnerText = "cell" + i;
             //   row.Controls.Add(cell1);
             //   HtmlTableCell cell2 = new HtmlTableCell();
                Button btn = new Button();
                btn.Text = "value" + i;
                btn.Click += new EventHandler(btn_Click);
                // cell2.Controls.Add(btn);
                //  row.Controls.Add(cell2);
                //  myTable.Controls.Add(row);
                btn.Style["width"] = "150px";
                btn.Style["height"] = "50px";
                btn.Style["border-radius"] = "8px";
                btn.Style["background-color"] = "8px";
                btn.BorderColor = System.Drawing.Color.Red;
                PlaceHolder1.Controls.Add(new LiteralControl("<br />"));
                PlaceHolder1.Controls.Add(btn);
            }
           

        }

        void btn_Click(object sender, EventArgs e)
        {
            string text= (((sender) as Button).Text);
            KetNoi.listTable.Add(text);
           
            Response.Write(KetNoi.listTable.Count);
            foreach(string A in KetNoi.listTable)
            {
                Response.Write(A);
            }
            string url = "";
            int count = 1;
            foreach (string i in KetNoi.listTable)
            {
                if (count == 1)
                {
                    url = KetNoi.listTable.Count.ToString() + "&table1=" + i;
                }
                if (count != 1)
                {
                    url += "&table" + count + "=" + i;
                }
                count++;
            }
            Response.Redirect("TestTable.aspx?size=" + url);

        }

    }
}