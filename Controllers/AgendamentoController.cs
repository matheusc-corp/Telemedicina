using CRUD_Telemedicina.Context;
using CRUD_Telemedicina.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CRUD_Telemedicina.Controllers
{
    [ApiController]
    [Route("agendamento")]
    public class AgendamentoController : Controller
    {
        private readonly TelemedicinaContext _context;

        public AgendamentoController(TelemedicinaContext context)
        {
            _context = context;
        }

        [HttpPost("agendar")]
        public IActionResult Agendar(AgendamentoModel agendamento)
        {
            if (_context.Medicos.Find(agendamento.IdMedico) == null)
                return NotFound("Medico nao encontrado");

            if (_context.Medicos.Find(agendamento.IdEspecialidade) == null)
                return NotFound("Especialidade nao encontrada");

            agendamento.DataCadastro = DateTime.UtcNow;
            agendamento.DataAtualizacao = DateTime.UtcNow;
            agendamento.Status = StatusAgendamento.Pendente;

            _context.Agendamentos.Add(agendamento);
            _context.SaveChanges();

            return Ok(agendamento);
        }

        [HttpGet("buscarTodos")]
        public IActionResult BuscarTodos()
        {
            var listaAgendamentos = _context.Agendamentos.Where(x => x.Id > 0);

            return Ok(listaAgendamentos);
        }

        [HttpGet("buscar/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var agendamento = _context.Agendamentos.Find(id);

            if (agendamento == null)
                return NotFound();

            return Ok(agendamento);
        }

        [HttpGet("buscar/idMedico/{idMedico}")]
        public IActionResult BuscarPorMedico(int idMedico) {
            var medicoBanco = _context.Medicos.Find(idMedico);

            if (medicoBanco == null)
                return NotFound("Medico nao encontrado pelo id informado");

            var listaAgendamentos = _context.Agendamentos.Where(x => x.IdMedico == medicoBanco.Id);

            return Ok(listaAgendamentos);
        }

        [HttpPut("alterar/{id}")]
        public IActionResult Alterar(int id, AgendamentoModel agendamento)
        {
            var agendamentoBanco = _context.Agendamentos.Find(id);

            if (agendamentoBanco == null)
                return NotFound();

            agendamentoBanco.DataAtualizacao = DateTime.UtcNow;
            agendamentoBanco.DataAgendamento = agendamento.DataAgendamento;
            agendamentoBanco.IdMedico = agendamento.IdMedico;
            agendamentoBanco.IdEspecialidade = agendamento.IdEspecialidade;
            agendamentoBanco.Status = agendamento.Status;

            _context.Agendamentos.Update(agendamentoBanco);
            _context.SaveChanges();
            return Ok(agendamentoBanco);
        }

        [HttpPut("finalizar/{id}")]
        public IActionResult FinalizarAgendamento(int id)
        {
            var agendamentoBanco = _context.Agendamentos.Find(id);

            if (agendamentoBanco == null)
                return NotFound();

            agendamentoBanco.Status = StatusAgendamento.Finalizado;
            agendamentoBanco.DataAtualizacao = DateTime.UtcNow;

            _context.Agendamentos.Update(agendamentoBanco);
            _context.SaveChanges();
            return Ok(agendamentoBanco);
        }

        [HttpPut("cancelar/{id}")]
        public IActionResult CancelarAgendamento(int id)
        {
            var agendamentoBanco = _context.Agendamentos.Find(id);

            if (agendamentoBanco == null)
                return NotFound();

            agendamentoBanco.Status = StatusAgendamento.Cancelado;
            agendamentoBanco.DataAtualizacao = DateTime.UtcNow;

            _context.Agendamentos.Update(agendamentoBanco);
            _context.SaveChanges();
            return Ok(agendamentoBanco);
        }

        [HttpPost("reagendar/{id}")]
        public IActionResult reagendar(int id, AgendamentoModel agendamento)
        {
            var agendamentoBanco = _context.Agendamentos.Find(id);

            if (agendamentoBanco == null)
                return NotFound();

            if (_context.Medicos.Find(agendamento.IdMedico) == null)
                return NotFound("Medico nao encontrado");

            if (_context.Medicos.Find(agendamento.IdEspecialidade) == null)
                return NotFound("Especialidade nao encontrada");

            agendamento.DataCadastro = DateTime.UtcNow;
            agendamento.DataAtualizacao = DateTime.UtcNow;
            agendamento.Status = StatusAgendamento.Pendente;

            agendamentoBanco.Status = StatusAgendamento.Reagendado;
            agendamentoBanco.DataAtualizacao = DateTime.UtcNow;

            _context.Agendamentos.Add(agendamento);
            _context.Agendamentos.Update(agendamentoBanco);
            _context.SaveChanges();
            return Ok(agendamento);
        }
    }
}