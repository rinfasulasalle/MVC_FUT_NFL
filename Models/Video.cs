using System;
using System.Collections.Generic;

namespace MVC_FUT_NFL.Models;

public partial class Video
{
    public int Id { get; set; }

    public int? IdPartido { get; set; }

    public string? TituloVideo { get; set; }

    public string? UrlVideo { get; set; }

    public virtual Partido? IdPartidoNavigation { get; set; }
}
