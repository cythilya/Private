var SP = {};
SP.module = {
    version: '0.1',
    namespace: function(ns_string){
        var parts = ns_string.split('.'),
            parent = SP,
            i;
        if (parts[0] === 'SP'){
            parts = parts.slice(1);
        }
        for (i = 0; i < parts.length; i += 1){
            if (typeof parent[parts[i]] === 'undefined') {
                parent[parts[i]] = {};
            }
            parent = parent[parts[i]];
        }
        return parent;
    },
    inherit: function(Child, Parent){
        Child.prototype = new Parent();
    },
    areaCarousel: function(dModule){
        var dModule = $(dModule),
            dSwipeSlider = dModule.find('#swipeSlider'),
            dTabList = dModule.find('.tabList');

        dSwipeSlider.slick({
            dots: true,
            adaptiveHeight: true,
            mobileFirst: true,
            slidesToShow: 1,
            slidesToScroll: 1,
            autoplay: false,
            responsive: [
                {
                  breakpoint: 1200,
                  settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3,
                    infinite: true,
                    dots: true
                  }
                },
                {
                  breakpoint: 992,
                  settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3
                  }
                },
                {
                  breakpoint: 768,
                  settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                  }
                }    
            ]   
        });
    },
    areaSelectOptions: function(dModule){
        var dModule = $(dModule),
            dSelector = dModule.find('#selector')
            dSelectFrame = dModule.find('.selectList'),
            dPageContainer = dModule.find('#pageContainer'),
            dSelectItem = dModule.find('.selectItem'),
            dActivityList = dModule.find('.activityList'),
            dLoadingImg = dModule.find('.js-loadingImg'),
            focusItemNumber = dModule.find('.focus').data('number'),
            lock = false, //是否可接受點擊來移動
            maxItemNumer = dModule.find('.selectItem').length || 0,
            config = {
                speed: 500,
                width: $(window).innerWidth()/3,
                itemNumber: dModule.find('.selectList .selectItem').length
            };

        //計算中央位置，放置focus item
        function moveCenter(){
            var totalWidth = $(window).innerWidth(),
                visibleItemNumber,
                start;

            config.width = $(window).innerWidth()/3; //calculate item width
            visibleItemNumber = totalWidth / config.width; //calculate visible number
            start = -((focusItemNumber - Math.ceil(visibleItemNumber/2)) * config.width); //calculate start position
            dModule.find('.selectList').width((config.width+1) * config.itemNumber + 1); //set list's width
            dModule.find('.selectLink').css('width', config.width + 'px'); //set item's width
            //dSelectFrame.css('left', start + 'px'); //move center
            dLoadingImg.css('left', ($(window).innerWidth()-40)/2 + 'px'); //move center
            dSelector.scrollLeft(-start);
        };    

        //當做左右移動動作的時候，皆不可再點擊來移動
        function setItemsDisabled(){
            lock = true;
        };

        //左右移動動作完成，可再接受點擊來移動
        function unsetItemsDisabled(){
            lock = false;
        };

        //決定移動方向(左/右)、是否到邊界值(到邊界值不可移動)
        function move(number, thisNumber){
            var num = thisNumber; //正數左移，負數右移
            setCurrentItem(num);
            unsetItemsDisabled(); //左右移動動作完成，可再接受點擊來移動
            getActivity(num);
        }; 

        //set current item
        function setCurrentItem(thisNumber){
            var dCurrentItem = dModule.find('.focus'),
                currentNumber = dCurrentItem.data('number'),
                thisItemNumber = thisNumber;

            if(focusItemNumber > 0 && focusItemNumber <= maxItemNumer){
                dModule.find('.selectItem').removeClass('focus');
                dModule.find('.selectItem').eq(thisItemNumber - 1).addClass('focus');
                focusItemNumber = thisItemNumber; //reset focus number
            }
        };

        //get activities on current month
        function getActivity(number){
            var formDataArray = [];
            var panelNum = number;
            var dCurrentActivityBlock = dActivityList.find('.activityBlock').eq(panelNum-1);
            var randomPhoto = 'css/dummy_230x185_' + Math.floor((Math.random() * 3) + 1) +'.jpg'; //fake data
            var randomNum = Math.floor((Math.random() * 100) + 1);

            if(!dCurrentActivityBlock.hasClass('ready')){
                startLoading();

                //fake ajax
                $.ajax.fake.registerWebservice('/GetActivity', function(data) {
                    return {
                        "success": true,
                        "data" : [
                            {
                                "ID": 999,
                                "title": "宜蘭太平山自行車挑戰" + randomNum,
                                "link": "http://www.google.com.tw",
                                "thumbnail": randomPhoto,
                                "date": "2015/06/06 (六)",
                                "startDate": "2015-06-06",
                                "location": "新北市政府行市民廣場",
                            },
                            {
                                "ID": 999,
                                "title": "宜蘭太平山自行車挑戰" + randomNum,
                                "link": "http://www.google.com.tw",
                                "thumbnail": randomPhoto,
                                "date": "2015/06/06 (六)",
                                "startDate": "2015-06-06",
                                "location": "新北市政府行市民廣場"
                            },
                            {
                                "ID": 999,
                                "title": "宜蘭太平山自行車挑戰" + randomNum,
                                "link": "http://www.google.com.tw",
                                "thumbnail": randomPhoto,
                                "date": "2015/06/06 (六)",
                                "startDate": "2015-06-06",
                                "location": "新北市政府行市民廣場"
                            }
                        ],
                        "message": "success!"
                    }
                });    

                $.ajax({
                    url: '/GetActivity',
                    type: 'post',
                    fake: true, //fake ajax
                    data: JSON.stringify({
                        "Data": formDataArray
                    }),
                    dataType: 'json',
                    error: function (xhr) {
                        alert('噢噢！發生錯誤了！請重新再試一次～');
                    },
                    success: function (response) {
                        var HTML = '';
                        var HTMLResult = '';
                        var dataList = {};

                        if(response.success && response.data){
                            dataList = response.data;
                            $.each(dataList, function(index, value){
                                var dataObj = {
                                    ID: value.ID,
                                    Name:　value.title,
                                    Thumbnail: value.thumbnail,
                                    URL: value.link
                                };
                                var dataString = JSON.stringify(dataObj);
                                HTML += [
                                    '<div class="activityItem browserItem" itemscope itemtype="http://schema.org/Article" data-item=' + dataString + '>',
                                    '    <div class="actImg"><a href="' + value.link + '" target="_blank" title="' + value.title + '"><img class="thumbnail" src="' + value.thumbnail + '" title="' + value.title + '" alt="' + value.title + '" itemprop="image"></a></div>',
                                    '    <h3 class="actTitle" itemprop="name">' + value.title + '</h3>',
                                    '    <div class="actDescription" itemprop="description">' + value.date + ' / ' + value.location + '</div>',
                                    '</div>'
                                ].join(''); 
                            });
                            HTMLResult= HTMLResult + HTML;
                            dCurrentActivityBlock.append(HTML)
                            dActivityList.find('.activityBlock').removeClass('focus');
                            dCurrentActivityBlock.addClass('ready');
                            dCurrentActivityBlock.addClass('focus');
                        }
                        else{
                            alert('噢噢！發生錯誤了！請重新再試一次～');
                        }
                    },
                    complete: function(){
                        endLoading();
                    }                
                });               
            } else {
                dActivityList.find('.activityBlock').removeClass('focus');
                dCurrentActivityBlock.addClass('ready');
                dCurrentActivityBlock.addClass('focus');
            }
        };

        function startLoading(parameters) {
            dLoadingImg.addClass('on');
        }        

        function endLoading(parameters) {
            dLoadingImg.removeClass('on');
        }          

        dSelectItem.click(function(){
            var dThisItem = $(this); //點擊項目
            var thisNumber = dThisItem.data('number'); //點擊項目的月份#
            var dis = thisNumber - focusItemNumber; //點擊項目的月份#與focus item #的差距

            //可接受點擊來移動
            if(!lock){
                setItemsDisabled(); //不可接受點擊來移動
                if(dis !== 0){
                    //點擊項目和focus item不相同，需要移動
                    move(dis, thisNumber); 

                    //重新設定focus項目
                    dModule.find('.selectItem').removeClass('focus');
                    dModule.find('.selectItem').eq(dThisItem.data('number')-1).addClass('focus');
                }
                else{
                    //點擊項目和focus item相同，不移動
                    unsetItemsDisabled();
                }
            }
        });

        $(document).ready(function() {
             $(window).resize(function(){
                if($(window).innerWidth()>$(window).innerHeight()){
                    //橫 
                    moveCenter();
                }else{
                    //直
                    moveCenter();
                } 
             }).resize();
        });   

        //load more
        $(document).ready(function(){
            function lastAddedLiveFunc() {
                var formDataArray = [];
                var panelNum = focusItemNumber;
                var dCurrentActivityBlock = dActivityList.find('.activityBlock').eq(panelNum-1);
                var randomPhoto = 'css/dummy_230x185_' + Math.floor((Math.random() * 3) + 1) +'.jpg'; //fake data
                var randomNum = Math.floor((Math.random() * 100) + 1);

                $('div#lastPostsLoader').html('<div class="icon-spinner3 waitActivity"></div>');
         
                //fake ajax
                $.ajax.fake.registerWebservice('/GetActivity?id=' + panelNum, function(data) {
                    return {
                        "success": true,
                        "data" : [
                            {
                                "ID" : 999,
                                "title": "宜蘭太平山自行車挑戰" + randomNum,
                                "link": "http://www.google.com.tw",
                                "thumbnail": randomPhoto,
                                "date": "2015/06/06 (六)",
                                "startDate": "2015-06-06",
                                "location": "新北市政府行市民廣場"
                            },
                            {
                                "ID" : 999,
                                "title": "宜蘭太平山自行車挑戰" + randomNum,
                                "link": "http://www.google.com.tw",
                                "thumbnail": randomPhoto,
                                "date": "2015/06/06 (六)",
                                "startDate": "2015-06-06",
                                "location": "新北市政府行市民廣場"
                            },
                            {
                                "ID" : 999,
                                "title": "宜蘭太平山自行車挑戰" + randomNum,
                                "link": "http://www.google.com.tw",
                                "thumbnail": randomPhoto,
                                "date": "2015/06/06 (六)",
                                "startDate": "2015-06-06",
                                "location": "新北市政府行市民廣場"
                            },
                            {
                                "ID" : 999,
                                "title": "宜蘭太平山自行車挑戰" + randomNum,
                                "link": "http://www.google.com.tw",
                                "thumbnail": randomPhoto,
                                "date": "2015/06/06 (六)",
                                "startDate": "2015-06-06",
                                "location": "新北市政府行市民廣場"
                            }                                                                                    
                        ],
                        "message": "success!"
                    }
                }); 

                $.ajax({
                    url: '/GetActivity?id=' + panelNum,
                    type: 'post',
                    fake: true, //fake ajax
                    data: JSON.stringify({
                        "Data": formDataArray
                    }),
                    dataType: 'json',
                    error: function (xhr) {
                        alert('噢噢！發生錯誤了！請重新再試一次～');
                    },
                    success: function (response) {
                        var HTML = '';
                        var HTMLResult = '';
                        var dataList = {};

                        if(response.success && response.data){
                            dataList = response.data;
                            $.each(dataList, function(index, value){
                                var dataObj = {
                                    ID: value.ID,
                                    Name:　value.title,
                                    Thumbnail: value.thumbnail,
                                    URL: value.link
                                };
                                var dataString = JSON.stringify(dataObj);
                                HTML += [
                                    '<div class="activityItem browserItem" itemscope itemtype="http://schema.org/Article" data-item=' + dataString + '>',
                                    '    <div class="actImg"><a href="' + value.link + '" target="_blank" title="' + value.title + '"><img class="thumbnail" src="' + value.thumbnail + '" title="' + value.title + '" alt="' + value.title + '" itemprop="image"></a></div>',
                                    '    <h3 class="actTitle" itemprop="name">' + value.title + '</h3>',
                                    '    <div class="actDescription" itemprop="description">' + value.date + ' / ' + value.location + '</div>',
                                    '</div>'
                                ].join(''); 
                            });
                            HTMLResult= HTMLResult + HTML;
                            dCurrentActivityBlock.append(HTML)
                        }
                        else{
                            alert('噢噢！發生錯誤了！請重新再試一次～');
                        }
                    },
                    complete: function(){
                        $('div#lastPostsLoader').empty();
                    }       
                }); 
            };
         
            $(window).scroll(function(){
                var wintop = $(window).scrollTop(), docheight = $(document).height(), winheight = $(window).height();
                var scrolltrigger = 0.5;
         
                if((wintop/(docheight-winheight)) > scrolltrigger) {
                    lastAddedLiveFunc();
                }
            });
        });

        //init
        moveCenter();
    },
    goTop: function(dModule){
        var dModule = $(dModule);

        $(window).scroll(function(){
            var dWindow = $(this);
            if((dWindow).scrollTop() > 100){
                dModule.fadeIn();
            }
            else{
                dModule.fadeOut();
            }
        });

        dModule.click(function(e){
            e.preventDefault();
            var $body = (window.opera) ? (document.compatMode == "CSS1Compat" ? $('html') : $('body')) : $('html,body');
            $body.animate({
                scrollTop: 0
            }, 1000 );
        });
    },
    pageMainContainer: function(dModule){
        var dModule = $(dModule);

       //load more
        $(document).ready(function(){
            function lastAddedLiveFunc() {
                var formDataArray = [];
                var dCurrentActivityBlock = dModule.find('.activityBlock.focus');
                var randomPhoto = 'css/dummy_230x185_' + Math.floor((Math.random() * 3) + 1) +'.jpg'; //fake data
                var randomNum = Math.floor((Math.random() * 100) + 1);

                $('div#lastPostsLoader').html('<div class="icon-spinner3 waitActivity"></div>');
         
                //fake ajax
                $.ajax.fake.registerWebservice('/GetActivity', function(data) {
                    return {
                        "success": true,
                        "data" : [
                            {
                                "ID": 888,
                                "title": "宜蘭太平山自行車挑戰" + randomNum,
                                "link": "http://www.google.com.tw",
                                "thumbnail": randomPhoto,
                                "date": "2015/06/06 (六)",
                                "startDate": "2015-06-06",
                                "location": "新北市政府行市民廣場"
                            },
                            {
                                "ID": 888,
                                "title": "宜蘭太平山自行車挑戰" + randomNum,
                                "link": "http://www.google.com.tw",
                                "thumbnail": randomPhoto,
                                "date": "2015/06/06 (六)",
                                "startDate": "2015-06-06",
                                "location": "新北市政府行市民廣場"
                            },
                            {
                                "ID": 888,
                                "title": "宜蘭太平山自行車挑戰" + randomNum,
                                "link": "http://www.google.com.tw",
                                "thumbnail": randomPhoto,
                                "date": "2015/06/06 (六)",
                                "startDate": "2015-06-06",
                                "location": "新北市政府行市民廣場"
                            },
                            {
                                "ID": 888,
                                "title": "宜蘭太平山自行車挑戰" + randomNum,
                                "link": "http://www.google.com.tw",
                                "thumbnail": randomPhoto,
                                "date": "2015/06/06 (六)",
                                "startDate": "2015-06-06",
                                "location": "新北市政府行市民廣場"
                            } 
                        ],
                        "message": "success!"
                    } 
                }); 

                $.ajax({
                    url: '/GetActivity',
                    type: 'post',
                    fake: true, //fake ajax
                    data: JSON.stringify({
                        "Data": formDataArray
                    }),
                    dataType: 'json',
                    error: function (xhr) {
                        alert('噢噢！發生錯誤了！請重新再試一次～');
                    },
                    success: function (response) {
                        var HTML = '';
                        var HTMLResult = '';
                        var dataList = {};
                        if(response.success && response.data){
                            dataList = response.data;
                            $.each(dataList, function(index, value){
                                var dataObj = {
                                    ID: value.ID,
                                    Name:　value.title,
                                    Thumbnail: value.thumbnail,
                                    URL: value.link
                                };
                                var dataString = JSON.stringify(dataObj);
                                HTML += [
                                    '<div class="activityItem browserItem" itemscope itemtype="http://schema.org/Article" data-item=' + dataString + '>',
                                    '    <div class="actImg"><a href="' + value.link + '" target="_blank" title="' + value.title + '"><img class="thumbnail" src="' + value.thumbnail + '" title="' + value.title + '" alt="' + value.title + '" itemprop="image"></a></div>',
                                    '    <h3 class="actTitle" itemprop="name">' + value.title + '</h3>',
                                    '    <div class="actDescription" itemprop="description">' + value.date + ' / ' + value.location + '</div>',
                                    '</div>'
                                ].join(''); 
                            });
                            HTMLResult= HTMLResult + HTML;
                            dCurrentActivityBlock.append(HTML)
                            $('div#lastPostsLoader').empty();
                        }
                        else{
                            alert('噢噢！發生錯誤了！請重新再試一次～');
                        }
                    }              
                }); 
            };
         
            $(window).scroll(function(){
                var wintop = $(window).scrollTop(), docheight = $(document).height(), winheight = $(window).height();
                var scrolltrigger = 0.5;
         
                if((wintop/(docheight-winheight)) > scrolltrigger) {
                    lastAddedLiveFunc();
                }
            });
        });        
    },
    loginArea: function(dModule){
        var dModule = $(dModule);
        var dForm = dModule.find('.formLogin');
        var dBtnLogin = dModule.find('.btnLogin');

        dForm.validationEngine('attach', {
            promptPosition : "bottomLeft", 
            scroll: false
        });
        
        dBtnLogin.click(function(e){
            var dThisBtn = $(this);
            var result =  dForm.validationEngine('validate');
            
            e.preventDefault();
            if(result){
                if (!dThisBtn.hasClass('disabled')) {
                     dThisBtn.addClass('disabled');

                    $.ajax({
                        url: '',
                        type: 'post',
                        data: {},
                        dataType: 'json',
                        error: function (xhr) {
                            alert('登入失敗');
                        },
                        success: function (response) {
                            alert('登入成功');
                        },
                        complete: function(){
                            dThisBtn.removeClass('disabled');
                        }
                    });
                }
            }
        });       
    },
    registerArea: function(dModule){
        var dModule = $(dModule);
        var dForm = dModule.find('.formLogin');
        var dBtnRegister = dModule.find('.btnRegister');

        dForm.validationEngine('attach', {
            promptPosition : "bottomLeft", 
            scroll: false
        });
        
        dBtnRegister.click(function(e){
            var dThisBtn = $(this);
            var result =  dForm.validationEngine('validate');
            
            e.preventDefault();
            if(result){
                if (!dThisBtn.hasClass('disabled')) {
                     dThisBtn.addClass('disabled');

                    $.ajax({
                        url: '',
                        type: 'post',
                        data: {},
                        dataType: 'json',
                        error: function (xhr) {
                            alert('登入失敗');
                        },
                        success: function (response) {
                            alert('登入成功');
                            location.href = 'confirm.html';
                        },
                        complete: function(){
                            dThisBtn.removeClass('disabled');
                        }
                    });
                }
            }
        });       
    }    
};
(function(){
    var doWhileExist = function(ModuleID,objFunction){
        var dTarget = document.getElementById(ModuleID);
        if(dTarget){
            objFunction(dTarget);
        }                
    };
    doWhileExist('areaCarousel',SP.module.areaCarousel);
    doWhileExist('areaSelectOptions',SP.module.areaSelectOptions);
    doWhileExist('goTop',SP.module.goTop);
    doWhileExist('pageMainContainer',SP.module.pageMainContainer);
    doWhileExist('loginArea',SP.module.loginArea);
    doWhileExist('registerArea',SP.module.registerArea);
})();