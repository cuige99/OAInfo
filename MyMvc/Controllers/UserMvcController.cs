using MyMvc.BLL;
using MyMvc.Model;
using MyMvc.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMvc.Controllers
{
    public class UserMvcController : Controller
    {

        #region 管理员登录 操作

        //登录
        public ActionResult AdminIndex()
        {
            MyMvc.Model.AdminInfoModel s = new AdminInfoModel();
            return View(s);
        }
        [HttpPost]
        public void AdminIndex(AdminInfoModel adminInfo)
        {

            DataTable dt = AdminInfoBLL.AdminLogin(adminInfo);
            string str = JsonConvert.SerializeObject(dt);
            Session["Sname"] = adminInfo.Sname;//保存用户名
            Session["pass"] = adminInfo.Passwords;//获取登录密码
            List<AdminInfoModel> list = JsonConvert.DeserializeObject<List<AdminInfoModel>>(str);

            if (list.Count > 0)
            {
                Session["id"] = list[0].Sida;//保存用户id
                Response.Write("<script>alert('登录成功!');location.href='/UserMvc/AdmianInter'</script>");
            }
            else
            {
                Response.Write("<script>alert('登录失败,请重新登陆!');location.href='/UserMvc/AdminIndex'</script>");
            }
        }

        //注册
        public ActionResult AdminAdd()
        {
            return View();
        }
        [HttpPost]
        public void AdminAdd(AdminInfoModel adminInfo)
        {
            int i = AdminInfoBLL.AdminAdd(adminInfo);
            if (i > 0)
            {
                Response.Write("<script>alert('注册成功,请您登录!');location.href='/UserMvc/AdminIndex'</script>");
            }
            else
            {
                Response.Write("<script>alert('注册失败,请重新注册!');location.href='/UserMvc/AdminIndex'</script>");
            }
        }

        //管理员信息
        public ActionResult AdminAddSelectAll(int PageSize = 4, int PageIndex = 1, string name = "")
        {
            DataTable dt = AdminInfoBLL.SelectAll(PageSize, PageIndex, name);
            string str = JsonConvert.SerializeObject(dt);
            List<AdminInfoModel> list = JsonConvert.DeserializeObject<List<AdminInfoModel>>(str);
            #region 分页
            int Count = (list == null || list.Count == 0) ? 0 : list[0].RowsId; //定义与数据库相同的字段RowsId 获取总个数
            int C = (int)Math.Ceiling((decimal)Count / PageSize);  //使用数学函数 总个数/条数=页数
            ViewBag.countTwo = Count; //定义总条数
            ViewBag.lastTwo = C;//页数
            ViewBag.PageNextTwo = PageIndex > C ? C : PageIndex + 1; //下一页       
            ViewBag.PageBackTwo = PageIndex + 1 <= 1 ? 1 : PageIndex - 1;//上一页
            #endregion
            return View(list);
        }

        //修改密码
        public ActionResult AdminUpdate(int id)
        {
            DataTable dt = AdminInfoBLL.SelectOne(id);
            string str = JsonConvert.SerializeObject(dt);
            List<AdminInfoModel> list = JsonConvert.DeserializeObject<List<AdminInfoModel>>(str);
            return View(list.First());
        }
        [HttpPost]
        public void AdminUpdate(AdminInfoModel adminInfo)
        {
            int i = AdminInfoBLL.Update(adminInfo);
            if (i > 0)
            {
                Response.Write("<script>alert('修改成功!')</script>");
            }
        }

        //管理员主界面
        public ActionResult AdmianInter()
        {
            return View();
        }
        #endregion


        #region 个人中心  操作


        // 个人中心显示
        public ActionResult UserIndex(int PageSize = 5, int PageIndex = 1, string name = "", string Uplate = "")
        {
            DataTable dt = UserInfoBLL.Select(PageSize, PageIndex, name, Uplate);
            string str = JsonConvert.SerializeObject(dt);
            List<ParkInfoViewModel> list = JsonConvert.DeserializeObject<List<ParkInfoViewModel>>(str);

            #region 分页
            int Count = (list == null || list.Count == 0) ? 0 : list[0].RowsId; //定义与数据库相同的字段RowsId 获取总个数
            int C = (int)Math.Ceiling((decimal)Count / PageSize);  //使用数学函数 总个数/条数=页数
            ViewBag.count = Count; //定义总条数
            ViewBag.last = C;//页数
            ViewBag.PageNext = PageIndex > C ? C : PageIndex + 1; //下一页       
            ViewBag.PageBack = PageIndex + 1 <= 1 ? 1 : PageIndex - 1;//上一页
            #endregion
            return View(list);
        }

        #endregion


        #region 车辆记录  操作

        //显示
        public ActionResult ParkIndex(string name = "")
        {
            ParkInfoBang();
            DataTable dt = ParkInfoBLL.Select(name);
            string str = JsonConvert.SerializeObject(dt);
            List<ParkInfoViewModel> list = JsonConvert.DeserializeObject<List<ParkInfoViewModel>>(str);
            return View(list);
        }

        //绑定下啦  车库

        public void ParkInfoBang()
        {
            ViewBag.list = new SelectList(CarTypesInfoBLL.Select(), "TID", "TName");
        }

        //删除
        public int ParkDel(string id)
        {
            id = id.TrimEnd(',');
            int i = ParkInfoBLL.Delete(id);
            return i;
        }


        #endregion


        #region 车库级别  操作

        //添加
        public ActionResult CarTypesAdd()
        {
            return View();
        }
        [HttpPost]
        public void CarTypesAdd(CarTypesInfoModel carTypes)
        {
            int i = CarTypesInfoBLL.Add(carTypes);
            if (i > 0)
            {
                Response.Write("<script>alert('添进成功!');location.href='/UserMvc/CarTypesIndex'</script>");
            }
            else
            {
                Response.Write("<script>alert('添进失败!');location.href='/UserMvc/CarTypesAdd'</script>");
            }
        }

        //显示

        public ActionResult CarTypesIndex(string name = "")
        {
            DataTable dt = CarTypesInfoBLL.SelectAll(name);
            string str = JsonConvert.SerializeObject(dt);
            List<ParkInfoViewModel> list = JsonConvert.DeserializeObject<List<ParkInfoViewModel>>(str);
            return View(list);
        }

        //删除
        public int CarTypesDel(string id)
        {
            id = id.TrimEnd(',');
            int i = CarTypesInfoBLL.Delete(id);
            return i;
        }

        //修改
        public ActionResult CarTypesUpdate(int id)
        {
            DataTable dt = CarTypesInfoBLL.SelectOne(id);
            string str = JsonConvert.SerializeObject(dt);
            List<ParkInfoViewModel> list = JsonConvert.DeserializeObject<List<ParkInfoViewModel>>(str);
            return View(list.First());
            return View();
        }
        [HttpPost]
        public void CarTypesUpdate(CarTypesInfoModel carTypes)
        {
            int i = CarTypesInfoBLL.Update(carTypes);
            if (i > 0)
            {
                Response.Write("<script>alert('编辑成功!');location.href='/UserMvc/CarTypesIndex'</script>");
            }
            else
            {
                Response.Write("<script>alert('编辑失败!');location.href='/UserMvc/CarTypesIndex'</script>");
            }
        }

        #endregion


        #region 驶入记录  操作

        //显示
        public ActionResult RecodeIndex(string name = "")
        {
            DataTable dt = RecodeInfoBLL.Select(name);
            string str = JsonConvert.SerializeObject(dt);
            List<ParkInfoViewModel> list = JsonConvert.DeserializeObject<List<ParkInfoViewModel>>(str);
            return View(list);
        }

        //删除
        public int RecodeDel(string id)
        {
            id = id.TrimEnd(',');
            int i = RecodeInfoBLL.Delete(id);
            return i;
        }

        #endregion


        #region 车位状态  操作

        //显示
        public ActionResult StallIndex(string name = "")
        {
            DataTable dt = StallInfoBLL.Select(name);
            string str = JsonConvert.SerializeObject(dt);
            List<ParkInfoViewModel> list = JsonConvert.DeserializeObject<List<ParkInfoViewModel>>(str);
            return View(list);
        }

        //添加
        public ActionResult StallAdd()
        {
            ParkInfoViewModel park = new ParkInfoViewModel();
            return View(park);
        }
        [HttpPost]
        public void StallAdd(StallInfoModel stallInfo)
        {

            int i = StallInfoBLL.Add(stallInfo);
            if (i > 0)
            {
                Response.Write("<script>alert('输入成功!');location.href='/UserMvc/StallIndex'</script>");
            }
            else
            {
                Response.Write("<script>alert('输入失败!');location.href='/UserMvc/StallAdd'</script>");
            }
        }


        //删除
        public int StallDel(string id)
        {
            id = id.TrimEnd(',');
            int i = StallInfoBLL.Delete(id);
            return i;
        }

        //编辑

        public ActionResult StallUpdate(int id)
        {
            DataTable dt = StallInfoBLL.SelectOne(id);
            string str = JsonConvert.SerializeObject(dt);
            List<ParkInfoViewModel> list = JsonConvert.DeserializeObject<List<ParkInfoViewModel>>(str);
            return View(list.First());
        }
        [HttpPost]
        public void StallUpdate(StallInfoModel stallInfo)
        {
            int i = StallInfoBLL.Update(stallInfo);
            if (i > 0)
            {
                Response.Write("<script>alert('编辑成功!');location.href='/UserMvc/StallIndex'</script>");
            }
            else
            {
                Response.Write("<script>alert('编辑失败!');location.href='/UserMvc/StallIndex'</script>");
            }

        }
        #endregion
    }
}
