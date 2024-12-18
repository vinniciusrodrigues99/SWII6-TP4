using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vrumvrum.DTOs.CorridaDTO;
using vrumvrum.Models;

namespace vrumvrum.DTOs.CampeonatoDTO;

public class ReadCampeonatoDTO
{
    public int id_campeonato { get; set;}
    public string nome { get; set; }
    public int ano { get; set; }
    public string categoria { get; set; }
    public virtual ICollection<Corrida> corrida { get; set; }
}