using Praxis.Application.Interfaces;

namespace Praxis.Application.Events.GetEventById;

public class GetEventByIdService
{
    private readonly IEventRepository _eventRepository;

    public GetEventByIdService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<GetEventByIdResponse?> GetAsync(int id,
                                                      CancellationToken cancellationToken = default)
    {
        var eventItem = await _eventRepository.GetByIdAsync(id, cancellationToken);

        if (eventItem is null)
        {
            return null;
        }

        return new GetEventByIdResponse
        {
            Id = eventItem.Id,
            Title = eventItem.Title,
            Description = eventItem.Description,
            Begin = eventItem.Begin,
            End = eventItem.End,
            EventTypeId = eventItem.EventTypeId,
            EventTypeName = eventItem.EventType?.Name ?? string.Empty,

            Attendees = eventItem.EventAttendees.Select(x => new GetEventAttendeeResponse
                                                             {
                                                                 AttendeeId = x.AttendeeId,
                                                                 Name = x.Attendee?.Name ?? string.Empty,
                                                                 Surname = x.Attendee?.Surname,
                                                                 Email = x.Attendee?.Email ?? string.Empty,
                                                                 AttendanceStatusId = x.AttendanceStatusId,
                                                                 AttendanceStatusName = x.AttendanceStatus?.Name ?? string.Empty
                                                             })
                                                .ToList()
        };
    }
}