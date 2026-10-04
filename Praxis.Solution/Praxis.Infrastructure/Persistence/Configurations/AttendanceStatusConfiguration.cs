using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Praxis.Domain.Entities;

namespace Praxis.Infrastructure.Persistence.Configurations;

public class AttendanceStatusConfiguration
    : IEntityTypeConfiguration<AttendanceStatus>
{
    public void Configure(EntityTypeBuilder<AttendanceStatus> builder)
    {
        builder.ToTable("AttendanceStatus");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code)
               .HasMaxLength(10)
               .IsRequired();

        builder.Property(x => x.Name)
               .HasMaxLength(25)
               .IsRequired();

        builder.Property(x => x.Description)
               .HasMaxLength(250);

        builder.HasData(new {
                                Id = 1,
                                Code = "PEN",
                                Name = "Pending",
                                Description = "Awaiting attendee response",
                                CreatedBy = "SYSTEM",
                                CreatedDateTime = new DateTime(
                                    2026, 1, 1, 0, 0, 0,
                                    DateTimeKind.Utc)
                            },
                            new
                            {
                                Id = 2,
                                Code = "ACC",
                                Name = "Accepted",
                                Description = "Attendee accepted the event",
                                CreatedBy = "SYSTEM",
                                CreatedDateTime = new DateTime(
                                    2026, 1, 1, 0, 0, 0,
                                    DateTimeKind.Utc)
                            },
                            new
                            {
                                Id = 3,
                                Code = "REJ",
                                Name = "Rejected",
                                Description = "Attendee rejected the event",
                                CreatedBy = "SYSTEM",
                                CreatedDateTime = new DateTime(
                                    2026, 1, 1, 0, 0, 0,
                                    DateTimeKind.Utc)
                            });
    }
}