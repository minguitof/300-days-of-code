﻿namespace PruebaLocalDB.Models
{
    public class Rol
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
}
