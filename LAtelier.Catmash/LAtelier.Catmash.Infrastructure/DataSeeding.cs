using LAtelier.Catmash.Domain;
using System.Text.Json;

namespace LAtelier.Catmash.Infrastructure
{
    public static class DataSeeding
    {
        public static void SeedCats(CatmashDbContext dbContext, string dataSetFilePath)
        {
            dbContext.Database.EnsureCreated();

            if (!dbContext.Cats.Any())
            {
                using (var r = new StreamReader(dataSetFilePath))
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    /* This is a small file so this should be fine. */
                    var cats = JsonSerializer.Deserialize<IEnumerable<Cat>>(r.BaseStream, options);

                    foreach (var cat in cats)
                        dbContext.Cats.Add(cat);

                    dbContext.SaveChanges();
                }
            }
        }
    }
}