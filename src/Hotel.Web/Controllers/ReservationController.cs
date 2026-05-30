using Hotel.Web.Data;
using Hotel.Web.Models;
using Hotel.Web.ViewModels;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using System;
using System.Threading.Tasks;

namespace Hotel.Web.Controllers
{
    public class ReservationsController(
        AppDatabaseContext context,
        UserManager<ApplicationUser> userManager
    ) : Controller
    {
        private readonly AppDatabaseContext _context = context;
        private readonly UserManager<ApplicationUser> _userManager = userManager;

        [HttpGet]
        public async Task<IActionResult> Create(int roomId)
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction(
                    "Register",
                    "Account",
                    new { returnUrl = Url.Action(nameof(Create), new { roomId }) });
            }

            Room? room = await _context.Rooms
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == roomId);

            if (room is null)
            {
                return NotFound();
            }

            ReservationCreateViewModel model = new()
            {
                RoomId = room.Id,
                RoomTitle = room.Title,
                RoomDescription = room.Description,
                RoomImageUrl = room.ImageUrl,
                RoomPrice = room.Price,
                RoomCapacity = room.Capacity,
                PretendedCheckInDate = DateTime.Today.AddDays(1),
                PretendedCheckOutDate = DateTime.Today.AddDays(2)
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservationCreateViewModel model)
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToAction(
                    "Register",
                    "Account",
                    new { returnUrl = Url.Action(nameof(Create), new { roomId = model.RoomId }) });
            }

            Room? room = await _context.Rooms
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == model.RoomId);

            if (room is null)
            {
                return NotFound();
            }

            model.RoomTitle = room.Title;
            model.RoomDescription = room.Description;
            model.RoomImageUrl = room.ImageUrl;
            model.RoomPrice = room.Price;
            model.RoomCapacity = room.Capacity;

            if (model.PretendedCheckInDate.Date < DateTime.Today)
            {
                ModelState.AddModelError(nameof(model.PretendedCheckInDate),
                    "O check-in não pode ser anterior a hoje.");
            }

            if (model.PretendedCheckOutDate.Date <= model.PretendedCheckInDate.Date)
            {
                ModelState.AddModelError(nameof(model.PretendedCheckOutDate),
                    "O check-out deve ser posterior ao check-in.");
            }

            int totalOccupants = 1 + model.Dependents.Count;
            if (totalOccupants > room.Capacity)
            {
                ModelState.AddModelError(string.Empty,
                    "A quantidade total de hóspedes excede a capacidade do quarto.");
            }

            bool conflict = await _context.Reserves.AnyAsync(r =>
                r.RoomId == model.RoomId &&
                r.PretendedCheckInDate < model.PretendedCheckOutDate &&
                model.PretendedCheckInDate < r.PretendedCheckOutDate);

            if (conflict)
            {
                ModelState.AddModelError(string.Empty,
                    "Já existe uma reserva para este quarto nesse período.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ApplicationUser? appUser = await _userManager.GetUserAsync(User);

            if (appUser is null)
            {
                return Challenge();
            }

            Guest? guest = await _context.Guests.FirstOrDefaultAsync(g => g.ApplicationUserId == appUser.Id);

            if (guest is null)
            {
                guest = new()
                {
                    ApplicationUserId = appUser.Id,
                    Name = appUser.FullName,
                    CPF = appUser.CPF,
                    Phone = appUser.PhoneNumber
                };

                _ = _context.Guests.Add(guest);
                _ = await _context.SaveChangesAsync();
            }

            await using IDbContextTransaction transaction = await _context.Database.BeginTransactionAsync();

            Reserve reserve = new()
            {
                RoomId = room.Id,
                GuestId = guest.Id,
                PretendedCheckInDate = model.PretendedCheckInDate.Date,
                PretendedCheckOutDate = model.PretendedCheckOutDate.Date
            };

            _ = _context.Reserves.Add(reserve);
            _ = await _context.SaveChangesAsync();

            foreach (ReservationDependentInputViewModel dependent in model.Dependents)
            {
                _ = _context.ReserveDependents.Add(new()
                {
                    ReserveId = reserve.Id,
                    Name = dependent.Name,
                    BirthdayDate = dependent.BirthdayDate.Date
                });
            }

            _ = await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return RedirectToAction(nameof(Success), new { id = reserve.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Success(int id)
        {
            Reserve? reserve = await _context.Reserves
                .Include(r => r.Room)
                .Include(r => r.Guest)
                .Include(r => r.Dependents)
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id);

            return reserve is null ? NotFound() : View(reserve);
        }
    }
}
