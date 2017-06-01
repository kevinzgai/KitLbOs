using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Kit.Common;
using Kit.DBUtility;
using Kit.Model;

namespace Kit.WebApp.Controllers
{
    public class LabelRoleLogController : Controller
    {
        // GET: LabelRoleLog
        [HttpGet]
        public ActionResult Index(string id, string lid)
        {
            lid = Request["lid"];
            string strView = "Index";
            string pid = id;
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(lid)) //指定标签格式
            {
                return Content("空标签id，非法操作");
            }
            Kit.Model.Kuser Kuser = new Kuser();
            if (Session["User"]!=null)
            {
                Kuser = Session["User"] as Kit.Model.Kuser;
                strView += Kuser.Urole.Trim();
                ViewBag.Kuser = Kuser;
            }
            else
            {
                Response.Redirect("~/Account/login");
                // RedirectToAction("login", "Account");

            }

            //string StrSql =string.Format("select * from KlableroleBase as b,Klableroleloop as a where a.Lid=b.Lid and a.Lid='{0}' and b.LProductid={1}",lid,id);

            Kit.Model.KlableroleBase kbKlableroleBase = new BLL.KlableroleBase().GetModel(int.Parse(lid));

            Kit.Model.Klableroleloop bKlableroleloop = new BLL.Klableroleloop().GetModelList(" Lid=" + lid)[0];
            // DataSet desDataSet=DbHelperSQL.Query(StrSql.ToString());
            List<object> objList = new List<object>();
            objList.Add(kbKlableroleBase);
            bKlableroleloop.Spare1 = GetRoleLoopsMaxnum(bKlableroleloop.Tlooprole);//该规则最大编号
            objList.Add(bKlableroleloop);

            JsonResult res = new JsonResult();
            res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            res.Data = objList;//desDataSet.Tables[0];
                               // return res;
            ViewBag.Labelobj = objList;
            DataTable DtLog = GetLabelPrtLog(lid, pid);
            string startnum = "";
            startnum = bKlableroleloop.Tlooprole;//标签基本循环
            if (DtLog.Rows.Count > 0)
            {
                ViewBag.Labelloglist = DtLog;
                startnum = FormatRolelooplastnumber(bKlableroleloop.Tlooprole.Length,
                    DtLog.Rows[0]["Rendnumber"].ToString());
            }
            ViewBag.startnum = string.IsNullOrEmpty(startnum) ? kbKlableroleBase.Lcontentsate : startnum;
            ViewBag.Kuser = Kuser;
            return View(strView);
        }
        //GET: LabelRoleLog/AddLbPrintLog
        [HttpPost]
        public ActionResult AddLbPrintLog()
        {

            string strErr = "";
            if (!PageValidate.IsNumber(Request["txtPid"]))
            {
                strErr += "Pid格式错误！<br/>";
            }
            if (!PageValidate.IsNumber(Request["txtLid"]))
            {
                strErr += "Lid格式错误！<br/>";
            }
            if (Request["txtRstartnumber"].Trim().Length == 0)
            {
                strErr += "本次记录开始编号不能为空！<br/>";
            }
            if (Request["txtRendnumber"].Trim().Length == 0)
            {
                strErr += "Rendnumber不能为空！<br/>";
            }
            if (Request["txtRprintnum"].Trim().Length==0)
            {
                strErr += "Rprintnum不能为空！<br/>";
            }
            if (Request["txtUid"].Trim().Length==0)
            {
                strErr += "用户id不允许为空<br/>";
            }
            if (strErr != "")
            {
                return Content("{\"result\":1,\"msg\":\""+strErr+"\"}");
            }
            int Pid = int.Parse(Request["txtPid"]);
            int Lid = int.Parse(Request["txtLid"]);
            string Rstartnumber = Request["txtRstartnumber"];
            string Rendnumber = Request["txtRendnumber"];
            int Rprintnum = int.Parse(Request["txtRprintnum"]);
            int Uid = int.Parse(Request["txtUid"]);
            string Spare1 = Request["txtSpare1"];
            string Spare2 = Request["txtSpare2"];
            string Spare3 = Request["txtSpare3"];

            Kit.Model.Rrecord model = new Kit.Model.Rrecord();
            model.Pid = Pid;
            model.Lid = Lid;
            model.Rstartnumber = Rstartnumber;
            model.Rendnumber = Rendnumber;
            model.Rprintnum = Rprintnum;
            model.Uid = Uid;
            model.Rdatetime=DateTime.Now;
            model.Spare1 = Spare1;
            model.Spare2 = Spare2;
            model.Spare3 = Spare3;

            Kit.BLL.Rrecord bll = new Kit.BLL.Rrecord();
            if (bll.Add(model)> 0)
            {
                Pagelog.UnitLog("prtlblog", "添加打印标签记录:"+model.Rdatetime+" /pid:"+model.Pid + " /Lid:" + model.Lid + " /startlabel:" +
                    model.Rstartnumber + " /endlabel:" + model.Rendnumber+ " /AddNum:" + model.Rprintnum, "测试数据");
                return Content("{\"result\":1,\"msg\":\"添加成功！\"}");

            }
            return Content("");
        }

        public string GetRoleLoopsMaxnum(string startnumber)
        {
            StringBuilder Str = new StringBuilder();
            for (int i = 0; i < startnumber.Length; i++)
            {
                Str.Append("9");
            }
            return Str.ToString();
        }
        public static string FormatRolelooplastnumber(int len, string number)
        {

            return (Int32.Parse(number) + 1).ToString().PadLeft(len, '0');
        }
        /// <summary>
        /// 返回标签打印记录
        /// </summary>
        /// <param name="lid">标签id</param>
        /// <param name="pid">产品id</param>
        /// <returns>返回打印记录列表</returns>
        public DataTable GetLabelPrtLog(string lid, string pid)
        {
            string sql = String.Format("select * from Rrecord where pid={0} and lid ={1} order by Rid desc", pid, lid);
            return DbHelperSQL.Query(sql).Tables[0];
        }
        public ActionResult ListEditAddRoleLog()
        {
            return View();
        }
    }
}