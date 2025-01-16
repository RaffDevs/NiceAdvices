using NiceAdvices.Core.Entities;
using NiceAdvices.Infrastructure.Models.DTOs;

namespace NiceAdvices.Infrastructure.Models.Extensions;

public static class AdviceResponseExtension
{
    public static Advice ToEntity(this AdviceServiceDTO adviceServiceDTO)
    {
        return new Advice
        {
            Code = adviceServiceDTO.Advice.Code,
            Text = adviceServiceDTO.Advice.Advice
        };
    }
}