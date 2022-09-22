using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.CinemaDto
{
    public class UptadeCinemaDto
    {
        [Required]
        public string Nome { get; set; }
    }
}
