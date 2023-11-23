using AluraAPI.Data;
using AluraAPI.Data.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Security.Cryptography;
using static System.Net.WebRequestMethods;

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
    public List<int> retornaDepoimentosAleatoriamente()
    {
        int tamanhoLista = _context.Depoimentos.Count();
        List<int> depoimentos = new List<int>();

        for (int i = 0; i <= 2; i++)
        {
            int randomNumber = RandomNumberGenerator.GetInt32(1, tamanhoLista);
            depoimentos.Add();
        }

        //return _mapper.Map<List<ReadDepoimentoDto>>(_context.Depoimentos.Skip(0).Take(3));
        return depoimentos;
    }
}
