using Microsoft.AspNetCore.Components;
using MudBlazor;
using NiceAdvices.Infrastructure.Services;
using NiceAdvices.Shared.ViewModels;
using NiceAdvices.Web.Components.State;
using NiceAdvices.Web.Components.UI;

namespace NiceAdvices.Web.Components.Pages;

public partial class Favorites : ComponentBase
{
    [Inject]
    private AdviceState AdviceState { get; set; }
    
    [Inject]
    private HttpClient HttpClient { get; set; }
    
    [Inject]
    private IDialogService DialogService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await LoadFavoriteAdvices();
    }

    private async Task<List<AdviceDetailsViewModel>> GetFavorites()
    {
        var result = await HttpClient.GetAsync("advice/list");
        if (result.IsSuccessStatusCode)
        {
            var content = await result.Content.ReadFromJsonAsync<List<AdviceDetailsViewModel>>();
            return content;
        }

        throw new Exception("Failed to get favorites");
    }

    private async void HandleDelete(AdviceDetailsViewModel advice)
    {
        var result = await HttpClient.DeleteAsync($"advice/{advice.Id}");
        if (result.IsSuccessStatusCode)
        {
            await LoadFavoriteAdvices();
            return;
        }
        
        var errorString = await result.Content.ReadAsStringAsync();
        throw new Exception($"Failed to delete advice - {errorString}");
    }

    private async void HandleAdviceDialog()
    {
        var options = new DialogOptions
        {
            MaxWidth = MaxWidth.Medium
        };

        var dialog = await DialogService.ShowAsync<AdviceCreateDialog>(null, options);
    }

    private async Task LoadFavoriteAdvices()
    {
        AdviceState.FavoriteAdvices = await GetFavorites();
        StateHasChanged();
    }
}