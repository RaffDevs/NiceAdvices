using MediatR;
using NiceAdvices.Shared.ViewModels;

namespace NiceAdvives.Application.Commands.TranslateAdvice;

public class TranslateAdviceCommand : IRequest<AdviceViewModel>
{
    public int AdviceId { get; set; }
}