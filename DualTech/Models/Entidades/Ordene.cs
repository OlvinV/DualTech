using System;
using System.Collections.Generic;

namespace DualTech.Models.Entidades;

public partial class Ordene
{
    public Guid OrdenId { get; set; }

    public decimal? Impuesto { get; set; }

    public decimal? Subtotal { get; set; }

    public decimal? Total { get; set; }

    public Guid? ClienteId { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<Detalleorden> Detalleordens { get; } = new List<Detalleorden>();
}
