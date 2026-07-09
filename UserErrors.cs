using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Identity.Domain.Errors;

public static class UserErrors
{
    public static readonly Error EmailAlreadyExists =
        new(
            "Identity.EmailAlreadyExists",
            "A user with this email already exists.");

    public static readonly Error UserNotFound =
        new(
            "Identity.UserNotFound",
            "User not found.");
}