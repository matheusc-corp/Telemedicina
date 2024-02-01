using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Telemedicina.Context;
using CRUD_Telemedicina.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Telemedicina.Controllers
{
    [ApiController]
    [Route("medico")]
    public class MedicoController : Controller
    {
        private readonly TelemedicinaContext _context;

        public MedicoController(TelemedicinaContext context)
        {
            _context = context;
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(MedicoModel medico)
        {
            _context.Medicos.Add(medico);
            _context.SaveChanges();
            return Ok(medico);
        }

        [HttpGet("buscarTodos")]
        public IActionResult BuscarTodos()
        {
            var medicos = _context.Medicos.Where(x => x.Id > 0);

            return Ok(medicos);
        }

        [HttpGet("buscar/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var medico = _context.Medicos.Find(id);

            if (medico == null)
                return NotFound("Medico nao encontrado");

            return Ok(medico);
        }

        [HttpPut("atualizar/{id}")]
        public IActionResult Atualizar(int id, MedicoModel medico)
        {
            var medicoBanco = _context.Medicos.Find(id);

            if (medicoBanco == null)
                return NotFound("Medico nao encontrada");

            medicoBanco.Nome = medico.Nome;
            medicoBanco.Crm = medico.Crm;

            _context.Update(medicoBanco);
            _context.SaveChanges();

            return Ok(medicoBanco);
        }

        [HttpDelete("deletar/{ìd}")]
        public IActionResult Deletar(int id)
        {
            var medicoBanco = _context.Medicos.Find(id);

            if (medicoBanco == null)
                return NotFound("Medico nao encontrada");

            _context.Remove(medicoBanco);
            _context.SaveChanges();

            return NoContent();
        }
    }
}