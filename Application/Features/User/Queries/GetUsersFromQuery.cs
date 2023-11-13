using Domain.Enums;

namespace Application.Features.User.Queries; 

public class GetUsersFromQuery {
    public int PerPage { get; set; }
    public SortingOrder Sort { get; set; }
}