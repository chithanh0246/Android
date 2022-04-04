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
    public class ThucDonController: Controller
    {
        ThucDonServices thucdonService = new ThucDonServices();

        [Route("api/thucdon/getthucdons")]
        [HttpGet]
        public ActionResult getallthucdon()
        {
            List<ThucDon> thucdonList = thucdonService.GetAllThucDons();
            return
            Json(new
            {
                thucdonList

            }, JsonRequestBehavior.AllowGet);

        }
        [Route("api/thucdon/getthucdonptc")]
        public ActionResult getthucdontc()
        {
            List<ThucDon> thucdonList = thucdonService.GetThucDonTC();
            return
            Json(new
            {
                thucdonList

            }, JsonRequestBehavior.AllowGet);
        }
        [Route("api/thucdon/getthucdonpgc")]
        [HttpGet]
        public ActionResult getthucdongc()
        {
            List<ThucDon> thucdonList = thucdonService.GetThucDonGC();
            return
            Json(new
            {
                thucdonList

            }, JsonRequestBehavior.AllowGet);
        }

    }
}