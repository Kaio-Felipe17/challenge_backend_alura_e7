using System.ComponentModel.DataAnnotations;

namespace AluraAPI.Models
{
    public class Depoimento
    {
        public int Id { get; set; }
        public string foto { get; set; }
        [Required(ErrorMessage = "O campo depoimento é obrigatório")]
        public string depoimento { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string nome { get; set; }
    }
}
