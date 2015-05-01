#ASP.NET MVC 4 Controller相關技術 閱讀筆記
tag: ASP.NET MVC, controller

![code](https://db.tt/6Pj5UJxd)

##Outline
###Method分類
- public method = action / action method, 可接受要求與回應請求
- private
- protected
###Model Binding
###ActionResult
- ViewResult -> View
- RedirectResult
- ContentResult
- FileResult
- void
- primitive types(sting, int) ->(ASP.NET MVC自動轉換) ContentResult
###Action Filters
- Authorization Filters
- Action Filters
- Result Filters
- Excetion Filters

---
##Action Name Selector 動作名稱選取器
`[ActionName("Default")]`會替代目前的action name。  
即，action輸入Default才能正確執行Index() method，而此時的return View()也會去找Default.cshtml，而非Index.cshtml。  
action輸入Index會被判定無法找到此方法，而執行HandleUnknownAction()。

執行步驟

- 網址列輸入 **http://localhost:1502** -> 呼叫**HandleUnknownAction()** 
- 網址列輸入 **http://localhost:1502/home** -> 呼叫**HandleUnknownAction()**
- 網址列輸入 **http://localhost:1502/home/index** -> 呼叫**HandleUnknownAction()**
- 網址列輸入 **http://localhost:1502/home/default** -> 呼叫**Index()**

	    [ActionName("Default")]
	    public ActionResult Index()
	    {
	        ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
	
	        return View();
	    }
	
	    protected override void HandleUnknownAction(string actionName)
	    {
	        Response.Redirect("http://www.friendo.com.tw");
	    }

##Action Method Selector 動作方法選取器
###NonAction (= private)
用於保護action不要公開。

    [NonAction]
    public ActionResult About()
    {
        ViewBag.Message = "Your app description page.";

        return View();
    }

此時網址列輸入**http://localhost:1502/home/about**，就會呼叫**HandleUnknownAction()**。


###HTTP動詞限定屬性
同名action，但不同動作時使用。

##ActionResult 衍生類別
- ViewResultBase
	- ViewResult - View()：可指定Layout、可傳入Model
	- PartialViewResult - PartialView()：無法指定Layout

	        public ActionResult Index()
	        {
	
	            return View(); //Default Setting
	
	            //return new RedirectToRouteResult(new RouteValueDictionary(new { action = "about" })); 
	            //return RedirectToAction("about"); //RedirectToRouteResult, Controller的輔助方法
	
	            //return View("about"); //Redirect to "About" page
	            //return View("about2"); //Page not found
	        }

		[Note] 可調整ViewEngine順序(WebFormViewEngine、RazorViewEngine)，縮短ASP.NET MVC搜尋View頁面的時間。

- EmptyResult = void
- ContentResult：可指定文字內容、內容類型(Content Type)、文字編碼(Encoding)。回傳內容(EX: 字串)的方法：

		//例一：return XML
        public ActionResult Index()
        {
            return Content("<div>AAA</div>", "text/xml", System.Text.Encoding.UTF8);
        }

		//例二：return HTML
        public ActionResult Index()
        {
            string strHTML = "<div>BBB</div>";
            return Content(strHTML);
        }

		//例三：return string
        public string Index()
        {
            string strHTML = "<div>CCC</div>";
            return strHTML;

        }

	其中，例二與例三結果相同。  
	將回傳型別設定為string(非ActionResult的衍伸型別)，就會將回傳值自動轉成ContentResult輸出。

- FileResult

	- FilePathResult：回應一個實體檔案內容。
	- FileContentResult：回應一個byte[]內容。
	- FileStreamResult：回應一個Stream內容。

	使用File方法自動選取不同的FileResult回應。

        public ActionResult Index()
        {
            byte[] fileContent = System.IO.File.ReadAllBytes("../orderedList0.png");

            if (Request.Browser.Browser == "IE" && Convert.ToInt32(Request.Browser.MajorVersion) < 9)
            {
                //處理IE舊版相容性問題，不支援RFC2231這種HTTP Header Value的編碼格式
                return File(fileContent, "image/png", Server.UrlPathEncode("範例圖片.png"));
            }
            else
            {
                return File(fileContent, "image/jpeg", "範例圖片.png");
            }
		}

- JavascriptResult：功能與ContentResult類似，差別在於Content-type不同(JavascriptResult的Content-Type為application/x-javascript)。透過ajax呼叫伺服器端傳回JavaScript。

	在Layout.cshtml載入(需載入正確的JavaScript函式庫才能正確執行Ajax輔助方法)：
	
	    @Scripts.Render("~/bundles/jquery")
	    @Scripts.Render("~/bundles/jqueryval")
	
	在view中放置：
	
		@Ajax.ActionLink("Run JavaScript", "JavaScript", new AjaxOptions());
	
	Controller撰寫程式碼以供呼叫：
	
	    public ActionResult Javascript()
	    {
	        return JavaScript("alert('OK')");//引號: 外雙內單
	    }
	
	則會alert "OK"。

- JsonResult：可自動將任意物件資料序列化(JavaScriptSerializer)成JSON格式回傳。若無法序列化，則會發生例外。為避免JSON Hijacking攻擊，任何以JSONResult回傳的要求都不允許HTTP GET取得JSON資料。

        public ActionResult JSON()
        {
            return Json( new {
                id = 1,
                name = "Bill",
                CreateOn = DateTime.Now
            });
        }

	使用POST方法呼叫，即會alert "1"。

	    $.ajax({
	        url: "http://localhost:1502/home/json",
	        type: "POST",
	        dataType: "json",
	        success: function (result) {
	            alert(result.id);
	        }
	    });

	加上JsonRequestBehavior列舉參數，透過Get method取得JSON資料。

        public ActionResult JSON()
        {
            return Json( new {
                id = 1,
                name = "Bill",
                CreateOn = DateTime.Now}, JsonRequestBehavior.AllowGet);
        }

- RedirectResult：分為301、302 Redirect。
 
        //302 Redirect
        public ActionResult Redirect() 
        {
            return Redirect("/Home/Index");
        }

        //301 Redirect
        public ActionResult Redirect301() 
        {
            return RedirectPermanent("/Home/Index");//有助於SEO，可帶走PR、link juice
        }

- RedirectToRoute  
	- RedirectToAction(action)
	- RedirectToActionPermanent(action, controller)
	- RedirectToRoute(routeName)
	- RedirectToRoutePermanent

- HTTPStatusCodeResult
		
		//Status: 201, Created
        public ActionResult Create() 
        {
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.Created, "data has been created");
        }

