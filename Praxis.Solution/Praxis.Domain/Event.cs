using Praxis.Domain.Common;

namespace Praxis.Domain.Entities;

public class Event : EntityBase
{
    #region Properties

    public string Title { get; private set; } = string.Empty;

    public string? Description { get; private set; }

    public DateTime Begin { get; private set; }

    public DateTime End { get; private set; }

    public int EventTypeId { get; private set; }

    public EventType? EventType { get; private set; }

    public ICollection<EventAttendee> EventAttendees { get; private set; } = new List<EventAttendee>();

    #endregion

    #region Constructor

    protected Event()
    {
    }

    public Event(string title,
                string? description,
                DateTime begin,
                DateTime end,
                int eventTypeId,
                string createdBy) : base(createdBy)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Event title is required.", nameof(title));
        }

        if (end <= begin)
        {
            throw new ArgumentException("Event end time must be after the begin time.", nameof(end));
        }

        Title = title;
        Description = description;
        Begin = begin;
        End = end;
        EventTypeId = eventTypeId;
    }

    #endregion

    #region Public Methods

    public void UpdateDetails(string title,
                              string? description,
                              DateTime begin,
                              DateTime end,
                              int eventTypeId,
                              string updatedBy)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Event title is required.", nameof(title));
        }

        if (end <= begin)
        {
            throw new ArgumentException("Event end time must be after the begin time.", nameof(end));
        }

        Title = title;
        Description = description;
        Begin = begin;
        End = end;
        EventTypeId = eventTypeId;

        MarkAsUpdated(updatedBy);
    }

    public void AddAttendee(Attendee attendee,
                            string createdBy)
    {
        ArgumentNullException.ThrowIfNull(attendee);

        if (EventAttendees.Any(x => x.AttendeeId == attendee.Id))
        {
            throw new InvalidOperationException($"Attendee '{attendee.Id}' has already been added to this event.");
        }

        EventAttendees.Add(new EventAttendee(attendee, createdBy));
    }

    #endregion

    #region Private Methods

    #endregion
}