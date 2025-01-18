using Microsoft.AspNetCore.Components;
using NiceAdvices.Infrastructure.Services;

namespace NiceAdvices.Web.Components.Pages;

public partial class Favorites : ComponentBase
{
    [Inject]
    private AdviceService AdviceService { get; set; }
    
}