namespace NexaCommerce.SharedKernel.Results;

public static class Errors
{
    public static Error Null(string name)
        => new("General.Null", $"{name} is null.");

    public static Error NotFound(string name)
        => new("General.NotFound", $"{name} was not found.");

    public static Error Validation(string message)
        => new("General.Validation", message);

    public static Error Conflict(string message)
        => new("General.Conflict", message);
}