using System;
using System.Collections.Generic;

namespace Dream_Theater_Fan_Page.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public int Cantidad { get; set; }

    public string? Photo { get; set; }
}
