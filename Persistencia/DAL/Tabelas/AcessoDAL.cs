using Modelos.Tabelas;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Tabelas
{
    public class AcessoDAL
    {
        private EFContext context = new EFContext();

        public Acesso obterAcessoPorId(long id)
        {
            return context.Acessos.Where(d => d.AcessoId == id).First();
        }


        public void gravarAcesso(Acesso acesso)
        {
            try
            {
                context.Acessos.Add(acesso);
            }

            catch (Exception e)
            {
                context.Entry(acesso).State = EntityState.Modified;
            }
        }


        public Acesso excluirAcesso(long id)
        {
            Acesso acesso = obterAcessoPorId(id);
            context.Acessos.Remove(acesso);
            context.SaveChanges();
            return acesso;
        }


        public IQueryable<Acesso> procurarTodosAcessos()
        {
            return context.Acessos.Include(d => d.AcessoId);
        }


        public Acesso updateAcesso(Acesso acesso)
        {
            var acessos = context.Acessos.Find(acesso.AcessoId);
            try
            {

                if (acessos != null)
                {
                    context.Entry(acessos).CurrentValues.SetValues(acesso);
                    context.SaveChanges();
                }

            }
            catch (Exception e)
            {

            }
            return acessos;

        }
    }
}
