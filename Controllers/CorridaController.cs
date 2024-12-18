using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vrumvrum.Interface;
using vrumvrum.DTOs.CorridaDTO;

namespace vrumvrum.Controllers;

[ApiController]
[Route("[Controller]")]
public class CorridaController : ControllerBase
{
    private readonly ICorridaService _corridaService;
    public CorridaController(ICorridaService corridaService)
    {
        _corridaService = corridaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCorridas()
    {
        var responseDTO = await _corridaService.GetCorridas();
        if(responseDTO.StatusCode == HttpStatusCode.NotFound) return NotFound(responseDTO);
        return Ok(responseDTO);
    }

    [HttpGet("{id_corrida}")]
    public async Task<IActionResult> GetCorridasPorId(int id_corrida)
    {
        var responseDTO = await _corridaService.GetCorridaPorId(id_corrida);
        if(responseDTO.StatusCode == HttpStatusCode.NotFound) return NotFound(responseDTO);
        return Ok(responseDTO);
    }

    [HttpPost]
    public async Task<IActionResult> PostCorrida([FromBody]CreateCorridaDTO corridaDTO)
    {
        var responseDTO = await _corridaService.PostCorrida(corridaDTO);
        if(responseDTO.StatusCode == HttpStatusCode.BadRequest) return BadRequest(responseDTO);
        return Ok(responseDTO);
    }

    [HttpDelete("{id_corrida}")]
    public async Task<IActionResult> DeleteCorrida(int id_corrida)
    {
        var responseDTO = await _corridaService.DeleteCorrida(id_corrida);
        if(responseDTO.StatusCode == HttpStatusCode.NotFound) return NotFound(responseDTO);
        return Ok(responseDTO);
    }

    [HttpPut("{id_corrida}")]
    public async Task<IActionResult> PutCorrida (int id_corrida, [FromBody]UpdateCorridaDTO corridaDTO)
    {
        var responseDTO = await _corridaService.PutCorrida(id_corrida, corridaDTO);
        if(responseDTO.StatusCode == HttpStatusCode.BadRequest) return BadRequest(responseDTO);
        return Ok(responseDTO);
    }
}