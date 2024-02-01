using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Telemedicina.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Telemedicina.Context
{
    public class TelemedicinaContext : DbContext
    {
        // // "Desenv"
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TELEMEDICINA");
        }

        // // "Producao"
        //public TelemedicinaContext(DbContextOptions<TelemedicinaContext> options) : base(options) { }


        public DbSet<MedicoModel> Medicos { get; set; }
        public DbSet<EspecialidadeModel> Especialidades { get; set; }
        public DbSet<AgendamentoModel> Agendamentos { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }



    }
}