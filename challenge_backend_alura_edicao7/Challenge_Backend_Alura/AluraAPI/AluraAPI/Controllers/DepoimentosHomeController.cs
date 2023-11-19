using AluraAPI.Data;
using AluraAPI.Data.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace AluraAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DepoimentosHomeController : ControllerBase
{
    private DepoimentoContext _context;
    private IMapper _mapper;
    public DepoimentosHomeController(DepoimentoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<ReadDepoimentoDto> retornaDepoimentosAleatoriamente([FromQuery] int skip = 0, [FromQuery] int take = 3)
    {
        return _mapper.Map<List<ReadDepoimentoDto>>(_context.Depoimentos.Skip(skip).Take(take));
    }
}
