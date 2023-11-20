using Microsoft.EntityFrameworkCore;
using MVC_FUT_NFL.Models;

namespace MVC_FUT_NFL.Data
{
    public class ComentarioDAO:IDisposable
    {
        NflBdContext db = new NflBdContext();
        private bool disposedValue;

        public int Agregar(Comentario comentario)
        {
            db.Comentarios.Add(comentario);
            return db.SaveChanges();
        }
        public int Editar(Comentario comentario)
        {
            db.Comentarios.Update(comentario);
            return db.SaveChanges();
        }
        public int Eliminar(int idcomentario)
        {
            var query = db.Comentarios.Where(c => c.Id == idcomentario).SingleOrDefault();
            db.Comentarios.Remove(query);
            return db.SaveChanges();
        }
        public Comentario Buscar(int idcomentario)
        {
            Listar(); // para que muestre en detalel
            var query = db.Comentarios.Where(c => c.Id == idcomentario).SingleOrDefault();
            return query;
        }
        public List<Comentario> Listar()
        {
            var query = db.Comentarios
                .Include(r => r.IdPartidoNavigation)
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
        // ~ComentarioDAO()
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
