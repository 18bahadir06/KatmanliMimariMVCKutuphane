using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace kutuphane.Controllers
{
    public class LoginController : Controller
    {
        StaffLoginManager slm = new StaffLoginManager(new EfStaffDal());
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Staff p)
        {
            var StaffUserInfo = slm.GetStaff(p.Gmail, p.Password);
            if (StaffUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(StaffUserInfo.Gmail, false);
                Session["StaffId"] = StaffUserInfo.StaffId;
                Session["StaffMail"]=StaffUserInfo.Gmail;
                Session["Staffadsoyad"]=StaffUserInfo.Name +" "+ StaffUserInfo.Surname;
                return RedirectToAction("Index","AdminAuthor");
            }
            else
            {
                Session["hata"] = "şifre veya kullanıcı adı hatalı";
            }
            return View();
        }
    }
}