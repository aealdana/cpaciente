using Cpaciente; // AJUSTA este using al namespace real de tu entidad Patient
using Cpaciente.Commands;
using Cpaciente.Data;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace CPaciente.Handlers.Commands;

public sealed class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, int>
{
    private readonly CpacienteDbContext _context;

    public CreatePatientCommandHandler(CpacienteDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        var data = request.Data;

        var documentExists = await _context.Patients
            .AsNoTracking()
            .AnyAsync(p => p.DocumentId == data.DocumentId, cancellationToken);

        if (documentExists)
        {
            throw new InvalidOperationException($"Ya existe un paciente con el documento {data.DocumentId}.");
        }

        var patient = new Patient
        {
            DocumentId = data.DocumentId,
            FirstName = data.FirstName,
            LastName = data.LastName,
            BirthDate = data.BirthDate,
            Gender = data.Gender,
            Phone = data.Phone,
            Email = data.Email,
            Address = data.Address,
            EmergencyContactName = data.EmergencyContactName,
            EmergencyContactPhone = data.EmergencyContactPhone
        };

        _context.Patients.Add(patient);
        await _context.SaveChangesAsync(cancellationToken);

        return patient.Id;
    }
}
