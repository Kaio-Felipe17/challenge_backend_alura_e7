using AluraAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AluraAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DepoimentosController : ControllerBase
{
    private static List<Depoimento> depoimentos = new List<Depoimento>();
    private static int id = 0;

    [HttpPost]
    public IActionResult insereDepoimento([FromBody] Depoimento depoimento)
    {
        depoimento.Id = id++;
        depoimentos.Add(depoimento);
        return CreatedAtAction(nameof(retornaDepoimentoPorId), new { id = depoimento.Id }, depoimento);
    }

    [HttpGet]
    public IEnumerable<Depoimento> retornaDepoimentos([FromQuery] int skip = 0, [FromQuery]  int take = 50)
    {
        return depoimentos.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult retornaDepoimentoPorId(int id)
    {
        var depoimento = depoimentos.FirstOrDefault(depoimento => depoimento.Id == id);

        if (depoimento == null) return NotFound();
        return Ok();
    }
}
