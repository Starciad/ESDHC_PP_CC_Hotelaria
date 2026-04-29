using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotelaria.Server.Data;
using Hotelaria.Server.Models;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly AppDbContext _context;

    public EmployeeController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _context.Employees.ToListAsync());

    [HttpPost]
    public async Task<IActionResult> Create(Employee e)
    {
        _context.Employees.Add(e);
        await _context.SaveChangesAsync();
        return Ok(e);
    }
}