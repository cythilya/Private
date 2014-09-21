using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cythilya.Areas.EShopper.Controllers
{
    public class CartController : Controller
    {
        /*
        功能：
         * 1. 加入購物車 
         * 2. 購物車管理
         */
        //顯示目前購物車的項目
        public ActionResult Index()
        {
            return View();
        }

        //加入購物車
        [HttpPost]
        public ActionResult AddToCart(int ProductID, int Amount = 1)
        {
            return View();
        }

        //移除購物車項目
        [HttpPost]
        public ActionResult Remove()
        {
            return View();
        }

        //更新購物車中特定項目的購買數量
        [HttpPost]
        public ActionResult UpdateAmount(int ProductID, int NewAmount)
        {
            return View();        
        }
    }
}
