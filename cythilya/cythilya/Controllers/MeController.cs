using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cythilya.Models;

namespace cythilya.Controllers
{
    public class MeController : Controller
    {
        
        //Index
        public ActionResult Index()
        {
            GetArticleList();
            getProjectList();
            return View();
        }

        //Resume
        public ActionResult Resume() 
        {
            return View();
        }

        //Portfolio
        public ActionResult Portfolio() 
        {
            GetArticleList();
            getProjectList();
            return View();
        }

        //Project
        public ActionResult Project(int id = 0) 
        {
            List<MeModels.Project> projList = new List<MeModels.Project>();
            projList = getProjectList();
            MeModels.Project proj = projList.Find(item => item.ID == id);

            if (proj == null) {
                return View("Portfolio");
            }

            ViewBag.ProjData = proj;
            return View();
        }

        //Get Article List
        public void GetArticleList() {
            List<MeModels.Article> articleList = new List<MeModels.Article>();

            #region Mock

            //IA for SEO：使用IA增進從搜尋引擎來的流量
            MeModels.Article article_1 = new MeModels.Article();
            article_1.Name = "IA for SEO：使用IA增進從搜尋引擎來的流量";
            article_1.Description = "在達到高的「有機搜尋引擎最佳化排行」(Organic Search Engine Optimization Ranking)中，IA(Information Architecture，資訊架構)是很重要的部份。";
            article_1.URL = "http://bit.ly/1z6veUU";
            article_1.RawPic = "/Content/me/img/blog/247479_5433.jpg";
            article_1.PicSmall = "/Content/me/img/blog/ia_for_seo_188x73.jpg";
            article_1.PicMedium = "/Content/me/img/blog/ia_for_seo_300.jpg";
            article_1.PicLarge = "/Content/me/img/blog/ia_for_seo_940x367.jpg";
            article_1.isHighlight = false;
            articleList.Add(article_1);

            //SEO：重複內容(Duplicate Content)
            MeModels.Article article_2 = new MeModels.Article();
            article_2.Name = "SEO：重複內容(Duplicate Content)";
            article_2.Description = "網站中或網站間存在許多重複內容，而搜尋引擎為了提供使用者最佳的搜尋結果，便會對這些內容作區別，將最原始的資料或最佳的內容排在搜尋結果的最前面。 在某些情況下，重複內容是無法避免的，而這些重複內容損害了網站或網頁的排名。 因此，我們可以對這些重複內容做處理，修正搜尋引擎對它們的解讀。 這裡的搜尋引擎是以Google為主。";
            article_2.URL = "http://bit.ly/1z6veUU";
            article_2.RawPic = "/Content/me/img/blog/250528_3929.jpg";
            article_2.PicSmall = "/Content/me/img/blog/duplicate_content_188x73.jpg";
            article_2.PicMedium = "/Content/me/img/blog/duplicate_content_300.jpg";
            article_2.PicLarge = "/Content/me/img/blog/duplicate_content_940x367.jpg";
            article_2.isHighlight = false;
            articleList.Add(article_2);

            //從搜尋到社群 - Semantics、Rich Snippets、Social Meta Tags
            MeModels.Article article_3 = new MeModels.Article();
            article_3.Name = "從搜尋到社群 - Semantics、Rich Snippets、Social Meta Tags";
            article_3.Description = "搜尋引擎提供使用者想要的資訊，而社群平台提供這些資訊更多露出的機會。我們希望將優質的內容提供給使用者，並利用社群的力量推廣出去。";
            article_3.URL = "http://bit.ly/1pNGBA3";
            article_3.RawPic = "/Content/me/img/blog/search_and_social.jpg";
            article_3.PicSmall = "/Content/me/img/blog/search_and_social_188x73.jpg";
            article_3.PicMedium = "/Content/me/img/blog/search_and_social_300.jpg";
            article_3.PicLarge = "/Content/me/img/blog/search_and_social_940x367.jpg";
            article_3.isHighlight = true;
            articleList.Add(article_3);

            //RSS：概念與實作
            MeModels.Article article_4 = new MeModels.Article();
            article_4.Name = "RSS：概念與實作";
            article_4.Description = "RSS(Really Simple Syndication，簡易資訊聚合)是一種消息來源格式規範，用以聚合經常發布更新數據的網站，例如博客文章、新聞、多媒體等的摘要或最新更新訊息。其目的為把新聞標題、摘要（Feed）、內容按照使用者的要求，「送」到使用者的面前。RSS摘要可以藉由RSS閱讀器、Feed Reader等軟體來閱讀(EX：Feedly、Digg)。";
            article_4.URL = "http://bit.ly/1wdcNBI";
            article_4.RawPic = "/Content/me/img/blog/505237_63345765.jpg";
            article_4.PicSmall = "/Content/me/img/blog/rss_188x73.jpg";
            article_4.PicMedium = "/Content/me/img/blog/rss_300.jpg";
            article_4.PicLarge = "/Content/me/img/blog/rss_940x367.jpg";
            article_4.isHighlight = true;
            articleList.Add(article_4);

            //Author Rank
            MeModels.Article article_5 = new MeModels.Article();
            article_5.Name = "Author Rank";
            article_5.Description = "Author Rank是評估作者影響力的指標，過去尚未被證實是否會影響搜尋結果的排名，但Matt Cutts的一則Tweet似乎證實在某些地方確實會用到，例如專門領域文章的分析。";
            article_5.URL = "http://bit.ly/VIeBBC";
            article_5.RawPic = "/Content/me/img/blog/Michal_Koralewski_419846_14072013.jpg";
            article_5.PicSmall = "/Content/me/img/blog/author_rank_188x73.jpg";
            article_5.PicMedium = "/Content/me/img/blog/author_rank_300.jpg";
            article_5.PicLarge = "/Content/me/img/blog/author_rank_940x367.jpg";
            article_5.isHighlight = true;
            articleList.Add(article_5);

            //粉多任務 x 一品禪 - 使用Microdata標記的網頁實例
            MeModels.Article article_6 = new MeModels.Article();
            article_6.Name = "粉多任務 x 一品禪 - 使用Microdata標記的網頁實例";
            article_6.Description = "什麼是Microdata？標記符號的用途在於讓搜尋引擎有效讀懂網頁的內容，進而達到搜尋時呈現我們所提供的資料的方法。 畢竟直接告訴搜尋引擎重點在哪裡－－告訴它這是一篇文章的標題、內文、圖片和圖片說明，或告訴它這是商品區塊、這些文字是商品名稱或廠商名稱、告訴它這些數字是價錢(而非無意義的數字)，是比較有效率和精準的。而文中也說明標記如何使用和測試。";
            article_6.URL = "http://bit.ly/1wdf3ZQ";
            article_6.RawPic = "/Content/me/img/blog/yipinchan_website.png";
            article_6.PicSmall = "/Content/me/img/blog/microdata_188x73.jpg";
            article_6.PicMedium = "/Content/me/img/blog/microdata_300.png";
            article_6.PicLarge = "/Content/me/img/blog/microdata_940x367.jpg";
            article_6.isHighlight = true;
            articleList.Add(article_6);

            //搜尋引擎優化指南(SEO Guideline) - 如何有系統的優化網站、評估與持續改進？
            MeModels.Article article_7 = new MeModels.Article();
            article_7.Name = "搜尋引擎優化指南(SEO Guideline) - 如何有系統的優化網站、評估與持續改進？";
            article_7.Description = "搜尋引擎優化指南(SEO Guideline)是一套有系統的優化網站的執行準則，每個崗位執行特定的工作項目即可讓網站(或專案)有一定品質以上的效果，並且這樣的優化效果是可以被評估、回饋與持續改進的。而系統化的實行也有助於在有限資源下做最大的利用，以得到最好的效果(例如：點閱率、排名)。";
            article_7.URL = "http://bit.ly/1tue7uA";
            article_7.RawPic = "/Content/me/img/blog/1441781_56845462.jpg";
            article_7.PicSmall = "/Content/me/img/blog/seo_guideline_188x73.jpg";
            article_7.PicMedium = "/Content/me/img/blog/seo_guideline_300.jpg";
            article_7.PicLarge = "/Content/me/img/blog/seo_guideline_940x367.jpg";
            article_7.isHighlight = true;
            articleList.Add(article_7);

            //Facebook Graph API & Demo Example
            MeModels.Article article_8 = new MeModels.Article();
            article_8.Name = "Facebook Graph API & Demo Example";
            article_8.Description = "Graph API是Facebook所推出的一種技術標準，它的核心概念是「物件與連結」。 為什麼稱為「Graph API」呢？ 因為整個Facebook就是透過這些物件與連結建立而成的Social Graph。 Facebook所提供存取的介面，就稱為「Graph API」。";
            article_8.URL = "http://bit.ly/1qtutRh";
            article_8.RawPic = "/Images/twenty_800.jpg";
            article_8.PicSmall = "/Content/me/img/blog/facebook_social_demo_188x73.jpg";
            article_8.PicMedium = "/Content/me/img/blog/facebook_social_demo_300.jpg";
            article_8.PicLarge = "/Content/me/img/blog/facebook_social_demo_940x367.jpg";
            article_8.isHighlight = false;
            articleList.Add(article_8);

            //關鍵字(Keyword)與標籤(Tag)－談選擇、聚焦與經營
            MeModels.Article article_9 = new MeModels.Article();
            article_9.Name = "關鍵字(Keyword)與標籤(Tag)－談選擇、聚焦與經營";
            article_9.Description = "許多網站都設置關鍵字與標籤，但網站一定需要關鍵字、標籤嗎？關鍵字和標籤有什麼差別？能夠帶給網站什麼樣的成效？";
            article_9.URL = "http://bit.ly/1wdiFLc";
            article_9.RawPic = "/Content/me/img/blog/1430736_59220148_800.jpg";
            article_9.PicSmall = "/Content/me/img/blog/keyword_tag_188x73.jpg";
            article_9.PicMedium = "/Content/me/img/blog/keyword_tag_300.jpg";
            article_9.PicLarge = "/Content/me/img/blog/keyword_tag_940x367.jpg";
            article_9.isHighlight = true;
            articleList.Add(article_9);

            //Ember.js & SEO - 測試搜尋引擎對JavaScript的剖析能力
            MeModels.Article article_10 = new MeModels.Article();
            article_10.Name = "Ember.js & SEO - 測試搜尋引擎對JavaScript的剖析能力";
            article_10.Description = "Google Webmaster Central Blog在今年五月宣布 ，Google 搜尋能夠執行網頁上的 Javascript (見Understanding web pages better)﻿。而過去已知Crawler只會剖析網頁上的HTML Code，而不會(或少量)執行JavaScript。。又由於開發品質與速度的要求，使得Single Page Application (SPA) frameworks盛行(例如：Angular.js、Ember.js等)，於是了解搜尋引擎是否能夠執行並解讀JavaScript與解讀的程度便成為網站開發的其中一項需求。";
            article_10.URL = "http://bit.ly/1unwm55";
            article_10.RawPic = "/Content/me/img/blog/JavaScript_SEO.jpg";
            article_10.PicSmall = "https://lh4.googleusercontent.com/-NQKoNelYrYk/VB2Kgo7AlzI/AAAAAAAACwM/9_byKkEoIAU/w188-h73-no/JavaScript_SEO_188x73.jpg";
            article_10.PicMedium = "https://lh5.googleusercontent.com/-jpsbP9Qfww8/VB2KgcI-M2I/AAAAAAAACwM/c_ZxQG3NwNc/w300-h169-no/JavaScript_SEO_300.jpg";
            article_10.PicLarge = "/Content/me/img/blog/JavaScript_SEO_940x367.jpg";
            article_10.isHighlight = true;
            articleList.Add(article_10);
            
            #endregion

            ViewBag.ArticleList = articleList;
        }

