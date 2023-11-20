using Microsoft.AspNetCore.Mvc;
using MVC_FUT_NFL.Data;
using MVC_FUT_NFL.Models;

namespace MVC_FUT_NFL.Controllers
{
    public class NoticiaController : Controller
    {
        // INDEX
        [HttpGet]
        public IActionResult Index()
        {
            using (NoticiaDAO db = new NoticiaDAO())
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
        public IActionResult Agregar(Noticia noticia)
        {
            using (NoticiaDAO db = new NoticiaDAO())
            {
                db.Agregar(noticia);
            }
            return RedirectToAction("Index");
        }
        // UPDATE
        [HttpGet]
        public IActionResult Editar(int id)
        {
            using (NoticiaDAO db = new NoticiaDAO())
            {
                var noti = db.Buscar(id);
                if (noti != null)
                {
                    return View(noti);
                    // retorna vista prod encontrado
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Editar(Noticia noticia)
        {
            using (NoticiaDAO db = new NoticiaDAO())
            {
                db.Editar(noticia);
            }
            return RedirectToAction("Index");
        }
        // DELETE
        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            using (NoticiaDAO db = new NoticiaDAO())
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
            using (NoticiaDAO db = new NoticiaDAO())
            {
                db.Eliminar(id);
            }
            return RedirectToAction("Index");
        }
        // READ
        [HttpGet]
        public IActionResult Detalle(int id)
        {
            using (NoticiaDAO db = new NoticiaDAO())
            {
                var noti = db.Buscar(id);
                return View(noti);
            }
        }
        [HttpGet]
        public IActionResult Admin()
        {
            using (NoticiaDAO db = new NoticiaDAO())
            {
                return View(db.Listar());
            }
        }
    }
}
