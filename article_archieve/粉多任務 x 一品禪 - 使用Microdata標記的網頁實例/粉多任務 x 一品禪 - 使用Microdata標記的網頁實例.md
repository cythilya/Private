#粉多任務 x 一品禪 - 使用Microdata標記的網頁實例

![粉多任務 x 一品禪 - 使用Microdata標記的網頁實例](https://dl.dropboxusercontent.com/u/78267129/img/yipinchan_website.png)

什麼是MicroData？  
有興趣的可以參考[從搜尋到社群 - Semantics、Rich Snippets、Social Meta Tags](http://cythilya.blogspot.tw/2014/02/search-and-social.html)，這些標記符號的用途在於讓搜尋引擎有效讀懂網頁的內容，進而達到搜尋時呈現我們所提供的資料的方法。
畢竟直接告訴搜尋引擎重點在哪裡－－告訴它這是一篇文章的標題、內文、圖片和圖片說明，或告訴它這是商品區塊、這些文字是商品名稱或廠商名稱、告訴它這些數字是價錢(而非無意義的數字)，是比較有效率和精準的。而文中也說明標記如何使用和測試。

##範例
**粉多任務的產品對於SEO是重視的**，因此自家產品都會對SEO做加強，除了熟知的**Ranking Factor**(Ref：[SEO Ranking Factors – Rank Correlation 2013 for Google US](http://www.searchmetrics.com/en/knowledge-base/ranking-factors-us-2013))外，這次在一品禪頁面上標註Microdata也花了不小的工。  

###粉多任務 x 一品禪
- [一品禪 - 首頁](http://www.friendo.com.tw/yipinchan)
- [一品禪 - 關於一品禪](http://www.friendo.com.tw/yipinchan/about)
- [一品禪 - 餃色介紹](http://www.friendo.com.tw/yipinchan/dumpling)
- [一品禪 - 御選四季食補選購專區Online Shop](http://www.friendo.com.tw/yipinchan/product)

####對於文章的每一個段落都標註此段落的標題、內文、圖片

	<div class="article" itemscope="" itemtype="http://schema.org/article">
		<h2 itemprop="name">一品禪 素顏手工水餃，讓你吃得好也吃得巧。</h2>
		<div class="content">
			<div class="thumbnail">
				<img src="../images/thumbnail_1.png" title="一品禪 素顏手工水餃，讓你吃得好也吃得巧。" alt="一品禪 素顏手工水餃，讓你吃得好也吃得巧。" itemprop="image">
			</div>
			<div class="descriptin" itemprop="description">
				《一品禪》傳承中國傳統四季食補的禪學，結合手作工序和當令蔬菜，捏出一顆顆兼具美味及養生的全素食手工水餃。拒絕摻入化學物危害消費者健康、堅持不添加人工素料矇騙消費者味蕾，期待透過每一雙手的溫度，傳達「吃得好也要吃得巧，把健康食物變美味」的理念，讓消費者在繁忙的生活中，也能吃到快速又養生的好料理。
			</div>
		</div>
	</div>

####商品區塊：指名此區塊是單一商品，且告知商品名稱、廠商名稱、圖片、價格
	<div class="item" itemscope="" itemtype="http://data-vocabulary.org/Product">
		<div class="content">
			<div class="brand" itemprop="brand">一品禪</div>
			<div class="thumbnail">
				<a href="#" title="高麗菜純手工水餃(螺旋藻皮)" target="_blank">
					<img itemprop="image" src="../images/product_1.jpg" title="高麗菜純手工水餃(螺旋藻皮)" alt="一品禪 高麗菜純手工水餃(螺旋藻皮)">
				</a>
			</div>
			<h2 itemprop="name">高麗菜純手工水餃(螺旋藻皮)</h2>
			<div class="price">特價＄
				<span class="number" itemprop="price">155</span>
			</div>
		</div>
	</div>

####當然也有標明此頁面的Navigation和Footer，因為這裡放了我們的重要連結與Anchor Text。

##檢測工具
HTML撰寫完畢一定要做測試：[Google Structured Data Testing Tool](http://www.google.com/webmasters/tools/richsnippets)

##成效
4/18下午一上線，搜尋關鍵字**一品禪**，[餃色介紹](http://www.friendo.com.tw/yipinchan/dumpling)、[關於一品禪](http://www.friendo.com.tw/yipinchan/about)就分別出現在SERPs第一頁的第7筆、第8筆。另外搜尋關鍵字**手工水餃 螺旋藻**，[餃色介紹](http://www.friendo.com.tw/yipinchan/dumpling)出現在SERPs第一頁的第3筆。由於這次做了Microdata的標記處理，讓搜尋引擎有效讀懂，而且將每個頁面都打在SERPs上，不管是時效和準確度都大大提升。  

當然有很多地方是不足或不夠好的，大家也都可以指證或討論噢~

##附註
我們的設計和企劃真的太厲害啦！有沒有覺得網站好美，文案也好美？

---
####推薦閱讀
- [SEO Ranking Factors – Rank Correlation 2013 for Google US](http://www.searchmetrics.com/en/knowledge-base/ranking-factors-us-2013)  
- [從搜尋到社群 - Semantics、Rich Snippets、Social Meta Tags](http://cythilya.blogspot.tw/2014/02/search-and-social.html)


