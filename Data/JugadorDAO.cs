using MVC_FUT_NFL.Models;
namespace MVC_FUT_NFL.Data
{
    public class JugadorDAO:IDisposable
    {
        NflBdContext db = new NflBdContext();
        private bool disposedValue;

        public int Agregar(Jugadore jugadore)
        {
            db.Jugadores.Add(jugadore);
            return db.SaveChanges();
        }
        public int Editar(Jugadore jugadore)
        {
            db.Jugadores.Update(jugadore);
            return db.SaveChanges();
        }
        public int Eliminar(int idjugadore)
        {
            var query = db.Jugadores.Where(e => e.Id == idjugadore).SingleOrDefault();
            db.Jugadores.Remove(query);
            return db.SaveChanges();
        }
        public Jugadore Buscar(int idjugadore)
        {
            var query = db.Jugadores.Where(e => e.Id == idjugadore).SingleOrDefault();
            return query;
        }
        public List<Jugadore> Listar()
        {
            var query = db.Jugadores.ToList();
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
        // ~JugadorDAO()
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
