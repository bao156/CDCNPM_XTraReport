using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebForm
{
    public class KetNoi
    {
        public static SqlConnection conn = new SqlConnection();
        public static String connstr;
        public static SqlCommand cmd = new SqlCommand();
        public static SqlDataReader myReader;
        public static String servername = "DESKTOP-8M2NJ75";
        public static String username = "";
        public static String mlogin = "sa";
        public static String password = "123456";
        public static HashSet<string> listTable = new HashSet<string>();
        public static string database = "";
        public static List<ObjectQuery> ObjectQueryList = new List<ObjectQuery>();
        public static List<ForeignKeyOject> ListFkTableQuery = new List<ForeignKeyOject>();
        public static string url = "";
        public static string queryString = "";
        public static List<string> critiria = new List<string>();

        public static int Connect(string database)
        {
            if (KetNoi.conn != null && KetNoi.conn.State == ConnectionState.Open)
                KetNoi.conn.Close();
            try
            {
                KetNoi.connstr = "Data Source=" + KetNoi.servername + ";Initial Catalog=" +
                      database + ";User ID=" +
                      KetNoi.mlogin + ";password=" + KetNoi.password +
                      ";MultipleActiveResultSets=True";
                KetNoi.conn.ConnectionString = KetNoi.connstr;
                KetNoi.conn.Open();
                return 1;
            }

            catch (Exception e)
            {
                Console.Write(e);
                return 0;
            }
        }
        public static string GetQueryText()
        {
            KetNoi.queryString = "SELECT ";
            int count = 1;
            bool checkFK = false;
            bool checkCriteria = false;
            bool checkGroupBy = false;

            HashSet<string> ListTableName = new HashSet<string>();
            foreach (ObjectQuery a in KetNoi.ObjectQueryList)
            {
                if (count != KetNoi.ObjectQueryList.Count)
                {
                    if (a.total != null)
                    {
                        KetNoi.queryString += a.total + "(" + a.tableName + "." + a.attributeName + "), as " + a.attributeName;
                        checkGroupBy = true;
                    }
                    else
                    {
                        KetNoi.queryString += a.tableName + "." + a.attributeName + ", ";
                    }

                    //SẴN CHECK CRITERIA LUÔN
                    if (a.critiria != null)
                    {
                        checkCriteria = true;
                    }

                }
                else
                {
                    if (a.total != null)
                    {
                        KetNoi.queryString += a.total + "(" + a.tableName + "." + a.attributeName + ") as " + a.attributeName;
                        checkGroupBy = true;
                    }
                    else
                    {
                        KetNoi.queryString += a.tableName + "." + a.attributeName;
                    }


                }
                count++;
            }


            KetNoi.queryString += "\r\n FROM ";

            //LẤY NHỮNG LOẠI BẢN CÓ TRONG DANH SÁCH SELECT
            foreach (ObjectQuery a in KetNoi.ObjectQueryList)
            {
                ListTableName.Add(a.tableName);
            }

            //VIẾT CHO FROM
            count = 1;
            foreach (string table in ListTableName)
            {
                if (count != ListTableName.Count)
                {
                    KetNoi.queryString += table + ", ";
                }
                else
                {
                    KetNoi.queryString += table + "";
                }
                count++;
            }


            //VIẾT CHO WHERE

            //DANH SÁCH TRẢ VỀ CÁI NÀO FALSE BỎ KO THÊM ZO
            HashSet<ForeignKeyOject> listTemp = KetNoi.getForeignKeyListToQuery();
            ListFkTableQuery.Clear();
            foreach (ForeignKeyOject t in listTemp)
            {
                if (t.isCheck == true) ListFkTableQuery.Add(t);
            }

            List<ObjectQuery> listFK = new List<ObjectQuery>();
            List<ObjectQuery> listPK = new List<ObjectQuery>();

            //CHẠY TỪNG QUAN HỆ CÓ TRONG DANH SÁCH LẤY ĐƯỢC
            foreach (ForeignKeyOject ob in ListFkTableQuery)
            {
                //THUỘC TÍNH ĐẦU TIÊN TRONG OBJECT LÀ BẢNG KHÓA NGOẠI
                //LỆNH DƯỚI THẤY TÊN CỘT KHÓA NGẠI TRONG BẢNG CHỨA KHÓA NGOẠI
                string strf =
                  "select COLUMN_NAME from INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE where CONSTRAINT_NAME='FK_" + ob.tableNameF + "_" + ob.tableNameK + "'";
                foreach (string a in getColumnNameKey(strf))
                {
                    ObjectQuery temp = new ObjectQuery();
                    temp.attributeName = a;
                    temp.tableName = ob.tableNameF;
                    listFK.Add(temp);
                }
                //;



                //LEEHNH NÀY LẤY KHÓA CHÍNH TRONG BẢNG CHỨA KHÓA CHÍNH
                string strp =
                  "select COLUMN_NAME from INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE where CONSTRAINT_NAME='PK_" + ob.tableNameK + "'";
                foreach (string a in getColumnNameKey(strp))
                {
                    ObjectQuery temp = new ObjectQuery();
                    temp.attributeName = a;
                    temp.tableName = ob.tableNameK;
                    listPK.Add(temp);
                }

            }
            if (listPK.Count != 0 || checkCriteria == true)
            {
                KetNoi.queryString += "\r\n WHERE ";
            }
            bool checkJoin = false;
            //GHÉP ZO NÈ HIHI
            for (int i = 0; i < listPK.Count; i++)
            {
                if (i != listPK.Count - 1)
                {
                    KetNoi.queryString += listPK[i].tableName + "." + listFK[i].attributeName + " = " +
                         listFK[i].tableName + "." + listFK[i].attributeName + " and ";


                    checkJoin = true;
                }
                else
                {

                    KetNoi.queryString += listPK[i].tableName + "." + listPK[i].attributeName + " =" +
                            listFK[i].tableName + "." + listFK[i].attributeName;
                    checkJoin = true;
                }

            }

            //PHẢI CHẠY RIEEGN ĐÂU PHẢI CÁI NÀO CŨNG CÓ ĐIỀU KIỆN

            int length = KetNoi.ObjectQueryList.Count;
            for (int i = 0; i < length; i++)
            {
                if (KetNoi.ObjectQueryList[i].critiria != null)
                {
                    if (checkJoin == true)
                    {
                        KetNoi.queryString += " and " + KetNoi.ObjectQueryList[i].tableName + "." + ObjectQueryList[i].attributeName + " ='" + ObjectQueryList[i].critiria + "' ";
                    }
                    else
                    {
                        KetNoi.queryString += KetNoi.ObjectQueryList[i].tableName + "." + ObjectQueryList[i].attributeName + "= '" + ObjectQueryList[i].critiria + "' ";
                    }

                }
            }


            //VIẾT CHO NẾU CÓ GROUP BY NÈ
            count = 0; //NÀY CHECK CHẠY ĐẦU TIÊN
            if (checkGroupBy == true)
            {
                KetNoi.queryString += "\r\n GROUP BY ";
                length = ObjectQueryList.Count;
                for (int i = 0; i < length; i++)
                {
                    if (KetNoi.ObjectQueryList[i].total == null)
                    {
                        if (count == 0)
                        {
                            KetNoi.queryString += " " + KetNoi.ObjectQueryList[i].tableName + "." + KetNoi.ObjectQueryList[i].attributeName;
                            count++;
                        }
                        else
                        {
                            KetNoi.queryString += ", " + KetNoi.ObjectQueryList[i].tableName + "." + KetNoi.ObjectQueryList[i].attributeName;
                        }
                    }
                }


            }
            return KetNoi.queryString;

        }

        public static HashSet<ForeignKeyOject> getForeignKeyListToQuery()
        {
            HashSet<ForeignKeyOject> hashForeinKey = new HashSet<ForeignKeyOject>();
            List<ForeignKeyOject> listForeginKey = new List<ForeignKeyOject>();

            //LẤY CÁC BẢNG CÓ ĐỂ QUERY KHÔNG CÓ TRÙNG GIÁ TRỊ
            HashSet<string> listDistinceTable = new HashSet<string>();
            foreach (ObjectQuery ob in KetNoi.ObjectQueryList)
            {
                listDistinceTable.Add(ob.tableName);
            }

            //LẤY TẤT CẢ CÁC KHÓA NGOẠI CÓ TRONG DATABASE
            List<string> listAllForeginKey = new List<string>();
            listAllForeginKey = KetNoi.getAllForeignKeyInDatabase(listAllForeginKey);


            //DO HASHSET KO LẤY RA ĐƯỢC VỊ TRÍ KHI CHẠY VÒNG FOR
            List<ObjectQuery> listObjectQueryTemp = new List<ObjectQuery>(KetNoi.ObjectQueryList);




            //TẠO CÁC TỔ HỢP KHÓA NGOẠI TỪ CÁC BẢN
            for (int i = 0; i < listObjectQueryTemp.Count - 1; i++)
            {
                string tableNameF;
                tableNameF = listObjectQueryTemp[i].tableName;
                for (int j = i + 1; j < listObjectQueryTemp.Count; j++)
                {
                    ForeignKeyOject temp = new ForeignKeyOject();
                    temp.tableNameF = tableNameF;
                    temp.tableNameK = listObjectQueryTemp[j].tableName;
                    listForeginKey.Add(temp);
                }

            }



            //List<string> test = new List<string>();
            //List<int> testint = new List<int>();
            //LỌC RA KHÓA NGOẠI NÀO SẼ DÙNG ĐƯỢC 
            for (int i = 0; i < listForeginKey.Count; i++)
            {
                string temp1 = listForeginKey[i].tableNameF + "_" + listForeginKey[i].tableNameK;
                string temp2 = listForeginKey[i].tableNameK + "_" + listForeginKey[i].tableNameF;
                //test.Add(temp1);
                //test.Add(temp2);
                bool check = false;
                foreach (string key in listAllForeginKey)
                {
                    if (key == temp1)
                    {
                        check = true;
                        listForeginKey[i].isCheck = true;


                    }
                    else if (key == temp2)
                    {
                        //ĐÔIT LẠI CHO ĐÚNG VỚI CÚ PHÁP TRONG TRUY VẤN LÀ TÊN BẢNG CHỨA KHÓA NGOẠI TRƯỚC MỚI KHÓA CHÍNH
                        check = true;
                        string temps = listForeginKey[i].tableNameF;
                        listForeginKey[i].tableNameF = listForeginKey[i].tableNameK;
                        listForeginKey[i].tableNameK = temps;

                        listForeginKey[i].isCheck = true;
                    }

                }
                if (check == false)
                {
                    listForeginKey[i].isCheck = false;
                }

            }

            foreach (ForeignKeyOject t in listForeginKey)
            {
                if (KetNoi.checkInsideHash(hashForeinKey, t) == false) hashForeinKey.Add(t);

            }
            //DANH SÁCH LÚC NÀY LẤY ĐÃ ĐƯỢC SẮP XẾP ĐÚNG CÚ PHÁP
            return hashForeinKey;

        }

        public static List<String> getAllForeignKeyInDatabase(List<String> list)
        {
            if (KetNoi.Connect(KetNoi.database) == 0) return list;
            String str = "select name from sys.objects where type='F'";
            SqlDataReader dataReader = KetNoi.ExecSqlDataReader(str);
            while (dataReader.Read())
            {
                string Output = dataReader.GetValue(0).ToString().Substring(3);
                list.Add(Output);
            }
            return list;
        }

        public static List<String> getColumnNameKey(string str)
        {
            List<String> list = new List<string>();
            KetNoi.Connect(KetNoi.database);
            SqlDataReader dataReader = KetNoi.ExecSqlDataReader(str);
            while (dataReader.Read())
            {
                string Output = dataReader.GetValue(0).ToString();
                list.Add(Output);
            }
            return list;
        }

        public static bool checkInsideHash(HashSet<ForeignKeyOject> hash, ForeignKeyOject item)
        {
            bool check = false;

            foreach (ForeignKeyOject a in hash)
            {
                if (item.tableNameF == a.tableNameF && item.tableNameK == a.tableNameK && item.isCheck == a.isCheck)
                {
                    check = true;
                    break;
                }
            }

            return check;
        }


        public static DataTable QueryDataTable()
        {
            KetNoi.Connect(KetNoi.database);
            String str = KetNoi.queryString;
            str.Replace("\r\n", " ");
            DataTable dataTable = KetNoi.ExecSqlDataTable(str);
            return dataTable;
        }


        public static SqlDataReader ExecSqlDataReader(String strLenh)
        {
            SqlDataReader myreader;
            SqlCommand sqlcmd = new SqlCommand(strLenh, KetNoi.conn);
            sqlcmd.CommandType = CommandType.Text;
            if (KetNoi.conn.State == ConnectionState.Closed) KetNoi.conn.Open();
            try
            {
                myreader = sqlcmd.ExecuteReader(); return myreader;

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                KetNoi.conn.Close();
                return null;
            }
        }
        public static DataTable ExecSqlDataTable(String cmd)
        {
            DataTable dt = new DataTable();
            if (KetNoi.conn.State == ConnectionState.Closed) KetNoi.conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, conn);
            da.Fill(dt);
            conn.Close();
            return dt;
        }


        public static int ExecSqlNonQuery(String strlenh)
        {
            ObjectQuery a = new ObjectQuery();
            SqlCommand Sqlcmd = new SqlCommand(strlenh, conn);
            Sqlcmd.CommandType = CommandType.Text;
            Sqlcmd.CommandTimeout = 600;// 10 phut 
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sqlcmd.ExecuteNonQuery(); conn.Close();
                return 0;
            }
            catch (SqlException ex)
            {
                conn.Close();
                return ex.State; // trang thai lỗi gởi từ RAISERROR trong SQL Server qua
            }
        }
    }
}