using EPOS.Application.Authentication.DTOs;

namespace EPOS.Application.Authentication.Interfaces;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginRequest request);
}