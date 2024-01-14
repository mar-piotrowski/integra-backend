using System.Net;
using Domain.Common.Models;

namespace Domain.Common.Errors;

public class AuthenticationErrors {
    public static Error WrongConfirmPassword =>
        new Error(HttpStatusCode.BadRequest, "Auth.ConfirmPasswordDoesNotMath", "Podane hasla nie sa identyczne");

    public static Error TokenIsNotValid =>
        new Error(HttpStatusCode.Unauthorized, "Auth.TokenIsNotValid", "Token nie jest poprawny!");
}
