using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using testovoe.Data;
using testovoe.Models;
using testovoe.ViewModels;
using testovoe.ViewModels.Pagination;

namespace testovoe.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 4;

            var source = await _db.Films.ToListAsync();
            var count = source.Count;
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pgm = new(count, page, pageSize);
            IndexViewModel ivm = new()
            {
                PageViewModel = pgm,
                Films = items
            };

            return View(ivm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> MyFilm()
        {
            return View(await _db.Films.Where(f => f.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToListAsync());
        }
    }
}