using AutoMapper;
using Indimin.Application.Features.Tareas.Commands;
using Indimin.Application.Helpers;
using Indimin.Application.Interfaces;
using Tarea = Indimin.Domain.Entities.Tareas;
using MediatR;

namespace Indimin.Application.Features.Tareas.Handlers;

public class InsertTareaHandler : IRequestHandler<InsertTarea, ResponseFormatting<Guid>>
{
    private readonly IGenericRepository<Tarea> _tareaRepository;
    private readonly IMapper _mapper;

    public InsertTareaHandler(IGenericRepository<Tarea> repository, IMapper mapper)
    {
        _tareaRepository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseFormatting<Guid>> Handle(InsertTarea request, CancellationToken cancellationToken)
    {

        var newTarea = _mapper.Map<Tarea>(request);
        
        _tareaRepository.Insert(newTarea);
        _tareaRepository.Save();
        
        return new ResponseFormatting<Guid>(newTarea.Id, "Task created successfully", 200);
    }
}