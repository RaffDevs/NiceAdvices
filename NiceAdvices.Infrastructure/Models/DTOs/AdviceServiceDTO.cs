using System.Text.Json.Serialization;

namespace NiceAdvices.Infrastructure.Models.DTOs;

public record AdviceServiceDTO
{
    [JsonPropertyName("slip")]
    public AdviceDTO Advice { get; init; }
}

public record AdviceDTO
{
    [JsonPropertyName("id")]
    public int Code { get; init; }
    
    [JsonPropertyName("advice")]
    public string Advice { get; init; }
};