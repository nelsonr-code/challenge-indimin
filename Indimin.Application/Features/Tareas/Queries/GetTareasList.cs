using Indimin.Application.DTOs;
using Indimin.Application.Helpers;
using MediatR;

namespace Indimin.Application.Features.Tareas.Queries;

public record GetTareasList : IRequest<ResponseFormatting<IEnumerable<TareaDto>>>
{
    
}