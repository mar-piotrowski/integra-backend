using Domain.Common.Models;

namespace Domain.ValueObjects;

public class IdentityNumber : ValueObject {
    public readonly string Value;
    private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    private IdentityNumber(string value) => Value = value;

    public static IdentityNumber Create(string value) => new IdentityNumber(value);

    protected override IEnumerable<object> GetAtomicValues() {
        yield return Value;
    }

    public static string Generate() => new string(
        Enumerable.Repeat(Chars, 5)
            .Select(s => s[new Random().Next(s.Length)])
            .ToArray()
    );
}