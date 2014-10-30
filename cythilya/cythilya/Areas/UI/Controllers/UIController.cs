using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cythilya.Areas.UI.Controllers
{
    public class UIController : Controller
    {
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

        public ActionResult d3SimpleBarChart()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /UI/UI/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /UI/UI/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /UI/UI/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /UI/UI/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /UI/UI/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /UI/UI/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /UI/UI/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
