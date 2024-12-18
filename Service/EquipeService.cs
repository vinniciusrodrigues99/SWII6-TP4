using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using vrumvrum.Context;
using vrumvrum.DTOs.EquipeDTO;
using vrumvrum.DTOs.ResponseDTO;
using vrumvrum.Interface;
using vrumvrum.Models;

namespace vrumvrum.Service;

public class EquipeService : IEquipeService
{
    private readonly IEquipeRepository _equipeRepository;
    private readonly ICampeonatoRepository _campeonatoRepository;
    private readonly VrumDbContext _vrumDbContext;

    public EquipeService(IEquipeRepository equipeRepository, ICampeonatoRepository campeonatoRepository, VrumDbContext vrumDbContext)
    {
        _equipeRepository = equipeRepository;
        _campeonatoRepository = campeonatoRepository;
        _vrumDbContext = vrumDbContext;
    }

    public async Task<ResponseDTO<int>> DeleteEquipe(int id_equipe)
    {
        var result = await _equipeRepository.GetEquipePorId(id_equipe);
        if(result == null)
        return new ResponseDTO<int>()
        {
            StatusCode = HttpStatusCode.NotFound,
            Mensagem = "Equipe não encontrado."
        };

        await _equipeRepository.DeleteEquipe(id_equipe);
        return new ResponseDTO<int>()
        {
            StatusCode = HttpStatusCode.OK,
            Mensagem = "Equipe deletada com sucesso."
        };
    }

    public async Task<ResponseDTO<ReadEquipeDTO>> GetEquipePorId(int id_equipe)
    {
        var result = await _equipeRepository.GetEquipePorId(id_equipe);
        if(result == null)
        return new ResponseDTO<ReadEquipeDTO>()
        {
            StatusCode = HttpStatusCode.NotFound,
            Mensagem = "Equipe não encontrada."
        };

        return new ResponseDTO<ReadEquipeDTO>()
        {
            StatusCode = HttpStatusCode.OK,
            Mensagem = "Equipe encontrada.",
            Dados = result
        };
    }

    public async Task<ResponseDTO<IEnumerable<ReadEquipeDTO>>> GetEquipes()
    {
        var result = await _equipeRepository.GetEquipes();
        if(result.Count() < 1)
        return new ResponseDTO<IEnumerable<ReadEquipeDTO>>()
        {
            StatusCode = HttpStatusCode.NotFound,
            Mensagem = "Não há equipes cadastradas na base de dados."
        };

        return new ResponseDTO<IEnumerable<ReadEquipeDTO>>()
        {
            StatusCode = HttpStatusCode.OK,
            Mensagem = $"Foram encontradas {result.Count()} equipes.",
            Dados = result
        };
    }

    public async Task<ResponseDTO<CreateEquipeDTO>> PostEquipe(CreateEquipeDTO equipeDTO)
    {
        var verificaNomeEquipe = await _equipeRepository.VerificaNomeEquipe(equipeDTO.nome);
        if(verificaNomeEquipe != null)
        return new ResponseDTO<CreateEquipeDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "Já existe uma equipe com esse nome, tente cadastrar uma equipe com outro nome.",
            Dados = verificaNomeEquipe
        };

        if(string.IsNullOrWhiteSpace(equipeDTO.nome))
        return new ResponseDTO<CreateEquipeDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "É necessário inserir um nome para cadastrar uma equipe."
        };

        if(string.IsNullOrWhiteSpace(equipeDTO.nacionalidade))
        return new ResponseDTO<CreateEquipeDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "É necessário inserir a nacionalidade da equipe para efetuar o cadastro"
        };

        await _equipeRepository.PostEquipe(equipeDTO);
        return new ResponseDTO<CreateEquipeDTO>()
        {
            StatusCode = HttpStatusCode.OK,
            Mensagem = "Equipe cadastrada com sucesso"
        };
    }

    public async Task<ResponseDTO<UpdateEquipeDTO>> PutEquipe(int id_equipe, UpdateEquipeDTO equipeDTO)
    {
        var verificaIdCampeonato = await _campeonatoRepository.GetCampeonatosPorId(equipeDTO.CampeonatoId);
        if(verificaIdCampeonato == null)
        return new ResponseDTO<UpdateEquipeDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "Campeonato não está registrada na base de dados",
        };

        var verificaIdEquipe = await _equipeRepository.GetEquipePorId(id_equipe);
        if(verificaIdEquipe == null)
        return new ResponseDTO<UpdateEquipeDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "Equipe não está registrada na base de dados",
        };

        var verificaNomeEquipe = await _equipeRepository.VerificaNomeEquipe(equipeDTO.nome);
        if(verificaNomeEquipe != null)
        return new ResponseDTO<UpdateEquipeDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "Já existe uma equipe com esse nome, tente cadastrar uma equipe com outro nome.",
        };

        if(string.IsNullOrWhiteSpace(equipeDTO.nome))
        return new ResponseDTO<UpdateEquipeDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "É necessário inserir um nome para cadastrar uma equipe."
        };

        if(string.IsNullOrWhiteSpace(equipeDTO.nacionalidade))
        return new ResponseDTO<UpdateEquipeDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "É necessário inserir a nacionalidade da equipe para efetuar o cadastro"
        };

        await _equipeRepository.PutEquipe(id_equipe, equipeDTO);
        return new ResponseDTO<UpdateEquipeDTO>()
        {
            StatusCode = HttpStatusCode.OK,
            Mensagem = "Equipe modificada com sucesso"
        };
    }
}