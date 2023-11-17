using System;
using System.Collections.Generic;

namespace MVC_FUT_NFL.Models;

public partial class Estadio
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Ubicacion { get; set; }

    public virtual ICollection<Partido> Partidos { get; set; } = new List<Partido>();
}
