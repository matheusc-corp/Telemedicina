using CRUD_Telemedicina.Context;
using CRUD_Telemedicina.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Telemedicina.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : Controller
    {
        private readonly TelemedicinaContext _context;

        public ClienteController(TelemedicinaContext context)
        {
            _context = context;
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(ClienteModel cliente)
        {
            if (cliente.Cpf == null)
                return BadRequest("CPF nao pode estar vazio");

            if (cliente.Nome == null)
                return BadRequest("Nome nao pode estar vazio");

            if (_context.Clientes.Where(x => x.Cpf == cliente.Cpf).Any())
                return BadRequest("Paciente já cadastrado com este CPF");

            if (_context.Clientes.Where(x => x.Email == cliente.Email).Any())
                return BadRequest("Paciente já cadastrado com este email");

            if (_context.Clientes.Where(x => x.Telefone == cliente.Telefone).Any())
                return BadRequest("Paciente já cadastrado com este telefone");

            cliente.DataCadastro = DateTime.UtcNow;
            cliente.Status = StatusPaciente.Ativo;

            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return Ok(cliente);
        }

        [HttpGet("buscarTodos")]
        public IActionResult BuscarTodos()
        {
            var listaClientes = _context.Clientes.Where(x => x.Id > 0);

            return Ok(listaClientes);
        }

        [HttpGet("buscarPorId")]
        public IActionResult BuscarPorId(int id)
        {
            var cliente = _context.Clientes.Find(id);

            if (cliente == null)
                return NotFound("Paciente não encontrado");

            return Ok(cliente); 
        }

        [HttpGet("buscarPorCpf")]
        public IActionResult BuscarPorCpf(string cpf)
        {
            var cliente = _context.Clientes.Where(x => x.Cpf == cpf);

            if (cliente == null)
                return NotFound("Paciente não encontrado");

            return Ok(cliente);
        }

        [HttpGet("buscarPorEmail")]
        public IActionResult BuscarPorEmail(string email)
        {
            var cliente = _context.Clientes.Where(x => x.Email == email);

            if (cliente == null)
                return NotFound("Paciente não encontrado");

            return Ok(cliente);
        }

        [HttpPut("desativar")]
        public IActionResult DesativarCliente(int id)
        {
            var cliente = _context.Clientes.Find(id);

            if (cliente == null)
                return NotFound("Paciente não encontrado");

            cliente.Status = StatusPaciente.Cancelado;
            _context.Update(cliente);
            _context.SaveChanges();

            return Ok(cliente);
        }
    }
}
