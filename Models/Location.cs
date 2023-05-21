using System.ComponentModel.DataAnnotations;

namespace Infeco.Models;

public class Location 
{
    public int Id { get; set;}
    public string? Nom { get; set;}
    public int? IdAppartement { get; set; }
    public int? IdClient { get; set; } 
    public Client? Client { get; set; }
    public float MontantLoyer { get; set; }
    public float MontantDepotGarantie { get; set; }
}