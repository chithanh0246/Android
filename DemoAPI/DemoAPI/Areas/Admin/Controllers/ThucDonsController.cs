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
    public class ThucDonsController : Controller
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

        // GET: Admin/ThucDons
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
            var exercises = from e in db.ThucDon
                            select e;


            if (!String.IsNullOrEmpty(searchString))
            {
                var searchStringUppercase = CapitalizeFirstLetter(searchString);
                exercises = exercises.Where(e => e.TenMonAn.Contains(searchStringUppercase));
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(exercises.ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/ThucDons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThucDon thucDon = db.ThucDon.Find(id);
            if (thucDon == null)
            {
                return HttpNotFound();
            }
            return View(thucDon);
        }

        // GET: Admin/ThucDons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ThucDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTD,IdLoai,TenMonAn,Hinh,calo")] ThucDon thucDon)
        {
            if (ModelState.IsValid)
            {
                db.ThucDon.Add(thucDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thucDon);
        }

        // GET: Admin/ThucDons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThucDon thucDon = db.ThucDon.Find(id);
            if (thucDon == null)
            {
                return HttpNotFound();
            }
            return View(thucDon);
        }

        // POST: Admin/ThucDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTD,IdLoai,TenMonAn,Hinh,calo")] ThucDon thucDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thucDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thucDon);
        }

        // GET: Admin/ThucDons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThucDon thucDon = db.ThucDon.Find(id);
            if (thucDon == null)
            {
                return HttpNotFound();
            }
            return View(thucDon);
        }

        // POST: Admin/ThucDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThucDon thucDon = db.ThucDon.Find(id);
            db.ThucDon.Remove(thucDon);
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
