using MVC_FUT_NFL.Models;

namespace MVC_FUT_NFL.Data
{
    public class EquipoDAO:IDisposable
    {
        NflBdContext db = new NflBdContext();
        private bool disposedValue;

        public int Agregar(Equipo equipo)
        {
            db.Equipos.Add(equipo);
            return db.SaveChanges();
        }
        public int Editar(Equipo equipo)
        {
            db.Equipos.Update(equipo);
            return db.SaveChanges();
        }
        public int Eliminar(int idequipo)
        {
            var query = db.Equipos.Where(e => e.Id == idequipo).SingleOrDefault();
            db.Equipos.Remove(query);
            return db.SaveChanges();
        }
        public Equipo Buscar(int idequipo)
        {
            var query = db.Equipos.Where(e => e.Id == idequipo).SingleOrDefault();
            return query;
        }
        public List<Equipo> Listar()
        {
            var query = db.Equipos.Take(100).ToList();
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
        // ~EquipoDAO()
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
