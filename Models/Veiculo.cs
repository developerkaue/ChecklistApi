namespace ChecklistApi.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public required string Placa { get; set; }
        public required string Modelo { get; set; }
        public required string Marca { get; set; }
    }
}
