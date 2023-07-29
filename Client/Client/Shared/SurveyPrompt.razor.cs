using Microsoft.AspNetCore.Components;

namespace Client.Shared;

public partial class SurveyPrompt : ComponentBase
{
    [Parameter]
    public string? Title { get; set; }
}