using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;



namespace MyMvc.Models
{
    public class ParkInfoViewModel
    {
        //管理员类
        public int Sida { get; set; }
        public string Sname { get; set; }
        public string Passwords { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Sex { get; set; }

        //用户类
        public int UIDa { get; set; }
        public string UImage { get; set; }
        public string Uname { get; set; }
        public string Upwd { get; set; }
        public string Uidentity { get; set; }
        public string UPhone { get; set; }
        public string USite { get; set; }
        public string Uplate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public int Price { get; set; }
        public decimal Moneya { get; set; }
        public int FId { get; set; }
        public int RowsId { get; set; }
        public string Plate { get; set; }

        //车辆类别
        public int TID { get; set; }
        public string Tname { get; set; }
        public string Tmaney { get; set; }

        //停车记录(One)
        public int RId { get; set; }
        public string RName { get; set; }
        public DateTime CreateDatetime { get; set; }
        public int Fid { get; set; }


        //停车记录 
        public int PID { get; set; }
        public string PImage { get; set; }



        //车位类
        [Display(Name = "编号")]
        public int WID { get; set; }
        [Display(Name = "区域")]
        public string Place { get; set; }
        [Display(Name = "状态")]
        public int Situation { get; set; }
        public int FID { get; set; }
    }
}