using Indimin.Application.Features.Citizens.Commands;
using Indimin.Application.Helpers;
using Indimin.Application.Interfaces;
using Indimin.Domain.Entities;
using MediatR;

namespace Indimin.Application.Features.Citizens.Handlers;

public class UpdateCitizenHandler : IRequestHandler<UpdateCitizen, ResponseFormatting<Guid>>
{
    private readonly IGenericRepository<Citizen> _repository;

    public UpdateCitizenHandler(IGenericRepository<Citizen> repository)
    {
        _repository = repository;
    }
    
    public async Task<ResponseFormatting<Guid>> Handle(UpdateCitizen request, CancellationToken cancellationToken)
    {
        var citizenDb = await _repository.FindById(request.CitizenId);
        
        if (citizenDb == null) throw new KeyNotFoundException($"Citizen with {request.CitizenId} not found");

        // var citizenToUpdate = new Citizen
        // {
        //     Name = request.Name,
        //     Lastname = request.LastName,
        // };

        citizenDb.Name = request.Name;
        citizenDb.Lastname = request.LastName;

        _repository.Update(citizenDb);

        return new ResponseFormatting<Guid>(citizenDb.Id, "Citizen updated successfully");
    }
}