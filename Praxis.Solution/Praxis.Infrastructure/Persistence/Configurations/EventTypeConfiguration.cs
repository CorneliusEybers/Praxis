using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Praxis.Domain.Entities;

namespace Praxis.Infrastructure.Persistence.Configurations;

public class EventTypeConfiguration : IEntityTypeConfiguration<EventType>
{
    public void Configure(EntityTypeBuilder<EventType> builder)
    {
        builder.ToTable("EventTypes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code)
               .HasMaxLength(10)
               .IsRequired();

        builder.Property(x => x.Name)
               .HasMaxLength(25)
               .IsRequired();

        builder.Property(x => x.Description)
               .HasMaxLength(250);
    }
}