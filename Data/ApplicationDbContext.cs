using ChecklistApi.Models;
using Microsoft.EntityFrameworkCore;
using ChecklistApi.DTO_s;


namespace ChecklistApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<ItemChecklist> ItensChecklist { get; set; }
        public DbSet<Executor> Executores { get; set; }
        public DbSet<Supervisor> Supervisores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Usando a string de conexão do appsettings.json
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Checklist>()
                .HasOne(c => c.Veiculo)
                .WithMany()
                .HasForeignKey(c => c.VeiculoId);

            modelBuilder.Entity<Checklist>()
                .HasOne(c => c.Executor)
                .WithMany()
                .HasForeignKey(c => c.ExecutorId);

            modelBuilder.Entity<Checklist>()
                .HasOne(c => c.Supervisor)
                .WithMany()
                .HasForeignKey(c => c.SupervisorId);

            modelBuilder.Entity<Checklist>()
                       .HasMany(c => c.Itens)
                       .WithOne(i => i.Checklist) 
                       .HasForeignKey(i => i.ChecklistId) 
                       .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Checklist>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<ItemChecklist>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Checklist>()
                .HasMany(c => c.Itens)
                .WithOne(i => i.Checklist)
                .HasForeignKey(i => i.ChecklistId);

        }
        public DbSet<ChecklistApi.DTO_s.ExecutorDTO> ExecutorDTO { get; set; } = default!;


    }
}
