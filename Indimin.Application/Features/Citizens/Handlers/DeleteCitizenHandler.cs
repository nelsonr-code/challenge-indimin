using Indimin.Application.Features.Citizens.Commands;
using Indimin.Application.Helpers;
using Indimin.Application.Interfaces;
using Indimin.Domain.Entities;
using MediatR;

namespace Indimin.Application.Features.Citizens.Handlers;

public class DeleteCitizenHandler : IRequestHandler<DeleteCitizen, ResponseFormatting<Guid>>
{
    private readonly IGenericRepository<Citizen> _repository;

    public DeleteCitizenHandler(IGenericRepository<Citizen> repository)
    {
        _repository = repository;
    }
    
    public async Task<ResponseFormatting<Guid>> Handle(DeleteCitizen request, CancellationToken cancellationToken)
    {
        var citizen = await _repository.FindById(request.CitizenId);
        
        if (citizen == null) throw new KeyNotFoundException($"Citizen with id {request.CitizenId} not found");
        
        _repository.Delete(citizen);

        return new ResponseFormatting<Guid>("Citizen deleted successfully", 200, true);
    }
}