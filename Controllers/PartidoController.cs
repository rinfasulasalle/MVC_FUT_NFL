using Microsoft.AspNetCore.Mvc;
using MVC_FUT_NFL.Data;
using MVC_FUT_NFL.Models;

namespace MVC_FUT_NFL.Controllers
{
    public class PartidoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using (PartidoDAO db = new PartidoDAO())
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
        public IActionResult Agregar(Partido partido)
        {
            using (PartidoDAO db = new PartidoDAO())
            {
                db.Agregar(partido);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            CargarListas();
            using (PartidoDAO db = new PartidoDAO())
            {
                var part = db.Buscar(id);
                if (part != null)
                {
                    return View(part);
                    // retorna vista part encontrado
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Editar(Partido partido)
        {
            using (PartidoDAO db = new PartidoDAO())
            {
                db.Editar(partido);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            using (PartidoDAO db = new PartidoDAO())
            {
                var parti = db.Buscar(id);
                if (parti != null)
                {
                    return View(parti);
                    // retorna vista prod encontrado
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Eliminar(int id, bool flag = false)
        {
            using (PartidoDAO db = new PartidoDAO())
            {
                db.Eliminar(id);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detalle(int id)
        {
            using (PartidoDAO db = new PartidoDAO())
            {
                var partido = db.Buscar(id);
                return View(partido);
            }
        }
        void CargarListas()
        {
            using (CatalogoDAO db = new CatalogoDAO())
            {
                ViewBag.IdEstadio = db.ListarEstadios();
                ViewBag.IdEquipo = db.ListarEquipos();

            }
        }
    }
}
