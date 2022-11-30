using Indimin.Application.Features.Citizens.Commands;
using Indimin.Application.Features.Citizens.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Indimin.API.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class CitizenController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CitizenController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        // POST: api/Citizen
        /// <summary>
        /// Creating a new citizen
        /// </summary>
        /// <response code="200">citizen created successfully </response>
        /// <returns></returns>
        [HttpPost("add/")]
        public async Task<IActionResult> CreateCitizen(InsertCitizen newCitizen)
        {
            return Ok(await _mediator.Send(newCitizen));
        }

        // GET: api/Citizen
        /// <summary>
        /// Get Citizen by id
        /// </summary>
        /// <response code="200">citizen found </response>
        /// <response code="404">citizen not found </response>
        /// <returns></returns>
        [HttpGet("show/{citizenId:guid}")]
        public async Task<IActionResult> GetCitizenById(Guid citizenId)
        {
            return Ok(await _mediator.Send(new GetCitizen { CitizenId = citizenId }));
        }

        // GET: api/Citizen/List
        /// <summary>
        /// Get Citizen list
        /// </summary>
        /// <response code="200">List all citizens</response>
        /// <response code="404"></response>
        /// <returns></returns>
        [HttpGet("list/", Name = "Get")]
        public async Task<IActionResult> GetAllCitizens()
        {
            return Ok(await _mediator.Send(new GetCitizenList()));
        }
        
        // PUT: api/Citizen/5
        /// <summary>
        /// Update citizen info
        /// </summary>
        /// <response code="200">Citizen updated</response>
        /// <returns></returns>
        [HttpPut("edit/{citizenId:guid}")]
        public async Task<IActionResult> UpdateCitizen(Guid citizenId, UpdateCitizen citizenToUpdate)
        {
            if (citizenId != citizenToUpdate.CitizenId) return BadRequest();

            return Ok(await _mediator.Send(citizenToUpdate));
        }

        // DELETE: api/Citizen/5
        /// <summary>
        /// Delete an citizen
        /// </summary>
        /// <response code="200">Citizen deleted</response>
        /// <response code="404">Citizen not found</response>
        /// <returns></returns>
        [HttpDelete("delete/{citizenId:guid}")]
        public async Task<IActionResult> DeleteCitizen(Guid citizenId)
        {
            return Ok(await _mediator.Send(new DeleteCitizen() { CitizenId = citizenId }));
        }
    }
}
