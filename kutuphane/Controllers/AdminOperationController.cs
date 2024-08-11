using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace kutuphane.Controllers
{
    public class AdminOperationController : Controller
    {
        StudentManager sm = new StudentManager(new EfStudentDal());
        BookManager bm = new BookManager(new EfBookDal());
        OperationManager om = new OperationManager(new EfOperationDal());
        
        public ActionResult Index()
        {
            var deger = om.GetOperationlist();
            return View(deger);
        }

        public ActionResult AddOperation()
        {
            List<SelectListItem> valueBook = (from i in bm.GetBookList()
                                              select new SelectListItem
                                              {
                                                  Text = i.Name,
                                                  Value = i.BookId.ToString()
                                              }).ToList();
            ViewBag.Book = valueBook;
            List<SelectListItem> valueStudent = (from i in sm.GetStudentlist()
                                                 select new SelectListItem
                                                 {
                                                     Text = i.Name,
                                                     Value = i.StudentId.ToString()
                                                 }).ToList();

            ViewBag.Student = valueStudent;
            return View();
        }
        [HttpPost]
        public ActionResult AddOperation(Operation p)
        {
            DateTime today = DateTime.Now;
            DateTime future = today.AddDays(10);
            if (ModelState.IsValid)
            {
                p.BorrowDate = today;
                p.ReturnDate1 = future;
                p.ReturnDate2 = today.AddDays(-1);
                p.StaffId = Convert.ToInt16(Session["StaffId"]);
                p.DeliveryStatus = false;
                om.OperationAdd(p);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult WaitOperation()
        {
            int id = Convert.ToInt16(Session["StaffId"]);
            var p = om.GetWaitList(id);
            return View(p);
        }
        public ActionResult DeliveryStatus(int id)
        {
            var a =om.GetById(id);
            a.DeliveryStatus = true;
            a.ReturnDate2=DateTime.Now;
            om.OperationUpdate(a);
            return RedirectToAction("MyTotalOperation");
        }
        public ActionResult MyTotalOperation()
        {
            int id = Convert.ToInt16(Session["StaffId"]);
            var p=om.GetStaffList(id);
            return View(p);
        }
        public ActionResult TotalOperation()
        {
            var p = om.GetOperationlist();
            return View(p);
        }
        public ActionResult StudentOperations(int id)
        {
            var p = om.GetStudentList(id);
            return View(p);
        }
    }
}