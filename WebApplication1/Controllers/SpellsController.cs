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
    public class SpellsController : Controller
    {
        private GameDbContext db = new GameDbContext();

        // GET: Spells
        public ActionResult Index()
        {
            var spells = db.Spells.Include(s => s.Character);
            return View(spells.ToList());
        }

        // GET: Spells/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spell spell = db.Spells.Find(id);
            if (spell == null)
            {
                return HttpNotFound();
            }
            return View(spell);
        }

        // GET: Spells/Create
        public ActionResult Create()
        {
            ViewBag.CharacterId = new SelectList(db.Characters, "Id", "Name");
            return View();
        }

        // POST: Spells/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CharacterId,Name,Description,Intensity")] Spell spell)
        {
            if (ModelState.IsValid)
            {
                db.Spells.Add(spell);
                db.SaveChanges();
                return Redirect(TempData["UrlReferrer"] + "/Characters/Test/" + TempData["CustomViewId"].ToString());
            }

            ViewBag.CharacterId = new SelectList(db.Characters, "Id", "Name", spell.CharacterId);
            return View(spell);
        }

        // GET: Spells/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spell spell = db.Spells.Find(id);
            if (spell == null)
            {
                return HttpNotFound();
            }
            ViewBag.CharacterId = new SelectList(db.Characters, "Id", "Name", spell.CharacterId);
            return View(spell);
        }

        // POST: Spells/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CharacterId,Name,Description,Intensity")] Spell spell)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spell).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(TempData["UrlReferrer"] + "/Characters/Test/" + TempData["CustomViewId"].ToString());
            }
            ViewBag.CharacterId = new SelectList(db.Characters, "Id", "Name", spell.CharacterId);
            return View(spell);
        }

        // GET: Spells/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spell spell = db.Spells.Find(id);
            if (spell == null)
            {
                return HttpNotFound();
            }
            return View(spell);
        }

        // POST: Spells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Spell spell = db.Spells.Find(id);
            db.Spells.Remove(spell);
            db.SaveChanges();
            return Redirect(TempData["UrlReferrer"] + "/Characters/Test/" + TempData["CustomViewId"].ToString());
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
