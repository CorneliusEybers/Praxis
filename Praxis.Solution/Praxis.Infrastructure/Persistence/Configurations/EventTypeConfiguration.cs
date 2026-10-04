using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Praxis.Domain.Entities;

namespace Praxis.Infrastructure.Persistence.Configurations;

public class EventTypeConfiguration : IEntityTypeConfiguration<EventType>
{
    public void Configure(EntityTypeBuilder<EventType> builder)
    {
        builder.ToTable("EventType");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code)
               .HasMaxLength(10)
               .IsRequired();

        builder.Property(x => x.Name)
               .HasMaxLength(25)
               .IsRequired();

        builder.Property(x => x.Description)
               .HasMaxLength(250);

        builder.HasData(
                new
                {
                    Id = 1,
                    Code = "CON",
                    Name = "Consultation",
                    Description = "General consultation or patient appointment.",
                    CreatedBy = "SYSTEM",
                    CreatedDateTime = DateTime.MinValue
                },
                new
                {
                    Id = 2,
                    Code = "FUP",
                    Name = "Follow-up",
                    Description = "Follow-up appointment relating to an earlier consultation or treatment.",
                    CreatedBy = "SYSTEM",
                    CreatedDateTime = DateTime.MinValue
                },
                new
                {
                    Id = 3,
                    Code = "PRO",
                    Name = "Procedure",
                    Description = "Clinical procedure or treatment appointment.",
                    CreatedBy = "SYSTEM",
                    CreatedDateTime = DateTime.MinValue
                },
                new
                {
                    Id = 4,
                    Code = "ADM",
                    Name = "Administration",
                    Description = "Administrative or non-clinical scheduled activity.",
                    CreatedBy = "SYSTEM",
                    CreatedDateTime = DateTime.MinValue
                },
                new
                {
                    Id = 5,
                    Code = "MTG",
                    Name = "Meeting",
                    Description = "Internal or external meeting.",
                    CreatedBy = "SYSTEM",
                    CreatedDateTime = DateTime.MinValue
                },
                new
                {
                    Id = 6,
                    Code = "OTH",
                    Name = "Other",
                    Description = "Any scheduled event not covered by the defined event types.",
                    CreatedBy = "SYSTEM",
                    CreatedDateTime = DateTime.MinValue
                });
    }
}