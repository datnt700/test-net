using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data;
using WebApplication1.Helpers;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers;

public class CoursController : Controller
{
    private readonly ApplicationDbContext _context;

    public CoursController(ApplicationDbContext context)
    {
        _context = context;
    }
    // GET

    public IActionResult Create()
    {
        var categories = _context.Categories
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            })
            .ToList();

        var viewModel = new CourseFormViewModel
        {
            Categories = categories
        };

        return View(viewModel); 
    }

    [HttpPost]
    public IActionResult Create(CourseFormViewModel course)
    {
        if (!ModelState.IsValid)
        {
            course.Categories = _context.Categories
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

            return View(course);
        }
        
        var courseModel = CourseMapping.ToEntity(course);
        _context.Courses.Add(courseModel);
        _context.SaveChanges();
        return RedirectToAction("Index", "Home");
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var course = _context.Courses.Find(id);
        if (course == null) return NotFound();
        var courseView = CourseMapping.ToViewModel(course);
        return View(courseView);
    }
    
    [HttpPost]
    public IActionResult Edit(CourseFormViewModel course)
    {
        if (!ModelState.IsValid)
        {
            return View(course);
        }
        var courseToEdit = _context.Courses.Find(course.Id);
        if (courseToEdit == null)
        {
            return NotFound();
        }
        courseToEdit.Title = course.Title;
        courseToEdit.Description = course.Description;
        courseToEdit.ImageUrl = course.ImageUrl;
        courseToEdit.Prix = course.Prix;
        courseToEdit.Rating = course.Rating;
        _context.SaveChanges();
        return RedirectToAction("Index", "Home");
    }
    [HttpGet]
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var course = _context.Courses.Find(id);
        if (course == null) return NotFound();
        _context.Courses.Remove(course);
        _context.SaveChanges();
        return RedirectToAction("Index", "Home");
    }
    
}