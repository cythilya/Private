(function($) {
	$.fn.d3SimpleBarChart = function(opts) {
		// default configuration
		var config = $.extend({}, {
			opt1: null
		}, opts);
		// main function
		function init(obj) {
			function draw(data) {
				d3.select('.barChart') //選擇放在barChart這個div容器裡面
				.selectAll('div') //選取".barChart"範圍內的所有的div
				.data(data) //將資料加入div
				.enter() //傳入資料
				.append('div') //放到畫面上
				.attr('class','item clearfix') //將剛剛放到畫面上的div，加上class "item"
				.text(function(d){return d.text}) //加上文字描述，使用json檔案裡面的 "text" 欄位
				.append('div') //加入包含資料的div，這個div是用來畫圖用的
				.text(function (data) {
					return data.count; //畫圖用div加上文字描述，使用json檔案裡面的 "count" 欄位
				})			
				.attr('class','bar') //畫圖用div加上class "bar"
				.style('width', function(d){ //將剛剛對每個畫圖用div設定寬度，這裡將取出的count值乘以15，即為顯示在畫面上的px數
					return (d.count*15)  + 'px'
				});
			};
			
			//Mockup JSON，使用JSON Generator http://www.json-generator.com
			//資料載入完畢後會call "draw" 這個callback function
			d3.json('http://www.json-generator.com/api/json/get/bTGclonYia?indent=2', draw); //Mockup
		}
		// initialize every element
		this.each(function() {
			init($(this));
		});
		return this;
	};
	// start
	$(function() {
		$('.barChart').d3SimpleBarChart();
	});
})(jQuery);
