using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Praxis.Domain.Entities;

namespace Praxis.Infrastructure.Persistence.Configurations;

public class EventAttendeeConfiguration
    : IEntityTypeConfiguration<EventAttendee>
{
    public void Configure(EntityTypeBuilder<EventAttendee> builder)
    {
        builder.ToTable("EventAttendees");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Event)
               .WithMany(x => x.EventAttendees)
               .HasForeignKey(x => x.EventId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Attendee)
               .WithMany(x => x.EventAttendees)
               .HasForeignKey(x => x.AttendeeId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.AttendanceStatus)
               .WithMany()
               .HasForeignKey(x => x.AttendanceStatusId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new {
                                       x.EventId,
                                       x.AttendeeId
                                  })
               .IsUnique();
    }
}