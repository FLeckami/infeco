using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infeco.Models;

public class Location 
{
    public int Id { get; set;}
    public string? Nom { get; set;}

    public int? IdAppartement { get; set; }
    
    [ForeignKey("IdAppartement")]
    public Appartement? Appartement { get; set; }
    public int? IdClient { get; set; }

    [ForeignKey("IdClient")]
    public Client? Client { get; set; }
    public float MontantLoyer { get; set; }
    public float MontantDepotGarantie { get; set; }
}