using DatabaseLayout.Models;
using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;
using System.Threading.Tasks;

namespace Server.Controllers;

public class UserConfigController : BaseController
{
    private readonly IUserConfigRepository _userConfigRepository;

    public UserConfigController(IUserConfigRepository userConfigRepository)
    {
        _userConfigRepository = userConfigRepository;
    }
}