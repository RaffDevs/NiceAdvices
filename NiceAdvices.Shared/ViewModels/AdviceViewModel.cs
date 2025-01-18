namespace NiceAdvices.Shared.ViewModels;

public record AdviceViewModel(
    string Text, 
    string Author, 
    string? Code 
);