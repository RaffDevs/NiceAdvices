using MediatR;
using NiceAdvices.Core.Repositories;
using NiceAdvices.Infrastructure.Services;
using NiceAdvices.Shared.ViewModels;

namespace NiceAdvives.Application.Queries.GetAdvice;

public class GetAdviceQueryHandler : IRequestHandler<GetAdviceQuery, AdviceViewModel>
{
    private readonly AdviceService _adviceService;

    public GetAdviceQueryHandler(AdviceService adviceService)
    {
        _adviceService = adviceService;
    }

    public async Task<AdviceViewModel> Handle(GetAdviceQuery request, CancellationToken cancellationToken)
    {
        var advice = await _adviceService.GetRandomAdvice();
        return new AdviceViewModel(advice.Text, "SlipAdvice", advice.Code);
    }
}