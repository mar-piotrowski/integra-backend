namespace Application.Dtos;

public class WorkingTimeMonthDto {
   public int TotalSeconds { get; set; } 
   public int TotalMonthWorkingHours { get; set; }
   public int TotalOverHours { get; set; }
   public DateTime Month { get; set; }
   public List<WorkingTimeDayDto> Days { get; set; } = new List<WorkingTimeDayDto>();
}