using Microsoft.AspNetCore.Mvc;
using MVC_FUT_NFL.Data;
using MVC_FUT_NFL.Models;

namespace MVC_FUT_NFL.Controllers
{
    public class RelJugadoresEquipoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using (RelJugadoresEquipoDAO db = new RelJugadoresEquipoDAO())
            {
                return View(db.Listar());
            }
        }
        [HttpGet]
        public IActionResult Agregar()
        {
            CargarListas();
            return View();
        }
        [HttpPost]
        public IActionResult Agregar(RelJugadoresEquipo rjl)
        {
            using (RelJugadoresEquipoDAO db = new RelJugadoresEquipoDAO())
            {
                db.Agregar(rjl);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            CargarListas();
            using (RelJugadoresEquipoDAO db = new RelJugadoresEquipoDAO())
            {
                var rjl = db.Buscar(id);
                if (rjl != null)
                {
                    return View(rjl);
                    // retorna vista rjl encontrado
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Editar(RelJugadoresEquipo rjl)
        {
            using (RelJugadoresEquipoDAO db = new RelJugadoresEquipoDAO())
            {
                db.Editar(rjl);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            using (RelJugadoresEquipoDAO db = new RelJugadoresEquipoDAO())
            {
                var rjl = db.Buscar(id);
                if (rjl != null)
                {
                    return View(rjl);
                    // retorna vista prod encontrado
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Eliminar(int id, bool flag = false)
        {
            using (RelJugadoresEquipoDAO db = new RelJugadoresEquipoDAO())
            {
                db.Eliminar(id);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detalle(int id)
        {
            using (RelJugadoresEquipoDAO db = new RelJugadoresEquipoDAO())
            {
                var rjl = db.Buscar(id);
                return View(rjl);
            }
        }
        void CargarListas()
        {
            using (CatalogoDAO db = new CatalogoDAO())
            {
                ViewBag.IdEquipo = db.ListarEquipos();
                ViewBag.IdJugadore = db.ListarJugadores();

            }
        }
    }

}
