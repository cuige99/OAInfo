using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMvc.Model
{
    public class RecodeInfoModel
    {
        //停车记录类
        public int RId { get; set; }
        public string RName { get; set; }
        public DateTime CreateDatetime { get; set; }
        public int Fid { get; set; }
    }
}