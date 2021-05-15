using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm
{
    public partial class KeyPressText : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnStart_Click(object sender, EventArgs e)
        {
            string a = txtDistance.Value;
            string[] subs = a.Split(new string[] { "_____" }, StringSplitOptions.None);
            List<string> list = new List<string>(subs);
            list.RemoveAt(list.Count - 1);
            Response.Redirect("Test.aspx?size=" + a);
        }

    }
}