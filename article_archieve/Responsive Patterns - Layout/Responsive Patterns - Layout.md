#Responsive Patterns - Layout

![Responsive Patterns - Layout](https://lh5.googleusercontent.com/-AdXc8xJsVdo/VTdQaMpLITI/AAAAAAAAGYQ/U6s7eIaUH-Y/w800-h494-no/responsive_patterns_layout_800.jpg)

[Responsive Patterns](http://bradfrost.github.io/this-is-responsive/patterns.html) 是一個蒐集響應式設計與實作的元件庫，舉凡Layout、Navigation、Forms、Carousel、Tabs、Accordion和Lightbox等皆有，很適合當成學習教材。先來玩玩Layout吧。我們分成幾大類：**Reflowing、Equal Width、Off Canvas、Source-Order Shift、Lists、Grid Block**。  
##Reflowing Layouts
###Mostly Fluid
多欄位呈現，在大銀幕上有大的margin，依賴fluid grid(流動網格)、flexible images來按銀幕比例縮放。當遇到小銀幕時，便將原先橫擺的column垂直擺放。  

![Responsive Patterns - Layout - Mostly Fluid](https://lh4.googleusercontent.com/-VFUOiGDFgO8/VSfkFPKI9_I/AAAAAAAAGNI/10vuPnDiFp8/w800-h288-no/mostly_fluid.png)  

寫法很簡單，指定銀幕寬度大過某個範圍時，放置左右兩欄(Desktop/Tablet)；否則(銀幕寬度小於特定範圍)都只是垂直擺放一欄(Mobile)。  

	//HTML
	<div class="pattern">
	  	<div class="container">
			<div class="main">
				<h2>Main Content (1st)</h2>
				<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent dictum odio eget mauris vestibulum feugiat. Praesent ante sapien, luctus pulvinar ultricies quis, aliquet in mi. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent dictum odio eget mauris vestibulum feugiat. Praesent ante sapien, luctus pulvinar ultricies quis, aliquet in mi.</p>
			</div>
			<div class="c2">
				<h3>Column (2nd)</h3>
				<p>Sed sit amet molestie diam. Etiam adipiscing dictum eros, vitae feugiat augue convallis sit amet. Nunc quis massa non dolor dictum condimentum.</p>
			</div>
			<div class="c3">
				<h3>Column (3rd)</h3>
				<p>Sed sit amet molestie diam. Etiam adipiscing dictum eros, vitae feugiat augue convallis sit amet. Nunc quis massa non dolor dictum condimentum.</p>
			</div>
		</div>
	</div>

	//CSS(SCSS)
	//預設垂直擺放一欄；銀幕寬度大過某個範圍時，放置左右兩欄
	@media screen and (min-width: 768px) {
		.container {
			.c2, .c3 {
		    	float: left;
		    	width: 50%;
		  	}
		}
	} 

#####[點此看Demo](http://codepen.io/cythilya/full/NPZaZj)
---
###Column Drop
多欄位的layout，銀幕大時，3個column平行排列；銀幕較小時，左邊sidebar移到頁面底端，只剩右邊sidebar；最後銀幕更小時，3個column垂直排列。

![Responsive Patterns - Layout - Column Drop](https://lh3.googleusercontent.com/-njQmLLoPxn8/VSo6A0BNf7I/AAAAAAAAGOc/w2jwF1kpzm8/w800-h287-no/column_drop.png)    

使用Media Query針對不同銀幕寬度將區塊做調整。在切版的歷程中我很少使用「clear」的指令，因此還特別查了該怎麼使用 [CSS clear Property](http://www.w3schools.com/cssref/pr_class_clear.asp)。　　

	@media screen and (min-width: 768px) {
		.container {
			.main {
				width: 75%;
				float: left;
			}
			.c2 {
				width: 25%;
				float: left;
		  	}
		  	.c3 {
		  		clear: both; /* 不允許左右兩邊有float element */
		  	}
		}
	} 

	@media screen and (min-width: 992px) {
		.container {
			.main{
				width: 50%;
				margin-left: 25%;
			}
			.c2 {
				margin-left: -75%; /* 使用負值將c2移到左側*/
		  	}
		  	.c3{
		  		clear: none; 
		  		/*
		  		允許左右兩邊皆有float element。
		  		不要使用「float: right;」使c3往右靠，
		  		因為container寬度不足容納三個區塊，c3會跑到右側底下。 
		  		*/
		  	}
		}
	}

#####[點此看Demo](http://codepen.io/cythilya/full/bNPQXK)
---
###Layout Shifter
![Responsive Patterns - Layout - Layout Shifter](https://lh3.googleusercontent.com/-cKYu_IbnuPY/VSo6M88Nh3I/AAAAAAAAGOw/dUQG4JWnKXI/w800-h287-no/layout_shifter.png)  

	@media screen and (min-width: 768px) {
		.container {
			.main {
				width: 30%;
				float: left;
			}
			.c2, .c3 {
				width: 70%;
				float: right;
		  	}
		}
	} 

######[點此看Demo](http://codepen.io/cythilya/full/NPZerE)
---
###Tiny Tweaks
單一Column，只是隨銀幕寬度調整標題與文字的大小與間距。  

![Responsive Patterns - Layout - Tiny Tweaks](https://lh4.googleusercontent.com/-UJwJ4Du_sZA/VSpEdJQ_CHI/AAAAAAAAGPI/i0hcrew1R-U/w800-h288-no/tiny_tweaks.png)

	//HTML
	<div class="pattern">
	  	<div class="container">
			<div class="main">
				<h2>Main Content (1st)</h2>
				<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent dictum odio eget mauris vestibulum feugiat. Praesent ante sapien, luctus pulvinar ultricies quis, aliquet in mi. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent dictum odio eget mauris vestibulum feugiat. Praesent ante sapien, luctus pulvinar ultricies quis, aliquet in mi.</p>
				<h3>Third-Level Heading</h3>
				<p>Sed sit amet molestie diam. Etiam adipiscing dictum eros, vitae feugiat augue convallis sit amet. Nunc quis massa non dolor dictum condimentum.</p>
				<h3>Third-Level Heading</h3>
				<p>Sed sit amet molestie diam. Etiam adipiscing dictum eros, vitae feugiat augue convallis sit amet. Nunc quis massa non dolor dictum condimentum.</p>
			</div>
		</div>
	</div>	

	//SCSS(CSS)
	.container {
		width: 960px;
		margin: 0 auto;
		.main{
			h2{
				font-size: 32px;
			}
			h3{
				font-size: 20px;	
			}
		}
	}

	@media screen and (min-width: 768px) {
		.container {
			.main {
				font-size: 120%;
				line-height: 1.5;
			}
		}
	} 

	@media screen and (min-width: 992px) {
		.container {
			.main{
			    font-size: 140%; 
			    line-height: 2;
			}
		}
	} 

#####[點此看Demo](http://codepen.io/cythilya/full/dPBwvR)
---
###Main Column with Sidebar
幾乎是最基本的排版方式 - 當銀幕夠寬時，側邊欄與主欄內容並排；當銀幕較小時，側邊欄在主欄之下。  

![Responsive Patterns - Layout - Main Column with Sidebar](https://lh6.googleusercontent.com/-gNp9yqUtvhw/VSvTfkNtc5I/AAAAAAAAGPo/bD5lBFbah-c/w800-h286-no/main_column_with_sidebar.png)

	@media screen and (min-width: 768px) {
		.container {
			.main {
				width: 66%;
				float: left;
			}
			.c2 {
				width: 34%;
				float: right;
		  	}
		}
	}

#####[點此看Demo](http://codepen.io/cythilya/full/xbvxdN)
---
###3 Column
三欄式排版，中間為主要內容的區塊，左右兩邊為sidebar。

![Responsive Patterns - Layout - 3 column](https://lh6.googleusercontent.com/-HfngEKNnRbA/VSza8-5wMsI/AAAAAAAAGQE/-TjwiyJJBo8/w800-h286-no/3_column.png)

	@media screen and (min-width: 768px) {
		.container {
			.main {
				width: 50%;
				float: left;
				margin-left: 25%;
			}
			.c2 {
				width: 25%;
				float: left;
				margin-left: -75%;
		  	}
		  	.c3 {
		  		width: 25%;
				float: right;
		  	}
		}
	} 

#####[點此看Demo 1](http://codepen.io/cythilya/full/KwOgvL)，[點此看Demo 2](http://codepen.io/bradfrost/full/joIac)
---
###3 Columns Content Reflow
三欄式排版。  

![Responsive Patterns - Layout - 3 Columns Content Reflow](https://lh3.googleusercontent.com/--PM4rz7yWLk/VTMttsQNEzI/AAAAAAAAGRk/HLKuLdsljPY/w800-h287-no/3_columns_content_reflow.png)

#####[Demo](http://codepen.io/cythilya/full/Xbrewz)，[Source Code](http://codepen.io/cythilya/pen/Xbrewz)
---
##Equal Width
###2 Equal-Width Columns
當銀幕較大時，可將區塊切分成2份(或3、4、5份等)；當銀幕較小時再分區段垂直擺放。

![Responsive Patterns - Layout - 2 Equal-Width Columns](https://lh3.googleusercontent.com/--LWXsoEVtnI/VTNQs8acvbI/AAAAAAAAGR8/TZyXLnWQLGE/w800-h289-no/2_equal_width_columns.png)

	//當銀幕較大時，可將區塊切分成2份；當銀幕較小時再分區段垂直擺放。
	@media screen and (min-width: 44em) {
	  .col-group > div {
	    float: left;
	    width: 50%;
	  }
	}

#####[點此看Demo](http://codepen.io/bradfrost/pen/tnhGv)

#####Note - 3 Equal-Width Columns、4 Equal-Width Columns和5 Equal-Width Columns實作方式與以上類似  
- [Demo - 3 Equal-Width Columns](http://codepen.io/bradfrost/full/orKvD)  
- [Demo - 4 Equal-Width Columns](http://codepen.io/bradfrost/full/pwmHf)  
- [Demo - 5 Equal-Width Columns](http://codepen.io/bradfrost/full/rjfta)  
 
---
##Off Canvas
###Top
在核心內容之上可放置導行列或其他內容，不需要的時候可以隱藏以節省空間。

![Responsive Patterns - Layout - Off Canvas - Top](https://lh3.googleusercontent.com/-4v4lN9foH-c/VTNtIeHeIMI/AAAAAAAAGSU/hXaMrluKd54/w659-h210-no/of_canvas_top.gif)  

####優點
- 節省空間，上方可放置更多內容(例如：Navigation、Breadcrumb)，在不需要使用時候隱藏起來。
- 畫面動作優雅。
####缺點
- 需要JavaScript實作區塊顯示/隱藏的效果。
- 實作於手機平台需要注意動畫效果的效能。

#####[點此看Demo](http://codepen.io/cythilya/full/vOBWRE)
---
###Left
左邊有側邊欄，若銀幕夠大則顯示在畫面上；若銀幕較小則收納在左側。

An off-canvas layout that tucks a left sidebar away for small screens but exposes it once enough screen space becomes available.

![Responsive Patterns - Layout - Off Canvas - Left](https://lh6.googleusercontent.com/-9oy2Fl8yPC4/VTOABrRS25I/AAAAAAAAGSw/C1rOwmlGtmc/w800-h286-no/off_canvas_left.png)  

#####[點此看Demo](http://codepen.io/cythilya/full/qdWVwe)
---
###Right
與「Off Canvas - Left」類似，只是將`float:left;`換成`float:right;`或絕對位置由left改為right。

![Responsive Patterns - Layout - Off Canvas - Right](https://lh6.googleusercontent.com/-9oy2Fl8yPC4/VTOABrRS25I/AAAAAAAAGSw/C1rOwmlGtmc/w800-h286-no/off_canvas_left.png) 

#####[點此看Demo](http://codepen.io/cythilya/full/NqKLmE)
---
###Full Screen Overlay
上方的Menu可隱藏於可視範圍之外，以適用於小尺寸的銀幕。

![Off Canvas - Full Screen Overlay](https://lh6.googleusercontent.com/-iCOIzqb9I6E/VTUN40p8Z8I/AAAAAAAAGUY/TLhjcFnXirA/w389-h309-no/off_canvas_full_screen_overlay.gif)  

#####[點此看Demo](http://codepen.io/cythilya/full/JdPeKa) - 這個範例有針對js停用的狀況做處理噢！
---
#####Related Articles - Off Canvas
- [Off Canvas Multi-Device Layout](http://www.lukew.com/ff/entry.asp?1517)
- [Off Canvas Multi-Device Layouts](http://www.lukew.com/ff/entry.asp?1569)
- [A Multi-Device Web Layout Pattern](http://jasonweaver.name/lab/offcanvas/)
- [Off Canvas Layouts](http://zurb.com/playground/off-canvas-layouts)

---
##Source-Order Shift
###Table Cell
利用Table的屬性改變元素的位置。如下範例程式碼，當銀幕寬度小於640px時，將原先在底下的`.nav`區塊利用`display: table-caption;`移到畫面上方。    

	@media all and (min-width: 640px){
		.t{
			display: table;
			caption-side: top;
			width: 100%;
		}
		.nav{
			display: table-caption;
			ol{
				display: table-row;
				li{
					display: inline-block;;
					margin-right: 10px;
				}
			}
		}
	}

![Responsive Patterns - Layout - Source-Order Shift - Table Cell](https://lh3.googleusercontent.com/-9hDyYsgOkK0/VTYc4thJPHI/AAAAAAAAGWA/QIaWdgO3E4Q/w800-h287-no/source_order_shift_table_cell.png)  

#####[點此看Demo](http://codepen.io/cythilya/full/rVBXqB)
---
##Lists
###List with Thumbnails
利用`<table>`的特性排列格狀物件。

![Responsive Patterns - List with Thumbnails](https://lh3.googleusercontent.com/-pGNcN1Qm0l4/VTcUu40WTSI/AAAAAAAAGWY/ZCNk4rD7Tqc/w800-h287-no/list_with_thumbnails.png)  

	//利用`<table>`的特性排列格狀物件
	.list_with_thumbnails{
		.list{
			.item{
				background: #eee;
				border-bottom: 1px solid #ccc;
				display: table;
				border-collapse: collapse;
				.item-image{
					display: table-cell;
					vertical-align: middle;
					width: 30%;
					padding-right: 1em;
					.thumbnail{
						display: block;
						width: 100%;
					}
				}
				.item-text{
					display: table-cell;
					vertical-align: middle;
					width: 70%;
				}
			}
		}
	}
	
	//根據銀幕大小調整元件比例
	@media all and (min-width: 45em) {
		.list{
	  		.item{
		    	float: left;
		    	width: 50%;
	  		}
	  	}
	}
	
	@media all and (min-width: 75em) {
		.list{
	  		.item{
		    	width: 33.33333%;
	  		}
	  	}
	}


#####[點此看Demo 1](http://codepen.io/cythilya/full/doyXog)，[點此看Demo 2](http://codepen.io/cythilya/full/LVYZWX)，[點此看Demo 3(小銀幕時隱藏部份內容)](http://codepen.io/bradfrost/full/ykalp)

#####Related Articles
- [THE MEDIA OBJECT SAVES HUNDREDS OF LINES OF CODE](http://www.stubbornella.org/content/2010/06/25/the-media-object-saves-hundreds-of-lines-of-code)

---
##Grid Block
###4-Up Grid Block
在銀幕寬度許可下，一列呈現四個物件；銀幕較小的狀況下，垂直排列一列放2個或1個物件。  

![Responsive Patterns - 4-Up Grid Block](https://lh3.googleusercontent.com/-8kkAhqdhG_s/VTdKBXcaw-I/AAAAAAAAGW0/fDVGGD6Ws04/w800-h287-no/4_up_grid_block.png)  

物件也可以有不同的寬度，例如物件#2。  

![Responsive Patterns - 4-Up Grid Block - Wide](https://lh4.googleusercontent.com/--pVdD4UeAzY/VTdMl9HKuOI/AAAAAAAAGXU/JTHizAvySw4/w800-h497-no/4_up_grid_block_wide.png)  

	//在不同銀幕大小下調整物件的寬度
	@media all and (min-width: 27em) {
		.grid{
			li{
				width: 50%;
				float: left;
			}
		}
	}

	@media all and (min-width: 40em) {
		.grid{
			li{
				width: 33.3333333%;
				&.wide{
					width: 66.666666%;	
				}
			}
		}
	}

	@media all and (min-width: 60em) {
		.grid{
		 	li {
				width: 25%;
				&.wide{
					width: 50%;
				}
			}
		}
	}

#####[點此看Demo 1](http://codepen.io/cythilya/full/VLwKYY),[點此看Demo 2](http://codepen.io/bradfrost/full/lpnqC)，[點此看Demo ３](http://codepen.io/bradfrost/full/GrFnj)，[點此看Demo ４](http://codepen.io/bradfrost/full/Dybsz)，[點此看Demo 5](http://codepen.io/bradfrost/full/GFHmf)，[點此看Demo 6](http://codepen.io/micahgodbolt/full/FgqLc)

---
看到這裡的時候剛好朋友在討論Layout Patterns何其多，為何使用Grid System排版？遇到複雜的版面的時候，使用Media Query一個區塊一個區塊調整是辛苦且不容易Debug的，如果可以有系統的規劃版面與實作真是可以節省時間和精力。

---
####推薦閱讀
- [Responsive Web Design Patterns | This Is Responsive](http://bradfrost.github.io)
- [Multi-Device Layout Patterns](http://www.lukew.com/ff/entry.asp?1514)
- Off Canvas 
	- [Off Canvas Multi-Device Layout](http://www.lukew.com/ff/entry.asp?1517)
	- [Off Canvas Multi-Device Layouts](http://www.lukew.com/ff/entry.asp?1569)
	- [A Multi-Device Web Layout Pattern](http://jasonweaver.name/lab/offcanvas/)
	- [Off Canvas Layouts](http://zurb.com/playground/off-canvas-layouts)
- List with Thumbnails
	- [THE MEDIA OBJECT SAVES HUNDREDS OF LINES OF CODE](http://www.stubbornella.org/content/2010/06/25/the-media-object-saves-hundreds-of-lines-of-code)