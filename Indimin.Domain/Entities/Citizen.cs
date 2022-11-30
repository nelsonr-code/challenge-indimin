using Indimin.Domain.Common;

namespace Indimin.Domain.Entities;

public class Citizen : BaseEntity
{
    public string? Name { get; set; }
    public string? Lastname { get; set; }
    public ICollection<Tareas> Tareas { get; set; }
}