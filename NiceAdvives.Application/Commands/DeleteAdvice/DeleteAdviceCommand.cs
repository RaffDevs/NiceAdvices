using MediatR;

namespace NiceAdvives.Application.Commands.DeleteAdvice;

public class DeleteAdviceCommand : IRequest
{
    public int Id { get; set; }
}