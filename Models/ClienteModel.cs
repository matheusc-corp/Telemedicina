﻿namespace CRUD_Telemedicina.Models
{
    public class ClienteModel
    {
        public int id { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public StatusPaciente Status { get; set; }
    }
}
