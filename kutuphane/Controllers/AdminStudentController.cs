using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace kutuphane.Controllers
{
    public class AdminStudentController : Controller
    {
        StudentManager sm = new StudentManager(new EfStudentDal());
        public ActionResult Index()
        {
            var StudentValues = sm.GetStudentlist();
            return View(StudentValues);
        }
        [HttpGet]
        public ActionResult AddStudent()
        {
            SetGenderViewbag();
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Student p)
        {
            StudentValidator StudentValidator= new StudentValidator();
            ValidationResult results = StudentValidator.Validate(p);
            if (results.IsValid)
            {
                sm.StudentAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                SetGenderViewbag();
                foreach(var i in results.Errors)
                {
                    ModelState.AddModelError(i.PropertyName, i.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult UpdateStudent(int id)
        {
            SetGenderViewbag();
            var StudentValue = sm.GetById(id);
            return View(StudentValue);
        }
        [HttpPost]
        public ActionResult UpdateStudent(Student p)
        {
            StudentValidator StudentValidator = new StudentValidator();
            ValidationResult results = StudentValidator.Validate(p);
            if (results.IsValid)
            {
                sm.StudentUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        private void SetGenderViewbag()
        {
            List<SelectListItem> cinsiyet = new List<SelectListItem>()
            {
          new SelectListItem {Text="Kadın",Value="false"},
          new SelectListItem {Text="Erkek",Value="true"},
           };
            ViewBag.Cinsiyet = cinsiyet;
        }
        public ActionResult DeleteStudent(int id)
        {
            var StudentValue = sm.GetById(id);
            sm. StudentDelete(StudentValue);
            return RedirectToAction("Index");
        }
    }
}