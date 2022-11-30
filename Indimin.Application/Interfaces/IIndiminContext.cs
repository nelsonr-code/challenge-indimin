using Indimin.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Indimin.Application.Interfaces;

public interface IIndiminContext
{
    DbSet<Citizen> Citizens { get; set; }
    DbSet<Tareas> Tareas { get; set; }
}