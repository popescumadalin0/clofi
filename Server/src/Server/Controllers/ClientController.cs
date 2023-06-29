using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayout.Context;
using DatabaseLayout.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Server.Models;

namespace Server.Controllers
{
    public class ClientController : BaseController
    {
        private readonly IClofiContext _clofiContext;

        public ClientController(IClofiContext context)
        {
            _clofiContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            _ = await _clofiContext.Users.AddAsync(new UserDto()
            {
                Description = "test user",
                Name = "test",
            });
            await _clofiContext.SaveChangesAsync();
            var users = await _clofiContext.Users.ToListAsync();

            //aici folosim automapper... ma rog toate astea se fac IN AFARA CONTROLLERULUI :)))
            var usersResult = users.Select(x => new User()
            {
                Description = x.Description,
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return ApiServiceResponse.ApiServiceResult(new ServiceResponse<List<User>>(usersResult));
        }
    }
}
