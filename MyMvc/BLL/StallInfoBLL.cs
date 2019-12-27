using MyMvc.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyMvc.BLL
{
    public class StallInfoBLL
    {
        //<--------------------------------------------------------------------------车位表----------------------------------------------------------------> 

        //显示
        public static DataTable Select(string name)
        {
            string str = $"P_Stall_SelectTwo '{name}'";
            DataTable dt = DBHelper.ExecDataTable(str);
            return dt;
        }


        //添加
        public static int Add(StallInfoModel stallInfo)
        {
            string str = $"P_Stall_Add '{stallInfo.Place}','{stallInfo.Situation}','{stallInfo.FID}'";
            if (stallInfo.Place ==null)
            {
                return 0;
            }
            int i = DBHelper.ExecSQL(str);
            return i;
        }


        //删除
        public static int Delete(string id)
        {
            string str = $"delete  from Stall where WID in ({id})";
            int i = DBHelper.ExecSQL(str);
            return i;
        }

        //反填
        public static DataTable SelectOne(int id)
        {
            string str = $"P_Stall_SelectOne '{id}'";
            DataTable dt = DBHelper.ExecDataTable(str);
            return dt;
        }

        //修改
        public static int Update(StallInfoModel stallInfo)
        {
            string str = $"P_Stall_UpdateTwo '{stallInfo.WID}','{stallInfo.Place}','{stallInfo.Situation}','{stallInfo.FID}'";
            if (stallInfo.Place == null)
            {
                return 0;
            }
            int i = DBHelper.ExecSQL(str);
            return i;
        }
    }
}