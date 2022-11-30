using Indimin.Application.Helpers;
using MediatR;

namespace Indimin.Application.Features.Tareas.Commands;

public record InsertTarea : IRequest<ResponseFormatting<Guid>>
{
    public string Name { get; set; }
    public string Description { get; set; }
    // public DateTime CreatedAt { get; set; }
    public bool? IsCompleted { get; set; }
    public Guid? CitizenId { get; set; }
}