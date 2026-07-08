using EPOS.Application.Authentication.DTOs;

namespace EPOS.Application.Authentication.Interfaces;

public interface IJwtService
{
    string GenerateToken(JwtUserInfo userInfo);
}