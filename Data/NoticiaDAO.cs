using MVC_FUT_NFL.Models;

namespace MVC_FUT_NFL.Data
{
    public class NoticiaDAO:IDisposable
    {
        NflBdContext db = new NflBdContext();
        private bool disposedValue;

        public int Agregar(Noticia noticia)
        {
            db.Noticias.Add(noticia);
            return db.SaveChanges();
        }
        public int Editar(Noticia noticia)
        {
            db.Noticias.Update(noticia);
            return db.SaveChanges();
        }
        public int Eliminar(int idnoticia)
        {
            var query = db.Noticias.Where(e => e.Id == idnoticia).SingleOrDefault();
            db.Noticias.Remove(query);
            return db.SaveChanges();
        }
        public Noticia Buscar(int idnoticia)
        {
            var query = db.Noticias.Where(e => e.Id == idnoticia).SingleOrDefault();
            return query;
        }
        public List<Noticia> Listar()
        {
            var query = db.Noticias.ToList();
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
        // ~NoticiaDAO()
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
