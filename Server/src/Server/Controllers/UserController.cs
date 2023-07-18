using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Server.Interfaces;
using Server.Models;

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
        var users = await _userRepository.GetUsers();
        return ApiServiceResponse.ApiServiceResult(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await _userRepository.GetUser(id);
        return ApiServiceResponse.ApiServiceResult(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] global::Models.DTOs.User newUserDto)
    {
        var result = await _userRepository.CreateUser(newUserDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] global::Models.DTOs.User updatedUserDto)
    {
        var result = await _userRepository.UpdateUser(updatedUserDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _userRepository.DeleteUser(id);
        return ApiServiceResponse.ApiServiceResult(result);
    }
}