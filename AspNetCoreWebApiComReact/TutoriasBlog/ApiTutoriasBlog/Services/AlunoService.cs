using ApiTutoriasBlog.Context;
using ApiTutoriasBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTutoriasBlog.Services
{
  public class AlunoService : IAlunoService
  {
    private readonly AppDbContext _context;
    public AlunoService(AppDbContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Aluno>> GetAlunos()
    {
      return await _context.Alunos.ToListAsync();
    }

    public async Task<IEnumerable<Aluno>> GetAlunosByName(string nome)
    {
      IEnumerable<Aluno> alunos;
      if (!string.IsNullOrWhiteSpace(nome))
      {
        alunos = await _context.Alunos.Where(x => x.Nome.Contains(nome)).ToListAsync();
      }
      else
      {
        alunos = await GetAlunos();
      }
      return alunos;
    }

    public async Task<Aluno> GetAluno(int id)
    {
      var aluno = await _context.Alunos.FindAsync(id);
      return aluno;
    }

    public async Task CreateAluno(Aluno aluno)
    {
      _context.Alunos.Add(aluno);
      await _context.SaveChangesAsync();
    }

    public async Task UpdateAluno(Aluno aluno)
    {
      _context.Entry(aluno).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAluno(Aluno aluno)
    {
      _context.Alunos.Remove(aluno);
      await _context.SaveChangesAsync();
    }
  }
}
