using System.Security.Claims;
using EmployeeManagementSystem.Application.Models;
using EmployeeManagementSystem.Domain.Entities;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagementSystem.Application.Abstractions;

public interface ITokenService
{
    Task<Result<TokenApiModel>> RefreshToken(TokenApiModel token);
    Task<IdentityResult> RevokeTokenAsync(string email);
    string GenerateAccessToken(ClaimsIdentity claims);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    Task<ClaimsIdentity> GenerateClaims(User user);
    Task<TokenApiModel> GenerateToken(User user, bool extendExpiration = false);
}