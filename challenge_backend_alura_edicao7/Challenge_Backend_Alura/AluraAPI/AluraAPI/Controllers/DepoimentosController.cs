using AluraAPI.Data;
using AluraAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AluraAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DepoimentosController : ControllerBase
{
    private DepoimentoContext _context;
    private IMapper _mapper;

    public DepoimentosController(DepoimentoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult insereDepoimento([FromBody] Depoimento depoimentoDto)
    {
        Depoimento depoimento = _mapper.Map<Depoimento>(depoimentoDto);
        _context.Depoimentos.Add(depoimento);
        _context.SaveChanges();
        return CreatedAtAction(nameof(retornaDepoimentoPorId), new { id = depoimento.Id }, depoimento);
    }

    [HttpGet]
    public IEnumerable<Depoimento> retornaDepoimentos([FromQuery] int skip = 0, [FromQuery]  int take = 50)
    {
        return _context.Depoimentos.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult retornaDepoimentoPorId(int id)
    {
        var depoimento = _context.Depoimentos.FirstOrDefault(depoimento => depoimento.Id == id);

        if (depoimento == null) return NotFound();
        return Ok();
    }
}
