using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Telemedicina.Models
{
    public class AgendamentoModel
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataAgendamento { get; set; }
        public int IdMedico { get; set; }
        public int IdEspecialidade { get; set; }
        public StatusAgendamento Status { get; set; }

    }
}