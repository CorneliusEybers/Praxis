using Microsoft.EntityFrameworkCore;
using Praxis.Application.Interfaces;
using Praxis.Domain.Entities;
using Praxis.Infrastructure.Persistence;

namespace Praxis.Infrastructure.Repositories;

public class AttendeeRepository : IAttendeeRepository
{
    private readonly PraxisDbContext _context;

    public AttendeeRepository(PraxisDbContext context)
    {
        _context = context;
    }

    public async Task<Attendee?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        return await _context.Attendees.Include(x => x.EventAttendees)
                                           .ThenInclude(x => x.Event)
                                       .FirstOrDefaultAsync(x => x.Id == id,
                                                            cancellationToken);
    }

    public async Task<IReadOnlyCollection<Attendee>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Attendees.OrderBy(x => x.Surname)
                                       .ThenBy(x => x.Name)
                                       .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Attendee attendee,
                               CancellationToken cancellationToken = default)
    {
        await _context.Attendees.AddAsync(attendee,
                                          cancellationToken);
    }

    public void Update(Attendee attendee)
    {
        _context.Attendees.Update(attendee);
    }

    public void Delete(Attendee attendee)
    {
        _context.Attendees.Remove(attendee);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}