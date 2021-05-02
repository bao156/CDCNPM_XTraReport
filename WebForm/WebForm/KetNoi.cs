using System;
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
        public static HashSet<string> listTable=new HashSet<string>();
        public static string database = "";
        public static HashSet<ObjectQuery> ObjectQueryList = new HashSet<ObjectQuery>();
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