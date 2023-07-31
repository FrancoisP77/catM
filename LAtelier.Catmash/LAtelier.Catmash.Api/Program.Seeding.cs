using LAtelier.Catmash.Infrastructure;

namespace LAtelier.Catmash.Api
{
    public static partial class Program
    {
        public static WebApplication SeedData(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<CatmashDbContext>();

                DataSeeding.SeedCats(dbContext, "cats.json");
            }

            return app;
        }
    }
}
