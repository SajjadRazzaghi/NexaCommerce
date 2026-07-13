using MediatR;

using NexaCommerce.SharedKernel.Results;

namespace NexaCommerce.Modules.Identity.Application.Features.ForgotPassword;

public sealed record ForgotPasswordCommand(
    string PhoneNumber)
    : IRequest<Result>;
