using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kit.Model;

namespace Kit.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            List<Ksystemset> Ksystemset = new List<Ksystemset>();
          ViewBag.Ksystemset = new BLL.Ksystemset().GetModelList("Stype='Icon'", "Skey2");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test() {
            ViewBag.Message = "This is Layui Test Dome";
            return View();
        }
    }
}