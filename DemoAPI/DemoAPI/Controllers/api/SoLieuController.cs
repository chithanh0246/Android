using DemoAPI.Models;
using Lib;
using Lib.Entities;
using Lib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoAPI.Controllers.api
{
    
        public class SoLieuController : Controller
        {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: BaiTap
        SoLieuServices solieuService = new SoLieuServices();

            [Route("api/SoLieu/insertSoLieu")]
            [HttpPost]
            public ActionResult insertsolieu(SoLieuModel rmodel)
            {
                SoLieu r = new SoLieu();
                r.ChieuCao = rmodel.ChieuCao;
                r.CanNang = rmodel.CanNang;
                r.IdTK = rmodel.IdTK;
           
                solieuService.insertSoLieu(r);
                return
                Json(new
                {
                    message = "success",
             
            }, JsonRequestBehavior.AllowGet);
            }
        [Route("api/solieu/getsolieus")]
        [HttpGet]
        public ActionResult getallsolieu()
        {
            List<SoLieu> SoLieu = solieuService.getAllSoLieus();
            return
            Json(new
            {
                SoLieu

            }, JsonRequestBehavior.AllowGet);
        }
           
            [Route("api/SoLieu/updatesolieu")]
            [HttpPut]
            public ActionResult updatesoLieu(SoLieuModel rmodel)
            {
                SoLieu r = new SoLieu();
                r.IdSL = rmodel.IdSL;
                r.ChieuCao = rmodel.ChieuCao;
                r.CanNang = rmodel.CanNang;
                r.IdTK = rmodel.IdTK;
                solieuService.updateSoLieu(r);
                return
                Json(new
                {
                    message = "success",
               
            }, JsonRequestBehavior.AllowGet);
            }
     
    }
    
}