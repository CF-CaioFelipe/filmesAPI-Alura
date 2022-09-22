using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.GerenteDto
{
    public class CreateGerenteDto
    {
        [Required]
        public string Nome { get; set; }
    }
}
