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
    public partial class AdminTableDesignView : System.Web.UI.Page
    {
        public static int distanceTop = -100;
        public static int distanceLeft = 280;
        public static bool checkExist;

        protected void Page_Load(object sender, EventArgs e)
        {

            int soluong = int.Parse(Request.QueryString["size"]);
            if (soluong != 0)
            {
                PlaceHolder2.Controls.Clear();
                createTableData(soluong);
            }
            Master.dropDownListProperty.SelectedIndexChanged += new EventHandler(DropDownList1_SelectedIndexChanged);
            createAttributeTable();

        }

        //EVENT
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string criterias = getHidden2.Value;
            string[] subs = criterias.Split(new string[] { "_____" }, StringSplitOptions.None);
            List<string> listCriteria = new List<string>(subs);
            Dictionary<int, string> listFilter = new Dictionary<int, string>();
            listCriteria.RemoveAt(listCriteria.Count - 1);
            //LẤY SỐ ĐẦU TIÊN RA NÈ
            //TableContent_bi
            for (int i = 0; i < listCriteria.Count; i++)
            {
                int key = Int16.Parse(listCriteria[i].Remove(0, 13)[0].ToString());
                string data = listCriteria[i].Remove(0, 14);
                if (listFilter.ContainsKey(key))
                {
                    listFilter[key] = data;
                }
                else
                {
                    listFilter.Add(key, data);
                }
            }

            listCriteria.Sort();


            //bỏ zo Object// Chuye
            foreach (int key in listFilter.Keys)
            {
                KetNoi.ObjectQueryList[key].critiria = listFilter[key];
            }


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

        protected void DropDownGroupBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            string attribute = (((sender) as DropDownList).ID);
            string table = (((sender) as DropDownList).CssClass);
            string value = (((sender) as DropDownList).Text);
            for (int i = 0; i < KetNoi.ObjectQueryList.Count; i++)
            {
                if (KetNoi.ObjectQueryList[i].attributeName == attribute && KetNoi.ObjectQueryList[i].attributeName == attribute)
                {
                    KetNoi.ObjectQueryList[i].total = value;
                }
            }

        }





        private static List<string> GetColumnTable(string database, string table)
        {
            List<String> itemlist = new List<string>();
            if (KetNoi.Connect(database) == 0) return itemlist;

            string queryString = "select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS Where TABLE_NAME = N'" + table + "'";
            SqlDataReader dataReader = KetNoi.ExecSqlDataReader(queryString);
            while (dataReader.Read())
            {
                string Output = "" + dataReader.GetValue(0);
                itemlist.Add(Output);
            }

            return itemlist;

        }
        void btn_Click(object sender, EventArgs e)
        {
            AdminTableDesignView.checkExist = false;
            string text = (((sender) as Button).Text);
            string table = (((sender) as Button).CssClass);
            ObjectQuery temp = new ObjectQuery();
            temp.attributeName = text;
            temp.tableName = table;
            //Trùng ko load page
            foreach (ObjectQuery a in KetNoi.ObjectQueryList)
            {
                if (a.attributeName == text && a.tableName == table)
                {
                    AdminTableDesignView.checkExist = true;
                }
            }
            if (AdminTableDesignView.checkExist == false) KetNoi.ObjectQueryList.Add(temp);
            PlaceHolder1.Controls.Clear();
            PlaceHolder1.PreRender += new EventHandler(PlaceHolder1_Pre);
        }


        void PlaceHolder1_Pre(object sender, EventArgs e)
        {
            PlaceHolder1.Controls.Clear();
            createAttributeTable();

        }


        public void createTableData(int soluong)
        {
            for (int i = 0; i < soluong; i++)
            {
                string name = Request.QueryString["table" + (i + 1)];
                //create a new HtmlTable object
                Table tableT = new Table();
                TableRow rowTableName = new TableRow();
                TableCell cellTableName = new TableCell();
                cellTableName.Style["color"] = "#145214";
                cellTableName.Style["font-weight"] = "bold";
                cellTableName.Style["font-family"] = "Arial,Helvetica, sans-serif";
                cellTableName.Text = name;

                rowTableName.Cells.Add(cellTableName);
                List<string> itemColumns = new List<string>();
                itemColumns = GetColumnTable(KetNoi.database, name);
                tableT.Rows.Add(rowTableName);
                foreach (string a in itemColumns)
                {
                    TableRow rowAttribute;
                    TableCell cellAttribute;
                    rowAttribute = new TableRow();
                    Button btn = new Button();
                    btn.Style["width"] = "100%";
                    btn.Style["height"] = "100%";
                    btn.Style["background-color"] = "#d9d9d9";
                    btn.Style["border-color"] = "#d0e1e1";
                    btn.Style["color"] = "#000000";
                    btn.Style["cursor"] = "pointer";
                    btn.Text = a;
                    btn.CssClass = name;
                    cellAttribute = new TableCell();
                    btn.Click += new EventHandler(btn_Click);
                    cellAttribute.Controls.Add(btn);

                    rowAttribute.Cells.Add(cellAttribute);
                    rowAttribute.Style["border"] = "none";
                    cellAttribute.Style["border"] = "none";
                    tableT.Controls.Add(rowAttribute);
                }
                ////SET thuộc tính nè
                tableT.Style["width"] = "15%";
                tableT.Style["border"] = "3px solid gray";
                if (i != 0)
                {
                    string marginT = (AdminTableDesignView.distanceTop * (i)).ToString() + "px";
                    string marginL = (AdminTableDesignView.distanceLeft * (i)).ToString() + "px";
                    tableT.Style["margin-top"] = marginT;
                    tableT.Style["margin-left"] = marginL;

                }
                cellTableName.Style["text-align"] = "center";
                cellTableName.Style["color"] = "green";
                tableT.Attributes["runat"] = "server";
                PlaceHolder2.Controls.Add(tableT);

            }
        }

        //CREATE ATTRIBUTE
        public void createAttributeTable()
        {
            PlaceHolder1.Controls.Clear();
            Table table = new Table();
            //Chạy Thuộc tính
            TableRow rowAttribute = new TableRow();
            rowAttribute.Style["height"] = "100px";
            TableCell cellAttributeTitle = new TableCell();
            cellAttributeTitle.Style["color"] = "white";
            cellAttributeTitle.Style["background-color"] = "#344a5b";
            cellAttributeTitle.Style["font-weight"] = "bold";
            cellAttributeTitle.Style["width"] = "50px";
            cellAttributeTitle.Style["font-family"] = "Arial,Helvetica, sans-serif";
            cellAttributeTitle.Text = "Field";
            rowAttribute.Cells.Add(cellAttributeTitle);


            foreach (ObjectQuery a in KetNoi.ObjectQueryList)
            {
                TableCell cellAttribute = new TableCell();
                cellAttribute.Text = a.attributeName;
                cellAttribute.Style["color"] = "#3d5c5c";
                cellAttribute.Style["text-align"] = "center";
                rowAttribute.Cells.Add(cellAttribute);

            }
            table.Rows.Add(rowAttribute);

            //Tên Table
            TableRow rowTableName = new TableRow();
            rowTableName.Style["height"] = "100px";
            TableCell cellTableNameTitle = new TableCell();
            cellTableNameTitle.Style["color"] = "white";
            cellTableNameTitle.Style["background-color"] = "#344a5b";
            cellTableNameTitle.Style["font-weight"] = "bold";
            cellTableNameTitle.Style["font-family"] = "Arial,Helvetica, sans-serif";
            cellTableNameTitle.Text = "Table";
            rowTableName.Cells.Add(cellTableNameTitle);


            foreach (ObjectQuery a in KetNoi.ObjectQueryList)
            {
                TableCell cellTableName = new TableCell();
                cellTableName.Style["text-align"] = "center";
                cellTableName.Text = a.tableName;
                rowTableName.Cells.Add(cellTableName);
            }
            table.Rows.Add(rowTableName);


            //Total
            TableRow rowTotal = new TableRow();
            rowTotal.Style["height"] = "100px";
            TableCell cellTotalTitle = new TableCell();
            cellTotalTitle.Style["color"] = "white";
            cellTotalTitle.Style["background-color"] = "#344a5b";
            cellTotalTitle.Style["font-weight"] = "bold";
            cellTotalTitle.Style["font-family"] = "Arial,Helvetica, sans-serif";
            cellTotalTitle.Text = "Total";
            rowTotal.Cells.Add(cellTotalTitle);

            int count = 0;
            foreach (ObjectQuery a in KetNoi.ObjectQueryList)
            {
                TableCell cellSort = new TableCell();
                cellSort.HorizontalAlign = HorizontalAlign.Left;
                DropDownList dropdownlist = new DropDownList();
                List<string> droplist = new List<string>();
                dropdownlist.Items.Add("Group by"); dropdownlist.Items.Add("Sum"); dropdownlist.Items.Add("Min"); dropdownlist.Items.Add("Max"); dropdownlist.Items.Add("Count");
                dropdownlist.Items.Add("Avg");
                dropdownlist.Style["border-radius"] = "8px";
                dropdownlist.Style["border-color"] = "#476b6b";
                dropdownlist.Style["box-shadow"] = "#c2d6d6";
                dropdownlist.Style["width"] = "60%";
                dropdownlist.Style["margin-left"] = "100px";
                dropdownlist.Style["height"] = "50px";
                dropdownlist.ID = a.attributeName;
                dropdownlist.CssClass = a.tableName;
                dropdownlist.SelectedIndexChanged += DropDownGroupBy_SelectedIndexChanged;
                dropdownlist.Attributes["runat"] = "server";
                dropdownlist.Attributes["OnSelectedIndexChanged"] = "DropDownGroupBy_SelectedIndexChanged";
                dropdownlist.AutoPostBack = true;
                count++;
                cellSort.Controls.Add(dropdownlist);
                rowTotal.Cells.Add(cellSort);
            }
            table.Rows.Add(rowTotal);





            //Criteria
            TableRow rowCriteria = new TableRow();
            rowCriteria.Style["height"] = "100px";
            TableCell cellCriteriaTitle = new TableCell();
            cellCriteriaTitle.Style["color"] = "white";
            cellCriteriaTitle.Style["background-color"] = "#344a5b";
            cellCriteriaTitle.Style["font-weight"] = "bold";
            cellCriteriaTitle.Style["font-family"] = "Arial,Helvetica, sans-serif";
            cellCriteriaTitle.Text = "Criteria";
            rowCriteria.Cells.Add(cellCriteriaTitle);

            count = 0;
           for(int i=0;i< KetNoi.ObjectQueryList.Count;i++)
           { 
                TableCell cellCriteria = new TableCell();
                cellCriteria.HorizontalAlign = HorizontalAlign.Left;
                TextBox input = new TextBox();
                input.Style["border-radius"] = "8px";
                input.Style["border-color"] = "#476b6b";
                input.Style["box-shadow"] = "#c2d6d6";
                input.Style["width"] = "60%";
                input.Style["margin-left"] = "100px";
                input.ID = count.ToString();
                input.Style["height"] = "50px";
                input.Attributes["onchange"] = "getCriteria(this)";
                if(KetNoi.ObjectQueryList[i].critiria!=null)
                {
                    input.Text = KetNoi.ObjectQueryList[i].critiria;
                }
                cellCriteria.Controls.Add(input);
                rowCriteria.Cells.Add(cellCriteria);
                count++;
            }
            table.Rows.Add(rowCriteria);


            //SORT
            TableRow rowSort = new TableRow();
            rowSort.Style["height"] = "100px";
            TableCell cellSortTitle = new TableCell();
            cellSortTitle.Style["color"] = "white";
            cellSortTitle.Style["background-color"] = "#344a5b";
            cellSortTitle.Style["font-weight"] = "bold";
            cellSortTitle.Style["font-family"] = "Arial,Helvetica, sans-serif";
            cellSortTitle.Text = "Sort";
            rowSort.Cells.Add(cellSortTitle);


            foreach (ObjectQuery a in KetNoi.ObjectQueryList)
            {
                TableCell cellSort = new TableCell();
                cellSort.Text = "";
                //TextBox test2 = new TextBox();
                //cellSort.Controls.Add(test2);
                rowSort.Cells.Add(cellSort);
            }
            table.Rows.Add(rowSort);




            //Clone1
            TableRow rowClone1 = new TableRow();
            rowClone1.Style["height"] = "100px";
            TableCell cellCloneTitle1 = new TableCell();
            cellCloneTitle1.Style["color"] = "white";
            cellCloneTitle1.Style["background-color"] = "#344a5b";
            rowClone1.Cells.Add(cellCloneTitle1);


            foreach (ObjectQuery a in KetNoi.ObjectQueryList)
            {
                TableCell cellClone1 = new TableCell();

                cellClone1.Text = "";
                rowClone1.Cells.Add(cellClone1);
            }
            table.Rows.Add(rowClone1);

            //Clone2
            TableRow rowClone2 = new TableRow();
            rowClone2.Style["height"] = "100px";
            TableCell cellCloneTitle2 = new TableCell();
            cellCloneTitle2.Style["color"] = "white";
            cellCloneTitle2.Style["background-color"] = "#344a5b";
            rowClone2.Cells.Add(cellCloneTitle2);


            foreach (ObjectQuery a in KetNoi.ObjectQueryList)
            {
                TableCell cellClone1 = new TableCell();

                cellClone1.Text = "";
                rowClone2.Cells.Add(cellClone1);
            }
            table.Rows.Add(rowClone2);

            //Clone
            TableRow rowClone3 = new TableRow();
            rowClone3.Style["height"] = "100px";
            TableCell cellCloneTitle3 = new TableCell();
            cellCloneTitle3.Style["color"] = "white";
            cellCloneTitle3.Style["background-color"] = "#344a5b";
            rowClone3.Cells.Add(cellCloneTitle3);


            foreach (ObjectQuery a in KetNoi.ObjectQueryList)
            {
                TableCell cellClone1 = new TableCell();

                cellClone1.Text = "";
                rowClone3.Cells.Add(cellClone1);
            }
            table.Rows.Add(rowClone3);

            PlaceHolder1.Controls.Add(table);
        }


    }
}