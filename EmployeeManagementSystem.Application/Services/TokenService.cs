using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using EmployeeManagementSystem.Application.Abstractions;
using EmployeeManagementSystem.Application.Models;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Errors;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeManagementSystem.Application.Services;

public class TokenService : ITokenService
{
    private readonly UserManager<User> userManager;
    private readonly IConfiguration configuration;
    private readonly string jwtSecret;

    public TokenService(
        UserManager<User> userManager,
        IConfiguration configuration)
    {
        this.userManager = userManager;
        this.configuration = configuration;
        jwtSecret = this.configuration["JWT:Secret"];
    }

    public async Task<Result<TokenApiModel>> RefreshToken(TokenApiModel token)
    {
        try
        {
            var principal = GetPrincipalFromExpiredToken(token.AccessToken);
            string username = principal.Identity.Name;
            var user = await userManager.FindByNameAsync(username);

            if (user is null)
                return new EntityNotFoundError("User Not Found");

            if (user.RefreshToken != token.RefreshToken)
                return new ValidationError("Refresh token is not recognised.");


            if (user.RefreshTokenExpiration <= DateTime.UtcNow)
                return new ValidationError("Refresh token is not valid due to expiration");

            var tokenModel = await GenerateToken(user);
            return tokenModel;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<IdentityResult> RevokeTokenAsync(string email)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user is null)
            return IdentityResult.Failed();

        user.RefreshToken = null;
        return await userManager.UpdateAsync(user);
    }

    public string GenerateAccessToken(ClaimsIdentity claims)
    {
        try
        {
            var handler = new JwtSecurityTokenHandler();

            var privateKey = Encoding.ASCII.GetBytes(jwtSecret);

            var credentials =
                new SigningCredentials(new SymmetricSecurityKey(privateKey), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = credentials,
                Expires =
                    DateTime.UtcNow.AddMinutes(Convert.ToInt16(configuration["JWT:AccessTokenExpirationMinutes"])),
                Subject = claims,
                Issuer = configuration["JWT:ValidIssuer"],
                Audience = configuration["JWT:ValidAudience"]
            };

            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public string GenerateRefreshToken()
    {
        try
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret)),
            ValidateLifetime = true
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
        var jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null ||
            !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");
        return principal;
    }

    public async Task<ClaimsIdentity> GenerateClaims(User user)
    {
        try
        {
            var claims = new ClaimsIdentity();

            claims.AddClaim(new Claim(ClaimTypes.Name, user.UserName!));
            claims.AddClaim(new Claim(ClaimTypes.Email, user.Email!));
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.AddClaim(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            var roles = await userManager.GetRolesAsync(user);

            foreach (var role in roles)
                claims.AddClaim(new Claim(ClaimTypes.Role, role));

            return claims;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<TokenApiModel> GenerateToken(User user, bool extendExpiration = false)
    {
        var claims = await GenerateClaims(user);
        var accessToken = GenerateAccessToken(claims);
        var refreshToken = GenerateRefreshToken();

        user.RefreshToken = refreshToken;

        if (extendExpiration)
            user.RefreshTokenExpiration =
                DateTime.UtcNow.AddDays(Convert.ToInt16(configuration["JWT:RefreshTokenExpirationDays"]));

        await userManager.UpdateAsync(user);

        return new TokenApiModel()
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
        };
    }
}