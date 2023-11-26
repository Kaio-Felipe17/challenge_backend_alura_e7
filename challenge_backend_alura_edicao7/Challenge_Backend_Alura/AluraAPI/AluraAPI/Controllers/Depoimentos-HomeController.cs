using AluraAPI.Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace AluraAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class Depoimentos_HomeController : ControllerBase
{
    private DepoimentoContext _context;
    private IMapper _mapper;

    public Depoimentos_HomeController(DepoimentoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
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
