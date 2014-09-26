using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cythilya.Models
{
    public class MeModels
    {
        public class Article
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string URL { get; set; }
            public string RawPic { get; set; }
            public string PicSmall { get; set; }
            public string PicMedium { get; set; }
            public string PicLarge { get; set; }
            public bool isHight { get; set; }
            public bool isHighlight { get; set; }
        }

        public class SnapshotInfo 
        {
            public string Name { get; set; }
            public string SnapshotURL { get; set; }        
        }

        public class Project 
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string URL { get; set; }
            public string RawPic { get; set; }
            public string PicSmall { get; set; } //940*367
            public string PicMedium { get; set; } //300*n
            public string PicLarge { get; set; } //188*73
            public List<SnapshotInfo> Snapshot { get; set; }
            public int Order { get; set; }
            public string Client { get; set; }
            public string ClientURL { get; set; }
            public string Date { get; set; }
            public string LauchURL { get; set; }
            public string HtmlContent { get; set; }
            public bool isHighlight { get; set; }
        }


    }
}