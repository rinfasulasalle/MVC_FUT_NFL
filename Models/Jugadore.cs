using System;
using System.Collections.Generic;

namespace MVC_FUT_NFL.Models;

public partial class Jugadore
{
    public int Id { get; set; }

    public string? NombreCompleto { get; set; }

    public string? Posicion { get; set; }

    public string? Estadisticas { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public virtual RelJugadoresEquipo? RelJugadoresEquipo { get; set; }
}
