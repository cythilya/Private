using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cythilya.Areas.UI.Controllers
{
    public class UIController : Controller
    {
        public ActionResult CKEditorDemo()
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
