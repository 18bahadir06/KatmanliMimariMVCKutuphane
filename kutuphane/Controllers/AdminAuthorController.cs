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

namespace kutuphane.Controllers
{
    public class AdminAuthorController : Controller
    {
        AuthorManager am=new AuthorManager(new EfAuthorDal());
        BookManager bm=new BookManager(new EfBookDal());
        [Authorize]
        public ActionResult Index()
        {
            var AuthorValues=am.GetAuthorList();
            return View(AuthorValues);
        }
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(Author p)
        {
            AuthorValidator AuthorValidator=new AuthorValidator();
            ValidationResult results = AuthorValidator.Validate(p);
            if (results.IsValid)
            {
                am.AuthorAdd(p);
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

        public ActionResult DeleteAuthor(int id)
        {
            var AuthorValue = am.GetById(id);
            am.AuthorDelete(AuthorValue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAuthor(int id)
        {
            var AuthorValue = am.GetById(id);
            return View(AuthorValue);
        }
        [HttpPost]
        public ActionResult UpdateAuthor(Author p)
        {
            AuthorValidator AuthorValidator = new AuthorValidator();
            ValidationResult results = AuthorValidator.Validate(p);
            if (results.IsValid)
            {
                am.AuthorUpdate(p);
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
    }
}