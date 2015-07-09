var results = [];

var resultReceiver = function(event){
    results.push(parseInt(event.data,10));
    if(results.length==2){
        postMessage(results[0]+results[1]);
    }
};

var errorReceiver = function(event){
    throw event.data;
};

var onmessage = function(event){
    var n = parseInt(event.data,10);
    if(n==0||n==1){
        postMessage(n);
        return;
    }
    for(var i=0;i<=2;i++){
        var worker = new Worker("fibonacci.js");
        worker.onmessage = resultReceiver;
        worker.onerror = errorReceiver;
        worker.postMessage(n-i);
    }
}; 