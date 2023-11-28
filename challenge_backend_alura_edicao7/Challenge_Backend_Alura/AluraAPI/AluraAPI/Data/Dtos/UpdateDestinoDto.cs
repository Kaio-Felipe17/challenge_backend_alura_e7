using System.ComponentModel.DataAnnotations;

namespace AluraAPI.Data.Dtos;

public class UpdateDestinoDto
{
    public string foto { get; set; }
    [Required(ErrorMessage = "O campo nome é obrigatório")]
    public string nome { get; set; }
    [Required(ErrorMessage = "O campo preço é obrigatório")]
    public double preco { get; set; }
}
