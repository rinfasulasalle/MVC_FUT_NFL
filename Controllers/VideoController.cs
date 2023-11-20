using Microsoft.AspNetCore.Mvc;
using MVC_FUT_NFL.Data;
using MVC_FUT_NFL.Models;

namespace MVC_FUT_NFL.Controllers
{
    public class VideoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using (VideoDAO db = new VideoDAO())
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
        public IActionResult Agregar(Video video)
        {
            using (VideoDAO db = new VideoDAO())
            {
                db.Agregar(video);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            CargarListas();
            using (VideoDAO db = new VideoDAO())
            {
                var vid = db.Buscar(id);
                if (vid != null)
                {
                    return View(vid);
                    // retorna vista part encontrado
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Editar(Video video)
        {
            using (VideoDAO db = new VideoDAO())
            {
                db.Editar(video);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            using (VideoDAO db = new VideoDAO())
            {
                var vid = db.Buscar(id);
                if (vid != null)
                {
                    return View(vid);
                    // retorna vista prod encontrado
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Eliminar(int id, bool flag = false)
        {
            using (VideoDAO db = new VideoDAO())
            {
                db.Eliminar(id);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detalle(int id)
        {
            using (VideoDAO db = new VideoDAO())
            {
                var video = db.Buscar(id);
                return View(video);
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
