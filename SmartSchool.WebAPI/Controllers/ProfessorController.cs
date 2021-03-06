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
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;

        public ProfessorController(IRepository repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllProfessores(true);
            return Ok(result);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id, false);
            if (professor == null) return BadRequest("O Professor não foi encontrado");
            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                 return Ok(professor);
            }
            
            return BadRequest("Professor não Cadastrado");
        }
        

        [HttpPut("{id}")]

        public IActionResult Put(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id, false);
            if (prof == null) return BadRequest("O Professor não foi encontrado");

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
            return Ok(professor);
            }
             return BadRequest("Professor não Alterado");
        }

        [HttpPatch("{id}")]

        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _repo.GetAlunoById(id, false);
            if (prof == null) return BadRequest("O Professor não foi encontrado");

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
            return Ok(professor);
            }
            return BadRequest("Professor não Alterado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prof = _repo.GetAlunoById(id, false);
            if (prof == null) return BadRequest("O Professor não foi encontrado");

            _repo.Delete(prof);
            if (_repo.SaveChanges())
            {
            return Ok(prof);
            }
            return BadRequest("Professor não Deletado");
           

        }




    }
}