/*
 * GET home page.
 */

exports.index = function(req, res){

	var todos = [
		{ id: 1, name: "果蕊姊妹淘學院", status: 0 },
		{ id: 2, name: "Nike 打出名堂 熱血應援團", status: 1 }
	];

	console.log(todos);
	
	res.render( 'index', {
		title : 'Express Todo Example',
		todos : todos
	});	
	
};

exports.edit = function(req, res){
	//res.render('index', { title: 'Express' });
	res.redirect( '/' );
};

exports.remove = function(req, res){
	//res.render('index', { title: 'Express' });
	res.redirect( '/' );
};

exports.create = function(req, res){
	//res.render('index', { title: 'Express' });
	res.redirect( '/' );
};