using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Praxis.Domain.Entities;

namespace Praxis.Infrastructure.Persistence.Configurations;

public class AttendeeConfiguration
    : IEntityTypeConfiguration<Attendee>
{
    public void Configure(EntityTypeBuilder<Attendee> builder)
    {
        builder.ToTable("Attendees");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(x => x.Surname)
               .HasMaxLength(50);

        builder.Property(x => x.Email)
               .HasMaxLength(150)
               .IsRequired();

        builder.Property(x => x.Tel)
               .HasMaxLength(15);

        builder.Property(x => x.Cell)
               .HasMaxLength(15);
    }
}