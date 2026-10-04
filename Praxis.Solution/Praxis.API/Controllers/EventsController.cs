using Microsoft.AspNetCore.Mvc;
using Praxis.Application.Events.CreateEvent;

namespace Praxis.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    #region Class Variables

    private readonly CreateEventService _createEventService;

    #endregion

    #region Constructor

    public EventsController(CreateEventService createEventService)
    {
        _createEventService = createEventService;
    }

    #endregion

    #region Public Methods

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Create([FromBody] CreateEventRequest request, CancellationToken cancellationToken)
    {
        var eventItem = await _createEventService.CreateAsync(request, cancellationToken);

        return CreatedAtAction(nameof(GetById),
                               new { id = eventItem.Id },
                               new {eventItem.Id,
                                    eventItem.Title,
                                    eventItem.Description,
                                    eventItem.Begin,
                                    eventItem.End,
                                    eventItem.EventTypeId});
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult GetById(int id)
    {
        // Placeholder for the next use case.
        return NotFound();
    }

    #endregion
}