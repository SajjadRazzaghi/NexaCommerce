using MediatR;

using Microsoft.AspNetCore.Mvc;

using NexaCommerce.Modules.Identity.Application.Features.RegisterUser;

namespace NexaCommerce.Api.Endpoints.Identity;

public static class RegisterEndpoint
{
    public static IEndpointRouteBuilder MapRegisterEndpoint(
        this IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/api/identity/register",
            async (
                [FromBody] RegisterUserCommand command,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var result = await sender.Send(command, cancellationToken);

                if (result.IsFailure)
                {
                    return Results.BadRequest(result.Error);
                }

                return Results.Created(
                    $"/api/identity/users/{result.Value.UserId}",
                    result.Value);
            })
            .WithName("Register")
            .WithTags("Identity");

        return app;
    }
}
