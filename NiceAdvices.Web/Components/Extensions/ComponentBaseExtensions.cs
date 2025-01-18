using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace NiceAdvices.Web.Components.Extensions;

public static class ComponentBaseExtensions
{
    public static void ShowSnackbar(this ComponentBase component, ISnackbar snackbar, Severity severity, string message)
    {
        snackbar.Clear();
        snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomEnd;
        snackbar.Add(message, severity);
    }
    
}