        //Get Project List
        public List<MeModels.Project> getProjectList()
        {
            List<MeModels.Project> projList = new List<MeModels.Project>();

            #region Mock

            #region ONE PIECE FILM Z 【航海王電影:Z】 官方網站
            MeModels.Project proj_1 = new MeModels.Project();
            proj_1.ID = 1;
            proj_1.Name = "ONE PIECE FILM Z 【航海王電影:Z】 官方網站";
            proj_1.Description = "ONE PIECE FILM Z【航海王電影:Z】官方網站1月25日決戰新世界。";
            proj_1.URL = "/Me/Project?id=1";
            proj_1.RawPic = "/Content/me/img/project/one_piece_z/one_piece_z_index.png";
            proj_1.PicSmall = "/Content/me/img/project/one_piece_z/one_piece_z_index_188x73.png";
            proj_1.PicMedium = "/Content/me/img/project/one_piece_z/one_piece_z_index_300.png";
            proj_1.PicLarge = "/Content/me/img/project/one_piece_z/one_piece_z_index_940x367.png";
            proj_1.Order = 1;
            proj_1.Client = "采昌國際多媒體";
            proj_1.ClientURL = "http://www.ccii.com.tw/chweb/index.asp";
            proj_1.Date = "Jan. 2013";
            proj_1.LauchURL = "http://www.ccii.com.tw/OPZ";
            proj_1.HtmlContent = "<p>ONE PIECE FILM Z【航海王電影:Z】官方網站1月25日決戰新世界。</p>";
            proj_1.isHighlight = true;

            List<MeModels.SnapshotInfo> SnapshotList1 = new List<MeModels.SnapshotInfo>();
            MeModels.SnapshotInfo proj_1_snap_1 = new MeModels.SnapshotInfo();
            MeModels.SnapshotInfo proj_1_snap_2 = new MeModels.SnapshotInfo();
            MeModels.SnapshotInfo proj_1_snap_3 = new MeModels.SnapshotInfo();;
            MeModels.SnapshotInfo proj_1_snap_4 = new MeModels.SnapshotInfo();
            MeModels.SnapshotInfo proj_1_snap_5 = new MeModels.SnapshotInfo();

            proj_1_snap_1.Name = "ONE PIECE FILM Z 【航海王電影:Z】 官方網站";
            proj_1_snap_1.SnapshotURL = "/Content/me/img/project/one_piece_z/one_piece_z_index_940x602.png";

            proj_1_snap_2.Name = "ONE PIECE FILM Z 【航海王電影:Z】 官方網站 - 故事大綱";
            proj_1_snap_2.SnapshotURL = "/Content/me/img/project/one_piece_z/one_piece_z_outline_940x602.png";

            proj_1_snap_3.Name = "ONE PIECE FILM Z 【航海王電影:Z】 官方網站 - 人物介紹";
            proj_1_snap_3.SnapshotURL = "/Content/me/img/project/one_piece_z/one_piece_z_character_940x602.png";

            proj_1_snap_4.Name = "ONE PIECE FILM Z 【航海王電影:Z】 官方網站 - 電影預告";
            proj_1_snap_4.SnapshotURL = "/Content/me/img/project/one_piece_z/one_piece_z_preview_940x602.png";

            proj_1_snap_5.Name = "ONE PIECE FILM Z 【航海王電影:Z】 官方網站 - 幕後製作";
            proj_1_snap_5.SnapshotURL = "/Content/me/img/project/one_piece_z/one_piece_z_cast_staff_940x602.png";

            SnapshotList1.Add(proj_1_snap_1);
            SnapshotList1.Add(proj_1_snap_2);
            SnapshotList1.Add(proj_1_snap_3);
            SnapshotList1.Add(proj_1_snap_4);
            SnapshotList1.Add(proj_1_snap_5);

            proj_1.Snapshot = SnapshotList1;
            projList.Add(proj_1);
            #endregion

            #region 粉多辦桌
            MeModels.Project proj_2 = new MeModels.Project();
            proj_2.ID = 2;
            proj_2.Name = "粉多辦桌";
            proj_2.Description = "粉多網路辦桌大請客，粉多為了慶祝台灣第一個雲端社群網站開站，舉辦網路辦桌活動。在活動時間內，使用Facebook登入並成為粉多會員後點選「免費請我」即可參加抽獎。每天都有不同商品，每天能抽當天的商品。當天邀請Facebook朋友參加，此帳號當日得獎機率提升為2倍。";
            proj_2.URL = "/Me/Project?id=2";
            proj_2.RawPic = "/Content/me/img/project/party/party_index_940x1025.png";
            proj_2.PicSmall = "/Content/me/img/project/party/party_index_188x73.png";
            proj_2.PicMedium = "/Content/me/img/project/party/party_index_300.png";
            proj_2.PicLarge = "/Content/me/img/project/party/party_index_940x367.png";
            proj_2.Order = 2;
            proj_2.Client = "";
            proj_2.ClientURL = "";
            proj_2.Date = "July 2012 - Aug 2014";
            proj_2.LauchURL = "";
            proj_2.HtmlContent = "<p>粉多網路辦桌大請客，粉多為了慶祝台灣第一個雲端社群網站開站，舉辦網路辦桌活動。在活動時間內，使用Facebook登入並成為粉多會員後點選「免費請我」即可參加抽獎。</p><p>每天都有不同商品，每天能抽當天的商品。當天邀請Facebook朋友參加，此帳號當日得獎機率提升為2倍。</p>";
            proj_2.isHighlight = false;

            List<MeModels.SnapshotInfo> SnapshotList2 = new List<MeModels.SnapshotInfo>();

            MeModels.SnapshotInfo proj_2_snap_1 = new MeModels.SnapshotInfo(); 
            MeModels.SnapshotInfo proj_2_snap_2 = new MeModels.SnapshotInfo(); 
            MeModels.SnapshotInfo proj_2_snap_3 = new MeModels.SnapshotInfo(); 
            MeModels.SnapshotInfo proj_2_snap_4 = new MeModels.SnapshotInfo(); 
            MeModels.SnapshotInfo proj_2_snap_5 = new MeModels.SnapshotInfo(); 
            MeModels.SnapshotInfo proj_2_snap_6 = new MeModels.SnapshotInfo(); 
            MeModels.SnapshotInfo proj_2_snap_7 = new MeModels.SnapshotInfo();

            proj_2_snap_1.Name = "粉多辦桌";
            proj_2_snap_1.SnapshotURL = "/Content/me/img/project/party/party_index_940x1025.png";

            proj_2_snap_2.Name = "粉多辦桌 - 活動辦法";
            proj_2_snap_2.SnapshotURL = "/Content/me/img/project/party/party_rule_940x1025.png";

            proj_2_snap_3.Name = "粉多辦桌 - 活動盛況";
            proj_2_snap_3.SnapshotURL = "/Content/me/img/project/party/party_event_940x1025.png";

            proj_2_snap_4.Name = "粉多辦桌 - 活動盛況 佔位";
            proj_2_snap_4.SnapshotURL = "/Content/me/img/project/party/party_event_join_940x754.png";

            proj_2_snap_5.Name = "粉多辦桌 - 中獎名單";
            proj_2_snap_5.SnapshotURL = "/Content/me/img/project/party/party_list_940x655.png";

            proj_2_snap_6.Name = "粉多辦桌 - 贊助廠商";
            proj_2_snap_6.SnapshotURL = "/Content/me/img/project/party/party_sponsor_940x1525.png";

            proj_2_snap_7.Name = "粉多辦桌結束";
            proj_2_snap_7.SnapshotURL = "/Content/me/img/project/party/party_index_close _940x965.png";
            
            SnapshotList2.Add(proj_2_snap_1);
            SnapshotList2.Add(proj_2_snap_2);
            SnapshotList2.Add(proj_2_snap_3);
            SnapshotList2.Add(proj_2_snap_4);
            SnapshotList2.Add(proj_2_snap_5);
            SnapshotList2.Add(proj_2_snap_6);
            SnapshotList2.Add(proj_2_snap_7);

            proj_2.Snapshot = SnapshotList2;
            projList.Add(proj_2);
            #endregion

            #region 粉多辦桌 X 恆隆行
            MeModels.Project proj_3 = new MeModels.Project();
            proj_3.ID = 3;
            proj_3.Name = "粉多辦桌 x 恆隆行";
            proj_3.Description = "粉多辦桌和恆隆行合作所特別製作的首頁與活動盛況頁面。";
            proj_3.URL = "/Me/Project?id=3";
            proj_3.RawPic = "/Content/me/img/project/party_hlh/party_index_hlh.png";
            proj_3.PicSmall = "/Content/me/img/project/party_hlh/party_index_hlh_188x73.png";
            proj_3.PicMedium = "/Content/me/img/project/party_hlh/party_index_hlh_300.png";
            proj_3.PicLarge = "/Content/me/img/project/party_hlh/party_index_hlh_940x367.png";
            proj_3.Order = 3;
            proj_3.Client = "恆隆行";
            proj_3.ClientURL = "http://www.hlh.com.tw";
            proj_3.Date = "Aug. 2012";
            proj_3.LauchURL = "";
            proj_3.HtmlContent = "<p>粉多辦桌和恆隆行合作所特別製作的首頁與活動盛況頁面。</p>";
            proj_3.isHighlight = false;

            List<MeModels.SnapshotInfo> SnapshotList3 = new List<MeModels.SnapshotInfo>();
            MeModels.SnapshotInfo proj_3_snap_1 = new MeModels.SnapshotInfo(); 
            MeModels.SnapshotInfo proj_3_snap_2 = new MeModels.SnapshotInfo(); 

            proj_3_snap_1.Name = "粉多辦桌 x 恆隆行";
            proj_3_snap_1.SnapshotURL = "/Content/me/img/project/party_hlh/party_index_hlh_940.png";
 
            proj_3_snap_2.Name = "粉多辦桌 x 恆隆行 - 活動盛況";
            proj_3_snap_2.SnapshotURL = "/Content/me/img/project/party_hlh/party_event_hlh_940.png";
           
            SnapshotList3.Add(proj_3_snap_1);
            SnapshotList3.Add(proj_3_snap_2);
            proj_3.Snapshot = SnapshotList3;

            projList.Add(proj_3);
            #endregion

            #region Friendo 粉多任務
            MeModels.Project proj_4 = new MeModels.Project();
            proj_4.ID = 4;
            proj_4.Name = "Friendo 粉多任務";
            proj_4.Description = "粉多任務是整合社群、紅利回饋與購物的社交網站，用Facebook臉書登入，尋找自己有興趣的任務來執行。解完任務，馬上取得購物時可以抵扣現金使用的粉多紅利。彩妝保養美食餐券3C雜貨……粉多優惠應有盡有。";
            proj_4.URL = "/Me/Project?id=4";
            proj_4.RawPic = "/Content/me/img/project/mission/mission_index_940x812.png";
            proj_4.PicSmall = "/Content/me/img/project/mission/mission_index_188x73.png";
            proj_4.PicMedium = "/Content/me/img/project/mission/mission_index_300.png";
            proj_4.PicLarge = "/Content/me/img/project/mission/mission_index_940x367.png";
            proj_4.Order = 4;
            proj_4.Client = "";
            proj_4.ClientURL = "";
            proj_4.Date = "Oct. 2012";
            proj_4.LauchURL = "http://www.friendo.com.tw";
            proj_4.HtmlContent = "<p>粉多任務是整合社群、紅利回饋與購物的社交網站，用Facebook臉書登入，尋找自己有興趣的任務來執行。解完任務，馬上取得購物時可以抵扣現金使用的粉多紅利。彩妝保養美食餐券3C雜貨……粉多優惠應有盡有。</p>";
            proj_4.isHighlight = true;

            List<MeModels.SnapshotInfo> SnapshotList4 = new List<MeModels.SnapshotInfo>();
            MeModels.SnapshotInfo proj_4_snap_1 = new MeModels.SnapshotInfo();
            MeModels.SnapshotInfo proj_4_snap_2 = new MeModels.SnapshotInfo();
            MeModels.SnapshotInfo proj_4_snap_3 = new MeModels.SnapshotInfo();
            MeModels.SnapshotInfo proj_4_snap_4 = new MeModels.SnapshotInfo();
            MeModels.SnapshotInfo proj_4_snap_5 = new MeModels.SnapshotInfo();

            proj_4_snap_1.Name = "Friendo 粉多任務";
            proj_4_snap_1.SnapshotURL = "/Content/me/img/project/mission/mission_index_940x812.png";

            proj_4_snap_2.Name = "Friendo 粉多任務 - 品牌基地";
            proj_4_snap_2.SnapshotURL = "/Content/me/img/project/mission/mission_brands_940x812.png";

            proj_4_snap_3.Name = "Friendo 粉多任務 - 標籤列表";
            proj_4_snap_3.SnapshotURL = "/Content/me/img/project/mission/mission_brands_940x812.png";

            proj_4_snap_4.Name = "Friendo 粉多任務 - 任務內頁";
            proj_4_snap_4.SnapshotURL = "/Content/me/img/project/mission/mission_single_940x812.png";

            proj_4_snap_5.Name = "Friendo 粉多任務 - 紅利商城";
            proj_4_snap_5.SnapshotURL = "/Content/me/img/project/mission/mission_bonus.png";
            
            SnapshotList4.Add(proj_4_snap_1);
            SnapshotList4.Add(proj_4_snap_2);
            SnapshotList4.Add(proj_4_snap_3);
            SnapshotList4.Add(proj_4_snap_4);
            SnapshotList4.Add(proj_4_snap_5);

            proj_4.Snapshot = SnapshotList4;
            projList.Add(proj_4);
            #endregion

            #region 原味千尋 x Friendo 粉多任務
            MeModels.Project proj_5 = new MeModels.Project();
            proj_5.ID = 5;
            proj_5.Name = "原味千尋 x Friendo 粉多任務";
            proj_5.Description = "原味千尋與粉多任務合作的活動網站。";
            proj_5.URL = "/Me/Project?id=5";
            proj_5.RawPic = "/Content/me/";
            proj_5.PicSmall = "/Content/me/img/project/daintiest/daintiest_index_188x73.png";
            proj_5.PicMedium = "/Content/me/img/project/daintiest/daintiest_index_300.png";
            proj_5.PicLarge = "/Content/me/img/project/daintiest/daintiest_index_940x367.png";
            proj_5.Order = 5;
            proj_5.Client = "原味千尋";
            proj_5.ClientURL = "http://www.daintiest.net";
            proj_5.Date = "July 2014";
            proj_5.LauchURL = "http://www.friendo.com.tw/daintiest";
            proj_5.HtmlContent = "<p>原味千尋與粉多任務合作的活動網站。</p>";
            proj_5.isHighlight = true;

            List<MeModels.SnapshotInfo> SnapshotList5 = new List<MeModels.SnapshotInfo>();
            MeModels.SnapshotInfo proj_5_snap_1 = new MeModels.SnapshotInfo();
            MeModels.SnapshotInfo proj_5_snap_2 = new MeModels.SnapshotInfo();
            MeModels.SnapshotInfo proj_5_snap_3 = new MeModels.SnapshotInfo();
            MeModels.SnapshotInfo proj_5_snap_4 = new MeModels.SnapshotInfo();
            MeModels.SnapshotInfo proj_5_snap_5 = new MeModels.SnapshotInfo();

            proj_5_snap_1.Name = "原味千尋 x Friendo 粉多任務";
            proj_5_snap_1.SnapshotURL = "/Content/me/img/project/daintiest/daintiest_index_940x1230.png";

            proj_5_snap_2.Name = "原味千尋 x Friendo 粉多任務 - 生活質缺";
            proj_5_snap_2.SnapshotURL = "/Content/me/img/project/daintiest/daintiest_spirit_940x1230.png";

            proj_5_snap_3.Name = "原味千尋 x Friendo 粉多任務 - 嚴選原味";
            proj_5_snap_3.SnapshotURL = "/Content/me/img/project/daintiest/daintiest_about_940x1230.png";

            proj_5_snap_4.Name = "原味千尋 x Friendo 粉多任務 - 跟知心好友無話不談嗎?是否有些話對朋友說不出口?讓粉多進入你的潛意識，挖掘你埋藏已久的小秘密!勇敢對朋友說出秘密，就有機會抽中最強乾杯零食 - 原味千尋炭燒辣味酪絲。原味千尋用16倍的真心，換1份乾杯的感動。";
            proj_5_snap_4.SnapshotURL = "/Content/me/img/project/daintiest/daintiest_mission.png";

            proj_5_snap_5.Name = "原味千尋 x Friendo 粉多任務 - 跟知心好友無話不談嗎?是否有些話對朋友說不出口?讓粉多進入你的潛意識，挖掘你埋藏已久的小秘密!勇敢對朋友說出秘密，就有機會抽中最強乾杯零食 - 原味千尋炭燒辣味酪絲。原味千尋用16倍的真心，換1份乾杯的感動。";
            proj_5_snap_5.SnapshotURL = "/Content/me/img/project/daintiest/daintiest_mission_content_generator.png";
           
            SnapshotList5.Add(proj_5_snap_1);
            SnapshotList5.Add(proj_5_snap_2);
            SnapshotList5.Add(proj_5_snap_3);
            SnapshotList5.Add(proj_5_snap_4);
            SnapshotList5.Add(proj_5_snap_5);

            proj_5.Snapshot = SnapshotList5;
            projList.Add(proj_5);
            #endregion

            #region 一品禪 x Friendo 粉多任務
            MeModels.Project proj_6 = new MeModels.Project();
            proj_6.ID = 6;
            proj_6.Name = "一品禪 x Friendo 粉多任務";
            proj_6.Description = "一品禪與粉多任務合作的活動網站。";
            proj_6.URL = "/Me/Project?id=6";
            proj_6.RawPic = "/Content/me/img/project/yipinchan/yipinchan_index_940x1130.png";
            proj_6.PicSmall = "/Content/me/img/project/yipinchan/yipinchan_index_188x73.png";
            proj_6.PicMedium = "/Content/me/img/project/yipinchan/yipinchan_index_300.png";
            proj_6.PicLarge = "/Content/me/img/project/yipinchan/yipinchan_index_940x367.png";
            proj_6.Order = 6;
            proj_6.Client = "一品禪";
            proj_6.ClientURL = "http://www.yishentw.com";
            proj_6.Date = "April 2014";
            proj_6.LauchURL = "http://www.friendo.com.tw/yipinchan";
            proj_6.HtmlContent = "<p>一品禪與粉多任務合作的活動網站，並特別加強SEO、品牌與相關產品關鍵字經營。</p>";
            proj_6.isHighlight = true;

            List<MeModels.SnapshotInfo> SnapshotList6 = new List<MeModels.SnapshotInfo>();
            MeModels.SnapshotInfo proj_6_snap_1 = new MeModels.SnapshotInfo();
            MeModels.SnapshotInfo proj_6_snap_2 = new MeModels.SnapshotInfo();
            MeModels.SnapshotInfo proj_6_snap_3 = new MeModels.SnapshotInfo();
            MeModels.SnapshotInfo proj_6_snap_4 = new MeModels.SnapshotInfo();

            proj_6_snap_1.Name = "一品禪 x Friendo 粉多任務";
            proj_6_snap_1.SnapshotURL = "/Content/me/img/project/yipinchan/yipinchan_index_940x1130.png";

            proj_6_snap_2.Name = "一品禪 x Friendo 粉多任務 - 關於一品禪";
            proj_6_snap_2.SnapshotURL = "/Content/me/img/project/yipinchan/yipinchan_intro_940x1130.png";

            proj_6_snap_3.Name = "一品禪 x Friendo 粉多任務 - 餃色介紹";
            proj_6_snap_3.SnapshotURL = "/Content/me/img/project/yipinchan/yipinchan_about_940x1130.png";

            proj_6_snap_4.Name = "一品禪 x Friendo 粉多任務 - 御選四季食補選購專區Online Shop";
            proj_6_snap_4.SnapshotURL = "/Content/me/img/project/yipinchan/yipinchan_product_940x1130.png";

            SnapshotList6.Add(proj_6_snap_1);
            SnapshotList6.Add(proj_6_snap_2);
            SnapshotList6.Add(proj_6_snap_3);
            SnapshotList6.Add(proj_6_snap_4);

            proj_6.Snapshot = SnapshotList6;
            projList.Add(proj_6);
            #endregion

            #region 票選10大爸爸最想要的父親節禮物，亞柏送給你
            MeModels.Project proj_7 = new MeModels.Project();
            proj_7.ID = 7;
            proj_7.Name = "票選10大爸爸最想要的父親節禮物，亞柏送給你";
            proj_7.Description = "亞柏EZ購與粉多任務合作的活動網站，票選爸爸最想要的父親節禮物並抽獎。";
            proj_7.URL = "/Me/Project?id=7";
            proj_7.RawPic = "/Content/me/img/project/aphezgo/aphezgo_index.png";
            proj_7.PicSmall = "/Content/me/img/project/aphezgo/aphezgo_index_188x73.png";
            proj_7.PicMedium = "/Content/me/img/project/aphezgo/aphezgo_index_300.png";
            proj_7.PicLarge = "/Content/me/img/project/aphezgo/aphezgo_index_940x367.png";
            proj_7.Order = 7;
            proj_7.Client = "亞柏EZ購";
            proj_7.ClientURL = "http://www.apezgo.com";
            proj_7.Date = "July 2014 - Aug 2014";
            proj_7.LauchURL = "http://fathersday.apezgo.com";
            proj_7.HtmlContent = "<p>亞柏EZ購與粉多任務合作的活動網站，票選爸爸最想要的父親節禮物並抽獎。</p>";
            proj_7.isHighlight = false;

            List<MeModels.SnapshotInfo> SnapshotList7 = new List<MeModels.SnapshotInfo>();
            MeModels.SnapshotInfo proj_7_snap_1 = new MeModels.SnapshotInfo();
            MeModels.SnapshotInfo proj_7_snap_2 = new MeModels.SnapshotInfo();
            MeModels.SnapshotInfo proj_7_snap_3 = new MeModels.SnapshotInfo();
            MeModels.SnapshotInfo proj_7_snap_4 = new MeModels.SnapshotInfo();

            proj_7_snap_1.Name = "票選10大爸爸最想要的父親節禮物，亞柏送給你";
            proj_7_snap_1.SnapshotURL = "/Content/me/img/project/aphezgo/aphezgo_index_940x855.png";

            proj_7_snap_2.Name = "票選10大爸爸最想要的父親節禮物，亞柏送給你 - 票選禮物";
            proj_7_snap_2.SnapshotURL = "/Content/me/img/project/aphezgo/aphezgo_form_940x847.png";

            proj_7_snap_3.Name = "票選10大爸爸最想要的父親節禮物，亞柏送給你 - 抽獎";
            proj_7_snap_3.SnapshotURL = "/Content/me/img/project/aphezgo/aphezgo_lottery_940x683.png";

            proj_7_snap_4.Name = "票選10大爸爸最想要的父親節禮物，亞柏送給你 - 票選結果";
            proj_7_snap_4.SnapshotURL = "/Content/me/img/project/aphezgo/aphezgo_result_940x855.png";

            SnapshotList7.Add(proj_7_snap_1);
            SnapshotList7.Add(proj_7_snap_2);
            SnapshotList7.Add(proj_7_snap_3);
            SnapshotList7.Add(proj_7_snap_4);

            proj_7.Snapshot = SnapshotList7;
            projList.Add(proj_7);
            #endregion 

            #endregion
            
            ViewBag.ProjList = projList;
            return projList;
        }
    }
}
