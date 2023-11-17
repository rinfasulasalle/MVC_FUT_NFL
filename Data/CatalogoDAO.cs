using MVC_FUT_NFL.Models;

namespace MVC_FUT_NFL.Data
{
    public class CatalogoDAO:IDisposable
    {
        NflBdContext db = new NflBdContext();
        private bool disposedValue;

        public List<Estadio> ListarEstadios()
        {
            return db.Estadios.ToList();
        }
        public List<Equipo> ListarEquipos()
        {
            return db.Equipos.ToList();
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
        // ~CatalogoDAO()
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
