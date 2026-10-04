using Praxis.Domain.Common;

namespace Praxis.Domain.Entities;

public class EventType : EntityBase
{
    public string Name { get; private set; } = string.Empty;

    public string? Description { get; private set; }

    public ICollection<Event> Events { get; private set; }
        = new List<Event>();

    protected EventType()
    {
    }

    public EventType(
        string name,
        string? description,
        string createdBy)
        : base(createdBy)
    {
        Name = name;
        Description = description;
    }
}