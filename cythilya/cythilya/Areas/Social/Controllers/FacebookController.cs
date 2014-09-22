using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cythilya.Areas.Social.Controllers
{
    public class FacebookController : Controller
    {
        //
        // GET: /Social/Facebook/

        public ActionResult Index()
        {
            return View();
        }

        //taggable_friends: A list of friends that can be tagged or mentioned in stories published to Facebook.
        public ActionResult TaggableFriends() 
        {
            return View();
        } 

        //
        // GET: /Social/Facebook/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Social/Facebook/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Social/Facebook/Create

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
        // GET: /Social/Facebook/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Social/Facebook/Edit/5

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
        // GET: /Social/Facebook/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Social/Facebook/Delete/5

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
