using Ludome.Application.Contracts.Auth;
using Ludome.Domain;
using Ludome.Domain.Exceptions.Auth;
using Ludome.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ludome.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(UserManager<User> userManager, ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            _tokenRepository = tokenRepository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task RegisterAsync(RegisterInput input)
        {
            var user = new User(input.Email, input.Name);

            var identityResult = await _userManager.CreateAsync(user, input.Password);

            if (!identityResult.Succeeded)
            {
                throw new IdentityRegisterErrorException(
                    string.Join(
                        string.Empty,
                        identityResult
                        .Errors
                        .Select(error => error.Description + Environment.NewLine)
                    )
                );
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<LoginResponseOutput> LoginAsync(LoginInput input)
        {
            var user = await _userManager.FindByEmailAsync(input.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, input.Password))
            {
                throw new InvalidLoginException();
            }

            var token = _tokenRepository.CreateJWTToken(user);

            var response = new LoginResponseOutput
            {
                JwtToken = token
            };

            return response;
        }
    }
}
