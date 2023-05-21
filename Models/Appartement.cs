using System.ComponentModel.DataAnnotations;

namespace Infeco.Models
{
    public class Appartement
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Adresse { get; set; }
    }
}
