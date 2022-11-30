using AutoMapper;
using Indimin.Application.DTOs;
using Indimin.Application.Features.Citizens.Queries;
using Indimin.Application.Helpers;
using Indimin.Application.Interfaces;
using Indimin.Domain.Entities;
using MediatR;

namespace Indimin.Application.Features.Citizens.Handlers;

public class GetCitizenHandler : IRequestHandler<GetCitizen, ResponseFormatting<CitizenDto>>
{
    private readonly IGenericRepository<Citizen> _citizenRepository;
    private readonly IMapper _mapper;

    public GetCitizenHandler(IGenericRepository<Citizen> citizenRepository, IMapper mapper)
    {
        _citizenRepository = citizenRepository;
        _mapper = mapper;
    }

    public async Task<ResponseFormatting<CitizenDto>> Handle(GetCitizen request, CancellationToken cancellationToken)
    {
        var citizenFromDb = await _citizenRepository.FindById(request.CitizenId);
        
        if (citizenFromDb == null) 
            throw new KeyNotFoundException($"Citizen with id {request.CitizenId} not found");
        
        var citizenDto = _mapper.Map<CitizenDto>(citizenFromDb);
        
        return await Task.FromResult(new ResponseFormatting<CitizenDto>(citizenDto, "Citizen found"));
    }
}
