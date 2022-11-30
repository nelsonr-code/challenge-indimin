using Indimin.Application.DTOs;
using Indimin.Application.Helpers;
using MediatR;

namespace Indimin.Application.Features.Tareas.Queries;

public record GetTarea : IRequest<ResponseFormatting<TareaDto>>
{
    public Guid TareaId { get; init; }
    // public bool IsDeleted { get; init; }
}