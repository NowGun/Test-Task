using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testovoe.Models
{
    public class Film
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название фильма")]
        [Display(Name = "Название фильма")]
        [MinLength(3, ErrorMessage = "Минимальная длина 3 символа")]
        public string Name { get; set; } = null!;

        [Display(Name = "Описание")]
        public string? Description { get; set; }

        [DataType(DataType.Date)]
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
