using DatabaseLayout.Models;
using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;
using Server.Repository;
using System.Threading.Tasks;
using System;

namespace Server.Controllers
{
    public class UserConfigController : BaseController
    {
        private readonly IUserConfigRepository _userConfigRepository;

        public UserConfigController(IUserConfigRepository userConfigRepository)
        {
            _userConfigRepository = userConfigRepository;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(UserConfig))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetUserConfig(int id)
        {
            var userConfig = await _userConfigRepository.GetUserConfig(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(userConfig);
        }
    }
}
