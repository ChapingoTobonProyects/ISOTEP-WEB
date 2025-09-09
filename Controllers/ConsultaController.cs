using System.Linq;
using System.Web.Mvc;
using ISOTEP_WEB.Models;
using System.Data.Entity;

namespace ISOTEP_WEB.Controllers
{
    public class ConsultaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Consulta/Buscar
        public ActionResult Buscar()
        {
            return View();
        }

        // POST: Consulta/Buscar
        [HttpPost]
        public ActionResult Buscar(string matricula)
        {
            if (string.IsNullOrWhiteSpace(matricula))
            {
                ViewBag.Mensaje = "Ingrese una matrícula.";
                return View();
            }

            var practicante = db.Practicantes
                .Include(p => p.EscuelaNMSCarrera.Carrera)
                .FirstOrDefault(p => p.Matricula == matricula);

            if (practicante == null)
            {
                ViewBag.Mensaje = "No se encontró ningún registro con esa matrícula.";
                return View();
            }

            return View("Detalle", practicante);
        }

        // GET: Consulta/Index
        public ActionResult Index()
        {
            return View();
        }
    }
}
