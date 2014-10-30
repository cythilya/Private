using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cythilya.Areas.UI.Controllers
{
    public class UIController : Controller
    {
        #region CKEditor

        public ActionResult CKEditorPreview() 
        {
            //get saved html snippet
            return View();
        }

        public ActionResult CKEditorDemo()
        {
            //get editor content
            //string output = "<div>ckeditor test</div>";//fake (raw) data here
            //string str = HttpUtility.UrlDecode(output);//decode
            //ViewBag.Out = str;
            return View();
        }

        //save editor content
        public ActionResult SaveEditorContent(string htmlSnippet) 
        {
            var html = htmlSnippet;
            if (!string.IsNullOrEmpty(html))
            {
                html = HttpUtility.UrlDecode(html);
            }

            //HttpCookie editorCookie = new HttpCookie("editorSnippet");
            //editorCookie.Value = html;
            //editorCookie.Expires = now.AddMinutes(10);
            //Response.Cookies.Add(editorCookie);

            var jsonObject = new { IsSuccess = false, ErrorMessage = "", ReturnData = "" };
            jsonObject = new { IsSuccess = true, ErrorMessage = "", ReturnData = "" };
            return Json(jsonObject);
        }

        #endregion

        #region D3.js

        public ActionResult d3SimpleBarChart()
        {
            return View();
        }

        #endregion

        #region AngularJS CRUD - Todo List
        public ActionResult AngularJSTodoList() 
        {
            return View();
        }
        #endregion
    }
}
