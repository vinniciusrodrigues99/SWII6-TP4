using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using vrumvrum.Context;
using vrumvrum.DTOs.CampeonatoDTO;
using vrumvrum.DTOs.CorridaDTO;
using vrumvrum.DTOs.ResponseDTO;
using vrumvrum.Interface;
using vrumvrum.Models;

namespace vrumvrum.Service;

public class CorridaService : ICorridaService
{
    private readonly ICorridaRepository _corridaRepository;
    private readonly ICampeonatoRepository _campeonatoRepository;
    private readonly VrumDbContext _vrumDbContext;

    public CorridaService(ICorridaRepository corridaRepository, ICampeonatoRepository campeonatoRepository, VrumDbContext vrumDbContext)
    {
        _corridaRepository = corridaRepository;
        _campeonatoRepository = campeonatoRepository;
        _vrumDbContext = vrumDbContext;
    }

    public async Task<ResponseDTO<int>> DeleteCorrida(int id_corrida)
    {
        var result = await _corridaRepository.GetCorridaPorId(id_corrida);
        if(result == null)
        return new ResponseDTO<int>()
        {
            StatusCode = HttpStatusCode.NotFound,
            Mensagem = "Corrida não encontrado."
        };

        await _corridaRepository.DeleteCorrida(id_corrida);
        return new ResponseDTO<int>()
        {
            StatusCode = HttpStatusCode.OK,
            Mensagem = "Corrida deletada com sucesso."
        };
    }

    public async Task<ResponseDTO<ReadCorridaDTO>> GetCorridaPorId(int id_corrida)
    {
        var result = await _corridaRepository.GetCorridaPorId(id_corrida);
        if(result == null)
        return new ResponseDTO<ReadCorridaDTO>()
        {
            StatusCode = HttpStatusCode.NotFound,
            Mensagem = "Corrida não encontrada."
        };

        return new ResponseDTO<ReadCorridaDTO>()
        {
            StatusCode = HttpStatusCode.OK,
            Mensagem = "Corrida encontrada.",
            Dados = result
        };
    }

    public async Task<ResponseDTO<IEnumerable<ReadCorridaDTO>>> GetCorridas()
    {
        var result = await _corridaRepository.GetCorridas();
        if(result.Count() < 1)
        return new ResponseDTO<IEnumerable<ReadCorridaDTO>>()
        {
            StatusCode = HttpStatusCode.NotFound,
            Mensagem = "Não há corridas cadastrados na base de dados"
        };

        return new ResponseDTO<IEnumerable<ReadCorridaDTO>>()
        {
            StatusCode = HttpStatusCode.OK,
            Mensagem = $"Foram encontradas {result.Count()} corridas",
            Dados = result,
        };
    }

    public async Task<ResponseDTO<CreateCorridaDTO>> PostCorrida(CreateCorridaDTO corridaDTO)
    {
        var VerificaNomeCorrida = await _corridaRepository.VerificaNomeCorrida(corridaDTO.nome_corrida);
        if(VerificaNomeCorrida != null)
        return new ResponseDTO<CreateCorridaDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "Já existe uma corrida com esse nome, tente cadastrar uma corrida com outro nome.",
            Dados = VerificaNomeCorrida
        };

        if(string.IsNullOrWhiteSpace(corridaDTO.pais))
        return new ResponseDTO<CreateCorridaDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "É necessário inserir um país para cadastrar uma corrida. Tente novamente."
        };

        var verificaIdCampeonato = await _campeonatoRepository.GetCampeonatosPorId(corridaDTO.CampeonatoId);
        if(verificaIdCampeonato == null)
        return new ResponseDTO<CreateCorridaDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "É necessário inserir um campeonato válido para cadastrar uma corrida no campeonato."
        };

        if(string.IsNullOrWhiteSpace(corridaDTO.nome_corrida))
        return new ResponseDTO<CreateCorridaDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "É necessário inserir o nome da corrida para cadastrar uma corrida. Tente novamente."
        };

        if(corridaDTO.tamanho_circuito <= 0)
        return new ResponseDTO<CreateCorridaDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "É necessário inserir o tamanho de circuito maior que 0 para cadastrar uma corrida. Tente novamente."
        };

        if(corridaDTO.voltas <= 0)
        return new ResponseDTO<CreateCorridaDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "É necessário inserir o número de voltas maior que 0 para cadastrar uma corrida. Tente novamente."
        };

        await _corridaRepository.PostCorrida(corridaDTO);
        return new ResponseDTO<CreateCorridaDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "Corrida cadastrada com sucesso!"
        };
    }

    public async Task<ResponseDTO<UpdateCorridaDTO>> PutCorrida(int id_corrida, UpdateCorridaDTO corridaDTO)
    {
        var verificaIdCorrida = await _corridaRepository.GetCorridaPorId(id_corrida);
        if(verificaIdCorrida == null)
        return new ResponseDTO<UpdateCorridaDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "Corrida não encontrada na base de dados."
        };

        var VerificaNomeCorrida = await _corridaRepository.VerificaNomeCorrida(corridaDTO.nome_corrida);
        if(VerificaNomeCorrida != null)
        return new ResponseDTO<UpdateCorridaDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "Já existe uma corrida com esse nome, tente utilizar outro nome para modificar o nome da corrida."
        };

        if(string.IsNullOrWhiteSpace(corridaDTO.pais))
        return new ResponseDTO<UpdateCorridaDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "É necessário inserir um país para modificar uma corrida. Tente novamente."
        };

        var verificaIdCampeonato = await _campeonatoRepository.GetCampeonatosPorId(corridaDTO.CampeonatoId);
        if(verificaIdCampeonato == null)
        return new ResponseDTO<UpdateCorridaDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "É necessário inserir um campeonato válido para modificar o campeonato da corrida."
        };

        if(string.IsNullOrWhiteSpace(corridaDTO.nome_corrida))
        return new ResponseDTO<UpdateCorridaDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "É necessário inserir o nome da corrida para modificar uma corrida. Tente novamente."
        };

        if(corridaDTO.tamanho_circuito <= 0)
        return new ResponseDTO<UpdateCorridaDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "É necessário inserir o tamanho de circuito maior que 0 para modificar uma corrida. Tente novamente."
        };

        if(corridaDTO.voltas <= 0)
        return new ResponseDTO<UpdateCorridaDTO>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Mensagem = "É necessário inserir o número de voltas maior que 0 para modificar uma corrida. Tente novamente."
        };

        await _corridaRepository.PutCorrida(id_corrida, corridaDTO);
        return new ResponseDTO<UpdateCorridaDTO>()
        {
            StatusCode = HttpStatusCode.OK,
            Mensagem = "Corrida modificada com sucesso!"
        };
    }
}