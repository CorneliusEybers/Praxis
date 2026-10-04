using Praxis.Domain.Entities;

namespace Praxis.Application.Interfaces;

public interface IEventRepository
{
    Task<Event?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<Event>> GetAllAsync(CancellationToken cancellationToken = default);

    Task AddAsync(Event eventItem, CancellationToken cancellationToken = default);

    void Update(Event eventItem);

    void Delete(Event eventItem);

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}