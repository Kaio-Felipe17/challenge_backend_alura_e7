using AluraAPI.Data;
using AluraAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

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
        #region Setting folder path and file name and saving the photos
        string folderPath = "C:\\Users\\kaio0\\OneDrive\\Desktop\\projetos\\challenge_backend_alura_e7\\challenge_backend_alura_edicao7\\Challenge_Backend_Alura\\AluraAPI\\AluraAPI\\Photos";
        string fileName = $"{depoimentoDto.nome}.jpg";
        string fullPath = Path.Combine(folderPath, fileName);
        byte[] photoBytes = Convert.FromBase64String(depoimentoDto.foto);
        System.IO.File.WriteAllBytes(fullPath, photoBytes);
        #endregion

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
