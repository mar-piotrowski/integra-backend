using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Application.Dtos;

public record AbsenceRouteParameters([FromRoute]int? UserId, [FromRoute]AbsenceStatus ?Status);