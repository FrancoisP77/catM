using AutoFixture;
using FluentAssertions;
using LAtelier.Catmash.Domain;
using LAtelier.Catmash.Infrastructure.Exceptions;
using LAtelier.Catmash.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LAtelier.Catmash.Infrastructure.Tests.Repositories
{
    public class CatsRepositoryTests : BaseTests
    {
        private Fixture _fixture = new Fixture();

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();

            var dbOptionsBuilder = new DbContextOptionsBuilder<CatmashDbContext>();
            dbOptionsBuilder.UseInMemoryDatabase(base.CatmashDbName);

            base.CatmashDbContext = new CatmashDbContext(dbOptionsBuilder.Options);
        }

        [Test]
        public void Getting_all_cats_should_return_all_of_them_order_by_descending_cuteness()
        {
            // Arrange
            var cats = new List<Cat>() { 
                BuildCat(totalVotes: 2),
                BuildCat(totalVotes: 0),
                BuildCat(totalVotes: 1)
            };
            base.CatmashDbContext.AddRange(cats);
            base.CatmashDbContext.SaveChanges();

            var catsRepository = new CatsRepository(base.CatmashDbContext);

            // Act
            var orderedCats = catsRepository.GetAll();

            // Assert
            orderedCats.Should().BeInDescendingOrder(c => c.TotalVotes);
        }

        [Test]
        public void Getting_a_random_mash_should_return_a_random_mash_of_cats()
        {
            // Arrange
            var cats = this._fixture.CreateMany<Cat>(10);

            base.CatmashDbContext.AddRange(cats);
            base.CatmashDbContext.SaveChanges();

            var catsRepository = new CatsRepository(base.CatmashDbContext);

            // Act
            var randomMash1 = catsRepository.GetRandomMash();
            var randomMash2 = catsRepository.GetRandomMash();

            // Assert
            randomMash1.Should().NotBeEquivalentTo(randomMash2);
        }

        [Test]
        public void Voting_for_a_cat_should_add_one_vote_to_its_totalVotes()
        {
            // Arrange
            var cat = this._fixture.Create<Cat>();
            cat.TotalVotes = 0;

            base.CatmashDbContext.Add(cat);
            base.CatmashDbContext.SaveChanges();

            var catsRepository = new CatsRepository(base.CatmashDbContext);

            // Act
            catsRepository.Vote(cat.Id);

            // Assert
            base.CatmashDbContext.Cats.First(c => c.Id == cat.Id).TotalVotes.Should().Be(1);
        }

        [Test]
        public void Voting_for_a_non_existing_cat_should_raise_a_NotFoundException()
        {
            // Arrange
            var catsRepository = new CatsRepository(base.CatmashDbContext);

            // Act
            var action = () => catsRepository.Vote("nonExistingId");

            // Assert
            action.Should().Throw<NotFoundException>();
        }

        [Test]
        public void Getting_the_total_number_votes_should_return_the_expected_result()
        {
            // Arrange
            var expectedNumberOfVotes = 10U;

            var cat = this._fixture.Create<Cat>();
            cat.TotalVotes = expectedNumberOfVotes;

            base.CatmashDbContext.Add(cat);
            base.CatmashDbContext.SaveChanges();

            var catsRepository = new CatsRepository(base.CatmashDbContext);

            // Act
            var totalNumberOfVotes = catsRepository.GetTotalVotes();

            // Assert
            totalNumberOfVotes.Should().Be(expectedNumberOfVotes);
        }

        private Cat BuildCat(uint totalVotes)
        {
            var fixture = new Fixture();
            
            var cat = fixture.Create<Cat>();
            cat.TotalVotes = totalVotes;

            return cat;
        }
    }
}
