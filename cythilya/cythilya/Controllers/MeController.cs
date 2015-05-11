using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cythilya.Models;
using System.Net.Mail;

namespace cythilya.Controllers
{
    public class MeController : Controller
    {
        #region View
        
        //Index
        public ActionResult Index()
        {
            GetArticleList();
            getProjectList();
            getRecentPostList();
            getFeaturedPostList();
            getRecentProject();
            return View();
        }

        //About
        public ActionResult About() 
        {
            getRecentPostList();
            getFeaturedPostList();
            getRecentProject();
            return View();
        }
        
        public ActionResult About_C() 
        {
            getRecentPostList();
            getFeaturedPostList();
            getRecentProject();
            return View();
        }

        //Resume
        public ActionResult Resume() 
        {
            getRecentPostList();
            getFeaturedPostList();
            getRecentProject();
            return View();
        }

        //Portfolio
        public ActionResult Portfolio() 
        {
            getProjectList();
            getRecentPostList();
            getFeaturedPostList();
            getRecentProject();
            return View();
        }

        //Blog
        public ActionResult BlogArchieve()
        {
            GetArticleList();
            getProjectList();
            getRecentPostList();
            getFeaturedPostList();
            getRecentProject();
            return View();
        }

        public ActionResult ProjectArchieve() 
        {
            GetArticleList();
            getProjectList();
            getRecentPostList();
            getFeaturedPostList();
            getRecentProject();
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

            #region 取得合作夥伴
            if (proj.Partners != null) 
            {
                GetPartnerList(proj.Partners);
            }
            #endregion

            getRelatedProject(id);

            ViewBag.ProjData = proj;
            getFeaturedPostList();
            getRecentPostList();
            getRecentProject();
            return View();
        }

        //Contact
        public ActionResult Contact()
        {
            getRecentPostList();
            getFeaturedPostList();
            getRecentProject();
            return View();
        }

        //Structured Data Exmaple
        /*
        public ActionResult StructuredDataExamplePage() 
        {
            return View();
        }
         * */

        #endregion

        #region Function
        
