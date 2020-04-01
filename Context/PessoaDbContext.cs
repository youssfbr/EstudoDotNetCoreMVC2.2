using EstudoDotNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EstudoDotNetCore.Context
{
    public class PessoaDbContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }

        public PessoaDbContext(DbContextOptions<PessoaDbContext> opts) : base(opts)
        {
                       
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>((builder) => 
            {
                builder.ToTable("PES_PESSOAS");
                builder.Property(p => p.Id).HasColumnName("PES_ID");
                builder.HasKey(p => p.Id);
                builder.Property(p => p.Idade).HasColumnName("PES_IDADE").IsRequired();
                builder.Property(p => p.Nome).HasColumnName("PES_NOME").HasMaxLength(50).IsRequired();
                builder.Property(p => p.Observacoes).HasColumnName("PES_OBSERVACOES").HasMaxLength(200).IsRequired(false);
            });
        }
    }
}