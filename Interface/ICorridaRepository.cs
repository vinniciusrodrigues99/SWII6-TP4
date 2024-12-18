using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vrumvrum.DTOs.CorridaDTO;
using vrumvrum.Models;

namespace vrumvrum.Interface;

public interface ICorridaRepository
{
    Task<IEnumerable<ReadCorridaDTO>> GetCorridas();
    Task<ReadCorridaDTO> GetCorridaPorId(int id_corrida);
    Task<CreateCorridaDTO> VerificaNomeCorrida(string nome_corrida);
    Task<CreateCorridaDTO> PostCorrida (CreateCorridaDTO corridaDTO);
    Task<int> PutCorrida (int id_corrida, UpdateCorridaDTO corridaDTO);
    Task<int> DeleteCorrida(int id_corrida);
}