window.ProductList = Ember.Application.create();

ProductList.ApplicationAdapter = DS.FixtureAdapter.extend();

ProductList.Router.map(function () {
	this.resource('productlist', { path: '/' }, function () {
		this.route('hot');
	});
});

ProductList.ProductListIndexRoute = Ember.Route.extend({
	model: function () {
		return this.modelFor('productlist');
	}
});

ProductList.ProductListHotRoute = Ember.Route.extend({
	model: function(){
		return this.store.filter('product', function (product) {
	  		return product.get('isHot');
		});
	},
	renderTemplate: function(controller){
		this.render('productlist/index', {controller: controller});
	}
});

ProductList.Product = DS.Model.extend({
	no: DS.attr('number'),
	cover: DS.attr('string'),
	name: DS.attr('string'),
	category: DS.attr('string'),
	status: DS.attr('string')
});

ProductList.Route = Ember.Route.extend({
	model: function(){
		return this.store.find('product');
	}
});

ProductList.Product.FIXTURES = [
	{
		id: 1,
		no: 3501,
		cover: "http://friendoprod.blob.core.windows.net/missionpics/images/main/240b0e00-72f7-4cca-a5ef-dbd4646efc2d.gif",
		name: '<a href="http://www.friendo.com.tw/Mission/3501" target="_blank">九品芝麻官大會考</a>',
		category: "相信有不少人都看過《九品芝麻官》，電影中滿滿的「老木」不說，妓院老鴇就佔了一大篇幅，貪官描述更是不遺餘力，可以說是一部藉古諷今的電影。電影中也有不少經典台詞及橋段，現在就來考考特務們對這部電影的記憶力吧！",
		status: "active"
	},
	{
		id: 2,
		no: 3521,
		cover: "http://friendoprod.blob.core.windows.net/missionpics/images/main/dfe4e330-ab91-41c6-834a-d22264adcf42.gif",
		name: '<a href="http://www.friendo.com.tw/Mission/3521" target="_blank">與龍共舞隨堂考</a>',
		category: "每次只要轉到港劇<<與龍共舞>>，就算早已看過上百遍，還是會忍不住停下來看，然後被老梗再次逗得哈哈大笑，其中最有名的梗當然就屬流行20年以上的「龍蝦裝」了。<<與龍共舞>>真是一部百看不膩的電影，現在就來考考特務們對與龍共舞的熟悉度吧！",
		status: "danger"
	},
	{
		id: 3,
		no: 3556,
		cover: "http://friendoprod.blob.core.windows.net/missionpics/images/main/bc2fae4f-dc2e-4d31-b6fd-8c9b3870aef6.jpg",
		name: '<a href="http://www.friendo.com.tw/Mission/3556" target="_blank">少林足球隨堂考</a>',
		category: "《少林足球》在全球上映的累計總票房約5000萬美元，亦是第一部在歐洲大規模上映的周星馳電影。相信各位特務們對《少林足球》這部電影都耳熟能詳，隊長就不囉嗦了，馬上出題考考大家！",
		status: "success"
	},
	{
		id: 4,
		no: 3485,
		cover: "http://friendoprod.blob.core.windows.net/missionpics/images/main/045c1eb9-5708-498c-9d4a-61db3d2f4952.jpg",
		name: '<a href="http://www.friendo.com.tw/Mission/3485" target="_blank">古惑仔大會考</a>',
		category: "《古惑仔》系列電影為香港著名的黑幫電影，從第一集《古惑仔之人在江湖》上映後便大受歡迎，往後更拍了許多續集，整體氣勢無人能及，堪稱黑幫片的經典！現在就請各位特務們，測驗看看你夠不格當古惑仔吧！",
		status: "none"
	},
	{
		id: 5,
		no: 3539,
		cover: "http://friendoprod.blob.core.windows.net/missionpics/images/main/b1e384c0-d822-4a71-85a1-577abe401615.gif",
		name: '<a href="http://www.friendo.com.tw/Mission/3539" target="_blank">食神隨堂考</a>',
		category: "《食神》是喜劇巨星周星馳主演的電影，該片為周星馳重要的代表作之一，在港台各地造成很大影響，其中許多經典台詞，更成為年輕人聊天或搞笑時經常使用的詞語。各位星爺迷們來測驗看看你對星爺有多喜愛吧！",
		status: "warning"
	},
	{
		id: 6,
		no: 3448,
		cover: "http://friendoprod.blob.core.windows.net/missionpics/images/main/66f35c25-2a45-42c4-b81e-57963cf9168e.jpg",
		name: '<a href="http://www.friendo.com.tw/Mission/3448" target="_blank">唐伯虎點秋香大會考</a>',
		category: "《唐伯虎點秋香》是1993年香港喜劇電影。由周星馳主演。該片為周星馳無厘頭喜劇經典之一，而這部電影也一直在電視上不斷的重複重複再重複…，相信星爺迷們一定對劇情及對白瞭若指掌，現在就來考考特務們電影裡的小知識吧！",
		status: "active"
	}		
];

ProductList.ProductListController = Ember.ArrayController.extend({
	actions: {
		insertProduct: function(){
			alert('insertProduct');
		}		
	},
	remaining: function () {
		return this.get('length');
	},
	remainingHot: function () {
	    return this.filterProperty('isHot', true).get('length');
	}.property('@each.isHot')
});

ProductList.ProductController = Ember.ObjectController.extend({
	actions: {
	    editProduct: function () {
	    	this.set('isEditing', true);
	    },
	    isEditing: false,
		acceptChanges: function(){
			this.set('isEditing', false);
			this.get('model').save();
		},	    
		removeProduct: function () {
	  		var item = this.get('model');
		  	item.deleteRecord();
		  	item.save();
		}
	}
});

ProductList.EditProductView = Ember.TextField.extend({
	didInsertElement: function () {
		this.$().focus();
	}
});

Ember.Handlebars.helper('edit-product', ProductList.EditProductView);