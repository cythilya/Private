using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace cythilya.Areas.EShopper.Models
{
    [DisplayName("商品類別名稱")]
    [DisplayColumn("Name")]
    public class ProductCategory
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("商品類別名稱")]
        [Required(ErrorMessage = "請輸入商品類別名稱")]
        [MaxLength(20, ErrorMessage="商品類別名稱不可超過20字")]
        public string Name { get; set; }
    }
}