using System;
using System.Collections.Generic;

namespace Dream_Theater_Fan_Page.Models;

public partial class Integrante
{
    public int IntegranteId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Biografia { get; set; }

    public string Instrumento { get; set; } = null!;

    public int? BandaId { get; set; }

    public virtual Banda? Banda { get; set; }
}
