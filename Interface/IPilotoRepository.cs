using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vrumvrum.DTOs.PilotoDTO;
using vrumvrum.Models;

namespace vrumvrum.Interface
{
    public interface IPilotoRepository
    {
        Task<IEnumerable<ReadPilotoDTO>> GetPilotos();
        Task<ReadPilotoDTO> GetPilotoPorId(int id_piloto);
        Task<CreatePilotoDTO> VerificaNomePiloto(string nome_corrida);
        Task<CreatePilotoDTO> PostPiloto (CreatePilotoDTO pilotoDTO);
        Task<int> PutPiloto (int id_piloto, UpdatePilotoDTO pilotoDTO);
        Task<int> DeletePiloto(int id_piloto);
    }
}