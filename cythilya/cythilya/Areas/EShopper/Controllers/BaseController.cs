﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cythilya.Areas.EShopper.Models;

namespace cythilya.Areas.EShopper.Controllers
{
    public class BaseController : Controller
    {
        protected MvcShoppingContext db = new MvcShoppingContext();

        protected List<Cart> Carts
        {
            get
            {
                if (Session["Carts"] == null)
                {
                    Session["Carts"] = new List<Cart>();
                }
                return (Session["Carts"] as List<Cart>);
            }
            set { Session["Carts"] = value; }

        }
    }
}
