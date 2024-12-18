using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vrumvrum.DTOs.CampeonatoDTO;
using vrumvrum.DTOs.ResponseDTO;
using vrumvrum.Interface;
using vrumvrum.Models;

namespace vrumvrum.Controllers;

[ApiController]
[Route("[Controller]")]
public class CampeonatoController : ControllerBase
{
    private readonly ICampeonatoService _campeonatoService;
    public CampeonatoController(ICampeonatoService campeonatoService)
    {
        _campeonatoService = campeonatoService;
    }
    [HttpGet]
    public async Task<IActionResult> GetCampeonatos()
    {
        var responseDTO = await _campeonatoService.GetCampeonatos();
        if(responseDTO.StatusCode == HttpStatusCode.NotFound) return NotFound(responseDTO);
        return Ok(responseDTO);
    }

    [HttpGet("{id_campeonato}")]
    public async Task<IActionResult> GetCampeonatosPorId(int id_campeonato)
    {
        var responseDTO = await _campeonatoService.GetCampeonatosPorId(id_campeonato);
        if(responseDTO.StatusCode == HttpStatusCode.NotFound) return NotFound(responseDTO);
        return Ok(responseDTO);
    }

    [HttpGet("{id_campeonato}/corridas")]
    public async Task<IActionResult> GetCampeonatosPorIdCorridas(int id_campeonato)
    {
        var responseDTO = await _campeonatoService.GetCampeonatosPorIdCorrida(id_campeonato);
        if(responseDTO.StatusCode == HttpStatusCode.NotFound) return NotFound(responseDTO);
        return Ok(responseDTO);
    }

    [HttpPost]
    public async Task<IActionResult> PostCampeonatos([FromBody]CreateCampeonatoDTO campeonatoDTO)
    {
        var responseDTO = await _campeonatoService.PostCampeonato(campeonatoDTO);
        if(responseDTO.StatusCode == HttpStatusCode.BadRequest)return BadRequest(responseDTO);
        return Ok(responseDTO);
    }

    [HttpDelete("{id_campeonato}")]
    public async Task<IActionResult> DeleteCampeonato(int id_campeonato)
    {
        var responseDTO = await _campeonatoService.DeleteCampeonato(id_campeonato);
        if(responseDTO.StatusCode == HttpStatusCode.BadRequest) return BadRequest(responseDTO);
        return Ok(responseDTO);
    }

    [HttpPut("{id_campeonato}")]
    public async Task<IActionResult> PutCampeonato(int id_campeonato, [FromBody]UpdateCampeonatoDTO campeonatoDTO)
    {
        var responseDTO = await _campeonatoService.PutCampeonato(id_campeonato, campeonatoDTO);
        if(responseDTO.StatusCode == HttpStatusCode.BadRequest) return BadRequest(responseDTO);
        return Ok(responseDTO);
    }
}