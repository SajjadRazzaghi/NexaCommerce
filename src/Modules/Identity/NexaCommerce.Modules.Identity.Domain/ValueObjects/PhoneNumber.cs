using System.Text.RegularExpressions;

namespace NexaCommerce.Modules.Identity.Domain.ValueObjects;

public sealed class PhoneNumber
{
    private static readonly Regex PhoneRegex =
        new(@"^09\d{9}$", RegexOptions.Compiled);

    public string Value { get; private set; } = null!;

    private PhoneNumber()
    {
    }

    private PhoneNumber(string value)
    {
        Value = value;
    }

    public static PhoneNumber Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Phone number is required.");

        value = value.Trim();

        if (!PhoneRegex.IsMatch(value))
            throw new ArgumentException("Phone number is invalid.");

        return new PhoneNumber(value);
    }

    public override string ToString()
        => Value;
}
