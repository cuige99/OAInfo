using MyMvc.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyMvc.BLL
{
    public class CarTypesInfoBLL
    {
        //<-------------------------------------------------------------------车库类别------------------------------------------------------------>

        //增加
        public static int Add(CarTypesInfoModel carTypes)
        {
            string str = $"P_CarTypes_Add '{carTypes.Tname}','{carTypes.Tmaney}'";
            if (carTypes.Tname==null)
            {
                return 0;
            }
            if (carTypes.Tmaney == null)
            {
                return 0;
            }
            int i = DBHelper.ExecSQL(str);
            return i;
        } 


        //显示
        public static DataTable SelectAll(string name)
        {
            string str = $"P_CarTypes_SelectTwo '{name}'";
            DataTable dt = DBHelper.ExecDataTable(str);
            return dt;
        }

        //绑定 

        public static List<CarTypesInfoModel> Select()
        {
            string str = "select * from CarTypes";
            DataTable dt = DBHelper.ExecDataTable(str);
            string str2 = JsonConvert.SerializeObject(dt);
            List<CarTypesInfoModel> list = JsonConvert.DeserializeObject<List<CarTypesInfoModel>>(str2);
            return list;
        }

        //删除
        public static int Delete(string id)
        {
            string str = $"delete  from CarTypes where TID in ({id})";
            int i = DBHelper.ExecSQL(str);
            return i;
        }

        //反填
        public static DataTable SelectOne(int id)
        {
            string str = $"P_CarTypes_SelectOne '{id}'";
            DataTable dt = DBHelper.ExecDataTable(str);
            return dt;
        }

        //修改
        public static int Update(CarTypesInfoModel carTypes)
        {
            string str = $"P_CarTypes_UpdateTwo '{carTypes.TID}','{carTypes.Tname}','{carTypes.Tmaney}'";
            if (carTypes.Tname == null)
            {
                return 0;
            }
            if (carTypes.Tmaney == null)
            {
                return 0;
            }
            int i = DBHelper.ExecSQL(str);
            return i;
        }

    }
}