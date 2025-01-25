using NiceAdvices.Shared.ViewModels;

namespace NiceAdvices.Web.Components.State;

public class AdviceState
{
    public AdviceViewModel? CurrentAdvice { get; set; }

    public List<AdviceDetailsViewModel> FavoriteAdvices { get; set; } = [];

}