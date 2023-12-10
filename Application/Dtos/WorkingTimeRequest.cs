namespace Application.Dtos;

public class WorkingTimeRequest {
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public DateTime StartWorkDate { get; private set; }
    public DateTime EndWorkDate { get; private set; }
}