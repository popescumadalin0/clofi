using Server.Interfaces;

namespace Server.Controllers;

public class UserConfigController : BaseController
{
    private readonly IUserConfigRepository _userConfigRepository;

    public UserConfigController(IUserConfigRepository userConfigRepository)
    {
        _userConfigRepository = userConfigRepository;
    }
}