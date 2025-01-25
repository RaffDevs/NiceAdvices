using MediatR;
using NiceAdvices.Shared.ViewModels;

namespace NiceAdvives.Application.Queries.GetFavoriteAdvices;

public class GetFavoriteAdvicesQuery : IRequest<List<AdviceDetailsViewModel>>
{
    
}