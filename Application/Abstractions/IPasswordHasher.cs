using Domain.ValueObjects;

namespace Application.Abstractions; 

public interface IPasswordHasher {
   public string Hash(Password password);
   public bool Verify(string hashPassword, Password password);
}