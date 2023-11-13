namespace Application.Dtos;

public class ErrorResponse {
    public IEnumerable<object> Errors { get; set; }

    public ErrorResponse(IEnumerable<object> errors) {
        Errors = errors;
    }
}