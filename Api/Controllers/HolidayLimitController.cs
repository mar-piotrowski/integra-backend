using Application.Dtos;
using Application.Features.HolidayLimit.Command;
using Application.Features.HolidayLimit.Query;
using Domain.Result;
using Domain.ValueObjects.Ids;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntegraBackend.Controllers;

[Route("/integra/holiday-limits")]
[ApiController]
public class HolidayLimitController : ControllerBase {
    private readonly ISender _sender;

    public HolidayLimitController(ISender sender) {
        _sender = sender;
    }
    
    [HttpGet]
    public async Task<ActionResult> GetAll([FromQuery] HolidayLimitsQueries queries) {
        var result = await _sender.Send(new GetHolidayLimitsQuery(queries));
        return result.MapResult();
    }

    [HttpGet("{holidayLimitId:int}")]
    public async Task<ActionResult> Get(int holidayLimitId) {
        var result = await _sender.Send(new GetHolidayLimitQuery(HolidayLimitId.Create(holidayLimitId)));
        return result.MapResult();
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateHolidayLimitRequest request) {
        var result = await _sender.Send(new CreateHolidayLimitCommand(
            UserId.Create(request.UserId),
            request.Current,
            request.StartDate,
            request.EndDate,
            request.Description
        ));
        return result.MapResult();
    }

    [HttpPut]
    public Task<ActionResult> Update() {
        throw new NotImplementedException();
    }
}