using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kutuphane.Controllers
{
    public class AdminStaffController : Controller
    {
        StaffManager sm=new StaffManager(new EfStaffDal());
        public ActionResult Index()
        {
            if (!IsAdmin())
            {
                return RedirectToAction("ErrorPage", "Page404"); // Admin olmayan kullanıcıyı yönlendirme
            }
            var StaffValue= sm.GetStaffList();
            return View(StaffValue);
        }
        [HttpGet]
        public ActionResult AddStaff()
        {
            if (!IsAdmin())
            {
                return RedirectToAction("ErrorPage", "Page404"); // Admin olmayan kullanıcıyı yönlendirme
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddStaff(Staff p) 
        {
            if (!IsAdmin())
            {
                return RedirectToAction("ErrorPage", "Page404"); // Admin olmayan kullanıcıyı yönlendirme
            }
            StaffValidator Sv= new StaffValidator();
            ValidationResult result=Sv.Validate(p);
            if (result.IsValid)
            {
                sm.StaffAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult UpdateStaff(int id) 
        {
            if (!IsAdmin())
            {
                return RedirectToAction("ErrorPage", "Page404"); // Admin olmayan kullanıcıyı yönlendirme
            }
            var p=sm.GetById(id);
            return View(p);
        }
        [HttpPost]
        public ActionResult UpdateStaff(Staff p)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("ErrorPage", "Page404"); // Admin olmayan kullanıcıyı yönlendirme
            }
            sm.StaffUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteStaff(int id)
        {
            var a=sm.GetById(id);
            sm.StaffDelete(a);
            return RedirectToAction("Index");
        }
        private bool IsAdmin()
        {
            bool control = sm.AdminControl(Convert.ToInt16(Session["StaffId"]));
            return control;
        }
    }
}