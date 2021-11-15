using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmatSchool.WebAPI.Models;

namespace SmatSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {

                public List<Aluno> Alunos = new List<Aluno>() {
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
                   
        };
        public AlunoController() {}

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        // api/aluno/"id" - exemplo api/aluno/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            return Ok(aluno);
        }

        [HttpGet("ByName")]
        public IActionResult GetByNameId(string nome, string sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(a => 
                a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome)
            );
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            return Ok(aluno);
        }


        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
           return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
           return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
           return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Put(int id)
        {
           return Ok();
        }


    }
}