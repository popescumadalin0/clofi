using DatabaseLayout.Context;
using DatabaseLayout.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDK.Models;
using Server.Interfaces;
using Server.Models;
using Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;


namespace Server.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ClofiContext _context;
        private readonly ITokenService _tokenService;
        private readonly IRefreshTokenService _refreshTokenService;

        public UserRepository(ClofiContext context, ITokenService tokenService,
            IRefreshTokenService refreshTokenService)
        {
            _context = context;
            _tokenService = tokenService;
            _refreshTokenService = refreshTokenService;
        }

        public async Task<ICollection<User>> GetUsers()
        {
            return await _context.Users.OrderBy(u => u.Id).ToListAsync();
        }

        public async Task<ServiceResponse<bool>> AddUser(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return new ServiceResponse<bool>(true);

            }
            catch
            {
                return new ServiceResponse<bool>(false, "Adding user failed");

            }
        }

        public async Task<ServiceResponse<UserLoginResponse>> LoginUser(UserLoginRequest request)
        {
            var checkUsername = await _context.Users.Where(u => u.Username == request.Username).ToListAsync();
            if (checkUsername.Count == 0)
            {
                return new ServiceResponse<UserLoginResponse>(new UserLoginResponse(), "Username/Password incorrect");
            }

            var checkPassword = checkUsername.FirstOrDefault(u => u.Password == request.Password);
            if (checkPassword == null)
            {
                return new ServiceResponse<UserLoginResponse>(new UserLoginResponse(), "Adding user failed");
            }

            _tokenService.CreateUsernameHash(request.Username, out byte[] usernameHash, out byte[] usernameSalt);
            _refreshTokenService.CreateUsernameHash(request.Username, out byte[] usernameHashR, out byte[] usernameSaltR);

            JwtSecurityToken token = _tokenService.GenerateToken(request);
            JwtSecurityToken refreshToken = _refreshTokenService.GenerateRefreshToken(request);

            UserLoginResponse responseLogin = new UserLoginResponse
            {
                Username = request.Username,
                Token = token,
                RefreshToken = refreshToken
            };
            return new ServiceResponse<UserLoginResponse>(responseLogin);

        }
    }
}
