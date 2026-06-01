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
    // Este controlador é responsável por gerenciar as ações relacionadas
    // às reservas de quartos. Ele possui ações para criar uma nova reserva
    // e exibir uma página de sucesso após a criação da reserva. O controlador
    // utiliza o AppDatabaseContext para acessar os dados do banco de dados e o
    // UserManager para obter informações sobre o usuário autenticado. Ele
    // também realiza validações para garantir que as datas de check-in e
    // check-out sejam válidas, que a capacidade do quarto seja respeitada
    // e que não haja conflitos com outras reservas existentes.
    public sealed class ReservationsController(
        AppDatabaseContext context,
        UserManager<ApplicationUser> userManager
    ) : Controller
    {
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

            Room? room = await context.Rooms
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == roomId);

            if (room is null)
            {
                return NotFound();
            }

            ApplicationUser? appUser = await userManager.GetUserAsync(User);

            if (appUser is null)
            {
                return Challenge();
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

            Room? room = await context.Rooms
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

            bool conflict = await context.Reserves.AnyAsync(r =>
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

            ApplicationUser? appUser = await userManager.GetUserAsync(User);

            if (appUser is null)
            {
                return Challenge();
            }

            Guest? guest = await context.Guests.FirstOrDefaultAsync(g => g.ApplicationUserId == appUser.Id);

            if (guest is null)
            {
                guest = new()
                {
                    ApplicationUserId = appUser.Id,
                    Name = appUser.FullName,
                    CPF = appUser.CPF,
                    Phone = appUser.PhoneNumber
                };

                _ = context.Guests.Add(guest);
                _ = await context.SaveChangesAsync();
            }

            await using IDbContextTransaction transaction = await context.Database.BeginTransactionAsync();

            Reserve reserve = new()
            {
                RoomId = room.Id,
                GuestId = guest.Id,
                PretendedCheckInDate = model.PretendedCheckInDate.Date,
                PretendedCheckOutDate = model.PretendedCheckOutDate.Date
            };

            _ = context.Reserves.Add(reserve);
            _ = await context.SaveChangesAsync();

            foreach (ReservationDependentInputViewModel dependent in model.Dependents)
            {
                _ = context.ReserveDependents.Add(new()
                {
                    ReserveId = reserve.Id,
                    Name = dependent.Name,
                    BirthdayDate = dependent.BirthdayDate.Date
                });
            }

            _ = await context.SaveChangesAsync();
            await transaction.CommitAsync();

            return RedirectToAction(nameof(Success), new { id = reserve.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Success(int id)
        {
            Reserve? reserve = await context.Reserves
                .Include(r => r.Room)
                .Include(r => r.Guest)
                .Include(r => r.Dependents)
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id);

            return reserve is null ? NotFound() : View(reserve);
        }
    }
}
