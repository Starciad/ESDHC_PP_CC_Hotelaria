using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotelaria.Server.Data;
using Hotelaria.Server.Models;


namespace Hotelaria.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestController : ControllerBase
    {
        private static List<Guest> guests = new List<Guest>();
        private static int nextId = 1;

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(guests);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var guest = guests.FirstOrDefault(g => g.Id == id);
            if (guest == null) return NotFound();
            return Ok(guest);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Guest guest)
        {
            guest.Id = nextId++;
            guests.Add(guest);
            return CreatedAtAction(nameof(GetById), new { id = guest.Id }, guest);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Guest updatedGuest)
        {
            var guest = guests.FirstOrDefault(g => g.Id == id);
            if (guest == null) return NotFound();

            guest.Name = updatedGuest.Name;
            guest.Email = updatedGuest.Email;
            guest.CPF = updatedGuest.CPF;
            guest.Telephone = updatedGuest.Telephone;
            guest.Phone = updatedGuest.Phone;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var guest = guests.FirstOrDefault(g => g.Id == id);
            if (guest == null) return NotFound();

            guests.Remove(guest);
            return NoContent();
        }
    }
}