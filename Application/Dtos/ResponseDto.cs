namespace Application.Dtos;

public class ResponseDto {
    public string Message { get; set; }
    public ResponseDto(string message) {
        Message = message;
    }
}