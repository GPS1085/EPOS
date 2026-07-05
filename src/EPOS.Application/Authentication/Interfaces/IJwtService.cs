namespace EPOS.Application.Authentication.Interfaces;

public interface IJwtService
{
    string GenerateToken(Guid userId, string email, List<string> roles);
}