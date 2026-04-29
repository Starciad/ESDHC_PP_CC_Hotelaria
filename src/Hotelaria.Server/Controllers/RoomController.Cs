using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotelaria.Server.Data;
using Hotelaria.Server.Models;

[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{
    private readonly AppDbContext _context;

    public RoomController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _context.Rooms.ToListAsync());

    [HttpPost]
    public async Task<IActionResult> Create(Room r)
    {
        _context.Rooms.Add(r);
        await _context.SaveChangesAsync();
        return Ok(r);
    }
}