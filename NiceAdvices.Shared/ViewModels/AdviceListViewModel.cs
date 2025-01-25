namespace NiceAdvices.Shared.ViewModels;

public record AdviceDetailsViewModel(
    int Id,
    string Text,
    string Author,
    string? Code
);