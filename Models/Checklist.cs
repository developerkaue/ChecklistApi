namespace ChecklistApi.Models
{
    public class Checklist
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int VeiculoId { get; set; }
        public required Veiculo Veiculo { get; set; }
        public int ExecutorId { get; set; }
        public required Executor Executor { get; set; }
        public int? SupervisorId { get; set; }
        public  Supervisor? Supervisor { get; set; }
        public bool? Aprovado { get; set; }
        public ICollection<ItemChecklist> Itens { get; set; }

    }
}
