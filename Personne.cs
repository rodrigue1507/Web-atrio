using System.ComponentModel.DataAnnotations;

namespace Web_atrio
{
    public class Personne
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nom { get; set; }
        [Required]
        [MaxLength(100)]
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public ICollection<Emploi> Emploies { get; set; } = new List<Emploi>();
    }
}
