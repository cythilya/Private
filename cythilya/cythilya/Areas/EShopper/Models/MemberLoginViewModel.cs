using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace cythilya.Areas.EShopper.Models
{
    public class MemberLoginViewModel
    {
        [DisplayName("Account")]
        [Required(ErrorMessage="forget account?")]
        public string Account { get; set; }

        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "forget password?")]
        public string Password { get; set; }

    }
}