using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace cythilya.Areas.EShopper.Models
{
    [DisplayName("訂單主檔")]
    [DisplayColumn("Name")]
    public class OrderHeader
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("訂購會員")]
        [Required]
        public virtual Member Member { get; set; }

        [DisplayName("收件人姓名")]
        [Required(ErrorMessage = "請輸入收件人姓名")]
        public string ContactName { get; set; }

        [DisplayName("收件人電話")]
        [Required(ErrorMessage = "請輸入收件人電話，例如：0912345678")]        
        [DataType(DataType.PhoneNumber)]
        public string ContactPhone { get; set; }

        [DisplayName("收件地址")]
        [Required(ErrorMessage = "請輸入收件地址")]
        public string ContactAddress { get; set; }

        [DisplayName("訂單總金額")]
        [Required]
        [DataType(DataType.Currency)]
        public int TotalPrice { get; set; }

        [DisplayName("訂單備註")]
        [DataType(DataType.MultilineText)]
        public string Memo { get; set; }

        [DisplayName("訂購時間")]
        public DateTime BuyOn { get; set; }

        //public virtual ICollection<OrderDetail> OrderDetailItems { get; set; }
    }
}