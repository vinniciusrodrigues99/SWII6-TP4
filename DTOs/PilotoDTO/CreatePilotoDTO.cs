using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vrumvrum.DTOs.PilotoDTO
{
    public class CreatePilotoDTO
    {
        public string nome { get; set; }
        public string nacionalidade { get; set; }

        public int EquipeId { get; set; }
    }
}