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
            //取得已註冊使用者的資料
            if (User.Identity.IsAuthenticated)
            {
                GetMemberInfo(User.Identity.Name);
            }
            return View();
        }

        //將訂單資料與購物車資料寫入資料庫
        [HttpPost]
        public ActionResult Complete(string Account, string Email, string Password, string ShipperName, string ShipperAddress, string ShipperMobile)
        {
            //TODO: 將訂單資料與購物車資料寫入資料庫

            //TODO: 訂單完成後清空目前購物車的資料

            //訂單完成
            var jsonObject = new { IsSuccess = true, ErrorMessage = "", ReturnData = "" };
            return Json(jsonObject);
        }

        //取得已註冊使用者的資料
        void GetMemberInfo(string account) 
        {
            #region fake data
            var memberInfo = new Member()
            {
                ID = 123456789,
                Account = account,
                Email = "cythilya@gmail.com",
                Name = "Hsin-Hao Tang"
            };
            #endregion

            ViewBag.MemberInfo = memberInfo;
        }
    }
}
