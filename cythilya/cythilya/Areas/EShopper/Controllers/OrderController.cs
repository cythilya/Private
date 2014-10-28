using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cythilya.Areas.EShopper.Models;

namespace cythilya.Areas.EShopper.Controllers
{
    //[Authorize] //必須登入會雸才能使用訂單結帳功能
    public class OrderController : BaseController
    {
        //顯示完成訂單的表單頁面
        public ActionResult Complete() 
        {
            var member = db.Members.Where(p => p.Account == User.Identity.Name).FirstOrDefault();

            //若使用者尚未註冊,將使用者導向註冊畫面
            if (member == null)
            {
                return RedirectToAction("Register", "Member");
            }

            //取得已註冊使用者的資料
            if (User.Identity.IsAuthenticated)
            {
                GetMemberInfo(User.Identity.Name);
            }
            return View();
        }

        //將訂單資料與購物車資料寫入資料庫
        public ActionResult CompleteOrder(string Account, string Email, string ShipperName, string ShipperAddress, string ShipperMobile)
        {
            var member = db.Members.Where(p => p.Account == User.Identity.Name).FirstOrDefault();
            var jsonObject = new { IsSuccess = true, ErrorMessage = "", ReturnData = "" };

            //購物車若無需要結帳的商品,回傳錯誤訊息給使用者
            if (this.Carts.Count == 0) 
            {
                //訂單失敗
                jsonObject = new { IsSuccess = false, ErrorMessage = "Cart is empty. Nothing needs to checkout.", ReturnData = "" };
                return Json(jsonObject);
            }

            //將訂單資料與購物車資料寫入資料庫
            OrderHeader oh = new OrderHeader() 
            {
                Member = member,
                ContactName = ShipperName,
                ContactPhone = ShipperMobile,
                ContactAddress = ShipperAddress,
                TotalPrice = 0,
                BuyOn = DateTime.UtcNow,
                Memo = "已結帳；",
                //OrderDetailItems = new List<OrderDetail>()
            };

            int total_price = 0;

            foreach (var item in this.Carts)
            {
                var product = db.Products.Find(item.Product.ID);
                
                if (product == null)
                {
                    //無存貨,回到購物車,請使用者修正品項
                    return RedirectToAction("Index", "Cart");
                }

                total_price += item.Product.Price * item.Amount;

                oh.Memo = oh.Memo + "Product ID：" + item.Product.ID + "；" + "Product Name：" + item.Product.Name + "；" + "Amount：" + item.Amount + "。";

                //oh.OrderDetailItems.Add(new OrderDetail() { Product = product, Price = product.Price/*, Amount = item.Amount*/ });
            }

            oh.TotalPrice = total_price;
            db.Orders.Add(oh);
            db.SaveChanges();

            //訂單完成後清空目前購物車的資料
            this.Carts.Clear();

            //訂單完成
            jsonObject = new { IsSuccess = true, ErrorMessage = "", ReturnData = "" };
            return Json(jsonObject);
        }

        //取得已註冊使用者的資料
        void GetMemberInfo(string account) 
        {
            var member = db.Members.Where(p => p.Account == User.Identity.Name).FirstOrDefault();

            var memberInfo = new Member()
            {
                ID = member.ID,
                Account = member.Account,
                Email = member.Email,
                Name = member.Name
            };

            ViewBag.MemberInfo = memberInfo;
        }
    }
}
