using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace NiceAdvices.Web.Components.UI;

public partial class AdviceDeleteDialog : ComponentBase
{
    [CascadingParameter]
    private IMudDialogInstance MudDialog { get; set; }

    private void Submit()
    {
        MudDialog.Close(DialogResult.Ok(true));
    }

    private void Cancel()
    {
        MudDialog.Cancel();
    }
}