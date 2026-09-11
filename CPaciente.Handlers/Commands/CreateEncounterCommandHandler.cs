using Cpaciente; // AJUSTA este using al namespace real de tus entidades
using Cpaciente.Commands;
using Cpaciente.Data;
using Cpaciente.Sdk;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace CPaciente.Handlers.Commands;

public sealed class CreateEncounterCommandHandler : IRequestHandler<CreateEncounterCommand, EncounterCreationOutput>
{
    private readonly CpacienteDbContext _context;

    public CreateEncounterCommandHandler(CpacienteDbContext context)
    {
        _context = context;
    }

    public async Task<EncounterCreationOutput> Handle(CreateEncounterCommand request, CancellationToken cancellationToken)
    {
        var patientExists = await _context.Patients
            .AsNoTracking()
            .AnyAsync(p => p.Id == request.PatientId, cancellationToken);

        if (!patientExists)
        {
            throw new KeyNotFoundException($"No se encontro el paciente con id {request.PatientId}.");
        }

        var staffExists = await _context.Staff
            .AsNoTracking()
            .AnyAsync(s => s.Id == request.Data.AttendingStaffId, cancellationToken);

        if (!staffExists)
        {
            throw new KeyNotFoundException($"No se encontro el personal con id {request.Data.AttendingStaffId}.");
        }

        var encounter = new Encounter
        {
            PatientId = request.PatientId,
            AttendingStaffId = request.Data.AttendingStaffId,
            ChiefComplaint = request.Data.ChiefComplaint,
            Symptoms = request.Data.Symptoms,
            PhysicalExamination = request.Data.PhysicalExamination,
            Priority = request.Data.Priority,
            Status = EncounterStatus.Waiting
        };

        _context.Encounters.Add(encounter);
        await _context.SaveChangesAsync(cancellationToken);

        // VitalSign es 1:1 con Encounter y solo pediste el endpoint de UPDATE,
        // asi que se crea vacio aqui para que exista un id que actualizar despues.
        var vitalSign = new VitalSign
        {
            EncounterId = encounter.Id
        };

        _context.VitalSigns.Add(vitalSign);
        await _context.SaveChangesAsync(cancellationToken);

        return new EncounterCreationOutput(encounter.Id, vitalSign.Id);
    }
}
