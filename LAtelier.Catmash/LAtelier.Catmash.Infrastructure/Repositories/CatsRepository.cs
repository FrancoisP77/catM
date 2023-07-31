using LAtelier.Catmash.Domain;
using LAtelier.Catmash.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace LAtelier.Catmash.Infrastructure.Repositories
{
    public class CatsRepository : ICatsRepository
    {
        private readonly CatmashDbContext _catmashDbContext;

        public CatsRepository(CatmashDbContext catmashDbContext)
        {
            this._catmashDbContext = catmashDbContext;
        }

        public IEnumerable<Cat> GetAll()
        {
            return this._catmashDbContext.Cats.OrderByDescending(c => c.TotalVotes);
        }

        public IEnumerable<Cat> GetRandomMash()
        {
            return this._catmashDbContext.Cats
                .OrderBy(c => EF.Functions.Random())
                .Take(2);
        }

        public void Vote(string id)
        {
            var cat = this._catmashDbContext.Cats.FirstOrDefault(c => c.Id == id);
            if (cat is null)
                throw new NotFoundException();

            cat.TotalVotes++;

            this._catmashDbContext.SaveChanges();
        }

        public long GetTotalVotes()
        {
            return this._catmashDbContext.Cats.Sum(c => c.TotalVotes);
        }
    }
}