using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace kutuphane.Controllers
{
    public class AdminBookController : Controller
    {
        BookManager bm = new BookManager(new EfBookDal());
        GenreManager gm = new GenreManager(new EfGenreDal());
        AuthorManager am = new AuthorManager(new EfAuthorDal());
        public ActionResult Index()
        {
            var BookValues=bm.GetBookList();
            return View(BookValues);
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            List<SelectListItem> valuesG = (from i in gm.GetGenreList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.GenreId.ToString()
                                           }).ToList(); 
            ViewBag.GenreValues = valuesG;
            List<SelectListItem> valuesA = (from i in am.GetAuthorList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name+" "+i.Surname,
                                               Value = i.AuthorId.ToString()
                                           }).ToList();
            ViewBag.AuthorValues = valuesA;
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(Book p)
        {
            BookValidator BookValidator = new BookValidator();
            ValidationResult results = BookValidator.Validate(p);
            if (results.IsValid)
            {
                bm.BookAdd(p);
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
        public ActionResult DeleteBook(int id)
        {
            var BookValue = bm.GetById(id);
            bm.BookDelete(BookValue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateBook(int id)
        {
            var BookValue = bm.GetById(id);
            List<SelectListItem> valuesG = (from i in gm.GetGenreList()
                                            select new SelectListItem
                                            {
                                                Text = i.Name,
                                                Value = i.GenreId.ToString()
                                            }).ToList();
            ViewBag.GenreValues = valuesG;
            List<SelectListItem> valuesA = (from i in am.GetAuthorList()
                                            select new SelectListItem
                                            {
                                                Text = i.Name + " " + i.Surname,
                                                Value = i.AuthorId.ToString()
                                            }).ToList();
            ViewBag.AuthorValues = valuesA;
            return View(BookValue);
        }
        [HttpPost]
        public ActionResult UpdateBook(Book p)
        {
            BookValidator BookValidator=new BookValidator();
            ValidationResult results= BookValidator.Validate(p);
            if (results.IsValid)
            {
                bm.BookUpdate(p);
                return RedirectToAction("Index");
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
        public ActionResult AuthorBook(int id)
        {
            var author= am.GetById(id);
            var p=bm.GetAuthorBookList(id);
            ViewData["Author"] = author.Name + " " + author.Surname; 
            return View(p);
        }
    }
}