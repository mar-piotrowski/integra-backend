using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public static class BankAccountMapper {
    public static BankAccountDto MapToDto(this BankAccount bankAccount) =>
        new BankAccountDto(bankAccount.Name, bankAccount.Number);
}