using Ludome.Domain.Games;

namespace Ludome.Domain.Repositories
{
    public interface IGameRepository
    {
        public IQueryable<Game> AsQueryable();
        public Task SaveChangesAsync();
        public void Update(Game game);
    }
}
