namespace Praxis.Application.Events.GetEventById;

public class GetEventByIdResponse
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateTime Begin { get; set; }

    public DateTime End { get; set; }

    public int EventTypeId { get; set; }

    public string EventTypeName { get; set; } = string.Empty;

    public List<GetEventAttendeeResponse> Attendees { get; set; } = new();
}

public class GetEventAttendeeResponse
{
    public int AttendeeId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Surname { get; set; }

    public string Email { get; set; } = string.Empty;

    public int AttendanceStatusId { get; set; }

    public string AttendanceStatusName { get; set; } = string.Empty;
}