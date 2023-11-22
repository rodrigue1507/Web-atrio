using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Web_atrio
{
    public class Emploi
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string NomEntreprise { get; set; }
        [Required]
        [MaxLength(100)]
        public string PosteOccupe { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; }
        [JsonIgnore]
        public ICollection<Personne>? Personnes { get; set; }
    }
}
