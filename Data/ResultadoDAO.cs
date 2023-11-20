using Microsoft.EntityFrameworkCore;
using MVC_FUT_NFL.Models;

namespace MVC_FUT_NFL.Data
{
    public class ResultadoDAO:IDisposable
    {
        NflBdContext db = new NflBdContext();
        private bool disposedValue;

        public int Agregar(Resultado resultado)
        {
            db.Resultados.Add(resultado);
            return db.SaveChanges();
        }
        public int Editar(Resultado resultado)
        {
            db.Resultados.Update(resultado);
            return db.SaveChanges();
        }
        public int Eliminar(int idresultado)
        {
            var query = db.Resultados.Where(r => r.Id == idresultado).SingleOrDefault();
            db.Resultados.Remove(query);
            return db.SaveChanges();
        }
        public Resultado Buscar(int idresultado)
        {
            var query = db.Resultados.Where(r => r.Id == idresultado).SingleOrDefault();
            return query;
        }
        public List<Resultado> Listar()
        {
            var query = db.Resultados
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
        // ~ResultadoDAO()
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
