using System.ComponentModel.DataAnnotations;

namespace Infeco.Models
{
    public class Facture
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public Client? Client { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatePaiement { get; set; }
    }
}
