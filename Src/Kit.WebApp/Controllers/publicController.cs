using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kit.WebApp.Controllers
{
    public class publicController : Controller
    {
        // GET: public
        public ActionResult Index()
        {
            return View();
        }
        //public/Upload  
        [HttpPost]
        public JsonResult Upload(HttpPostedFileBase upImg)
        {
            upImg = Request.Files[0];
            if (string.IsNullOrEmpty(upImg.FileName)
                 )
            {
                return Json(new
                {
                    pic = "无图片",
                    error = "空"

                });
            }
            string fileName = System.IO.Path.GetFileName(upImg.FileName);
            string filePhysicalPath = Server.MapPath("~/upload/" + fileName);
            string pic = "", error = "";
            try
            {
                upImg.SaveAs(filePhysicalPath);
                pic = "/upload/" + fileName;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return Json(new
            {
                pic = pic,
                error = error
            });
        }
        [HttpPost]
        public JsonResult Uploadicon(HttpPostedFileBase upImg)
        {
            upImg = Request.Files[0];
            if (string.IsNullOrEmpty(upImg.FileName)
            )
            {
                return Json(new
                {
                    pic = "无图片",
                    error = "空"

                });
            }
            string fileName = System.IO.Path.GetFileName(upImg.FileName);
            string filePhysicalPath = Server.MapPath("~/upload/icon/" + fileName);
            string pic = "", error = "";
            try
            {
                upImg.SaveAs(filePhysicalPath);
                pic = "/upload/icon/" + fileName;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return Json(new
            {
                src = pic,
                error = error
            });
        }
        //public/Uploadlableimg
        [HttpPost]
        public JsonResult Uploadlableimg(HttpPostedFileBase upImg)
        {
            upImg = Request.Files[0];
            if (string.IsNullOrEmpty(upImg.FileName)
            )
            {
                return Json(new
                {
                    pic = "无图片",
                    error = "空"

                });
            }
            string fileName = System.IO.Path.GetFileName(upImg.FileName);
            string filePhysicalPath = Server.MapPath("~/upload/lable/" + fileName);
            string pic = "", error = "";
            try
            {
                upImg.SaveAs(filePhysicalPath);
                pic = "/upload/lable/" + fileName;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return Json(new
            {
                src = pic,
                error = error
            });
        }
    }
}