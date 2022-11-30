using Indimin.Domain.Entities;

namespace Indimin.Application.DTOs;

public class CitizenDto
{
    public Guid Id { get; set; } 
    public string? Name { get; set; }
    public string? Lastname { get; set; }
    public ICollection<Tareas> Tareas { get; set; }

}