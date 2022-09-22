using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.GerenteDto;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : Controller
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public GerenteController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpPost] //Verbo http da ação
        public IActionResult AdicionaGerente([FromBody] CreateGerenteDto cinemaDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(cinemaDto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaGerentePorId), new { id = gerente.Id }, gerente);
        }



        [HttpGet]
        public IEnumerable<Gerente> RecuperaGerente()
        {
            return _context.Gerentes;
        }



        [HttpGet("{id}")]
        public IActionResult RecuperaGerentePorId(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente != null)
            {
                ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);
                return Ok(gerenteDto);
            }
            return NotFound();
        }
    }
}
