using Microsoft.AspNetCore.Components;

namespace Client.Shared;

public partial class NavMenu : ComponentBase
{
    private bool _collapseNavMenu = false;

    private string? NavMenuCssClass => _collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        _collapseNavMenu = !_collapseNavMenu;
    }
}