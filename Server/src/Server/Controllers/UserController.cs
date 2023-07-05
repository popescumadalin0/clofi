using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout.Models;
using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;

namespace Server.Controllers;

public class UserController : BaseController
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userRepository.GetUsers();
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(users);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(User))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await _userRepository.GetUser(id);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(user);
    }

    [HttpGet("{userId}/assignments")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Assignment>))]
    public async Task<IActionResult> GetAssignments(int userId)
    {
        var assignments = await _userRepository.GetAssignments(userId);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(assignments);
    }

    [HttpGet("{userId}/notes")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Note>))]
    public async Task<IActionResult> GetNotes(int userId)
    {
        var notes = await _userRepository.GetNotes(userId);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(notes);
    }

    [HttpGet("{userId}/alarms")] 
    [ProducesResponseType(200, Type = typeof(IEnumerable<Alarm>))]
    public async Task<IActionResult> GetAlarms(int userId)
    {
        var alarms = await _userRepository.GetAlarms(userId);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(alarms);
    }

    [HttpGet("{userId}/userConfig")]
    [ProducesResponseType(200, Type = typeof(UserConfig))]
    public async Task<IActionResult> GetUserConfig(int userId)
    {
        var userConfig = await _userRepository.GetUserConfig(userId);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(userConfig);
    }
}