using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vrumvrum.DTOs.CampeonatoDTO;
using vrumvrum.Models;

namespace vrumvrum.DTOs.CorridaDTO;

public class ReadCorridaDTO
{
    public int id_corrida { get; set; }
    public string nome_corrida { get; set; }
    public int voltas { get; set; }
    public double tamanho_circuito { get; set; }
    public string pais { get; set; }
    public int CampeonatoId { get; set; }
}