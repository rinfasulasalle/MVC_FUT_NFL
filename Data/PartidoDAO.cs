using Microsoft.EntityFrameworkCore;
using MVC_FUT_NFL.Models;
namespace MVC_FUT_NFL.Data
{
    public class PartidoDAO:IDisposable
    {
        NflBdContext db = new NflBdContext();
        private bool disposedValue;

        public int Agregar(Partido partido)
        {
            db.Partidos.Add(partido);
            return db.SaveChanges();
        }
        public int Editar(Partido partido)
        {
            db.Partidos.Update(partido);
            return db.SaveChanges();
        }
        public int Eliminar(int idpartido)
        {
            var query = db.Partidos.Where(p => p.Id == idpartido).SingleOrDefault();
            db.Partidos.Remove(query);
            return db.SaveChanges();
        }
        public Partido Buscar(int idpartido)
        {
            Listar(); // para que muestre en detalel
            var query = db.Partidos.Where(p => p.Id == idpartido).SingleOrDefault();
            return query;
        }
        public List<Partido> Listar()
        {
            // Incluye las propiedades de navegación
            var query = db.Partidos
                .Include(p => p.IdEquipo1Navigation)
                .Include(p => p.IdEquipo2Navigation)
                .Include(p => p.IdEstadioNavigation)
                .ToList();

            return query;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: eliminar el estado administrado (objetos administrados)
                }

                // TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
                // TODO: establecer los campos grandes como NULL
                disposedValue = true;
            }
        }

        // // TODO: reemplazar el finalizador solo si "Dispose(bool disposing)" tiene código para liberar los recursos no administrados
        // ~PartidoDAO()
        // {
        //     // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
