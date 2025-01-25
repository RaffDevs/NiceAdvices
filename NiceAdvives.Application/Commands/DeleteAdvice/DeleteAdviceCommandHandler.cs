using MediatR;
using NiceAdvices.Core.Repositories;

namespace NiceAdvives.Application.Commands.DeleteAdvice;

public class DeleteAdviceCommandHandler : IRequestHandler<DeleteAdviceCommand>
{
    private readonly IAdviceRepository _adviceRepository;

    public DeleteAdviceCommandHandler(IAdviceRepository adviceRepository)
    {
        _adviceRepository = adviceRepository;
    }

    public async Task Handle(DeleteAdviceCommand request, CancellationToken cancellationToken)
    {
        var advice = await _adviceRepository.GetById(request.Id);
        if (advice == null)
        {
            throw new Exception("Advice not found");
        }

        await _adviceRepository.Delete(advice);
    }
}