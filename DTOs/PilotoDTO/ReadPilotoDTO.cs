using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vrumvrum.DTOs.PilotoDTO;

public class ReadPilotoDTO
{
    public int id_piloto { get; set; }
    public string nome { get; set; }
    public string nacionalidade { get; set; }

    public int EquipeId { get; set; }
}