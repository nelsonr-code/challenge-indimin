using Indimin.Application.Features.Tareas.Commands;
using Indimin.Application.Features.Tareas.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Indimin.API.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        // POST: api/Tarea
        /// <summary>
        /// Creating a new tarea
        /// </summary>
        /// <response code="200">tarea created successfully </response>
        /// <returns></returns>
        [HttpPost("add/")]
        public async Task<IActionResult> CreateTarea(InsertTarea newTarea)
        {
            return Ok(await _mediator.Send(newTarea));
        }

        // GET: api/Tarea
        /// <summary>
        /// Get Tarea by id
        /// </summary>
        /// <response code="200">tarea found </response>
        /// <response code="404">tarea not found </response>
        /// <returns></returns>
        [HttpGet("show/{tareaId:guid}")]
        public async Task<IActionResult> GetTareaById(Guid tareaId)
        {
            return Ok(await _mediator.Send(new GetTarea { TareaId = tareaId }));
        }

        // GET: api/Tarea/List
        /// <summary>
        /// Get Tarea list
        /// </summary>
        /// <response code="200">List all tareas</response>
        /// <response code="404"></response>
        /// <returns></returns>
        [HttpGet("list/", Name = "GetAllTareas")]
        public async Task<IActionResult> GetAllTareas()
        {
            return Ok(await _mediator.Send(new GetTareasList()));
        }
        
        // PUT: api/Tarea/5
        /// <summary>
        /// Update tarea info
        /// </summary>
        /// <response code="200">Tarea updated</response>
        /// <returns></returns>
        [HttpPut("edit/{tareaId:guid}")]
        public async Task<IActionResult> UpdateTarea(Guid tareaId, UpdateTarea tareaToUpdate)
        {
            if (tareaId != tareaToUpdate.TaskId) return BadRequest();

            return Ok(await _mediator.Send(tareaToUpdate));
        }

        // DELETE: api/Tarea/5
        /// <summary>
        /// Delete an tarea
        /// </summary>
        /// <response code="200">Tarea deleted</response>
        /// <response code="404">Tarea not found</response>
        /// <returns></returns>
        [HttpDelete("delete/{tareaId:guid}")]
        public async Task<IActionResult> DeleteTarea(Guid tareaId)
        {
            return Ok(await _mediator.Send(new DeleteTarea() { TareaId = tareaId }));
        }
    }
}
