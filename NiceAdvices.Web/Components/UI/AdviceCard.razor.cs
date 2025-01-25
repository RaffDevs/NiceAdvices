using Microsoft.AspNetCore.Components;
using MudBlazor;
using NiceAdvices.Shared.ViewModels;

namespace NiceAdvices.Web.Components.UI;

public partial class AdviceCard : ComponentBase
{
    [Inject]
    private IDialogService DialogService { get; set; }
    
    [Inject]
    private NavigationManager NavigationManager { get; set; }
    
    [Parameter]
    public string StyleClass { get; set; }
    
    [Parameter]
    public AdviceDetailsViewModel Advice { get; set; }
    
    [Parameter]
    public EventCallback<AdviceDetailsViewModel> OnDelete { get; set; }


    private async void ExecuteOnDelete()
    {
        await ShowDeleteDialog();
    }

    private void ExecuteOnTranslate()
    {
        NavigationManager.NavigateTo($"translate/{Advice.Id}");
    }

    private async Task ShowDeleteDialog()
    {
        var dialog = await DialogService.ShowAsync<AdviceDeleteDialog>("Delete Advice");
        var result = await dialog.Result;
        
        if (!result.Canceled)
        {
            await OnDelete.InvokeAsync();
        }
    }
}