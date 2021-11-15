using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SmatSchool.WebAPI.Models;

namespace SmatSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {

        public ProfessorController() {}

        [HttpGet]
        public IActionResult Get()
        {
             return Ok("Professores: Marta, Paulo");
        }


    }
}