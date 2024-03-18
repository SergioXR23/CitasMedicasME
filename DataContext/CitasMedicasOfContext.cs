using CitasMedicasME.Models.Entitys;
using Microsoft.EntityFrameworkCore;

namespace CitasMedicasME.Data
{
    public class CitasMedicasContext : DbContext
    {
        public CitasMedicasContext(DbContextOptions<CitasMedicasContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; } = default!;
        public DbSet<Paciente> Pacientes { get; set; } = default!;
        public DbSet<Medico> Medicos { get; set; } = default!;
        public DbSet<Cita> Citas { get; set; } = default!;
        public DbSet<Diagnostico> Diagnosticos { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          base.OnModelCreating(modelBuilder);

         // Configuración de la herencia TPT para Paciente y Medico
         modelBuilder.Entity<Paciente>().ToTable("Pacientes");
         modelBuilder.Entity<Medico>().ToTable("Medicos");
         modelBuilder.Entity<Cita>()
            .HasOne(c => c.Paciente)
            .WithMany(p => p.Citas)
            .HasForeignKey(c => c.PacienteId)
            .OnDelete(DeleteBehavior.Restrict); 

        modelBuilder.Entity<Cita>()
             .HasOne(c => c.Medico)
             .WithMany(m => m.Citas)
             .HasForeignKey(c => c.MedicoId)
             .OnDelete(DeleteBehavior.Restrict);



         modelBuilder.Entity<Diagnostico>()
            .HasOne(d => d.Cita)
            .WithOne(c => c.Diagnostico)
            .HasForeignKey<Diagnostico>(d => d.Id)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
