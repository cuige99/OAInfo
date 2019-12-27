using MyMvc.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyMvc.BLL
{
    public class RecodeInfoBLL
    {

        //<---------------------------------------------------------------------停车记录 ------------------------------------------------------------------------>



        //显示
        public static DataTable Select(string name = "")
        {
            string str = $"Recode_Select_Two '{name}'";
            DataTable dt = DBHelper.ExecDataTable(str);
            return dt;
        }

        //删除
        public static int Delete(string id)
        {
            string str = $"delete  from Recode where RId in ({id})";
            int i = DBHelper.ExecSQL(str);
            return i;
        }



    }
}