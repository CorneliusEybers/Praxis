using Praxis.Domain.Common;
using Praxis.Domain.Enums;

namespace Praxis.Domain.Entities;

public class EventAttendee : EntityBase
{
    public int EventId { get; private set; }

    public Event? Event { get; private set; }

    public int AttendeeId { get; private set; }

    public Attendee? Attendee { get; private set; }

    public AttendanceStatus AttendanceStatus { get; private set; }

    protected EventAttendee()
    {
    }

    public EventAttendee(
        int eventId,
        int attendeeId,
        string createdBy)
        : base(createdBy)
    {
        EventId = eventId;
        AttendeeId = attendeeId;
        AttendanceStatus = AttendanceStatus.Pending;
    }

    public void Accept(string updatedBy)
    {
        AttendanceStatus = AttendanceStatus.Accepted;
        MarkAsUpdated(updatedBy);
    }

    public void Reject(string updatedBy)
    {
        AttendanceStatus = AttendanceStatus.Rejected;
        MarkAsUpdated(updatedBy);
    }
}