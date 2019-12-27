using MyMvc.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyMvc.BLL
{
    public class UserInfoBLL
    {
        //用户显示
        public static DataTable Select(int PageSize = 5, int PageIndex = 1, string name = "", string Uplate = "")
        {
            string str = $"UserInfosELECTAllPage '{name}','{Uplate}','{PageSize}','{PageIndex}'";
            DataTable dt = DBHelper.ExecDataTable(str);
            return dt;
        }

        //会员查询
        public static List<UserInfoModel> VIPSelect()
        {
            string str = $"";
            DataTable dt = DBHelper.ExecDataTable(str);
            string str2 = JsonConvert.SerializeObject(dt);
            List<UserInfoModel> list = JsonConvert.DeserializeObject<List<UserInfoModel>>(str2);
            return list;
        }

    }
}