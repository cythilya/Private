var ESHOPPER = {};
ESHOPPER.module = {
    version: '0.1',
    nameESHOPPERace: function(ns_string){
        var parts = ns_string.ESHOPPERlit('.'),
            parent = ESHOPPER,
            i;
        if (parts[0] === 'ESHOPPER'){
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
    navList: function(dModule){
		var dModule = $(dModule);
		var dLogout = dModule.find('.logout');
		
		dLogout.click(function(e){
			e.preventDefault();
			
			$.ajax({
				url: '/EShopper/Member/Logout',
				type: 'post',
				data: {},
				dataType: 'json',
				error: function (xhr) {},
				success: function (response) {
					if(response.IsSuccess) {
						location.href = '/EShopper/Home/Index';
					}
					else{
						alert('登出發生錯誤，請重新再試。');
					}
				}
			});
		});
    },
	cartList: function(dModule){
		var dModule = $(dModule);
		
		dModule.on('click', '.cartItem .btnRemoveItem', function(e){
			e.preventDefault();
			
			var dItem = $(this);
			
			$.ajax({
				url: '/EShopper/Cart/Remove',
				type: 'post',
				data: {
					'ID' : dItem.data('itemid')
				},
				dataType: 'json',
				error: function (xhr) {},
				success: function (response) {
					if(response.IsSuccess) {
						alert('Remove successfully. Page will reload.');
						location.reload();
					}
					else{
						alert('Remove failed. Please try again later.');
					}
				}
			});
		});
	},
	shopperDeliveryInfoIsAuthenticated: function(dModule){
		var dModule = $(dModule);
		var dBtnSubmit = dModule.find('.btnSubmit');
		var dUserInfoForm = dModule.find('.userInfoForm');
		var dDeliveryInfoForm = dModule.find('.deliveryInfoForm');
		var flagUserInfoForm = false; 
		var flagDeliveryInfo = false; 		
		
		dBtnSubmit.click(function(e){
			e.preventDefault();
			
			flagUserInfoForm = dUserInfoForm.validationEngine('validate');
			flagDeliveryInfo = dDeliveryInfoForm.validationEngine('validate');
			
			if(flagUserInfoForm && flagDeliveryInfo){
				$.ajax({
					url: '/EShopper/Order/Complete',
					type: 'post',
					data: {
						'Account' : dUserInfoForm.find('.account').val(),
						'Email' : dUserInfoForm.find('.email').val(),
						'Password' : dUserInfoForm.find('.password').val(),
						'ShipperName': dDeliveryInfoForm.find('.shipperName').val(),
						'ShipperAddress': dDeliveryInfoForm.find('.shipperAddress').val(),
						'ShipperMobile': dDeliveryInfoForm.find('.shipperMobile').val()
					},
					dataType: 'json',
					error: function (xhr) {},
					success: function (response) {
						if(response.IsSuccess) {
							alert('Order successfully. Redirect to Index.');
							location.href = '/EShopper/Home/Index';
						}
						else{
							alert('Order failed. Please try again later.');
						}
					}
				});				
			}
		});
	},
	shopperDeliveryInfo: function(dModule){
		var dModule = $(dModule);
		var dBtnSubmit = dModule.find('.btnSubmit');
		var dUserRegisterForm = dModule.find('.userRegisterForm');
		var dDeliveryInfoForm = dModule.find('.deliveryInfoForm');
		var flagUserInfoForm = false; 
		var flagDeliveryInfo = false; 		
		
		dBtnSubmit.click(function(e){
			e.preventDefault();
			
			flagUserInfoForm = dUserRegisterForm.validationEngine('validate');
			flagDeliveryInfo = dDeliveryInfoForm.validationEngine('validate');
			
			if(flagUserInfoForm && flagDeliveryInfo){
				$.ajax({
					url: '/EShopper/Order/Complete',
					type: 'post',
					data: {
						'Account' : dUserRegisterForm.find('.account').val(),
						'Email' : dUserRegisterForm.find('.email').val(),
						'Password' : dUserRegisterForm.find('.password').val(),
						'ShipperName': dDeliveryInfoForm.find('.shipperName').val(),
						'ShipperAddress': dDeliveryInfoForm.find('.shipperAddress').val(),
						'ShipperMobile': dDeliveryInfoForm.find('.shipperMobile').val()
					},
					dataType: 'json',
					error: function (xhr) {},
					success: function (response) {
						if(response.IsSuccess) {
							alert('Order successfully. Redirect to Index.');
							location.href = '/EShopper/Home/Index';
						}
						else{
							alert('Order failed. Please try again later.');
						}
					}
				});				
			}
		});
	},
	singleProductInfo: function(dModule){
		var dModule = $(dModule);
		var dBtnAddToCart = dModule.find('.btnAddToCart');
		var dSelectItem = dModule.find('.selectItem');
		
		dBtnAddToCart.click(function(){
			dThisBtn = $(this);
			
			$.ajax({
				url: '/EShopper/Cart/AddToCart',
				type: 'post',
				data: {
					'ProductID' : dThisBtn.data('productid'),
					'Amount' : dSelectItem.find(':selected').val()
				},
				dataType: 'json',
				error: function (xhr) {},
				success: function (response) {
					if(response.IsSuccess) {
						alert('Add successfully.');
					}
					else{
						alert('Add failed. Please try again later.');
					}
				}
			});			
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
    doWhileExist('navList',ESHOPPER.module.navList);
    doWhileExist('cartList',ESHOPPER.module.cartList);
    doWhileExist('shopperDeliveryInfoIsAuthenticated',ESHOPPER.module.shopperDeliveryInfoIsAuthenticated);
	doWhileExist('shopperDeliveryInfo',ESHOPPER.module.shopperDeliveryInfo);
	doWhileExist('singleProductInfo',ESHOPPER.module.singleProductInfo);
})();