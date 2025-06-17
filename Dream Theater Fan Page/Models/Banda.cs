using System;
using System.Collections.Generic;

namespace Dream_Theater_Fan_Page.Models;

public partial class Banda
{
    public int BandaId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Integrante> Integrantes { get; set; } = new List<Integrante>();
}
