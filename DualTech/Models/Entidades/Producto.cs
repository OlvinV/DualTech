using System;
using System.Collections.Generic;

namespace DualTech.Models.Entidades;

public partial class Producto
{
    public Guid ProductoId { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public int? Existencia { get; set; }

    public virtual ICollection<Detalleorden> Detalleordens { get; } = new List<Detalleorden>();
}
