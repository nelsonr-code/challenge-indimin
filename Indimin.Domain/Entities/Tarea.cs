using Indimin.Domain.Common;

namespace Indimin.Domain.Entities;

public class Tareas : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool? IsCompleted { get; set; }
    public Guid? CitizenId { get; set; }
    public Citizen? Citizen { get; set; }
}