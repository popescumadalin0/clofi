using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DatabaseLayout.Context;
using Microsoft.EntityFrameworkCore;
using Server.Interfaces;

namespace Server.Repository;

public class UserRepository : IUserRepository
{
    private readonly IClofiContext _context;
    private readonly IMapper _mapper;

    public UserRepository(IClofiContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ICollection<global::Models.DTOs.User>> GetUsers()
    {
        var users = await _context.Users.ToListAsync();
        return _mapper.Map<ICollection<global::Models.DTOs.User>>(users);
    }

    public async Task<global::Models.DTOs.User> GetUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        return _mapper.Map<global::Models.DTOs.User>(user);
    }

    public async Task CreateUser(global::Models.DTOs.User userDto)
    {
        var user = _mapper.Map<DatabaseLayout.Models.User>(userDto);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        userDto.Id = user.Id;
    }

    public async Task UpdateUser(global::Models.DTOs.User userDto)
    {
        var user = await _context.Users.FindAsync(userDto.Id);
        _mapper.Map(userDto, user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}