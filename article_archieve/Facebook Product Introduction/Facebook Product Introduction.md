#Facebook Product Introduction 產品總整理與功能說明
Facebook產品總整理與功能說明(Social Plugins、Sharing、其他UI功能應用、Graph API功能應用、og相關、權限相關、成效衡量)，部份範例以粉多網站為例。

註：[Facebook Product Introduction](http://blog.friendo.com.tw/posts/234544-facebook-product-introduction) - 這篇文章的孿生兄弟，也是我寫的，因當時有分享需求而略做調整，是比較完整的版本，可以參考一下。  

##Social Plugins
###[Like Button](https://developers.facebook.com/docs/plugins/like-button)
-  目的：對特定網址或粉絲團按讚。
	- 對粉絲團按讚，增加看到此粉絲頁的使用者數量，導流或宣傳用，以期能經由定期與不定期的PO文導入流量到網站。
	- 對網頁按讚，希望能在使用者的動態牆上出現該頁面摘要，以提高活動散播度/社群影響力而導入流量到該網站，與提高搜尋引擎排名。
-  參數設定：Layout、Action Type、Show Friends' Faces、Include Share Button
	- Layout：UI呈現共分四種 `standard、box_count、button_count、button`
		- standard  
			![facebook like button - standard](http://goo.gl/FxRZl6)
		- box_count	  
			![facebook like button - box_count](http://goo.gl/9YsGtk)
		- button_count  
			![facebook like button - button_count](http://goo.gl/TFGyhP)
		- button   
			![facebook like button - button](http://goo.gl/HGWN0u) 
	- Action Type：like和recommend。這兩個動作是相同的，差別只在於button文字適用於不同類別的網站。大部份的網站是使用like，而新聞類別的網站傾向使用recommend，因為使用者會傾向使用recommend而非like來散佈壞消息。 可參考 [Distinctions Between Facebook 'Like,' 'Share' and 'Recommend'](http://goo.gl/Ezohun)。  
	- Show Friends' Faces：layout選擇standard，可再選擇是否要顯示好友頭像。
	- Include Share Button，加上分享的按鈕。  
	  ![](https://lh4.googleusercontent.com/HO2nke0KZ5sjgyg1uTPHmlBGdzsNNxqNCo8WntPisMA=w573-h258-no) 
- 備註：在這裡的數字並非真實按讚數，而是包含like、share、comment。  
	  ![Like Button, 內頁對此任務網址按讚](https://lh3.googleusercontent.com/-G2pPwqSHF-U/VQaliFIfMvI/AAAAAAAAF0s/B4uum2wazN8/w800-h244-no/like_number.png)  
	精確查詢需使用FQL或工具[Facebook Share Counter](http://goo.gl/VYCvs6)。例如：任務[【一品禪-御選四季食補】春補護肝，養生素食大調查！](http://www.friendo.com.tw/Mission/3195)，此網址的like數顯示為3700，但其實Share:1597 + Like:2070 + Comments:33 = 3700(如上圖紅框處)。  

---
###[Share Button](https://developers.facebook.com/docs/plugins/share-button)
對特定粉絲團分享，按下分享後，跳出popup供使用者填寫分享內容，可設定分享群組。  

![](https://lh5.googleusercontent.com/-tpWOQjKVK7c/VBe3m9exFMI/AAAAAAAACsg/xhP85EfebJQ/w110-h42-no/share_button.png)  

填寫內容與設定分享群組的popup。  

![](https://lh5.googleusercontent.com/-CeynVdKrO2c/VQam7oIb1aI/AAAAAAAAF08/DyZEmH6kf-A/w800-h369-no/share_button.png)

分享在使用者的timeline上，使用者可設定是否要接收通知、加到興趣清單、取消like。    

![](https://lh6.googleusercontent.com/-2DEuBQgBAbQ/VBe1_XElY9I/AAAAAAAACr0/7DSvu_5cI8A/w594-h386-no/share_button_timeline.png)

其中，興趣清單(interest list)可放在使用者動態牆的左側書籤上，針對關注的粉絲團專頁做整理。

![](https://lh6.googleusercontent.com/-KK1D9HtYf6Q/VBe1_Y4_riI/AAAAAAAACr4/xstH6YfCucQ/w685-h664-no/interest_list.png)

---
###[Like Box](https://developers.facebook.com/docs/plugins/like-box-for-pages)
- 目的：對特定粉絲團專頁按讚，以提高按讚量，增加看到此粉絲頁的使用者數量，以期能經由定期與不定期的PO文導入流量到網站。
- 粉多網站應用
	- 品牌基地
	  ![](http://s26.postimg.org/4dusu34fb/like_box.png)  
	- 對特定粉絲團按讚 (會檢查使用者是否按過讚，沒有按過讚才會出現Popup)
	  ![facebook fan page](http://s26.postimg.org/6wghurq5j/Like_Button_Check_3.png)  
      - 由於Facebook禁止第三方網站或平台獎勵使用者按讚加入粉絲團或點擊進入社群附屬軟體，防止洗讚(但我們可在Facebook站內對粉絲頁按讚)。另外也是希望經營者修正經營策略，經由正當方式得到真正的粉絲，而非使用利誘強迫的方式增加粉絲數，得到曝光在動態牆上的機會。給網站或平台的緩衝修改時間至2014/11/05。參考 [Facebook updates app settings page to give you more control](http://goo.gl/hrkuSg)。
- 限制：對特定粉絲團按讚的功能，若該粉絲團曾經非正當途徑取得讚，Facebook會限制專頁透過外部連結按讚，而只能在Facebook網站內取得讚。若該粉絲團專頁被限制，會在按讚後出現 "專頁的讚功能限制: 你想要按讚的粉絲專頁目前暫時被禁止接收新的「讚」" 的訊息。 如下圖紅框處。  
	![果蕊 粉絲團 按讚](https://lh5.googleusercontent.com/-PgpFIo4vpXo/VQanZvmKI8I/AAAAAAAAF1I/lfg-eOpQzqs/w800-h429-no/fan_page_like.png) 

---
###[Comments](https://developers.facebook.com/docs/plugins/comments)
留言，可勾選是否要在Facebook上發表。  

- 目的：對特定網址評論，可選擇發佈在Facebook上，以提高任務散播度/社群影響力而導入流量到粉多任務網站、搜尋引擎排名。
- 參數設定
	- data-numposts：預設展開5則留言
	- data-colorscheme：主題顏色，可選"light" or "dark"
- 粉多網站應用：任務內頁的留言  
	![Social Plugins - Comments](https://lh5.googleusercontent.com/--uxeebj3S1M/VQans90HxBI/AAAAAAAAF1U/NqAuBKi_XsA/w800-h236-no/Comment.png)

---
###[Facepile](https://developers.facebook.com/docs/plugins/facepile)
- 目的：列出使用此APP或粉絲專頁的使用者頭像
- 粉多網站應用：任務內頁Footer的Facepipe  

	![facebook facepipe](https://lh4.googleusercontent.com/-ylhfCeKGChs/VQaoMoXshlI/AAAAAAAAF1k/78Hpisv4B48/w800-h88-no/Facepipe.png)
	
---
###[Follow Button](https://developers.facebook.com/docs/plugins/follow-button)
![Follow Button](https://lh5.googleusercontent.com/BphOlmNT1QcmoHFdW1UFHF5fXq_Hgl41jk5UBO1Y4iI=w343-h51-no)

- 目的：讓使用者訂閱特定使用者、粉絲頁。

---
###[Send Button](https://developers.facebook.com/docs/plugins/send-button)
傳送訊息。  
![Send Button](https://lh6.googleusercontent.com/tcvl1y4AKo0-AkL09bUOojQyzqji316KKRife34pocg=w783-h557-no)

在Mailbox收到訊息。  
![Send Button](https://lh4.googleusercontent.com/QSBg0CjJ9nseGnWqbxy9Bcsgm2T9BfckXvcZ-J6LG0I=w304-h345-no)

- 目的：傳送訊息，傳送成功後，接受者可在Mailbox收到訊息。
- 功能類似 [Send Dialog](https://developers.facebook.com/docs/sharing/reference/send-dialog)。

---
###[Embedded Posts](https://developers.facebook.com/docs/plugins/embedded-posts)  

![Embedded Posts](http://goo.gl/5ytebI)

- 目的：將在Facebook公開發表的文章內嵌在網站中，可對此Facebook Page按讚。

---
###[Activity Feed](https://developers.facebook.com/docs/plugins/activity) 最新動態

![Activity Feed](http://goo.gl/e1LX5u) 

- 目的：從網站取得時間內使用者對此網站讚或推薦的內容，類似動態牆/排行榜功能，目的是**推薦朋友按讚或評論的內容**。使用者對於排行榜類型的東西會有群聚效應。

--- 
###[Recommendations Feed](https://developers.facebook.com/docs/plugins/recommendations) 人氣動態

![Recommendations Feed](http://goo.gl/nKTBXq)

- 目的：從網站取得時間內使用者對此網站熱門推薦的內容，不限是否為自己好友，類似動態牆/排行榜功能，目的是推薦有趣、即時的內容給使用者。使用者對於排行榜類型的東西會有群聚效應。

---
##Sharing 分享
- Using Social Plugins：Like Button、Share Button
- Using Share Dialog：Feed Dialog，可參考 [POST UI](http://coenraets.org/sociogram/#postui)
	- 任務內頁的 "分享任務"   
      ![任務內頁的 "分享任務" (Feed Dialog)](https://lh6.googleusercontent.com/-dK-wMCbe0AE/VQaomBdRVCI/AAAAAAAAF1w/rGVLBhY36JI/w800-h140-no/Share_1.png)  
	- 積分任務，任務完成後的 "分享結果"  
      ![積分任務，任務完成後的 "分享結果" (Feed Dialog)](https://lh4.googleusercontent.com/-fmzHaYT8nlw/VQaom8K7opI/AAAAAAAAF18/7OEcN-2ZRtk/w800-h572-no/Share_Result.png)
- Using the Graph API
	- 可參考 [POST](http://coenraets.org/sociogram/#post)
	- 所有任務類型的**我同意審核完成後分享訊息到我的動態牆**  
      ![所有任務類型的**我同意審核完成後分享訊息到我的動態牆**](https://lh6.googleusercontent.com/-Sdvcxa1hTFs/VQapA6DqxUI/AAAAAAAAF2I/EEQcr9GEsB4/w800-h384-no/Share_4.png) 

---
###其他UI功能應用
- 邀請好友  
	![](http://goo.gl/Oicugo)  
 
- [Send Dialog](https://developers.facebook.com/docs/sharing/reference/send-dialog)
	- 目的：傳訊息給好友。
	- 粉多網站應用：[圖文任務，審核成功後的 "揪朋友挺我" 傳送訊息](http://s26.postimg.org/xrv4newiv/Send_Msg_Friend.png)
		- 傳送訊息的Popup  
			![facebook send dialog](https://lh5.googleusercontent.com/--IMiAgZP52o/VQapQbxMWiI/AAAAAAAAF2U/27Qc1oMWehw/w800-h367-no/Send_Msg_Friend.png)  
		- 傳送成功後，可在接受者的Mailbox收到訊息  
			![facebook send dialog](http://goo.gl/JDzpci)  
		- 參數設定
			- name：標題
			- picture： 圖片網址
			- description：說明
			- link：連結網址
- 使用Hashtags 主題標籤  
	![](http://goo.gl/8HrQwY)   

	- 目的：當使用者對於特定主題有興趣的時候，可點Hashtags觀看相關文章，增加曝光率，功能類似是一個搜尋結果連結。
	- 備註
		- 建議使用方式：同標籤選取方式，但範圍不設限於自己站內經營的關鍵字，而是目前(或某段時間內)搜尋或分享的潮流。
		- 建議格式：可參考[Hashtag 是什麼？](http://gordon168.tw/?p=595)

---
###其他Graph API功能應用
- Taggable_friends：選擇、分享(graph api)同時標記好友。參考另一篇文章[Facebook Graph API - Taggable Friends](http://cythilya.blogspot.tw/2014/09/facebook-graph-api-taggable-friends.html)，對於背景、功能、範例、程式碼等有詳細的解說。  

- 活動提醒、加入行事曆，[Citytalk 城市通](http://www.citytalk.tw)、[Accupass 活動通](http://www.accupass.com)  
	- Citytalk 城市通 - 加入Facebook活動提醒、Google行事曆  

	![Citytalk 城市通，活動提醒、加入行事曆](https://lh5.googleusercontent.com/-mRO8s-49Jhc/VQapTQE8wGI/AAAAAAAAF2o/PZQzQWXMVuQ/w800-h442-no/citytalk_notification.png)   
	- Citytalk 城市 - 加入Facebook活動提醒、Google行事曆  

	![Citytalk 城市通，提醒列表](https://lh4.googleusercontent.com/-nYfwrqvY4nQ/VQapTjVUA9I/AAAAAAAAF2s/2FiQ0gqO258/w800-h686-no/citytalk_notification_list.png)

	- Accupass 活動通 - 加入Google行事曆 
	![Accupass 活動通 - 加入Google行事曆](https://lh5.googleusercontent.com/-ssR0FaXmfhM/VQapTs292fI/AAAAAAAAF2k/wythpfp3iFM/w800-h668-no/accupass_cal.png)

---
##og相關
- 功能：指定分享內容
- 分享呈現的檢視
	- og:title - Name
	- og:description -Description
	- og:image - Picture
	- og:url - Link  

![](http://goo.gl/8cYcMH)

- 清除快取工具：[Open Graph Debugger](https://developers.facebook.com/tools/debug/)

##權限相關
哪些功能是需要權限的？需要什麼權限？<!-- 基本或進階的權限？-->  

- Sharing by Graph API
	- 需要的權限：publish_actions
	- 備註
		- 由於需要要求權限並設定分享群組，因此除了授權APP外，會多一個授權分享的popup，如下圖。  
			- 取得授權  
				![](http://goo.gl/9tQh8U)
			- PO文權限  
				![新會員授權, PO文權限](http://goo.gl/BLiSQ1) 
		- 分享權重較低(低於UI分享)，可能無法出現在動態牆上。
		- 若標示不清會被使用者檢舉濫發訊息，導致APP被停用(目前解法是申請多個APP供替換)。 
- taggable_friends 
	- 需要的權限：taggable_friends 
	- 備註
		- 2.0後才有的功能。  
		- 需經審核。

---
##成效衡量
- [Insight](https://developers.facebook.com/docs/insights)
- 若評估轉換率，則再加入短網址 + GA
	- 短網址：記錄每個分享網址的點擊數，約略計算導回網站的流量
	- 使用Sever端做紀錄
	- GA：得到每一頁的頻道流量(Social、Direct、Referral、Organic Search)
- 使用Hashtag增加的流量(Referral)

---
###相關閱讀
- [Facebook Graph API & Demo Example](http://cythilya.blogspot.tw/2014/06/facebook-graph-api-demo-example.html)
- [Facebook Product Introduction](http://blog.friendo.com.tw/posts/234544-facebook-product-introduction) - 這篇文章的孿生兄弟，也是我寫的，因當時有分享需求而略做調整，是比較完整的版本，可以參考一下。