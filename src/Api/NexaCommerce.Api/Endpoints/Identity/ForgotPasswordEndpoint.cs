using MediatR;

using Microsoft.AspNetCore.Mvc;

using NexaCommerce.Modules.Identity.Application.Features.ForgotPassword;

namespace NexaCommerce.Api.Endpoints.Identity;

public static class ForgotPasswordEndpoint
{
    public static IEndpointRouteBuilder MapForgotPasswordEndpoint(
        this IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/api/identity/forgot-password",
            async (
                [FromBody] ForgotPasswordCommand command,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var result =
                    await sender.Send(command, cancellationToken);

                if (result.IsFailure)
                    return Results.BadRequest(result.Error);

                return Results.Ok();
            })
        .WithName("ForgotPassword")
        .WithTags("Identity");

        return app;
    }
}
