using AutoMapper;
using DatabaseLayout.Context;
using DatabaseLayout.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Controllers
{
    public class ClientController : BaseController
    {
        private readonly IClofiContext _clofiContext;
        private readonly IMapper _mapper;

        public ClientController(IClofiContext context, IMapper mapper)
        {
            _clofiContext = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            _ = await _clofiContext.Users.AddAsync(new User
            {
                Description = "test user",
                Name = "test",
                Username = "test_username"
            });
            await _clofiContext.SaveChangesAsync();
            var users = await _clofiContext.Users.ToListAsync();

            var usersResult = _mapper.Map<List<UserDTO>>(users);
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse<List<UserDTO>>(usersResult));
        }
    }
}