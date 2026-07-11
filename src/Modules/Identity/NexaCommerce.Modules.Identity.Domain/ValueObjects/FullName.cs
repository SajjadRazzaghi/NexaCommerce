namespace NexaCommerce.Modules.Identity.Domain.ValueObjects;

public sealed record FullName
{
    public string FirstName { get; }

    public string LastName { get; }

    public string DisplayName => $"{FirstName} {LastName}";

    private FullName()
    {
        FirstName = null!;
        LastName = null!;
    }

    private FullName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public static FullName Create(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException(nameof(firstName));

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException(nameof(lastName));

        return new FullName(firstName.Trim(), lastName.Trim());
    }
}
