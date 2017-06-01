/**
 * 
 * 系统日志文件
 * 
 * 
 * kevin  2017年5月27日15:31:04
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kit.Common;
using Kit.Model;

namespace Kit.WebApp.Controllers
{
    public class SysLogController : Controller
    {
        // GET: SysLog
        public ActionResult Index(string id)
        { List<Model.Alllog> MLog = new List<Alllog>();
            string strwhere = "";
            if (!string.IsNullOrEmpty(id))
            {
                strwhere = " Atype='"+id.Trim()+"'";
            }
             if ("0".Equals(id))
            {
                strwhere = "";
            }
            object aa = new BLL.Alllog().GetModelList(strwhere).OrderByDescending(T=>T.Atime);
            ViewBag.Model = aa;
            return View();
        }
    }

    public static class Pagelog
    {

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="content">日志内容</param>
        /// <param name="Astate">日志说明</param>
        /// <param name="Atype">日志类型</param>
        public static void UnitLog(string Atype, string content, string Astate)
        {
            object Uid = DataCache.GetCache("uid");
            try
            {
                Model.Alllog MLog = new Alllog();
                MLog.Acontent = content;//记录内容
                MLog.Astate = Astate;//备注说明
                MLog.Atype = Atype;//日志类型
                MLog.Uid = int.Parse(Uid==null?"0":Uid.ToString());//操作用户

                new BLL.Alllog().Add(MLog);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }
    }
}