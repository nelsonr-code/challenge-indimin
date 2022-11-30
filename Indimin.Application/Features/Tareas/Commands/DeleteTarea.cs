using Indimin.Application.Helpers;
using MediatR;

namespace Indimin.Application.Features.Tareas.Commands;

public record DeleteTarea : IRequest<ResponseFormatting<Guid>>
{
    public Guid TareaId { get; set; }
}