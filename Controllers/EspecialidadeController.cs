using CRUD_Telemedicina.Context;
using CRUD_Telemedicina.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Telemedicina.Controllers
{
    [ApiController]
    [Route("especialidade")]
    public class EspecialidadeController : Controller
    {
        private readonly TelemedicinaContext _context;

        public EspecialidadeController(TelemedicinaContext context)
        {
            _context = context;
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(EspecialidadeModel especialidade)
        {
            _context.Especialidades.Add(especialidade);
            _context.SaveChanges();

            return Ok(especialidade);
        }

        [HttpGet("buscarTodos")]
        public IActionResult BuscarTodos()
        {
            var especialidades = _context.Especialidades.Where(x => x.Id > 0);

            return Ok(especialidades);
        }

        [HttpGet("buscar/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var especialidade = _context.Especialidades.Find(id);

            if (especialidade == null)
                return NotFound("Especialidade nao encontrada");

            return Ok(especialidade);
        }

        [HttpPut("atualizar/{id}")]
        public IActionResult Atualizar(int id, EspecialidadeModel especialidade)
        {
            var especialidadeBanco = _context.Especialidades.Find(id);

            if (especialidadeBanco == null)
                return NotFound("Especialidade nao encontrada");

            especialidadeBanco.Nome = especialidade.Nome;

            _context.Update(especialidadeBanco);
            _context.SaveChanges();

            return Ok(especialidadeBanco);
        }

        [HttpDelete("deletar/{ìd}")]
        public IActionResult Deletar(int id)
        {
            var especialidadeBanco = _context.Especialidades.Find(id);

            if (especialidadeBanco == null)
                return NotFound("Especialidade nao encontrada");

            _context.Remove(especialidadeBanco);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
