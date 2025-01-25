using System.ComponentModel.DataAnnotations;

namespace NiceAdvices.Shared.InputModels;

public record CreateAdviceInputModel
{
    [Required(ErrorMessage = "Must have text")]
    public string Text { get; set; }
    
    [Required(ErrorMessage = "Must have author")]
    public string Author { get; set; }
    public string Code { get; set; }

    public CreateAdviceInputModel()
    {
        Code = Guid.NewGuid().ToString();
    }
};