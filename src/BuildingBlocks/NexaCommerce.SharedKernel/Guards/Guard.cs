namespace NexaCommerce.SharedKernel.Guards;

public static class Guard
{
    public static void AgainstNull(object? value, string parameterName)
    {
        ArgumentNullException.ThrowIfNull(value, parameterName);
    }

    public static void AgainstNullOrWhiteSpace(string? value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException($"{parameterName} cannot be empty.", parameterName);
    }
}