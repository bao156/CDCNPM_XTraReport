using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.LookAndFeel;

namespace WebForm
{
    public partial class SQLView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Box2.Attributes["color"] = "#003300";
            Box2.Text = KetNoi.GetQueryText();
            Master.dropDownListProperty.SelectedIndexChanged += new EventHandler(DropDownList1_SelectedIndexChanged);

        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            if (getHidden2.Value != "")
            {
                string textChange = getHidden2.Value;
                KetNoi.queryString = textChange.Replace("\r\n", " ");
            }
            else
            {
                KetNoi.queryString = Box2.Text.Replace("\r\n", " ");
            }


            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "openModal", "window.open('DocumentReport.aspx?' ,'_blank');", true);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = Master.dropDownListProperty.SelectedValue.ToString();
            if (text.Equals("2"))
            {
                //    //Response.Write("<script>alert('b" + text + "')</script>");
                //    //// DropDownList1.SelectedValue = "Datasheet View";
                Response.Redirect("DatasheetView.aspx?size=");
            }
            else if (text.Equals("1"))
            {
                if (KetNoi.ObjectQueryList.Count != 0)
                    Response.Redirect("AdminTableDesignView.aspx?size=" + KetNoi.url + "&load=0");
                else Response.Redirect("AdminTableDesignView.aspx?size=0");
            }
            else
            {
                Response.Redirect("SQLView.aspx");
            }


        }


    }
}