using Cpaciente.Commands;
using Cpaciente.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace CPaciente.Handlers.Commands;

public sealed class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly CpacienteDbContext _context;

    public RegisterUserCommandHandler(UserManager<ApplicationUser> userManager, CpacienteDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var data = request.Data;

        var staffExists = await _context.Staff
            .AsNoTracking()
            .AnyAsync(s => s.Id == data.StaffId, cancellationToken);

        if (!staffExists)
        {
            throw new KeyNotFoundException($"No se encontro el personal con id {data.StaffId}.");
        }

        var alreadyLinked = await _context.Users
            .AsNoTracking()
            .AnyAsync(u => u.StaffId == data.StaffId, cancellationToken);

        if (alreadyLinked)
        {
            throw new InvalidOperationException("Este miembro del personal ya tiene una cuenta registrada.");
        }

        var user = new ApplicationUser
        {
            UserName = data.Email,
            Email = data.Email,
            StaffId = data.StaffId
        };

        var result = await _userManager.CreateAsync(user, data.Password);

        if (!result.Succeeded)
        {
            var errors = string.Join("; ", result.Errors.Select(e => e.Description));
            throw new InvalidOperationException($"No se pudo registrar el usuario: {errors}");
        }

        return user.Id;
    }
}
