namespace Application.Dtos; 

public record ChangePasswordRequest(int UserId, string CurrentPassword, string NewPassword);