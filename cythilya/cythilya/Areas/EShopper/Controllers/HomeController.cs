using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cythilya.Areas.EShopper.Controllers
{
    public class HomeController : Controller
    {
        //首頁
        public ActionResult Index()
        {
            return View();
        }

        //商品列表
        public ActionResult ProductList()
        {
            return View();
        }

        //商品明細
        public ActionResult ProductDetail() 
        {
            return View();
        }

        //404
        public ActionResult NotFound()
        {
            return View();
        }

        //Contact
        public ActionResult Contact()
        {
            return View();
        }
    }
}
