using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace LAtelier.Catmash.Infrastructure.Tests
{
    public class DataSeedingTests : BaseTests
    {
        [SetUp]
        public void Setup()
        {
            var dbOptionsBuilder = new DbContextOptionsBuilder<CatmashDbContext>();
            dbOptionsBuilder.UseInMemoryDatabase(base.CatmashDbName);

            base.CatmashDbContext = new CatmashDbContext(dbOptionsBuilder.Options);
        }

        [Test]
        [Explicit]
        public void Seeding_cats_into_our_testing_database_should_be_successful()
        {
            // Arrange
            var dataSetFilePath = "cats.json";

            // Act
            DataSeeding.SeedCats(base.CatmashDbContext, dataSetFilePath);

            // Assert
            base.CatmashDbContext.Cats.Any().Should().BeTrue();
        }
    }
}