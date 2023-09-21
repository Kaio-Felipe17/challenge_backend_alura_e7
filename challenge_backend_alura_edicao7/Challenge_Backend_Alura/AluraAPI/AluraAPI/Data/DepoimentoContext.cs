using AluraAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AluraAPI.Data;

// Classe para configurar a conexão com o banco de dados
public class DepoimentoContext : DbContext
{
    public DepoimentoContext(DbContextOptions<DepoimentoContext> opts)
        : base(opts)
    {
        
    }

    // Propriedade que representa a tabela Depoimentos do banco de dados
    // Representa uma coleção de objetos da classe Depoimentos
    public DbSet<Depoimento> Depoimentos { get; set; } 
}
