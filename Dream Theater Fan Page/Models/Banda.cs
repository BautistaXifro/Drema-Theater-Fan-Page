using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dream_Theater_Fan_Page.Models;

public partial class Banda
{
    public int BandaId { get; set; }
    [Required(ErrorMessage = "El nombre de la banda es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
    public string Nombre { get; set; } = null!;

    [StringLength(250)]
    public string? Photo { get; set; }
    public virtual ICollection<Integrante> Integrantes { get; set; } = new List<Integrante>();
}
