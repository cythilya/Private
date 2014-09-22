using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cythilya.Areas.EShopper.Models;

namespace cythilya.Areas.EShopper.Controllers
{
    public class HomeController : Controller
    {
        //首頁
        public ActionResult Index()
        {
            #region fake data - product category
            var data = new List<ProductCategory>()
            {
                new ProductCategory() { ID = 1, Name = "WOMENS"},
                new ProductCategory() { ID = 2, Name = "MENS"},
                new ProductCategory() { ID = 3, Name = "KIDS"},
                new ProductCategory() { ID = 4, Name = "SPORTSWEAR"},
                new ProductCategory() { ID = 5, Name = "FASHION"},
                new ProductCategory() { ID = 6, Name = "HOUSEHOLDS"},
                new ProductCategory() { ID = 7, Name = "INTERIORS"},
                new ProductCategory() { ID = 8, Name = "CLOTHING"},
                new ProductCategory() { ID = 9, Name = "BAGS"},
                new ProductCategory() { ID = 10, Name = "SHOES"}
            };
            #endregion

            return View(data);
        }

        //商品列表
        public ActionResult Category()
        {
            #region fake data - product category
            var data = new List<ProductCategory>()
            {
                new ProductCategory() { ID = 1, Name = "WOMENS"},
                new ProductCategory() { ID = 2, Name = "MENS"},
                new ProductCategory() { ID = 3, Name = "KIDS"},
                new ProductCategory() { ID = 4, Name = "SPORTSWEAR"},
                new ProductCategory() { ID = 5, Name = "FASHION"},
                new ProductCategory() { ID = 6, Name = "HOUSEHOLDS"},
                new ProductCategory() { ID = 7, Name = "INTERIORS"},
                new ProductCategory() { ID = 8, Name = "CLOTHING"},
                new ProductCategory() { ID = 9, Name = "BAGS"},
                new ProductCategory() { ID = 10, Name = "SHOES"}
            };
            #endregion

            #region fake data - product
            var productCategory = new ProductCategory(){ID = 1, Name = "WOMENS"};
            
            var tag = new Tag(){ ID = 1, Name = "New Arrival"};
            var tagList = new List<Tag>();
            tagList.Add(tag);

            var ProductList = new List<Product>()
            {
                new Product()
                {
                    ID = 1, 
                    Name = "Easy Polo Black Edition",
                    ProductCategory = productCategory,
                    Description = "",
                    RawPicUrl = "",
                    PicLargeUrl = "",
                    PicMediumUrl = "/Content/eshopper/images/home/product1.jpg",
                    PicSmallUrl = "",
                    PublishOn = DateTime.UtcNow,
                    Brand = "",
                    BrandInfo = "",
                    Tags = tagList,
                    Price = 99,
                    Amount = 99,
                    IsSale = false,
                    IsHigLight = true
                },
                new Product()
                {
                    ID = 2, 
                    Name = "Easy Polo Black Edition",
                    ProductCategory = productCategory,
                    Description = "",
                    RawPicUrl = "",
                    PicLargeUrl = "",
                    PicMediumUrl = "/Content/eshopper/images/home/product3.jpg",
                    PicSmallUrl = "",
                    PublishOn = DateTime.UtcNow,
                    Brand = "",
                    BrandInfo = "",
                    Tags = tagList,
                    Price = 99,
                    Amount = 99,
                    IsSale = false,
                    IsHigLight = false
                },
                new Product()
                {
                    ID = 3, 
                    Name = "Easy Polo Black Edition",
                    ProductCategory = productCategory,
                    Description = "",
                    RawPicUrl = "",
                    PicLargeUrl = "",
                    PicMediumUrl = "/Content/eshopper/images/home/product6.jpg",
                    PicSmallUrl = "",
                    PublishOn = DateTime.UtcNow,
                    Brand = "",
                    BrandInfo = "",
                    Tags = tagList,
                    Price = 99,
                    Amount = 99,
                    IsSale = true,
                    IsHigLight = false
                }
            };
            #endregion

            ViewBag.ProductList = ProductList;
            return View(data);
        }

        //商品明細
        public ActionResult Product()
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
