namespace Application.Dtos;

public class UserWorkingTimeResponse {
   public int Year { get; set; }
   public decimal TotalSeconds { get; set; }
   public List<WorkingTimeMonthDto> Months { get; set; } = new List<WorkingTimeMonthDto>();
}