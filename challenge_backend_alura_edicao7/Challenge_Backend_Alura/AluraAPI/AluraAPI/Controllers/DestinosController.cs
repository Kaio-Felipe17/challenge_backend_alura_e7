using AluraAPI.Data;
using AluraAPI.Data.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AluraAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class DestinosController : ControllerBase
{
    private DestinoContext _context;
    private IMapper _mapper;

    public DestinosController(DestinoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<ReadDestinoDto> retornaDestinos([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadDestinoDto>>(_context.Destinos.Skip(skip).Take(take));
    }

}
