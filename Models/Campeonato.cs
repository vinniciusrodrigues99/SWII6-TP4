using System.ComponentModel.DataAnnotations;

namespace vrumvrum.Models;

public class Campeonato
{
    [Key]
    [Required]
    public int id_campeonato { get; set;}
    public string nome { get; set; }
    public int ano { get; set; }
    public string categoria { get; set; }
    
    //relacionamento com corrida
    public virtual ICollection<Corrida> Corridas { get; set; }

    //relacionamento com equipe
    public virtual ICollection<Equipe> Equipes { get; set; }

}