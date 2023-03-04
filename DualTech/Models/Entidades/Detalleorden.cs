using System;
using System.Collections.Generic;

namespace DualTech.Models.Entidades;

public partial class Detalleorden
{
    public Guid DetalleOrdenId { get; set; }

    public decimal? Cantidad { get; set; }

    public decimal? Impuesto { get; set; }

    public decimal? Subtotal { get; set; }

    public decimal? Total { get; set; }

    public Guid? ProductoId { get; set; }

    public Guid? OrdenId { get; set; }

    public virtual Ordene? Orden { get; set; }

    public virtual Producto? Producto { get; set; }
}
