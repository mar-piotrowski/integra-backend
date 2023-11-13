using Domain.Common.Models;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class InsuranceCode : Entity<InsuranceCodeId> {
    public string Code { get; private set; }
    public string Title { get; private set; }

    private InsuranceCode(string code, string title) {
        Code = code;
        Title = title;
    }

    public static InsuranceCode Create(string code, string title) => new InsuranceCode(code, title);
}