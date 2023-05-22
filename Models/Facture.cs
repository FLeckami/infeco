using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infeco.Models
{
    public class Facture
    {
        public int Id { get; set; }
        public int IdClient { get; set; }

        [ForeignKey("IdClient")]
        public Client? Client { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatePaiement { get; set; }
    }
}
