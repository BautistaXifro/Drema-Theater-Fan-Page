using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dream_Theater_Fan_Page.Models;

public partial class Integrante
{
    public int IntegranteId { get; set; }
    [Required(ErrorMessage = "El nombre del integrante es obligatorio.")]
    [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres.")]
    public string Nombre { get; set; } = null!;
    [StringLength(250, ErrorMessage = "La biografía no puede superar los 250 caracteres.")]
    public string? Biografia { get; set; }
    [Required(ErrorMessage = "Debe especificar el instrumento.")]
    [StringLength(250, ErrorMessage = "El instrumento no puede superar los 250 caracteres.")]
    public string Instrumento { get; set; } = null!;

    public int? BandaId { get; set; }

    public virtual Banda? Banda { get; set; }
}
