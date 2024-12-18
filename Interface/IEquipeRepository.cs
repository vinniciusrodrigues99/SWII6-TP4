using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vrumvrum.DTOs.EquipeDTO;
using vrumvrum.Models;

namespace vrumvrum.Interface
{
    public interface IEquipeRepository
    {
        Task<IEnumerable<ReadEquipeDTO>> GetEquipes();
        Task<ReadEquipeDTO> GetEquipePorId(int id_equipe);
        Task<CreateEquipeDTO> PostEquipe (CreateEquipeDTO equipeDTO);
        Task<CreateEquipeDTO> VerificaNomeEquipe (string nome);
        Task<int> PutEquipe (int id_equipe, UpdateEquipeDTO equipeDTO);
        Task<int> DeleteEquipe (int id_equipe);
    }
}