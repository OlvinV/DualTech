using DualTech.Models.Entidades;

namespace DualTech.Models
{
    public class ActualizacionClienteVista
    {
        public Guid ClienteId { get; set; }

        public string? Nombre { get; set; }

        public string? Identidad { get; set; }

        public virtual ICollection<Ordene> Ordenes { get; } = new List<Ordene>();
    }
}
