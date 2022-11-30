using AutoMapper;
using Indimin.Application.DTOs;
using Indimin.Application.Features.Citizens.Queries;
using Indimin.Application.Helpers;
using Indimin.Application.Interfaces;
using Indimin.Domain.Entities;
using MediatR;

namespace Indimin.Application.Features.Citizens.Handlers;

public class GetCitizenListHandler : IRequestHandler<GetCitizenList, ResponseFormatting<IEnumerable<CitizenDto>>>
{
    private readonly IGenericRepository<Citizen> _citizenRepository;
    private readonly IMapper _mapper;

    public GetCitizenListHandler(IGenericRepository<Citizen> citizenRepository, IMapper mapper)
    {
        _citizenRepository = citizenRepository;
        _mapper = mapper;
    }
    
    public async Task<ResponseFormatting<IEnumerable<CitizenDto>>> Handle(GetCitizenList request,
        CancellationToken cancellationToken)
    {
        // var citizenList = _citizenRepository.FindByCondition(c => c.IsDeleted == false);
        var citizenList = await _citizenRepository.FindAll();
        var citizenDtoList = _mapper.Map<IEnumerable<CitizenDto>>(citizenList);

        return await Task.FromResult(new ResponseFormatting<IEnumerable<CitizenDto>>
            { Data = citizenDtoList, Success = true, StatusCode = 200, Message = "request successfully"});
    }
}