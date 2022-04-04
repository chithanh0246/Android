using DemoAPI.Models;
using Lib.Entities;
using Lib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoAPI.Controllers.api
{
    public class TaiKhoanController : Controller
    {
        // GET: BaiTap
        TaiKhoanServices taikhoanService = new TaiKhoanServices();

        [Route("api/TaiKhoan/inserttaikhoan")]
        [HttpPost]
        public ActionResult inserttaikhoan(TaiKhoanModel rmodel)
        {
            TaiKhoan r = new TaiKhoan();
            r.Email = rmodel.Email;
            r.Pass = rmodel.Pass;
            r.HoTen = rmodel.HoTen;
            r.IdLoai = rmodel.IdLoai;
        
            taikhoanService.insertTaiKhoan(r);
            return
            Json(new
            {
                message = "success",
               
            }, JsonRequestBehavior.AllowGet);
        }
        [Route("api/taikhoan/gettaikhoans")]
        [HttpGet]
        public ActionResult getalltaikhoan()
        {
            List<TaiKhoan> TaiKhoan = taikhoanService.GetTaiKhoans();
            return
            Json(new
            {
                TaiKhoan

            }, JsonRequestBehavior.AllowGet);
        }
     

    }
}