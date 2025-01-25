using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using NiceAdvices.Shared.InputModels;

namespace NiceAdvices.Web.Components.UI;

public partial class AdviceCreateDialog : ComponentBase
{
    [CascadingParameter]
    private IMudDialogInstance MudDialog { get; set; }

    private CreateAdviceInputModel Model = new CreateAdviceInputModel();

    private void Cancel()
    {
        MudDialog.Cancel();
    }
}