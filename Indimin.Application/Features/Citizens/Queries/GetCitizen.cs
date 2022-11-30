using Indimin.Application.DTOs;
using Indimin.Application.Helpers;
using Indimin.Domain.Entities;
using MediatR;

namespace Indimin.Application.Features.Citizens.Queries;

public record GetCitizen : IRequest<ResponseFormatting<CitizenDto>>
{
    public Guid CitizenId { get; init; }
    // public bool IsDeleted { get; init; }
}