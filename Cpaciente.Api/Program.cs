using Cpaciente.Data;
using CPaciente.Handlers.Queries;
using Microsoft.EntityFrameworkCore;

namespace Cpaciente.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();


            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(GetPatientEncountersQueryHandler).Assembly);
            });

            builder.Services.AddDbContext<CpacienteDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("CpacienteDb")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.Run();
        }
    }
}
