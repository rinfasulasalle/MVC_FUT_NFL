using Microsoft.AspNetCore.Mvc;
using MVC_FUT_NFL.Data;
using MVC_FUT_NFL.Models;

namespace MVC_FUT_NFL.Controllers
{
    public class EquipoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using (EquipoDAO db = new EquipoDAO())
            {
                return View(db.Listar());
            }
        }
        [HttpGet]
        public IActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Agregar(Equipo equipo)
        {
            using (EquipoDAO db = new EquipoDAO())
            {
                db.Agregar(equipo);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            using (EquipoDAO db = new EquipoDAO())
            {
                var equi = db.Buscar(id);
                if (equi != null)
                {
                    return View(equi);
                    // retorna vista prod encontrado
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Editar(Equipo equipo)
        {
            using (EquipoDAO db = new EquipoDAO())
            {
                db.Editar(equipo);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            using (EquipoDAO db = new EquipoDAO())
            {
                var equi = db.Buscar(id);
                if (equi != null)
                {
                    return View(equi);
                    // retorna vista prod encontrado
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Eliminar(int id, bool flag = false)
        {
            using (EquipoDAO db = new EquipoDAO())
            {
                db.Eliminar(id);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detalle(int id)
        {
            using (EquipoDAO db = new EquipoDAO())
            {
                var equipo = db.Buscar(id);
                return View(equipo);
            }
        }
        [HttpGet]
        public IActionResult Tabla()
        {
            using (EquipoDAO db = new EquipoDAO())
            {
                // Obtener la lista de equipos y ordenarla por puntaje de mayor a menor
                var equiposOrdenados = db.Listar().OrderByDescending(equipo => equipo.Puntuacion).ToList();
                return View(equiposOrdenados);
            }
        }

    }
}
