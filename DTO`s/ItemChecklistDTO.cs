using ChecklistApi.Models;

namespace ChecklistApi.DTO_s
{
    public class ItemChecklistDTO
    {
        public int Id { get; set; }
        public int ChecklistId { get; set; } // Foreign key reference
        public string NomeItem { get; set; }
        public string Observacao { get; set; }
        public bool EmConformidade { get; set; }
    }
}
