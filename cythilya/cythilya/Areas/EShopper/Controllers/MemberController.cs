using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using cythilya.Areas.EShopper.Models;
using System.Net.Mail;

namespace cythilya.Areas.EShopper.Controllers
{
    public class MemberController : Controller
    {
        MvcShoppingContext db = new MvcShoppingContext();

        //會員註冊驗頁面
        public ActionResult Register()
        {
            return View();
        }

        //密碼雜湊所需的Salt亂數值
        private string pwSalt = "AlrySqloPe2Mh784QQwG6jRAfkdPpDa90J0i";

        //寫入會員資料
        [HttpPost]
        public ActionResult Register([Bind(Exclude = "RegisterOn, AuthCode")] Member member)
        {
            //檢查會員是否存在
            var chk_member = db.Members.Where(p => p.Account == member.Account).FirstOrDefault();

            if (chk_member != null)
            {
                ModelState.AddModelError("Account", "This account has been registered. Please enter another one or login.");
            }

            if (ModelState.IsValid)
            {
                //將密碼加鹽後進行雜湊運算,以提升會員密碼的安全性
                member.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(pwSalt + member.Password, "SHA1");

                //會員註冊時間
                member.RegisterOn = DateTime.UtcNow;

                //會員驗證碼,採用GUID當成驗證碼的內容,避免使用到重覆的驗證碼
                member.AuthCode = Guid.NewGuid().ToString();

                db.Members.Add(member);
                db.SaveChanges();

                SendAuthCodeToMember(member);

                return RedirectToAction("Index", "Home");
            }
            else 
            {
                return View();
            }
        }

        private void SendAuthCodeToMember(Member member)
        {
            string mailBody = System.IO.File.ReadAllText(Server.MapPath("/App_Data/MemberRegisterEmailTemplate.html"));

            mailBody = mailBody.Replace("{{Name}}", member.Name);
            //mailBody = mailBody.Replace("{{RegisterOn}}", member.RegisterOn.ToString());
            var auth_url = new UriBuilder(Request.Url)
            {
                Path = Url.Action("ValidateRegister", new { id = member.AuthCode }),
                Query = ""
            };
            mailBody = mailBody.Replace("{{AUTH_URL}}", auth_url.ToString());

            try
            {
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("eshoppertw@gmail.com", "liardice.,1024");
                SmtpServer.EnableSsl = true;

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("eshoppertw@gmail.com");
                mail.To.Add(member.Email);
                mail.Subject = "EShopper Account Confirmation";
                mail.Body = mailBody;
                mail.IsBodyHtml = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
            var hash_pw = FormsAuthentication.HashPasswordForStoringInConfigFile(pwSalt + password, "SHA1");

            var member = (from p in db.Members where p.Account == account && p.Password == hash_pw select p).FirstOrDefault();

            return (member != null);
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
