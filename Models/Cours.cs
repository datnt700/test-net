namespace WebApplication1.Models;

public class Cours
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }


    public string? ImageUrl { get; set; }
    public decimal Prix { get; set; }
    public decimal Rating { get; set; }
    
    public int CategoryId { get; set; }  // FK
    public Category Category { get; set; }  // Navigation
}