using Microsoft.EntityFrameworkCore;
using Praxis.Application.Interfaces;
using Praxis.Domain.Entities;
using Praxis.Infrastructure.Persistence;

namespace Praxis.Infrastructure.Repositories;

public class EventRepository : IEventRepository
{
    private readonly PraxisDbContext _context;

    public EventRepository(PraxisDbContext context)
    {
        _context = context;
    }

    public async Task<Event?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Events.Include(x => x.EventType)
                                    .Include(x => x.EventAttendees)
                                        .ThenInclude(x => x.Attendee)
                                    .Include(x => x.EventAttendees)
                                        .ThenInclude(x => x.AttendanceStatus)
                                    .FirstOrDefaultAsync(x => x.Id == id,
                                                         cancellationToken);
    }

    public async Task<IReadOnlyCollection<Event>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Events.Include(x => x.EventType)
                                    .Include(x => x.EventAttendees)
                                        .ThenInclude(x => x.Attendee)
                                    .Include(x => x.EventAttendees)
                                        .ThenInclude(x => x.AttendanceStatus)
                                    .OrderBy(x => x.Begin)
                                    .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Event eventItem,CancellationToken cancellationToken = default)
    {
        await _context.Events.AddAsync(eventItem, cancellationToken);
    }

    public void Update(Event eventItem)
    {
        _context.Events.Update(eventItem);
    }

    public void Delete(Event eventItem)
    {
        _context.Events.Remove(eventItem);
    }

    public async Task SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}