- HttpNotFoundResult

		//Status: 404, Not Found
        public ActionResult Create() 
        {
            return HttpNotFound();
        }

- HttpUnauthorizedResult
 
		//Status: 401, Unauthorized(redirects to login action)
        public ActionResult Create() 
        {
            return new HttpUnauthorizedResult();
        }

自定義error pages - 覆寫HandleUnknownAction 		
這不是定義404 pages的方法，而是在此controller下找不到呼叫的action時，可顯示替代頁面的方始。  
EX: 輸入"http://localhost:1502/Home/123456"，因為在HomeController沒有此"123456"的action，因此轉跳到"http://www.friendo.com.tw"。

    protected override void HandleUnknownAction(string actionName)
    {
        Response.Redirect("http://www.friendo.com.tw");
    }
		
##ViewData, TempData, ViewBag
Controller協調Model與View之間資料的傳遞的方式。

- ViewData
	- ViewData.Model

			//controller
			public ActionResult Info()
			{
			    string data = "data for test";
			    ViewData.Model = data;
			
			    return View();
			}

			//view
			@{
			    ViewBag.Title = "Info";
			    Layout = "~/Views/Shared/_Layout.cshtml";
			}
			
			<h2>@ViewData.Model</h2>
- ViewBag
- TempData：使用Session，暫存時間為**一次網頁要求**。

        public ActionResult Index()
        {
            TempData["PostMessage"] = "Info";
            return RedirectToAction("Info");
        }

        public ActionResult Info()
        {
            string data = TempData["PostMessage"] as string;//data = "Info"
            return View(data);//找尋檔名為"Info"的view
        }

