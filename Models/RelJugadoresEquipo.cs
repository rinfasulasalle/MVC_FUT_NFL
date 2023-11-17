using System;
using System.Collections.Generic;

namespace MVC_FUT_NFL.Models;

public partial class RelJugadoresEquipo
{
    public int IdJugador { get; set; }

    public int? IdEquipo { get; set; }

    public virtual Equipo? IdEquipoNavigation { get; set; }

    public virtual Jugadore IdJugadorNavigation { get; set; } = null!;
}
