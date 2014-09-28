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
        //public ProductCategory ProductCategory { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }

        //商品介紹
        [DisplayName("商品介紹")]
        [Required(ErrorMessage = "請輸入商品介紹")]
        public string Description { get; set; }

        //商品圖片
        //主打圖片原始檔
        [DisplayName("圖片原始檔")]
        [Required(ErrorMessage = "請輸入圖片原始檔")]
        public string RawPicUrl { get; set; }

        //主打圖片, 329x380 (內頁)
        [DisplayName("329x380 (內頁)")]
        [Required(ErrorMessage = "請輸入329x380 (內頁)")]
        public string PicLargeUrl { get; set; }

        //主打圖片, 268x249 (特定類別頁)
        [DisplayName("268x249 (特定類別頁)")]
        [Required(ErrorMessage = "請輸入268x249 (特定類別頁)")]
        public string PicMediumUrl { get; set; }

        //主打圖片, 255x128 (Recommended)
        [DisplayName("255x128 (Recommended)")]
        [Required(ErrorMessage = "請輸入255x128 (Recommended)")]
        public string PicSmallUrl { get; set; }

        //208x183 (首頁特色商品、標籤商品)
        [DisplayName("208x183 (首頁特色商品、標籤商品)")]
        [Required(ErrorMessage = "請輸入208x183 (首頁特色商品、標籤商品)")]
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