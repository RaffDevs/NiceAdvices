using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NiceAdvices.Shared.ViewModels;
using NiceAdvices.Web.Components.State;

namespace NiceAdvices.Web.Components.Pages;

public partial class Translate : ComponentBase
{
    [Inject]
    private AdviceState AdviceState { get; set; }
    
    [Inject]
    private HttpClient HttpClient { get; set; }
    
    [Inject]
    private IJSRuntime JsRuntime { get; set; }
    
    [Parameter]
    public int AdviceId { get; set; }
    
    private AdviceViewModel? Advice { get; set; }
    private bool IsProcessing { get; set; } = true;
    
    protected override async Task OnParametersSetAsync()
    {
        Advice = await TranslateAdvice();
        IsProcessing = false;
        StateHasChanged();
    }
    

    private async Task<AdviceViewModel> TranslateAdvice()
    {
        if (HttpClient == null)
        {
            throw new InvalidOperationException("HttpClient is not initialized.");
        }

        var result = await HttpClient.PostAsJsonAsync("advice/translate/", AdviceId);
        if (result.IsSuccessStatusCode)
        {
            var content = await result.Content.ReadFromJsonAsync<AdviceViewModel>();
            return content;
        }
        
        var errorString = await result.Content.ReadAsStringAsync();
        throw new Exception($"Failed to translate advice - {errorString}");
    }

    private async Task GoBack()
    {
        await JsRuntime.InvokeVoidAsync("goBack");
    }
}