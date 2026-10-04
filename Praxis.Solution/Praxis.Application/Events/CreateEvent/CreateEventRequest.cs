namespace Praxis.Application.Events.CreateEvent;

public class CreateEventRequest
{
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateTime Begin { get; set; }

    public DateTime End { get; set; }

    public int EventTypeId { get; set; }

    public List<int> AttendeeIds { get; set; } = new();

    public string CreatedBy { get; set; } = string.Empty;
}