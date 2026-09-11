using Cpaciente.Commands;
using Cpaciente.Data;
using Cpaciente.Sdk;
using Microsoft.AspNetCore.Identity;
using MediatR;

namespace CPaciente.Handlers.Commands;

public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, AuthenticationOutput>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IJwtTokenGenerator _tokenGenerator;

    public LoginCommandHandler(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IJwtTokenGenerator tokenGenerator)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<AuthenticationOutput> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Data.Email);

        if (user is null)
        {
            throw new UnauthorizedAccessException("Credenciales invalidas.");
        }

        var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Data.Password, lockoutOnFailure: true);

        if (!signInResult.Succeeded)
        {
            throw new UnauthorizedAccessException("Credenciales invalidas.");
        }

        return _tokenGenerator.GenerateToken(user.Id, user.Email!, user.StaffId);
    }
}
