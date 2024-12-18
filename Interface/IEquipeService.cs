using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vrumvrum.DTOs.EquipeDTO;
using vrumvrum.DTOs.ResponseDTO;
using vrumvrum.Models;

namespace vrumvrum.Interface;

public interface IEquipeService
{
    Task<ResponseDTO<IEnumerable<ReadEquipeDTO>>> GetEquipes();
    Task<ResponseDTO<ReadEquipeDTO>> GetEquipePorId(int id_equipe);
    Task<ResponseDTO<CreateEquipeDTO>> PostEquipe (CreateEquipeDTO equipeDTO);
    Task<ResponseDTO<UpdateEquipeDTO>> PutEquipe (int id_equipe, UpdateEquipeDTO equipeDTO);
    Task<ResponseDTO<int>> DeleteEquipe (int id_equipe); 
}