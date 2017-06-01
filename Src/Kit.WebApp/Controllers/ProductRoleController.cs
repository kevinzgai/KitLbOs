/*产品对应标签管理
 * 
 * 
 * 
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
    //产品标签管理
    public class ProductRoleController : Controller
    {
        // GET: ProductRole
        public ActionResult Index()
        {
            
            return View();
        }

        // post: ProductRole/AddRole 产品标签添加
        [HttpGet]
        public ActionResult AddRole(string pid)
        {

            if (!string.IsNullOrEmpty(pid))
            {
                Model.KProduce Kproduct = new KProduce();
                Kproduct = new BLL.KProduce().GetModel(int.Parse(pid));
                if (Kproduct == null)
                {
                    return Redirect("../Products");
                }
                ViewBag.Kproduct = Kproduct;
            }
            else
            {
                return Redirect("../Products");
            }

            List<Model.Ksystemset> MSysSet = new List<Ksystemset>();
            ViewBag.MSysSet = new BLL.Ksystemset().GetModelList(" Stype='LableRole'");

            return View();
        }
        [HttpGet]
        public ActionResult EditRole(string Rid)
        {
            if (!string.IsNullOrEmpty(Rid))
            {
                KlableroleBase roleBase = new KlableroleBase();
                roleBase = new BLL.KlableroleBase().GetModel(int.Parse(Rid));

                if (roleBase != null)
                {
                    ViewBag.MRoleBase = roleBase;
                }
            }

            return View();
        }

        //post :ProductRole/AddRoleaction
        /// <summary>
        /// 添加产品标签基本信息
        /// </summary>
        /// <param name="pid">产品id</param>
        /// <param name="Lname">标签名称</param>
        /// <param name="Lcontent">标签内容</param>
        /// <param name="Lcontentsate">标签内容说明</param>
        /// <param name="Llabletypeid">标签类型ID</param>
        /// <param name="Llabletypename">标签类型名称</param>
        /// <param name="LlableImg">标签图片</param>
        /// <param name="Llableloopid">标签循环规则ID</param>
        /// <param name="LProductid">产品id</param>
        /// <param name="Llableloopname">自定义循环名称</param>
        /// <param name="Startloopnum">循环开始号码</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddRoleaction(int pid, string Lname, string Lcontent, string Lcontentsate,
            string Llabletypeid, string Llabletypename, string LlableImg, int Llableloopid, string Llableloopname,
            string LProductid, string Startloopnum)
        {
            string Msg = "";
            Model.KlableroleBase MlableroleBase = new Model.KlableroleBase();
            if (Lname.Trim().Length == 0)
            {
                Msg += "标签名称不能为空！<br/>";
            }
            if (Lcontent.Trim().Length == 0)
            {
                Msg += "标签内容不能为空！<br/>";
            }
            if (Lcontentsate.Trim().Length == 0)
            {
                Msg += "标签内容说明不能为空！<br/>";
            }
            if (Llabletypeid.Trim().Length == 0)
            {
                Msg += "Llabletypeid不能为空！<br/>";
            }
            if (Llabletypename.Trim().Length == 0)
            {
                Msg += "Llabletypename不能为空！<br/>";
            }
            if (LlableImg.Trim().Length == 0)
            {
                Msg += "LlableImg不能为空！<br/>";
            }
            if (!PageValidate.IsNumber(Llableloopid.ToString()))
            {
                Msg += "循环规则表id格式错误！<br/>";
            }
            else if (Llableloopid.Equals(4))
            {

                if (Llableloopname.Trim().Length == 0)
                {
                    Msg += "循环名称不能为空！<br/>";
                }

            }

            switch (Llableloopid)
            {
                case 0:
                    Llableloopname = "无";
                    break;
                case 1:
                    Llableloopname = "年";
                    break;
                case 2:
                    Llableloopname = "月";
                    break;
                case 3:
                    Llableloopname = "周";
                    break;
            }
            if (Llableloopid > 0)
            {
                if (!PageValidate.IsNumber(Startloopnum))
                {
                    Msg += "标签长度不正确！<br/>";
                }
            }
            if (!PageValidate.IsNumber(LProductid))
            {
                Msg += "LProductid格式错误！<br/>";
            }
            if (Msg.Length > 0)
            {
                return Content("{\"result\":0,\"error\":\"" + Msg + "\"}");
            }
            else
            {

                MlableroleBase.Ltime = DateTime.Now;
                MlableroleBase.Lname = Lname;
                MlableroleBase.Lcontent = Lcontent;
                MlableroleBase.LProductid = pid;
                MlableroleBase.Lcontentsate = Lcontentsate;
                MlableroleBase.LlableImg = LlableImg;
                MlableroleBase.Llableloopid = Llableloopid;
                MlableroleBase.Llabletypeid = Llabletypeid;
                MlableroleBase.Llabletypename = Llabletypename;
                MlableroleBase.Llableloopname = Llableloopname;
                //执行标签基本信息添加  并且返回标签ID 唯一
                int labelid = new BLL.KlableroleBase().Add(MlableroleBase);
                JsonResult jes = new JsonResult();

                
                jes.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                //添加循环规则
                //如果Llableloopid（标签循环规则>0）的时候必须填写开始号码
                jes.Data = new BLL.KProduce().GetModel(pid);
                if (MlableroleBase.Llableloopid > 0)
                {
                    
                    AddLableRoleStarNum(labelid, Startloopnum);

                }
                return jes;
            }
        }

        /// <summary>
        /// 为标签添加循环规则
        /// </summary>
        /// <param name="Lid">标签ID</param>
        /// <param name="StartNum">开始标签号码</param>
        /// <returns></returns>
        public int AddLableRoleStarNum(int Lid, String StartNum)
        {
            Model.Klableroleloop Mlbloop = new Klableroleloop();
            Mlbloop.Lid = Lid;
            Mlbloop.Tlooprole = StartNum;
            Mlbloop.Ttime = DateTime.Now;
            return new BLL.Klableroleloop().Add(Mlbloop);
        }

        // get :ProductRole/editlabelrole
        /// <summary>
        /// 编辑标签
        /// </summary>
        /// <param name="lid">标签id</param>
        /// <param name="type">操作类型 del：删除 edit:编辑</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult editlabelrole(int lid, string type)
        {
            if (type.Equals("del"))
            {
                //删除操作
                try
                {
                    new BLL.KlableroleBase().Delete(lid);
                    new BLL.Klableroleloop().Delete(lid);
                    return Content("{\"result\":1}");
                }
                catch (Exception e)
                {
                    return Content("{\"result\":0,\"error\":\"" + e.ToString() + "\"}");
                }
                
            }
            else
            {
                //编辑操作 -获取一个标签
                return Content("{\"result\":0,\"error\":\"" + 0 + "\"}");
            }

        }


    }
}