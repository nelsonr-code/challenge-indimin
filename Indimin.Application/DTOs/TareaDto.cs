namespace Indimin.Application.DTOs;

public class TareaDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsCompleted { get; set; }
    public Guid CitizenId { get; set; }
}