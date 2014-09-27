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
                new ProductCategory() { ID = 5, Name = "HOUSEHOLDS"},
                new ProductCategory() { ID = 6, Name = "BAGS & SHOES"}
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
                new ProductCategory() { ID = 5, Name = "HOUSEHOLDS"},
                new ProductCategory() { ID = 6, Name = "BAGS & SHOES"}

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
            ViewBag.Category = data;
            return View(data);
        }

        //商品明細
        public ActionResult Product()
        {
            #region fake data - product category
            var data = new List<ProductCategory>()
            {
                new ProductCategory() { ID = 1, Name = "WOMENS"},
                new ProductCategory() { ID = 2, Name = "MENS"},
                new ProductCategory() { ID = 3, Name = "KIDS"},
                new ProductCategory() { ID = 4, Name = "SPORTSWEAR"},
                new ProductCategory() { ID = 5, Name = "HOUSEHOLDS"},
                new ProductCategory() { ID = 6, Name = "BAGS & SHOES"}
            };
            #endregion

            #region fake data - product detail

            var productCategory = new ProductCategory(){ID = 1, Name = "WOMENS"};
            
            var tag = new Tag(){ ID = 1, Name = "New Arrival"};
            var tagList = new List<Tag>();
            tagList.Add(tag);

            var Detail = new Product() 
            { 
                ID = 1,
                Name = "Easy Polo Black Edition",
                ProductCategory = productCategory,
                Description = "Easy Polo Black Edition",
                RawPicUrl = "/Content/eshopper/images/temp_329x380.png",
                PicLargeUrl = "/Content/eshopper/images/temp_329x380.png",
                PicMediumUrl = "/Content/eshopper/images/temp_255x381.png",
                PicSmallUrl = "/Content/eshopper/images/temp_85x84.png",
                PublishOn = DateTime.UtcNow,
                Brand = "E-Shopper",
                BrandInfo = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.", 
                Tags = tagList,
                Price = 999,
                Amount = 99,
                IsSale = false,
                IsHigLight = true 
            };

            #endregion

            ViewBag.ProductDetail = Detail;
            return View(data);
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
