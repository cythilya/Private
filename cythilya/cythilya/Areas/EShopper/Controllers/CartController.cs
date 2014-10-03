using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cythilya.Areas.EShopper.Models;

namespace cythilya.Areas.EShopper.Controllers
{
    public class CartController : Controller
    {
        //On*6
        /*
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
         * */

        MvcShoppingContext db = new MvcShoppingContext();

        List<Cart> Carts
        {
            get 
            {
                if (Session["Carts"] == null)
                {
                    Session["Carts"] = new List<Cart>();
                }
                return (Session["Carts"] as List<Cart>);
            }
            set { Session["Carts"] = value; }
        
        }

        /*
        功能：
         * 1. 加入購物車 
         * 2. 購物車管理
         */
        //顯示目前購物車的項目
        public ActionResult Index()
        {
            #region fake data - product
            /*
            var productCategory = new ProductCategory() { ID = 1, Name = "WOMENS" };

            var tag = new Tag() { ID = 1, Name = "New Arrival" };
            var tagList = new List<Tag>();
            tagList.Add(tag);

            Product item1 = new Product(){
                ID = 1,
                Name = "Easy Polo Black Edition",
                ProductCategory = productCategory,
                Description = "",
                RawPicUrl = "",
                PicLargeUrl = "",
                PicMediumUrl = "/Content/eshopper/images/home/product1.jpg",
                PicSmallUrl = "/Content/eshopper/images/product-details/similar1.jpg",
                PublishOn = DateTime.UtcNow,
                Brand = "",
                BrandInfo = "",
                Tags = tagList,
                Price = 99,
                Amount = 99,
                IsSale = false,
                IsHigLight = true            
            };

            Product item2 = new Product() {
                ID = 2,
                Name = "Easy Polo Black Edition",
                ProductCategory = productCategory,
                Description = "",
                RawPicUrl = "",
                PicLargeUrl = "",
                PicMediumUrl = "/Content/eshopper/images/home/product3.jpg",
                PicSmallUrl = "/Content/eshopper/images/product-details/similar2.jpg",
                PublishOn = DateTime.UtcNow,
                Brand = "",
                BrandInfo = "",
                Tags = tagList,
                Price = 99,
                Amount = 99,
                IsSale = false,
                IsHigLight = false            
            };
            
            

            var data = new List<Cart>() 
            { 
                new Cart()
                {
                    Product = item1,
                    Amount = 2
                },
                new Cart()
                {
                    Product = item2,
                    Amount = 1
                }
            };
            */
            #endregion

            return View(this.Carts);
        }

        //加入購物車
        [HttpPost]
        public ActionResult AddToCart(int ProductID, int Amount = 1)
        {
            var product = db.Products.Find(ProductID);
            var jsonObject = new { IsSuccess = false, ErrorMessage = "", ReturnData = "" };

            if (product == null)
            {
                //return HttpNotFound();
                jsonObject = new { IsSuccess = false, ErrorMessage = "Product is not found.", ReturnData = "" };
            }
            else 
            {
                var existingCart = this.Carts.FirstOrDefault(p => p.Product.ID == ProductID);

                if (existingCart != null)
                {
                    existingCart.Amount += 1;
                }
                else
                {
                    this.Carts.Add(new Cart() { Product = product, Amount = Amount });
                }
                jsonObject = new { IsSuccess = true, ErrorMessage = "", ReturnData = "" };
            }
            
            return Json(jsonObject);
        }

        //移除購物車項目
        [HttpPost]
        public JsonResult Remove(int ID = 0)
        {
            var existingCart = this.Carts.FirstOrDefault(p => p.Product.ID == ID);
            var jsonObject = new { IsSuccess = false, ErrorMessage = "", ReturnData = "" };

            if (existingCart != null)
            {
                this.Carts.Remove(existingCart);
                jsonObject = new { IsSuccess = true, ErrorMessage = "", ReturnData = "" };
            }
            else 
            {
                jsonObject = new { IsSuccess = false, ErrorMessage = "Remove item failed.", ReturnData = "" };
            }
            return Json(jsonObject);
        }

        //更新購物車中特定項目的購買數量
        [HttpPost]
        public ActionResult UpdateAmount(int ProductID, int NewAmount)
        {
            return View();        
        }
    }
}
