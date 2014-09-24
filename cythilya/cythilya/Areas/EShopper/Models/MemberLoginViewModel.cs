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
        [Required(ErrorMessage="Enter Account?")]
        public string Account { get; set; }

        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter Password?")]
        public string Password { get; set; }

    }
}