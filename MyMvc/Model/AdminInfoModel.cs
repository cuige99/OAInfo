using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMvc.Model
{
    public class AdminInfoModel
    {
        //管理员类
        public int Sida { get; set; }
        public string Sname { get; set; }
        public string Passwords { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Sex { get; set; }
        public int RowsId { get; set; }
    }
}