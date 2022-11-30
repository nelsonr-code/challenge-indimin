using Indimin.Application.DTOs;
using Indimin.Application.Helpers;
using MediatR;

namespace Indimin.Application.Features.Citizens.Queries;

public record GetCitizenList : IRequest<ResponseFormatting<IEnumerable<CitizenDto>>>
{
    public bool IsDeleted { get; init; }

}