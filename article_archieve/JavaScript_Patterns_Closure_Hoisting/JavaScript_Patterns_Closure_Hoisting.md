#Closure與Hoisting | JavaScript Patterns
[JavaScript Patterns](http://shop.oreilly.com/product/9780596806767.do) 的閱讀筆記之Closure與Hoisting。
##Closure
Closure是指變數的生命週期只存在於該Function中，一旦離開了Function，該變數就會被回收而不可再利用，且必須在Function內事先宣告。  

    function closure() {
        var a = 1;
        console.log(a); //1
    }
    closure();
    console.log(a); //Uncaught ReferenceError: a is not defined

##Hoisting
Hoisting是一種把宣告提升到其所在區域內頂端的行為，意即程式會將Function中全部需要宣告的Local Variable，提升到Function的第一行來執行，但不包含初始值設定。

        var a = 1;
        function hoisting() {
            if (!a) {
                var a = 999;
            }
            console.log(a); //999
        }
        hoisting();  

咦!?怎麼會是999呢？a在第一行已初始化為1，必不為0、undefined、空字串或null，怎麼會造成判斷 !a === true 呢？  

原來對於JavaScript來說，所有未宣告的Local Variable都會被提到第一行做宣告(但不設定初始值，即初始值為undefined)，意即：

        var a = 1;
        function hoisting() {
			var a = undefined;
            if (!a) {
                a = 999;
            }
            console.log(a); //999
        }
        hoisting();  

####推薦閱讀
- [JavaScript Scoping and Hoisting](http://www.adequatelygood.com/JavaScript-Scoping-and-Hoisting.html) - 清楚說明Scope、Hoisting、Function的相關觀念
- [Functions: declarations and expressions](http://javascript.info/tutorial/functions-declarations-and-expressions) - 承上，Function相關可參考這篇文章