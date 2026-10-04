using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Praxis.Domain.Entities;

namespace Praxis.Infrastructure.Persistence.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Events");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(x => x.Description)
               .HasMaxLength(250);

        builder.Property(x => x.Begin)
               .IsRequired();

        builder.Property(x => x.End)
               .IsRequired();

        builder.HasOne(x => x.EventType)
               .WithMany(x => x.Events)
               .HasForeignKey(x => x.EventTypeId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}