using Indimin.Application.Helpers;
using MediatR;

namespace Indimin.Application.Features.Citizens.Commands;

public record DeleteCitizen : IRequest<ResponseFormatting<Guid>>
{
    public Guid CitizenId { get; set; }
}