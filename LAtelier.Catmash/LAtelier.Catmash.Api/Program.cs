using Microsoft.Extensions.FileProviders;

namespace LAtelier.Catmash.Api
{
    public static partial class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(); 
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.ConfigureAllServices();

            var app = builder.Build();

            app.SeedData();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            /* We're making this available in all environments just for the purpose of this exercice */
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseFileServer(
                new FileServerOptions()
                {
                    FileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory())
                }
            );

            app.UseRouting();

            app.UseCors("AllOriginsAllowed");

            app.MapControllers();


            app.Run();
        }
    }
}