using DualTech.Models.Entidades;

namespace DualTech.Models
{
    public class ActualizacionProductoVista
    {
        public Guid ProductoId { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public decimal? Precio { get; set; }

        public int? Existencia { get; set; }

        public virtual ICollection<Detalleorden> Detalleordens { get; } = new List<Detalleorden>();
    }
}
