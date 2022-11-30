using Indimin.Application.Helpers;
using MediatR;

namespace Indimin.Application.Features.Citizens.Commands;

public record UpdateCitizen : IRequest<ResponseFormatting<Guid>>
{
    public Guid CitizenId { get; init; }
    public string Name { get; init; }
    public string LastName { get; init; }

}