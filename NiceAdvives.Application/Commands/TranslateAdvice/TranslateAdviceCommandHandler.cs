using MediatR;
using NiceAdvices.Core.Repositories;
using NiceAdvices.Infrastructure.Services;
using NiceAdvices.Shared.ViewModels;

namespace NiceAdvives.Application.Commands.TranslateAdvice;

public class TranslateAdviceCommandHandler : IRequestHandler<TranslateAdviceCommand, AdviceViewModel>
{
    private readonly TranslatorService _translatorService;
    private readonly IAdviceRepository _adviceRepository;

    public TranslateAdviceCommandHandler(TranslatorService translatorService, IAdviceRepository adviceRepository)
    {
        _translatorService = translatorService;
        _adviceRepository = adviceRepository;
    }

    public async Task<AdviceViewModel> Handle(TranslateAdviceCommand request, CancellationToken cancellationToken)
    {
        var advice = await _adviceRepository.GetById(request.AdviceId);
        if (advice is null)
        {
            throw new Exception("Advice not found");
        }

        var translatedAdvice = await _translatorService.Translate(advice.Text);
        
        if (translatedAdvice is null)
        {
            throw new Exception("Failed to translate advice");
        }

        return new AdviceViewModel(translatedAdvice.Text, translatedAdvice.Author, translatedAdvice.Code);
    }
}