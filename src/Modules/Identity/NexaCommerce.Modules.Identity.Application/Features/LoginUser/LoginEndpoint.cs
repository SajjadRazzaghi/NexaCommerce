using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder; // For MapPost, MapGet, etc.
using Microsoft.AspNetCore.Http; // For HttpContext, IResult, etc.
using NexaCommerce.Modules.Identity.Application.Features.LoginUser;

namespace NexaCommerce.Api.Endpoints.Identity;

public static class LoginEndpoint
{
    public static IEndpointRouteBuilder MapLoginEndpoint(
        this IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/api/identity/login",
            async (
                [FromBody] LoginUserCommand command,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var result = await sender.Send(
                    command,
                    cancellationToken);

                if (result.IsFailure)
                {
                    return Results.Unauthorized();
                }

                return Results.Ok(result.Value);
            })
        .WithName("Login")
        .WithTags("Identity");

        return app;
    }
}
