using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ISOTEP_WEB.Models;
using System.Data.Entity;

namespace ISOTEP_WEB.Controllers
{
    [Authorize]
    public class PracticantesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Practicantes
        public ActionResult Index()
        {
            var practicantes = db.Practicantes
                .Include(p => p.EscuelaNMSCarrera.Carrera)
                .ToList();

            return View(practicantes);
        }

        // GET: Practicantes/Buscar
        public ActionResult Buscar()
        {
            return View();
        }

        // POST: Practicantes/BuscarPorMatricula
        [HttpPost]
        public ActionResult BuscarPorMatricula(string matricula)
        {
            if (string.IsNullOrWhiteSpace(matricula))
            {
                ViewBag.Mensaje = "Debe ingresar una matrícula.";
                return View("Buscar");
            }

            var practicante = db.Practicantes
                .Include(p => p.EscuelaNMSCarrera.Carrera)
                .FirstOrDefault(p => p.Matricula == matricula);

            if (practicante == null)
            {
                ViewBag.Mensaje = "No se encontró un practicante con esa matrícula.";
                return View("Buscar");
            }

            return View("Detalle", practicante);
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
