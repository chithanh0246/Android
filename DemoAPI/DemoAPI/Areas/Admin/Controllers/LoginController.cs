using DemoAPI.Areas.Admin.code;
using Lib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoAPI.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Models.LoginModel model)
        {
            TaiKhoanServices taiKhoanServices = new TaiKhoanServices();

            var result = taiKhoanServices.Login(model.Email, model.Pass);
            if (result && ModelState.IsValid)
            {
                SessionHelper.SetSession(new UserSession() { Email = model.Email });
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
            }

            return View(model);
        }
    }
}