using Application.Abstractions.Messaging;
using Application.Dtos;

namespace Application.Features.Absence.GetAbsences; 

public record GetAbsencesQuery : IQuery<AbsencesResponse>;