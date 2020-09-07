using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaBackend.Domain;
using CopaBackend.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CopaBackend.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class CopaController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] ITeamService service)
        {
            return StatusCode(200, await service.GetTeamsAsync());
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<Team> teams)
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
