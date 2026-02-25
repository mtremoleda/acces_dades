using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace dbdemo.Endpoints;

public static class EndpointsUsers
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        app.MapGet("/login", (JswTokenService jwtService) =>
        {
            return Results.Ok(jwtService.GenerateToken(
                userId: "user identification",
                email: "anna@exemple.com",
                issuer: "demo",
                role: "admin",
                audience: "public",
                lifetime: TimeSpan.FromHours(2)));
        }).WithTags("Users");

    }
}

public record TokenRequest(string Token);