using Microsoft.AspNetCore.Mvc;
using MVC_FUT_NFL.Data;
using MVC_FUT_NFL.Models;

namespace MVC_FUT_NFL.Controllers
{
    public class ComentarioController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using (ComentarioDAO db = new ComentarioDAO())
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
        public IActionResult Agregar(Comentario comentario)
        {
            using (ComentarioDAO db = new ComentarioDAO())
            {
                db.Agregar(comentario);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            CargarListas();
            using (ComentarioDAO db = new ComentarioDAO())
            {
                var com = db.Buscar(id);
                if (com != null)
                {
                    return View(com);
                    // retorna vista part encontrado
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Editar(Comentario comentario)
        {
            using (ComentarioDAO db = new ComentarioDAO())
            {
                db.Editar(comentario);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            using (ComentarioDAO db = new ComentarioDAO())
            {
                var com = db.Buscar(id);
                if (com != null)
                {
                    return View(com);
                    // retorna vista prod encontrado
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Eliminar(int id, bool flag = false)
        {
            using (ComentarioDAO db = new ComentarioDAO())
            {
                db.Eliminar(id);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detalle(int id)
        {
            using (ComentarioDAO db = new ComentarioDAO())
            {
                var comentario = db.Buscar(id);
                return View(comentario);
            }
        }

        void CargarListas()
        {
            using (CatalogoDAO db = new CatalogoDAO())
            {
                ViewBag.IdPartido = db.ListarPartidos();
            }
        }
    }
}
