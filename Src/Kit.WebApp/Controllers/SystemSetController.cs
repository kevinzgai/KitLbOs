using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Kit.Model;
using Kit.Common;

namespace Kit.WebApp.Controllers
{
    public class SystemSetController : Controller
    {
        // GET: SystemSet
        public ActionResult Index()
        {
            return View();
        }
        // GET: SystemSet/AddLableRole  条码格式 列表
        public ActionResult AddLableRole()
        {
            string Templist = @"<tr><td>{No}</td><td>{Name}</td><td>{Des}</td><td class='edit-i'><i class='layui-icon' onclick='Btn.edit({id})'>&#xe642;</i><i class='layui-icon' onclick='Btn.del({id})'>&#xe640;</i></td></tr>";
            StringBuilder listhtml = new StringBuilder();
            List<Model.Ksystemset> listSysSet = new BLL.Ksystemset().GetModelList("Stype='LableRole'");

            for (int i = 0; i < listSysSet.Count; i++)
            {
                string strtmp = Templist;
                strtmp = strtmp.Replace("{No}", (i + 1).ToString());
                strtmp = strtmp.Replace("{Name}", listSysSet[i].Sname);
                strtmp = strtmp.Replace("{Des}", listSysSet[i].Svalue);
                strtmp = strtmp.Replace("{id}", listSysSet[i].Sid.ToString());
                listhtml.Append(strtmp);
            }
            ViewBag.listhtml = listhtml;
            return View();
        }
        // GET: SystemSet/AddLableRoleaction  条码格式 列表
        [HttpPost]
        public ActionResult AddLableRoleaction(String Name, string Des)
        {
            Model.Ksystemset MsystemSet = new Ksystemset();
            MsystemSet.Stype = "LableRole";
            MsystemSet.Sname = Name;
            MsystemSet.Svalue = Des;
            int ExtRow = new BLL.Ksystemset().Add(MsystemSet);
            if (ExtRow > 0)
            {
                return Content("{\"result\":true,\"id\":" + ExtRow + "}");
            }
            else
            {
                return Content("{\"result\":false,\"id\":" + ExtRow + "}");
            }

        }
        // GET: SystemSet/AddLableRoleEditaction  条码格式 列表
        [HttpPost]
        public ActionResult AddLableRoleEditaction(int Sid,String Name, string Des)
        {
            Model.Ksystemset MsystemSet = new Ksystemset();
            MsystemSet.Stype = "LableRole";
            MsystemSet.Sname = Name;
            MsystemSet.Svalue = Des;
            MsystemSet.Sid = Sid;
            if (new BLL.Ksystemset().Update(MsystemSet))
            {
                return Content("{\"result\":true,\"msg\":\"修改成功\"}");
            }
            else
            {
                return Content("{\"result\":false,\"msg\":\"修改失败\"}");
            }

        }

        // GET: SystemSet/AddLableRoledelaction  条码格式 列表
        [HttpPost]
        public ActionResult AddLableRoledelaction(int Sid)
        {
            if (new BLL.Ksystemset().Delete(Sid))
            {
                return Content("{\"result\":true,\"msg\":\"删除成功\"}");
            }
            else
            {
                return Content("{\"result\":false,\"msg\":\"删除失败\"}");
            }

        }
        // post: SystemSet/getLableRole 获取单个条码格式
        [HttpPost]
        public ActionResult getLableRole(string id)
        {
           Model.Ksystemset MSysSet = new BLL.Ksystemset().GetModel(int.Parse(id.ToString()));
            JsonResult jso = new JsonResult();
            jso.Data = MSysSet;
            jso.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return jso;
        }

        /// <summary>
        /// // post: SystemSet/getLableRole 获取条码格式列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult getLableRole()
        {

            List<Model.Ksystemset> MSysSet = new List<Ksystemset>();
            MSysSet=new BLL.Ksystemset().GetModelList(" Stype='LableRole'");
            JsonResult jso = new JsonResult();
            jso.Data = MSysSet;
            jso.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return jso;

        }



        // GET: SystemSet/AddHomeIcon
        public ActionResult AddHomeIcon()
        {
            ViewBag.Title = "添加新图标";
            ViewBag.Ksystemset = null;

            Model.Ksystemset M_Ksystemset = new Ksystemset();
            //demo <option value="layer">layer</option>
            string Stroption = "";
            List<Model.Ksystemset> Ksystemset = new BLL.Ksystemset().GetModelList("Stype='Icon'");//所有数据
            List<Model.Ksystemset> tmpKsystemsets = new List<Ksystemset>();//新容器
            foreach (var ksystemset in Ksystemset)
            {
                if (!getKsystemsets(tmpKsystemsets, ksystemset))
                {
                    tmpKsystemsets.Add(ksystemset);
                }
            }

            for (int i = 0; i < tmpKsystemsets.Count; i++)
            {

                Stroption += string.Format("<option value='{0}'>{0}</option>", tmpKsystemsets[i].Skey2);
            }
            //判断是否编辑
            if (this.Request["Sid"] != null)
            {
                ViewBag.Title = "修改图标";
                Response.Write("正在编辑Sid" + Request["Sid"].Trim());
                M_Ksystemset = new BLL.Ksystemset().GetModel(int.Parse(Request["Sid"].Trim()));

            }

            ViewBag.Ksystemset = M_Ksystemset;
            ViewBag.WindowTitle = Stroption;
            return View();
        }



