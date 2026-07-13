using MediatR;

using Microsoft.AspNetCore.Mvc;

using NexaCommerce.Modules.Identity.Application.Features.ResetPassword;

namespace NexaCommerce.Api.Endpoints.Identity;

public static class ResetPasswordEndpoint
{
    public static IEndpointRouteBuilder MapResetPasswordEndpoint(
        this IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/api/identity/reset-password",
            async (
                [FromBody] ResetPasswordCommand command,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var result =
                    await sender.Send(command, cancellationToken);

                if (result.IsFailure)
                    return Results.BadRequest(result.Error);

                return Results.Ok();
            })
        .WithTags("Identity");

        return app;
    }
}
