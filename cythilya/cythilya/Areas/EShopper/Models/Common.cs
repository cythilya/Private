using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cythilya.Areas.EShopper.Models
{
    public class Common
    {
        #region Social Platform
        public class SocialList
        {
            public string Name { get; set; }
            public string Link { get; set; }
        }
        #endregion

        #region Carousel
        public class Carousel
        {
            public string Heading { get; set; }
            public string Caption { get; set; }
            public string Description { get; set; }
            public string Link { get; set; }
            public string ImageUrl { get; set; }
            public string PriceImageUrl { get; set; }
            public bool IsHighlight { get; set; }
        }
        #endregion

        #region Main Tag
        public class MainTag
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
        #endregion

        #region 取得特定標籤的商品列表
        public class TagProduct
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Price  { get; set; }
            public string PicUrl { get; set; }
        }

        public class TagProductList
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public List<TagProduct> TagProduct { get; set; }
        }
        #endregion

        #region 推薦商品
        public class RecommendItem
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }
            public string PicUrl { get; set; }
        }
        #endregion
    }
}