using System.ComponentModel.DataAnnotations;

namespace vrumvrum.Models;

public class Corrida
{
    [Key]
    [Required]
    public int id_corrida { get; set; }
    public string nome_corrida { get; set; }
    public int voltas { get; set; }
    public double tamanho_circuito { get; set; }
    public string pais { get; set; }

    //corrida possui um campeonato
    public int CampeonatoId { get; set; }
    public virtual Campeonato Campeonato { get; set; }

}