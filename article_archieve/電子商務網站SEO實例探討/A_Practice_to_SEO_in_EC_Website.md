#電子商務網站SEO實例探討

![電子商務網站SEO實例探討](https://lh5.googleusercontent.com/-zYbfPgDR-LY/VMMzY2wmOeI/AAAAAAAAFSk/N4tZsDgRbcc/w800-h494-no/a_practice_to_seo_in_ec_website_800.jpg)

大部份會做SEO的網站不外乎是電子商務、活動網站、內容/服務平台(例如：新聞、旅遊)。而極端如Campaign Site這樣類型的網站由於存活時間短，便不需要做SEO，只要放置簡單的Meta Tag或Social Meta Tag即可(供SERPs顯示標題和描述、社群平台分享時帶出適當的文字與圖片，快速產出網站以搭配行銷活動與流程能順暢操作才是重點)。以下我們會先就電子商務的狀況作探討。

##台灣電子商務網站的現況？遇到什麼問題？
###台灣電子商務網站的現況
用一個簡單的例子來說明 - 搜尋「膳魔師」後，出現在搜尋結果列表第一頁的網站(頁)如下圖所示：

![膳魔師 SERPs](http://goo.gl/VJngc7)

第一名當然是膳魔師官方網站，知名品牌的關鍵字原則上是不去搶第一名的(不需要也沒必要花資源)，接下來便是各大購物網站 - PChome購物中心、momo購物網、Yahoo!奇摩購物中心、udn買東西、7net、森森購物網、ETMall東森購物網、博客來。台灣的網站很少很少在做[Rich Snippet](http://goo.gl/qur2dH)且部份Ranking Factor牽涉到與外部社群平台網站的互動、搜尋結果頁的點擊率或其他User Signal，所以我們只要比較基本的項目就好：

- 關鍵字的選擇與佈置(含Relevant Terms、Meta Tag或Social Meta Tag的撰寫)
- 網站規模(將牽涉到點擊率、觸及TA的數量，甚至未來會關係到與社群的互動，但這幾個網站都是大的)
- 內部連結數(是否能讓搜尋引擎好爬，也包含檢視是否有標籤集合頁，集眾人之力以小搏大，還有推薦系統)
- Backlink數(PR沒那麼重要了，但關係到Referral的建置帶來多少流量和TA)
- G+ (為了在SERPs上顯示更豐富的資訊)

####[PChome購物中心的膳魔師](http://mall.pchome.com.tw/store/QBAH0Z)
[PChome購物中心的膳魔師](http://mall.pchome.com.tw/store/QBAH0Z)是一個集合頁，雖然不是標籤頁而是品牌頁，但功能上是類似的(會被更新而加入新血、有多個頁面連結至此頁，只差沒有保留舊項目和Archive)。沒有善用H2等標籤(Semantic HTML)放置重點關鍵字是可惜的，但卻用了放置[Rich Snippet](http://goo.gl/msmEHq)(只)來標記Breadcrumb。在使用Rich Snippet這一塊，在我心目中除了我們公司的產品[Friendo 粉多任務](http://www.friendo.com.tw)、[一品禪](www.friendo.com.tw/yipinchan/product)是模範生之外，[EZPrice](http://ezprice.com.tw)也是我很喜歡的網站。沒有G+是很可惜的(就算有也要有人用心經營)，有G+的話就有機會可以在SERPs顯示更豐富的資訊。下圖以搜尋「粉多」為例，右側就由搜尋引擎幫我們帶出更多內容。

site:pchome.com.tw 2900000

![Friendo 粉多任務](http://goo.gl/OVMruj)
 
####[momo購物網的膳魔師](http://goo.gl/ZDs5NN)
[momo購物網的膳魔師](http://goo.gl/ZDs5NN)是一個品牌集合頁，關鍵字的佈置是相對較用心的，不管是數量還是廠牌中英文名稱，但同樣也沒有善用Semantic HTML。

site:momoshop.com.tw 5130000

####[Yahoo!奇摩購物中心的膳魔師](http://goo.gl/qvnCeJ)
分享大圖這件事情不是必要但很吸引人，而它把Banner大圖放在HTML文件前面，就算沒有設定og:image都會被Facebook抓到而分享，這應該是一個不正確但剛好解決問題的方法。

順道一提，Yahoo!的頁面在我的學習成長歷程中有很大的幫助，它讓我學習到版面和關鍵字的配置、IA架構，有很多功能看起來不起眼其實是有很深奧的學問的。

site:tw.buy.yahoo.com  659000

####[udn買東西的膳魔師](http://goo.gl/2wu809)
雖然[udn買東西的膳魔師](http://goo.gl/2wu809)也是用Rich Snippet(只)來標記Breadcrumb，但卻完整而非部份的標記，這可以當成標記重點關鍵字，也是一種經營方式。

site:shopping.udn.com 502000

####[7net的膳魔師](http://www.7net.com.tw/7net/rui004.faces?catid=18319)
我們常會遇到一種狀況，就是圖片外面會包一層連結，讓使用者點圖片的時候，帶到該商品的詳細資訊頁。但這樣`<a>...</a>` tag就很難在塞文字(anchor text)，或包一層span再塞關鍵字，然後用CSS隱藏起來。這對SEO來說是不好的，因為搜尋引擎會忽略被隱藏的內容(因為它們要杜絕刻意給搜尋引擎的重點，或隱藏起來也可能不是重要資訊)。所以這樣的標記方式是聰明的，在`<a>...</a>` tag上加上title屬性，放上我們想要佈置的關鍵字「【THERMOS膳魔師】不鏽鋼真空保溫瓶0.35L(JMY-351KT-VAN)」。

	<a href="http://www.7net.com.tw/7net/rui005.faces?ID=141000230898&catid=18319" title="【THERMOS膳魔師】不鏽鋼真空保溫瓶0.35L(JMY-351KT-VAN)">
		<img src="/mdz_file/item/09/08/06/1410/14100023089G_view2_141021185643.jpg" alt="【THERMOS膳魔師】不鏽鋼真空保溫瓶0.35L(JMY-351KT-VAN)" width="152" height="152"/>
	</a>

site:7net.com.tw 736000

####[森森購物網的膳魔師](http://goo.gl/iUJK1f)
對搜尋引擎來說，放置HTML上愈前面的東西愈是重要，所以前面最好不要放太多的JavaScript Snippet，或是在HTML Tag中放置太多屬性，例如data-xxxx。當然，Google聲明它們搜尋引擎可閱讀JavaScript，但根據實驗，它們是可以讀懂沒錯，但能不能被index又是一回事，可參考[Ember.js & SEO - 測試搜尋引擎對JavaScript的剖析能力](http://cythilya.blogspot.tw/2014/09/emberjs-seo-javascript.html)。

site:u-mall.com.tw 1710000

###總結我們遇到的狀況與前進方向
看完以上台灣各大電子商務網站的狀況，是不是覺得SEO有很大的改善空間？因此，Off-Site SEO要靠外力協助較難控制，我們可盡力改善On-site SEO - 從基本的Semantic HTML、關鍵字的選取與佈置、RSS即時通知搜尋引擎來爬網站最新/更新的內容、標籤系統/推薦系統(記得要分對頻道)開始著手，漸進式改善網站體質，再進一步使用工具長期觀察各頻道的流量和各功能所帶來的貢獻。大約經過半年的調整，就會看到Organic顯著的成效，而若能跨部門合作，則不管是Direct、Referral、Social，也都能相益得彰。

另外，也要注意 **主打重點** 這件事情，但這是題外話，因為牽涉到UX / UI的部份。而台灣的電子商務網站較重視特效，類似Gallery，而非重內容的呈現。這是因為為了呈現重點商品，除了在頁面上所佔的版面較大外，特效是常用手法之一。但基本上一個頁面有太多會動的東西，是很容易分散使用者的注意力的，所以 **主打重點** 這件事情非常重要。

###優良SEO網站推薦 - TechCrunch、EZPrice、雄獅旅遊網
除了Yahoo!外，我也很喜歡觀察[TechCrunch](http://techcrunch.com)、[EZPrice](http://ezprice.com.tw)。

####[TechCrunch](http://techcrunch.com)
[TechCrunch](http://techcrunch.com)的把標籤放在左上最顯眼的地方，加強了聚焦、對使用者的閱讀導引，加強搜尋與分類。為此，前輩食夢黑貘還為了TechCrunch的標籤寫了一篇文章 [從令人震驚的 Techcrunch 的改版來看 Tag 在 SEO 價值](http://gene.speaking.tw/2014/11/techcrunch-tag-seo.html)。

####[EZprice 比價網](http://ezprice.com.tw)
[EZprice 比價網](http://ezprice.com.tw)是一個能讓消費者輕鬆比較商品在各購物網站的價格和現狀的平台。它們有做Rich Snippet這些基本功，但最讓我喜歡的是它們的標籤系統，有推薦(聚焦)功能，如下圖。

![EZprice 比價網](https://lh4.googleusercontent.com/-5T_FpfTWYNU/VMMdZKwwG9I/AAAAAAAAFSE/SvVfiSFHB5s/w1249-h746-no/ezprice_tag.png)

它們把所有使用者查詢或點擊的關鍵字都記錄下來，放在這裡 [Ezprice比價網價格比價熱門商品關鍵字列表](http://ezprice.com.tw/hotkw.php)。這對後續觀察和推薦使用者(or TA)相關商品，即製作推建系統有很大的助益。畢竟這些資料才是真實使用者正在使用的，而非經由工具觀察、旁敲側擊猜出來的。

####[雄獅旅遊網](http://www.liontravel.com)
[雄獅旅遊網](http://www.liontravel.com) 對於SEO處理是細膩的，例如Meta Description這種扣分的東西也是整個拿掉、Rich Snippet這些基本功最得非常完整。

---
####[friday購物](http://shopping.friday.tw)
會注意到[friday購物](http://shopping.friday.tw)是因為和朋友團購聖誕禮物(如果世界上有好的禮物推薦系統請告訴我XD)。它們的專題文章漸進引導我們一步步按下購買button，可參考 [12星座壁咚特輯](http://shopping.friday.tw/activity/index/?no=PP15010007_bidon)，成功解決我們不知道要買什麼的困擾，超有梗！

比較吃虧的地方是以下部份：

**1. 網站規模不夠大**，site:friday.tw -> 257000
和前面提到的各大購物網站比較，網站規模是小的。
site:pchome.com.tw           2900000
site:momoshop.com.tw      5130000
site:tw.buy.yahoo.com         659000
site:shopping.udn.com        502000
site:7net.com.tw                  736000
site:u-mall.com.tw             1710000
site:friday.tw                        257000

這可以經由定期產出頁面來解決，例如Archive頁、標籤tem

**2. Semantic HTML + [Rich Snippet](http://cythilya.blogspot.tw/2014/02/search-and-social.html)**。
讓搜尋引擎快速且清楚了解重點所在。畢竟行銷是搶重點搶時效的。

**3. Yahoo! / Bing的追蹤**。
網站一般都會觀察主要三大網站的狀況，即Google、[Yahoo! & Bing](http://www.bing.com/toolbox/webmaster)。Google、Yahoo! & Bing的使用比例應該是2:1，因此觀察Yahoo! / Bing的狀況是必要的。

**4. [RSS](http://cythilya.blogspot.tw/2014/03/rss.html)的建置。**
每當網站產出新的頁面時，立刻告知搜尋引擎來做Index，這樣就能快速出現在SERPs上，也能趕快爭取CTR，藉由CTR和累積頁面年齡將SERPs的排名往上提高

**5. 增加與社群平台的互動和優化**。
例如：增加G+的plugin、G+的經營、Facebook分享大圖的優化。目前Social Signal是重點Factor，爭取使用者的按讚、+1、分享對排名有幫助，也是藉由另外更大的社群平台達到更廣的資訊傳播。某個層面來說這也是另類的Referral。

**6. 圖片蒐尋的優化**。
圖片蒐尋也會帶來流量，因此不要浪費網站上的任何一張有價值的商品圖，img tag要加上title和alt。

另外，還有內部連結的優化、Web與App的導流、後續經營、觀察與檢測等。

---
分享自己的觀察心得，也歡迎討論，如果有任何錯誤的地方也請指正，謝謝。

---
###推薦閱讀
- [About rich snippets and structured data](https://support.google.com/webmasters/answer/99170?hl=en) 
- [從搜尋到社群 - Semantics、Rich Snippets、Social Meta Tags](http://cythilya.blogspot.tw/2014/02/search-and-social.html)
- [2014 SEO Ranking Factors - 點閱率CTR成為最重要的因子、利用標籤競爭SERPs排名](http://cythilya.blogspot.tw/2014/10/2014-seo-ranking-factors-ctr.html)
- [談如何利用標籤(Tag)加強網站的近似辭彙(Relevant Terms)](http://cythilya.blogspot.tw/2014/11/tag-relevant-terms.html)
- [Ember.js & SEO - 測試搜尋引擎對JavaScript的剖析能力](http://cythilya.blogspot.tw/2014/09/emberjs-seo-javascript.html)
- [從令人震驚的 Techcrunch 的改版來看 Tag 在 SEO 價值](http://gene.speaking.tw/2014/11/techcrunch-tag-seo.html)





