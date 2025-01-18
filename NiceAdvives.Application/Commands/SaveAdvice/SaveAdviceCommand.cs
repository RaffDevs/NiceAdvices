using MediatR;
using NiceAdvices.Shared.InputModels;

namespace NiceAdvives.Application.Commands.SaveAdvice;

public class SaveAdviceCommand : IRequest
{
    public SaveAdviceInputModel Model { get; set; }
}