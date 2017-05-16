using Modelos.Cadastros;
using Modelos.Tabelas;
using Persistencia.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Persistencia.Contexts
{
   public  class EFContext :DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public EFContext():base ("ARDUINO_PROJETO")
        {
            
      
            Database.SetInitializer<EFContext>(new MigrateDatabaseToLatestVersion<EFContext, Configuration>());
       
    }
        public DbSet<Dispositivo> Dispositivos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Salas> Salas { get; set; }
        public DbSet<Acesso> Acessos { get; set; }
    }
}
