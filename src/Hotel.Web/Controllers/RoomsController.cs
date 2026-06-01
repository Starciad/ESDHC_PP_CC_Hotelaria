using Hotel.Web.Data;
using Hotel.Web.Models;
using Hotel.Web.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Controllers
{
    // Este controlador é responsável por gerenciar as ações relacionadas à exibição dos
    // quartos disponíveis no hotel. Ele possui uma ação Index que recebe um filtro
    // para pesquisar quartos por título, faixa de preço e capacidade. A ação utiliza
    // o AppDatabaseContext para acessar os dados do banco de dados e retorna uma view
    // com uma lista de quartos que correspondem aos critérios de pesquisa, bem como
    // informações de paginação para facilitar a navegação entre os resultados.
    public sealed class RoomsController(AppDatabaseContext appDatabaseContext) : Controller
    {
        private const int PAGE_SIZE = 9;

        [HttpGet]
        public async Task<IActionResult> Index(RoomFilterViewModel filter)
        {
            IQueryable<Room> query = appDatabaseContext.Rooms.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                query = query.Where(r => EF.Functions.Like(r.Title, $"%{filter.Search}%"));
            }

            if (filter.MinPrice.HasValue)
            {
                query = query.Where(r => (double)r.Price >= (double)filter.MinPrice.Value);
            }

            if (filter.MaxPrice.HasValue)
            {
                query = query.Where(r => (double)r.Price <= (double)filter.MaxPrice.Value);
            }

            if (filter.Capacity.HasValue)
            {
                query = query.Where(r => r.Capacity >= filter.Capacity.Value);
            }

            int totalRooms = await query.CountAsync();
            int totalPages = (int)Math.Ceiling(totalRooms / (double)PAGE_SIZE);

            List<Room> rooms = await query
                .OrderBy(r => (double)r.Price)
                .Skip((filter.Page - 1) * PAGE_SIZE)
                .Take(PAGE_SIZE)
                .ToListAsync();

            RoomsIndexViewModel viewModel = new()
            {
                Rooms = rooms,
                Filter = filter,
                CurrentPage = filter.Page,
                TotalPages = totalPages
            };

            return View(viewModel);
        }
    }
}
