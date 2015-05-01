#利用Bootstrap Grid System排版的學習筆記
##Bootstrap Grid System in Responsive Web Design
利用Bootstrap Grid System來排版真是一個方便的方法，最簡單的例子就是如果一個頁面上有許多小方格會隨著Device/解析度而有不同的排列方式，就很適合用Grid System來排版，像這樣～  

![Bootstrap Grid System in Responsive Web Design](https://lh3.googleusercontent.com/-3Ocz5GKl4TE/VSOdfbTDj1I/AAAAAAAAGJA/eI_h-fwaObI/w800-h467-no/grid_image_800.png)  

[Am I Responsive?](http://ami.responsivedesign.is)

##規則
Grid System是經由Row(列)和Column(行)來建立頁面的架構的，然後再將內容裝在這些由Row(列)和Column(行)組成的框框裡面。簡述規則如下：

- class的結構依序為：`.container`(固定寬度) 或 `.container-fluid`(滿版，看[範例](http://getbootstrap.com/css/#grid-example-fluid)) -> `.row` -> Column。「`.container`」或「`.container-fluid`」讓版面有適當的對齊方式(alignment)和間格(padding)。
- 使用水平方向的「`.row`」來群組Column。
- 內容放在Column之內，且Column一定緊接在「`.row`」之下，是為Immediate Children。
- 使用class「`.row`」或「`.col-xs-4`」來建立頁面的架構，也可以使用Less mixins and variables來做設定或調整。
- Column為最小單位的方格，且有間格將彼此格開，並由「`.row`」使用負的margin值校正因Column而多出來的左右padding。
- 指定Column的格數(最多到12)，例如一列希望有3個相等的Column，可指定3個「`.col-xs-4`」。
- 基本上一個Row放置12個Column，若有一個Row超過12個Column，則會斷行放置多出來的Column。
- 使用Grid Class會影響到大於/等於設定分段點的Device，例如：使用「`.col-md-*`」不僅會影響到Desktop，若沒有設定「`.col-lg-*`」，還會影響到Large Desktop。

##Media Queries的分段點
- Mobile – xs ( < 768px )
- Tablet – sm ( 768~991px ) 
- Desktop – md ( 992~1200px )
- Large Desktop - lg ( >= 1200px )

##Grid Options
列表如下。

![Bootstrap Grid Options](https://lh4.googleusercontent.com/-Ci2UIEdxe4k/VSOdfp1zz0I/AAAAAAAAGJA/h8UJdBl5woo/w724-h395-no/grid_options.png)  

因此我們可以依此做基本的設定，在Desktop的結果如下：  

![stacked-to-horizontal](https://lh4.googleusercontent.com/-YtRiM35BRWg/VSOdg309LFI/AAAAAAAAGJA/shNn1qZ-f6s/w800-h217-no/stacked-to-horizontal.png)  

Mobile和Tablet就是垂直排列：  

![stacked-to-horizontal-vertical](https://lh4.googleusercontent.com/-7mipMIKsQ9c/VSOdgfG8BrI/AAAAAAAAGJA/a0PE1vQx6MA/w757-h850-no/stacked-to-horizontal-vertical.png)  

可參考[官方網站範例](http://getbootstrap.com/css/#grid-example-basic)。

##針對不同Device混合使用
也許我們不想讓Colume在較小解析度的Device上全都垂直呈現，因為這樣非常單調無聊 - 那就混合使用這些class吧。每一種class單獨控制一種裝置，例如：`col-xs-*`控制Mobile，`col-sm-6-*`控制Tablet，`col-md-*`控制Desktop。

預覽如下圖。  

![grid-example-mixed-complete](https://lh4.googleusercontent.com/-1FhesbnAKl8/VSOdeuRNIfI/AAAAAAAAGJA/HKAQKjow4lQ/w748-h865-no/grid-example-mixed-complete_800.png)  

	<!-- Mobile上各自一列， Tablet上兩欄比例各半、Desktop上兩欄比例為3:2  -->
	<div class="row">
		<div class="col-xs-12 col-sm-6 col-md-8">.col-xs-12 .col-sm-6 .col-md-8</div>
	  	<div class="col-xs-6 col-md-4">.col-xs-6 .col-md-4</div>
	</div>

	<!-- Mobile上各佔一半， Tablet以上三欄各佔1/3 -->
	<div class="row">
	  	<div class="col-xs-6 col-sm-4">.col-xs-6 .col-sm-4</div>
	  	<div class="col-xs-6 col-sm-4">.col-xs-6 .col-sm-4</div>
	  	<div class="clearfix visible-xs-block"></div>
	  	<div class="col-xs-6 col-sm-4">.col-xs-6 .col-sm-4</div>
	</div>

##Column Wrapping
基本上一個Row放置12個Column，若有一個Row超過12個Column，則會斷行放置多出來的Column。  

![Column Wrapping](https://lh6.googleusercontent.com/-fxdH3kxfLWY/VSOdd6LCKrI/AAAAAAAAGJA/Z4cV4nx0-Ec/w737-h148-no/column_wrapping.png)  

	<div class="row">
		<div class="col-xs-9">.col-xs-9</div>	

		<!-- 9 + 4 = 13 > 12，因此以下斷行放置多出來的Column -->
		<div class="col-xs-4">.col-xs-4<br>Since 9 + 4 = 13 &gt; 12, this 4-column-wide div gets wrapped onto a new line as one contiguous unit.</div>
		<div class="col-xs-6">.col-xs-6<br>Subsequent columns continue along the new line.</div>
	</div>

可參考[官方網站範例](http://getbootstrap.com/css/#grid-example-wrapping)。  

##Responsive Column Resets
在某些分段點下，Column沒有正確被擺放。這時就可以使用`.clearfix`和[responsive utility classes](http://getbootstrap.com/css/#responsive-utilities)來作修正。而在某些狀況下，可能還需要用到reset offsets、pushes或pulls。  

利用`col-md-offset-0`、`col-lg-offset-0`做修正。  

	<div class="row">
		<div class="col-sm-5 col-md-6">.col-sm-5 .col-md-6</div>
		<div class="col-sm-5 col-sm-offset-2 col-md-6 col-md-offset-0">.col-sm-5 .col-sm-offset-2 .col-md-6 .col-md-offset-0</div>
	</div>
	
	<div class="row">
		<div class="col-sm-6 col-md-5 col-lg-6">.col-sm-6 .col-md-5 .col-lg-6</div>
		<div class="col-sm-6 col-md-5 col-md-offset-2 col-lg-6 col-lg-offset-0">.col-sm-6 .col-md-5 .col-md-offset-2 .col-lg-6 .col-lg-offset-0</div>
	</div>

正常版(左圖)，如果沒有設定class `col-md-offset-0`、`col-lg-offset-0`就會壞掉唷(右圖)！

![Responsive Column Resets](https://lh4.googleusercontent.com/-zH7AhuR_uqc/VSOdgGOTg9I/AAAAAAAAGJA/wq5hTRy-o9A/w800-h244-no/responsive_column_resets.png)  

可參考[官方網站範例](http://getbootstrap.com/css/#grid-responsive-resets)。

##Offsetting Columns
將Column向右移，意即向左填補空格。  

	<div class="row">
		<div class="col-md-4">.col-md-4</div>
		<!-- 向左填補4個Column -->
		<div class="col-md-4 col-md-offset-4">.col-md-4 .col-md-offset-4</div>
	</div>
	<div class="row">
		<div class="col-md-3 col-md-offset-3">.col-md-3 .col-md-offset-3</div>
		<!-- 向左填補3個Column -->
		<div class="col-md-3 col-md-offset-3">.col-md-3 .col-md-offset-3</div>
	</div>
	<div class="row">
		<!-- 向左填補3個Column -->
		<div class="col-md-6 col-md-offset-3">.col-md-6 .col-md-offset-3</div>
	</div>

![grid-offsetting](https://lh6.googleusercontent.com/-z7RjGSNcfao/VSOde6kAcPI/AAAAAAAAGJA/WjDxW1PNMEQ/w800-h206-no/grid-offsetting.png)

可參考[官方網站範例](http://getbootstrap.com/css/#grid-offsetting)

##Nesting Columns
巢狀放置Column。

![Nesting Columns](https://lh5.googleusercontent.com/-arbjOcmHs54/VSOdf9-bhvI/AAAAAAAAGJA/dWvStvu-Mek/w662-h104-no/nesting_columns.png)  

	<div class="row">
		<div class="col-sm-9">
			Level 1: .col-sm-9
			<div class="row">
				<div class="col-xs-8 col-sm-6">
					Level 2: .col-xs-8 .col-sm-6
				</div>
				<div class="col-xs-4 col-sm-6">
					Level 2: .col-xs-4 .col-sm-6
				</div>
			</div>
		</div>
	</div>

可參考[官方網站範例](http://getbootstrap.com/css/#grid-nesting)

##Column Ordering
設定Column的順序 - `.col-md-push-*` 和 `.col-md-pull-*`。  

![Column Ordering](https://lh5.googleusercontent.com/-Erby989cfPk/VSOddz1B6oI/AAAAAAAAGJA/nDt0Y1PNWFY/w884-h50-no/column_ordering.png)

	<div class="row">
		<div class="col-md-9 col-md-push-3">.col-md-9 .col-md-push-3</div>
	  	<div class="col-md-3 col-md-pull-9">.col-md-3 .col-md-pull-9</div>
	</div>

可參考[官方網站範例](http://getbootstrap.com/css/#grid-column-ordering)  

##Less Mixins and Variables
使用Less mixins and variables來做客製化調整。  

雖然Bootstrap官網可以做些許客製化，但修改的幅度還是太小而且速度太慢了。最好的方式還是用LESS來修改。

使用[Prepros](https://prepros.io)將.less轉為.css。

##實作範例
###範例1 - 簡單暖身題，先練練基本指令
設定參數值：blue、gray、lime、white、sansFontFamily，當用到該值時使用參數(例如：@gray)即可。  

	/* Variables */
	@blue: #049cdb;
	@gray: #555;
	@lime: #32CD32;
	@white: #fff;
	@sansFontFamily: "PT Sans", Helvetica, Arial, sans-serif;
	
	.blog-article {
	    h2 {
	        font-family: @sansFontFamily;
	        color: @gray;
	    }
	}
	
	/* Mixins */
	.blue-background {
	    background: url(path/img.png) 0 0 repeat-x @blue;
	}
	.blog-article {
	    .blue-background;
	}
	.widget-box {
	    color: @white;
	    border: 2px solid @lime;
	    .blue-background;
	}

####Output - Prepros會幫我們輸出CSS檔案(如下)。  

	/* Variables */
	.blog-article h2 {
	  font-family: "PT Sans", Helvetica, Arial, sans-serif;
	  color: #555555;
	}
	/* Mixins */
	.blue-background {
	  background: url(path/img.png) 0 0 repeat-x #049cdb;
	}
	.blog-article {
	  background: url(path/img.png) 0 0 repeat-x #049cdb;
	}
	.widget-box {
	  color: #ffffff;
	  border: 2px solid #32cd32;
	  background: url(path/img.png) 0 0 repeat-x #049cdb;
	}

範例參考 [Using Bootstrap With LESS CSS – Tutorial](http://groupdocs.com/blog/using-bootstrap-with-less-css-tutorial)。

###範例2
客製化Bootstrap的label - 改變label的字體顏色為`#4400cc`。  

	/* Import Bootstrap Less Files */ 
	@import "bootstrap.less"; 
	@label-color: #4400cc;
	.custom-label { 
		.label; 
	} 

####Output - 擷取客製化的部份程式碼

	.label {
	  display: inline;
	  padding: .2em .6em .3em;
	  font-size: 75%;
	  font-weight: bold;
	  line-height: 1;
	  color: #4400cc;
	  text-align: center;
	  white-space: nowrap;
	  vertical-align: baseline;
	  border-radius: .25em;
	}

####Demo
當使用HTML Tag如下，Custom Label變呈現先前設定的紫色樣貌。  

	<label class="custom-label">	
		Custom Label
	</label>

###範例3
####LESS的部份...
	.wrapper {
	  .make-row();
	}
	.content-main {
	  .make-sm-column(8);
	}
	.content-secondary {
	  .make-sm-column(4);
	}

####輸出的CSS部份...
	.wrapper {
	  margin-left: -15px;
	  margin-right: -15px;
	}
	.content-main {
	  position: relative;
	  min-height: 1px;
	  padding-left: 15px;
	  padding-right: 15px;
	}
	@media (min-width: 768px) {
	  .content-main {
	    float: left;
	    width: 66.66666667%;
	  }
	}
	.content-secondary {
	  position: relative;
	  min-height: 1px;
	  padding-left: 15px;
	  padding-right: 15px;
	}
	@media (min-width: 768px) {
	  .content-secondary {
	    float: left;
	    width: 33.33333333%;
	  }
	}

####HTML的部份...
	<div class="container">
		<div class="wrapper">
			<div class="content-main">
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
			<div class="content-secondary">
				<div class="box">
					<div class="box-heading">
						<img src="images/food_strawberry.jpg">
					</div>
					<div class="box-body">
						<h3>Strawberry</h3>
						<p>Por scientie, musica, sport etc. Li lingues differe solmen in li grammatica, li pro</p>
					</div>
				</div>
			</div>
		</div>
	</div>

####Demo
![Bootstrap Grid System](https://lh5.googleusercontent.com/-hsJ0BcKkQuc/VSOdd-9_vDI/AAAAAAAAGJA/NET7uMf4-pY/w800-h160-no/demo_1.png) 

可參考 [官方網站範例](http://getbootstrap.com/css/#grid-less) 

###範例4
除了使用`.make-row()`，也混合使用`.make-xs/sm/md/lg-column()`。

<!--
- `.make-row();`  
- `.make-xs/sm/md/lg-column();`
-->

####LESS的部份...

	.left-and-right {
	  .make-row();

	  .left {
	    .make-sm-column(1);
	    .make-md-column(7);
	    .make-lg-column(4);
	  }
	
	  .right {
	    .make-sm-column(11);
	    .make-md-column(5);
	    .make-lg-column(8);
	  }
	}

####輸出的CSS部份...
	.left-and-right {
	  margin-left: -15px;
	  margin-right: -15px;
	}
	.left-and-right .left {
	  position: relative;
	  min-height: 1px;
	  padding-left: 15px;
	  padding-right: 15px;
	}
	@media (min-width: 992px) {
	  .left-and-right .left {
	    float: left;
	    width: 50%;
	  }
	}
	.left-and-right .right {
	  position: relative;
	  min-height: 1px;
	  padding-left: 15px;
	  padding-right: 15px;
	}
	@media (min-width: 992px) {
	  .left-and-right .right {
	    float: left;
	    width: 50%;
	  }
	}
	.left-and-right {
	  margin-left: -15px;
	  margin-right: -15px;
	}
	.left-and-right .left {
	  position: relative;
	  min-height: 1px;
	  padding-left: 15px;
	  padding-right: 15px;
	}
	@media (min-width: 768px) {
	  .left-and-right .left {
	    float: left;
	    width: 16.66666667%;
	  }
	}
	@media (min-width: 992px) {
	  .left-and-right .left {
	    float: left;
	    width: 58.33333333%;
	  }
	}
	@media (min-width: 1200px) {
	  .left-and-right .left {
	    float: left;
	    width: 33.33333333%;
	  }
	}
	.left-and-right .right {
	  position: relative;
	  min-height: 1px;
	  padding-left: 15px;
	  padding-right: 15px;
	}
	@media (min-width: 768px) {
	  .left-and-right .right {
	    float: left;
	    width: 83.33333333%;
	  }
	}
	@media (min-width: 992px) {
	  .left-and-right .right {
	    float: left;
	    width: 41.66666667%;
	  }
	}
	@media (min-width: 1200px) {
	  .left-and-right .right {
	    float: left;
	    width: 66.66666667%;
	  }
	}

####HTML的部份...
	<div class="container">
		<div class="left-and-right">
			<div class="left">
				<div class="box">
					<div class="box-heading">
						<img src="images/food_bread.jpg">
					</div>
					<div class="box-body">
						<h3>Bread</h3>
						<p>Li Europan lingues es membres del sam familie. Lor separat existentie es un myth. </p>
					</div>
				</div>
			</div>
			<div class="right">
				<div class="box">
					<div class="box-heading">
						<img src="images/food_strawberry.jpg">
					</div>
					<div class="box-body">
						<h3>Strawberry</h3>
						<p>Por scientie, musica, sport etc. Por scientie, musica, sport etc. Por scientie, musica, sport etc. Por scientie, musica, sport etc. </p>
					</div>
				</div>
			</div>
		</div>
	</div>

####Demo
![Bootstrap Grid System](https://lh4.googleusercontent.com/-nhU6z2NuOGU/VSOdelk2RvI/AAAAAAAAGJA/wXxf5MAQRd4/w800-h475-no/demo_2.png)  

Note - [Mixins列表](http://bootstrapdocs.com/v3.0.3/docs/css/#grid-less)。

---
####推薦閱讀
#####Bootstrap Gripd System相關
- [Bootstrap 3 Grid Introduction | Experience Design at Hello Erik](http://www.helloerik.com/bootstrap-3-grid-introduction)
- [The Subtle Magic Behind Why the Bootstrap 3 Grid Works](http://www.helloerik.com/the-subtle-magic-behind-why-the-bootstrap-3-grid-works) - 將觀念清楚圖示
- [建立自己的Grid System](http://j4n.co/blog/Creating-your-own-css-grid-system)
#####Bootstrap Less Mixins and Variables相關
- [A Comprehensive Introduction to LESS: Mixins](http://www.sitepoint.com/a-comprehensive-introduction-to-less-mixins)
- [Bootstrap 3 Less Workflow Tutorial](http://www.helloerik.com/bootstrap-3-less-workflow-tutorial)
- [Using Bootstrap With LESS CSS – Tutorial](http://groupdocs.com/blog/using-bootstrap-with-less-css-tutorial)
- [5 Useful Sass Mixins in Bootstrap](http://www.sitepoint.com/5-useful-sass-mixins-bootstrap) - 常用的Mixins
- [Mixins列表](http://bootstrapdocs.com/v3.0.3/docs/css/#grid-less) - 官方教學
- [Twitter Bootstrap's Undocumented Mixins](http://ely-s.github.io/mixin/) - 其他可用的Mixins
#####Bootstrap版本相關
- [Bootstrap 2.x 與 3 的重要差異(一)：Overview | 烏托比亞](https://hsinyu00.wordpress.com/2013/08/28/bootstrap-2-to-3)
- [Bootstrap 2.x 與 3 的重要差異(二)：grid系統的變革 | 烏托比亞](https://hsinyu00.wordpress.com/2013/08/29/bootstrap-2-to-3-grid)
- [迷．夢: Bootstrap 3.0 (RC2) 過渡筆記](http://indreamhk.blogspot.tw/2013/06/bootstrap-3.html)
#####RWD觀念相關
- [Responsive Patterns - A collection of patterns and modules for responsive designs.](http://bradfrost.github.io/this-is-responsive/patterns.html)
- [行動網站開發：RWD實作心得01](http://luolala.gitbooks.io/mystudynote/content/MobileWebDev/note.html)
- [RWD(Responsive Web Design) 實作筆記](http://cythilya.blogspot.tw/2014/10/rwd.html) - 使用Media Query簡單做RWD網頁
- [使用Bootstrap建立一個RWD Template (Twitter Bootstrap in Responsive Web Design)](http://cythilya.blogspot.tw/2015/02/bootstrap-rwd-template.html) - 利用Bootstrap做RWD樣版，含Navbar、Jumbotrol、Grids、Panel、Forms、Wells、Footer，Viewport Meta Tag的注意事項與Mobile Search相關探討