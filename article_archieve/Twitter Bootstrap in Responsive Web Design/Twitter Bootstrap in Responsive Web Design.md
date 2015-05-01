#使用Bootstrap建立一個RWD Template (Twitter Bootstrap in Responsive Web Design)
使用Bootstrap建立一個RWD Template的筆記。

![使用Bootstrap建立一個RWD Template (Twitter Bootstrap in Responsive Web Design)](https://lh5.googleusercontent.com/-pWSKWYXja30/VPB4ZUyrK6I/AAAAAAAAFiA/f_Pzm-H6ZYM/w800-h559-no/1442274_71263819.jpg)

##建立方法 / 觀念
一個頁面能成為RWD，需要Fluid Layout、Flexible / Fluid Images與CSS3 Media Query。

###Fluid Layout
傳統的Fixed Layout在不同解析度上，是呈現固定寬度的。

![Fixed Layout](https://lh5.googleusercontent.com/-1N6pdr5zg7Q/VPA3vCsvXvI/AAAAAAAAFhM/QTchxCL2DYU/w500-h375-no/fixed.jpg)  

但這樣的頁面在手機、平板等行動裝置上非常不易閱讀，使用者可能要常常做放大、縮小的動作來觀看網頁內容。因此，我們希望在這些行動裝置上的排版可以不一樣，以適應不同裝置上的瀏覽方式。寬度的設定不再固定px等固定單位，而是使用百分比(%)。

![Fluid Layout](https://lh6.googleusercontent.com/-33t9BzGpWjw/VPA3vEqEs6I/AAAAAAAAFhM/5T70xNAiio4/w500-h375-no/fluid.jpg)

圖片來源：[Fixed vs. Fluid vs. Elastic Layout: What’s The Right One For You?](http://www.smashingmagazine.com/2009/06/02/fixed-vs-fluid-vs-elastic-layout-whats-the-right-one-for-you)

###Flexible / Fluid Images
不設定圖片為固定的寬度(例如：`width: 100px;`)，而是使用百分比(%)，讓圖片隨著容器大小而改變寬高。

	img{
		width: 100%;
	}

###CSS3 Media Query
RWD中最重要的就是Media Query，它讓版面在不同解析度下能有不同的呈現。例如：依據不同寬度做不同的調整。

	@media(max-width: 768px){
		.navbar-right form{
			display:none;
		}
	}
	
	@media(max-width: 568px){
		.jumbotron{
			text-align: center;
		}
		footer{
			text-align: center;
		}
	}

######當然還有其它的地方需要注意，例如：
- Viewport meta tag - zoom in, zoom out
- Mouse vs. Touch：手機和平板沒有滑鼠，而是觸控、滑動
- Images / Graphics：不同銀幕解析度需要不同解析度、Size的圖片，有個Image Server就更好了
- Amount of content：功能與內容的增減(可能還有流程調整)，以適於不同裝置的瀏覽習慣

##使用Bootstrap建立一個RWD Template
####[點此看Demo](http://cythilya.apphb.com/content/template/bootstrap_foodsense/index.html)
###建立基本外殼
Copy Bootstrap的範本作為外殼，範本位置：[Basic template](http://getbootstrap.com/getting-started/#template)，去除不需要的片段，精簡如下：

	<!DOCTYPE html>
	<html lang="en">
	  <head>
	    <meta charset="utf-8">
	    <meta http-equiv="X-UA-Compatible" content="IE=edge">
	    <meta name="viewport" content="width=device-width, initial-scale=1">
	    <title>Bootstrap Template</title>
	    <link href="css/bootstrap.min.css" rel="stylesheet">
	  </head>
	  <body>
	    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
	    <script src="js/bootstrap.min.js"></script>
	  </body>
	</html>

###Navbar、Jumbotrol
- 取得[Navbar樣版](http://getbootstrap.com/components/#navbar)，並將程式碼片段貼在樣板上。
- 取得[Jumbotrol樣版](http://getbootstrap.com/components/#jumbotron)，並將程式碼片段貼在樣板上。
 
###Grids
由於在這裡我們希望三個小方塊(box)可以依據解析度而有不同的排列方式，因此使用Bootstrap的Grid System。規則如下：

- 結構依序為如下：container -> row -> column 
- 所有的「row」都要放在「container」之下，「col-*」(column)要放在「row」之下。
- column為最小單位的方格，且有間格將彼此格開。
- 由「row」校正colume左右多出來的左右padding。
- 基本上一個row放置12個column，若有一個row超過12個column，則會斷行放置多出來的column。

column命名規則：

- `.col-xs-*`：只是scall down
- `.col-sm-*`、`.col-md-*`、`.col-lg-*`：在特定範圍下是維持Horizontal，以下則Stack Vertically
	- Small grid (≥768px) = .col-sm-*
	- Medium grid (≥992px) = .col-md-*
	- Large grid (≥1200px) = .col-lg-* 
- `.col-md-offset-*`：間格

詳細資訊可參考

- [What is the difference among col-lg-*, col-md-* and col-sm-* in twitter bootstrap3?](http://stackoverflow.com/questions/19865158/what-is-the-difference-among-col-lg-col-md-and-col-sm-in-twitter-bootstra)
- [Grid System](http://getbootstrap.com/css/#grid)

###Panel、Forms、Wells、Footer
另外，我們會再放佔8個Grid的Panel([Panel樣版](http://getbootstrap.com/components/#panels))、佔4個Grid的Form進去([Form樣版](http://getbootstrap.com/css/#forms))、Well([Well樣版](http://getbootstrap.com/components/#wells))、Sticky Footer。

因此將以下的三個小方塊、Panel、Form、Well、Sticky Footer程式碼片段放到樣版中。

	<div class="container">
	    <div class="row">
	        <div class="col-sm-4 panel-item">
	            <div class="box">
	                <div class="box-heading">
	                    <img src="images/food_bread.jpg">
	                </div>
	                <div class="box-body">
	                    <h3>Bread</h3>
	                    <p>Li Europan lingues es membres del sam familie. Lor separat existentie es un myth. Por scientie, musica, sport etc, litot Europa usa li sam vocabular. Li lingues differe solmen in li grammatica, li pro</p>
	                </div>
	            </div>
	        </div>
	        <div class="col-sm-4 panel-item">
	            <div class="box">
	                <div class="box-heading">
	                    <img src="images/food_coffee_beans.jpg">
	                </div>
	                <div class="box-body">
	                    <h3>Coffee Beans</h3>
	                    <p>The European languages are members of the same family. Their separate existence is a myth. For science, music, sport, etc, Europe uses the same vocabulary. The languages only differ in their grammar.</p>
	                </div>
	            </div>
	        </div>
	        <div class="col-sm-4 panel-item">
	            <div class="box">
	                <div class="box-heading">
	                    <img src="images/food_strawberry.jpg">
	                </div>
	                <div class="box-body">
	                    <h3>Strawberry</h3>
	                    <p>A wonderful serenity has taken possession of my entire soul, like these sweet mornings of spring which I enjoy with my whole heart. I am alone, and feel the charm of existence in this spot, which was.</p>
	                </div>
	            </div>
	        </div>        
	    </div>
	    <div class=row>
	        <div class="col-md-8">
	            <div class="panel panel-default">
	                <div class="panel-heading">
	                    Welcome
	                </div>
	                <div class="panel-body">
	                    <p>
	                        Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo
	                    </p>    
	                    <p>
	                        Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo
	                    </p>
	                </div>
	            </div>   
	        </div>
	        <div class="col-md-4">
	            <div class="well">
	                <form>
	                    <div class="form-group">
	                        <label for="exampleInputName">Name</label>
	                        <input type="password" class="form-control" id="exampleInputName" placeholder="Name">
	                    </div>
	                    <div class="form-group">
	                        <label for="exampleInputEmail1">Email address</label>
	                        <input type="email" class="form-control" id="exampleInputEmail1" placeholder="Enter email">
	                    </div>
	                    <div class="form-group">
	                        <label for="exampleMessage">Message</label>
	                        <textarea class="form-control" id="exampleMessage" placeholder="Messages"></textarea>
	                    </div>                
	                    <button type="submit" class="btn btn-default">Submit</button>
	                </form>  
	            </div>
	        </div>
	    </div>
	    <hr>
	    <footer>
	        <div class="row">
	            <div class="col-lg-12">
	                <p>Copyright &copy 2015, Food Sense</p>
	            </div>
	        </div>
	    </footer>
	</div>

###完整的HTML Structure

	<!DOCTYPE html>
	<html>
	<head>
	<meta charset="utf-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<title>Bootstrap Template</title>
	<link href="css/bootstrap.min.css" rel="stylesheet">
	<link href="css/custom.css" rel="stylesheet">
	</head>
	<body>
	<nav class="navbar navbar-default">
	    <div class="container-fluid">
	        <div class="navbar-header">
	            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1"><span class="sr-only">Toggle navigation</span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
	            </button>
	            <a class="navbar-brand" href="#">Food Sense</a>
	        </div>
	        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
	            <ul class="nav navbar-nav">
	                <li class="active">
	                    <a href="#">Home<span class="sr-only">(current)</span></a>
	                </li>
	                <li>
	                    <a href="#">About</a>
	                </li>
	                <li class="dropdown">
	                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Foods<span class="caret"></span></a>
	                    <ul class="dropdown-menu" role="menu">
	                        <li><a href="#">Bread</a></li>
	                        <li><a href="#">Coffee Beans</a></li>
	                        <li><a href="#">Strawberry</a></li>
	                    </ul>
	                </li>
	            </ul>
	            <ul class="nav navbar-nav navbar-right">
	                <form class="navbar-form navbar-left" role="search">
	                    <div class="form-group">
	                        <input type="text" class="form-control" placeholder="Search">
	                    </div>
	                    <button type="submit" class="btn btn-default">Submit</button>
	                </form>
	                <li><a href="#">My Account</a></li>
	            </ul>
	        </div>
	    </div>
	</nav>
	<div class="jumbotron">
		<div class="container">
			<div class="row">
				<div class="col-md-7 jumbo-text">
					<h1 class="tagline">Food Sense</h1>
					<p class="lead">A wonderful serenity has taken possession of my entire soul</p>
					<a href="#" class="btn btn-default btn-lg">Read More</a>
				</div>
			</div>
		</div>
	</div>
	<div class="container">
	    <div class="row">
	        <div class="col-sm-4 panel-item">
	            <div class="box">
	                <div class="box-heading">
	                    <img src="images/food_bread.jpg">
	                </div>
	                <div class="box-body">
	                    <h3>Bread</h3>
	                    <p>Li Europan lingues es membres del sam familie. Lor separat existentie es un myth. Por scientie, musica, sport etc, litot Europa usa li sam vocabular. Li lingues differe solmen in li grammatica, li pro</p>
	                </div>
	            </div>
	        </div>
	        <div class="col-sm-4 panel-item">
	            <div class="box">
	                <div class="box-heading">
	                    <img src="images/food_coffee_beans.jpg">
	                </div>
	                <div class="box-body">
	                    <h3>Coffee Beans</h3>
	                    <p>The European languages are members of the same family. Their separate existence is a myth. For science, music, sport, etc, Europe uses the same vocabulary. The languages only differ in their grammar.</p>
	                </div>
	            </div>
	        </div>
	        <div class="col-sm-4 panel-item">
	            <div class="box">
	                <div class="box-heading">
	                    <img src="images/food_strawberry.jpg">
	                </div>
	                <div class="box-body">
	                    <h3>Strawberry</h3>
	                    <p>A wonderful serenity has taken possession of my entire soul, like these sweet mornings of spring which I enjoy with my whole heart. I am alone, and feel the charm of existence in this spot, which was.</p>
	                </div>
	            </div>
	        </div>        
	    </div>
	    <div class=row>
	        <div class="col-md-8">
	            <div class="panel panel-default">
	                <div class="panel-heading">
	                    Welcome
	                </div>
	                <div class="panel-body">
	                    <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo</p>
	                </div>
	            </div>   
	        </div>
	        <div class="col-md-4">
	            <div class="well">
	                <form>
	                    <div class="form-group">
	                        <label for="exampleInputName">Name</label>
	                        <input type="password" class="form-control" id="exampleInputName" placeholder="Name">
	                    </div>
	                    <div class="form-group">
	                        <label for="exampleInputEmail1">Email address</label>
	                        <input type="email" class="form-control" id="exampleInputEmail1" placeholder="Enter email">
	                    </div>
	                    <div class="form-group">
	                        <label for="exampleMessage">Message</label>
	                        <textarea class="form-control" id="exampleMessage" placeholder="Messages"></textarea>
	                    </div>                
	                    <button type="submit" class="btn btn-default">Submit</button>
	                </form>  
	            </div>
	        </div>
	    </div>
	    <hr>
	    <footer>
	        <div class="row">
	            <div class="col-lg-12">
	                <p>Copyright &copy 2015, Food Sense</p>
	            </div>
	        </div>
	    </footer>
	</div>
	<script src="js/jquery-1.11.2.min.js"></script>
	<script src="js/bootstrap.min.js"></script>
	</body>
	</html>

###完整的CSS Code Snippet
雖然使用Bootstrap的框架，但還是做了一些客製化調整。  

[點此看原始檔](http://cythilya.apphb.com/content/template/bootstrap_foodsense/css/custom.css)。

###預覽圖
####Desktop
![Twitter Bootstrap in Responsive Web Design - Desktop](https://lh5.googleusercontent.com/-sK0JNtnCH2Q/VPBcs7P0fBI/AAAAAAAAFhs/lkBfNQep4YQ/w799-h816-no/bootstrap_template_desktop.png)
###Tablet
![Twitter Bootstrap in Responsive Web Design - Tablet](https://lh4.googleusercontent.com/-Al5OqbO7uYY/VPBcs5LNuZI/AAAAAAAAFho/ceb3G_iJxMo/w672-h816-no/bootstrap_template_tablet.png)
###Mobile
![Twitter Bootstrap in Responsive Web Design - Mobile](https://lh3.googleusercontent.com/9hXL_ewQLGafnYYewCUUu_-ipj0NPsclyVHMnp6_Vbc=w413-h815-no)

以下備註一些相關資訊~

###關於Viewport Meta Tag
Viewport Meta Tag並非W3C標準的標籤，但仍廣泛備使用。格式為：  
`<meta name="viewport" content="">`

屬性content的值可為：  

- Width
- Width-device-width
- Initial-scale
- Maximum-scale

範例:設定寬度為320px  
`<meta name="viewport" content="width="320">`

範例: 設定寬度為裝置的寬度  
`<meta name="viewport" content="width=device-width">`

範例: 設定縮放大小為1倍  
`<meta name="viewport" content="initial-scale=1">`

範例: 設定縮放大小最大為1倍，但使用此設定，使用者會無法藉由放大縮小來看也面的內容  
`<meta name="viewport" content="maximum-scale=1">`

範例: 設定寬度為裝置的寬度、縮放大小為1倍  
`<meta name="viewport" content="width=device-width,initial-scale=1">`

###關於`<meta http-equiv="X-UA-Compatible" content="IE=edge">`
有什麼最心的版本IE，就用什麼版本的標準模式。

相關可參考

- [[ASP.net] 確保IE瀏覽器的瀏覽器模式、文件模式都是使用最新版本](http://mobile.dotblogs.com.tw/shadow/archive/2012/01/12/65506.aspx)
- [【HTML教學】X-UA-Compatible設置IE兼容模式](http://injerry.pixnet.net/blog/post/57042465-%E3%80%90html%E6%95%99%E5%AD%B8%E3%80%91x-ua-compatible%E8%A8%AD%E7%BD%AEie%E5%85%BC%E5%AE%B9%E6%A8%A1%E5%BC%8F)

##建立自己的Grid System
使用框架[Twitter Bootstrap](http://getbootstrap.com)、[Foundation](http://foundation.zurb.com)當然非常方便，但我們往往因為需求而需要大量客製化，如果使用框架反而造成太多限制，不如自己寫個Grid System就好。這裡有一篇教學文章可參考 [Creating Your Own CSS Grid System | Jan Drewniak](http://j4n.co/blog/Creating-your-own-css-grid-system)。

##Mobile Search
再次強調Mobile看網頁的用戶實在太多了，因此Mobile First逐漸形成趨勢。而Google手機搜尋結果將把Mobile Usability當成其中一個評斷標準。如果希望2015/04/21後能看到自己的網站出現在手機搜尋結果上，可用工具檢測看看是否符合官方標準。  

相關可見 [Google To Use Mobile Usability As A Ranking Factor In Mobile Search Results](http://www.searchenginejournal.com/google-use-mobile-usability-ranking-factor-mobile-search-results/127045)

---
####推薦閱讀
- [Fixed vs. Fluid vs. Elastic Layout: What’s The Right One For You?](http://www.smashingmagazine.com/2009/06/02/fixed-vs-fluid-vs-elastic-layout-whats-the-right-one-for-you)
- [Twitter Bootstrap in Responsive Web Design | Udemy](https://www.udemy.com/twitter-bootstrap-in-responsive-web-design) - 線上學習課程，解說清楚、免費
- [Bootstrap · The world's most popular mobile-first and responsive front-end framework.](http://getbootstrap.com)
- [Bootstrap 3 中文手冊 · 世界最受歡迎的行動優先和自適應前端框架。 - KKBruce](https://kkbruce.tw/bs3) 
- [Creating Your Own CSS Grid System | Jan Drewniak](http://j4n.co/blog/Creating-your-own-css-grid-system) - 自製Grid System教學文章
- [各廠牌手機解析度列表](http://screensiz.es/phone) - 查詢各手機的解析度等資訊 
- [Media Query Snippets](http://nmsdvid.com/snippets) - 蒐集Media Query常用程式碼片段，並用解析度、廠牌分類
- [What is the difference among col-lg-*, col-md-* and col-sm-* in twitter bootstrap3?](http://stackoverflow.com/questions/19865158/what-is-the-difference-among-col-lg-col-md-and-col-sm-in-twitter-bootstra)
- [Container-fluid vs .container](http://stackoverflow.com/questions/22262311/container-fluid-vs-container)
- [手機網頁設計新取向─台灣五大案例分析！](http://www.bnext.com.tw/article/view/id/35307)
- [RWD(Responsive Web Design) 實作筆記](http://cythilya.blogspot.tw/2014/10/rwd.html) - 簡單的Media Query筆記
####工具推薦
#####開發工具
- [ApacheFriends XAMP](https://www.apachefriends.org/zh_tw/index.html) - XAMPP是最流行的PHP開發環境XAMPP是完全免費且易於安裝的Apache發行版本，其中包含MySQL、PHP和Perl。XAMPP開放源碼套件的設置讓安裝和使用出奇容易。
#####測試工具
- [Responsive Website Tester](https://chrome.google.com/webstore/detail/responsive-website-tester/eopndgnmfpbhfamlgcfcfedcabbfnkhn) - Google Chrome擴充工具
- [Mobile Responsive Design Testing](http://www.studiopress.com/responsive) - 可將所有狀況一次展開
- [Do You Use Responsive Web Design | Responsive Design Checker](http://responsivedesignchecker.com) - 一次一種狀況
- [Responsinator](https://www.responsinator.com) - 可將所有狀況一次展開，以Apple產品為主，更為擬真
- [Responsive Design Testing across Mobile and Desktop Browsers - iOS, Android, OS X, Windows](http://www.browserstack.com/responsive)
- [Viewport Resizer - Responsive design testing tool](http://lab.maltewassermann.com/viewport-resizer) – Emulate various screen resolutions - Best developer device testing toolbar
#####設計工具
- [Flinto](https://www.flinto.com) - 有圖層概念，類似Photoshop，可合作編輯，但要付費
- [Webflow](https://webflow.com) - Drag & Drop界面，快速產生程式碼
#####框架
- [Twitter Bootstrap](http://getbootstrap.com)
- [Foundation](http://foundation.zurb.com)
#####樣版、元件
- [Bootstrap中文网](http://www.bootcss.com) - Bootstrap是Twitter推出的一个用于前端开发的开源工具包。它由Twitter的设计师Mark Otto和Jacob Thornton合作开发，是一个CSS/HTML框架。目前，Bootstrap最新版本为3.0 。Bootstrap中文网致力于为广大国内开发者提供详尽的中文文档、代码实例等，助力开发者掌握并使用这一框架。
- [LayoutIt! - Interface Builder for Bootstrap](http://www.layoutit.com)
- [Bootstrap Form Builder](http://minikomi.github.io/Bootstrap-Form-Builder)
- Sliders
	- [ResponsiveSlides.js](http://responsiveslides.com) 
    - [Flex Slider](http://www.woothemes.com/flexslider)
    - [UnoSlider](http://unoslider.com)
    - [Blueberry](http://marktyrrell.com/labs/blueberry)
- Table
	- [Crafty Responsive Tables | Playground from ZURB](http://zurb.com/playground/responsive-tables)