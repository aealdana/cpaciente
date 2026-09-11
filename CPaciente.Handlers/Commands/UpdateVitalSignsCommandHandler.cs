using Cpaciente.Commands;
using Cpaciente.Data;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace CPaciente.Handlers.Commands;

public sealed class UpdateVitalSignsCommandHandler : IRequestHandler<UpdateVitalSignsCommand>
{
    private readonly CpacienteDbContext _context;

    public UpdateVitalSignsCommandHandler(CpacienteDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateVitalSignsCommand request, CancellationToken cancellationToken)
    {
        var vitalSign = await _context.VitalSigns
            .FirstOrDefaultAsync(v => v.Id == request.VitalSignId, cancellationToken);

        if (vitalSign is null)
        {
            throw new KeyNotFoundException($"No se encontro el registro de signos vitales con id {request.VitalSignId}.");
        }

        var data = request.Data;

        if (data.Height is not null) vitalSign.Height = data.Height;
        if (data.Weight is not null) vitalSign.Weight = data.Weight;
        if (data.Temperature is not null) vitalSign.Temperature = data.Temperature;
        if (data.SystolicPressure is not null) vitalSign.SystolicPressure = data.SystolicPressure;
        if (data.DiastolicPressure is not null) vitalSign.DiastolicPressure = data.DiastolicPressure;
        if (data.OxygenSaturation is not null) vitalSign.OxygenSaturation = data.OxygenSaturation;
        if (data.RespiratoryRate is not null) vitalSign.RespiratoryRate = data.RespiratoryRate;
        if (data.HeartRate is not null) vitalSign.HeartRate = data.HeartRate;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
