using Praxis.Domain.Entities;

namespace Praxis.Application.Interfaces;

public interface IAttendeeRepository
{
    Task<Attendee?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<Attendee>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task AddAsync(
        Attendee attendee,
        CancellationToken cancellationToken = default);

    void Update(Attendee attendee);

    void Delete(Attendee attendee);

    Task SaveChangesAsync(
        CancellationToken cancellationToken = default);
}