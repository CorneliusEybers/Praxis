using Praxis.Application.Interfaces;
using Praxis.Domain.Entities;

namespace Praxis.Application.Events.CreateEvent;

public class CreateEventService
{
    private readonly IEventRepository _eventRepository;
    private readonly IAttendeeRepository _attendeeRepository;

    public CreateEventService(IEventRepository eventRepository,
                              IAttendeeRepository attendeeRepository)
    {
        _eventRepository = eventRepository;
        _attendeeRepository = attendeeRepository;
    }

    public async Task<Event> CreateAsync(CreateEventRequest request,CancellationToken cancellationToken = default)
    {
        var eventItem = new Event(request.Title,
                                  request.Description,
                                  request.Begin,
                                  request.End,
                                  request.EventTypeId,
                                  request.CreatedBy);

        foreach (var attendeeId in request.AttendeeIds.Distinct())
        {
            var attendee = await _attendeeRepository.GetByIdAsync(attendeeId, cancellationToken);

            if (attendee is null)
            {
                throw new InvalidOperationException($"Attendee with Id {attendeeId} was not found.");
            }

            eventItem.AddAttendee(attendee, request.CreatedBy);
        }

        await _eventRepository.AddAsync(eventItem, cancellationToken);

        await _eventRepository.SaveChangesAsync(cancellationToken);

        return eventItem;
    }
}