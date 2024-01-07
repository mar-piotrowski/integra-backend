using Domain.Enums;

namespace Application.Dtos; 

public class UserQueryParams {
    public int PerPage { get; set; }
    public SortingOrder Sort { get; set; }
}