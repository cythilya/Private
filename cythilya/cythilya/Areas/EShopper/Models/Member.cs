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
    public class Member
    {
        [Key]
        public int ID { get; set; }

        //會員登入帳號
        [DisplayName("會員登入帳號")]
        [Required(ErrorMessage = "會員登入帳號")]
        public string Account { get; set; }
        
        //Email
        [DisplayName("Email")]
        [Required(ErrorMessage = "請輸入Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        //密碼
        [DisplayName("密碼")]
        [Required(ErrorMessage = "請輸入密碼")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        //姓名
        [DisplayName("姓名")]
        [Required(ErrorMessage = "請輸入姓名")]
        public string Name { get; set; }
        
        //會員註冊時間
        [DisplayName("會員註冊時間")]
        public DateTime RegisterOn { get; set; }
        
        //會員啟用認證碼，若為null則表示已通過Email驗證
        [DisplayName("會員啟用認證碼")]
        [MaxLength(36)]
        public string AuthCode { get; set; }

        //FBUID
        [DisplayName("FBUID")]
        public string FBUserID { get; set; }
    }
}