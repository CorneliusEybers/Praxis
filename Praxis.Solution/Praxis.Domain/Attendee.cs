using Praxis.Domain.Common;

namespace Praxis.Domain.Entities;

public class Attendee : EntityBase
{
    public string Name { get; private set; } = string.Empty;

    public string? Surname { get; private set; }

    public string Email { get; private set; } = string.Empty;

    public string? Tel { get; private set; }

    public string? Cell { get; private set; }

    public ICollection<EventAttendee> EventAttendees { get; private set; }
        = new List<EventAttendee>();

    protected Attendee()
    {
    }

    public Attendee(
        string name,
        string? surname,
        string email,
        string? tel,
        string? cell,
        string createdBy)
        : base(createdBy)
    {
        Name = name;
        Surname = surname;
        Email = email;
        Tel = tel;
        Cell = cell;
    }
}