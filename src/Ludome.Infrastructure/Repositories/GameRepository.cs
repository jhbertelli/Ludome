using Ludome.Domain.Games;
using Ludome.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludome.Infrastructure.Repositories
{
    public class GameRepository(LudomeDbContext dbContext) : IGameRepository
    {
        private readonly LudomeDbContext _dbContext = dbContext;

        public IQueryable<Game> AsQueryable()
            => _dbContext.Games.AsQueryable();

        public async Task SaveChangesAsync()
            => await _dbContext.SaveChangesAsync();

        public void Update(Game game)
            => _dbContext.Games.Update(game);
    }
}
