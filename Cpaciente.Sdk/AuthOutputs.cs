namespace Cpaciente.Sdk;

public sealed record UserRegistrationData(
    string Email,
    string Password,
    int StaffId
);

public sealed record LoginData(
    string Email,
    string Password
);

public sealed record AuthenticationOutput(
    string Token,
    DateTime ExpiresAt
);

public interface IJwtTokenGenerator
{
    AuthenticationOutput GenerateToken(string userId, string email, int staffId);
}
