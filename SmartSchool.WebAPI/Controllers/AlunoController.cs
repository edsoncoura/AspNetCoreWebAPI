using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public  readonly IRepository _repo;

        public AlunoController(IRepository repo)
        {
            _repo = repo;

        }

        //Foi comentado pois agora está utilziando o bancod e dados vi "context"
        /*  public List<Aluno> Alunos = new List<Aluno>() {
              new Aluno() {
                  Id =1,
                  Nome = "Lucas",
                  Sobrenome = "Teste1",
                  Telefone = "032991956789"
              },
              new Aluno() {
                  Id =2,
                  Nome = "Marta",
                  Sobrenome = "Kent",
                  Telefone = "032888888889"
              },
              new Aluno() {
                  Id =3,
                  Nome = "Marcos",
                  Sobrenome = "TEste2",
                  Telefone = "032777777778"
              },

  };*/

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllAlunos(true);
            return Ok(result);
        }

        // api/aluno/"id" - exemplo api/aluno/1
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            return Ok(aluno);
        }
 
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            
            _repo.Add(aluno);
            if (_repo.SaveChanges())
            {
               return Ok(aluno);                
            }

            return BadRequest("Aluno não cadastrato");

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null) return BadRequest("Aluno não enontrado");


            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
               return Ok(aluno);                
            }

            return BadRequest("Aluno não cadastrato");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {

            var alu = _repo.GetAlunoById(id);
            if (alu == null) return BadRequest("Aluno não enontrado");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
               return Ok(aluno);                
            }

            return BadRequest("Aluno não cadastrato");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null) return BadRequest("Aluno não enontrado");

             _repo.Delete(alu);
            if (_repo.SaveChanges())
            {
               return Ok("Aluno Deletado");                
            }

            return BadRequest("Aluno não deletado");
        }


    }
}