using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CopaBackend.Domain;
using CopaBackend.Service;
using Microsoft.AspNetCore.Mvc;


namespace CopaBackend.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class CopaController : ControllerBase
    {
        [Route("")]
        [HttpGet]

        //Retorna a lista de equipes do serviço externo
        public async Task<IActionResult> Get([FromServices] ITeamService service)
        {
            return StatusCode(200, await service.GetTeamsAsync());
        }

        [Route("")]
        [HttpPost]

        //Recebe a lista dos 8 times e retorna os 2 ganhadores
        public IActionResult Post([FromBody] List<Team> teams)
        {
            try
            {
                return StatusCode(200, Team.GenerateCup(teams));
            }
            catch (Exception err)
            {
                return BadRequest(new { ErrorMessage = err.Message });
            }
        }
    }
}
