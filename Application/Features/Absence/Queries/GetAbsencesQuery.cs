using Application.Abstractions.Messaging;
using Application.Dtos;

namespace Application.Features.Absence.Queries; 

public record GetAbsencesQuery : IQuery<AbsencesResponse>;