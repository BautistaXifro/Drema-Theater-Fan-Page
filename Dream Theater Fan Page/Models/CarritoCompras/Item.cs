using System;
using System.Collections.Generic;

namespace Dream_Theater_Fan_Page.Models.CarritoCompras;

public partial class Item
{
    public Producto Producto { get; set; }
    public int Cantidad { get; set; }
}
