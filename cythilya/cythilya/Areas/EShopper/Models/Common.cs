using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cythilya.Areas.EShopper.Models
{
    public class Common
    {
        //Social Platform
        public class SocialList
        {
            public string Name { get; set; }
            public string Link { get; set; }
        }

        //Carousel
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
        
    }
}