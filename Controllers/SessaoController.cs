using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.SessaoDto;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController] 
    [Route("[controller]")]
    public class SessaoController : Controller 
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public SessaoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost] //Verbo http da ação
        public IActionResult AdicionaSessao([FromBody] CreateSessaoDto sessaoDto) 
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSessoesPorId), new { id = sessao.Id }, sessao); 
        }

        [HttpGet] //Para pegar informação
        public IEnumerable<Sessao> RecuperaSessao() 
        {
            return _context.Sessoes; 
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessoesPorId(int id) 
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id); 
            if (sessao != null)
            {
                ReadSessaoDto SessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
                return Ok(SessaoDto);
            }
            return NotFound();
        }
    }
}
