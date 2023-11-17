using Microsoft.AspNetCore.Mvc;
using MVC_FUT_NFL.Data;
using MVC_FUT_NFL.Models;

namespace MVC_FUT_NFL.Controllers
{
    public class JugadorController : Controller
    {
        // INDEX
        [HttpGet]
        public IActionResult Index()
        {
            using (JugadorDAO db = new JugadorDAO())
            {
                return View(db.Listar());
            }
        }
        // CREATE
        [HttpGet]
        public IActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Agregar(Jugadore jugadore)
        {
            using (JugadorDAO db = new JugadorDAO())
            {
                db.Agregar(jugadore);
            }
            return RedirectToAction("Index");
        }
        // UPDATE
        [HttpGet]
        public IActionResult Editar(int id)
        {
            using (JugadorDAO db = new JugadorDAO())
            {
                var juga = db.Buscar(id);
                if (juga != null)
                {
                    return View(juga);
                    // retorna vista prod encontrado
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Editar(Jugadore jugadore)
        {
            using (JugadorDAO db = new JugadorDAO())
            {
                db.Editar(jugadore);
            }
            return RedirectToAction("Index");
        }
        // DELETE
        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            using (JugadorDAO db = new JugadorDAO())
            {
                var juga = db.Buscar(id);
                if (juga != null)
                {
                    return View(juga);
                    // retorna vista prod encontrado
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Eliminar(int id, bool flag = false)
        {
            using (JugadorDAO db = new JugadorDAO())
            {
                db.Eliminar(id);
            }
            return RedirectToAction("Index");
        }
        // READ
        [HttpGet]
        public IActionResult Detalle(int id)
        {
            using (JugadorDAO db = new JugadorDAO())
            {
                var juga = db.Buscar(id);
                return View(juga);
            }
        }
    }
}
