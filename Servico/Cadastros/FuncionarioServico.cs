using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Cadastros;

using Persistencia.DAL.Cadastros;

namespace Servico.Cadastros
{
    public class FuncionarioServico
    {
        private FuncionarioDAL funcionarioDAL = new FuncionarioDAL();

        public void GravarFuncionario(Funcionario funcionario)
        {
            funcionarioDAL.gravarFuncionario(funcionario);
             
        }
        public IQueryable<Funcionario> ProcurarTodosFuncionarios()
        {
            return funcionarioDAL.procurarTodosFuncionarios();
        }

        public Funcionario AtualizarFuncionario(Funcionario funcionario)
        {
            return funcionarioDAL.updateFuncionario(funcionario);
        }

        public Funcionario ExcluirFuncionario(long id)
        {
            return funcionarioDAL.excluirFuncionario(id);
        }

    }
}
