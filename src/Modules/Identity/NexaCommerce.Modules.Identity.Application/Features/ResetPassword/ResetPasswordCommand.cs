using MediatR;

using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Identity.Application.Features.ResetPassword;

public sealed record ResetPasswordCommand(
    string PhoneNumber,
    string Code,
    string NewPassword)
    : IRequest<Result>;
