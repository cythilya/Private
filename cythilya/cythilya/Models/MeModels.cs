﻿using System;
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
            public string PicInFooter { get; set; } //54x54
            public bool isHight { get; set; }
            public string Tag { get; set; }
            public bool isHighlight { get; set; } //appear in footer
            public string Time { get; set; }
            public bool isBanner { get; set;  } //appear in banner
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
            public string PicSmall { get; set; } //188*73
            public string PicMedium { get; set; } //300*n
            public string PicLarge { get; set; } //940*367
            public List<SnapshotInfo> Snapshot { get; set; }
            public int Order { get; set; }
            public string Client { get; set; }
            public string ClientURL { get; set; }
            public string Date { get; set; }
            public string LauchURL { get; set; }
            public string HtmlContent { get; set; }
            public string Tag { get; set; }
            public bool isHighlight { get; set; }
        }

        public class RelatedProject
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string URL { get; set; }
            public string PicLarge { get; set; } //940*367
            public string Date { get; set; }
            public int TagScore { get; set; }
        }

        public class Visitor 
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Message { get; set; }
        }
    }
}