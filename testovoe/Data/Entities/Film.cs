using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using testovoe.Models;

namespace testovoe.Data.Entities
{
    public class Film
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Название фильма обязательно")]
        [Display(Name = "Название фильма")]
        public string Name { get; set; } = null!;

        [Display(Name = "Описание")]
        public string? Description { get; set; }

        [Display(Name = "Дата выпуска")]
        public string? YearRelease { get; set; }

        [Display(Name = "Режиссёр")]
        public string? Producer { get; set; }

        public string? PosterName { get; set; }

        [NotMapped]
        [Display(Name = "Постер")]
        public IFormFile? File { get; set; }

        public string? UserId { get; set; }

        public virtual User? UserNavigation { get; set; }
    }
}
