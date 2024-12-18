using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vrumvrum.DTOs.CampeonatoDTO;
using vrumvrum.DTOs.ResponseDTO;
using vrumvrum.Models;

namespace vrumvrum.Interface;

public interface ICampeonatoService
{
    Task<ResponseDTO<IEnumerable<ReadCampeonatoDTO>>>GetCampeonatos();
    Task<ResponseDTO<ReadCampeonatoDTO>>GetCampeonatosPorId(int id_campeonato);
    Task<ResponseDTO<IEnumerable<ReadCampeonatoDTO>>> GetCampeonatosPorIdCorrida(int id_campeonato);
    Task<ResponseDTO<CreateCampeonatoDTO>> PostCampeonato (CreateCampeonatoDTO campeonatoDTO);
    Task<ResponseDTO<int>> PutCampeonato (int id_campeonato, UpdateCampeonatoDTO campeonatoDTO);
    Task<ResponseDTO<int>> DeleteCampeonato(int id_campeonato);
}