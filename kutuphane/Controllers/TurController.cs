using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kutuphane.Controllers
{
    public class TurController : Controller
    {
        // GET: Tur
        turManager tm=new turManager(new EfturDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetTurList()
        {
            var turvalues = tm.GetturList();
            return View(turvalues);
        }
        public ActionResult turAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult turAdd(tur a)
        {
            turValidator turValidator=new turValidator();
            ValidationResult results= turValidator.Validate(a);
            if (results.IsValid)
            {
                tm.turAdd(a);
                return RedirectToAction("GetTurList");
            }
            else 
            { 
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
        }
    }
}