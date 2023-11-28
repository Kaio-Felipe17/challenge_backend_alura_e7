using System.ComponentModel.DataAnnotations;

namespace AluraAPI.Models;

public class Destino
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string foto { get; set; }
    [Required(ErrorMessage = "O campo nome é obrigatório")]
    public string nome { get; set; }
    [Required(ErrorMessage = "O campo preço é obrigatório")]
    public double preco { get; set; }
}
