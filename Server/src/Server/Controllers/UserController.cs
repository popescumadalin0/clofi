﻿using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models;
using Server.Interfaces;
using Server.Models;

namespace Server.Controllers;

public class UserController : BaseController
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsersAsync()
    {
        var users = await _userRepository.GetUsersAsync();
        return ApiServiceResponse.ApiServiceResult(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserAsync(int id)
    {
        var user = await _userRepository.GetUserAsync(id);
        return ApiServiceResponse.ApiServiceResult(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] User newUserDto)
    {
        var result = await _userRepository.CreateUserAsync(newUserDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUserAsync([FromBody] User updatedUserDto)
    {
        var result = await _userRepository.UpdateUserAsync(updatedUserDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserAsync(int id)
    {
        var result = await _userRepository.DeleteUserAsync(id);
        return ApiServiceResponse.ApiServiceResult(result);
    }
}