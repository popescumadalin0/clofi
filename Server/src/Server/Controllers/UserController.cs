using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DatabaseLayout.Models;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Server.Interfaces;

namespace Server.Controllers;

public class UserController : BaseController
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserController(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = _mapper.Map<ICollection<DatabaseLayout.Models.User>>(await _userRepository.GetUsers());
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var userDto = await _userRepository.GetUser(id);
        if (userDto == null)
        {
            return NotFound();
        }

        var user = _mapper.Map<DatabaseLayout.Models.User>(userDto);
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] global::Models.DTOs.User newUserDto)
    {
        if (newUserDto == null)
        {
            return BadRequest();
        }

        await _userRepository.CreateUser(newUserDto);

        var createdUserDto = await _userRepository.GetUser(newUserDto.Id);
        var createdUser = _mapper.Map<DatabaseLayout.Models.User>(createdUserDto);

        return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] global::Models.DTOs.User updatedUserDto)
    {
        if (id != updatedUserDto.Id)
        {
            return BadRequest();
        }

        var existingUserDto = await _userRepository.GetUser(id);
        if (existingUserDto == null)
        {
            return NotFound();
        }

        var existingUser = _mapper.Map<DatabaseLayout.Models.User>(existingUserDto);
        _mapper.Map(updatedUserDto, existingUser);

        await _userRepository.UpdateUser(updatedUserDto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var userDto = await _userRepository.GetUser(id);
        if (userDto == null)
        {
            return NotFound();
        }

        await _userRepository.DeleteUser(id);

        return NoContent();
    }
}