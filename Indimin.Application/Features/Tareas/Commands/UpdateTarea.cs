using Indimin.Application.Helpers;
using MediatR;

namespace Indimin.Application.Features.Tareas.Commands;

public record UpdateTarea : IRequest<ResponseFormatting<Guid>>
{
    public Guid TaskId { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public Guid CitizenId { get; set; }

}