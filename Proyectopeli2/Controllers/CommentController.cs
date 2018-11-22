using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyectopeli2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
namespace Proyectopeli.Controllers
{

    public class CommentController : Controller
    {
        private Peliculadb db = new Peliculadb();
            
        //
        // GET: una vista parcial para mostrar en la vista de detalles de la foto
         [ChildActionOnly] //Este atributo significa que no se puede acceder a la acción desde la barra de direcciones del navegador.
        public PartialViewResult _CommentsForPhoto(int PeliID)
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
                var Imus = currentUser.Imaus;
                ViewBag.im = Imus;
            }
            //Los comentarios para una foto en particular han sido solicitados. Consigue esos comentarios.
            var comments = from c in db.Comentario
                           where c.PeliID == PeliID
                           select c;
            //guarde la identificación con foto en ViewBag porque la necesitaremos en la vista
            ViewBag.PeliID = PeliID;

            return PartialView(comments.ToList());
        }

        //
        //POST: Esta acción crea el comentario cuando se utiliza la herramienta de creación de comentario AJAX.
        [HttpPost]
        public PartialViewResult _CommentsForPhoto(Comentario comment, int PeliID)
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
                var Imus = currentUser.Imaus;
                ViewBag.im = Imus;
            }
                //El comentario viene del usuario actualmente autenticado.
                comment.UserName = ViewBag.Nombre +" "+ViewBag.Ap;
                 comment.Imaus = ViewBag.im;
            //Guarda el nuevo comentario
            db.Comentario.Add(comment);
            db.SaveChanges();

            //Obtenga la lista actualizada de comentarios
            var comments = from c in db.Comentario
                           where c.PeliID == PeliID
                           select c;
            //Guarde el PhotoID en el ViewBag porque lo necesitaremos en la vista
            ViewBag.PeliID = PeliID;
            //Devuelve la vista con la nueva lista de comentarios.
            return PartialView("_CommentsForPhoto", comments.ToList());
        }

        //
        // GET: / Comentario / CreateInline. Una vista parcial para mostrar la herramienta de creación de comentarios como una actualización parcial de la página AJAX
        [Authorize]
        public PartialViewResult _Create(int PeliID)
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
                var Imus = currentUser.Imaus;
                ViewBag.im = Imus;
            }
            //Crear el nuevo comentario.
            Comentario newComment = new Comentario();
            newComment.PeliID = PeliID;
            newComment.UserName = ViewBag.Nombre + " " + ViewBag.Ap;
            newComment.Imaus= ViewBag.im;
            ViewBag.PeliID = PeliID;
            return PartialView("_AddAComment");
        }

        //
        // GET: /Comment/Delete/5
        [Authorize]
        public ActionResult Delete(int id = 0)
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
                var Imus = currentUser.Imaus;
                ViewBag.im = Imus;
            }
            Comentario comment = db.Comentario.Find(id);
            ViewBag.PeliID = comment.PeliID;
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        //
        // POST: /Comment/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
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
                var Imus = currentUser.Imaus;
                ViewBag.im = Imus;
            }
            Comentario comment = db.Comentario.Find(id);
            db.Comentario.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Details", "Peliculas1", new { id = comment.PeliID });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    

    }
}