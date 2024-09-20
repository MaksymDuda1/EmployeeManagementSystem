using System.Security.Claims;
using EmployeeManagementSystem.Application.Models;
using EmployeeManagementSystem.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace EmployeeManagementSystem.Application.Abstractions;

public interface ITokenService
{
    Task<string> RefreshToken(TokenApiModel token);
    Task RevokeTokenAsync(ClaimsPrincipal principal);
    string CreateAccessToken(ClaimsIdentity claims);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    Task<ClaimsIdentity> GenerateClaims(User user);
    Task<TokenApiModel> GenerateToken(User user);
}