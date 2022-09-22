using FilmesAPI.Models;

namespace FilmesAPI.Data.Dtos.GerenteDto
{
    public class ReadGerenteDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Object Cinemas { get; set; }
    }
}
