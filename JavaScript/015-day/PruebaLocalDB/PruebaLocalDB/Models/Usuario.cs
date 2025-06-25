using System.ComponentModel.DataAnnotations;

namespace PruebaLocalDB.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }

        [Required, EmailAddress]
        public string? Correo { get; set; }

        [Required]
        public DateTime FechaRegistro { get; set; }

        [Required]
        public int? RolId { get; set; }

        public Rol? Rol { get; set; }
    }
}
