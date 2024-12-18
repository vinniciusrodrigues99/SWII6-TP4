using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vrumvrum.DTOs.CorridaDTO;

public class UpdateCorridaDTO
{
    public string nome_corrida { get; set; }
    public int voltas { get; set; }
    public double tamanho_circuito { get; set; }
    public string pais { get; set; }

    public int CampeonatoId { get; set; }
}