using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cythilya.Areas.EShopper.Models;

namespace cythilya.Areas.EShopper.Controllers
{
    //[Authorize] //必須登入會雸才能使用訂單結帳功能
    public class OrderController : Controller
    {
        //顯示完成訂單的表單頁面
        public ActionResult Complete() 
        {
            return View();
        }

        //將訂單資料與購物車資料寫入資料庫
        [HttpPost]
        public ActionResult Complete(FormCollection form)
        {
            //TODO: 將訂單資料與購物車資料寫入資料庫

            //TODO: 訂單完成後清空目前購物車的資料

            //訂單完成後回到網站首頁
            return RedirectToAction("Index", "Home");
        }
    }
}
