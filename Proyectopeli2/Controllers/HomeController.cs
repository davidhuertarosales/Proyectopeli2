using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Proyectopeli2.Models;
using Proyectopeli2.ViewModel;
namespace Proyectopeli2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int pagina = 1)
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
            }
            var cantidadRegistrosPorPagina = 3; // parámetro
            using (var db = new Peliculadb())
            {
                var peliculas = db.Pelicula.OrderBy(x => x.PeliID)
                    .Skip((pagina - 1) * cantidadRegistrosPorPagina)
                    .Take(cantidadRegistrosPorPagina).ToList();
                var totalDeRegistros = db.Pelicula.Count();

                var modelo = new ViewModel.IndexViewModel();
                modelo.Peliculas = peliculas;
                modelo.PaginaActual = pagina;
                modelo.TotalDeRegistros = totalDeRegistros;
                modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;
                

                return View(modelo);
            }
            //return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}