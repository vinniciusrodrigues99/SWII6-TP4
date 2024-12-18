using System.ComponentModel.DataAnnotations;

namespace vrumvrum.Models;

public class Piloto
{
    [Key]
    [Required]
    public int id_piloto { get; set; }
    public string nome { get; set; }
    public string nacionalidade { get; set; }

    public int EquipeId { get; set; }
    public virtual Equipe Equipe { get; set;}

}