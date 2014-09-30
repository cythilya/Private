using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cythilya.Areas.SEOLab.Controllers
{
    public class SEOLabController : Controller
    {
        //
        // GET: /SEOLab/SEOLab/

        public ActionResult Index()
        {
            return View("~/Areas/SEOLab/Views/SEOLab/Index.cshtml");
        }

        public ActionResult EmberJSSEO(int id = 0) 
        {
            if (id == 0) 
            {
                return View("~/Areas/SEOLab/Views/SEOLab/Index.cshtml");
            }

            ViewBag.TemplateID = id;
            return View("~/Areas/SEOLab/Views/SEOLab/EmberJSSEO.cshtml");
        }

        public ActionResult AngularJSSEO()
        {
            return View("~/Areas/SEOLab/Views/SEOLab/AngularJSSEO.cshtml");
        }

        // GET: /SEOLab/SEOLab/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: /SEOLab/SEOLab/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /SEOLab/SEOLab/Create
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

        // GET: /SEOLab/SEOLab/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: /SEOLab/SEOLab/Edit/5
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

        // GET: /SEOLab/SEOLab/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: /SEOLab/SEOLab/Delete/5
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
