using AutoMapper;
using Indimin.Application.DTOs;
using Indimin.Application.Exceptions;
using Indimin.Application.Features.Citizens.Queries;
using Indimin.Application.Features.Tareas.Queries;
using Indimin.Application.Helpers;
using Indimin.Application.Interfaces;
using Tarea = Indimin.Domain.Entities.Tareas;
using MediatR;

namespace Indimin.Application.Features.Tareas.Handlers;

public class GetTareasListHandler : IRequestHandler<GetTareasList, ResponseFormatting<IEnumerable<TareaDto>>>
{
    private readonly IGenericRepository<Tarea> _tareaRepository;
    private readonly IMapper _mapper;

    public GetTareasListHandler(IGenericRepository<Tarea> tareaRepository, IMapper mapper)
    {
        _tareaRepository = tareaRepository;
        _mapper = mapper;
    }

    public async Task<ResponseFormatting<IEnumerable<TareaDto>>> Handle(GetTareasList request, CancellationToken cancellationToken)
    {
        // var tareasListFromDb = _tareaRepository.FindByCondition(t => t.IsDeleted == false);
        var tareasListFromDb = await _tareaRepository.FindAll();
        
        if (tareasListFromDb == null)
            throw new ApiException("No tasks were found");
        
        var tareaDto = _mapper.Map<IEnumerable<TareaDto>>(tareasListFromDb);
        
        return await Task.FromResult(new ResponseFormatting<IEnumerable<TareaDto>>
        {
            Data = tareaDto,
            Message = "Request successfully",
            Success = true,
            StatusCode = 200
            
        });
    }
}
