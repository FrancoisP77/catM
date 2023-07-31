using FluentAssertions;
using LAtelier.Catmash.Api.Controllers;
using LAtelier.Catmash.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LAtelier.Catmash.Api.Tests.Controllers
{
    public class Tests
    {
        private ICatsRepository _mockedCatsRepository;

        [SetUp]
        public void Setup()
        {
            this._mockedCatsRepository = new Moq.Mock<ICatsRepository>().Object;
        }

        [Test]
        public void Getting_all_cats_should_return_a_200_OK_response()
        {
            // Arrange
            var catsController = new CatsController(this._mockedCatsRepository);

            // Act
            var response = catsController.GetAll();

            // Assert
            response.Should().BeOfType(typeof(OkObjectResult));
        }

        [Test]
        public void Getting_a_random_mash_should_return_a_200_OK_response()
        {
            // Arrange
            var catsController = new CatsController(this._mockedCatsRepository);

            // Act
            var response = catsController.GetRandomMash();

            // Assert
            response.Should().BeOfType(typeof(OkObjectResult));
        }

        [Test]
        public void Voting_for_a_cat_should_return_a_200_OK_response()
        {
            // Arrange
            var catsController = new CatsController(this._mockedCatsRepository);

            // Act
            var response = catsController.Vote(It.IsAny<string>());

            // Assert
            response.Should().BeOfType(typeof(OkResult));
        }

        [Test]
        public void Gett_the_total_number_of_votes_for_all_the_cats_should_return_a_200_OK_response()
        {
            // Arrange
            var catsController = new CatsController(this._mockedCatsRepository);

            // Act
            var response = catsController.TotalVotes();

            // Assert
            response.Should().BeOfType(typeof(OkObjectResult));
        }
    }
}