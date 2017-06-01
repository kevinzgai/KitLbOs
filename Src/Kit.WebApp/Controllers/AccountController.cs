using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kit.BLL;
using Kit.Model;
using System.Data;
using System.Text;
using Kit.Common;
using Kit.Common.DEncrypt;
using Kit.DBUtility;
using Newtonsoft.Json;

namespace Kit.WebApp.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return RedirectToAction("GetAccount", "Account");
        }
        public ActionResult login()
        {
            return View();
        }
        public ActionResult loginaction()
        {
            StringBuilder strjson = new StringBuilder();
            //strjson.Append("{\"result\":\"true\"}");
            String Usename = Request["username"];
            string password = Request["password"].Trim();
            password = DESEncrypt.Encrypt(password);

            List<Kit.Model.Kuser> Uds = new BLL.Kuser().GetModelList("UEmail='" + Usename + "'");
            //if (Uds.Tables[0].Rows.Count > 0)
            //    strjson.Append("\"result\":\"true\"");
            //else
            //{
            //    strjson.Append("{\"result\":\"false\",\"msg:\"找不到该用户\"\"}");
            //}

            if (Uds.Count > 0)
            {
                Kit.Model.Kuser drow = Uds[0];
                if (drow.Upwd.Equals(password))
                {
                    
                    Session["User"] = drow;
                    Response.Cookies["Lang"].Value = drow.Ulang.Trim();
                    Response.Cookies["userName"].Expires = DateTime.Now.AddMonths(1);
                    Session["Lang"] = drow.Ulang.Trim()=="CN"?Lang.LangType.cn:Lang.LangType.en;
                    strjson.Append("{\"result\":\"0\",\"msg\":\"登录成功！\"}");
                }
                else
                {
                    strjson.Append("{\"result\":\"1\",\"msg\":\"账户或者密码错误\"}");
                }
            }
            else
            {
                strjson.Append("{\"result\":\"1\",\"msg\":\"账户或者密码错误\"}");
            }
            return Content(strjson.ToString());
        }

        public ActionResult GetAccount()
        {
            if (Session["User"]==null)
                return RedirectToAction("login", "Account");
            ViewBag.model = new BLL.Kuser().GetModelList("");
            return View();
        }
        //添加用户 页面
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            if (id.Equals(null))
            {
                RedirectToAction("GetAccount", "Account");
            }
            ViewBag.Model = new BLL.Kuser().GetModel(id);
            ViewBag.Model.Upwd = Kit.Common.DEncrypt.DESEncrypt.Decrypt(ViewBag.Model.Upwd);
            return View();
        }
        //post:Account/Createaction
        public ActionResult Createaction()
        {
            Model.Kuser Mkuser = new Model.Kuser();
            string strErr = "";
            if (Request["txtUEmail"].Trim().Length == 0)
            {

                strErr += "用户Email不能为空！<br/>";
            }
            if (Request["txtUpwd"].Trim().Length == 0)
            {
                strErr += "用户密码不能为空！<br/>";
            }
            if (Request["txtUlang"].Trim().Length == 0)
            {
                strErr += "Ulang不能为空！<br/>";
            }
            if (Request["txtUrole"].Trim().Length == 0)
            {
                strErr += "Urole不能为空！<br/>";
            }
            if (!PageValidate.IsEmail(Request["txtUEmail"].Trim()))
            {
                strErr += "Email格式不正确！<br/>";
            }
            if (strErr != "")
            {
                return Content("{\"result\":0,\"msg\":\"" + strErr + "\"}");
            }

            string UEmail = Request["txtUEmail"];
            string Upwd = Request["txtUpwd"];
            string Ulang = Request["txtUlang"];
            string Urole = Request["txtUrole"];

            if (new BLL.Kuser().GetList(" UEmail='" + UEmail + "'").Tables[0].Rows.Count > 0)
            {
                return Content("{\"result\":0,\"msg\":\"该账号已存在，请不要重复添加\"}");
            }
            Mkuser.UEmail = UEmail;
            Mkuser.Upwd = Kit.Common.DEncrypt.DESEncrypt.Encrypt(Upwd);
            Mkuser.Ulang = Ulang;
            Mkuser.Urole = Urole;


            Kit.BLL.Kuser bll = new Kit.BLL.Kuser();

            

            Pagelog.UnitLog("ulogin", "Add User:" + JsonConvert.SerializeObject(Mkuser) , "测试数据");

            return Content("{\"result\":1,\"msg\":\"" + bll.Add(Mkuser) + "\"}");
        }
        //post:Account/Editaction
        [HttpPost]
        public ActionResult Editaction()
        {
            Model.Kuser Mkuser = new Model.Kuser();
            string strErr = "";
            if (Request["txtUEmail"].Trim().Length == 0)
            {

                strErr += "用户Email不能为空！<br/>";
            }
            if (Request["txtUpwd"].Trim().Length == 0)
            {
                strErr += "用户密码不能为空！<br/>";
            }
            if (Request["txtUlang"].Trim().Length == 0)
            {
                strErr += "Ulang不能为空！<br/>";
            }
            if (Request["txtUrole"].Trim().Length == 0)
            {
                strErr += "Urole不能为空！<br/>";
            }
            if (!PageValidate.IsEmail(Request["txtUEmail"].Trim()))
            {
                strErr += "Email格式不正确！<br/>";
            }
            if (strErr != "")
            {
                return Content("{\"result\":0,\"msg\":\"" + strErr + "\"}");
            }

            string UEmail = Request["txtUEmail"];
            string Upwd = Request["txtUpwd"];
            string Ulang = Request["txtUlang"];
            string Urole = Request["txtUrole"];
            Mkuser.Uid = int.Parse(Request["id"].ToString());
            Mkuser.UEmail = UEmail;
            Mkuser.Upwd = Kit.Common.DEncrypt.DESEncrypt.Encrypt(Upwd);
            Mkuser.Ulang = Ulang;
            Mkuser.Urole = Urole;
            Kit.BLL.Kuser bll = new Kit.BLL.Kuser();
            Pagelog.UnitLog("ulogin", "Edit User:" + JsonConvert.SerializeObject(Mkuser), "测试数据");
            return Content("{\"result\":1,\"msg\":\"" + bll.Update(Mkuser) + "\"}");
        }
    }
}