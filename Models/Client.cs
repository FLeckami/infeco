using System.ComponentModel.DataAnnotations;

namespace Infeco.Models;

public class Client 
{
    public int Id { get; set; }
    public string? Nom { get; set; }
    public string? Prenom { get; set; }
    public string? NumeroTel {get; set;}
    public string? Mail { get; set; }
    public float Solde {get; set; }
}