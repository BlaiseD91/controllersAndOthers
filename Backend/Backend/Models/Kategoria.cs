using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("kategoriak")]
    public class Kategoria
    {
        public int Id { get; set; }
        [Required]
        public string Nev { get; set; }

        public Kategoria() { }
        public Kategoria(int id, string Nev)
        {
            this.Id = id;
            this.Nev = Nev;
        }
    }
}
