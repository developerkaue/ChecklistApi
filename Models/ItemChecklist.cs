namespace ChecklistApi.Models
{
    public class ItemChecklist
    {
        public int Id { get; set; }
        public int ChecklistId { get; set; }
        public string NomeItem { get; set; }
        public string Observacao { get; set; }
        public bool EmConformidade { get; set; }
        public Checklist Checklist { get; set; }

    }
}

