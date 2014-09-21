using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace cythilya.Areas.EShopper.Models
{
    [DisplayName("訂單明細")]
    [DisplayColumn("Name")]
    public class OrderDetail
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("訂單主檔")]
        [Required]
        public OrderHeader OrderHeader { get; set; }

        [DisplayName("訂購商品")]
        [Required]
        public Product Product { get; set; }

        [DisplayName("商品售價")]
        [Required(ErrorMessage="請輸入商品售價")]
        [Range(1, 10000000, ErrorMessage = "商品價格必須介於1~10000000之間")]
        [DataType(DataType.Currency)]
        public int Price { get; set; }
    }
}