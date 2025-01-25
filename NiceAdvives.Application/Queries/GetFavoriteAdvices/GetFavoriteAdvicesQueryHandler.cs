using MediatR;
using NiceAdvices.Core.Repositories;
using NiceAdvices.Shared.ViewModels;

namespace NiceAdvives.Application.Queries.GetFavoriteAdvices;

public class GetFavoriteAdvicesQueryHandler : IRequestHandler<GetFavoriteAdvicesQuery, List<AdviceDetailsViewModel>>
{
    private readonly IAdviceRepository _adviceRepository;

    public GetFavoriteAdvicesQueryHandler(IAdviceRepository adviceRepository)
    {
        _adviceRepository = adviceRepository;
    }

    public async Task<List<AdviceDetailsViewModel>> Handle(GetFavoriteAdvicesQuery request,
        CancellationToken cancellationToken)
    {
        var advices = await _adviceRepository.Get();
        return advices.Select(advice => new AdviceDetailsViewModel(advice.Id, advice.Text, advice.Author, advice.Code)).ToList();
    }
}