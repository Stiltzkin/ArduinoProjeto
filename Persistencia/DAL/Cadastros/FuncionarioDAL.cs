using Modelos.Cadastros;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Cadastros
{
    public class FuncionarioDAL
    {
        private EFContext context = new EFContext();

        public Funcionario obterFuncionarioPorId(long id)
        {
            return context.Funcionarios.Where(d => d.FuncionarioId == id).First();
        }


        public void gravarFuncionario(Funcionario funcionario)
        {
            try
            {
                context.Funcionarios.Add(funcionario);
            }

            catch (Exception e)
            {
                context.Entry(funcionario).State = EntityState.Modified;
            }
        }


        public Funcionario excluirFuncionario(long id)
        {
            Funcionario funcionario = obterFuncionarioPorId(id);
            context.Funcionarios.Remove(funcionario);
            context.SaveChanges();
            return funcionario;
        }

        public IQueryable<Funcionario> procurarTodosFuncionarios()
        {
            return context.Funcionarios.Include(d => d.FuncionarioId);
        }

        public Funcionario updateFuncionario(Funcionario funcionario)
        {
            var funcionarios = context.Funcionarios.Find(funcionario.FuncionarioId);
            try
            {

                if (funcionarios != null)
                {
                    context.Entry(funcionarios).CurrentValues.SetValues(funcionario);
                    context.SaveChanges();
                }

            }
            catch (Exception e)
            {

            }
            return funcionarios;

        }


    }
}
