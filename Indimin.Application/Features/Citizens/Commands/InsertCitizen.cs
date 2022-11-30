using Indimin.Application.Helpers;
using MediatR;

namespace Indimin.Application.Features.Citizens.Commands;

public record InsertCitizen : IRequest<ResponseFormatting<Guid>>
{
    public string Name { get; set; }
    public string Lastname { get; set; }

}