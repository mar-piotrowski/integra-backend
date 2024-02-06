using Application.Dtos;
using Application.Features.HolidayLimit.CreateHolidayLimit;
using Application.Features.HolidayLimit.GetHolidayLimits;
using Application.Features.HolidayLimit.GetHolidayLimt;
using Domain.Common.Result;
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
        return result.MapToResult();
    }

    [HttpGet("{holidayLimitId:int}")]
    public async Task<ActionResult> Get(int holidayLimitId) {
        var result = await _sender.Send(new GetHolidayLimitQuery(HolidayLimitId.Create(holidayLimitId)));
        return result.MapToResult();
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
        return result.MapToResult();
    }

    [HttpPut]
    public Task<ActionResult> Update() {
        throw new NotImplementedException();
    }
}