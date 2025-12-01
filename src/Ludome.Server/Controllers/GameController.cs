using Ludome.Application.Contracts.Auth;
using Ludome.Application.Contracts.Games;
using Ludome.Domain;
using Ludome.Domain.Exceptions.Auth;
using Ludome.Domain.Games;
using Ludome.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ludome.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController(UserManager<User> userManager, IGameRepository gameRepository) : ControllerBase
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly IGameRepository _gameRepository = gameRepository;

        [HttpGet]
        [Route("GetPopular")]
        public async Task<GameOutput[]> GetPopularAsync([FromQuery] GetPopularGamesInput input)
        {
            var games = await _gameRepository
                .AsQueryable()
                .Include(game => game.Ratings)
                .Select(game => new GameOutput
                {
                    Id = game.Id,
                    Title = game.Title,
                    Image = game.Image,
                    Rating = (double?)game.Ratings.Average(rating => rating.Score) ?? 0,
                    ReviewsCount = game.Ratings.Count
                })
                .Take(20)
                .OrderByDescending(game => game.ReviewsCount)
                .ToArrayAsync();

            return games;
        }

        [HttpGet]
        [Route("GetGameDetails/{id}")]
        public async Task<GetGameDetailOutput> GetGameDetailsAsync(Guid id)
        {
            var game = await _gameRepository
                .AsQueryable()
                .Include(game => game.Ratings)
                .Include(game => game.Categories)
                .Include(game => game.Developers)
                .Include(game => game.Publishers)
                .Select(game => new GetGameDetailOutput
                {
                    Id = game.Id,
                    Title = game.Title,
                    Image = game.Image,
                    AverageRating = (double?)game.Ratings.Average(rating => rating.Score) ?? 0,
                    ReviewsCount = game.Ratings.Count,
                    Categories = game.Categories.Select(category => category.Name),
                    Developers = game.Developers.Select(developer => developer.Name),
                    Publishers = game.Publishers.Select(publisher => publisher.Name),
                    Description = game.Description,
                    Year = game.YearReleased
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            // todo: exception para not found

            return game;
        }

        [HttpGet]
        [Route("GetGameRatings/{id}")]
        public async Task<RatingOutput[]> GetGameRatingsAsync(Guid id)
        {
            var ratings = await _gameRepository
                .AsQueryable()
                .Include(game => game.Ratings)
                .ThenInclude(rating => rating.CreatorUser)
                .Where(game => game.Id == id)
                .SelectMany(game => game.Ratings)
                .Select(rating => new RatingOutput
                {
                    Id = rating.Id,
                    Comment = rating.Comment,
                    IsMine = rating.CreatorUser == HttpContext.Session.GetLoggedUser(),
                    Score = rating.Score,
                    ReviewDate = rating.CreatedAt,
                    UserNickname = rating.CreatorUser.Nickname
                })
                .OrderBy(rating => rating.IsMine)
                .ThenByDescending(rating => rating.ReviewDate)
                .ToArrayAsync();

            // todo: exception para not found

            return ratings;
        }
        
        [HttpPost]
        [Route("RateGame")]
        public async Task RateGameAsync(RatingInput input)
        {
            var game = await _gameRepository
                .AsQueryable()
                .Include(game => game.Ratings)
                .FirstOrDefaultAsync(game => game.Id == input.GameId);

            // todo: exception para not found

            var rating = new Rating(
                input.Score,
                HttpContext.Session.GetLoggedUser()!,
                input.Comment);

            game!.AddRating(rating);

            _gameRepository.Update(game);

            await _gameRepository.SaveChangesAsync();
        }
        
        [HttpDelete]
        [Route("DeleteRating")]
        public async Task DeleteRatingAsync(DeleteRatingInput input)
        {
            var game = await _gameRepository
                .AsQueryable()
                .Include(game => game.Ratings)
                .FirstOrDefaultAsync(game => game.Id == input.GameId);

            // todo: exception para not found

            game!.RemoveRating(input.Id);

            _gameRepository.Update(game);

            await _gameRepository.SaveChangesAsync();
        }

        //[HttpGet]
        //public async Task<GameOutput> Search()
        //{

        //}
    }
}
