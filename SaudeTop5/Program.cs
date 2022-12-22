namespace SaudeTop5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<SaudeTop5.Context.DatabaseContext>();
            builder.Services.AddScoped<SaudeTop5.Interfaces.IProfissionalRepository, SaudeTop5.Repositorios.ProfissionalRepository>();
            builder.Services.AddScoped<SaudeTop5.Interfaces.IBeneficiarioRepository, SaudeTop5.Repositorios.BeneficiarioRepository>();
            builder.Services.AddScoped<SaudeTop5.Interfaces.IEspecialidadeRepository, SaudeTop5.Repositorios.EspecialidadeRepository>();




            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MinhaRegraCors",
                    policy =>
                    {
                        policy.AllowAnyHeader()
                        .AllowAnyOrigin()
                        .AllowAnyMethod();

                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("MinhaRegraCors");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}