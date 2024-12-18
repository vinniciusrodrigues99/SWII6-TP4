using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vrumvrum.DTOs.PilotoDTO;
using vrumvrum.DTOs.ResponseDTO;
using vrumvrum.Models;

namespace vrumvrum.Interface;

public interface IPilotoService
{
    Task<ResponseDTO<IEnumerable<ReadPilotoDTO>>> GetPilotos();
    Task<ResponseDTO<ReadPilotoDTO>> GetPilotoPorId(int id_piloto);
    Task<ResponseDTO<CreatePilotoDTO>> PostPiloto (CreatePilotoDTO pilotoDTO);
    Task<ResponseDTO<UpdatePilotoDTO>> PutPiloto (int id_piloto, UpdatePilotoDTO pilotoDTO);
    Task<ResponseDTO<int>> DeletePiloto(int id_piloto);
}