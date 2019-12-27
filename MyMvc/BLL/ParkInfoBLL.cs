using MyMvc.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyMvc.BLL
{
    public class ParkInfoBLL
    {
        //<--------------------------------------------------------------------------停车详情 ----------------------------------------------------> 

        //显示
        public static DataTable Select( string name )
        {
            string str = $"P_Park_SelectTwo '{name}'";
            DataTable dt = DBHelper.ExecDataTable(str);
            return dt;
        }


        ////添加
        //public static int Add(ParkInfoModel parkInfo)
        //{
        //    string str = $"P_Park_Add '{parkInfo.UIDa}','{parkInfo.PImage}','{parkInfo.TID}','{parkInfo.WID}','{parkInfo.CreateDate}','{parkInfo.ExpireDate}'";
        //    int i = DBHelper.ExecSQL(str);
        //    return i;
        //}


        //删除
        public static int Delete(string id)
        {
            string str = $"delete  from Park where PID in ({id})";
            int i = DBHelper.ExecSQL(str);
            return i;
        }


    }
}