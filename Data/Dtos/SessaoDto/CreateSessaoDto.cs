namespace FilmesAPI.Data.Dtos.SessaoDto
{
    public class CreateSessaoDto
    {
        public int FilmeId { get; set; }
        public int CinemaId { get; set; }

        public DateTime HorarioDeEncerramento { get; set; }
    }
}
