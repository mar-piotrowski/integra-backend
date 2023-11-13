using Application.Dtos;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Application.Mappers; 

public static class BankDetailsMapper {
   public static BankDetails MapToEntity(this BankDetailsDto bankDetails) =>
      BankDetails.Create(bankDetails.Name, bankDetails.Number);
}