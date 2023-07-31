using LAtelier.Catmash.Domain;

namespace LAtelier.Catmash.Infrastructure.Repositories
{
    public interface ICatsRepository
    {
        public IEnumerable<Cat> GetAll();
        public IEnumerable<Cat> GetRandomMash();
        public void Vote(string id);
        public long GetTotalVotes();
    }
}