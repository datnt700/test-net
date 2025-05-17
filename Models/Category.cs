namespace WebApplication1.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Navigation: một Category có nhiều Cours
    public ICollection<Cours> CoursList { get; set; }
}