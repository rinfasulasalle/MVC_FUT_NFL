using System;
using System.Collections.Generic;

namespace MVC_FUT_NFL.Models;

public partial class Resultado
{
    public int Id { get; set; }

    public int? IdPartido { get; set; }

    public int? ScoreEquipo1 { get; set; }

    public int? ScoreEquipo2 { get; set; }

    public virtual Partido? IdPartidoNavigation { get; set; }
}
