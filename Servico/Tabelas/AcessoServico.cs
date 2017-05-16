using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL.Tabelas;
using Modelos.Tabelas;

namespace Servico.Tabelas
{
    public class AcessoServico
    {
        private AcessoDAL acessoDAL = new AcessoDAL();

        public void GravarAcesso(Acesso acesso)
        {
            acessoDAL.gravarAcesso(acesso);

        }
        public IQueryable<Acesso> ProcurarTodosAcessos()
        {
            return acessoDAL.procurarTodosAcessos();
        }

        public Acesso AtualizarAcesso(Acesso acesso)
        {
            return acessoDAL.updateAcesso(acesso);
        }

        public Acesso ExcluirAcesso(long id)
        {
            return acessoDAL.excluirAcesso(id);
        }

    }
}
