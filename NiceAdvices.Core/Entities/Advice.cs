using System.ComponentModel.DataAnnotations;

namespace NiceAdvices.Core.Entities;

public class Advice
{
    [Key]
    public int Id { get; set; }
    
    public string Text { get; set; }
    
    public string Author { get; set; }
    
    public string? Code { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public Advice()
    {
        CreatedAt = DateTime.Now;
    }
}