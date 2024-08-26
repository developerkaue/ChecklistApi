using ChecklistApi.Models;

namespace ChecklistApi.DTO_s
{
    public class ChecklistDTO
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int VeiculoId { get; set; }
        public int ExecutorId { get; set; }
        public int? SupervisorId { get; set; }
        public bool? Aprovado { get; set; }
        public List<ItemChecklistDTO> Itens { get; set; } 
    }
}
