using System;
using System.Collections.Generic;

namespace MVC_FUT_NFL.Models;

public partial class Noticia
{
    public int Id { get; set; }

    public string? TituloNoticia { get; set; }

    public string? ContenidoNoticia { get; set; }

    public string? UrlImgNoticia { get; set; }
}
