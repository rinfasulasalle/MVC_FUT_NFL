using Microsoft.EntityFrameworkCore;
using MVC_FUT_NFL.Models;

namespace MVC_FUT_NFL.Data
{
    public class VideoDAO:IDisposable
    {
        NflBdContext db = new NflBdContext();
        private bool disposedValue;

        public int Agregar(Video video)
        {
            db.Videos.Add(video);
            return db.SaveChanges();
        }
        public int Editar(Video video)
        {
            db.Videos.Update(video);
            return db.SaveChanges();
        }
        public int Eliminar(int idvideo)
        {
            var query = db.Videos.Where(v => v.Id == idvideo).SingleOrDefault();
            db.Videos.Remove(query);
            return db.SaveChanges();
        }
        public Video Buscar(int idvideo)
        {
            Listar(); // para que muestre en detalle
            var query = db.Videos.Where(v => v.Id == idvideo).SingleOrDefault();
            return query;
        }

        public List<Video> Listar()
        {
            var query = db.Videos
                .Include(r => r.IdPartidoNavigation)
                    .ThenInclude(p => p.IdEquipo1Navigation) // Incluir el equipo1 del partido
                .Include(r => r.IdPartidoNavigation)
                    .ThenInclude(p => p.IdEquipo2Navigation) // Incluir el equipo2 del partido
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
        // ~VideoDAO()
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