##Model Binding
- 簡單Model Binding

    	//controller
	    public ActionResult Info(string Username)
	    {
	        ViewData.Model = Username;
	        return View();
	    }
		
		//view
		<form method="post">
		    <input type="text" name="Username" id="Username"/>
		    <input type="text" name="Result" id="Result" value="@Model"></inout>
		    <input type="submit"/>
		</form>

	input使用"name"這個屬性即可對應到controller的輸入參數。  
	Step 1：在id="Username"的input中輸入字串"hi"  
	Step 2：按"submit" button  
	Step 3：呼叫controller "Info"，參數Username == "hi"  
	Step 4：ViewData.Model == "hi"  
	Step 5：id="Result"的input值為"hi"   

- 使用FormCollection取得表單資料：設定FormCollection型別的參數，一次取得表單所有資料。
		
		//controller
        public ActionResult Info(FormCollection form)
        {
            ViewData.Model = form["Username"];
            return View();
        }

		//view
		<form method="post">
		    <input type="text" name="Username" id="Username"/>
		    <input type="text" name="Result" id="Result" />
		    <input type="submit"/>
		</form>

	在input "Username"與"Result"輸入數值後，按下submit。controller可一次接到整份表單的資料。I

- 複雜Model Binding：使用class來接整份表單的資料，欄位名稱(name)與class中的property名稱必須相同。

		//controller
        public class UserForm 
        {
            public string Username { get; set; }
            public string Result { get; set; }
        }

        public ActionResult Info(UserForm form)
        {
            ViewData.Model = form.Username;
            return View();
        }

		//view
		<form method="post">
		    <input type="text" name="Username" id="Username"/>
		    <input type="text" name="Result" id="Result" />
		    <input type="submit"/>
		</form>

- 多個複雜Model Binding：一個表單內傳送兩筆資料到action。
		
		//controller
        public class UserForm 
        {
            public string Username { get; set; }
            public string Result { get; set; }
        }

        public ActionResult Info(UserForm form1, UserForm form2)
        {
           return View();
        }

		//view
		<form method="post">
		    <input type="text" name="form1.Username" id="Username"/>
		    <input type="text" name="form1.Result" id="Result" />
		
		    <input type="text" name="form2.Username" id="Username"/>
		    <input type="text" name="form2.Result" id="Result" />
		
		    <input type="submit"/>
		</form>

	form1與form2收到個別的資料。

- 判斷Model Binding的驗證結果：ModelState.IsValid

		//model
	    public class UserForm
	    {
	        [Required]
	        public string Username { get; set; }
	        [Required]
	        public string Result { get; set; }
	    }

		//controller
        public ActionResult Info(UserForm form)
        {
            if (!ModelState.IsValid)
            {
                return View();//驗證不通過則在原頁，在此為驗證必填欄位皆填寫
            }
            return RedirectToAction("Index");//驗證通過則回到首頁
        }

		//view
		<form method="post">
		    <input type="text" name="Username" id="Username"/>
		    <input type="text" name="Result" id="Result" />
		    <input type="submit"/>
		</form>

- Model Binding的驗證失敗的錯誤詳細資訊
	- 統計被Binding的屬性：ModelState.Count
	- 取得特定屬性在Binding過程中是否出現錯誤：ModelState["Username"].Errors.Count
	- 取得特定屬性在Binding過程中出現的第一個錯誤與錯誤訊息：ModelState["Username"].Errors[0]、ErrorMessage

	        public ActionResult Info(UserForm form)
	        {
	            if (ModelState["Username"].Errors.Count > 0) 
	            {
	                ModelError error = ModelState["Username"].Errors[0];//取得特定屬性在Binding過程中出現的第一個錯誤
	                var errMsg = error.ErrorMessage;//取得特定屬性在Binding過程中出現的第一個錯誤的錯誤訊息
	                var errExp = error.Exception;//取得Exception

					ModelState.AddModelError("Username", "請填寫使用者名稱");//顯示錯誤訊息
	
	                return View();//驗證不通過則在原頁，在此為驗證必填欄位"Username"必填寫
	            }
	            return RedirectToAction("Index");//驗證通過則回到首頁
	        }

