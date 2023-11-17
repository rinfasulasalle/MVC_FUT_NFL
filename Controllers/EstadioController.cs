using Microsoft.AspNetCore.Mvc;
using MVC_FUT_NFL.Data;
using MVC_FUT_NFL.Models;

namespace MVC_FUT_NFL.Controllers
{
    public class EstadioController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using (EstadioDAO db = new EstadioDAO())
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
        public IActionResult Agregar(Estadio estadio)
        {
            using (EstadioDAO db = new EstadioDAO())
            {
                db.Agregar(estadio);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            using (EstadioDAO db = new EstadioDAO())
            {
                var est = db.Buscar(id);
                if (est != null)
                {
                    return View(est);
                    // retorna vista prod encontrado
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Editar(Estadio estadio)
        {
            using (EstadioDAO db = new EstadioDAO())
            {
                db.Editar(estadio);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            using (EstadioDAO db = new EstadioDAO())
            {
                var est = db.Buscar(id);
                if (est != null)
                {
                    return View(est);
                    // retorna vista prod encontrado
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Eliminar(int id, bool flag = false)
        {
            using (EstadioDAO db = new EstadioDAO())
            {
                db.Eliminar(id);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detalle(int id)
        {
            using (EstadioDAO db = new EstadioDAO())
            {
                var estadio = db.Buscar(id);
                return View(estadio);
            }
        }
    }
}