        // post: SystemSet/AddHomeIconAction
        /// <summary>
        /// 修改删除二合一
        /// </summary>
        /// <param name="Sid">修改时Sid>0</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddHomeIconAction(int Sid)
        {
            Sid = int.Parse(Request["Sid"]);
            if (Sid < 1)
            {
                string strErr = "";
                string result = "";
                if (this.Request["txtStype"] == null)
                {
                    strErr += "请不要非法操作/n";
                }
                if (this.Request["txtSname"] == null)
                {
                    strErr += "标题非法！/n";
                }
                if (this.Request["txtSvalue"] == null)
                {
                    strErr += "链接地址非法！/n";
                }
                if (this.Request["txtSkey1"] == null)
                {
                    strErr += "图标地址非法！/n";
                }
                if (this.Request["windowtitle"] == null)
                {
                    strErr += "窗口名称非法！/n";
                }

                if (strErr != "")
                {
                    result = "{\"result\":0,\"msg\":\"";
                    result += strErr;
                    result += "\"}";

                    return Content(result);
                }
                string Stype = this.Request["txtStype"];
                string Sname = this.Request["txtSname"];
                string Svalue = this.Request["txtSvalue"];
                string Skey1 = this.Request["txtSkey1"];
                string Skey2 = this.Request["windowtitle"];

                Kit.Model.Ksystemset model = new Kit.Model.Ksystemset();
                model.Stype = Stype;
                model.Sname = Sname;
                model.Svalue = Svalue;
                model.Skey1 = Skey1;
                model.Skey2 = Skey2;

                Kit.BLL.Ksystemset bll = new Kit.BLL.Ksystemset();
                bll.Add(model);
                return Content("{\"result\":1}", "text");
            }
            else
            {
                //修改操作

                string strErr = "";
                string result = "";
                if (this.Request["txtStype"] == null)
                {
                    strErr += "请不要非法操作/n";
                }
                if (this.Request["txtSname"] == null)
                {
                    strErr += "标题非法！/n";
                }
                if (this.Request["txtSvalue"] == null)
                {
                    strErr += "链接地址非法！/n";
                }
                if (this.Request["txtSkey1"] == null)
                {
                    strErr += "图标地址非法！/n";
                }
                if (this.Request["windowtitle"] == null)
                {
                    strErr += "窗口名称非法！/n";
                }

                if (strErr != "")
                {
                    result = "{\"result\":0,\"msg\":\"";
                    result += strErr;
                    result += "\"}";

                    return Content(result);
                }
                string Stype = this.Request["txtStype"];
                string Sname = this.Request["txtSname"];
                string Svalue = this.Request["txtSvalue"];
                string Skey1 = this.Request["txtSkey1"];
                string Skey2 = this.Request["windowtitle"];


                Kit.Model.Ksystemset model = new Kit.Model.Ksystemset();
                model.Sid = Sid;
                model.Stype = Stype;
                model.Sname = Sname;
                model.Svalue = Svalue;
                model.Skey1 = Skey1;
                model.Skey2 = Skey2;

                Kit.BLL.Ksystemset bll = new Kit.BLL.Ksystemset();
                if (bll.Update(model))
                {
                    return Content("{\"result\":\"1\",\"msg\":\"修改成功\"}");
                }
                else
                {

                    return Content("{\"result\":\"0\",\"msg\":\"修改失败\"}");
                }
            }
        }

        //SystemSet/EditHomeIcon
        [HttpGet]
        public ActionResult EditHomeIcon(int Sid)
        {
            if (Request["type"].Equals("del"))
            {
                Sid = int.Parse(Request["Sid"]);
                if (Sid > 0)
                {
                    if (new BLL.Ksystemset().Delete(Sid))
                    {
                        return Content("{\"result\":\"1\",\"msg\":\"修改成功\"}");
                    }
                    else
                    {
                        return Content("{\"result\":\"0\",\"msg\":\"修改失败\"}");
                    }
                }
                else
                {
                    return Content("{\"result\":\"0\",\"msg\":\"修改失败\"}");
                }
            }
            else
            {
                return Content("非删除操作！");
            }
        }
        // GET: SystemSet/HomeIconList
        public ActionResult HomeIconList()
        {
            return View();
        }
        
        public ActionResult GetResult()
        {
            List<Ksystemset> Ksystemset = new List<Ksystemset>();

            Ksystemset = new BLL.Ksystemset().GetModelList("Stype='Icon'", "Skey2");
            var res = new JsonResult();
            res.Data = Ksystemset;
            res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return res;
        }

        /// <summary>
        /// 判断该实例中是否包含Key2 字段
        /// </summary>
        /// <param name="LKsystemset"></param>
        /// <param name="MKsystemset"></param>
        /// <returns></returns>
        private bool getKsystemsets(List<Model.Ksystemset> LKsystemset, Model.Ksystemset MKsystemset)
        {
            foreach (var VARIABLE in LKsystemset)
            {
                if (MKsystemset.Skey2 == VARIABLE.Skey2)
                {
                    return true;
                }
            }
            return false;
        }


    }
}