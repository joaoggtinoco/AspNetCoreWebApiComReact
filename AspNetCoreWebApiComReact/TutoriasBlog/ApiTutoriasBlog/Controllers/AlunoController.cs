using ApiTutoriasBlog.Models;
using ApiTutoriasBlog.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTutoriasBlog.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  //[Produces("application/json")]
  public class AlunoController : ControllerBase
  {
    private IAlunoService _alunoService;

    public AlunoController(IAlunoService alunoService)
    {
      _alunoService = alunoService;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunos()
    {
      try
      {
        var alunos = await _alunoService.GetAlunos();
        return Ok(alunos);
      }
      catch
      {
        //return BadRequest("Request inválido");
        return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter alunos");
      }
    }
    [HttpGet("AlunosPorNome")]
    public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunosByName([FromQuery] string nome)
    {
      try
      {
        var alunosByName = await _alunoService.GetAlunosByName(nome);
        if (alunosByName.Count() == 0)
          return NotFound($"Não foi encontrado nenhum aluno com o critério {nome}.");
        return Ok(alunosByName);
      }
      catch
      {
        return BadRequest("Request inválido.");
      }
    }

    [HttpGet("{id:int}", Name = "GetAluno")]
    public async Task<ActionResult<Aluno>> GetAluno(int id)
    {
      try
      {
        var alunoPorId = await _alunoService.GetAluno(id);
        if (alunoPorId == null)
          return NotFound($"Não foi encontrado nenhum aluno com o ID: {id}.");
        return Ok(alunoPorId);
      }
      catch
      {
        return BadRequest("Request inválido.");
      }
    }

    [HttpPost]
    public async Task<ActionResult> CreateAluno(Aluno aluno)
    {
      try
      {
        await _alunoService.CreateAluno(aluno);
        return CreatedAtRoute(nameof(GetAluno), new { id = aluno.Id }, aluno);
      }
      catch
      {
        return BadRequest("Request inválido.");
      }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateAluno(int id, [FromBody] Aluno aluno)
    {
      try
      {
        if (aluno.Id == id)
        {
          await _alunoService.UpdateAluno(aluno);
          //return NoContent();
          return Ok($"Aluno com id: {id} foi atualizado com sucesso.");
        }
        else
        {
          return BadRequest("Dados inconsistentes");
        }
      }
      catch
      {
        return BadRequest("Request inválido.");
      }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAluno(int id)
    {
      try
      {
        var aluno = await _alunoService.GetAluno(id);
        if (aluno != null)
        {
          await _alunoService.DeleteAluno(aluno);
          return Ok($"Aluno com ID: {id} deletado com sucesso.");
        }
        else
        {
          return NotFound($"Não foi encontrado nenhum aluno com ID: {id}.");
        }
      }
      catch
      {
        return BadRequest("Request inválido.");
      }
    }


  }
}

