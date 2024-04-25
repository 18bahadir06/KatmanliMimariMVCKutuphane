using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using EntityLayer.Concrete;
using FluentValidation.Results;
using FluentValidation.TestHelper;
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
        GenreManager tm = new GenreManager(new EfGenreDal());
        public ActionResult Index()
        {
            var Genrevalues = tm.GetGenreList();
            return View(Genrevalues);
        }
        [HttpGet]
        public ActionResult AddTur()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTur(Genre p)
        {
            GenreValidator GenreValidator = new GenreValidator();
            ValidationResult results = GenreValidator.Validate(p);
            if (results.IsValid)
            {
                tm.GenreAdd(p);
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

        public ActionResult Deletetur(int id)
        {
            var GenreValue = tm.GetByID(id);
            tm.GenreDelete(GenreValue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Updatetur(int id)
        {
            var Genrevalue=tm.GetByID(id);
            return View(Genrevalue);
        }
        [HttpPost]
        public ActionResult Updatetur(Genre p)
        {
            tm.GenreUpdate(p);
            return RedirectToAction("Index");
        }
    }
}