- 清空Model Binding狀態，View不受Model Binding Status影響：ModelState.Clear()
- 使用Bindg屬性限制可被更新的資料模型屬性
	- 避免因竄改View的欄位名稱而用Model Binding的方式傳入資料：[Bind(Exclude = "欄位名稱")]

			//方法一：宣告在controller的action中
			//Result這個欄位會是null
	        public ActionResult Info([Bind(Exclude = "Result")] UserForm form)
	        {
	            if (ModelState["Username"].Errors.Count > 0) 
	            {
	                ModelError error = ModelState["Username"].Errors[0];//取得特定屬性在Binding過程中出現的第一個錯誤
	                var errMsg = error.ErrorMessage;//取得特定屬性在Binding過程中出現的第一個錯誤的錯誤訊息
	                var errExp = error.Exception;//取得Exception
	
	                ModelState.AddModelError("Username", "請填寫使用者名稱");//顯示錯誤訊息
	                ModelState.Clear();
	
	                return View();//驗證不通過則在原頁，在此為驗證必填欄位"Username"必填寫
	            }
	            return RedirectToAction("Index");//驗證通過則回到首頁
	        }
	
			//宣告在model中(統一宣告)
		    [Bind(Exclude = "Result")]
		    public class UserForm
		    {
		        [Required]
		        public string Username { get; set; }
		        [Required]
		        public string Result { get; set; }
		    }

	- 明確指出那些欄位需要繫結：[Bind(Include = "欄位名稱")]

- 使用UpdateModel與TryUpdateModel：由於屬性Bing已被限制，因此要調整判斷Model Binding的驗證結果。  
為避免繫結錯誤，不用UpdateModel，改用TryUpdateModel

        public ActionResult Info(UserForm form)
        {
            GuestForm geustform = new GuestForm();
            TryUpdateModel<GuestForm>(geustform);

            if (!TryUpdateModel<GuestForm>(geustform))
            {
                return View();
            }
            return RedirectToAction("Index");
        }

##Action Filter
- Authorization Filter
	- Authorize：驗證身分

	        //判斷登入者是否為管理者，驗證失敗則導入login畫面
	        [Authorize(Roles="Admin")]
	        public ActionResult About()
	        {
	            return View();
	        }
	
			//web.config對於驗證失敗導入畫面的設定
		    <authentication mode="Forms">
		    	<forms loginUrl="~/Account/Login" timeout="2880" />
		    </authentication>
	- AllowAnonymous：不登入也可執行此action
	- ChildActionOnly
	- RequireHttps
	- ValidateInput：由於ASP.NET預設框架會檢查透過表單來的輸入資料是否有惡意程式碼或標籤，因此當網頁輸入HTML Tag時必須關掉此驗證。

	        [ValidateInput(false)]
	        public ActionResult About()
	        {
	            return View();
	        }
	- ValidateAntiForgeryToken：防止跨網站造假點擊(Cross Site Request Forgery, CSRF)的攻擊。

			//view
			@Html.AntiForgeryToken()

			//controller
	        [ValidateAntiForgeryToken]
	        public ActionResult About()
	        {
	            return View();
	        }

- Action Filter
	- AsyncTimeout：設定action期時間限制
	- NoAsyncTimeout：設定action無逾期時間限制
- Result Filter
	- OutputCache

			//將此action "About"的輸出結果快取60秒
	        [OutputCache(Duration=60)]
	        public ActionResult About()
	        {
	            return View();
	        }

- Exception Filter
	- HandleError
		- 當錯誤發生的時候，會顯示錯誤畫面
		- 可針對特定另外狀況做處理
- 自訂動作過濾器屬性：對於重複執行的動作單獨抽出來，寫在自訂動作過濾器屬性中。

		//controller
        public class ShoppingDataAttrubute : ActionFilterAttribute 
        {
            //覆寫OnActionExecuting
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                filterContext.Controller.ViewData["MyData"] = "my data";
            }
        }

		//多個action使用同一個自訂動作過濾器屬性取資料
        [ShoppingDataAttrubute]
        public ActionResult About()
        {
            ViewBag.Message = ViewData["MyData"];
            return View();
        }

        [ShoppingDataAttrubute]
        public ActionResult Contact()
        {
            ViewBag.Message = ViewData["MyData"];

            return View();
        }

---
Ref  
- [Content Type 大全](http://ianjung1974.blogspot.tw/2009/03/content-type.html)   