        //Get Article List
        public List<MeModels.Article> GetArticleList()
        {
            List<MeModels.Article> articleList = new List<MeModels.Article>();

            #region Mock

            #region Icon Fonts Tutorial
            MeModels.Article article_30 = new MeModels.Article();
            article_30.Name = "Icon Fonts Tutorial";
            article_30.Description = "什麼是Icon Fonts?以往我們都是將小圖示(icon)用切圖的方式放入網頁，而我們也可以將這些icon用CSS「畫」出來。";
            article_30.URL = "http://cythilya-blog.logdown.com/posts/145597-icon-fonts-tutorial";
            article_30.RawPic = "/Content/me/img/blog//icon_fonts/icon_fonts_940x367.png";
            article_30.PicSmall = "/Content/me/img/blog//icon_fonts/icon_fonts_188x73.png";
            article_30.PicMedium = "/Content/me/img/blog//icon_fonts/icon_fonts_300.png";
            article_30.PicLarge = "/Content/me/img/blog//icon_fonts/icon_fonts_940x367.png";
            article_30.PicInFooter = "/Content/me/img/blog//icon_fonts/icon_fonts_54x54.png";
            article_30.Tag = "icon fonts";
            article_30.isHighlight = false;
            article_30.Time = "Oct 8, 2013";
            article_30.isBanner = false;
            articleList.Add(article_30);
            #endregion

            #region IA for SEO：使用IA增進從搜尋引擎來的流量
            MeModels.Article article_1 = new MeModels.Article();
            article_1.Name = "IA for SEO：使用IA增進從搜尋引擎來的流量";
            article_1.Description = "在達到高的「有機搜尋引擎最佳化排行」(Organic Search Engine Optimization Ranking)中，IA(Information Architecture，資訊架構)是很重要的部份。";
            article_1.URL = "http://bit.ly/1z6veUU";
            article_1.RawPic = "/Content/me/img/blog/247479_5433.jpg";
            article_1.PicSmall = "/Content/me/img/blog/ia_for_seo_188x73.jpg";
            article_1.PicMedium = "/Content/me/img/blog/ia_for_seo_300.jpg";
            article_1.PicLarge = "/Content/me/img/blog/ia_for_seo_940x367.jpg";
            article_1.PicInFooter = "/Content/me/img/blog/247479_5433_54x54.jpg";
            article_1.Tag = "SEO, IA";
            article_1.isHighlight = false;
            article_1.Time = "Jan 1, 2014";//2014/01/04
            article_1.isBanner = false;
            articleList.Add(article_1);
            #endregion

            #region SEO：重複內容(Duplicate Content)
            MeModels.Article article_2 = new MeModels.Article();
            article_2.Name = "SEO：重複內容(Duplicate Content)";
            article_2.Description = "網站中或網站間存在許多重複內容，而搜尋引擎為了提供使用者最佳的搜尋結果，便會對這些內容作區別，將最原始的資料或最佳的內容排在搜尋結果的最前面。 在某些情況下，重複內容是無法避免的，而這些重複內容損害了網站或網頁的排名。 因此，我們可以對這些重複內容做處理，修正搜尋引擎對它們的解讀。 這裡的搜尋引擎是以Google為主。";
            article_2.URL = "http://bit.ly/1z6veUU";
            article_2.RawPic = "/Content/me/img/blog/250528_3929.jpg";
            article_2.PicSmall = "/Content/me/img/blog/duplicate_content_188x73.jpg";
            article_2.PicMedium = "/Content/me/img/blog/duplicate_content_300.jpg";
            article_2.PicLarge = "/Content/me/img/blog/duplicate_content_940x367.jpg";
            article_2.PicInFooter = "/Content/me/img/blog/250528_3929_54x54.jpg";
            article_2.Tag = "SEO";
            article_2.isHighlight = false;
            article_2.Time = "Jan 22, 2014";
            article_2.isBanner = false;
            articleList.Add(article_2);
            #endregion

            #region 從搜尋到社群 - Semantics、Rich Snippets、Social Meta Tags
            MeModels.Article article_3 = new MeModels.Article();
            article_3.Name = "從搜尋到社群 - Semantics、Rich Snippets、Social Meta Tags";
            article_3.Description = "搜尋引擎提供使用者想要的資訊，而社群平台提供這些資訊更多露出的機會。我們希望將優質的內容提供給使用者，並利用社群的力量推廣出去。";
            article_3.URL = "http://bit.ly/1pNGBA3";
            article_3.RawPic = "/Content/me/img/blog/search_and_social.jpg";
            article_3.PicSmall = "/Content/me/img/blog/search_and_social_188x73.jpg";
            article_3.PicMedium = "/Content/me/img/blog/search_and_social_300.jpg";
            article_3.PicLarge = "/Content/me/img/blog/search_and_social_940x367.jpg";
            article_3.PicInFooter = "/Content/me/img/blog/search_and_social_54x54.jpg";
            article_3.Tag = "SEO, Rich Snippets";
            article_3.isHighlight = true;
            article_3.Time = "Feb 1, 2014";
            article_3.isBanner = false;
            articleList.Add(article_3);
            #endregion

            #region RSS：概念與實作
            MeModels.Article article_4 = new MeModels.Article();
            article_4.Name = "RSS：概念與實作";
            article_4.Description = "RSS(Really Simple Syndication，簡易資訊聚合)是一種消息來源格式規範，用以聚合經常發布更新數據的網站，例如博客文章、新聞、多媒體等的摘要或最新更新訊息。其目的為把新聞標題、摘要（Feed）、內容按照使用者的要求，「送」到使用者的面前。RSS摘要可以藉由RSS閱讀器、Feed Reader等軟體來閱讀(EX：Feedly、Digg)。";
            article_4.URL = "http://bit.ly/1wdcNBI";
            article_4.RawPic = "/Content/me/img/blog/505237_63345765.jpg";
            article_4.PicSmall = "/Content/me/img/blog/rss_188x73.jpg";
            article_4.PicMedium = "/Content/me/img/blog/rss_300.jpg";
            article_4.PicLarge = "/Content/me/img/blog/rss_940x367.jpg";
            article_4.PicInFooter = "/Content/me/img/blog/rss_54x54.jpg";
            article_4.Tag = "SEO";
            article_4.isHighlight = false;
            article_4.Time = "March 9, 2014";
            article_4.isBanner = false;
            articleList.Add(article_4);
            #endregion

            #region Author Rank
            MeModels.Article article_5 = new MeModels.Article();
            article_5.Name = "Author Rank";
            article_5.Description = "Author Rank是評估作者影響力的指標，過去尚未被證實是否會影響搜尋結果的排名，但Matt Cutts的一則Tweet似乎證實在某些地方確實會用到，例如專門領域文章的分析。";
            article_5.URL = "http://bit.ly/VIeBBC";
            article_5.RawPic = "/Content/me/img/blog/Michal_Koralewski_419846_14072013.jpg";
            article_5.PicSmall = "/Content/me/img/blog/author_rank_188x73.jpg";
            article_5.PicMedium = "/Content/me/img/blog/author_rank_300.jpg";
            article_5.PicLarge = "/Content/me/img/blog/author_rank_940x367.jpg";
            article_5.PicInFooter = "/Content/me/img/blog/author_rank_54x54.jpg";
            article_5.Tag = "SEO,Author Rank";
            article_5.isHighlight = false;
            article_5.Time = "March 22, 2014";
            article_5.isBanner = false;
            articleList.Add(article_5);
            #endregion

            #region 粉多任務 x 一品禪 - 使用Microdata標記的網頁實例
            MeModels.Article article_6 = new MeModels.Article();
            article_6.Name = "粉多任務 x 一品禪 - 使用Microdata標記的網頁實例";
            article_6.Description = "什麼是Microdata？標記符號的用途在於讓搜尋引擎有效讀懂網頁的內容，進而達到搜尋時呈現我們所提供的資料的方法。 畢竟直接告訴搜尋引擎重點在哪裡－－告訴它這是一篇文章的標題、內文、圖片和圖片說明，或告訴它這是商品區塊、這些文字是商品名稱或廠商名稱、告訴它這些數字是價錢(而非無意義的數字)，是比較有效率和精準的。而文中也說明標記如何使用和測試。";
            article_6.URL = "http://bit.ly/1wdf3ZQ";
            article_6.RawPic = "/Content/me/img/blog/yipinchan_website.png";
            article_6.PicSmall = "/Content/me/img/blog/microdata_188x73.jpg";
            article_6.PicMedium = "/Content/me/img/blog/microdata_300.png";
            article_6.PicLarge = "/Content/me/img/blog/microdata_940x367.jpg";
            article_6.PicInFooter = "/Content/me/img/blog/microdata_54x54.jpg";
            article_6.Tag = "SEO, Rich Snippets";
            article_6.isHighlight = false;
            article_6.Time = "April 21, 2014";
            article_6.isBanner = false;
            articleList.Add(article_6);
            #endregion

            #region 搜尋引擎優化指南(SEO Guideline) - 如何有系統的優化網站、評估與持續改進？
            MeModels.Article article_7 = new MeModels.Article();
            article_7.Name = "搜尋引擎優化指南(SEO Guideline) - 如何有系統的優化網站、評估與持續改進？";
            article_7.Description = "搜尋引擎優化指南(SEO Guideline)是一套有系統的優化網站的執行準則，每個崗位執行特定的工作項目即可讓網站(或專案)有一定品質以上的效果，並且這樣的優化效果是可以被評估、回饋與持續改進的。而系統化的實行也有助於在有限資源下做最大的利用，以得到最好的效果(例如：點閱率、排名)。";
            article_7.URL = "http://bit.ly/1tue7uA";
            article_7.RawPic = "/Content/me/img/blog/seo_guideline/seo_guideline.png";
            article_7.PicSmall = "/Content/me/img/blog/seo_guideline/seo_guideline_188x73.png";
            article_7.PicMedium = "/Content/me/img/blog/seo_guideline/seo_guideline_300.png";
            article_7.PicLarge = "/Content/me/img/blog/seo_guideline/seo_guideline_940x367.png";
            article_7.PicInFooter = "/Content/me/img/blog/seo_guideline/seo_guideline_54x54.png";
            article_7.Tag = "SEO";
            article_7.isHighlight = true;
            article_7.Time = "May 17, 2014";
            article_7.isBanner = false;
            articleList.Add(article_7);
            #endregion

            #region Facebook Graph API & Demo Example
            MeModels.Article article_8 = new MeModels.Article();
            article_8.Name = "Facebook Graph API & Demo Example";
            article_8.Description = "Graph API是Facebook所推出的一種技術標準，它的核心概念是「物件與連結」。 為什麼稱為「Graph API」呢？ 因為整個Facebook就是透過這些物件與連結建立而成的Social Graph。 Facebook所提供存取的介面，就稱為「Graph API」。";
            article_8.URL = "http://bit.ly/1qtutRh";
            article_8.RawPic = "/Images/twenty_800.jpg";
            article_8.PicSmall = "/Content/me/img/blog/facebook_social_demo_188x73.jpg";
            article_8.PicMedium = "/Content/me/img/blog/facebook_social_demo_300.jpg";
            article_8.PicLarge = "/Content/me/img/blog/facebook_social_demo_940x367.jpg";
            article_8.PicInFooter = "/Content/me/img/blog/facebook_social_demo_54x54.jpg";
            article_8.Tag = "Facebook, Graph API";
            article_8.isHighlight = false;
            article_8.Time = "June 7, 2014";
            article_8.isBanner = false;
            articleList.Add(article_8);
            #endregion

            #region 關鍵字(Keyword)與標籤(Tag)－談選擇、聚焦與經營
            MeModels.Article article_9 = new MeModels.Article();
            article_9.Name = "關鍵字(Keyword)與標籤(Tag)－談選擇、聚焦與經營";
            article_9.Description = "許多網站都設置關鍵字與標籤，但網站一定需要關鍵字、標籤嗎？關鍵字和標籤有什麼差別？能夠帶給網站什麼樣的成效？";
            article_9.URL = "http://bit.ly/1wdiFLc";
            article_9.RawPic = "/Content/me/img/blog/1430736_59220148_800.jpg";
            article_9.PicSmall = "/Content/me/img/blog/keyword_tag_188x73.jpg";
            article_9.PicMedium = "/Content/me/img/blog/keyword_tag_300.jpg";
            article_9.PicLarge = "/Content/me/img/blog/keyword_tag_940x367.jpg";
            article_9.PicInFooter = "/Content/me/img/blog/keyword_tag_54x54.jpg";
            article_9.Tag = "SEO, Keyword, Tag";
            article_9.isHighlight = true;
            article_9.Time = "Aug 16, 2014";
            article_9.isBanner = false;
            articleList.Add(article_9);
            #endregion

            #region Ember.js & SEO - 測試搜尋引擎對JavaScript的剖析能力
            MeModels.Article article_10 = new MeModels.Article();
            article_10.Name = "Ember.js & SEO - 測試搜尋引擎對JavaScript的剖析能力";
            article_10.Description = "Google Webmaster Central Blog在今年五月宣布 ，Google 搜尋能夠執行網頁上的 Javascript (見Understanding web pages better)﻿。而過去已知Crawler只會剖析網頁上的HTML Code，而不會(或少量)執行JavaScript。。又由於開發品質與速度的要求，使得Single Page Application (SPA) frameworks盛行(例如：Angular.js、Ember.js等)，於是了解搜尋引擎是否能夠執行並解讀JavaScript與解讀的程度便成為網站開發的其中一項需求。";
            article_10.URL = "http://bit.ly/1unwm55";
            article_10.RawPic = "/Content/me/img/blog/JavaScript_SEO.jpg";
            article_10.PicSmall = "/Content/me/img/blog/JavaScript_SEO_188x73.jpg";
            article_10.PicMedium = "/Content/me/img/blog/JavaScript_SEO_300.jpg";
            article_10.PicLarge = "/Content/me/img/blog/JavaScript_SEO_940x367.jpg";
            article_10.PicInFooter = "/Content/me/img/blog/JavaScript_SEO_54x54.jpg";
            article_10.Tag = "Ember.js, SEO";
            article_10.isHighlight = false;
            article_10.Time = "Sep 11, 2014";
            article_10.isBanner = false;
            articleList.Add(article_10);
            #endregion

            #region Facebook Graph API - Taggable Friends
            MeModels.Article article_11 = new MeModels.Article();
            article_11.Name = "Facebook Graph API - Taggable Friends";
            article_11.Description = "有鑑於IKEA做了一個好玩的活動網站來IKEA睡一晚，其中含有邀請朋友並標記、分享到Facebook上，因此也做了一個範例來玩玩。";
            article_11.URL = "http://bit.ly/1xptGc3";
            article_11.RawPic = "/Content/me/img/blog/Facebook_Graph_API_Taggable_Friends_940x367.jpg";
            article_11.PicSmall = "/Content/me/img/blog/Facebook_Graph_API_Taggable_Friends_188x73.jpg";
            article_11.PicMedium = "/Content/me/img/blog/Facebook_Graph_API_Taggable_Friends_300.jpg";
            article_11.PicLarge = "/Content/me/img/blog/Facebook_Graph_API_Taggable_Friends_940x367.jpg";
            article_11.PicInFooter = "/Content/me/img/blog/Facebook_Graph_API_Taggable_Friends_54x54.jpg";
            article_11.Tag = "Facebook, Graph API";
            article_11.isHighlight = false;
            article_11.Time = "Sep 24, 2014";
            article_11.isBanner = false;
            articleList.Add(article_11);
            #endregion

            #region Facebook Product Introduction 產品總整理與功能說明
            MeModels.Article article_12 = new MeModels.Article();
            article_12.Name = "Facebook Product Introduction 產品總整理與功能說明";
            article_12.Description = "Facebook產品總整理與功能說明(Social Plugins、Sharing、其他UI功能應用、Graph API功能應用、og相關、權限相關、成效衡量)。";
            article_12.URL = "http://bit.ly/ZyYSYx";
            article_12.RawPic = "/Content/me/img/blog/facebook_product_introduction/facebook_product_introduction.jpg";
            article_12.PicSmall = "/Content/me/img/blog/facebook_product_introduction/facebook_product_introduction_188x73.jpg";
            article_12.PicMedium = "/Content/me/img/blog/facebook_product_introduction/facebook_product_introduction_300.jpg";
            article_12.PicLarge = "/Content/me/img/blog/facebook_product_introduction/facebook_product_introduction_940x367.jpg";
            article_12.PicInFooter = "/Content/me/img/blog/facebook_product_introduction/facebook_product_introduction_54x54.jpg";
            article_12.Tag = "Facebook, Graph API";
            article_12.isHighlight = false;
            article_12.Time = "Oct 3, 2014";
            article_12.isBanner = false;
            articleList.Add(article_12);
            #endregion

            #region 2014 SEO Ranking Factors - 點閱率CTR成為最重要的因子、利用標籤競爭SERPs排名
            MeModels.Article article_13 = new MeModels.Article();
            article_13.Name = "2014 SEO Ranking Factors - 點閱率CTR成為最重要的因子、利用標籤競爭SERPs排名";
            article_13.Description = "2013年的SEO Rankgin Factors著重於頁面優化、如何呈現好的內容與社群平台的散播。與2013相較，2014年最大的不同在於CTR變成SERPs排行中最重要的因子，並強調了使用者的動向(User Signals)，除了CTR還有使用者停留時間(Time on Site)、跳出率(Bounse Rate)、更全面性的評估，例如相關詞彙(Relevant Terms)、網站速度(Site Speed)。";
            article_13.URL = "http://bit.ly/1vP70Pz";
            article_13.RawPic = "/Content/me/img/blog/seo-ranking-factors-2014.png";
            article_13.PicSmall = "/Content/me/img/blog/seo-ranking-factors-2014_188x73.png";
            article_13.PicMedium = "/Content/me/img/blog/seo-ranking-factors-2014_300.png";
            article_13.PicLarge = "/Content/me/img/blog/seo-ranking-factors-2014_940x367.png";
            article_13.PicInFooter = "/Content/me/img/blog/seo-ranking-factors-2014_54x54.jpg";
            article_13.Tag = "SEO, Ranking Factor";
            article_13.isHighlight = false;
            article_13.Time = "Oct 9, 2014";
            article_13.isBanner = false;
            articleList.Add(article_13);
            #endregion

            #region CKEditor Addons - 簡易上傳圖片、檔案(SimpleUploads)、Youtube影片搜尋(CKEditor Youtube + search feature)
            MeModels.Article article_14 = new MeModels.Article();
            article_14.Name = "CKEditor Addons - 簡易上傳圖片、檔案(SimpleUploads)、Youtube影片搜尋(CKEditor Youtube + search feature)";
            article_14.Description = "CKEditor是一款「所見即所得」(WYSIWYG) 的 HTML網頁編輯器，免費、功能強大、周邊資源多。下載後經過簡單安裝便能作為前台或後台編輯工具。";
            article_14.URL = "http://bit.ly/1vgZMVi";
            article_14.RawPic = "/Content/me/img/blog/ckeditor_addons_simpleuploads_youtube_search_feature/sckeditor_addons_simpleuploads_youtube_search_feature.jpg";
            article_14.PicSmall = "/Content/me/img/blog/ckeditor_addons_simpleuploads_youtube_search_feature/ckeditor_addons_simpleuploads_youtube_search_feature_188x73.jpg";
            article_14.PicMedium = "/Content/me/img/blog/ckeditor_addons_simpleuploads_youtube_search_feature/ckeditor_addons_simpleuploads_youtube_search_feature_300.jpg";
            article_14.PicLarge = "/Content/me/img/blog/ckeditor_addons_simpleuploads_youtube_search_feature/ckeditor_addons_simpleuploads_youtube_search_feature_940x367.jpg";
            article_14.PicInFooter = "/Content/me/img/blog/ckeditor_addons_simpleuploads_youtube_search_feature/ckeditor_addons_simpleuploads_youtube_search_feature_54x54.jpg";
            article_14.Tag = "CKEditor";
            article_14.isHighlight = false;
            article_14.Time = "Oct 16, 2014";
            article_14.isBanner = false;
            articleList.Add(article_14);
            #endregion

            #region RWD(Responsive Web Design) 實作筆記
            MeModels.Article article_15 = new MeModels.Article();
            article_15.Name = "RWD(Responsive Web Design) 實作筆記";
            article_15.Description = "RWD(Responsive Web Design)是一種設計概念，希望能讓網頁適用在不同的平台上。 而距離上一次專做RWD大約是一年前，公司最近想對產品大改版，於是又來練練RWD摟！";
            article_15.URL = "http://bit.ly/1wgGsWx";
            article_15.RawPic = "/Content/me/img/blog/rwd_implement_note/rwd_implement_note.png";
            article_15.PicSmall = "/Content/me/img/blog/rwd_implement_note/rwd_implement_note_188x73.png";
            article_15.PicMedium = "/Content/me/img/blog/rwd_implement_note/rwd_implement_note_300.png";
            article_15.PicLarge = "/Content/me/img/blog/rwd_implement_note/rwd_implement_note_940x367.png";
            article_15.PicInFooter = "/Content/me/img/blog/rwd_implement_note/rwd_implement_note_54x54.jpg";
            article_15.Tag = "RWD";
            article_15.isHighlight = false;
            article_15.Time = "Oct 19, 2014";
            article_15.isBanner = false;
            articleList.Add(article_15);
            #endregion

            #region 使用Graph API上傳圖片到Facebook相簿、並設定為使用者大頭照
            MeModels.Article article_16 = new MeModels.Article();
            article_16.Name = "使用Graph API上傳圖片到Facebook相簿、並設定為使用者大頭照";
            article_16.Description = "有不少活動都會引導使用者上傳圖片並設定為封面或是檔案頭像，例如 遮打革命 Umbrella Revolution - Support Campaign | Twibbon。";
            article_16.URL = "http://bit.ly/1yRtaV8";
            article_16.RawPic = "/Content/me/img/blog/upload_photos_to_users_profile_via_graph_api_and_change_profile_picture/upload_photos_to_users_profile_via_graph_api_and_change_profile_picture.jpg";
            article_16.PicSmall = "/Content/me/img/blog/upload_photos_to_users_profile_via_graph_api_and_change_profile_picture/upload_photos_to_users_profile_via_graph_api_and_change_profile_picture_188x73.jpg";
            article_16.PicMedium = "/Content/me/img/blog/upload_photos_to_users_profile_via_graph_api_and_change_profile_picture/upload_photos_to_users_profile_via_graph_api_and_change_profile_picture_300.jpg";
            article_16.PicLarge = "/Content/me/img/blog/upload_photos_to_users_profile_via_graph_api_and_change_profile_picture/upload_photos_to_users_profile_via_graph_api_and_change_profile_picture_940x367.jpg";
            article_16.PicInFooter = "/Content/me/img/blog/upload_photos_to_users_profile_via_graph_api_and_change_profile_picture/upload_photos_to_users_profile_via_graph_api_and_change_profile_picture_54x54.jpg";
            article_16.Tag = "Graph API";
            article_16.isHighlight = false;
            article_16.Time = "Oct 20, 2014";
            article_16.isBanner = false;
            articleList.Add(article_16);
            #endregion

            #region D3.js - Bar Chart
            MeModels.Article article_17 = new MeModels.Article();
            article_17.Name = "D3.js - Bar Chart";
            article_17.Description = "D3是Data-Driven Documents，是將資料視覺化呈現的library，甚至可與使用者互動。舉凡Bar Chart、Pie Chart、Bubble Chart、Tag Cloud或更複雜有趣的圖表，都可以以之呈現。";
            article_17.URL = "http://cythilya.blogspot.tw/2014/10/d3js-bar-chart.html";
            article_17.RawPic = "/Content/me/img/blog/d3_bar_chart/d3_bar_chart.png";
            article_17.PicSmall = "/Content/me/img/blog/d3_bar_chart/d3_bar_chart_188x73.jpg";
            article_17.PicMedium = "/Content/me/img/blog/d3_bar_chart/d3_bar_chart_300.jpg";
            article_17.PicLarge = "/Content/me/img/blog/d3_bar_chart/d3_bar_chart_940x367.jpg";
            article_17.PicInFooter = "/Content/me/img/blog/d3_bar_chart/d3_bar_chart_54x54.jpg";
            article_17.Tag = "D3.js, Data Visualization";
            article_17.isHighlight = false;
            article_17.Time = "Oct 30, 2014";
            article_17.isBanner = false;
            articleList.Add(article_17);
            #endregion

            #region 使用Node.js + Express建構一個簡單的微博網站
            MeModels.Article article_18 = new MeModels.Article();
            article_18.Name = "使用Node.js + Express建構一個簡單的微博網站";
            article_18.Description = "使用Node.js + Express建構一個簡單的微博網站。";
            article_18.URL = "http://cythilya.blogspot.tw/2014/11/nodejs-express-microblog.html";
            article_18.RawPic = "/Content/me/img/blog/nodejs-express-microblo/nodejs-express-microblo.jpg";
            article_18.PicSmall = "/Content/me/img/blog/nodejs-express-microblo/nodejs-express-microblo_188x73.jpg";
            article_18.PicMedium = "/Content/me/img/blog/nodejs-express-microblo/nodejs-express-microblo_300.jpg";
            article_18.PicLarge = "/Content/me/img/blog/nodejs-express-microblo/nodejs-express-microblo_940x367.jpg";
            article_18.PicInFooter = "/Content/me/img/blog/nodejs-express-microblo/nodejs-express-microblo_54x54.jpg";
            article_18.Tag = "Node.js, Express";
            article_18.isHighlight = false;
            article_18.Time = "Nov 23, 2014";
            article_18.isBanner = false;
            articleList.Add(article_18);
            #endregion

            #region 談如何利用標籤(Tag)加強網站的近似辭彙(Relevant Terms)
            MeModels.Article article_19 = new MeModels.Article();
            article_19.Name = "談如何利用標籤(Tag)加強網站的近似辭彙(Relevant Terms)";
            article_19.Description = "2014年的Ranking Factor中，Relevant Terms是一個重要因子，它代表了這個網站對於特定主題的近似字詞。而一個頁面是否能針對特定主題被搜尋到，除了佈署特定關鍵字外，搜尋引擎也會觀察這個頁面是否有其他語意接近的關鍵字。";
            article_19.URL = "http://cythilya.blogspot.tw/2014/11/tag-relevant-terms.html";
            article_19.RawPic = "/Content/me/img/blog/tag-relevant-terms/tag-relevant-terms.jpg";
            article_19.PicSmall = "/Content/me/img/blog/tag-relevant-terms/tag-relevant-terms_188x73.jpg";
            article_19.PicMedium = "/Content/me/img/blog/tag-relevant-terms/tag-relevant-terms_300.jpg";
            article_19.PicLarge = "/Content/me/img/blog/tag-relevant-terms/tag-relevant-terms_940x367.jpg";
            article_19.PicInFooter = "/Content/me/img/blog/tag-relevant-terms/tag-relevant-terms_54x54.jpg";
            article_19.Tag = "SEO, Tag, Ranking Factor, Relevant Terms";
            article_19.isHighlight = false;
            article_19.Time = "Nov 26, 2014";
            article_19.isBanner = false;
            articleList.Add(article_19);
            #endregion

            #region App Store Optimization (ASO) Guideline
            MeModels.Article article_20 = new MeModels.Article();
            article_20.Name = "App Store Optimization (ASO) Guideline";
            article_20.Description = "App Store Optimization (ASO) is the process of improving a mobile app’s visibility within mobile app stores (such as the iOS App Store and Google Play Store) by optimizing the content of the app’s store page for popular, targeted keyword phrases.";
            article_20.URL = "http://cythilya.blogspot.tw/2014/12/aso-guideline.html";
            article_20.RawPic = "/Content/me/img/blog/ASO_Guideline/ASO_Guideline.jpg";
            article_20.PicSmall = "/Content/me/img/blog/ASO_Guideline/ASO_Guideline_188x73.jpg";
            article_20.PicMedium = "/Content/me/img/blog/ASO_Guideline/ASO_Guideline_300.jpg";
            article_20.PicLarge = "/Content/me/img/blog/ASO_Guideline/ASO_Guideline_940x367.jpg";
            article_20.PicInFooter = "/Content/me/img/blog/ASO_Guideline/ASO_Guideline_54x54.jpg";
            article_20.Tag = "ASO";
            article_20.isHighlight = false;
            article_20.Time = "Dec 22, 2014";
            article_20.isBanner = false;
            articleList.Add(article_20);
            #endregion

            #region 電子商務網站SEO實例探討
            MeModels.Article article_21 = new MeModels.Article();
            article_21.Name = "電子商務網站SEO實例探討";
            article_21.Description = "大部份會做SEO的網站不外乎是電子商務、活動網站、內容/服務平台(例如：新聞、旅遊)。而極端如Campaign Site這樣類型的網站由於存活時間短，便不需要做SEO，只要放置簡單的Meta Tag或Social Meta Tag即可。";
            article_21.URL = "http://cythilya.blogspot.tw/2015/01/a-practice-to-seo-in-ec-website.html";
            article_21.RawPic = "/Content/me/img/blog/a_practice_to_seo_in_ec_website/a_practice_to_seo_in_ec_website.jpg";
            article_21.PicSmall = "/Content/me/img/blog/a_practice_to_seo_in_ec_website/a_practice_to_seo_in_ec_website_188x73.jpg";
            article_21.PicMedium = "/Content/me/img/blog/a_practice_to_seo_in_ec_website/a_practice_to_seo_in_ec_website_300.jpg";
            article_21.PicLarge = "/Content/me/img/blog/a_practice_to_seo_in_ec_website/a_practice_to_seo_in_ec_website_940x367.jpg";
            article_21.PicInFooter = "/Content/me/img/blog/a_practice_to_seo_in_ec_website/a_practice_to_seo_in_ec_website_54x54.jpg";
            article_21.Tag = "SEO";
            article_21.isHighlight = false;
            article_21.Time = "Jan 24, 2015";
            article_21.isBanner = false;
            articleList.Add(article_21);
            #endregion

            #region 吃什麼，どっち - 讓朋友幫你決定吃什麼 (ALPHA Hackathon 2015)
            MeModels.Article article_22 = new MeModels.Article();
            article_22.Name = "吃什麼，どっち - 讓朋友幫你決定吃什麼 (ALPHA Hackathon 2015)";
            article_22.Description = "使用者藉由輸入簡單的字詞，例如：「台北市中山區 火鍋」，按下「尋找餐廳」後就能從列表中找到符合項目的推薦餐廳，或按下「看看朋友吃什麼」，經由Facebook授權登入後，看看朋友去過哪些地方、評價。而我們也會爬回Facebook上的資訊做處理並排序，推薦適合的餐廳給使用者。";
            article_22.URL = "http://cythilya.blogspot.tw/2015/02/dotchi.html";
            article_22.RawPic = "/Content/me/img/blog/dotchi/dotchi.png";
            article_22.PicSmall = "/Content/me/img/blog/dotchi/dotchi_188x73.png";
            article_22.PicMedium = "/Content/me/img/blog/dotchi/dotchi_300.png";
            article_22.PicLarge = "/Content/me/img/blog/dotchi/dotchi_940x367.png";
            article_22.PicInFooter = "/Content/me/img/blog/dotchi/dotchi_54x54.png";
            article_22.Tag = "SEO, Tag, Relevant Terms, Hackathon";
            article_22.isHighlight = true;
            article_22.Time = "Feb 2, 2015";
            article_22.isBanner = false;
            articleList.Add(article_22);
            #endregion

            #region Facebook Login Review筆記 Day 1 - Overview
            MeModels.Article article_23 = new MeModels.Article();
            article_23.Name = "Facebook Login Review筆記 Day 1 - Overview";
            article_23.Description = "由於今年的4月30日Facebook Graph API 1.0即將退休，取而代之的是2.0+，因此從年初開始，一直收到Facebook的Alert。為了避免App被break，我開始對使用1.0的App做修改來提交Review。以下是一些筆記。";
            article_23.URL = "http://cythilya.blogspot.tw/2015/02/facebook-login-review.html";
            article_23.RawPic = "/Content/me/img/blog/facebook_login_review/facebook_login_review.jpg";
            article_23.PicSmall = "/Content/me/img/blog/facebook_login_review/facebook_login_review_188x73.jpg";
            article_23.PicMedium = "/Content/me/img/blog/facebook_login_review/facebook_login_review_300.jpg";
            article_23.PicLarge = "/Content/me/img/blog/facebook_login_review/facebook_login_review_940x367.jpg";
            article_23.PicInFooter = "/Content/me/img/blog/facebook_login_review/facebook_login_review_54x54.jpg";
            article_23.Tag = "Facebook, Graph API";
            article_23.isHighlight = false;
            article_23.Time = "Feb 4, 2015";
            article_23.isBanner = false;
            articleList.Add(article_23);
            #endregion

            #region Facebook Login Review筆記 Day 2 - Policies and Best Practices
            MeModels.Article article_24 = new MeModels.Article();
            article_24.Name = "Facebook Login Review筆記 Day 2 - Policies and Best Practices";
            article_24.Description = "Facebook Login Review筆記 Day 2 - Policies and Best Practices";
            article_24.URL = "http://cythilya.blogspot.tw/2015/02/facebook-login-review-day-2.html";
            article_24.RawPic = "/Content/me/img/blog/facebook_login_review_day_2/facebook_login_review_day_2.png";
            article_24.PicSmall = "/Content/me/img/blog/facebook_login_review_day_2/facebook_login_review_day_2_188x73.png";
            article_24.PicMedium = "/Content/me/img/blog/facebook_login_review_day_2/facebook_login_review_day_2_300.png";
            article_24.PicLarge = "/Content/me/img/blog/facebook_login_review_day_2/facebook_login_review_day_2_940x367.png";
            article_24.PicInFooter = "/Content/me/img/blog/facebook_login_review_day_2/facebook_login_review_day_2_54x54.png";
            article_24.Tag = "Facebook, Graph API";
            article_24.isHighlight = false;
            article_24.Time = "Feb 5, 2015";
            article_24.isBanner = false;
            articleList.Add(article_24);
            #endregion

            #region 使用Bootstrap建立一個RWD Template (Twitter Bootstrap in Responsive Web Design)
            MeModels.Article article_25 = new MeModels.Article();
            article_25.Name = "使用Bootstrap建立一個RWD Template (Twitter Bootstrap in Responsive Web Design)";
            article_25.Description = "使用Bootstrap建立一個RWD Template的筆記。";
            article_25.URL = "http://cythilya.blogspot.tw/2015/02/bootstrap-rwd-template.html";
            article_25.RawPic = "/Content/me/img/blog/bootstrap_rwd_template/bootstrap_rwd_template.jpg";
            article_25.PicSmall = "/Content/me/img/blog/bootstrap_rwd_template/bootstrap_rwd_template_188x73.jpg";
            article_25.PicMedium = "/Content/me/img/blog/bootstrap_rwd_template/bootstrap_rwd_template_300.jpg";
            article_25.PicLarge = "/Content/me/img/blog/bootstrap_rwd_template/bootstrap_rwd_template_940x367.jpg";
            article_25.PicInFooter = "/Content/me/img/blog/bootstrap_rwd_template/bootstrap_rwd_template_54x54.jpg";
            article_25.Tag = "RWD, Mobile Search, Bootstrap";
            article_25.isHighlight = false;
            article_25.Time = "Feb 27, 2015";
            article_25.isBanner = false;
            articleList.Add(article_25);
            #endregion

            #region Upgrade Guide - Upgrading from v1.0 to v2.0
            MeModels.Article article_26 = new MeModels.Article();
            article_26.Name = "Upgrade Guide - Upgrading from v1.0 to v2.0";
            article_26.Description = "Graph API升級筆記。";
            article_26.URL = "http://cythilya.blogspot.tw/2015/03/upgrade-guide-upgrading-from-v10-to-v20.html";
            article_26.RawPic = "/Content/me/img/blog/upgrade_guide_upgrading_from_v10_to_v20/upgrade_guide_upgrading_from_v10_to_v20.jpg";
            article_26.PicSmall = "/Content/me/img/blog/upgrade_guide_upgrading_from_v10_to_v20/upgrade_guide_upgrading_from_v10_to_v20_188x73.jpg";
            article_26.PicMedium = "/Content/me/img/blog/upgrade_guide_upgrading_from_v10_to_v20/upgrade_guide_upgrading_from_v10_to_v20_300.jpg";
            article_26.PicLarge = "/Content/me/img/blog/upgrade_guide_upgrading_from_v10_to_v20/upgrade_guide_upgrading_from_v10_to_v20_940x367.jpg";
            article_26.PicInFooter = "/Content/me/img/blog/upgrade_guide_upgrading_from_v10_to_v20/upgrade_guide_upgrading_from_v10_to_v20_54x54.jpg";
            article_26.Tag = "Facebook, Graph API";
            article_26.isHighlight = false;
            article_26.Time = "March 4, 2015";
            article_26.isBanner = false;
            articleList.Add(article_26);
            #endregion

            #region YHA美荷樓青年旅舍 (YHA Mei Ho House Youth Hostel)
            MeModels.Article article_27 = new MeModels.Article();
            article_27.Name = "YHA美荷樓青年旅舍 (YHA Mei Ho House Youth Hostel)";
            article_27.Description = "藉UXHK 2015之便，我們在香港多待了幾天。而來去香港好幾次，每次我爸都習慣訂YMCA，但無奈改建成高級酒店，像我們這樣的小資女孩是無法負擔的。同行夥伴小奎找到一間「YHA美荷樓青年旅舍 (YHA Mei Ho House Youth Hostel)」，看起來交通方便(近港鐵深水埗站)、環境漂亮又安全、價格便宜，就訂了下來。";
            article_27.URL = "http://cythilya.blogspot.tw/2015/03/yha-mei-ho-house-youth-hostel.html";
            article_27.RawPic = "/Content/me/img/blog/yha_mei_ho_house_youth_hostel/yha_mei_ho_house_youth_hostel_940x367.jpg";
            article_27.PicSmall = "/Content/me/img/blog/yha_mei_ho_house_youth_hostel/yha_mei_ho_house_youth_hostel_188x73.jpg";
            article_27.PicMedium = "/Content/me/img/blog/yha_mei_ho_house_youth_hostel/yha_mei_ho_house_youth_hostel_300.jpg";
            article_27.PicLarge = "/Content/me/img/blog/yha_mei_ho_house_youth_hostel/yha_mei_ho_house_youth_hostel_940x367.jpg";
            article_27.PicInFooter = "/Content/me/img/blog/yha_mei_ho_house_youth_hostel/yha_mei_ho_house_youth_hostel_54x54.jpg";
            article_27.Tag = "Hong Kong, 住宿, 深水埗, 添好運, 港式點心, 石硤尾邨, 美荷樓, 美荷樓 呼吸冰室, 美荷樓 生活館, 美食, 貴州菜, 青年旅舍, 香港, 黔菜, 黔館";
            article_27.isHighlight = false;
            article_27.Time = "March 15, 2015";
            article_27.isBanner = false;
            articleList.Add(article_27);
            #endregion

            #region 赤柱 (Stanley) - 悠閒愜意的異國風情小鎮
            MeModels.Article article_28 = new MeModels.Article();
            article_28.Name = "赤柱 (Stanley) - 悠閒愜意的異國風情小鎮";
            article_28.Description = "如果準備搭飛機離港前剛好有一小段時間不知道要幹嘛的話，可以考慮到 赤柱(Stanley) 逛逛。赤柱像是沒有商業化又比較乾淨的淡水，跟西貢比起來更有異國風情味。";
            article_28.URL = "http://cythilya.blogspot.tw/2015/03/stanley.html";
            article_28.RawPic = "/Content/me/img/blog/stanley/stanley_940x367.jpg";
            article_28.PicSmall = "/Content/me/img/blog/stanley/stanley_188x73.jpg";
            article_28.PicMedium = "/Content/me/img/blog/stanley/stanley_300.png";
            article_28.PicLarge = "/Content/me/img/blog/stanley/stanley_940x367.jpg";
            article_28.PicInFooter = "/Content/me/img/blog/stanley/stanley_54x54.jpg";
            article_28.Tag = "Hong Kong, Stanley, 卜公碼頭, 赤柱, 赤柱大街, 赤柱市集, 赤柱海濱長廊, 赤柱美利樓, 香港";
            article_28.isHighlight = false;
            article_28.Time = "March 17, 2015";
            article_28.isBanner = false;
            articleList.Add(article_28);
            #endregion

            #region 利用Bootstrap Grid System排版的學習筆記
            MeModels.Article article_31 = new MeModels.Article();
            article_31.Name = "利用Bootstrap Grid System排版的學習筆記";
            article_31.Description = "利用Bootstrap Grid System來排版真是一個方便的方法，最簡單的例子就是如果一個頁面上有許多小方格會隨著Device/解析度而有不同的排列方式，就很適合用Grid System來排版。";
            article_31.URL = "http://cythilya.blogspot.tw/2015/04/bootstrap-grid-system.html";
            article_31.RawPic = "/Content/me/img/blog/bootstrap_grid_system_in_responsive_web_design/bootstrap_grid_system_in_responsive_web_design.png";
            article_31.PicSmall = "/Content/me/img/blog/bootstrap_grid_system_in_responsive_web_design/bootstrap_grid_system_in_responsive_web_design_188x73.png";
            article_31.PicMedium = "/Content/me/img/blog/bootstrap_grid_system_in_responsive_web_design/bootstrap_grid_system_in_responsive_web_design_300.png";
            article_31.PicLarge = "/Content/me/img/blog/bootstrap_grid_system_in_responsive_web_design/bootstrap_grid_system_in_responsive_web_design_940x367.png";
            article_31.PicInFooter = "/Content/me/img/blog/bootstrap_grid_system_in_responsive_web_design/bootstrap_grid_system_in_responsive_web_design_54x54.png";
            article_31.Tag = "RWD, Bootstrap";
            article_31.isHighlight = false;
            article_31.Time = "April 7, 2015";
            article_31.isBanner = false;
            articleList.Add(article_31);
            #endregion

            #region Responsive Patterns - Layout
            MeModels.Article article_32 = new MeModels.Article();
            article_32.Name = "Responsive Patterns - Layout";
            article_32.Description = "Responsive Patterns 是一個蒐集響應式設計與實作的元件庫，舉凡Layout、Navigation、Forms、Carousel、Tabs、Accordion和Lightbox等皆有，很適合當成學習教材。先來玩玩Layout吧。我們分成幾大類：Reflowing、Equal Width、Off Canvas、Source-Order Shift、Lists、Grid Block。";
            article_32.URL = "http://cythilya.blogspot.tw/2015/04/responsive-patterns-layout.html";
            article_32.RawPic = "/Content/me/img/blog/responsive_patterns_layout/responsive_patterns_layout.jpg";
            article_32.PicSmall = "/Content/me/img/blog/responsive_patterns_layout/responsive_patterns_layout_188x73.png";
            article_32.PicMedium = "/Content/me/img/blog/responsive_patterns_layout/responsive_patterns_layout_300.jpg";
            article_32.PicLarge = "/Content/me/img/blog/responsive_patterns_layout/responsive_patterns_layout_940x367.png";
            article_32.PicInFooter = "/Content/me/img/blog/responsive_patterns_layout/responsive_patterns_layout_54x54.jpg";
            article_32.Tag = "RWD";
            article_32.isHighlight = false;
            article_32.Time = "April 22, 2015";
            article_32.isBanner = false;
            articleList.Add(article_32);
            #endregion

            #region JavaScript - Closure與Hoisting
            MeModels.Article article_33 = new MeModels.Article();
            article_33.Name = "JavaScript - Closure與Hoisting";
            article_33.Description = "分散var來宣告變數並沒有太大的意義，因為就JavaScript程式語言的特性來說，函數(Function)中未宣告而先用到的變數會被提升至區塊的第一行做宣告。先來看基本觀念Closure，再來看Hoisting。";
            article_33.URL = "http://cythilya.blogspot.tw/2015/05/javascript-patterns-closure-hoisting.html";
            article_33.RawPic = "/Content/me/img/blog/javascript_patterns/javascript_patterns.jpg";
            article_33.PicSmall = "/Content/me/img/blog/javascript_patterns/javascript_patterns_188x73.jpg";
            article_33.PicMedium = "/Content/me/img/blog/javascript_patterns/javascript_patterns_300.jpg";
            article_33.PicLarge = "/Content/me/img/blog/javascript_patterns/javascript_patterns_940x367.jpg";
            article_33.PicInFooter = "/Content/me/img/blog/javascript_patterns/javascript_patterns_54x54.jpg";
            article_33.Tag = "JavaScript, Closure, Hoisting";
            article_33.isHighlight = false;
            article_33.Time = "May 1, 2015";
            article_33.isBanner = false;
            articleList.Add(article_33);
            #endregion

            #region JavaScript - Call and Apply
            MeModels.Article article_34 = new MeModels.Article();
            article_34.Name = "JavaScript - Call and Apply";
            article_34.Description = "call與apply兩者皆是執行某個function，並將這個function的context(即物件)替換成第一個代入的參數。其差異在於call必須將參數一一代入，而apply除了第一個參數代入context外，其餘的參數只要包在一個陣列裡面即可。註：第二個參數不是必須的(optional)。";
            article_34.URL = "http://cythilya.blogspot.tw/2015/05/javascript-call-and-apply.html";
            article_34.RawPic = "/Content/me/img/blog/javascript_patterns/javascript_patterns.jpg";
            article_34.PicSmall = "/Content/me/img/blog/javascript_patterns/javascript_patterns_188x73.jpg";
            article_34.PicMedium = "/Content/me/img/blog/javascript_patterns/javascript_patterns_300.jpg";
            article_34.PicLarge = "/Content/me/img/blog/javascript_patterns/javascript_patterns_940x367.jpg";
            article_34.PicInFooter = "/Content/me/img/blog/javascript_patterns/javascript_patterns_54x54.jpg";
            article_34.Tag = "JavaScript, Call, Apply";
            article_34.isHighlight = false;
            article_34.Time = "May 3, 2015";
            article_34.isBanner = false;
            articleList.Add(article_34);
            #endregion

            #region JavaScript - JSON.parse and JSON.stringify
            MeModels.Article article_35 = new MeModels.Article();
            article_35.Name = "JavaScript - JSON.parse and JSON.stringify";
            article_35.Description = "使用JSON做Client端與Server端資料傳遞的說明與範例。";
            article_35.URL = "http://cythilya.blogspot.tw/2015/05/javascript-json-parse-stringify.html";
            article_35.RawPic = "/Content/me/img/blog/javascript_patterns/javascript_patterns.jpg";
            article_35.PicSmall = "/Content/me/img/blog/javascript_patterns/javascript_patterns_188x73.jpg";
            article_35.PicMedium = "/Content/me/img/blog/javascript_patterns/javascript_patterns_300.jpg";
            article_35.PicLarge = "/Content/me/img/blog/javascript_patterns/javascript_patterns_940x367.jpg";
            article_35.PicInFooter = "/Content/me/img/blog/javascript_patterns/javascript_patterns_54x54.jpg";
            article_35.Tag = "JavaScript";
            article_35.isHighlight = false;
            article_35.Time = "May 9, 2015";
            article_35.isBanner = false;
            articleList.Add(article_35);
            #endregion

            #endregion

            articleList.Reverse();

            ViewBag.ArticleList = articleList;
            return articleList;
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
            proj_1.Role = "Front-End Development";
            proj_1.Tech = "";
            proj_1.URL = "/Me/Project?id=1";
            proj_1.RawPic = "/Content/me/img/project/one_piece_z/one_piece_z_index.png";
            proj_1.PicSmall = "/Content/me/img/project/one_piece_z/one_piece_z_index_188x73.png";
            proj_1.PicMedium = "/Content/me/img/project/one_piece_z/one_piece_z_index_300.png";
            proj_1.PicLarge = "/Content/me/img/project/one_piece_z/one_piece_z_index_940x367.jpg";
            proj_1.PicInFooter = "/Content/me/img/project/one_piece_z/one_piece_z_index_54x54.png";
            proj_1.Order = 4;
            proj_1.Client = "采昌國際多媒體";
            proj_1.ClientURL = "http://www.ccii.com.tw/chweb/index.asp";
            proj_1.Date = "Jan 2013";
            proj_1.LauchURL = "http://www.ccii.com.tw/OPZ";
            proj_1.HtmlContent = "<p>ONE PIECE FILM Z【航海王電影:Z】官方網站1月25日決戰新世界。</p>";
            proj_1.Tag = "Web CampignSite";
            proj_1.isHighlight = false;
            proj_1.IsShowInPortfolio = true;

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
            proj_2.Role = "Front-End Development and C# Backend";
            proj_2.Tech = "Web Development with jQuery and C#";
            proj_2.URL = "/Me/Project?id=2";
            proj_2.RawPic = "/Content/me/img/project/party/party_index_940x1025.png";
            proj_2.PicSmall = "/Content/me/img/project/party/party_index_188x73.png";
            proj_2.PicMedium = "/Content/me/img/project/party/party_index_300.png";
            proj_2.PicLarge = "/Content/me/img/project/party/party_index_940x367.jpg";
            proj_2.PicInFooter = "/Content/me/img/project/party/party_index_54x54.png";
            proj_2.Order = 1;
            proj_2.Client = "Friendo 粉多任務";
            proj_2.ClientURL = "http://www.friendo.com.tw/About/Friendo";
            proj_2.Date = "July 2012 - Aug 2014";
            proj_2.LauchURL = "";
            proj_2.HtmlContent = "<p>粉多網路辦桌大請客，粉多為了慶祝台灣第一個雲端社群網站開站，舉辦網路辦桌活動。在活動時間內，使用Facebook登入並成為粉多會員後點選「免費請我」即可參加抽獎。</p><p>每天都有不同商品，每天能抽當天的商品。當天邀請Facebook朋友參加，此帳號當日得獎機率提升為2倍。</p>";
            proj_2.Tag = "Web Platform";
            proj_2.isHighlight = false;
            proj_2.IsShowInPortfolio = true;

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
            proj_3.Role = "Front-End Development";
            proj_3.Tech = "";
            proj_3.URL = "/Me/Project?id=3";
            proj_3.RawPic = "/Content/me/img/project/party_hlh/party_index_hlh.png";
            proj_3.PicSmall = "/Content/me/img/project/party_hlh/party_index_hlh_188x73.png";
            proj_3.PicMedium = "/Content/me/img/project/party_hlh/party_index_hlh_300.png";
            proj_3.PicLarge = "/Content/me/img/project/party_hlh/party_index_hlh_940x367.png";
            proj_3.PicInFooter = "/Content/me/img/project/party_hlh/party_index_hlh_54x54.png";
            proj_3.Order = 2;
            proj_3.Client = "恆隆行";
            proj_3.ClientURL = "http://www.hlh.com.tw";
            proj_3.Date = "Aug 2012";
            proj_3.LauchURL = "";
            proj_3.HtmlContent = "<p>粉多辦桌和恆隆行合作所特別製作的首頁與活動盛況頁面。";
            proj_3.Tag = "Web";
            proj_3.isHighlight = false;
            proj_3.IsShowInPortfolio = true;

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
            proj_4.Role = "UI Design, Front-End Development and C# Backend";
            proj_4.Tech = "SCSS, jQuery and C#";
            proj_4.URL = "/Me/Project?id=4";
            proj_4.RawPic = "/Content/me/img/project/mission/mission_index_940x812.png";
            proj_4.PicSmall = "/Content/me/img/project/mission/mission_index_188x73.png";
            proj_4.PicMedium = "/Content/me/img/project/mission/mission_index_300.png";
            proj_4.PicLarge = "/Content/me/img/project/mission/mission_index_940x367.jpg";
            proj_4.PicInFooter = "/Content/me/img/project/mission/mission_index_54x54.png";
            proj_4.Order = 3;
            proj_4.Client = "Friendo 粉多任務";
            proj_4.ClientURL = "http://www.friendo.com.tw/About/Friendo";
            proj_4.Date = "Oct 2012 - Present";
            proj_4.LauchURL = "http://www.friendo.com.tw";
            proj_4.HtmlContent = "<p>粉多任務是整合社群、紅利回饋與購物的社交網站，用Facebook臉書登入，尋找自己有興趣的任務來執行。解完任務，馬上取得購物時可以抵扣現金使用的粉多紅利。彩妝保養美食餐券3C雜貨……粉多優惠應有盡有。</p>";
            proj_4.Tag = "Web SEO Platform";
            proj_4.isHighlight = false;
            proj_4.IsShowInPortfolio = true;

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

            #region 原味千尋 - 十六倍的堅持，只為一次的感動
            MeModels.Project proj_5 = new MeModels.Project();
            proj_5.ID = 5;
            proj_5.Name = "十六倍的堅持，只為一次的感動";
            proj_5.Description = "原味千尋與粉多任務合作的活動網站。";
            proj_5.Role = "Front-End Development";
            proj_5.Tech = "Web Development with SCSS and jQuery";
            proj_5.URL = "/Me/Project?id=5";
            proj_5.RawPic = "/Content/me/";
            proj_5.PicSmall = "/Content/me/img/project/daintiest/daintiest_index_188x73.png";
            proj_5.PicMedium = "/Content/me/img/project/daintiest/daintiest_index_300.png";
            proj_5.PicLarge = "/Content/me/img/project/daintiest/daintiest_index_940x367.png";
            proj_5.PicInFooter = "/Content/me/img/project/daintiest/daintiest_index_54x54.jpg";
            proj_5.Order = 7;
            proj_5.Client = "原味千尋";
            proj_5.ClientURL = "http://www.daintiest.net";
            proj_5.Date = "July 2014";
            proj_5.LauchURL = "http://www.friendo.com.tw/daintiest";
            proj_5.HtmlContent = "<p>原味千尋與粉多任務合作的活動網站。</p>";
            proj_5.Tag = "Web CampignSite";
            proj_5.isHighlight = false;
            proj_5.IsShowInPortfolio = true;

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

            #region 一品禪 - 御選四季食補，全素食手工水餃
            MeModels.Project proj_6 = new MeModels.Project();
            proj_6.ID = 6;
            proj_6.Name = "御選四季食補，全素食手工水餃";
            proj_6.Description = "一品禪與粉多任務合作的活動網站，特別加強SEO、品牌與相關產品關鍵字經營。";
            proj_6.Role = "Front-End Development";
            proj_6.Tech = "Web Development with SCSS and jQuery";
            proj_6.URL = "/Me/Project?id=6";
            proj_6.RawPic = "/Content/me/img/project/yipinchan/yipinchan_index_940x1130.png";
            proj_6.PicSmall = "/Content/me/img/project/yipinchan/yipinchan_index_188x73.png";
            proj_6.PicMedium = "/Content/me/img/project/yipinchan/yipinchan_index_300.png";
            proj_6.PicLarge = "/Content/me/img/project/yipinchan/yipinchan_index_940x367.png";
            proj_6.PicInFooter = "/Content/me/img/project/yipinchan/yipinchan_index_54x54.png";
            proj_6.Order = 6;
            proj_6.Client = "一品禪";
            proj_6.ClientURL = "http://www.yishentw.com";
            proj_6.Date = "April 2014";
            proj_6.LauchURL = "http://www.friendo.com.tw/yipinchan";
            proj_6.HtmlContent = "<p>一品禪與粉多任務合作的活動網站，特別加強SEO、品牌與相關產品關鍵字經營。</p>";
            proj_6.Tag = "Web CampignSite SEO";
            proj_6.isHighlight = false;
            proj_6.IsShowInPortfolio = true;

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
            proj_7.Role = "Front-End Development and C# Backend";
            proj_7.Tech = "SCSS, jQuery and C#";
            proj_7.URL = "/Me/Project?id=7";
            proj_7.RawPic = "/Content/me/img/project/aphezgo/aphezgo_index.png";
            proj_7.PicSmall = "/Content/me/img/project/aphezgo/aphezgo_index_188x73.png";
            proj_7.PicMedium = "/Content/me/img/project/aphezgo/aphezgo_index_300.png";
            proj_7.PicLarge = "/Content/me/img/project/aphezgo/aphezgo_index_940x367.jpg";
            proj_7.PicInFooter = "/Content/me/img/project/aphezgo/aphezgo_index_54x54.jpg";
            proj_7.Order = 8;
            proj_7.Client = "亞柏EZ購";
            proj_7.ClientURL = "http://www.apezgo.com";
            proj_7.Date = "July - Aug 2014";
            proj_7.LauchURL = "http://fathersday.apezgo.com";
            proj_7.HtmlContent = "<p>亞柏EZ購與粉多任務合作的活動網站，票選爸爸最想要的父親節禮物並抽獎。</p>";
            proj_7.Tag = "Web CampignSite";
            proj_7.isHighlight = false;
            proj_7.IsShowInPortfolio = true;

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

            #region 葡萄王LGG特益菌 - 黃金三兄弟賽運占卜
            MeModels.Project proj_8 = new MeModels.Project();
            proj_8.ID = 8;
            proj_8.Name = "黃金三兄弟賽運占卜";
            proj_8.Description = "葡萄王生技與粉多任務合作的活動網站。";
            proj_8.Role = "Front-End Development";
            proj_8.Tech = "Web Development with SCSS and jQuery";
            proj_8.URL = "/Me/Project?id=8";
            proj_8.RawPic = "/Content/me/img/project/grapeking/grapeking_index.png";
            proj_8.PicSmall = "/Content/me/img/project/grapeking/grapeking_index_188x73.png";
            proj_8.PicMedium = "/Content/me/img/project/grapeking/grapeking_index_300.png";
            proj_8.PicLarge = "/Content/me/img/project/grapeking/grapeking_index_940x367.png";
            proj_8.PicInFooter = "/Content/me/img/project/grapeking/grapeking_index_54x54.png";
            proj_8.Order = 9;
            proj_8.Client = "葡萄王生技";
            proj_8.ClientURL = "http://grapeking.shop.mymall.com.tw";
            proj_8.Date = "Oct 2014";
            proj_8.LauchURL = "http://www.friendo.com.tw/grapeking";
            proj_8.HtmlContent = "<p>葡萄王生技與粉多任務合作的活動網站。</p>";
            proj_8.Tag = "Web CampignSite";
            proj_8.isHighlight = false;
            proj_8.IsShowInPortfolio = true;

            List<MeModels.SnapshotInfo> SnapshotList8 = new List<MeModels.SnapshotInfo>();
            MeModels.SnapshotInfo proj_8_snap_1 = new MeModels.SnapshotInfo();
            MeModels.SnapshotInfo proj_8_snap_2 = new MeModels.SnapshotInfo();

            proj_8_snap_1.Name = "葡萄王LGG特益菌 - 黃金三兄弟賽運占卜";
            proj_8_snap_1.SnapshotURL = "/Content/me/img/project/grapeking/grapeking_index_940.png";

            proj_8_snap_2.Name = "葡萄王LGG特益菌 - 順暢小密技";
            proj_8_snap_2.SnapshotURL = "/Content/me/img/project/grapeking/grapeking_about_940.png";

            SnapshotList8.Add(proj_8_snap_1);
            SnapshotList8.Add(proj_8_snap_2);
            proj_8.Snapshot = SnapshotList8;

            projList.Add(proj_8);
            #endregion

            #region Hello Mip炫風抵台！3C控請入席
            MeModels.Project proj_9 = new MeModels.Project();
            proj_9.ID = 9;
            proj_9.Name = "Hello Mip炫風抵台！3C控請入席";
            proj_9.Description = "Hello! Mip與粉多任務合作的活動網站。";
            proj_9.Role = "Front-End Development";
            proj_9.Tech = "Web Development with SCSS and jQuery";
            proj_9.URL = "/Me/Project?id=9";
            proj_9.RawPic = "/Content/me/img/project/hellomip/hellomip_index.png";
            proj_9.PicSmall = "/Content/me/img/project/hellomip/hellomip_index_188x73.png";
            proj_9.PicMedium = "/Content/me/img/project/hellomip/hellomip_index_300.png";
            proj_9.PicLarge = "/Content/me/img/project/hellomip/hellomip_index_940x367.png";
            proj_9.PicInFooter = "/Content/me/img/project/hellomip/hellomip_index_54x54.png";
            proj_9.Order = 10;
            proj_9.Client = "";
            proj_9.ClientURL = "";
            proj_9.Date = "Oct 2014";
            proj_9.LauchURL = "http://www.friendo.com.tw/hellomip";
            proj_9.HtmlContent = "<p>Hello! Mip與粉多任務合作的活動網站。</p>";
            proj_9.Tag = "Web CampignSite";
            proj_9.isHighlight = false;
            proj_9.IsShowInPortfolio = true;

            List<MeModels.SnapshotInfo> SnapshotList9 = new List<MeModels.SnapshotInfo>();
            MeModels.SnapshotInfo proj_9_snap_1 = new MeModels.SnapshotInfo();

            proj_9_snap_1.Name = "Hello! Mip - 3C控請入席。HELLO MiP、TAKARATOMY、兩輪式行走機器人、翹孤輪機器人。";
            proj_9_snap_1.SnapshotURL = "/Content/me/img/project/hellomip/hellomip_index_940.png";

            SnapshotList9.Add(proj_9_snap_1);
            proj_9.Snapshot = SnapshotList9;

            projList.Add(proj_9);
            #endregion

            #region 全家Fami霜淇淋 小小特務送幸福
            MeModels.Project proj_10 = new MeModels.Project();
            proj_10.ID = 10;
            proj_10.Name = "全家Fami霜淇淋 小小特務送幸福";
            proj_10.Description = "只要在2014/10/7前上傳你的全家Fami霜淇淋『幸福提案』，就有機會讓小小特務親自到『幸福現場』完成你的夢想，還有機會贏得365支Fami霜淇淋，讓你天天都幸福。";
            proj_10.Role = "負責技術與後備專案支援(HTML, CSS, JS, C#, SEO, Facebook Social Plugins and Graph API)";
            proj_10.Tech = "SCSS, jQuery and C#";
            proj_10.URL = "/Me/Project?id=10";
            proj_10.RawPic = "/Content/me/img/project/eventfamily/fami_index.png";
            proj_10.PicSmall = "/Content/me/img/project/eventfamily/fami_index_188x73.png";
            proj_10.PicMedium = "/Content/me/img/project/eventfamily/fami_index_300.png";
            proj_10.PicLarge = "/Content/me/img/project/eventfamily/fami_index_940x367.jpg";
            proj_10.PicInFooter = "/Content/me/img/project/eventfamily/fami_index_54x54.png";
            proj_10.Order = 11;
            proj_10.Client = "FamilyMart 全家便利商店";
            proj_10.ClientURL = "http://www.family.com.tw/Marketing/index.aspx";
            proj_10.Date = "Sept - Oct 2014";
            proj_10.LauchURL = "http://event.family.com.tw/ice_cream/FansMission";
            proj_10.IsShowInPortfolio = true;

            var demoRUL = "/Content/me/img/project/eventfamily/eventFamily.gif";

            proj_10.HtmlContent = "<p> 只要在2014/10/7前上傳你的全家Fami霜淇淋『幸福提案』，就有機會讓小小特務親自到『幸福現場』完成你的夢想，還有機會贏得365支Fami霜淇淋，讓你天天都幸福！</p><p><img src=" + "/Content/me/img/project/eventfamily/event_family_tablet_mobile_320.png" + "></p><p>RWD(Responsive Web Design)，支援平板、手機等行動裝置瀏覽。</p><p>Demo影片如下。</p><p><a href=" + demoRUL + " target=" + "_blank" + "><img src=" + demoRUL + " width=" + 320 + "></a></p>";
            proj_10.Tag = "Web CampignSite RWD";
            proj_10.isHighlight = true;

            List<MeModels.SnapshotInfo> SnapshotList10 = new List<MeModels.SnapshotInfo>();
            MeModels.SnapshotInfo proj_10_snap_1 = new MeModels.SnapshotInfo();

            proj_10_snap_1.Name = "全家Fami霜淇淋 - 小小特務送幸福";
            proj_10_snap_1.SnapshotURL = "/Content/me/img/project/eventfamily/fami_index_940.png";

            SnapshotList10.Add(proj_10_snap_1);
            proj_10.Snapshot = SnapshotList10;

            projList.Add(proj_10);
            #endregion

            #region Self TV Prototype
            MeModels.Project proj_11 = new MeModels.Project();
            proj_11.ID = 11;
            proj_11.Name = "Self TV Prototype";
            proj_11.Description = "Self TV官網的Prototype。";
            proj_11.Role = "UI Design and Front-End Development";
            proj_11.Tech = "";
            proj_11.URL = "/Me/Project?id=11";
            proj_11.RawPic = "/Content/me/img/project/selftv/selftv_index_940x367.jpg";
            proj_11.PicSmall = "/Content/me/img/project/selftv/selftv_index_188x73.jpg";
            proj_11.PicMedium = "/Content/me/img/project/selftv/selftv_index_300.jpg";
            proj_11.PicLarge = "/Content/me/img/project/selftv/selftv_index_940x367.jpg";
            proj_11.PicInFooter = "/Content/me/img/project/selftv/selftv_index_54x54.jpg";
            proj_11.Order = 5;
            proj_11.Client = "采昌國際多媒體";
            proj_11.ClientURL = "http://www.ccii.com.tw/chweb/index.asp";
            proj_11.Date = "Jan 2013";
            //proj_11.LauchURL = "http://bit.ly/10JcEZ9";
            proj_11.LauchURL = "";
            proj_11.HtmlContent = "<p>SELF做自己頻道，是台灣第一個專門以服務同志族群的頻道品牌。隸屬於「采昌娛樂多媒體集團」。</p><p><img src=" + "/Content/me/img/project/selftv/selftv_20141102_1.png" + "></p> <br> <p><img src=" + "/Content/me/img/project/selftv/selftv_20141102_2.png" + "></p>";
            proj_11.Tag = "Web Prototype";
            proj_11.isHighlight = false;
            proj_1.IsShowInPortfolio = false;

            List<MeModels.SnapshotInfo> SnapshotList11 = new List<MeModels.SnapshotInfo>();
            MeModels.SnapshotInfo proj_11_snap_1 = new MeModels.SnapshotInfo();

            proj_11_snap_1.Name = "Self TV";
            proj_11_snap_1.SnapshotURL = "/Content/me/img/project/selftv/selftv_index_940x367.jpg";
            SnapshotList11.Add(proj_11_snap_1);

            proj_11.Snapshot = SnapshotList11;
            projList.Add(proj_11);

            #endregion

            #region 御奉小餐館 Emperorlove - 後宮爭餅傳
            MeModels.Project proj_12 = new MeModels.Project();
            proj_12.ID = 12;
            proj_12.Name = "後宮爭餅傳 - 《御奉小餐館emperorlove》心機美食，挑起姊妹間的鬥爭！";
            proj_12.Description = "御奉小餐館與粉多任務合作的活動網站。";
            proj_12.Role = "SEO規劃、Facebook Social Plugins and Graph API技術支援";
            proj_12.Tech = "Web Development with SCSS and jQuery";
            proj_12.URL = "/Me/Project?id=12";
            proj_12.RawPic = "/Content/me/img/project/emperorlove/emperorlove.png";
            proj_12.PicSmall = "/Content/me/img/project/emperorlove/emperorlove_188x73.png";
            proj_12.PicMedium = "/Content/me/img/project/emperorlove/emperorlove_300.png";
            proj_12.PicLarge = "/Content/me/img/project/emperorlove/emperorlove_940x367.jpg";
            proj_12.PicInFooter = "/Content/me/img/project/emperorlove/emperorlove_54x54.png";
            proj_12.Order = 12;
            //proj_12.Client = "御奉小餐館";
            proj_12.ClientURL = "http://www.emperorlove.com.tw";
            proj_12.Date = "Oct 2014";
            proj_12.LauchURL = "http://www.friendo.com.tw/emperorlove";
            proj_12.HtmlContent = "《御奉小餐館emperorlove》心機美食，挑起姊妹間的鬥爭！後宮甄嬛傳不夠看，「後宮爭餅傳」才精彩！到底是什麼樣的特色美食，讓平常毫無心機的姊妹淘，也開始有心機了？且來看看御奉小餐館的心機美食，如可引起姊妹間的爭食搶奪，快邀姊妹淘來一嚐究竟，一起心機過招！參加活動即有四人同行一人我請優惠喔！";
            proj_12.Tag = "Web CampignSite";
            proj_12.isHighlight = false;
            proj_12.IsShowInPortfolio = true;

            List<MeModels.SnapshotInfo> SnapshotList12 = new List<MeModels.SnapshotInfo>();
            MeModels.SnapshotInfo proj_12_snap_1 = new MeModels.SnapshotInfo();

            proj_12_snap_1.Name = "《御奉小餐館emperorlove》";
            proj_12_snap_1.SnapshotURL = "/Content/me/img/project/emperorlove/emperorlove.png";
            SnapshotList12.Add(proj_12_snap_1);

            proj_12.Snapshot = SnapshotList12;
            projList.Add(proj_12);

            #endregion

            #region 新東陽2015職場狀況劇大調查
            MeModels.Project proj_13 = new MeModels.Project();
            proj_13.ID = 13;
            proj_13.Name = "新東陽2015職場狀況劇大調查";
            proj_13.Description = "職場背黑鍋！假日老闆LINE不停！有些職場潛規則，你學會了沒？如果沒學會，快來參加新東陽2015職場狀況劇大調查，讓職場達人原味哥，蜜汁女，厚脆叔，黑椒女，五香弟，麻辣姊告訴你職場潛規則...";
            proj_13.Role = "Front-End Development and C# Backend";
            proj_13.Tech = "SCSS, jQuery and C#";
            proj_13.URL = "/Me/Project?id=13";
            proj_13.RawPic = "/Content/me/img/project/hty/hty.png";
            proj_13.PicSmall = "/Content/me/img/project/hty/hty_188x73.png";
            proj_13.PicMedium = "/Content/me/img/project/hty/hty_300.png";
            proj_13.PicLarge = "/Content/me/img/project/hty/hty_940x367.png";
            proj_13.PicInFooter = "/Content/me/img/project/hty/hty_54x54.png";
            proj_13.Order = 13;
            proj_13.Client = "HSIN TUNG YANG 新東陽";
            proj_13.ClientURL = "http://www.hty.com.tw";
            proj_13.Date = "Jan 2015";
            proj_13.LauchURL = "http://2014event.hty.com.tw";
            proj_13.IsShowInPortfolio = true;

            var demoHTYURL = "https://dl.dropboxusercontent.com/u/78267129/hty_flow.gif";
            proj_13.HtmlContent = "<p>職場背黑鍋！假日老闆LINE不停！有些職場潛規則，你學會了沒？如果沒學會，快來參加新東陽2015職場狀況劇大調查，讓職場達人原味哥，蜜汁女，厚脆叔，黑椒女，五香弟，麻辣姊告訴你職場潛規則，還有300份新東陽人氣伴手禮，蜜汁豬肉乾與原味牛肉乾大獎，等你拿！</p><p><img width=" + 320 + " src=" + demoHTYURL + "></p>";
            proj_13.Tag = "Web CampignSite";
            proj_13.isHighlight = true;//錄製_2014_12_05_22_00_48_818.mp4

            List<MeModels.SnapshotInfo> SnapshotList13 = new List<MeModels.SnapshotInfo>();
            MeModels.SnapshotInfo proj_13_snap_1 = new MeModels.SnapshotInfo();

            proj_13_snap_1.Name = "新東陽2015職場狀況劇大調查 - 參加調查新東陽豬肉、牛肉乾送給你";
            proj_13_snap_1.SnapshotURL = "/Content/me/img/project/hty/hty.png";
            SnapshotList13.Add(proj_13_snap_1);

            proj_13.Snapshot = SnapshotList13;
            projList.Add(proj_13);
            #endregion

            #region P&G 生活家 - 姊妹淘心靈悄悄話，說出你的真心話
            MeModels.Project proj_14 = new MeModels.Project();
            proj_14.ID = 14;
            proj_14.Name = "姊妹淘心靈悄悄話，說出你的真心話";
            proj_14.Description = "分析你的靈魂指數，找出契合姊妹淘，玩就送 P&G 靈魂建議試用品，包括歐蕾、潘婷、飛柔、汰漬！加碼分享私房真心話，人氣最高前 8 名，還能拿千元明星商品，快邀親朋好友幫按讚！更有機會被挑選為 P&G 明星部落客，獲得 Happy Box哦！";
            proj_14.Role = "Team Leader, Front-End Development and C# Backend";
            proj_14.Tech = "SCSS, jQuery and C#";
            proj_14.URL = "/Me/Project?id=14";
            proj_14.RawPic = "/Content/me/img/project/livingartist/livingartist.png";
            proj_14.PicSmall = "/Content/me/img/project/livingartist/livingartist_188x73.png";
            proj_14.PicMedium = "/Content/me/img/project/livingartist/livingartist_300.png";
            proj_14.PicLarge = "/Content/me/img/project/livingartist/livingartist_940x367.png";
            proj_14.PicInFooter = "/Content/me/img/project/livingartist/livingartist_54x54.png";
            proj_14.Order = 14;
            proj_14.Client = "P&G 生活家";
            proj_14.ClientURL = "http://www.livingartist.com.tw/";
            proj_14.Date = "Jan 2015";
            proj_14.LauchURL = "http://site.friendo.com.tw/livingartist";
            proj_14.HtmlContent = "<p>分析你的靈魂指數，找出契合姊妹淘，玩就送 P&G 靈魂建議試用品，包括歐蕾、潘婷、飛柔、汰漬！加碼分享私房真心話，人氣最高前 8 名，還能拿千元明星商品，快邀親朋好友幫按讚！更有機會被挑選為 P&G 明星部落客，獲得 Happy Box哦！</p>";
            proj_14.Tag = "Web CampignSite";
            proj_14.isHighlight = true;
            proj_14.IsShowInPortfolio = true;

            List<MeModels.SnapshotInfo> SnapshotList14 = new List<MeModels.SnapshotInfo>();
            MeModels.SnapshotInfo proj_14_snap_1 = new MeModels.SnapshotInfo();
            MeModels.SnapshotInfo proj_14_snap_2 = new MeModels.SnapshotInfo();
            MeModels.SnapshotInfo proj_14_snap_3 = new MeModels.SnapshotInfo();
            MeModels.SnapshotInfo proj_14_snap_4 = new MeModels.SnapshotInfo();
            MeModels.SnapshotInfo proj_14_snap_5 = new MeModels.SnapshotInfo();
            MeModels.SnapshotInfo proj_14_snap_6 = new MeModels.SnapshotInfo();
            MeModels.SnapshotInfo proj_14_snap_7 = new MeModels.SnapshotInfo();

            proj_14_snap_1.Name = "P&G 生活家 - 姊妹淘心靈悄悄話，說出你的真心話";
            proj_14_snap_1.SnapshotURL = "/Content/me/img/project/livingartist/livingartist.png";
            proj_14_snap_2.Name = "P&G 生活家 - 姊妹淘靈魂分析儀分析結果";
            proj_14_snap_2.SnapshotURL = "/Content/me/img/project/livingartist/livingartist_result_question_940x469.png";
            proj_14_snap_3.Name = "P&G 生活家 - 姊妹淘靈魂分析儀排行榜";
            proj_14_snap_3.SnapshotURL = "/Content/me/img/project/livingartist/livingartist_billboard_940x469.png";
            proj_14_snap_4.Name = "P&G 生活家 - 姊妹淘私房真心話";
            proj_14_snap_4.SnapshotURL = "/Content/me/img/project/livingartist/livingartist_activity_940x469.png";
            proj_14_snap_5.Name = "P&G 生活家 - 姊妹淘私房真心話";
            proj_14_snap_5.SnapshotURL = "/Content/me/img/project/livingartist/livingartist_post_940x469.png";
            proj_14_snap_6.Name = "P&G 生活家 - HappyBox";
            proj_14_snap_6.SnapshotURL = "/Content/me/img/project/livingartist/livingartist_happybox_940x469.png";
            proj_14_snap_7.Name = "P&G 生活家 - 活動辦法";
            proj_14_snap_7.SnapshotURL = "/Content/me/img/project/livingartist/livingartist_rule_940x469.png";
            
            SnapshotList14.Add(proj_14_snap_1);
            SnapshotList14.Add(proj_14_snap_2);
            SnapshotList14.Add(proj_14_snap_3);
            SnapshotList14.Add(proj_14_snap_4);
            SnapshotList14.Add(proj_14_snap_5);
            SnapshotList14.Add(proj_14_snap_6);
            SnapshotList14.Add(proj_14_snap_7);

            proj_14.Snapshot = SnapshotList14;
            projList.Add(proj_14);
            #endregion
            
            #region 喜年來 - 過年拷問神回覆
            MeModels.Project proj_15 = new MeModels.Project();
            proj_15.ID = 15;
            proj_15.Name = "過年拷問神回覆";
            proj_15.Description = "過年總陷入被親戚追問的窘境？快來 喜年來-過年拷問神回覆 活動網站上傳你的神回覆，就有機會獲得現金 5,000 元、威秀電影票、喜年來原味蛋捲禮盒、雙喜蛋捲禮盒、山藥蛋捲禮盒、咖啡蛋捲禮盒哦！送禮喜年來，歡喜跟著來！";
            proj_15.Role = "Front-End Development and C# Backend";
            proj_15.Tech = "SCSS, jQuery and C#";
            proj_15.URL = "/Me/Project?id=15";
            proj_15.RawPic = "/Content/me/img/project/serena/serena.png";
            proj_15.PicSmall = "/Content/me/img/project/serena/serena_188x73.png";
            proj_15.PicMedium = "/Content/me/img/project/serena/serena_300.png";
            proj_15.PicLarge = "/Content/me/img/project/serena/serena_940x367.png";
            proj_15.PicInFooter = "/Content/me/img/project/serena/serena_54x54.png";
            proj_15.Order = 15;
            proj_15.Client = "喜年來";
            proj_15.ClientURL = "http://www.serenafoods.com.tw";
            proj_15.Date = "Jan 2015";
            proj_15.LauchURL = "http://site.friendo.com.tw/serena";
            proj_15.HtmlContent = "<p>過年總陷入被親戚追問的窘境？快來 喜年來-過年拷問神回覆 活動網站上傳你的神回覆，就有機會獲得現金 5,000 元、威秀電影票、喜年來原味蛋捲禮盒、雙喜蛋捲禮盒、山藥蛋捲禮盒、咖啡蛋捲禮盒哦！送禮喜年來，歡喜跟著來！</p>";
            proj_15.Tag = "Web CampignSite";
            proj_15.isHighlight = false;
            proj_15.IsShowInPortfolio = true;

            List<MeModels.SnapshotInfo> SnapshotList15 = new List<MeModels.SnapshotInfo>();
            MeModels.SnapshotInfo proj_15_snap_1 = new MeModels.SnapshotInfo();

            proj_15_snap_1.Name = "喜年來 - 過年拷問神回覆";
            proj_15_snap_1.SnapshotURL = "/Content/me/img/project/serena/serena_940x367.png";
            SnapshotList15.Add(proj_15_snap_1);

            proj_15.Snapshot = SnapshotList15;
            projList.Add(proj_15);

            #endregion

            #region 吃什麼，どっち - 讓朋友幫你決定吃什麼
            MeModels.Project proj_16 = new MeModels.Project();
            proj_16.ID = 16;
            proj_16.Name = "吃什麼，どっち - 讓朋友幫你決定吃什麼";
            proj_16.Description = "使用者藉由輸入簡單的字詞，例如：「台北市中山區 火鍋」，按下「尋找餐廳」後就能從列表中找到符合項目的推薦餐廳，或按下「看看朋友吃什麼」，經由Facebook授權登入後，看看朋友去過哪些地方、評價。而我們也會爬回Facebook上的資訊做處理並排序，推薦適合的餐廳給使用者。";
            proj_16.Role = "Front-End Development and C# Backend";
            proj_16.Tech = "SCSS, jQuery and C#";
            proj_16.URL = "/Me/Project?id=16";
            proj_16.RawPic = "/Content/me/img/project/dotchi_food/dotchi.png";
            proj_16.PicSmall = "/Content/me/img/project/dotchi_food/dotchi_188x73.png";
            proj_16.PicMedium = "/Content/me/img/project/dotchi_food/dotchi_300.png";
            proj_16.PicLarge = "/Content/me/img/project/dotchi_food/dotchi_940x367.png";
            proj_16.PicInFooter = "/Content/me/img/project/dotchi_food/dotchi_54x54.png";
            proj_16.Order = 16;
            proj_16.Client = "";
            proj_16.ClientURL = "";
            proj_16.Date = "Feb 2015";
            proj_16.LauchURL = "http://dotchi.apphb.com";
            proj_16.HtmlContent = "<p></p><p>相關介紹請見<a href=\"http://cythilya.blogspot.tw/2015/02/dotchi.html\" target=\"_blank\">吃什麼，どっち - 讓朋友幫你決定吃什麼 (ALPHA Hackathon 2015)</a></p>";
            proj_16.Tag = "Web Hackathon";
            proj_16.isHighlight = true;
            List<int> partnerList = new List<int>(new int[] { 1, 2 });
            proj_16.Partners = partnerList;
            proj_16.IsShowInPortfolio = true;

            List<MeModels.SnapshotInfo> SnapshotList16 = new List<MeModels.SnapshotInfo>();
            MeModels.SnapshotInfo proj_16_snap_1 = new MeModels.SnapshotInfo();
            MeModels.SnapshotInfo proj_16_snap_2 = new MeModels.SnapshotInfo();
            MeModels.SnapshotInfo proj_16_snap_3 = new MeModels.SnapshotInfo();

            proj_16_snap_1.Name = "吃什麼，どっち - 讓朋友幫你決定吃什麼";
            proj_16_snap_1.SnapshotURL = "/Content/me/img/project/dotchi_food/dotchi_index_940x580.png";
            SnapshotList16.Add(proj_16_snap_1);

            proj_16_snap_2.Name = "吃什麼，どっち - 讓朋友幫你決定吃什麼";
            proj_16_snap_2.SnapshotURL = "/Content/me/img/project/dotchi_food/dotchi_page_1_940x580.png";
            SnapshotList16.Add(proj_16_snap_2);

            proj_16_snap_3.Name = "吃什麼，どっち - 讓朋友幫你決定吃什麼";
            proj_16_snap_3.SnapshotURL = "/Content/me/img/project/dotchi_food/dotchi_page_2_940x580.png";
            SnapshotList16.Add(proj_16_snap_3);

            proj_16.Snapshot = SnapshotList16;
            projList.Add(proj_16);

            #endregion

            #region 讓心年在一起 - 漢堡王心年賀卡
            MeModels.Project proj_17 = new MeModels.Project();
            proj_17.ID = 17;
            proj_17.Name = "讓心年在一起 - 漢堡王心年賀卡";
            proj_17.Description = "新年是互相祝賀的節日，除了謝謝親朋好友們過去一年的照顧，同時也希望在新年每個人都能幸福快樂。現在動手製作漢堡王心年賀卡，傳遞感謝與祝福，還有機會抽美麗華電影票、可口可樂隨身碟等多項好禮！";
            proj_17.Role = "Front-End Development and C# Backend";
            proj_17.Tech = "SCSS, jQuery and C#";
            proj_17.URL = "/Me/Project?id=17";
            proj_17.RawPic = "/Content/me/img/project/bbk_new_year/bbk_new_year.png";
            proj_17.PicSmall = "/Content/me/img/project/bbk_new_year/bbk_new_year_188x73.png";
            proj_17.PicMedium = "/Content/me/img/project/bbk_new_year/bbk_new_year_300.png";
            proj_17.PicLarge = "/Content/me/img/project/bbk_new_year/bbk_new_year_940x367.png";
            proj_17.PicInFooter = "/Content/me/img/project/bbk_new_year/bbk_new_year_54x54.png";
            proj_17.Order = 17;
            proj_17.Client = "漢堡王";
            proj_17.ClientURL = "http://www.burgerking.com.tw/index.html";
            proj_17.Date = "Feb 2015";
            proj_17.LauchURL = "http://www.friendo.com.tw/Mission/3958";
            proj_17.HtmlContent = "<p>新年是互相祝賀的節日，除了謝謝親朋好友們過去一年的照顧，同時也希望在新年每個人都能幸福快樂。現在動手製作漢堡王心年賀卡，傳遞感謝與祝福，還有機會抽美麗華電影票、可口可樂隨身碟等多項好禮！</p>";
            proj_17.Tag = "Web CampignSite";
            proj_17.isHighlight = true;
            proj_17.IsShowInPortfolio = true;

            List<MeModels.SnapshotInfo> SnapshotList17 = new List<MeModels.SnapshotInfo>();
            MeModels.SnapshotInfo proj_17_snap_1 = new MeModels.SnapshotInfo();

            proj_17_snap_1.Name = "讓心年在一起 - 漢堡王心年賀卡";
            proj_17_snap_1.SnapshotURL = "/Content/me/img/project/bbk_new_year/bbk_new_year_940x367.png";
            SnapshotList17.Add(proj_17_snap_1);

            proj_17.Snapshot = SnapshotList17;
            projList.Add(proj_17);
            #endregion

            #region 台灣高鐵 - 未上作品集
            /*
            MeModels.Project proj_18 = new MeModels.Project();
            proj_18.ID = 18;
            proj_18.Name = "台灣高鐵";
            proj_18.Description = "台灣高鐵連結台灣南北主要城市，我們不只是交通運輸業，更是推動台灣­前進的服務業；我們代表的不僅只是速度，而是速度所帶來的現代生活新態度；我們以更文明的旅行體驗，成為你實現夢想的助力，台灣高鐵，實踐台灣新生活。";
            proj_18.Role = "Front-End Development";
            proj_18.Tech = "Web Development with SCSS and jQuery";
            proj_18.URL = "/Me/Project?id=18";
            proj_18.RawPic = "/Content/me/img/project/thsr/thsr.png";
            proj_18.PicSmall = "/Content/me/img/project/thsr/thsr_188x73.png";
            proj_18.PicMedium = "/Content/me/img/project/thsr/thsr_300.png";
            proj_18.PicLarge = "/Content/me/img/project/thsr/thsr_940x367.png";
            proj_18.PicInFooter = "/Content/me/img/project/thsr/thsr_54x54.png";
            proj_18.Order = 18;
            proj_18.Client = "台灣高速鐵路股份有限公司";
            proj_18.ClientURL = "";
            proj_18.Date = "April 2015";
            proj_18.LauchURL = "http://www.thsrc.com.tw";
            proj_18.HtmlContent = "<p>台灣高鐵連結台灣南北主要城市，我們不只是交通運輸業，更是推動台灣­前進的服務業；我們代表的不僅只是速度，而是速度所帶來的現代生活新態度；我們以更文明的旅行體驗，成為你實現夢想的助力，台灣高鐵，實踐台灣新生活。</p>";
            proj_18.Tag = "Web RWD Platform";
            proj_18.isHighlight = true;
            proj_18.IsShowInPortfolio = true;

            List<MeModels.SnapshotInfo> SnapshotList18 = new List<MeModels.SnapshotInfo>();
            MeModels.SnapshotInfo proj_18_snap_1 = new MeModels.SnapshotInfo();

            proj_18_snap_1.Name = "台灣高鐵";
            proj_18_snap_1.SnapshotURL = "/Content/me/img/project/thsr/thsr_940x367.png";
            SnapshotList18.Add(proj_18_snap_1);

            proj_18.Snapshot = SnapshotList18;
            projList.Add(proj_18);
            */
            #endregion

            #region 活動咖 - 未上作品集
            /*
            MeModels.Project proj_19 = new MeModels.Project();
            proj_19.ID = 19;
            proj_19.Name = "活動咖";
            proj_19.Description = "活動咖 Eventpal - 專業賽事、活動報名與購物平台";
            proj_19.Role = "UI Design and Front-End Development";
            proj_19.Tech = "Web Development with SCSS and jQuery";
            proj_19.URL = "/Me/Project?id=19";
            proj_19.RawPic = "/Content/me/img/project/eventpal/eventpal.png";
            proj_19.PicSmall = "/Content/me/img/project/eventpal/eventpal_188x73.png";
            proj_19.PicMedium = "/Content/me/img/project/eventpal/eventpal_300.png";
            proj_19.PicLarge = "/Content/me/img/project/eventpal/eventpal_940x367.png";
            proj_19.PicInFooter = "/Content/me/img/project/eventpal/eventpal_54x54.png";
            proj_19.Order = 19;
            proj_19.Client = "Uni-Net 聯網國際";
            proj_19.ClientURL = "http://www.uni-net.com.tw";
            proj_19.Date = "April 2015";
            proj_19.LauchURL = "eventpal.com.tw";
            proj_19.HtmlContent = "<p>活動咖 Eventpal - 專業賽事、活動報名與購物平台。</p>";
            proj_19.Tag = "Web Platform";
            proj_19.isHighlight = true;
            proj_19.IsShowInPortfolio = true;

            List<MeModels.SnapshotInfo> SnapshotList19 = new List<MeModels.SnapshotInfo>();
            MeModels.SnapshotInfo proj_19_snap_1 = new MeModels.SnapshotInfo();

            proj_19_snap_1.Name = "活動咖";
            proj_19_snap_1.SnapshotURL = "/Content/me/img/project/thsr/thsr_940x367.png";
            SnapshotList19.Add(proj_19_snap_1);

            proj_19.Snapshot = SnapshotList19;
            projList.Add(proj_19);
             * */
            #endregion

            #region VOLVING沐頤健康概念館 - 未上作品集
            /*
            MeModels.Project proj_20 = new MeModels.Project();
            proj_20.ID = 20;
            proj_20.Name = "VOLVING沐頤健康概念館";
            proj_20.Description = "VOLVING沐頤健康概念館為國泰健康管理推出的品牌，擁有專業的健康照護團隊，結合健康餐廳、體適能及SPA，透過健康檢查提供飲食建議，搭配體適能教練給予運動指導，享受SPA舒緩壓力，陪伴您一起練習健康新生活。服務項目：國泰台南功能醫學診所提供健康檢測、營養師諮詢、健康餐點、健身教練指導、體適能中心、登琪爾SPA紓壓。";
            proj_20.Role = "Front-End Development";
            proj_20.Tech = "Web Development with SCSS and jQuery";
            proj_20.URL = "/Me/Project?id=" + proj_20.ID;
            proj_20.RawPic = "/Content/me/img/project/volving/volving.png";
            proj_20.PicSmall = "/Content/me/img/project/volving/volving_188x73.png";
            proj_20.PicMedium = "/Content/me/img/project/volving/volving_300.png";
            proj_20.PicLarge = "/Content/me/img/project/volving/volving_940x367.png";
            proj_20.PicInFooter = "/Content/me/img/project/volving/volving_54x54.png";
            proj_20.Order = 20;
            proj_20.Client = "國泰健康管理";
            proj_20.ClientURL = "http://www.cathay-hcm.com.tw/Health";
            proj_20.Date = "May 2015";
            proj_20.LauchURL = "http://www.volving.com.tw/index";
            proj_20.HtmlContent = "<p>VOLVING沐頤健康概念館為國泰健康管理推出的品牌，擁有專業的健康照護團隊，結合健康餐廳、體適能及SPA，透過健康檢查提供飲食建議，搭配體適能教練給予運動指導，享受SPA舒緩壓力，陪伴您一起練習健康新生活。服務項目：國泰台南功能醫學診所提供健康檢測、營養師諮詢、健康餐點、健身教練指導、體適能中心、登琪爾SPA紓壓。</p>";
            proj_20.Tag = "Web OfficialWebsite";
            proj_20.isHighlight = false;
            proj_20.IsShowInPortfolio = true;

            List<MeModels.SnapshotInfo> SnapshotList20 = new List<MeModels.SnapshotInfo>();
            MeModels.SnapshotInfo proj_20_snap_1 = new MeModels.SnapshotInfo();

            proj_20_snap_1.Name = "VOLVING沐頤健康概念館";
            proj_20_snap_1.SnapshotURL = "/Content/me/img/project/volving/volving_940x367.png";
            SnapshotList20.Add(proj_20_snap_1);

            proj_20.Snapshot = SnapshotList20;
            projList.Add(proj_20);
             * */
            #endregion

            #region 用聽的網頁‧933樂活網
            MeModels.Project proj_21 = new MeModels.Project();
            proj_21.ID = 21;
            proj_21.Name = "用聽的網頁‧933樂活網";
            proj_21.Description = "933樂活網每天24小時不打烊，期待以健康、美麗、快樂、智慧的生活訊息，以及優質輕鬆音樂，喚起聽眾朋友們愛自己、重視健康的意識，並透過各領域專業人士分享最新最實用的資訊，進而將正面的知識力傳播給大家！";
            proj_21.Role = "Front-End Development";
            proj_21.Tech = "Web Development with SCSS and jQuery";
            proj_21.URL = "/Me/Project?id=" + proj_21.ID;
            proj_21.RawPic = "/Content/me/img/project/933/933.png";
            proj_21.PicSmall = "/Content/me/img/project/933/933_188x73.png";
            proj_21.PicMedium = "/Content/me/img/project/933/933_300.png";
            proj_21.PicLarge = "/Content/me/img/project/933/933_940x367.png";
            proj_21.PicInFooter = "/Content/me/img/project/933/933_54x54.png";
            proj_21.Order = 21;
            proj_21.Client = "四神湯家族";
            proj_21.ClientURL = "https://www.facebook.com/butyhealthgo/timeline";
            proj_21.Date = "May 2015";
            proj_21.LauchURL = "http://i933.com.tw";
            string mobileSiteURL = "http://i933.com.tw/mobile";
            proj_21.HtmlContent = "<p>933樂活網每天24小時不打烊，期待以健康、美麗、快樂、智慧的生活訊息，以及優質輕鬆音樂，喚起聽眾朋友們愛自己、重視健康的意識，並透過各領域專業人士分享最新最實用的資訊，進而將正面的知識力傳播給大家！</p><p>支援平板、手機等行動裝置瀏覽。<a href=" + mobileSiteURL + ">行動裝置版網站。</a></p>";
            proj_21.Tag = "Web RWD OfficialWebsite";
            proj_21.isHighlight = false;
            proj_21.IsShowInPortfolio = true;
            List<int> partnerList21 = new List<int>(new int[] { 5 });
            proj_21.Partners = partnerList21;

            List<MeModels.SnapshotInfo> SnapshotList21 = new List<MeModels.SnapshotInfo>();
            MeModels.SnapshotInfo proj_21_snap_1 = new MeModels.SnapshotInfo();

            proj_21_snap_1.Name = "用聽的網頁‧933樂活網";
            proj_21_snap_1.SnapshotURL = "/Content/me/img/project/933/933_940x367.png";
            SnapshotList21.Add(proj_21_snap_1);

            proj_21.Snapshot = SnapshotList21;
            projList.Add(proj_21);
            #endregion

            #endregion

            projList = projList.OrderBy(x => x.Order).Reverse().ToList();
            ViewBag.ProjList = projList;
            return projList;
        }

