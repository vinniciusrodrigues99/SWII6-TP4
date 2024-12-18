using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vrumvrum.DTOs.PilotoDTO;
using vrumvrum.Interface;

namespace vrumvrum.Controllers;

[ApiController]
[Route("[Controller]")]
public class PilotoController : ControllerBase
{
    private readonly IPilotoService _pilotoService;
    public PilotoController(IPilotoService pilotoService)
    {
        _pilotoService = pilotoService;
    }

    [HttpGet]
    public async Task<IActionResult> Getpilotos()
    {
        var responseDTO = await _pilotoService.GetPilotos();
        if(responseDTO.StatusCode == HttpStatusCode.NotFound) return NotFound(responseDTO);
        return Ok(responseDTO);
    }

    [HttpGet("{id_piloto}")]
    public async Task<IActionResult> GetPilotoPorId(int id_piloto)
    {
        var responseDTO = await _pilotoService.GetPilotoPorId(id_piloto);
        if(responseDTO.StatusCode == HttpStatusCode.NotFound) return NotFound(responseDTO);
        return Ok(responseDTO);
    }

    [HttpPost]
    public async Task<IActionResult> PostPiloto([FromBody]CreatePilotoDTO pilotoDTO)
    {
        var responseDTO = await _pilotoService.PostPiloto(pilotoDTO);
        if(responseDTO.StatusCode == HttpStatusCode.BadRequest) return BadRequest(responseDTO);
        return Ok(responseDTO);
    }

    [HttpDelete("{id_piloto}")]
    public async Task<IActionResult> DeletePiloto(int id_piloto)
    {
        var responseDTO = await _pilotoService.DeletePiloto(id_piloto);
        if(responseDTO.StatusCode == HttpStatusCode.NotFound) return NotFound(responseDTO);
        return Ok(responseDTO);
    }

    [HttpPut("{id_piloto}")]
    public async Task<IActionResult> PutPiloto (int id_piloto, [FromBody]UpdatePilotoDTO pilotoDTO)
    {
        var responseDTO = await _pilotoService.PutPiloto(id_piloto, pilotoDTO);
        if(responseDTO.StatusCode == HttpStatusCode.BadRequest) return BadRequest(responseDTO);
        return Ok(responseDTO);
    }
}