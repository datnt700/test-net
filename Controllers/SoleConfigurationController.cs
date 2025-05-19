using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Controllers;

public class SoleConfigurationController: Controller
{
    private readonly ApplicationDbContext _context;
    
    public SoleConfigurationController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        ViewBag.Active = "Projets";
        var soleConfig = _context.SoleConfigurations
            .Include(s => s.Layers)
            .FirstOrDefault(); // hoặc theo id nếu cần

        // var soleConfig = _context.SoleConfigurations
        //     .Include(s => s.Layers)
        //     .FirstOrDefault(s => s.Id == id);
        if (soleConfig == null)
            return NotFound();
        // return RedirectToAction("Index", "SoleConfiguration", new { id = 5 });

        return View(soleConfig); 
    }
    
    // GET: /SoleConfiguration/Details/5
    public IActionResult Details(int id)
    {
        var config = _context.SoleConfigurations
            .Include(sc => sc.Layers)
            .FirstOrDefault(sc => sc.Id == id);
    
        if (config == null)
            return NotFound();
    
        return View(config);
    }
}