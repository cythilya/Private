#RWD(Responsive Web Design) 實作筆記

![RWD(Responsive Web Design) 實作筆記](https://lh4.googleusercontent.com/AumhW1hD0nxyB06L60rRZ3QU6FLl8TBRTVaj7K6ZxHU=w800-h374-no)

RWD(Responsive Web Design)是一種設計概念，希望能讓網頁適用在不同的平台上。  而距離上一次專做RWD大約是一年前，公司最近想對產品大改版，於是又來練練RWD搂！

##設計與實作
###第一步：設計三個版面架構
我大多會做三個版面(<480、480~768、768~1024+)，由於流程與便於閱讀的優點，大致上會規劃成這個樣子...
![](http://webpiremarketing.com.au/wp-content/uploads/2013/10/responsivedesign.png)

###第二步：使用Media Query撰寫CSS
這次並不會使用Grid System，而是單純使用CSS的Media Query。而在撰寫CSS的部份，如果是共通、可以共用的，我會放在Common的區塊，而其他針對特定尺寸的指令，便分別放在單獨的區塊裡，例如：

		/*超過768px*/
		@media screen and (min-width: 768px) {
			...
		}
	
	    /*介於480px與767px之間*/
		@media screen and (min-width: 480px) and (max-width: 767px) {
		...
		}
	
	    /*未滿480px，即479px以下*/
		@media screen and (max-width: 479px) {
		...
	}


##Demo
前天剛好跟一位在做餐飲的朋友吃飯，就用"食物"來當成這次實作網站的主題吧！
Demo網站 [Food Sense](http://cythilya.ihost.tw/rwd/rwd_foodsense)

###PC
![](https://lh6.googleusercontent.com/-xFgdVw820o8/VEKhfVrMCAI/AAAAAAAADSQ/9UXsMFMeHBs/w642-h553-no/rwd_foodsense_960.png)

###Tablet
![](https://lh5.googleusercontent.com/-DhE9u0w_lpE/VEKhe_HdnLI/AAAAAAAADSM/GtvTUODbKQo/w488-h553-no/tablet.png)

###Mobile
![](https://lh5.googleusercontent.com/-1vo8LJvALBA/VEKhehEc3RI/AAAAAAAADSI/KM3QV7H0SYI/w659-h553-no/mobile.png)

##附註
之前常有人提到，RWD是有助於SEO的，可參考 [4 SEO Benefits of Responsive Web Design](http://www.searchenginejournal.com/4-seo-benefits-responsive-web-design/92807)。一來是網址統一，不浪費Link Juice，另一方面是因為提高可閱讀性而降低網站的跳出率。但對於擁有複雜流程的網站而言，希望用一個版本的HTML再搭配不同的CSS，而能適應PC、平板、手機是困難的，因為流程與功能複雜，勢必會有流程變動或功能增減，所以可能的解法就是判斷平台或解析度，然後轉跳到不同的頁面。因此就演變成作兩個版本的HTML - PC + 行動裝置(平板與手機)。但若決定做一個以上的版本的頁面，就需要考慮維護成本了~

---
###推薦閱讀：隔壁同事已消化並整理、分享的文件...
- [手機版網站 - 概論整理](http://blog.friendo.com.tw/posts/236801-mobile-phone-website-brief)
- [手機網頁技術介紹](http://blog.friendo.com.tw/posts/236810-mobile-web-basic-knowledge)
- [Responsive Web Design - 概論整理重點](http://blog.friendo.com.tw/posts/238205-responsive-web-design)

###好用的測試網站
- [Mobile Responsive Design Testing](http://www.studiopress.com/responsive)：可將所有狀況一次展開
- [Do You Use Responsive Web Design | Responsive Design Checker](http://responsivedesignchecker.com/)：一次一種狀況
- [Responsinator](https://www.responsinator.com)：可將所有狀況一次展開，以Apple產品為主，更為擬真
- [Responsive Design Testing across Mobile and Desktop Browsers - iOS, Android, OS X, Windows](http://www.browserstack.com/responsive)

###其他參考資料
-  [4 SEO Benefits of Responsive Web Design](http://www.searchenginejournal.com/4-seo-benefits-responsive-web-design/92807)
- [Food Sense - A unique resource for thoughtful, food-loving eaters and home cooks who have a palate for plant-based eating - for themselves or their loved ones; three days a week, or every day of the year.](http://foodsense.is) 真正的Food Sense網站，這次練習主要參考的範例~
