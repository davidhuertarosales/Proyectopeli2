using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyectopeli2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Proyectopeli2.Controllers
{
    public class Peliculas1Controller : Controller
    {
        private Peliculadb db = new Peliculadb();

        // GET: Peliculas1
        public async Task<ActionResult> Index()
        {
            if (Request.IsAuthenticated)
            {
                var currentUserid = User.Identity.GetUserId();
                var manager = new UserManager<Proyectopeli2.Models.ApplicationUser>(new UserStore<Proyectopeli2.Models.ApplicationUser>(new Proyectopeli2.Models.ApplicationDbContext()));
                var currentUser = manager.FindById(currentUserid);
                var Rolid = currentUser.RolID;
                ViewBag.Rol = Rolid;
                var Nombre = currentUser.Nombre;
                ViewBag.Nombre = Nombre;
                var Apellido = currentUser.Apellido;
                ViewBag.Ap = Apellido;
                var user = ViewBag.Nombre + " " + ViewBag.Ap;
                ViewBag.us = user;
            }
            return View(await db.Pelicula.ToListAsync());
        }

        // GET: Peliculas1/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = await db.Pelicula.FindAsync(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // GET: Peliculas1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Peliculas1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PeliID,Title,Poster,Poster2,Video,Sinopsis,Fecha_estreno,Duracion,Generos,Idiomas,Director")] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                db.Pelicula.Add(pelicula);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pelicula);
        }

        // GET: Peliculas1/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = await db.Pelicula.FindAsync(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // POST: Peliculas1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PeliID,Title,Poster,Poster2,Video,Sinopsis,Fecha_estreno,Duracion,Generos,Idiomas,Director")] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pelicula).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pelicula);
        }

        // GET: Peliculas1/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = await db.Pelicula.FindAsync(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // POST: Peliculas1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Pelicula pelicula = await db.Pelicula.FindAsync(id);
            db.Pelicula.Remove(pelicula);
            await db.SaveChangesAsync();
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