        //Get Recent Post
        public void getRecentPostList(int number = 4) 
        {
            List<MeModels.Article> articleList = new List<MeModels.Article>();
            List<MeModels.Article> recentArticleList = new List<MeModels.Article>();

            articleList = GetArticleList();

            foreach(var item in articleList)
            {
                recentArticleList.Add(item);
            };

            recentArticleList.Reverse();
            recentArticleList = Enumerable.Reverse(recentArticleList).Take(number).ToList();
            ViewBag.RecentPostList = recentArticleList;
        }

        //Get Featured Post
        public void getFeaturedPostList(int number = 4)
        {
            List<MeModels.Article> articleList = new List<MeModels.Article>();
            List<MeModels.Article> featuredArticleList = new List<MeModels.Article>();

            articleList = GetArticleList();

            foreach (var item in articleList)
            {
                if (item.isHighlight)
                { 
                    featuredArticleList.Add(item);
                }
            }
            ViewBag.FeaturedPostList = featuredArticleList;
        }

        //Get Related Projects
        public void getRelatedProject(int id = 1, int count = 4)
        {
            //tag list
            List<string> TagList = new List<string>();
            TagList.Add("Web");
            TagList.Add("Prototype");
            TagList.Add("Hackathon");
            TagList.Add("CampignSite");
            TagList.Add("OfficialWebsite");
            TagList.Add("Platform");
            TagList.Add("SEO");
            TagList.Add("RWD");
            TagList.Add("SPWA");
            TagList.Add("App");

            //get project list
            List<MeModels.Project> projList = new List<MeModels.Project>();
            projList = getProjectList();

            MeModels.Project proj = projList.Find(item => item.ID == id);

            //new list to calculate
            List<MeModels.RelatedProject> relatedProjectList = new List<MeModels.RelatedProject>();

            foreach (var item in projList)
            {
                int score = 1;
                int total = 0;
                MeModels.RelatedProject projectItem = new MeModels.RelatedProject();
                string[] parts = item.Tag.Split(' ');

                for(int i = 0; i < TagList.Count ; i++)
                {
                    var result = Array.FindAll(parts, s => s.Equals(TagList[i]));
                    if (result.Length != 0) 
                    {
                        total = total + score;
                    }
                    score = score * 2;

                };

                projectItem.ID = item.ID;
                projectItem.Name = item.Name;
                projectItem.URL = item.URL;
                projectItem.PicLarge = item.PicLarge;
                projectItem.TagScore = total;
                relatedProjectList.Add(projectItem);
            }


            //get target project
            MeModels.RelatedProject targetProj = relatedProjectList.Find(item => item.ID == id);

            //remove target project from related project list
            var itemToRemove = relatedProjectList.Single(r => r.ID == id);
            bool flag = relatedProjectList.Remove(itemToRemove);

            //calculate determinant
            foreach(var item in relatedProjectList)
            {
                var resultScore = targetProj.TagScore & item.TagScore;
                item.TagScore = resultScore;
            };

            //re-order related projects by determinant
            relatedProjectList = relatedProjectList.OrderByDescending(x => x.TagScore).ToList();

            //get first four items in related project list
            List<MeModels.RelatedProject> reulstRelatedProjectList = new List<MeModels.RelatedProject>();
            int c = 0;
            int max = 4;

            foreach (var r in relatedProjectList)
            {
                if (c < max)
                {
                    reulstRelatedProjectList.Add(r);
                    c++;
                }
            }

            ViewBag.RelatedProjects = reulstRelatedProjectList;
        }

