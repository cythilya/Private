#Facebook  Graph API - Taggable Friends

![Facebook  Graph API - Taggable Friends](https://lh5.googleusercontent.com/PVQpjhXb8rwBsesmmBXVUcu35V25LUU1giPibA015JI=w885-h664-no)

有鑑於IKEA做了一個好玩的活動網站[來IKEA睡一晚](http://ikea.event2.tw/gathering/?website=fbpostback)，其中含有邀請朋友並標記、分享到Facebook上，因此也做了一個範例來玩玩。   

##[來IKEA睡一晚 - Taggable Friends](http://ikea.event2.tw/gathering/?website=fbpostback)的UI流程
- 選擇好友
	![](https://lh3.googleusercontent.com/-BsFd-qWnDnI/VBf85YXH6vI/AAAAAAAACvA/-gfsjna5qX0/w911-h649-no/taggable_friends_invite_popup.png)  

- 分享並標記好友  
	![](https://lh5.googleusercontent.com/-rhuRYiAxUrc/VBf85VeO8hI/AAAAAAAACvA/vE1Whz609BU/w927-h652-no/taggable_friends_invite_confirm.png)
- 在FB上看到分享的PO文  
	![](https://lh4.googleusercontent.com/l13C8704lOVBn4Ie376Op2tCTLv1znxlg96mIFa3qwk=w523-h262-no) 

##但這個功能是有限制的...
- 好友頭像大小受限(50*50(px))。如果想客製拉成大圖就會很模糊，但一般選擇朋友應該不會用到太大的圖啦XD    
- 此權限必須要經過Reivew才能供非開發者使用 -> 必須提交審核APP，審核需要相關資訊和時間。
- 此功能只有2.0以上才有，如果網站是用1.0的話就無法使用。附註：轉換成2.0，此時取得的使用者ID是Application-Specific IDs。
- 不能使用UI分享，必須使用Graph API分享，因為UI分享無法使用Message欄位，不能對使用的發佈的訊息做加工。附註：Graph API分享的權重較低。
- 必須要有 "place" 欄位，否則不能分享PO文，會出現錯誤訊息 "(#100) Cannot specify user tags without a place tag"。並且place欄位要放ID而非一般的字串，必須是粉絲頁ID，不可為個人ID。

##自己做的簡單範例Demo
![Facebook  Graph API - Taggable Friends](https://lh6.googleusercontent.com/KDraS0tPi5zF5Pcj0AVHRXq9cxDzIAkA_g7wEO-XoGU=w920-h594-no)

##主要程式碼解說

		//取得朋友清單
		FB.api('/me/taggable_friends', function(res) {
			if (res && !res.error) {
				var friendsData = res.data;
				
				$.each(friendsData, function(index, value){
					//取得分享ID
					//Append到畫面上供使用者勾選
				});	
			}
		});	

		//按下分享按鈕
		dShare.click(function(e){
			e.preventDefault();
			
			//將所有的朋友小區塊蒐集起來
			var dFriends = dFriendList.find('.friend');
			
			//把選擇到的朋友ID丟入此Array
			var friendArr = [];
			
			//檢查每一個朋友小區塊是否被勾選，如果被勾選就將此朋友的ID放到Array裡面
			dFriends.each(function(index, value){
				var dObj = $(value).find('.checkbox');
				
				if(dObj.attr('checked')){
					friendArr.push(dObj.data('id'));
				}
			});

			//將被勾選的朋友陣列轉成逗點分隔的字串
			friendString = friendArr.join(',');
			

			FB.login(function(){
				var params = {};
				params['name'] = 'Facebook Graph API & Demo Example - Taggable Friends';
				params['caption'] = 'Facebook Graph API & Demo Example - Taggable Friends';	
				params['description'] = 'Taggable Friends';
				params['message'] = 'Graph API是Facebook所推出的一種技術標準，它的核心概念是「物件與連結」。為什麼稱為「Graph API」呢？因為整個Facebook就是透過這些物件與連結建立而成的Social Graph。Facebook所提供存取的介面，就稱為「Graph API」。';
				params['link'] = 'http://bit.ly/1qtutRh';
				params['picture'] = 'https://lh4.googleusercontent.com/-nw381RE73SY/U5KlRrevDFI/AAAAAAAACMQ/FJnuqzQfnMA/w764-h509-no/twenty_800.jpg';
				
				//被Tag的朋友字串
				params['tags'] = friendString;
				
				//一定要有地點欄位，否則會出錯
				params['place'] = '647158178704039';//https://www.facebook.com/pages/Search-Engine-Optimization-Social-Media/647158178704039
			
				//PO文，記得要取得publish_actions權限
				FB.api('/me/feed', 'post', params, function(response) {
				  if (!response || response.error) {
					alert('Error occured');
				  } else {
					alert('Post ID: ' + response.id);
				  }
				});
			}, {scope: 'publish_actions'});	
		});	

##結果
![](https://lh4.googleusercontent.com/-KZ6-L0Xl-nU/VCAAPfeHzKI/AAAAAAAADIM/veC_3XiPK5I/w521-h334-no/taggable_friends_individual.png)

