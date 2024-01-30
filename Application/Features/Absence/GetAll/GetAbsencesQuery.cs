using Application.Abstractions.Messaging;
using Application.Dtos;
using Domain.ValueObjects.Ids;

namespace Application.Features.Absence.GetAll; 

public record GetAbsencesQuery(UserId? UserId) : IQuery<AbsencesResponse>;