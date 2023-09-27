using System.ComponentModel.DataAnnotations;

namespace AluraAPI.Data.Dtos;

public class UpdateDepoimentoDto
{
    public string foto { get; set; }
    [Required(ErrorMessage = "O campo depoimento é obrigatório")]
    public string depoimento { get; set; }
    [Required(ErrorMessage = "O campo nome é obrigatório")]
    public string nome { get; set; }
}
