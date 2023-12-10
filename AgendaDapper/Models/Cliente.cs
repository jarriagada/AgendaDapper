using System.ComponentModel.DataAnnotations;

namespace AgendaDapper.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set;}
        public long Telefono { get; set; }
        public string Email { get; set; }
        public string Pais { get; set;}
        public DateTime  FechaCreacion { get; set;}
    }
}

