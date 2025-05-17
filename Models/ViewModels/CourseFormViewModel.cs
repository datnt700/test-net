using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Models.ViewModels;

public class CourseFormViewModel
{
    public int? Id { get; set; }

    [Required]
    public string Title { get; set; }

    public string Description { get; set; }
    public string? ImageUrl { get; set; }

    [Range(0, 1000)]
    public decimal Prix { get; set; }

    public decimal Rating { get; set; }
    public List<SelectListItem>? Categories { get; set; }
    public int CategoryId { get; set; }
}