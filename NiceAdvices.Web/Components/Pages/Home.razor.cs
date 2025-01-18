using Microsoft.AspNetCore.Components;
using MudBlazor;
using NiceAdvices.Shared.InputModels;
using NiceAdvices.Shared.ViewModels;
using NiceAdvices.Web.Components.Extensions;
using NiceAdvices.Web.Components.State;

namespace NiceAdvices.Web.Components.Pages;

public partial class Home : ComponentBase
{
    
    [Inject] private ISnackbar Snackbar { get; set; }
    [Inject] private AdviceState AdviceState { get; set; }
    [Inject] private HttpClient HttpClient { get; set; }
    public bool IsLoading { get; set; } = false;
    
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            ToggleIsLoading();
            AdviceState.CurrentAdvice = await GetRandomAdvice();
            ToggleIsLoading();
        }
    }

    private async Task<AdviceViewModel> GetRandomAdvice()
    {
        var request = await HttpClient.GetAsync("advice");
        if (request.IsSuccessStatusCode)
        {
            var content = await request.Content.ReadFromJsonAsync<AdviceViewModel>();
            return content;
        }
        
        throw new Exception("Failed to get advice");
    }
    
    private async Task GetNewAdvice()
    {
        ToggleIsLoading();
        AdviceState.CurrentAdvice = await GetRandomAdvice();
        ToggleIsLoading();

    }
    
    private void ToggleIsLoading()
    {
        IsLoading = !IsLoading;
        StateHasChanged();
    }

    private async void FavoriteAdvice()
    {
        Console.Write(AdviceState.CurrentAdvice.Author);
        var model = new SaveAdviceInputModel
        {
            Text = AdviceState.CurrentAdvice.Text,
            Author = AdviceState.CurrentAdvice.Author,
            Code = AdviceState.CurrentAdvice.Code
        };
        this.ShowSnackbar(Snackbar, Severity.Info, "Sending data");
        ToggleIsLoading();
        var request = await HttpClient.PostAsJsonAsync("advice", model);
        if (request.IsSuccessStatusCode)
        {
            this.ShowSnackbar(Snackbar, Severity.Success, "Advice has been saved!");
            ToggleIsLoading();
            await GetNewAdvice();
        }
        else
        {
            this.ShowSnackbar(Snackbar, Severity.Error, "Failed to save advice");
            ToggleIsLoading();
        }
        
    }
}