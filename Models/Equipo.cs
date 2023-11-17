using System;
using System.Collections.Generic;

namespace MVC_FUT_NFL.Models;

public partial class Equipo
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Pais { get; set; }

    public int? Puntuacion { get; set; }

    public virtual ICollection<Partido> PartidoIdEquipo1Navigations { get; set; } = new List<Partido>();

    public virtual ICollection<Partido> PartidoIdEquipo2Navigations { get; set; } = new List<Partido>();

    public virtual ICollection<RelJugadoresEquipo> RelJugadoresEquipos { get; set; } = new List<RelJugadoresEquipo>();
}
