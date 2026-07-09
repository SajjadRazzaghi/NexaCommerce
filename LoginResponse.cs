namespace NexaCommerce.Modules.Identity.Application.DTOs;

public sealed record LoginResponse(
    string AccessToken,
    DateTime ExpireAt);