using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DungeonMasterData.GameWorker;
using DungeonMasterData.Models;

namespace WebApplication1.Controllers
{
    public class BagsController : Controller
    {
        private GameDbContext db = new GameDbContext();

        // GET: Bags
        public ActionResult Index()
        {
            var bags = db.Bags.Include(b => b.Character);
            return View(bags.ToList());
        }

        // GET: Bags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bag bag = db.Bags.Find(id);
            if (bag == null)
            {
                return HttpNotFound();
            }
            return View(bag);
        }

        public ActionResult CheckItems(int id)
        {
            var contents = db.Bags.Where(x => x.CharacterId == id).Include(c => c.Character);
            return View("Index", contents.ToList());
        }

        // GET: Bags/Create
        public ActionResult Create()
        {
            ViewBag.CharacterId = new SelectList(db.Characters, "Id", "Name");
            return View();
        }

        // POST: Bags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CharacterId,Name,Description,Quantity")] Bag bag)
        {
            if (ModelState.IsValid)
            {
                db.Bags.Add(bag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CharacterId = new SelectList(db.Characters, "Id", "Name", bag.CharacterId);
            return View(bag);
        }

        // GET: Bags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bag bag = db.Bags.Find(id);
            if (bag == null)
            {
                return HttpNotFound();
            }
            ViewBag.CharacterId = new SelectList(db.Characters, "Id", "Name", bag.CharacterId);
            return View(bag);
        }

        // POST: Bags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CharacterId,Name,Description,Quantity")] Bag bag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CharacterId = new SelectList(db.Characters, "Id", "Name", bag.CharacterId);
            return View(bag);
        }

        // GET: Bags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bag bag = db.Bags.Find(id);
            if (bag == null)
            {
                return HttpNotFound();
            }
            return View(bag);
        }

        // POST: Bags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bag bag = db.Bags.Find(id);
            db.Bags.Remove(bag);
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
