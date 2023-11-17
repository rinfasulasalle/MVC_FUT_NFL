using Microsoft.EntityFrameworkCore;
using MVC_FUT_NFL.Models;

namespace MVC_FUT_NFL.Data
{
    public class RelJugadoresEquipoDAO:IDisposable
    {
        NflBdContext db = new NflBdContext();
        private bool disposedValue;

        public int Agregar(RelJugadoresEquipo rjl)
        {
            db.RelJugadoresEquipos.Add(rjl);
            return db.SaveChanges();
        }
        public int Editar(RelJugadoresEquipo rjl)
        {
            db.RelJugadoresEquipos.Update(rjl);
            return db.SaveChanges();
        }
        public int Eliminar(int idrjl)
        {
            var query = db.RelJugadoresEquipos.Where(r => r.IdEquipo == idrjl).SingleOrDefault();
            db.RelJugadoresEquipos.Remove(query);
            return db.SaveChanges();
        }
        public RelJugadoresEquipo Buscar(int idrjl)
        {
            Listar(); // para que muestre en detalel
            var query = db.RelJugadoresEquipos.Where(r => r.IdEquipo == idrjl).SingleOrDefault();
            return query;
        }
        public List<RelJugadoresEquipo> Listar()
        {
            // Incluye las propiedades de navegación
            var query = db.RelJugadoresEquipos
                .Include(r => r.IdEquipoNavigation)
                .Include(r => r.IdJugadorNavigation)
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
        // ~RelJugadoresEquipoDAO()
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
