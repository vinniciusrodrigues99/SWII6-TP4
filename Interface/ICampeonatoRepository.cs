using vrumvrum.DTOs.CampeonatoDTO;
using vrumvrum.Models;

namespace vrumvrum.Interface;

public interface ICampeonatoRepository
{
    Task<IEnumerable<ReadCampeonatoDTO>> GetCampeonatos();
    Task<ReadCampeonatoDTO> GetCampeonatosPorId(int id_campeonato);
    Task<IEnumerable<ReadCampeonatoDTO>> GetCampeonatosPorIdCorrida(int id_campeonato);
    Task<CreateCampeonatoDTO> VerificaNomeCampeonato(string nome_campeonato);
    Task<CreateCampeonatoDTO> PostCampeonato (CreateCampeonatoDTO campeonatoDTO);
    Task<int> PutCampeonato (int id_campeonato, UpdateCampeonatoDTO campeonatoDTO);
    Task<int> DeleteCampeonato(int id_campeonato);
}