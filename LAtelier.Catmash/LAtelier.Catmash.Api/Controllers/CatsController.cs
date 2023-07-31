using LAtelier.Catmash.Domain;
using LAtelier.Catmash.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LAtelier.Catmash.Api.Controllers
{
    /// <summary>
    /// Cats main actions
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class CatsController : ControllerBase
    {
        private readonly ICatsRepository _catsRepository;

        public CatsController(ICatsRepository catsRepository)
        {
            this._catsRepository = catsRepository;
        }

        /// <summary>
        /// Get all cats ordered by cuteness (cutest first).
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IList<Cat>), StatusCodes.Status200OK)]
        public IActionResult GetAll() /* We may want to implement some paging here. We're not expecting too much data to be returned though. */
        {
            return Ok(this._catsRepository.GetAll());
        }

        /// <summary>
        /// Returns a list of two cats randomly selected.
        /// </summary>
        /// <returns></returns>
        [HttpGet("RandomMash")]
        [ProducesResponseType(typeof(IList<Cat>), StatusCodes.Status200OK)]
        public IActionResult GetRandomMash()
        {
            return Ok(this._catsRepository.GetRandomMash());
        }

        /// <summary>
        /// Add one vote to the specifed cat.
        /// </summary>
        /// <param name="id">Cat id</param>
        /// <returns></returns>
        [HttpPost("{id}/Vote")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult Vote(string id)
        {
            this._catsRepository.Vote(id);
            return Ok();
        }

        /// <summary>
        /// Gets the total number of votes for all the cats.
        /// </summary>
        /// <returns></returns>
        [HttpGet("TotalVotes")]
        [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
        public IActionResult TotalVotes()
        {
            return Ok(this._catsRepository.GetTotalVotes());
        }
    }
}
