using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace MyMvc
{
    public class DBHelper
    {
        static string sqlconn = ConfigurationManager.ConnectionStrings["Conn"].ToString();
        //普通的Sql
        public static int ExecSQL(string sql)
        {


            using (SqlConnection conn = new SqlConnection(sqlconn))
            {
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sql, conn);
                    int i = command.ExecuteNonQuery();
                    conn.Close();
                    return i;
                }
                catch (Exception ex)
                {

                    LogHelper.WriteLog("异常", ex);
                    return 0;
                }


            }
        }
        //普通的Sql
        public static DataTable ExecDataTable(string sql)
        {
            using (SqlConnection conn = new SqlConnection(sqlconn))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);
                    dataAdapter.Dispose();
                    LogHelper.WriteLog("正常日志记录!");
                    conn.Close();
                    return dt;
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog("异常", ex);
                    return null;
                }


            }
        }


        //存储过程带参数
        public static DataTable ExecProcDataTable(string sql, Dictionary<string, object> pairs)
        {
            using (SqlConnection conn = new SqlConnection(sqlconn))
            {
                //try
                //{
                conn.Open();


                SqlCommand command = new SqlCommand();
                command.CommandText = sql;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conn;
                foreach (var item in pairs)
                {
                    command.Parameters.AddWithValue(item.Key, item.Value);
                }


                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataAdapter.Dispose();
                conn.Close();
                LogHelper.WriteLog("正常日志记录!");
                return dt;
                //}
                //catch (Exception ex)
                //{


                //    MySqlLog.Writelog("MyDBHelper", ex.Message);
                //    return null;
                //}


            }
        }


        //存储过程带参数
        public static int ExecProcSQL(string sql, Dictionary<string, object> pairs)
        {


            using (SqlConnection conn = new SqlConnection(sqlconn))
            {
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = sql;
                    command.Connection = conn;
                    foreach (var item in pairs)
                    {
                        command.Parameters.AddWithValue(item.Key, item.Value);
                    }
                    int i = command.ExecuteNonQuery();
                    conn.Close();
                    return i;
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog("异常", ex);
                    return 0;
                }


            }
        }

        //聚合函数  执行登录
        public static object ExecuteScalar(string sql)
        {
            using (SqlConnection conn = new SqlConnection(sqlconn))
            {

                //打开数据库
                conn.Open();
                //创建执行过程
                SqlCommand cmd = new SqlCommand(sql, conn);
                //获取执行结果
                object ob = cmd.ExecuteScalar();
                //关闭数据库
                conn.Close();
                //返回受影响的行数
                LogHelper.WriteLog("正常日志记录!");
                return ob;


            }


        }
    }
}
