using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kutuphane.Controllers
{
    public class AdminTurController : Controller
    {
        // GET: AdminTur
        turManager tm = new turManager(new EfturDal());
        public ActionResult Index()
        {
            var turvalues = tm.GetturList();
            return View(turvalues);
        }
    }
}