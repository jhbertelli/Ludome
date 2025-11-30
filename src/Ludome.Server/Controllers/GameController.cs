using Ludome.Application.Contracts.Auth;
using Ludome.Application.Contracts.Games;
using Ludome.Domain;
using Ludome.Domain.Exceptions.Auth;
using Ludome.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ludome.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController(UserManager<User> userManager, ITokenRepository tokenRepository)
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly ITokenRepository _tokenRepository = tokenRepository;

        private List<GameOutput> _fakeGames = new List<GameOutput>
        {
            new GameOutput
            {
                Id = Guid.NewGuid(),
                Title = "Tomb Raider (2013)",
                Rating = 4.5,
                ReviewsCount = 282,
                Image = "https://upload.wikimedia.org/wikipedia/en/f/f1/TombRaider2013.jpg",
            },
            new GameOutput
            {
                Id = Guid.NewGuid(),
                Title = "Dark Souls 3",
                Rating = 4.7,
                ReviewsCount = 569,
                Image = "https://upload.wikimedia.org/wikipedia/en/b/bb/Dark_souls_3_cover_art.jpg",
            },
            new GameOutput
            {
                Id = Guid.NewGuid(),
                Title = "The Last Of Us",
                Rating = 4.8,
                ReviewsCount = 681,
                Image = "https://upload.wikimedia.org/wikipedia/en/4/46/Video_Game_Cover_-_The_Last_of_Us.jpg",
            },
            new GameOutput
            {
                Id = Guid.NewGuid(),
                Title = "Monster Hunter Wilds",
                Rating = 4.7,
                ReviewsCount = 302,
                Image = "https://upload.wikimedia.org/wikipedia/en/5/52/Monster_Hunter_Wilds_cover.png",
            },
            new GameOutput
            {
                Id = Guid.NewGuid(),
                Title = "Borderlands 2",
                Rating = 4.5,
                ReviewsCount = 104,
                Image = "https://upload.wikimedia.org/wikipedia/en/5/51/Borderlands_2_cover_art.png",
            },
            new GameOutput
            {
                Id = Guid.NewGuid(),
                Title = "Super Mario Odyssey",
                Rating = 4.8,
                ReviewsCount = 565,
                Image = "https://upload.wikimedia.org/wikipedia/en/8/8d/Super_Mario_Odyssey.jpg",
            },
            new GameOutput
            {
                Id = Guid.NewGuid(),
                Title = "Rise of the Tomb Raider",
                Rating = 4.6,
                ReviewsCount = 350,
                Image = "https://upload.wikimedia.org/wikipedia/en/2/29/Rise_of_the_Tomb_Raider.jpg",
            },
            new GameOutput
            {
                Id = Guid.NewGuid(),
                Title = "The Legend of Zelda: Tears of the Kingdom",
                Rating = 4.7,
                ReviewsCount = 468,
                Image = "https://upload.wikimedia.org/wikipedia/en/f/fb/The_Legend_of_Zelda_Tears_of_the_Kingdom_cover.jpg",
            },
            new GameOutput
            {
                Id = Guid.NewGuid(),
                Title = "Castlevania: Symphony of the Night",
                Rating = 4.8,
                ReviewsCount = 501,
                Image = "https://upload.wikimedia.org/wikipedia/en/d/dc/Castlevania_SOTN_PAL_Game_Cover.jpg",
            },
            new GameOutput
            {
                Id = Guid.NewGuid(),
                Title = "Shadow of the Colossus",
                Rating = 4.8,
                ReviewsCount = 498,
                Image = "https://upload.wikimedia.org/wikipedia/en/6/66/Shadow_of_the_Colossus_2018_cover_art.jpg",
            },
        };

        [HttpGet]
        [Route("GetPopular")]
        public async Task<GameOutput[]> GetPopularAsync([FromQuery] GetPopularGamesInput input)
        {
            return await Task.FromResult(
                _fakeGames.ToArray());
        }

        //[HttpGet]
        //public async Task<GameOutput> Search()
        //{
            
        //}
    }
}
