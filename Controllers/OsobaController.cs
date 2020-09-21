using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspMvcCodeFirst1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspMvcCodeFirst1.Controllers
{
    public class OsobaController : Controller
    {
        private readonly OsobaContext db;
        private object osoba;

        public OsobaController(OsobaContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View(db.Osobe.ToList());
        }

        public IActionResult Details(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Osoba os1 = db.Osobe.SingleOrDefault(os => os.OsobaId == id);

            if (os1 == null)
            {
                return NotFound();
            }
            return View(os1);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("OsobaId,Ime,Prezime,Adresa")] Osoba osoba)
        {
            if (ModelState.IsValid)
            {
                db.Add(osoba);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(osoba);
        }

        public IActionResult Edit(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Osoba os1 = db.Osobe.SingleOrDefault(os => os.OsobaId == id);

            if (os1 == null)
            {
                return NotFound();
            }
            return View(os1);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("OsobaId,Ime,Prezime,Adresa")] Osoba osoba)
        {
            if (id != osoba.OsobaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    db.Entry(osoba).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {

                    db.Entry(osoba).State = EntityState.Unchanged;
                    ViewBag.Greska = "Greska pri komunikaciji sa bazom";
                    return View(osoba);
                }

            }
            ViewBag.Greska = "Neispravni podaci";
            return View(osoba);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Osoba os1 = db.Osobe.SingleOrDefault(os => os.OsobaId == id);

            if (os1 == null)
            {
                return NotFound();
            }
            return View(os1);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {
                Osoba osoba = db.Osobe.Find(id);
                db.Osobe.Remove(osoba);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewBag.Greska = "Greska pri komunikaciji sa bazom";
                return View(osoba);
            }
        }
    }
}
