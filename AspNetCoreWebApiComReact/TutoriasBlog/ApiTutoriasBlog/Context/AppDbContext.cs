using ApiTutoriasBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTutoriasBlog.Context
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Aluno> Alunos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Aluno>().HasData(
        new Aluno
        {
          Id = 1,
          Nome = "Josefina Da Silva",
          Email = "josefina@gmail.com",
          Idade = 20
        },
        new Aluno
        {
          Id = 2,
          Nome = "Marlucio De Oliveira",
          Email = "marlucio@gmail.com",
          Idade = 25
        }
        );

    }
  }
}

