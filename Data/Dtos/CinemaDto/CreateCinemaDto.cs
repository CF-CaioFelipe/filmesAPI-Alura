using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.CinemaDto
{
    public class CreateCinemaDto
    {      
        [Required]
        public string Nome { get; set; }

        public int EnderecoId { get; set; }

        public int GerenteId { get; set; } 
    }
}
