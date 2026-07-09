namespace NexaCommerce.Modules.Identity.Domain.ValueObjects;

public sealed record FullName(
    string FirstName,
    string LastName)
{
    public string DisplayName => $"{FirstName} {LastName}";
}