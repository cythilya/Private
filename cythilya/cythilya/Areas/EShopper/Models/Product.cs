using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace cythilya.Areas.EShopper.Models
{
    [DisplayName("商品資訊")]
    [DisplayColumn("Name")]
    public class Product
    {
        //ID
        [Key]
        public int ID { get; set; }

        //商品名稱
        [DisplayName("商品名稱")]
        [Required(ErrorMessage = "請輸入商品名稱")]
        [MaxLength(60, ErrorMessage = "商品名稱不可超過60字")]
        public string Name { get; set; }

        //商品類別
        [DisplayName("商品類別")]
        [Required]
        public ProductCategory ProductCategory { get; set; }

        //商品介紹
        [DisplayName("商品介紹")]
        [Required(ErrorMessage = "請輸入商品介紹")]
        public string Description { get; set; }

        //商品圖片
        //主打圖片原始檔
        [DisplayName("主打圖片原始檔")]
        [Required(ErrorMessage = "請輸入主打圖片原始檔")]
        public string RawPicUrl { get; set; }

        //主打圖片, 大(內頁 329x380)
        [DisplayName("主打內頁大圖(329x380)")]
        [Required(ErrorMessage = "請輸入主打內頁大圖(329x380)")]
        public string PicLargeUrl { get; set; }

        //主打圖片, 中(首頁 255x381)
        [DisplayName("主打中圖(首頁 255x381)")]
        [Required(ErrorMessage = "請輸入主打中圖(首頁 255x381)")]
        public string PicMediumUrl { get; set; }

        //主打圖片, 小(內頁 85x84)
        [DisplayName("主打內頁小圖(85x84)")]
        [Required(ErrorMessage = "請輸入主打內頁小圖(85x84)")]
        public string PicSmallUrl { get; set; }

        //特色商品(208x183)
        [DisplayName("主打中圖(首頁 255x381)")]
        [Required(ErrorMessage = "請輸入主打中圖(首頁 255x381)")]
        public string PicFeaturedUrl { get; set; }

        //上架時間
        [DisplayName("上架時間")]
        [Description("如果不設定上架時間，則此商品永不上架")]
        public DateTime? PublishOn { get; set; }

        //品牌
        //品牌名稱
        [DisplayName("品牌名稱")]
        public string Brand { get; set; }

        //品牌簡介
        [DisplayName("品牌簡介")]
        public string BrandInfo { get; set; }

        //標籤列表
        [DisplayName("標籤列表")]
        public List<Tag> Tags { get; set; }

        //價格
        [DisplayName("價格")]
        public int Price { get; set; }

        //數量
        [DisplayName("數量")]
        public int Amount { get; set; }

        //是否出清
        [DisplayName("是否出清")]
        public bool IsSale { get; set; } //是否出清

        //是否為特色商品
        [DisplayName("是否為特色商品")]
        public bool IsHigLight { get; set; } //是否為特色商品

        //主要標籤
        [DisplayName("主要標籤")]
        [Required(ErrorMessage = "請輸入主要標籤")]
        public string MainTag { get; set; }
    }
}