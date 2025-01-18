namespace NiceAdvices.Shared.InputModels;

public record SaveAdviceInputModel
{
    public string Text { get; set; }
    public string Author { get; set; }
    public string Code { get; set; }
};