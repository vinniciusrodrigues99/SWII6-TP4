using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vrumvrum.DTOs.CorridaDTO;
using vrumvrum.DTOs.ResponseDTO;
using vrumvrum.Models;

namespace vrumvrum.Interface;

public interface ICorridaService
{
    Task<ResponseDTO<IEnumerable<ReadCorridaDTO>>> GetCorridas();
    Task<ResponseDTO<ReadCorridaDTO>> GetCorridaPorId(int id_corrida);
    Task<ResponseDTO<CreateCorridaDTO>> PostCorrida (CreateCorridaDTO corridaDTO);
    Task<ResponseDTO<UpdateCorridaDTO>> PutCorrida(int id_corrida, UpdateCorridaDTO corridaDTO);
    Task<ResponseDTO<int>> DeleteCorrida(int id_corrida);
}