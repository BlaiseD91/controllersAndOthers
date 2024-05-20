using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("ingatlanok")]
    public class Ingatlan
    {
        public int Id { get; set; }
        public Kategoria Kategoria { get; }
        public string Leiras { get; set; }
        public DateTime HirdetesDatuma { get; set; } = DateTime.Today;
        public bool Tehermentes { get; set; }
        public uint Ar { get; set; }
        public string KepUrl { get; set; }

        public int KategoriaId { get; set; }

        public Ingatlan() { }
    }
}
