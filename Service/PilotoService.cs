using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using vrumvrum.Context;
using vrumvrum.DTOs.PilotoDTO;
using vrumvrum.DTOs.ResponseDTO;
using vrumvrum.Interface;
using vrumvrum.Models;

namespace vrumvrum.Service;

public class PilotoService : IPilotoService
{
    private readonly IPilotoRepository _pilotoRepository;
    private readonly IEquipeRepository _equipeRepository;
    private readonly VrumDbContext _vrumDbContext;

    public PilotoService(IPilotoRepository pilotoRepository, IEquipeRepository equipeRepository, VrumDbContext vrumDbContext)
    {
        _pilotoRepository = pilotoRepository;
        _equipeRepository = equipeRepository;
        _vrumDbContext = vrumDbContext;
    }

    public async Task<ResponseDTO<int>> DeletePiloto(int id_piloto)
    {
        var result = await _pilotoRepository.GetPilotoPorId(id_piloto);
        if(result == null)
        return new ResponseDTO<int>()
        {
            StatusCode = HttpStatusCode.NotFound,
            Mensagem = "Piloto não encontrado."
        };

        await _pilotoRepository.DeletePiloto(id_piloto);
        return new ResponseDTO<int>()
        {
            StatusCode = HttpStatusCode.OK,
            Mensagem = "Piloto deletado com sucesso."
        };
    }

    public async Task<ResponseDTO<ReadPilotoDTO>> GetPilotoPorId(int id_piloto)
    {
        var result = await _pilotoRepository.GetPilotoPorId(id_piloto);
        if(result == null)
        return new ResponseDTO<ReadPilotoDTO>()
        {
            StatusCode = HttpStatusCode.NotFound,
            Mensagem = "Piloto não encontrado."
        };

        return new ResponseDTO<ReadPilotoDTO>()
        {
            StatusCode = HttpStatusCode.OK,
            Mensagem = "Piloto encontrado.",
            Dados = result
        };
    }

    public async Task<ResponseDTO<IEnumerable<ReadPilotoDTO>>> GetPilotos()
    {
        var result = await _pilotoRepository.GetPilotos();
        if(result.Count() < 1)
        return new ResponseDTO<IEnumerable<ReadPilotoDTO>>()
        {
            StatusCode = HttpStatusCode.NotFound,
            Mensagem = "Não há pilotos cadastrados na base de dados."
        };

        return new ResponseDTO<IEnumerable<ReadPilotoDTO>>()
        {
            StatusCode = HttpStatusCode.OK,
            Mensagem = $"Piloto encontrados: {result.Count()}.",
            Dados = result
        };
    }

    public async Task<ResponseDTO<CreatePilotoDTO>> PostPiloto(CreatePilotoDTO pilotoDTO)
    {
        var verificaNomePiloto = await _pilotoRepository.VerificaNomePiloto(pilotoDTO.nome);
        if(verificaNomePiloto != null)
        return new ResponseDTO<CreatePilotoDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "Já existe um piloto com este nome, tente cadastrar novamente."
        };

        if(string.IsNullOrWhiteSpace(pilotoDTO.nome))
        return new ResponseDTO<CreatePilotoDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "É necessário inserir um nome para cadastrar um piloto."
        };

        if(string.IsNullOrWhiteSpace(pilotoDTO.nacionalidade))
        return new ResponseDTO<CreatePilotoDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "É necessário inserir a nacionalidade do piloto para realizar o cadastro"
        };

        var verificaIdEquipe = await _equipeRepository.GetEquipePorId(pilotoDTO.EquipeId);
        if(verificaIdEquipe == null)
        return new ResponseDTO<CreatePilotoDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "É necessário inserir uma equipe existente para cadastrar um piloto"
        };

        await _pilotoRepository.PostPiloto(pilotoDTO);
        return new ResponseDTO<CreatePilotoDTO>()
        {
            StatusCode = HttpStatusCode.OK,
            Mensagem = "Piloto cadastrado"
        };
    }

    public async Task<ResponseDTO<UpdatePilotoDTO>> PutPiloto(int id_piloto, UpdatePilotoDTO pilotoDTO)
    {
        var verificaIdPiloto = await _pilotoRepository.GetPilotoPorId(id_piloto);
        if(verificaIdPiloto == null)
        return new ResponseDTO<UpdatePilotoDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "Piloto não cadastrado na base de dados"
        };
        var verificaNomePiloto = await _pilotoRepository.VerificaNomePiloto(pilotoDTO.nome);
        if(verificaNomePiloto != null)
        return new ResponseDTO<UpdatePilotoDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "Já existe um piloto com este nome, tente modificar novamente."
        };

        if(string.IsNullOrWhiteSpace(pilotoDTO.nome))
        return new ResponseDTO<UpdatePilotoDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "É necessário inserir um nome para modificar um piloto."
        };

        if(string.IsNullOrWhiteSpace(pilotoDTO.nacionalidade))
        return new ResponseDTO<UpdatePilotoDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "É necessário inserir a nacionalidade do piloto para realizar a modificação"
        };

        var verificaIdEquipe = await _equipeRepository.GetEquipePorId(pilotoDTO.EquipeId);
        if(verificaIdEquipe == null)
        return new ResponseDTO<UpdatePilotoDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "É necessário inserir uma equipe existente para modificar um piloto"
        };

        await _pilotoRepository.PutPiloto(id_piloto, pilotoDTO);
        return new ResponseDTO<UpdatePilotoDTO>()
        {
            StatusCode = HttpStatusCode.OK,
            Mensagem = "Piloto modificado"
        };
    }
}