        //Get Recent Projects
        public void getRecentProject(int number = 4)
        {
            //get project list
            List<MeModels.Project> projList = new List<MeModels.Project>();
            projList = getProjectList();

            //new list to calculate
            List<MeModels.RecentProject> recentProjects = new List<MeModels.RecentProject>();

            foreach (var item in projList)
            {
                MeModels.RecentProject projectItem = new MeModels.RecentProject();
                projectItem.ID = item.ID;
                projectItem.Name = item.Name;
                projectItem.Description = item.Description;
                projectItem.Tag = item.Tag;
                projectItem.URL = item.URL;
                projectItem.Date = item.Date;
                projectItem.PicLarge = item.PicLarge;
                projectItem.PicInFooter = item.PicInFooter;
                projectItem.Order = item.Order;
                recentProjects.Add(projectItem);
            }

            //get last four items in related project list
            List<MeModels.RecentProject> recentProjectList = new List<MeModels.RecentProject>();
            int c = 0;
            int max = number;

            ViewBag.RecentAllProjects = recentProjects;

            foreach (var r in recentProjects)
            {
                if (c < max)
                {
                    recentProjectList.Add(r);
                    c++;
                }
            }
            ViewBag.RecentProjectList = recentProjectList;
        }

        //Send Mail to Me
        public ActionResult ContactMe(MeModels.Visitor visitor)
        {
            string mailBody = System.IO.File.ReadAllText(Server.MapPath("/App_Data/VisitorEmailTemplate.html"));


            mailBody = mailBody.Replace("{{Visitor_Name}}", visitor.Name);
            mailBody = mailBody.Replace("{{Visitor_Email}}", visitor.Email);
            mailBody = mailBody.Replace("{{Visitor_Messages}}", visitor.Message);
            mailBody = mailBody.Replace("{{Visitor_Time}}", DateTime.UtcNow.ToString());
            
            try
            {
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("eshoppertw@gmail.com", "liardice.,1024");
                SmtpServer.EnableSsl = true;

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("eshoppertw@gmail.com");
                mail.To.Add("cythilya@gmail.com");
                mail.Subject = "Hello ~ Email from " + visitor.Name + " at " + DateTime.UtcNow.ToString();
                mail.Body = mailBody;
                mail.IsBodyHtml = true;

                SmtpServer.Send(mail);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        //Get Partners
        public void GetPartnerList(List<int> parters)
        {
            #region Mock
            List<MeModels.Partner> partnerList = new List<MeModels.Partner>();

            MeModels.Partner partner1 = new MeModels.Partner();
            partner1.ID = 1;
            partner1.Name = "小奎";
            partner1.Website = "https://www.facebook.com/profile.php?id=100000189857091&fref=ts";
            partnerList.Add(partner1);

            MeModels.Partner partner2 = new MeModels.Partner();
            partner2.ID = 2;
            partner2.Name = "吳采洪";
            partner2.Website = "https://www.facebook.com/profile.php?id=100000133231966&fref=ts";
            partnerList.Add(partner2);

            MeModels.Partner partner3 = new MeModels.Partner();
            partner3.ID = 3;
            partner3.Name = "Jim Lin";
            partner3.Website = "http://jimlindesign.com";
            partnerList.Add(partner3);

            MeModels.Partner partner4 = new MeModels.Partner();
            partner4.ID = 4;
            partner4.Name = "Leah Yeh";
            partner4.Website = "https://www.facebook.com/leahyeh?fref=ts";
            partnerList.Add(partner4);

            MeModels.Partner partner5 = new MeModels.Partner();
            partner5.ID = 5;
            partner5.Name = "I-Six Liu";
            partner5.Website = "https://www.facebook.com/isix.liu";
            partnerList.Add(partner5);
            #endregion

            List<MeModels.Partner> projectPartnerList = new List<MeModels.Partner>();

            foreach (var num in parters) 
            {
                MeModels.Partner partnerItem = partnerList.Find(item => item.ID == num);
                projectPartnerList.Add(partnerItem);
            }

            ViewBag.PartnerList = projectPartnerList;
        }
        #endregion
    }
}
