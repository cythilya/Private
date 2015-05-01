#Ember.js & SEO - 測試搜尋引擎對JavaScript的剖析能力

![Ember.js & SEO](https://lh6.googleusercontent.com/-pBYR5ny-j04/VBGyhD93RRI/AAAAAAAACpQ/3jUuwPMTeQ4/w960-h540-no/JavaScript_SEO.jpg)  

Google Webmaster Central Blog在今年五月宣布 ，Google 搜尋能夠執行網頁上的 Javascript (見[Understanding web pages better](http://googlewebmastercentral.blogspot.com.es/2014/05/understanding-web-pages-better.html))﻿。而過去已知Crawler只會剖析網頁上的HTML Code，而不會(或少量)執行JavaScript。。又由於開發品質與速度的要求，使得Single Page Application (SPA) frameworks盛行(例如：Angular.js、Ember.js等)，於是了解搜尋引擎是否能夠執行並解讀JavaScript與解讀的程度便成為網站開發的其中一項需求。  

##利用Ember.js製作測試案例
- 編號1頁面：[畫面載入時，利用JavaScript render 列表資訊](http://cythilya.apphb.com/SEOLab/SEOLab/EmberJSSEO?id=1)
- 編號2頁面：[對照組，資料直接放在HTML上](http://cythilya.apphb.com/SEOLab/SEOLab/EmberJSSEO?id=2)

如果編號1頁面可被剖析，我們還有後續的劇本可以持續測試...

資料來源：[Friendo 粉多任務](http://www.friendo.com.tw)

##探討方向
主要實驗對象是Goole搜尋，附帶Facebook。

- Indexing  
	- Google Search
		- 搜尋[編號1頁面](http://cythilya.apphb.com/SEOLab/SEOLab/EmberJSSEO?id=1)的關鍵字 "Ember.js & SEO 九品芝麻官大會考" 
			- 提交後無法馬上經由搜尋特定關鍵字搜尋到[編號1頁面]
			- 約一週後可經由搜尋特定關鍵字找到該頁面，如下圖。  

			  ![](https://lh4.googleusercontent.com/-uVA1qZyC9bM/VBekMMMp9xI/AAAAAAAACrc/HlC00CM6ZUc/w796-h239-no/ember_render_content.png)

		- 搜尋編號2頁面的關鍵字 "Ember.js & SEO 玉泉水果酒 - 愛呆丸快樂產生器！" 可在提交後馬上經由搜尋特定關鍵字找到[編號2頁面](http://cythilya.apphb.com/SEOLab/SEOLab/EmberJSSEO?id=2)。
		- 由以上兩點可知，推測會執行[這段JavaScript Code](http://cythilya.apphb.com/Content/seo_lab/js/script.js)，因此但無法馬上Indexing經由執行JavaScript Code所帶入的資料，而必須過一段時間。
		- [看Crawler得到的結果 (資料來源：Google模擬器，擷取並轉譯，如下圖)](https://dl.dropboxusercontent.com/u/78267129/SEO_Lab/result/google_fetch_ember_1/google_fetch.txt)  

		![Google模擬器，擷取並轉譯](https://lh6.googleusercontent.com/-qJ5USHwHXSs/VBbxwBxHpUI/AAAAAAAACq8/nvrPmrglgRQ/w538-h494-no/google_exe.png)  
	- Facebook Share
		- 由Facebook所提供的工具可知，無法執行這段JavaScript Code和Indexing經由執行JavaScript Code所帶入的資料。
		- [看Crawler得到的結果](https://dl.dropboxusercontent.com/u/78267129/SEO_Lab/result/fb_fetch_emberjs_1/fb_fetch.htm) or [Original Result From Facebook](https://developers.facebook.com/tools/debug/og/echo?q=http%3A%2F%2Fcythilya.apphb.com%2FSEOLab%2FSEOLab%2FEmberJSSEO%3Fid%3D1)
- Linkability：由於無法Indexing，因此推測無Linkability(外部連結、Link Juice相關)。

##結論
目前Google Search可剖析經由SPA帶入到頁面的資料但不即時，因此若想利用SPA來開發前台，必須思考網站是否有SEO的需求。若有，頁面重要資訊還是必須放在HTML上，或利用其他的解法(為Crawler另外提供一個頁面、[Server Pre-rendering](https://prerender.io)、[PhantomJS](http://phantomjs.org/) 等)。  

相關實驗可見 [SEO Strategies for JavaScript-Heavy Single Page Applications or AJAX Sites](http://cythilya.apphb.com/SEOLab/SEOLab) 

###就算使用SPA建構網站，還是可以在SERPs得到高的排名？
就排名來說，由於搜尋引擎的排名是由眾多因素集合起來的，因此若其他地方做得很好，也是可以有很好的搜尋排名。例如高品質的Inbound Links、網站效能佳、速度快、社群平台熱烈討論、On-Page SEO等。

---
###參考資料
- [Understanding web pages better](http://googlewebmastercentral.blogspot.com.es/2014/05/understanding-web-pages-better.html)
- [Google’s Crawler Now Understands JavaScript: What Does This Mean For You?](http://www.business2community.com/seo/googles-crawler-now-understands-javascript-mean-0898263)
- [SEO Strategies for JavaScript-Heavy Single Page Applications or AJAX Sites](http://searchenginewatch.com/article/2358775/SEO-Strategies-for-JavaScript-Heavy-Single-Page-Applications-or-AJAX-Sites)
- [SEO Google crawl to execute your site JavaScript](http://ng-learn.org/2014/05/SEO-Google-crawl-JavaScript)
- [Full Specification - Webmasters — Google Developers](https://developers.google.com/webmasters/ajax-crawling/docs/specification)
- [JAVASCRIPT SEO](http://jeffwhelpley.com/javascript-seo)
- [Google Can Now Execute AJAX & JavaScript For Indexing](http://searchengineland.com/google-can-now-execute-ajax-javascript-for-indexing-99518)
- [Can Google Really Access Content in JavaScript? Really?](http://moz.com/ugc/can-google-really-access-content-in-javascript-really)


