var SocialDemo = {};
SocialDemo.module = {
    version: '0.1',
    nameSocialDemoace: function(ns_string){
        var parts = ns_string.SocialDemolit('.'),
            parent = SocialDemo,
            i;
        if (parts[0] === 'SocialDemo'){
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
    taggableFriends: function(dModule){
		var dModule = $(dModule);
		var dFriendList = dModule.find('.friendList');
		var dMessgae = dModule.find('.message');
		var dShare = dModule.find('.btnShare');
		var friendString = '';
		
		dMessgae.html('Loading...');

		FBUtil.after(function (FB) {
			FB.getLoginStatus(function(response) {
				if (response.status === 'connected') {
					FB.api('/me/taggable_friends', function(res) {
						if (res && !res.error) {
							var friendsData = res.data;
							dMessgae.html('');
							
							$.each(friendsData, function(index, value){
								var picture = friendsData[index].picture.data.url;

								HTML = "";
								HTML += [
									'<div class="friend">',
									'	<a target="_blank">',
									'		<img src="' + picture + '">',
									'	</a>',
									'	<div class="name">' + friendsData[index].name + '</div>',
									'   <div class="check"><input type="checkbox" class="checkbox" data-id="'+ value.id +'"></div>',
									'</div>'
								].join('');

								dFriendList.append(HTML);
							});	
						}
					});	
				}
				else {
					FB.login();
				}
			});
		});	
		
		//Post
		dShare.click(function(e){
			e.preventDefault();
			
			var dFriends = dFriendList.find('.friend')
			var friendArr = [];
			
			dFriends.each(function(index, value){
				var dObj = $(value).find('.checkbox');
				
				if(dObj.attr('checked')){
					friendArr.push(dObj.data('id'));
				}
				
				
			});
			friendString = friendArr.join(',');

			FB.login(function(){
				var params = {};
				params['name'] = 'Taggable Friends';
				params['caption'] = 'Taggable Friends';	
				params['description'] = 'Taggable Friends';
				params['message'] = 'Worth a share.';
				params['link'] = 'http://cythilya.blogspot.tw';
				params['picture'] = 'https://lh4.googleusercontent.com/-nw381RE73SY/U5KlRrevDFI/AAAAAAAACMQ/FJnuqzQfnMA/w764-h509-no/twenty_800.jpg';
				params['tags'] = friendString;
				params['place'] = '647158178704039';
			
				FB.api('/me/feed', 'post', params, function(response) {
				  if (!response || response.error) {
					alert('Error occured');
				  } else {
					alert('Post ID: ' + response.id);
				  }
				});
			}, {scope: 'publish_actions'});	
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
    doWhileExist('taggableFriends',SocialDemo.module.taggableFriends);
})();