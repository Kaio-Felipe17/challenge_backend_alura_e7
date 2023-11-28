namespace AluraAPI.Data.Dtos;

public class ReadDestinoDto
{
    public string foto { get; set; }
    public string nome { get; set; }
    public double preco { get; set; }
    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
}
