using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Kit.Common;
using Kit.Model;

namespace Kit.WebApp.Controllers
{
    using Microsoft.Ajax.Utilities;

    public class ProductsController : Controller
    {
        //GET: Products  产品列表
        [HttpGet]
        public ActionResult Index(string Pnumber)
        {
            string ViewName = "Index";

            Kit.Model.Kuser Kuser = new Kuser();
            if (Session["User"] != null)
            {
                Kuser = Session["User"] as Model.Kuser;
                ViewName += Kuser.Urole.Trim();
            }
            else
            {
                Response.Redirect("~/Account/login");

                // RedirectToAction("login", "Account");

            }

            /*1.获取所有产品
             *2.根据获取的产品 取得该产品对应的所有标签
             */


            DataSet KproductTab = new DataSet();

            //下面是带产品参数id，获取单独产品
            if (!string.IsNullOrEmpty(Pnumber))//指定产品
            {
                if (Pnumber == "undefined")
                {
                    KproductTab = new BLL.KProduce().GetAllList();

                    ViewBag.prolisthtml = ProductTabToHtml(KproductTab, Kuser);
                }
                else
                {

                    string strWhere = " Pnumber='" + Pnumber + "'";

                    KproductTab = new BLL.KProduce().GetList(strWhere);

                    ViewBag.prolisthtml = ProductTabToHtml(KproductTab, Kuser);
                }

            }
            else
            {

                // ViewBag.prolisthtml = GetProductItem(new BLL.KlableroleBase().GetModelList();
                KproductTab = new BLL.KProduce().GetAllList();

                ViewBag.prolisthtml = ProductTabToHtml(KproductTab, Kuser);

            }
            ViewBag.User = Kuser;
            return View(ViewName);
        }
        //GET: Products/addproduct   
        //添加产品
        public ActionResult addproduct()
        {

            return View();
        }
        //GET: Products/addproduct   
        //添加产品
        [HttpPost]
        public ActionResult addproductaction()
        {
            Model.KProduce KProduce = new Model.KProduce();
            KProduce.Pimg = Request["newpicurl"];
            KProduce.Pname = Request["P_name"];
            KProduce.Pnumber = Request["P_num"];
            KProduce.Spare1 = Request["P_desc"];
            if (new BLL.KProduce().Add(KProduce) > 0)
            {
                return Json(KProduce);//添加成功
            }
            else
            {
                return Content("1");//添加失败
            }
        }
        //GET: Products/Editproduct   
        //编辑产品
        [HttpGet]
        public ActionResult Editproduct(string id)
        {
            Model.KProduce mProduce = new BLL.KProduce().GetModel(int.Parse(id));
            ViewBag.MProduct = mProduce;
            return View();

        }
        //GET: Products/Editproductaction   
        //添加产品
        [HttpPost]
        public ActionResult Editproductaction()
        {
            Model.KProduce KProduce = new Model.KProduce();
            KProduce.Pid = int.Parse(Request["pid"].Trim());
            KProduce.Pimg = Request["newpicurl"].Trim();
            KProduce.Pname = Request["P_name"].Trim();
            KProduce.Pnumber = Request["P_num"].Trim();
            KProduce.Spare1 = Request["P_desc"].Trim();
            if (new BLL.KProduce().Update(KProduce))
            {
                // return Json(KProduce);//修改成功
                //return RedirectToAction("Index", "Products",new { Pnumber = KProduce.Pnumber });
                return View("Index");
            }
            else
            {
                return Content("1");//添加失败
            }
        }

        /// <summary>
        /// 所有产品和产品标签列表html
        /// </summary>
        /// <param name="ProDataSet"></param>
        /// <returns></returns>
        private string ProductTabToHtml(DataSet ProDataSet, Model.Kuser Kuser)
        {
            StringBuilder StrHtml = new StringBuilder();
            if (ProDataSet.Tables.Count > 0)//判断是否获取到产品列表
            {
                foreach (DataRow Drow in ProDataSet.Tables[0].Rows)//遍历产品
                {
                    Model.KProduce Product = new BLL.KProduce().GetModel(int.Parse(Drow["Pid"].ToString()));
                    StrHtml.Append(GetProductItem(Product, Kuser));
                }
            }
            else
            {
                return "";
            }
            return StrHtml.ToString();

        }


