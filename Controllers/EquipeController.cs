using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vrumvrum.Interface;
using vrumvrum.DTOs.EquipeDTO;

namespace vrumvrum.Controllers;

[ApiController]
[Route("[Controller]")]
public class EquipeController : ControllerBase
{
    private readonly IEquipeService _equipeService;
    public EquipeController(IEquipeService equipeService)
    {
        _equipeService = equipeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetEquipes()
    {
        var responseDTO = await _equipeService.GetEquipes();
        if(responseDTO.StatusCode == HttpStatusCode.NotFound) return NotFound(responseDTO);
        return Ok(responseDTO);
    }

    [HttpGet("{id_equipe}")]
    public async Task<IActionResult> GetEquipePorId(int id_equipe)
    {
        var responseDTO = await _equipeService.GetEquipePorId(id_equipe);
        if(responseDTO.StatusCode == HttpStatusCode.NotFound) return NotFound(responseDTO);
        return Ok(responseDTO);
    }

    [HttpPost]
    public async Task<IActionResult> PostEquipe([FromBody]CreateEquipeDTO equipeDTO)
    {
        var responseDTO = await _equipeService.PostEquipe(equipeDTO);
        if(responseDTO.StatusCode == HttpStatusCode.BadRequest) return BadRequest(responseDTO);
        return Ok(responseDTO);
    }

    [HttpDelete("{id_equipe}")]
    public async Task<IActionResult> DeleteEquipe(int id_equipe)
    {
        var responseDTO = await _equipeService.DeleteEquipe(id_equipe);
        if(responseDTO.StatusCode == HttpStatusCode.NotFound) return NotFound(responseDTO);
        return Ok(responseDTO);
    }

    [HttpPut("{id_equipe}")]
    public async Task<IActionResult> PutEquipe(int id_equipe, [FromBody]UpdateEquipeDTO equipeDTO)
    {
        var responseDTO = await _equipeService.PutEquipe(id_equipe, equipeDTO);
        if(responseDTO.StatusCode == HttpStatusCode.BadRequest) return BadRequest(responseDTO);
        return Ok(responseDTO);
    }
}