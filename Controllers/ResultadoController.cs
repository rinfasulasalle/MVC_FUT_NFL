using Microsoft.AspNetCore.Mvc;
using MVC_FUT_NFL.Data;
using MVC_FUT_NFL.Models;

namespace MVC_FUT_NFL.Controllers
{
    public class ResultadoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using (ResultadoDAO db = new ResultadoDAO())
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
        public IActionResult Agregar(Resultado resultado)
        {
            using (ResultadoDAO db = new ResultadoDAO())
            {
                db.Agregar(resultado);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            CargarListas();
            using (ResultadoDAO db = new ResultadoDAO())
            {
                var res = db.Buscar(id);
                if (res != null)
                {
                    return View(res);
                    // retorna vista prod encontrado
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Editar(Resultado resultado)
        {
            using (ResultadoDAO db = new ResultadoDAO())
            {
                db.Editar(resultado);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            using (ResultadoDAO db = new ResultadoDAO())
            {
                var res = db.Buscar(id);
                if (res != null)
                {
                    return View(res);
                    // retorna vista prod encontrado
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Eliminar(int id, bool flag = false)
        {
            using (ResultadoDAO db = new ResultadoDAO())
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

        void CargarListas()
        {
            using (CatalogoDAO db = new CatalogoDAO())
            {
                ViewBag.IdPartido = db.ListarPartidos();
                ViewBag.IdEquipo = db.ListarEquipos();

            }
        }

    }
}
