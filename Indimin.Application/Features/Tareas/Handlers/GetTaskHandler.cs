using AutoMapper;
using Indimin.Application.DTOs;
using Indimin.Application.Features.Tareas.Queries;
using Indimin.Application.Helpers;
using Indimin.Application.Interfaces;
using Tarea = Indimin.Domain.Entities.Tareas;
using MediatR;

namespace Indimin.Application.Features.Tareas.Handlers;

public class GetTareaHandler : IRequestHandler<GetTarea, ResponseFormatting<TareaDto>>
{
    private readonly IGenericRepository<Tarea> _citizenRepository;
    private readonly IMapper _mapper;

    public GetTareaHandler(IGenericRepository<Tarea> citizenRepository, IMapper mapper)
    {
        _citizenRepository = citizenRepository;
        _mapper = mapper;
    }

    public async Task<ResponseFormatting<TareaDto>> Handle(GetTarea request, CancellationToken cancellationToken)
    {
        var tareaFromDb = await _citizenRepository.FindById(request.TareaId);
        
        if (tareaFromDb == null) 
            throw new KeyNotFoundException($"Task with id {request.TareaId} not found");
        
        var tareaDto = _mapper.Map<TareaDto>(tareaFromDb);
        
        return await Task.FromResult(new ResponseFormatting<TareaDto>{ Data = tareaDto });
    }
}
