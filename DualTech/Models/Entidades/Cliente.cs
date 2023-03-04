using System;
using System.Collections.Generic;

namespace DualTech.Models.Entidades;

public partial class Cliente
{
    public Guid ClienteId { get; set; }

    public string? Nombre { get; set; }

    public string? Identidad { get; set; }

    public virtual ICollection<Ordene> Ordenes { get; } = new List<Ordene>();
}
