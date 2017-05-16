using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL.Cadastros;
using Modelos.Cadastros;
namespace Servico.Cadastros
{
    public class SalaServico
    {
        private SalasDAL salasDAL = new SalasDAL();

        public void GravarSalas(Salas salas)
        {
            salasDAL.gravarSala(salas);

        }
        public IQueryable<Salas> ProcurarTodosSalas()
        {
            return salasDAL.procurarTodasAsSalas();
        }

        public Salas AtualizarSalas(Salas salas)
        {
            return salasDAL.updateSala(salas);
        }

        public Salas ExcluirSalas(long id)
        {
            return salasDAL.excluirSala(id);
        }
    }
}
