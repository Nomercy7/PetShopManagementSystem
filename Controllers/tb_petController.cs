using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Store.Models;

namespace Store.Controllers
{
    public class tb_petController : Controller
    {
        private PetStoreEntities4 db = new PetStoreEntities4();

        // GET: tb_pet
        public ActionResult Index()
        {
            /*if (AccountController.isLoggedIn == false || AccountController.isAdmin == false)
                return HttpNotFound();

            return View(db.tb_pet.ToList());*/
            if (Session["isLoggedIn"] == null || (bool)Session["isLoggedIn"]==false)
            {
                return HttpNotFound();

            }
            return View(db.tb_pet.ToList());
        }

        public ActionResult UserDisplay()
        {
            /* if (AccountController.isLoggedIn == false || AccountController.isUser == false)
                 return HttpNotFound();
             return View(db.tb_pet.ToList());*/

            if (Session["isLoggedIn"] == null || (bool)Session["isLoggedIn"] == false)
            {
                return HttpNotFound();

            }
            return View(db.tb_pet.ToList());

        }
        // GET: tb_pet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_pet tb_pet = db.tb_pet.Find(id);
            if (tb_pet == null)
            {
                return HttpNotFound();
            }
            return View(tb_pet);
        }

        // GET: tb_pet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_pet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,pet_name,species,breed,dateofbirth,IsAvailable,price")] tb_pet tb_pet)
        {
            if (ModelState.IsValid)
            {
                db.tb_pet.Add(tb_pet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_pet);
        }

        // GET: tb_pet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_pet tb_pet = db.tb_pet.Find(id);
            if (tb_pet == null)
            {
                return HttpNotFound();
            }
            return View(tb_pet);
        }

        // POST: tb_pet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,pet_name,species,breed,dateofbirth,IsAvailable,price")] tb_pet tb_pet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_pet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_pet);
        }

        // GET: tb_pet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_pet tb_pet = db.tb_pet.Find(id);
            if (tb_pet == null)
            {
                return HttpNotFound();
            }
            return View(tb_pet);
        }

        // POST: tb_pet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_pet tb_pet = db.tb_pet.Find(id);
            db.tb_pet.Remove(tb_pet);
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
