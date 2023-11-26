using AluraAPI.Data;
using AluraAPI.Data.Dtos;
using AluraAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using dotenv.net;
using System.Security.Cryptography;

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
        dotenv.net.DotEnv.Load();
        string folderPath = Environment.GetEnvironmentVariable("folderPath");
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
    public IEnumerable<ReadDepoimentoDto> retornaDepoimentos([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadDepoimentoDto>>(_context.Depoimentos.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult retornaDepoimentoPorId(int id)
    {
        var depoimento = _context.Depoimentos.FirstOrDefault(depoimento => depoimento.Id == id);

        if (depoimento == null) return NotFound();
        return CreatedAtAction(nameof(retornaDepoimentoPorId), new { id = depoimento.Id }, depoimento);
    }

    [HttpPut("{id}")]
    public IActionResult atualizaDepoimento(int id, [FromBody] UpdateDepoimentoDto depoimentoDto)
    {
        var depoimento = _context.Depoimentos.FirstOrDefault(depoimento => depoimento.Id == id);
        if (depoimento == null) return NotFound();
        _mapper.Map(depoimentoDto, depoimento);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaDepoimento(int id)
    {
        var depoimento = _context.Depoimentos.FirstOrDefault(depoimento => depoimento.Id == id);
        if (depoimento == null) return NotFound();
        _context.Remove(depoimento);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpGet("depoimentos-home")]
    public List<AluraAPI.Models.Depoimento> retornaDepoimentosAleatoriamente()
    {
        int tamanhoLista = _context.Depoimentos.Count();
        List<AluraAPI.Models.Depoimento> depoimentosAleatorios = new List<AluraAPI.Models.Depoimento>();

        for (int i = 0; i <= 2; i++)
        {
            int idDepoimentoAleatorio = RandomNumberGenerator.GetInt32(1, tamanhoLista);

            var depoimentoAleatorio = _context.Depoimentos.FirstOrDefault(
                                      depoimento => depoimento.Id == idDepoimentoAleatorio);

            depoimentosAleatorios.Add(depoimentoAleatorio);
        }

        return depoimentosAleatorios;
    }
}
