using MVC_FUT_NFL.Models;

namespace MVC_FUT_NFL.Data
{
    public class EstadioDAO:IDisposable
    {
        NflBdContext db = new NflBdContext();
        private bool disposedValue;

        public int Agregar(Estadio estadio)
        {
            db.Estadios.Add(estadio);
            return db.SaveChanges();
        }
        public int Editar(Estadio estadio)
        {
            db.Estadios.Update(estadio);
            return db.SaveChanges();
        }
        public int Eliminar(int idestadio)
        {
            var query = db.Estadios.Where(e => e.Id == idestadio).SingleOrDefault();
            db.Estadios.Remove(query);
            return db.SaveChanges();
        }
        public Estadio Buscar(int idestadio)
        {
            var query = db.Estadios.Where(e => e.Id == idestadio).SingleOrDefault();
            return query;
        }
        public List<Estadio> Listar()
        {
            var query = db.Estadios.Take(100).ToList();
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
        // ~EstadioDAO()
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
