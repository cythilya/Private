/**
 * Module dependencies.
 */
var express = require('express');
var routes = require('./routes');
var user = require('./routes/user');
var http = require('http');
var path = require('path');

var app = express();

// all environments
app.set('port', process.env.PORT || 3000);
app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'ejs');
app.use(express.favicon());
app.use(express.logger('dev'));
app.use(express.json());
app.use(express.urlencoded());
app.use(express.methodOverride());
app.use(app.router);
app.use(express.static(path.join(__dirname, 'public')));

// development only
if ('development' == app.get('env')) {
	app.use(express.errorHandler());
}

//routes
var req = require('request');
var url = require('url');
var http = require('http');

//get to-do list
app.get('/', function(req, res) {
	options = {
		host: '192.168.11.86',
		port: '8000',
		path: '/v1/todo/member/cythilya%40gmail.com'
	}

	var request = http.request(options, function(response) {
		response.setEncoding('utf8');
		response.on('data', function(data){
			var todos = JSON.parse(data);
			res.render('index.ejs', { todos: todos });
		});
	});
	request.on('error',function(ex){
		console.log(ex);
	})
	request.end();
});

app.post('/create', function(req, res){
	var todoData = {};
	todoData.finished = false;
	todoData.member = 'cythilya@gmail.com';
	todoData.task_name = req.param('task_name');
	todoData = JSON.stringify(todoData);	

	options = {
		host: '192.168.11.86',
		port: '8000',
		path: '/v1/todo/',
		method: 'POST'	,
		headers: {
	        'Content-Type': 'application/json',
	        'Content-Length': Buffer.byteLength(todoData)
	    }		
	}

	var request = http.request(options, function(response){
		response.setEncoding('utf8');
		response.on('data', function(data){
			res.json({isSuccess:true, itemID: data});
		});
	});
	request.write(todoData);
	request.end();
});

app.post('/edit', function(req, res){
	var todoData = {};
	todoData.finished = false;
	todoData.member = 'cythilya@gmail.com';
	todoData.task_name = req.param('task_name');
	todoData = JSON.stringify(todoData);	
	
	options = {
		host: '192.168.11.86',
		port: '8000',
		path: '/v1/todo/' + req.param('seq'),
		method: 'POST',
		headers: {
	        'Content-Type': 'application/json',
	        'Content-Length': Buffer.byteLength(todoData)
	    }		
	}

	var request = http.request(options, function(response){
		response.setEncoding('utf8');
		response.on('data', function(data){
			res.json({isSuccess:true, itemID: data});
		});
	});
	request.write(todoData);
	request.end();
});

app.post('/remove', function(req, res){
	options = {
		host: '192.168.11.86',
		port: '8000',
		path: '/v1/todo/' + req.param('seq'),
		method: 'delete',
		headers: {
	        'Content-Type': 'application/json'
	    }		
	}

	var request = http.request(options, function(response){
		response.setEncoding('utf8');
		response.on('data', function(data){
			res.json({isSuccess:true, itemID: data});
		});
	});
	request.end();
});

http.createServer(app).listen(app.get('port'), function(){
	console.log('Express server listening on port ' + app.get('port'));
});
