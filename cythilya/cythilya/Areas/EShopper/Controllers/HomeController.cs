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
            GetCategotyList();//取得商品類別
            GetCarouselList();//取得輪播資料
            return View();
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

        //取得商品類別
        void GetCategotyList()
        {
            #region fake data - product category
            var categoryList = new List<ProductCategory>()
            {
                new ProductCategory() { ID = 1, Name = "WOMENS"},
                new ProductCategory() { ID = 2, Name = "MENS"},
                new ProductCategory() { ID = 3, Name = "KIDS"},
                new ProductCategory() { ID = 4, Name = "SPORTSWEAR"},
                new ProductCategory() { ID = 5, Name = "HOUSEHOLDS"},
                new ProductCategory() { ID = 6, Name = "BAGS & SHOES"}
            };
            #endregion

            ViewBag.CategoryList = categoryList;
        }

        //取得輪播資料
        void GetCarouselList()
        {
            #region Carousel List
            var carouselList = new List<Common.Carousel>() 
            { 
                new Common.Carousel()
                {
                    Heading = "E-SHOPPER",
                    Caption = "Free E-Commerce Template",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Link = "/EShopper/Home/Product?id=1",
                    ImageUrl = "/Content/eshopper/images/home/girl1.jpg",
                    PriceImageUrl = "/Content/eshopper/images/home/pricing.png",
                    IsHighlight = true
                },
                new Common.Carousel()
                {
                    Heading = "E-SHOPPER",
                    Caption = "100% Responsive Design",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Link = "/EShopper/Home/Product?id=2",
                    ImageUrl = "/Content/eshopper/images/home/girl2.jpg",
                    PriceImageUrl = "/Content/eshopper/images/home/pricing.png",
                    IsHighlight = false
                },
                new Common.Carousel()
                {
                    Heading = "E-SHOPPER",
                    Caption = "Free Ecommerce Template",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Link = "/EShopper/Home/Product?id=3",
                    ImageUrl = "/Content/eshopper/images/home/girl3.jpg",
                    PriceImageUrl = "/Content/eshopper/images/home/pricing.png",
                    IsHighlight = false
                }
            }; 
            #endregion

            ViewBag.CarouselList = carouselList;
        }
    }
}
