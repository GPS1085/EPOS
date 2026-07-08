using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EPOS.Application.Authentication.Configurations;
using EPOS.Application.Authentication.DTOs;
using EPOS.Application.Authentication.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EPOS.Infrastructure.Authentication.JWT;

public class JwtService : IJwtService
{
    private readonly JwtSettings _jwtSettings;

    public JwtService(IOptions<JwtSettings> jwtOptions)
    {
        _jwtSettings = jwtOptions.Value;
    }

    public string GenerateToken(JwtUserInfo userInfo)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, userInfo.UserId.ToString()),
            new(JwtRegisteredClaimNames.Email, userInfo.Email),
            new("OrganizationId", userInfo.OrganizationId.ToString()),
            new("EmployeeCode", userInfo.EmployeeCode),
            new("MobileNumber", userInfo.MobileNumber),
            new("UserType", userInfo.UserType)
        };

        foreach (var role in userInfo.Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

        var credentials = new SigningCredentials(
            key,
            ClaimTypes.Role);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}