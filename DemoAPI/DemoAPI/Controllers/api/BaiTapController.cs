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
    public class BaiTapController : Controller
    {
 
        BaiTapServices baitapService = new BaiTapServices();

        [Route("api/baitap/getbaitaps")]
        [HttpGet]
        public ActionResult getallbaitap()
        {
            List<BaiTap> baitapList = baitapService.GetAllBaiTaps();
            return
            Json(new
            {
               baitapList
                
            }, JsonRequestBehavior.AllowGet);
        }
        [Route("api/baitap/getbaitaptc")]
        [HttpGet]
        public ActionResult getbaitaptc()
        {
            List<BaiTap> baitapList = baitapService.GetBaiTapTC();
            return
            Json(new
            {
                baitapList

            }, JsonRequestBehavior.AllowGet);
        }
        [Route("api/baitap/getbaitapgc")]
        [HttpGet]
        public ActionResult getbaitapgc()
        {
            List<BaiTap> baitapList = baitapService.GetBaiTapGC();
            return
            Json(new
            {
                baitapList

            }, JsonRequestBehavior.AllowGet);
        }

    }
}