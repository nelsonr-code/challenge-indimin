using Indimin.Application.Features.Tareas.Commands;
using Indimin.Application.Helpers;
using Indimin.Application.Interfaces;
using Indimin.Domain.Entities;
using MediatR;
using Tarea = Indimin.Domain.Entities.Tareas;

namespace Indimin.Application.Features.Tareas.Handlers;

public class UpdateTareaHandler : IRequestHandler<UpdateTarea, ResponseFormatting<Guid>>
{
    private readonly IGenericRepository<Tarea> _tareaRepository;

    public UpdateTareaHandler(IGenericRepository<Tarea> repository)
    {
        _tareaRepository = repository;
    }
    
    public async Task<ResponseFormatting<Guid>> Handle(UpdateTarea request, CancellationToken cancellationToken)
    {
        var taskFromDb = await _tareaRepository.FindById(request.TaskId);
        
        if (taskFromDb == null) throw new KeyNotFoundException($"Task with {request.TaskId} not found");

        // var taskToUpdate = new Tarea()
        // {
        //     Name = request.Name,
        //     Description = request.Description,
        //     CitizenId = request.CitizenId
        // };
        
        taskFromDb.Name = request.Name;
        taskFromDb.Description = request.Description;
        taskFromDb.CitizenId = request.CitizenId;

        
        _tareaRepository.Update(taskFromDb);

        return new ResponseFormatting<Guid>(taskFromDb.Id, "Task updated successfully");
    }
}