using Modelos.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modelos.Cadastros
{
    public class Funcionario
    {
        public long FuncionarioId {get;set;}
        public String Nome { get; set; }
        public virtual Acesso Acesso { get; set; }
        public long Token { get; set; }

    }
}