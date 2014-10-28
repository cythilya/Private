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

        //Project
        public ActionResult Project(int id = 0) 
        {
            List<MeModels.Project> projList = new List<MeModels.Project>();
            projList = getProjectList();
            MeModels.Project proj = projList.Find(item => item.ID == id);

            if (proj == null) {
                return View("Portfolio");
            }

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

        #endregion

        #region Function
        
        //Get Article List
        public List<MeModels.Article> GetArticleList()
        {
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
            article_1.PicInFooter = "/Content/me/img/blog/247479_5433_54x54.jpg";
            article_1.Tag = "SEO";
            article_1.isHighlight = false;
            article_1.Time = "Jan 1, 2014";//2014/01/04
            article_1.isBanner = false;
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
            article_2.PicInFooter = "/Content/me/img/blog/250528_3929_54x54.jpg";
            article_2.Tag = "SEO";
            article_2.isHighlight = false;
            article_2.Time = "Jan 22, 2014";
            article_2.isBanner = false;
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
            article_3.PicInFooter = "/Content/me/img/blog/search_and_social_54x54.jpg";
            article_3.Tag = "SEO";
            article_3.isHighlight = true;
            article_3.Time = "Feb 1, 2014";
            article_3.isBanner = false;
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
            article_4.PicInFooter = "/Content/me/img/blog/rss_54x54.jpg";
            article_4.Tag = "SEO";
            article_4.isHighlight = false;
            article_4.Time = "March 9, 2014";
            article_4.isBanner = false;
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
            article_5.PicInFooter = "/Content/me/img/blog/author_rank_54x54.jpg";
            article_5.Tag = "SEO";
            article_5.isHighlight = false;
            article_5.Time = "March 22, 2014";
            article_5.isBanner = false;
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
            article_6.PicInFooter = "/Content/me/img/blog/microdata_54x54.jpg";
            article_6.Tag = "SEO";
            article_6.isHighlight = false;
            article_6.Time = "April 21, 2014";
            article_6.isBanner = false;
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
            article_7.PicInFooter = "/Content/me/img/blog/seo_guideline_54x54.jpg";
            article_7.Tag = "SEO";
            article_7.isHighlight = true;
            article_7.Time = "May 17, 2014";
            article_7.isBanner = false;
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
            article_8.PicInFooter = "/Content/me/img/blog/facebook_social_demo_54x54.jpg";
            article_8.Tag = "SEO";
            article_8.isHighlight = false;
            article_8.Time = "June 7, 2014";
            article_8.isBanner = false;
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
            article_9.PicInFooter = "/Content/me/img/blog/keyword_tag_54x54.jpg";
            article_9.Tag = "SEO";
            article_9.isHighlight = true;
            article_9.Time = "Aug 16, 2014";
            article_9.isBanner = false;
            articleList.Add(article_9);

            //Ember.js & SEO - 測試搜尋引擎對JavaScript的剖析能力
            MeModels.Article article_10 = new MeModels.Article();
            article_10.Name = "Ember.js & SEO - 測試搜尋引擎對JavaScript的剖析能力";
            article_10.Description = "Google Webmaster Central Blog在今年五月宣布 ，Google 搜尋能夠執行網頁上的 Javascript (見Understanding web pages better)﻿。而過去已知Crawler只會剖析網頁上的HTML Code，而不會(或少量)執行JavaScript。。又由於開發品質與速度的要求，使得Single Page Application (SPA) frameworks盛行(例如：Angular.js、Ember.js等)，於是了解搜尋引擎是否能夠執行並解讀JavaScript與解讀的程度便成為網站開發的其中一項需求。";
            article_10.URL = "http://bit.ly/1unwm55";
            article_10.RawPic = "/Content/me/img/blog/JavaScript_SEO.jpg";
            article_10.PicSmall = "/Content/me/img/blog/JavaScript_SEO_188x73.jpg";
            article_10.PicMedium = "/Content/me/img/blog/JavaScript_SEO_300.jpg";
            article_10.PicLarge = "/Content/me/img/blog/JavaScript_SEO_940x367.jpg";
            article_10.PicInFooter = "/Content/me/img/blog/JavaScript_SEO_54x54.jpg";
            article_10.Tag = "SEO";
            article_10.isHighlight = false;
            article_10.Time = "Sep 11, 2014";
            article_10.isBanner = false;
            articleList.Add(article_10);

            //Facebook Graph API - Taggable Friends
            MeModels.Article article_11 = new MeModels.Article();
            article_11.Name = "Facebook Graph API - Taggable Friends";
            article_11.Description = "有鑑於IKEA做了一個好玩的活動網站來IKEA睡一晚，其中含有邀請朋友並標記、分享到Facebook上，因此也做了一個範例來玩玩。";
            article_11.URL = "http://bit.ly/1xptGc3";
            article_11.RawPic = "/Content/me/img/blog/Facebook_Graph_API_Taggable_Friends_940x367.jpg";
            article_11.PicSmall = "/Content/me/img/blog/Facebook_Graph_API_Taggable_Friends_188x73.jpg";
            article_11.PicMedium = "/Content/me/img/blog/Facebook_Graph_API_Taggable_Friends_300.jpg";
            article_11.PicLarge = "/Content/me/img/blog/Facebook_Graph_API_Taggable_Friends_940x367.jpg";
            article_11.PicInFooter = "/Content/me/img/blog/Facebook_Graph_API_Taggable_Friends_54x54.jpg";
            article_11.Tag = "SEO";
            article_11.isHighlight = true;
            article_11.Time = "Sep 24, 2014";
            article_11.isBanner = true;
            articleList.Add(article_11);

            //Facebook Product Introduction
            MeModels.Article article_12 = new MeModels.Article();
            article_12.Name = "Facebook Product Introduction";
            article_12.Description = "Facebook產品總整理與功能說明(Social Plugins、Sharing、其他UI功能應用、Graph API功能應用、og相關、權限相關、成效衡量)。";
            article_12.URL = "http://bit.ly/ZyYSYx";
            article_12.RawPic = "/Content/me/img/blog/facebook_product_introduction_940x367.jpg";
            article_12.PicSmall = "/Content/me/img/blog/facebook_product_introduction_188x73.jpg";
            article_12.PicMedium = "/Content/me/img/blog/facebook_product_introduction_300.jpg";
            article_12.PicLarge = "/Content/me/img/blog/facebook_product_introduction_940x367.jpg";
            article_12.PicInFooter = "/Content/me/img/blog/";
            article_12.Tag = "SEO";
            article_12.isHighlight = false;
            article_12.Time = "Oct 3, 2014";
            article_12.isBanner = false;
            articleList.Add(article_12);

            //2014 SEO Ranking Factors - 點閱率CTR成為最重要的因子、利用標籤競爭SERPs排名
            MeModels.Article article_13 = new MeModels.Article();
            article_13.Name = "2014 SEO Ranking Factors - 點閱率CTR成為最重要的因子、利用標籤競爭SERPs排名";
            article_13.Description = "2013年的SEO Rankgin Factors著重於頁面優化、如何呈現好的內容與社群平台的散播。與2013相較，2014年最大的不同在於CTR變成SERPs排行中最重要的因子，並強調了使用者的動向(User Signals)，除了CTR還有使用者停留時間(Time on Site)、跳出率(Bounse Rate)、更全面性的評估，例如相關詞彙(Relevant Terms)、網站速度(Site Speed)。";
            article_13.URL = "http://bit.ly/1vP70Pz";
            article_13.RawPic = "/Content/me/img/blog/seo-ranking-factors-2014.png";
            article_13.PicSmall = "/Content/me/img/blog/seo-ranking-factors-2014_188x73.png";
            article_13.PicMedium = "/Content/me/img/blog/seo-ranking-factors-2014_300.png";
            article_13.PicLarge = "/Content/me/img/blog/seo-ranking-factors-2014_940x367.png";
            article_13.PicInFooter = "/Content/me/img/blog/seo-ranking-factors-2014_54x54.jpg";
            article_13.Tag = "SEO";
            article_13.isHighlight = false;
            article_13.Time = "Oct 9, 2014";
            article_13.isBanner = false;
            articleList.Add(article_13);

            //CKEditor Addons - 簡易上傳圖片、檔案(SimpleUploads)、Youtube影片搜尋(CKEditor Youtube + search feature)
            MeModels.Article article_14 = new MeModels.Article();
            article_14.Name = "CKEditor Addons - 簡易上傳圖片、檔案(SimpleUploads)、Youtube影片搜尋(CKEditor Youtube + search feature)";
            article_14.Description = "CKEditor是一款「所見即所得」(WYSIWYG) 的 HTML網頁編輯器，免費、功能強大、周邊資源多。下載後經過簡單安裝便能作為前台或後台編輯工具。";
            article_14.URL = "http://bit.ly/1vgZMVi";
            article_14.RawPic = "/Content/me/img/blog/ckeditor_addons_simpleuploads_youtube_search_feature/sckeditor_addons_simpleuploads_youtube_search_feature.jpg";
            article_14.PicSmall = "/Content/me/img/blog/ckeditor_addons_simpleuploads_youtube_search_feature/ckeditor_addons_simpleuploads_youtube_search_feature_188x73.jpg";
            article_14.PicMedium = "/Content/me/img/blog/ckeditor_addons_simpleuploads_youtube_search_feature/ckeditor_addons_simpleuploads_youtube_search_feature_300.jpg";
            article_14.PicLarge = "/Content/me/img/blog/ckeditor_addons_simpleuploads_youtube_search_feature/ckeditor_addons_simpleuploads_youtube_search_feature_940x367.jpg";
            article_14.PicInFooter = "/Content/me/img/blog/ckeditor_addons_simpleuploads_youtube_search_feature/ckeditor_addons_simpleuploads_youtube_search_feature_54x54.jpg";
            article_14.Tag = "";
            article_14.isHighlight = false;
            article_14.Time = "Oct 16, 2014";
            article_14.isBanner = false;
            articleList.Add(article_14);

            //RWD(Responsive Web Design) 實作筆記
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

            //使用Graph API上傳圖片到Facebook相簿、並設定為使用者大頭照
            MeModels.Article article_16 = new MeModels.Article();
            article_16.Name = "使用Graph API上傳圖片到Facebook相簿、並設定為使用者大頭照";
            article_16.Description = "有不少活動都會引導使用者上傳圖片並設定為封面或是檔案頭像，例如 遮打革命 Umbrella Revolution - Support Campaign | Twibbon。";
            article_16.URL = "http://bit.ly/1yRtaV8";
            article_16.RawPic = "/Content/me/img/blog/upload_photos_to_users_profile_via_graph_api_and_change_profile_picture/upload_photos_to_users_profile_via_graph_api_and_change_profile_picture.jpg";
            article_16.PicSmall = "/Content/me/img/blog/upload_photos_to_users_profile_via_graph_api_and_change_profile_picture/upload_photos_to_users_profile_via_graph_api_and_change_profile_picture_188x73.jpg";
            article_16.PicMedium = "/Content/me/img/blog/upload_photos_to_users_profile_via_graph_api_and_change_profile_picture/upload_photos_to_users_profile_via_graph_api_and_change_profile_picture_300.jpg";
            article_16.PicLarge = "/Content/me/img/blog/upload_photos_to_users_profile_via_graph_api_and_change_profile_picture/upload_photos_to_users_profile_via_graph_api_and_change_profile_picture_940x367.jpg";
            article_16.PicInFooter = "/Content/me/img/blog/upload_photos_to_users_profile_via_graph_api_and_change_profile_picture/upload_photos_to_users_profile_via_graph_api_and_change_profile_picture_54x54.jpg";
            article_16.Tag = "SEO";
            article_16.isHighlight = false;
            article_16.Time = "Oct 20, 2014";
            article_16.isBanner = false;
            articleList.Add(article_16);

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
            proj_1.URL = "/Me/Project?id=1";
            proj_1.RawPic = "/Content/me/img/project/one_piece_z/one_piece_z_index.png";
            proj_1.PicSmall = "/Content/me/img/project/one_piece_z/one_piece_z_index_188x73.png";
            proj_1.PicMedium = "/Content/me/img/project/one_piece_z/one_piece_z_index_300.png";
            proj_1.PicLarge = "/Content/me/img/project/one_piece_z/one_piece_z_index_940x367.jpg";
            proj_1.PicInFooter = "/Content/me/img/project/one_piece_z/one_piece_z_index_54x54.png";
            proj_1.Order = 1;
            proj_1.Client = "采昌國際多媒體";
            proj_1.ClientURL = "http://www.ccii.com.tw/chweb/index.asp";
            proj_1.Date = "Jan 2013";
            proj_1.LauchURL = "http://www.ccii.com.tw/OPZ";
            proj_1.HtmlContent = "<p>ONE PIECE FILM Z【航海王電影:Z】官方網站1月25日決戰新世界。負責Front-End Development。</p>";
            proj_1.Tag = "Web";
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
            proj_2.PicLarge = "/Content/me/img/project/party/party_index_940x367.jpg";
            proj_2.PicInFooter = "/Content/me/img/project/party/party_index_54x54.png";
            proj_2.Order = 2;
            proj_2.Client = "";
            proj_2.ClientURL = "";
            proj_2.Date = "July 2012 - Aug 2014";
            proj_2.LauchURL = "";
            proj_2.HtmlContent = "<p>粉多網路辦桌大請客，粉多為了慶祝台灣第一個雲端社群網站開站，舉辦網路辦桌活動。在活動時間內，使用Facebook登入並成為粉多會員後點選「免費請我」即可參加抽獎。</p><p>每天都有不同商品，每天能抽當天的商品。當天邀請Facebook朋友參加，此帳號當日得獎機率提升為2倍。<br>負責Front-End Development、C# backend。</p>";
            proj_2.Tag = "Web";
            proj_2.isHighlight = true;

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
            proj_3.PicInFooter = "/Content/me/img/project/party_hlh/party_index_hlh_54x54.png";
            proj_3.Order = 3;
            proj_3.Client = "恆隆行";
            proj_3.ClientURL = "http://www.hlh.com.tw";
            proj_3.Date = "Aug 2012";
            proj_3.LauchURL = "";
            proj_3.HtmlContent = "<p>粉多辦桌和恆隆行合作所特別製作的首頁與活動盛況頁面。<br>負責Front-End Development。</p>";
            proj_3.Tag = "Web";
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
            proj_4.PicLarge = "/Content/me/img/project/mission/mission_index_940x367.jpg";
            proj_4.PicInFooter = "/Content/me/img/project/mission/mission_index_54x54.png";
            proj_4.Order = 4;
            proj_4.Client = "";
            proj_4.ClientURL = "";
            proj_4.Date = "Oct 2012";
            proj_4.LauchURL = "http://www.friendo.com.tw";
            proj_4.HtmlContent = "<p>粉多任務是整合社群、紅利回饋與購物的社交網站，用Facebook臉書登入，尋找自己有興趣的任務來執行。解完任務，馬上取得購物時可以抵扣現金使用的粉多紅利。彩妝保養美食餐券3C雜貨……粉多優惠應有盡有。負責Front-End Development、C# backend。</p>";
            proj_4.Tag = "Web";
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
            proj_5.PicInFooter = "/Content/me/img/project/daintiest/daintiest_index_54x54.jpg";
            proj_5.Order = 5;
            proj_5.Client = "原味千尋";
            proj_5.ClientURL = "http://www.daintiest.net";
            proj_5.Date = "July 2014";
            proj_5.LauchURL = "http://www.friendo.com.tw/daintiest";
            proj_5.HtmlContent = "<p>原味千尋與粉多任務合作的活動網站。負責Front-End Development。</p>";
            proj_5.Tag = "Web Brand";
            proj_5.isHighlight = false;

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
            proj_6.Description = "一品禪與粉多任務合作的活動網站，特別加強SEO、品牌與相關產品關鍵字經營。";
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
            proj_6.HtmlContent = "<p>一品禪與粉多任務合作的活動網站，特別加強SEO、品牌與相關產品關鍵字經營。負責Front-End Development。</p>";
            proj_6.Tag = "Web Brand SEO";
            proj_6.isHighlight = false;

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
            proj_7.PicLarge = "/Content/me/img/project/aphezgo/aphezgo_index_940x367.jpg";
            proj_7.PicInFooter = "/Content/me/img/project/aphezgo/aphezgo_index_54x54.jpg";
            proj_7.Order = 7;
            proj_7.Client = "亞柏EZ購";
            proj_7.ClientURL = "http://www.apezgo.com";
            proj_7.Date = "July 2014 - Aug 2014";
            proj_7.LauchURL = "http://fathersday.apezgo.com";
            proj_7.HtmlContent = "<p>亞柏EZ購與粉多任務合作的活動網站，票選爸爸最想要的父親節禮物並抽獎。負責Front-End Development、C# backend。</p>";
            proj_7.Tag = "Web";
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

            #region 葡萄王LGG特益菌 x Friendo 粉多任務
            MeModels.Project proj_8 = new MeModels.Project();
            proj_8.ID = 8;
            proj_8.Name = "葡萄王LGG特益菌 x Friendo 粉多任務";
            proj_8.Description = "葡萄王生技與粉多任務合作的活動網站。";
            proj_8.URL = "/Me/Project?id=8";
            proj_8.RawPic = "/Content/me/img/project/grapeking/grapeking_index.png";
            proj_8.PicSmall = "/Content/me/img/project/grapeking/grapeking_index_188x73.png";
            proj_8.PicMedium = "/Content/me/img/project/grapeking/grapeking_index_300.png";
            proj_8.PicLarge = "/Content/me/img/project/grapeking/grapeking_index_940x367.png";
            proj_8.PicInFooter = "/Content/me/img/project/grapeking/grapeking_index_54x54.png";
            proj_8.Order = 8;
            proj_8.Client = "葡萄王生技";
            proj_8.ClientURL = "http://grapeking.shop.mymall.com.tw";
            proj_8.Date = "Oct. 2014";
            proj_8.LauchURL = "http://www.friendo.com.tw/grapeking";
            proj_8.HtmlContent = "<p>葡萄王生技與粉多任務合作的活動網站。負責Front-End Development。</p>";
            proj_8.Tag = "Web Brand";
            proj_8.isHighlight = false;

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

            #region Hello! Mip
            MeModels.Project proj_9 = new MeModels.Project();
            proj_9.ID = 9;
            proj_9.Name = "Hello! Mip x Friendo 粉多任務";
            proj_9.Description = "Hello! Mip與粉多任務合作的活動網站。";
            proj_9.URL = "/Me/Project?id=9";
            proj_9.RawPic = "/Content/me/img/project/hellomip/hellomip_index.png";
            proj_9.PicSmall = "/Content/me/img/project/hellomip/hellomip_index_188x73.png";
            proj_9.PicMedium = "/Content/me/img/project/hellomip/hellomip_index_300.png";
            proj_9.PicLarge = "/Content/me/img/project/hellomip/hellomip_index_940x367.png";
            proj_9.PicInFooter = "/Content/me/img/project/hellomip/hellomip_index_54x54.png";
            proj_9.Order = 9;
            proj_9.Client = "";
            proj_9.ClientURL = "";
            proj_9.Date = "Oct. 2014";
            proj_9.LauchURL = "http://www.friendo.com.tw/hellomip";
            proj_9.HtmlContent = "<p>Hello! Mip與粉多任務合作的活動網站。負責Front-End Development。</p>";
            proj_9.Tag = "Web Brand";
            proj_9.isHighlight = false;

            List<MeModels.SnapshotInfo> SnapshotList9 = new List<MeModels.SnapshotInfo>();
            MeModels.SnapshotInfo proj_9_snap_1 = new MeModels.SnapshotInfo();

            proj_9_snap_1.Name = "Hello! Mip - 3C控請入席。HELLO MiP、TAKARATOMY、兩輪式行走機器人、翹孤輪機器人。";
            proj_9_snap_1.SnapshotURL = "/Content/me/img/project/hellomip/hellomip_index_940.png";

            SnapshotList9.Add(proj_9_snap_1);
            proj_9.Snapshot = SnapshotList9;

            projList.Add(proj_9);
            #endregion
            
            #region 全家Fami霜淇淋 - 小小特務送幸福
            MeModels.Project proj_10 = new MeModels.Project();
            proj_10.ID = 10;
            proj_10.Name = "全家Fami霜淇淋 - 小小特務送幸福";
            proj_10.Description = "只要在2014/10/7前上傳你的全家Fami霜淇淋『幸福提案』，就有機會讓小小特務親自到『幸福現場』完成你的夢想，還有機會贏得365支Fami霜淇淋，讓你天天都幸福。";
            proj_10.URL = "/Me/Project?id=10";
            proj_10.RawPic = "/Content/me/img/project/eventfamily/fami_index.png";
            proj_10.PicSmall = "/Content/me/img/project/eventfamily/fami_index_188x73.png";
            proj_10.PicMedium = "/Content/me/img/project/eventfamily/fami_index_300.png";
            proj_10.PicLarge = "/Content/me/img/project/eventfamily/fami_index_940x367.jpg";
            proj_10.PicInFooter = "/Content/me/img/project/eventfamily/fami_index_54x54.png";
            proj_10.Order = 10;
            proj_10.Client = "";
            proj_10.ClientURL = "";
            proj_10.Date = "Sept 2014";
            proj_10.LauchURL = "";
            proj_10.HtmlContent = "<p>全家Fami霜淇淋 - 小小特務送幸福。主要負責技術與後備專案支援(HTML, CSS, JS, C#, SEO, Facebook Social Plugins and Graph API)。</p>";
            proj_10.Tag = "Web SEO RWD";
            proj_10.isHighlight = true;

            List<MeModels.SnapshotInfo> SnapshotList10 = new List<MeModels.SnapshotInfo>();
            MeModels.SnapshotInfo proj_10_snap_1 = new MeModels.SnapshotInfo();

            proj_10_snap_1.Name = "全家Fami霜淇淋 - 小小特務送幸福";
            proj_10_snap_1.SnapshotURL = "/Content/me/img/project/eventfamily/fami_index_940.png";

            SnapshotList10.Add(proj_10_snap_1);
            proj_10.Snapshot = SnapshotList10;

            projList.Add(proj_10);
            #endregion

            #endregion

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
            TagList.Add("Brand");
            TagList.Add("SEO");
            TagList.Add("RWD");
            TagList.Add("SPWA");

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
                projectItem.URL = item.URL;
                projectItem.Date = item.Date;
                projectItem.PicInFooter = item.PicInFooter;
                recentProjects.Add(projectItem);
            }

            //get last four items in related project list
            List<MeModels.RecentProject> recentProjectList = new List<MeModels.RecentProject>();
            int c = 0;
            int max = 4;

            //re-order
            recentProjects.Reverse();

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

        #endregion
    }
}
