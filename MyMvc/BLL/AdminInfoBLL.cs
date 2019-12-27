using MyMvc.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyMvc.BLL
{
    public class AdminInfoBLL
    {
        //<---------------------------------------------------------------------管理员信息操作---------------------------------------------------->

        //登录
        public static DataTable AdminLogin(AdminInfoModel adminInfo)
        {
            string str = $"P_AdminInfo_Select '{adminInfo.Sname}','{adminInfo.Passwords}'";
            DataTable dt = DBHelper.ExecDataTable(str);/*P_AdminInfo_Select*/
            return dt;
        }

        //注册
        public static int AdminAdd(AdminInfoModel adminInfo)
        {
            string str = $"P_AdminInfoAdd '{adminInfo.Sname}','{adminInfo.Passwords}','{adminInfo.Phone}','{adminInfo.Sex}'";
            int i = DBHelper.ExecSQL(str);/*P_AdminInfoAddTwo*/
            return i;
        }

        //反填
        public static DataTable SelectOne(int id)
        {
            string str = $"P_AdminInfo_SelectOneTwo '{id}'";
            DataTable i = DBHelper.ExecDataTable(str);
            return i;
        }

        //修改
        public static int Update(AdminInfoModel adminInfo)
        {
            string str = $"P_AdminInfo_UpdateTwo '{adminInfo.Sida}','{adminInfo.Passwords}'";
            int i = DBHelper.ExecSQL(str);
            return i;
        }

        //显示
        public static DataTable SelectAll(int PageSize = 4, int PageIndex = 1, string name = "")
        {
            string str = $"P_AdminInfoSelectTwo '{name}','{PageSize}','{PageIndex}'";
            DataTable dt = DBHelper.ExecDataTable(str);
            return dt;
        }

    }
}