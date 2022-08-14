using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testovoe.Data;
using Microsoft.EntityFrameworkCore;
using testovoe.Models;

namespace testovoe.Controllers
{
    public class FilmController : Controller
    {
        ApplicationDbContext _db;
        IWebHostEnvironment _appEnvironment;
        public FilmController(ApplicationDbContext db, IWebHostEnvironment appEnvironment)
        {
            _db = db;
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
                string userID = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (model.File != null)
                {
                    string path = $"/images/posters/{userID}_{model.File.FileName}";
                    using var file = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create);
                    await model.File.CopyToAsync(file);
                }

                Film film = new()
                {
                    Name = model.Name,
                    Description = model.Description,
                    YearRelease = model.YearRelease,
                    Producer = model.Producer,
                    PosterName = model.File == null ? "no_photo.png" : $"{userID}_{model.File.FileName}",
                    UserId = userID
                };

                _db.Films.Add(film);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(int id) => View(await _db.Films.FirstOrDefaultAsync(film => film.Id == id));

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(Film model)
        {
            if (ModelState.IsValid)
            {
                Film? film = await _db.Films.FirstOrDefaultAsync(film => film.Id == model.Id);
                string userID = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (film != null)
                {
                    if (model.File != null)
                    {
                        FileInfo fileDel = new(_appEnvironment.WebRootPath + $"/images/posters/{film.PosterName}");
                        if (fileDel.Exists) fileDel.Delete();

                        string path = $"/images/posters/{userID}_{model.File.FileName}";

                        using var file = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create);
                        await model.File.CopyToAsync(file);
                    }

                    film.Name = model.Name;
                    film.Description = model.Description;
                    film.Producer = model.Producer;
                    film.YearRelease = model.YearRelease;
                    film.PosterName = model.File?.Name == null ? film.PosterName : $"{userID}_{model.File.FileName}";

                    await _db.SaveChangesAsync();

                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var film = await _db.Films.FindAsync(id);

            if (film != null)
            {
                if (film.PosterName != "no_photo.png")
                {
                    FileInfo file = new(_appEnvironment.WebRootPath + $"/images/posters/{film.PosterName}");

                    if (file.Exists) file.Delete();
                }

                _db.Films.Remove(film);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("MyFilm", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Info(int id) => View(await _db.Films.FirstOrDefaultAsync(film => film.Id == id));
    }
}
