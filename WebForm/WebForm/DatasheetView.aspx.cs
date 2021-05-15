using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm
{
    public partial class DatasheetView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string test = KetNoi.GetQueryText();
            Master.dropDownListProperty.SelectedIndexChanged += new EventHandler(DropDownList1_SelectedIndexChanged);
            createTableData();
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "openModal", "window.open('DocumentReport.aspx?' ,'_blank');", true);

        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = Master.dropDownListProperty.SelectedValue.ToString();
            if (text.Equals("2"))
            {
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

        public void createTableData()
        {
            TableHolder.Controls.Clear();
            Table table = new Table();
            table.Width = 1300;
            //Chạy Thuộc tính
            TableRow rowAttribute = new TableRow();
            foreach (ObjectQuery ob in KetNoi.ObjectQueryList)
            {
                TableCell cellAttributeTitle = new TableCell();
                cellAttributeTitle.Style["color"] = "white";
                cellAttributeTitle.Style["background-color"] = "#344a5b";
                cellAttributeTitle.Style["font-weight"] = "bold";
                cellAttributeTitle.Style["width"] = "100px";
                cellAttributeTitle.Style["text-align"] = "center";
                cellAttributeTitle.Style["height"] = "50px";
                cellAttributeTitle.Style["border"] = "#cccccc 8px solid";
                cellAttributeTitle.Style["font-family"] = "Arial,Helvetica, sans-serif";
                cellAttributeTitle.Text = ob.attributeName;
                rowAttribute.Cells.Add(cellAttributeTitle);
            }
            table.Rows.Add(rowAttribute);



            DataTable dataTable = KetNoi.QueryDataTable();


            //Tạo các cột theo data
            foreach (DataRow row in dataTable.Rows)
            {
                TableRow rowData = new TableRow();
                foreach (ObjectQuery ob in KetNoi.ObjectQueryList)
                {
                    TableCell cellAttributeTitle = new TableCell();
                    string attribute = row[ob.attributeName].ToString();
                    cellAttributeTitle.Style["color"] = "#404040";
                    cellAttributeTitle.Style["background-color"] = "white";
                    cellAttributeTitle.Style["font-weight"] = "bold";
                    cellAttributeTitle.Style["width"] = "100px";
                    cellAttributeTitle.Style["text-align"] = "center";
                    cellAttributeTitle.Style["height"] = "50px";
                    cellAttributeTitle.Style["border"] = "#cccccc 8px solid";
                    cellAttributeTitle.Style["font-family"] = "Arial,Helvetica, sans-serif";
                    cellAttributeTitle.Text = attribute;
                    rowData.Cells.Add(cellAttributeTitle);
                }


                table.Rows.Add(rowData);
            }
            TableHolder.Controls.Add(table);
        }
    }

}