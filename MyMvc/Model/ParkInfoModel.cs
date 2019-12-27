﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMvc.Model
{
    public class ParkInfoModel
    {
        //用户停车记录 
        public int PID { get; set; }
        public int UIDa { get; set; }
        public string PImage { get; set; }
        public int TID { get; set; }
        public string Plate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}