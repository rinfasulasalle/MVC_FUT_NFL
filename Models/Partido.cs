using System;
using System.Collections.Generic;

namespace MVC_FUT_NFL.Models;

public partial class Partido
{
    public int Id { get; set; }

    public int? IdEstadio { get; set; }

    public int? IdEquipo1 { get; set; }

    public int? IdEquipo2 { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Tipo { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual Equipo? IdEquipo1Navigation { get; set; }

    public virtual Equipo? IdEquipo2Navigation { get; set; }

    public virtual Estadio? IdEstadioNavigation { get; set; }

    public virtual ICollection<Resultado> Resultados { get; set; } = new List<Resultado>();

    public virtual ICollection<Video> Videos { get; set; } = new List<Video>();
}