        /// <summary>
        /// 返回所有产品列表
        /// </summary>
        /// <param name="Product">产品实例</param>
        /// <returns>返回列表html</returns>
        private string GetProductItem(Model.KProduce Product, Model.Kuser KUser)
        {

            string StrBtn = "<input type='button' class='layui-btn' onclick='btn.EditProduct(" + Product.Pid
                             + @")' name='name' value='编辑产品' />
                         <input type='button' class='layui-btn layui-btn-danger' onclick='btn.AddlableRole("
                             + Product.Pid + @")' name='name' value='添加标签' />";
            string linkname = "添加查看记录";//添加查看记录 - 链接名称
            switch (KUser.Urole.Trim())
            {
                case "A"://查看标签记录
                    StrBtn = "";
                    linkname = "查看标签记录";
                    break;
                case "B"://添加标签记录
                    StrBtn = "<input type='button' class='layui-btn layui-btn-danger' onclick='btn.AddlableRole("
                          + Product.Pid + @")' name='name' value='添加标签' />";
                    break;
                case "C":
                    StrBtn = "<input type='button' class='layui-btn' onclick='btn.EditProduct(" + Product.Pid
                              + @")' name='name' value='编辑产品' />
                         <input type='button' class='layui-btn layui-btn-danger' onclick='btn.AddlableRole("
                              + Product.Pid + @")' name='name' value='添加标签' />";
                    break;
                default:
                    Response.Write("没有号数");
                    break;
            }
            List<Model.KlableroleBase> listLableBases = new BLL.KlableroleBase().GetModelList("LProductid='" + Product.Pid + "'");//获取产品标签列表

            StringBuilder listLable = new StringBuilder();
            for (int i = 0; i < listLableBases.Count; i++)
            {
                Model.KlableroleBase MlableBase = listLableBases[i];
                string shoulog = MlableBase.Llableloopid > 0 ? "<i class='layui-icon'>&#xe62a;<a onclick='btn.AddlableRoleLog(" + MlableBase.LProductid + "," + MlableBase.Lid + @")' style='color:orange'>"+ linkname + @"</a></i>" : "";
                listLable.Append(@"<tr> <td>  " + (i + 1).ToString("00") + @" </td> <td> " + MlableBase.Lname + @" </td> <td> " + MlableBase.Lcontent + @" </td> <td>
                      " + shoulog + @" </td> <td> <i class='layui-icon' onclick='tool.edit(" + MlableBase.Lid + @")'> &#xe642; </i><i class='layui-icon' onclick='tool.del(" + MlableBase.Lid + @")'> &#xe640; </i> </td></tr>");
            }
           
            string StrItem = @"<div class='layui-form-item product-item'>
	                <img src='" + Product.Pimg + @"'/>
	                <div class='div-title'>
		              <label>产品名称：</label><b>" + Product.Pname + @"</b><br/>
		              <label>产品编号：</label><b>" + Product.Pnumber + @"</b><br/>
		              <label>产品介绍：</label><p class='pppp'><small>" + Product.Spare1 + @"</small>
		                </p></div><div>" + StrBtn + @"</div>
                <table class='layui-table' lay-skin='line'> <colgroup><col width='20'><col width='150'><col width='250'><col width='90'><col width='30'></colgroup>
	                <thead> <tr> <th> 序号 </th> <th> 标签标题 </th> <th> 标签内容 </th> <th> 标签操作 </th><th> 操作 </th> </tr> </thead> <tbody>
		         " + listLable + @"</tbody> </table></div>";
            return StrItem;
        }


    }
}