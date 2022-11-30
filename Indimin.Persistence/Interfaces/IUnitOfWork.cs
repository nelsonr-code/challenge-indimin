namespace Indimin.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ICitizenRepository Citizens { get; }
    void SaveChanges();
    Task SaveChangesAsync();
}
