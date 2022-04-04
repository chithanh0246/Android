using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lib;
using Lib.Entities;
using PagedList;

namespace DemoAPI.Areas.Admin.Controllers
{
    public class BaiTapsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        static string CapitalizeFirstLetter(string value)
        {
            value = value.ToLower();
            char[] array = value.ToCharArray();
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array);
        }

        // GET: Admin/BaiTaps
        public ActionResult Index(string searchString, string currentFilter, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var exercises = from e in db.BaiTap
                            select e;


            if (!String.IsNullOrEmpty(searchString))
            {
                var searchStringUppercase = CapitalizeFirstLetter(searchString);
                exercises = exercises.Where(e => e.TenBaiTap.Contains(searchStringUppercase));
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(exercises.ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/BaiTaps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiTap baiTap = db.BaiTap.Find(id);
            if (baiTap == null)
            {
                return HttpNotFound();
            }
            return View(baiTap);
        }

        // GET: Admin/BaiTaps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/BaiTaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBT,IdLoai,TenBaiTap,Hinh,NoiDung,SoHiep,SoLanTap")] BaiTap baiTap)
        {
            if (ModelState.IsValid)
            {
                db.BaiTap.Add(baiTap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(baiTap);
        }

        // GET: Admin/BaiTaps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiTap baiTap = db.BaiTap.Find(id);
            if (baiTap == null)
            {
                return HttpNotFound();
            }
            return View(baiTap);
        }

        // POST: Admin/BaiTaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdBT,IdLoai,TenBaiTap,Hinh,NoiDung,SoHiep,SoLanTap")] BaiTap baiTap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baiTap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(baiTap);
        }

        // GET: Admin/BaiTaps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiTap baiTap = db.BaiTap.Find(id);
            if (baiTap == null)
            {
                return HttpNotFound();
            }
            return View(baiTap);
        }

        // POST: Admin/BaiTaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaiTap baiTap = db.BaiTap.Find(id);
            db.BaiTap.Remove(baiTap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
