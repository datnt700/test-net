using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Helpers;

public static class CourseMapping
{
    public static CourseFormViewModel ToViewModel(Cours entity)
    {
        return new CourseFormViewModel
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            Prix = entity.Prix,
            Rating = entity.Rating,
            ImageUrl = entity.ImageUrl,
            CategoryId = entity.CategoryId
        };
    }

    public static Cours ToEntity(CourseFormViewModel vm)
    {
        return new Cours
        {
            Id = vm.Id ?? 0,
            Title = vm.Title,
            Description = vm.Description,
            Prix = vm.Prix,
            Rating = vm.Rating,
            ImageUrl = vm.ImageUrl,
            CategoryId = vm.CategoryId
        };
    }
}