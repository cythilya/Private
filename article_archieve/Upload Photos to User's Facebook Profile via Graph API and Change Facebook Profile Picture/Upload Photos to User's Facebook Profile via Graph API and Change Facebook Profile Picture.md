#使用Graph API上傳圖片到Facebook相簿、並設定為使用者大頭照(Upload Photos to User's Facebook Profile via Graph API and Change Facebook Profile Picture)
有不少活動都會引導使用者上傳圖片並設定為封面或是檔案頭像，例如 [遮打革命 Umbrella Revolution - Support Campaign | Twibbon](http://twb.ly/D7KQB1B6)。  

###先來看看遮打革命 Umbrella Revolution的分享美圖~
![遮打革命 Umbrella Revolution - Support Campaign | Twibbon](https://lh5.googleusercontent.com/-voJVyXnzGEM/VETqkDAeDWI/AAAAAAAADUY/SfPjE1WVjXI/w505-h452-no/%E9%81%AE%E6%89%93%E9%9D%A9%E5%91%BD.png)

###再來看看活動流程~
![](https://lh3.googleusercontent.com/-wv-69SuPe90/VETopYSGbDI/AAAAAAAADUE/BD_cvrjahrM/w899-h725-no/umbrella_revolution.gif)

##流程解析
1. 上傳圖片到到APP專屬資料夾，上傳成功後會回傳photo id
2. 取得photo id與相關訊息，引導使用者切圖、自行設定為profile image

##程式碼說明
在clicke "Clik Me to Upload & Set Profile Image" 按鈕後，先將圖片上傳至使用者Facebook之此APP的相簿(此為Lydia)。  
上傳成功後，會回傳photo id。我們在由此photo取得編輯圖片的網址，並在網址後面加上設定為profile image的參數 - "&makeprofile=1"。  
這樣我們就可以看到上傳圖片後，被轉址到Facebook網站，此照片切裁、設定profile image的頁面。  

		dBtnUplodSetCover.click(function(e){
			e.preventDefault();
			
			FB.login(function(response) {
				if (response.authResponse) {
					var access_token =   FB.getAuthResponse()['accessToken'];
					var linkTemp = '';
					userID = FB.getAuthResponse()['userID'];
				
					//上傳圖片，在此API後必須加上access token才能運作
					FB.api(
						'/me/photos?access_token=' + access_token, 
						'post', 
						{ 
							url: IMAGE_SRC, //上傳圖片的網址
							access_token: access_token 
						}, function(resp) {
						if (!resp || resp.error) {
							console.log('Error occured: ' + JSON.stringify(resp.error));
						} 
						else {
							//上傳成功
							//取得photo id，準備進一步取得設定photo的網址
							var photoID = resp.id;
							
							FB.api(
								'/' + photoID,
								function (res) {
									//makeprofile: 設定為profile image的參數
									//取得照片網址後，將其append到編輯網址之後
									linkTemp = res.link + '&makeprofile=1'; 

									//轉址到Facebook網站，此照片切裁、設定profile image的頁面
									location.replace(linkTemp);
								}
							);
						}
					});
				} else {
					console.log('User cancelled login or did not fully authorize.');
				}
			}, {scope: 'publish_stream, user_photos'});		
		});

##Demo
範例結果展示如下~  

![Upload & Set Profile Image](https://lh3.googleusercontent.com/-enU2uyS2H1o/VETkuatQKzI/AAAAAAAADTk/jW8x9aEOvhU/w899-h725-no/upload_and_profile_image.gif)

##Permission
以上流程需要的權限為：  

- publish_stream：上傳圖片
- user_photos：操作使用者的相簿與圖片

---
###參考資料
- [遮打革命 Umbrella Revolution - Support Campaign | Twibbon](http://twb.ly/D7KQB1B6)：換頭像的活動
- [Change Facebook Cover or Profile Pic with PHP](http://www.sanwebe.com/2012/09/change-facebook-cover-or-profile-pic-with-php)：除了換頭像，還可以換封面
- [Generate Facebook ID Card with PHP](http://www.sanwebe.com/2013/03/creating-facebook-id-card-with-php-facebook-sdk)  ：產生Facebook身分證，取得個人資訊、PO圖與活動網址
- [How-To: Use the Graph API to Upload Photos to a user’s profile](https://developers.facebook.com/blog/post/498)：如何經由Graph API上傳圖片 - 上傳到APP專屬資料夾、新建資料夾
- [PHP Change Facebook Profile Picture With Graph API](http://4rapiddev.com/facebook-graph-api/php-change-facebook-profile-picture-with-graph-api)
- [Setting Facebook Cover Photo via API](http://stackoverflow.com/questions/7849783/setting-facebook-cover-photo-via-api)
