using Application.Abstractions.Messaging;
using Application.Dtos;
using Domain.ValueObjects.Ids;

namespace Application.Features.Absence.GetAbsence; 

public record GetAbsenceQuery(AbsenceId AbsenceId) : IQuery<AbsenceDto>;