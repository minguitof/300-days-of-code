using System;
using System.ComponentModel.DataAnnotations;

namespace MyFirtsTest.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Correo { get; set; }

        [Display(Name = "Fecha de Registro")]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
