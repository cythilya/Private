using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace cythilya.Areas.EShopper.Models
{
    public class Tag
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; } 
    }
}