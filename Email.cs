using System.Text.RegularExpressions;

namespace NexaCommerce.Modules.Identity.Domain.ValueObjects;

public sealed record Email
{
    private static readonly Regex EmailRegex =
        new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

    public string Value { get; }

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email is required.", nameof(value));

        value = value.Trim().ToLowerInvariant();

        if (!EmailRegex.IsMatch(value))
            throw new ArgumentException("Invalid email format.", nameof(value));

        Value = value;
    }

    public override string ToString() => Value;

    public static implicit operator string(Email email) => email.Value;

    public static explicit operator Email(string value) => new(value);
}