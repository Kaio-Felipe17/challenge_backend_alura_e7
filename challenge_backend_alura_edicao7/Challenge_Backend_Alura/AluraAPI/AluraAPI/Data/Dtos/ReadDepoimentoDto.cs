using System.ComponentModel.DataAnnotations;

namespace AluraAPI.Data.Dtos
{
    public class ReadDepoimentoDto
    {
        public IFormFile foto { get; set; }
        public string depoimento { get; set; }
        public string nome { get; set; }
        public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
    }
}
