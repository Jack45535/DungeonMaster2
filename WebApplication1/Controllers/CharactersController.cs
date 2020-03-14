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
    public class CharactersController : Controller
    {
        private GameDbContext db = new GameDbContext();

        // GET: Characters
        public ActionResult Index()
        {
            var characters = db.Characters.Include(c => c.Game);
            return View(characters.ToList());
            
        }

        public ActionResult Test(int id)
        {
            var characters = db.Characters.Where(x=> x.GameId==id).Include(c => c.Game);
            TempData["CustomViewId"] = id;
            var baseurl = Request.Url.GetLeftPart(UriPartial.Authority);
            TempData["UrlReferrer"] = baseurl;
            return View("Index",characters.ToList());
            

        }

        // GET: Characters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }



        // GET: Characters/Create
        public ActionResult Create()
        {
            ViewBag.GameId = new SelectList(db.Game, "Id", "Name");
            return View();
            
        }

        // POST: Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GameId,Name,Owner,Age,CharDesc,Plat,Gold,Silver,Copper,Str,Int,Dex,Luck,Speed,Charisma")] Character character)
        {
            if (ModelState.IsValid)
            {
                db.Characters.Add(character);
                db.SaveChanges();
                return Redirect(TempData["UrlReferrer"] + "/Characters/Test/" + TempData["CustomViewId"].ToString());
            }

            ViewBag.GameId = new SelectList(db.Game, "Id", "Name", character.GameId);
            return Redirect(TempData["UrlReferrer"].ToString());
        }

        // GET: Characters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameId = new SelectList(db.Game, "Id", "Name", character.GameId);
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GameId,Name,Owner,Age,CharDesc,Plat,Gold,Silver,Copper,Str,Int,Dex,Luck,Speed,Charisma")] Character character)
        {
            int CustomViewId = (int)TempData["CustomViewId"];

            if (ModelState.IsValid)
            {
                db.Entry(character).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(TempData["UrlReferrer"]+"/Characters/Test/"+CustomViewId.ToString());
            }
            ViewBag.GameId = new SelectList(db.Game, "Id", "Name", character.GameId);
            return Redirect(TempData["UrlReferrer"].ToString());
        }

        // GET: Characters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            int CustomViewId = (int)TempData["CustomViewId"];

            Character character = db.Characters.Find(id);
            db.Characters.Remove(character);
            db.SaveChanges();
            return Redirect(TempData["UrlReferrer"] + "/Characters/Test/" + CustomViewId.ToString());
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
