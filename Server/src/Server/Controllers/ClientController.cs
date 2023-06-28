using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DatabaseLayout.Context;
using DatabaseLayout.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;

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
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            _ = await _clofiContext.Users.AddAsync(new User()
            {
                Description = "test user",
                Name = "test",
            });
            await _clofiContext.SaveChangesAsync();
            var users = await _clofiContext.Users.ToListAsync();
            var userDto = _mapper.Map<List<UserDTO>>(users);

            return Ok(userDto);
        }
    }
}
