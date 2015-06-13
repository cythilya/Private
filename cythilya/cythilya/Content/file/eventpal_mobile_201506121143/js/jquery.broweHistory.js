(function($) {
	$.fn.browseHistoryList = function(opts) {
		// default configuration
		var config = $.extend({}, {
			historyInitDisplayNumber: 4,
			historySaveMaxNumber: 20,
			isExpandHistoryList: false
		}, opts);
		// main function
		function init(obj) {
			var dModule = $(obj),
	            dMoreBtn = dModule.find('.more'),
	            dNoMoreBtn = dModule.find('.noMoreBrowseHistory'),
	            dHistoryArea = dModule.find('.areaHistory'),
	        	dRecentlyHistoryArea = dHistoryArea.find('.recentlyViewActivity'),
	            activityList = [],
	            reverseList = []; //reverse activity list
	           
			//設定localStorage
	        function setObj (key, obj) {
	            return localStorage.setItem(key, JSON.stringify(obj));
	        };

	        //取得localStorage
	        function getObj (key) {
	            return JSON.parse(localStorage.getItem(key));
	        };

	        //更新瀏覽紀錄
	        function refreshHistoryList(){
	        	var  ResultHTML = ''; // 更新後，append到畫面上的歷史紀錄

	        	dRecentlyHistoryArea.html(''); //清除先前在畫面上的資料
		        activityList = JSON.parse(getObj('browseHistory')) || []; //取得目前localStorage的瀏覽紀錄

	            if(activityList.length != 0){
	                $.each(activityList, function(index, value){
	                    var item = activityList.pop();
	                    reverseList.push(item);
	                });

	                $.each(reverseList, function(index, value){
	                    if(index < config.historyInitDisplayNumber){
	                        var HTML = '';
	                        HTML += [
	                            '<div class="item">',
	                            '   <div class="itemImage">',
	                            '        <a href="' + value.URL + '" class="itemLink">',
	                            '            <img class="thumbnail" src="' + value.Thumbnail + '" alt="' + value.Name + '">',
	                            '        </a>',
	                            '    </div>',
	                            '    <div class="itemName">',
	                            '        <a href="#' + value.URL + '" class="itemLink">' + value.Name + '</a>',
	                            '    </div>',
	                            '</div>'
	                        ].join('');  
	                        ResultHTML = ResultHTML + HTML;
	                    }
	                    else{
	                        return;
	                    }
	                });
	                
	                for(var i = 0; i < 4; i++){
	                    reverseList.shift(); //移除清單上已顯示的項目
	                }
	                
	                dHistoryArea.find('.recentlyViewActivity').append(ResultHTML);
	                dHistoryArea.show(); //顯示最近瀏覽過的活動

	                if(reverseList.length > 0){
	                    dMoreBtn.show();
	                }
	            }
	        };

	        //點擊活動，將活動加入歷史紀錄列表
	        dModule.on('click', '.browserItem', function(){
	            var dThisItem = $(this),
	                itemDataObj = dThisItem.data('item'),
	                activityList = [],
	                newActivityList = [];

	            activityList = JSON.parse(getObj('browseHistory')) || [];
	            if(activityList != null && activityList != []){
	                $.each(activityList, function(index, value){
	                    if(value.ID !== itemDataObj.ID){
	                        newActivityList.push(value);
	                    }
	                });
	            }
	            newActivityList.push(itemDataObj);
	            setObj('browseHistory', JSON.stringify(newActivityList));

	            console.log(activityList);
	        });

	        //展開紀錄
	        dMoreBtn.click(function(e){
	        	var resultMoreHTML = '';
	            e.preventDefault();
	            if(reverseList.length != 0){
	                for(var i = 0; i < 4; i++){
	                    var popupItem = reverseList.shift(0,1);
	                    if(popupItem != null){
	                        var HTML = '';
	                         HTML += [
	                            '<div class="item">',
	                            '   <div class="itemImage">',
	                            '        <a href="' + popupItem.URL + '" class="itemLink">',
	                            '            <img class="thumbnail" src="' + popupItem.Thumbnail + '" alt="' + popupItem.Name + '">',
	                            '        </a>',
	                            '    </div>',
	                            '    <div class="itemName">',
	                            '        <a href="#' + popupItem.URL + '" class="itemLink">' + popupItem.Name + '</a>',
	                            '    </div>',
	                            '</div>'
	                        ].join('');
	                        resultMoreHTML = resultMoreHTML + HTML;                  
	                    }
	                }
	                dHistoryArea.find('.recentlyViewActivity').append(resultMoreHTML);                
	            }
	            else{
	                dMoreBtn.hide();
	                dNoMoreBtn.show();                 
	            }
	        });	

	        refreshHistoryList();
        }
		// initialize every element
		this.each(function() {
			init($(this));
		});
		return this;
	};
	// start
	$(function() {
		if(typeof(Storage) !== "undefined") {
			$('.EventPalMobile').browseHistoryList();
		}
	});
})(jQuery);