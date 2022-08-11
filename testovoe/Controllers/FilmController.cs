using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testovoe.Data;
using testovoe.Data.Entities;

namespace testovoe.Controllers
{
    public class FilmController : Controller
    {
        ApplicationDbContext db;
        IWebHostEnvironment _appEnvironment;
        public FilmController(ApplicationDbContext db, IWebHostEnvironment appEnvironment)
        {
            this.db = db;
            _appEnvironment = appEnvironment;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Add() => View();

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(Film model)
        {
            if (ModelState.IsValid)
            {
                if (model.File != null)
                {
                    string path = $"/images/posters/{model.File.FileName}";

                    using var file = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create);

                    Film film = new()
                    {
                        Name = model.Name,
                        Description = model.Description,
                        YearRelease = model.YearRelease,
                        Producer = model.Producer,
                        PosterName = model.File.FileName,
                        UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                    };

                    db.Films.Add(film);
                    db.SaveChanges();

                    await model.File.CopyToAsync(file);
                }
                /* db.Films.Add(model);
                 await db.SaveChangesAsync();*/
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [Authorize]
        public IActionResult Edit() => View();


        public IActionResult Film() => View();
    }
}
