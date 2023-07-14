using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        var usersDto = await _userRepository.GetUsers();
        return Ok(usersDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var userDto = await _userRepository.GetUser(id);
        if (userDto == null)
        {
            return NotFound();
        }

        return Ok(userDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] global::Models.DTOs.User newUserDto)
    {
        if (newUserDto == null)
        {
            return BadRequest();
        }

        await _userRepository.CreateUser(newUserDto);

        return CreatedAtAction(nameof(GetUser), new { id = newUserDto.Id }, newUserDto);
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