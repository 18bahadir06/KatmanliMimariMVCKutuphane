﻿using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using EntityLayer.Concrete;
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
        GenreManager tm=new GenreManager(new EfGenreDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetTurList()
        {
            var turvalues = tm.GetGenreList();
            return View(turvalues);
        }
        public ActionResult turAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult turAdd(Genre a)
        {
            GenreValidator turValidator=new GenreValidator();
            ValidationResult results= turValidator.Validate(a);
            if (results.IsValid)
            {
                tm.GenreAdd(a);
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