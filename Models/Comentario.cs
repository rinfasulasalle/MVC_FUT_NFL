using System;
using System.Collections.Generic;

namespace MVC_FUT_NFL.Models;

public partial class Comentario
{
    public int Id { get; set; }

    public string? Comentario1 { get; set; }

    public int? IdPartido { get; set; }

    public virtual Partido? IdPartidoNavigation { get; set; }
}
