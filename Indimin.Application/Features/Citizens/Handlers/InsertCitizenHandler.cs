using AutoMapper;
using Indimin.Application.Features.Citizens.Commands;
using Indimin.Application.Helpers;
using Indimin.Application.Interfaces;
using Indimin.Domain.Entities;
using MediatR;

namespace Indimin.Application.Features.Citizens.Handlers;

public class InsertCitizenHandler : IRequestHandler<InsertCitizen, ResponseFormatting<Guid>>
{
    private readonly IGenericRepository<Citizen> _repository;
    private readonly IMapper _mapper;

    public InsertCitizenHandler(IGenericRepository<Citizen> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseFormatting<Guid>> Handle(InsertCitizen request, CancellationToken cancellationToken)
    {
        // var citizen = new Citizen
        // {
        //     Name = request.Name,
        //     Lastname = request.Lastname,
        // };
        // _repository.Insert(citizen);

        var newCitizen = _mapper.Map<Citizen>(request);
        
        _repository.Insert(newCitizen);
        _repository.Save();
        
        return new ResponseFormatting<Guid>(newCitizen.Id, "Citizen created successfully", 200);
    }
}