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
            public int ID { get; set; } //按新增順序編號
            public string Name { get; set; }
            public string Description { get; set; }
            public string URL { get; set; }
            public string Role { get; set; }
            public string Tech { get; set; }
            public int Order { get; set; } //archieve order
            public string RawPic { get; set; }
            public string PicSmall { get; set; } //188*73
            public string PicMedium { get; set; } //300*n
            public string PicLarge { get; set; } //940*367
            public string PicInFooter { get; set; } //54*54
            public List<SnapshotInfo> Snapshot { get; set; }
            public string Client { get; set; }
            public string ClientURL { get; set; }
            public string Date { get; set; }
            public string LauchURL { get; set; }
            public string HtmlContent { get; set; }
            public string Tag { get; set; }
            public bool isHighlight { get; set; }
            public bool isHideFromIndex { get; set; } //首頁不會成展現此專案，只會在Archieve、Portfolio顯示
            public List<int> Partners { get; set; } //合作夥伴
            public bool IsShowInPortfolio { get; set; } //是否顯示在作品集 
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

        public class RecentProject
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string URL { get; set; }
            public string PicLarge { get; set; } //940*367
            public string PicInFooter { get; set; } //54*54
            public int Order { get; set; } //archieve order
            public string Date { get; set; }
            public string Tag { get; set; }
            public int TagScore { get; set; }
        }

        public class Visitor 
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Message { get; set; }
        }

        //合作夥伴
        public class Partner 
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Website { get; set; }
        }

        #region 活動
        public class Activity
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public List<string> Pic { get; set; }
            public List<int> Participant { get; set; }
            public string StartDate { get; set; } //2015-06-06T10:00
            public string Time { get; set; } //2015/06/06 (六)
            public string Month { get; set; }
            public String Day { get; set; }
            public string WebURL { get; set; }
            public List<int> Tag { get; set; }
            public int Location { get; set; }
            public string HTMLContent { get; set; }
        }

        public class Participant
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Website { get; set; }
        }

        public class Location
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string StreetAddress { get; set; } //光復南路102號3樓
            public string AddressLocality { get; set; } //台北市
            public string AddressRegion { get; set; } //台灣
            public string Latitude { get; set; }
            public string Longitude { get; set; }
        }
        
        public class Tag
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }

        #endregion


    }
}