using System.Text.RegularExpressions;

namespace NexaCommerce.Modules.Identity.Domain.ValueObjects;

public sealed record Email
{
    private static readonly Regex EmailRegex =
        new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

    public string Value { get; }

    private Email()
    {
        Value = null!;
    }

    private Email(string value)
    {
        Value = value;
    }

    public static Email Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email is required.");

        value = value.Trim().ToLowerInvariant();

        if (!EmailRegex.IsMatch(value))
            throw new ArgumentException("Invalid email.");

        return new Email(value);
    }

    public override string ToString() => Value;
}
