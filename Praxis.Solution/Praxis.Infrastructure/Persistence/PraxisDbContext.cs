using Microsoft.EntityFrameworkCore;
using Praxis.Domain;
using Praxis.Domain.Entities;

namespace Praxis.Infrastructure.Persistence;

public class PraxisDbContext : DbContext
{
    public PraxisDbContext(
        DbContextOptions<PraxisDbContext> options)
        : base(options)
    {
    }

    public DbSet<Attendee> Attendees => Set<Attendee>();

    public DbSet<Event> Events => Set<Event>();

    public DbSet<EventType> EventTypes => Set<EventType>();

    public DbSet<EventAttendee> EventAttendees => Set<EventAttendee>();

    public DbSet<AttendanceStatus> AttendanceStatuses
        => Set<AttendanceStatus>();

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(PraxisDbContext).Assembly);
    }
}