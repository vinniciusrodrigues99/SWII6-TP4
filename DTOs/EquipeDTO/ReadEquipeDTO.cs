using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vrumvrum.DTOs.EquipeDTO
{
    public class ReadEquipeDTO
    {
        public int id_equipe { get; set;}
        public string nome { get; set; }
        public string nacionalidade { get; set; }
        public int CampeonatoId { get; set; }
    }
}