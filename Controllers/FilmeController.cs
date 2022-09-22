using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.FilmeDto;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController] // Para controlar a API
    [Route("[controller]")] // A route de forma generica vai ser "controler" que faz referencia a classe FilmeController
    public class FilmeController : Controller //Vai Herdar propriedades da classe base Controller
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost] //Verbo http da ação
        public IActionResult AdicionaFilmes([FromBody] CreateFilmeDto filmeDto) //IActionResult porque é o tipo de retorno, uma ação
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { id = filme.Id }, filme); //Criar uma ação no Header da API, tal como caminho e o filme(id)
        }

        [HttpGet] //Para pegar informação
        public IActionResult RecuperaFilmes([FromQuery] int classificacaoEtaria = 18) //IActionResult porque é o tipo de retorno, uma ação
        {
            List<Filme> filmes = _context.Filmes.Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            if(filmes != null)
            {
                List<ReadFilmeDto> readDto = _mapper.Map<List<ReadFilmeDto>>(filmes);
                return Ok(readDto);
            }
            return NotFound();
             
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id) //IActionResult porque é o tipo de retorno, uma ação
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id); //Primeiro id == Id vai retornar um Ok, senão um NotFound
            if (filme != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
                return Ok(filmeDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
