using System.Text.Json.Serialization;

namespace NiceAdvices.Infrastructure.Models.DTOs;

public record TranslatorResponseDTO
{
    [JsonPropertyName("translations")]
    public List<TranslatorDTO> Translations { get; init; }
}

public record TranslatorDTO
{
    [JsonPropertyName("text")]
    public string Text { get; init; }
    
    [JsonPropertyName("to")]
    public string To { get; init; }
}

public record TranslatorRequestDTO {
    [JsonPropertyName("text")]
    public string Text { get; init; }
}
