using System.ComponentModel.DataAnnotations;

namespace vrumvrum.Models;

public class Equipe
{
    [Key]
    [Required]
    public int id_equipe { get; set; }
    public string nome { get; set; }
    public string nacionalidade { get; set; }

    public virtual ICollection<Piloto>Pilotos { get; set; }

    public int? CampeonatoId { get; set; }
    public virtual Campeonato Campeonato { get; set;}

}