using MediatR;

using Microsoft.AspNetCore.Mvc;

using NexaCommerce.Modules.Identity.Application.Features.RefreshToken;

namespace NexaCommerce.Api.Endpoints.Identity;

public static class RefreshTokenEndpoint
{
    public static IEndpointRouteBuilder MapRefreshTokenEndpoint(
        this IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/api/identity/refresh-token",
            async (
                [FromBody] RefreshTokenCommand command,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var result =
                    await sender.Send(command, cancellationToken);

                if (result.IsFailure)
                    return Results.BadRequest(result.Error);

                return Results.Ok(result.Value);
            })
        .WithTags("Identity")
        .WithName("RefreshToken");

        return app;
    }
}
