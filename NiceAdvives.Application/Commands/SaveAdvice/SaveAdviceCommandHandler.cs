using MediatR;
using NiceAdvices.Core.Entities;
using NiceAdvices.Core.Repositories;

namespace NiceAdvives.Application.Commands.SaveAdvice;

public class SaveAdviceCommandHandler : IRequestHandler<SaveAdviceCommand>
{
    private readonly IAdviceRepository _adviceRepository;

    public SaveAdviceCommandHandler(IAdviceRepository adviceRepository)
    {
        _adviceRepository = adviceRepository;
    }

    public async Task Handle(SaveAdviceCommand request, CancellationToken cancellationToken)
    {
        var advice = new Advice
        {
            Code = request.Model.Code,
            Text = request.Model.Text,
            Author = request.Model.Author
        };

        var _ = await _adviceRepository.Create(advice);
        return;
    }
}