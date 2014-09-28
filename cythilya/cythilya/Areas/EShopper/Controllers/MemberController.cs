using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using cythilya.Areas.EShopper.Models;

namespace cythilya.Areas.EShopper.Controllers
{
    public class MemberController : Controller
    {
        //會員註冊驗頁面
        public ActionResult Register()
        {
            return View();
        }

        //寫入會員資料
        [HttpPost]
        public ActionResult Register([Bind(Exclude = "RegisterOn")] Member member)
        {
            return RedirectToAction("Index", "Home");
            //return View();
        }

        //顯示會員登入頁面
        public ActionResult Login([Bind(Exclude = "RegisterOn")] Member member, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //執行會員登入
        [HttpPost]
        public ActionResult Login(string account, string password, string returnUrl) 
        {
            if (ValidateUser(account, password))
            {
                FormsAuthentication.SetAuthCookie(account, false);

                if (String.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                else 
                {
                    return Redirect(returnUrl);
                }
            }
            ModelState.AddModelError("", "您輸入的帳號或密碼有誤，請重新再試一次。");
            return View();
        }

        private bool ValidateUser(string account, string password)
        {
            return true;
            //throw new NotImplementedException();
        }

        //執行會員登出
        public JsonResult Logout() 
        {
            //清除表單驗證的cookie
            FormsAuthentication.SignOut();

            //清除所有曾經寫入的session資料
            Session.Clear();

            //登出後回到首頁
            var jsonObject = new { IsSuccess = true, ErrorMessage = "", ReturnData = "" };
            return Json(jsonObject);
        }
    }
}
