using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotelaria.Server.Data;
using Hotelaria.Server.Models;

[ApiController]
[Route("api/[controller]")]
public class DependentController : ControllerBase
{
    private readonly AppDbContext _context;

    public DependentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _context.Dependents.ToListAsync());

    [HttpPost]
    public async Task<IActionResult> Create(Dependent d)
    {
        _context.Dependents.Add(d);
        await _context.SaveChangesAsync();
        return Ok(d);
    }
}