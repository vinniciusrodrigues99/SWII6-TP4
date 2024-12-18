using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using vrumvrum.Context;
using vrumvrum.DTOs.CampeonatoDTO;
using vrumvrum.DTOs.ResponseDTO;
using vrumvrum.Interface;
using vrumvrum.Models;

namespace vrumvrum.Service;

public class CampeonatoService : ICampeonatoService
{
    private readonly ICampeonatoRepository _campeonatoRepository;
    private readonly VrumDbContext _vrumDbContext;

    public CampeonatoService(ICampeonatoRepository campeonatoRepository, VrumDbContext vrumDbContext)
    {
        _campeonatoRepository = campeonatoRepository;
        _vrumDbContext = vrumDbContext;
    }

    public async Task<ResponseDTO<int>> DeleteCampeonato(int id_campeonato)
    {
        var result = await _campeonatoRepository.GetCampeonatosPorId(id_campeonato);
        if(result == null)
        return new ResponseDTO<int>()
        {
            StatusCode = HttpStatusCode.NotFound,
            Mensagem = "Campeonato não encontrado."
        };
        await _campeonatoRepository.DeleteCampeonato(id_campeonato);
        return new ResponseDTO<int>()
        {
            StatusCode = HttpStatusCode.OK,
            Mensagem = "Campeonato removido com sucesso."
        };
    }

    public async Task<ResponseDTO<IEnumerable<ReadCampeonatoDTO>>> GetCampeonatos()
    {
        
        var result = await _campeonatoRepository.GetCampeonatos();
        if(result.Count() < 1)
        return new ResponseDTO<IEnumerable<ReadCampeonatoDTO>>()
        {
            StatusCode = HttpStatusCode.NotFound,
            Mensagem = "Não há campeonatos cadastrados na base de dados"
        };

        return new ResponseDTO<IEnumerable<ReadCampeonatoDTO>>()
        {
            StatusCode = HttpStatusCode.OK,
            Mensagem = $"Foram encontrados {result.Count()} campeonatos",
            Dados = result
        };
    }

    public async Task<ResponseDTO<ReadCampeonatoDTO>> GetCampeonatosPorId(int id_campeonato)
    {
        var result = await _campeonatoRepository.GetCampeonatosPorId(id_campeonato);
        if(result == null)
        return new ResponseDTO<ReadCampeonatoDTO>()
        {
            StatusCode = HttpStatusCode.NotFound,
            Mensagem = "Campeonato não encontrado."
        };

        return new ResponseDTO<ReadCampeonatoDTO>()
        {
            StatusCode = HttpStatusCode.OK,
            Mensagem = "Campeonato Encontrado.",
            Dados = result
        };
    }

    public async Task<ResponseDTO<IEnumerable<ReadCampeonatoDTO>>> GetCampeonatosPorIdCorrida(int id_campeonato)
    {
        var result = await _campeonatoRepository.GetCampeonatosPorIdCorrida(id_campeonato);
        if(result.Count() < 1)
        return new ResponseDTO<IEnumerable<ReadCampeonatoDTO>>()
        {
            StatusCode = HttpStatusCode.NotFound,
            Mensagem = "Não há corridas cadastradas em campeonatos na base de dados"
        };

        return new ResponseDTO<IEnumerable<ReadCampeonatoDTO>>()
        {
            StatusCode = HttpStatusCode.OK,
            Mensagem = $"Foram encontrados {result.Count()} campeonatos",
            Dados = result
        };
    }

    public async Task<ResponseDTO<CreateCampeonatoDTO>> PostCampeonato(CreateCampeonatoDTO campeonatoDTO)
    {
        var VerificaNomeCampeonato = await _campeonatoRepository.VerificaNomeCampeonato(campeonatoDTO.nome);
        if(VerificaNomeCampeonato != null)
        return new ResponseDTO<CreateCampeonatoDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "Já existe um campeonato com esse nome, tente cadastrar um campeonato com outro nome.",
            Dados = VerificaNomeCampeonato
        };

        if(string.IsNullOrWhiteSpace(campeonatoDTO.nome))
        return new ResponseDTO<CreateCampeonatoDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "É necessário inserir um nome para cadastrar um campeonato. Tente cadastrar novamente."
        };

        if(campeonatoDTO.ano < 2000)
        return new ResponseDTO<CreateCampeonatoDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "Não é permitido cadastrar campeonatos que aconteceram antes dos anos 2000. Tente cadastrar novamente."
        };

        if(string.IsNullOrWhiteSpace(campeonatoDTO.categoria))
        return new ResponseDTO<CreateCampeonatoDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "É necessário inserir uma categoria para cadastrar um campeonato. Tente cadastrar novamente."
        };
        var result = await _campeonatoRepository.PostCampeonato(campeonatoDTO);

        return new ResponseDTO<CreateCampeonatoDTO>()
        {
            StatusCode = HttpStatusCode.OK,
            Mensagem = "Campeonado Cadastrado.",
            Dados = result
        };
    }

    public async Task<ResponseDTO<int>> PutCampeonato(int id_campeonato, UpdateCampeonatoDTO campeonatoDTO)
    {
        var result = await _campeonatoRepository.GetCampeonatosPorId(id_campeonato);
        if(result == null)
        return new ResponseDTO<int>()
        {
            StatusCode = HttpStatusCode.NotFound,
            Mensagem = "Campeonato não encontrado."
        };

        var VerificaNomeCampeonato = await _campeonatoRepository.VerificaNomeCampeonato(campeonatoDTO.nome);
        if(VerificaNomeCampeonato != null)
        return new ResponseDTO<int>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "Não é possível modificar o nome do campeonato pois já existe um campeonato com esse nome."
        };

        if(string.IsNullOrWhiteSpace(campeonatoDTO.nome))
        return new ResponseDTO<int>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "É necessário inserir um nome para modificar um campeonato. Tente modificar novamente."
        };

        if(campeonatoDTO.ano < 2000)
        return new ResponseDTO<int>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "Não é permitido cadastrar campeonatos que aconteceram antes dos anos 2000. Tente modificar novamente."
        };

        if(string.IsNullOrWhiteSpace(campeonatoDTO.categoria))
        return new ResponseDTO<int>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "É necessário inserir uma categoria para modificar um campeonato. Tente modificar novamente."
        };

        await _campeonatoRepository.PutCampeonato(id_campeonato, campeonatoDTO);
        return new ResponseDTO<int>()
        {
            StatusCode = HttpStatusCode.OK,
            Mensagem = "Campeonado modificado."
        };
    }
}