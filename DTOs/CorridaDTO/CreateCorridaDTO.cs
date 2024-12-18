using vrumvrum.Models;

namespace vrumvrum.DTOs.CorridaDTO;

public class CreateCorridaDTO
{
    public string nome_corrida { get; set; }
    public int voltas { get; set; }
    public double tamanho_circuito { get; set; }
    public string pais { get; set; }

    public int CampeonatoId { get; set; }
}