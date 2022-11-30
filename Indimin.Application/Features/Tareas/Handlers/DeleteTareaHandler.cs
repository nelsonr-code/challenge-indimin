using Indimin.Application.Features.Tareas.Commands;
using Indimin.Application.Helpers;
using Indimin.Application.Interfaces;
using MediatR;
using Tarea = Indimin.Domain.Entities.Tareas;

namespace Indimin.Application.Features.Tareas.Handlers;

public class DeleteTareaHandler : IRequestHandler<DeleteTarea, ResponseFormatting<Guid>>
{
    private readonly IGenericRepository<Tarea> _tareaRepository;

    public DeleteTareaHandler(IGenericRepository<Tarea> repository)
    {
        _tareaRepository = repository;
    }
    
    public async Task<ResponseFormatting<Guid>> Handle(DeleteTarea request, CancellationToken cancellationToken)
    {
        var taskToDelete = await _tareaRepository.FindById(request.TareaId);
        
        if (taskToDelete == null) throw new KeyNotFoundException($"Task with id {request.TareaId} not found");
        
        _tareaRepository.Delete(taskToDelete);

        return new ResponseFormatting<Guid>("Task deleted successfully", 200, true);
    }
}