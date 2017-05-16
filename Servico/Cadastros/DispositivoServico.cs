using Persistencia.DAL.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Cadastros;

namespace Servico.Cadastros
{
     public class DispositivoServico
    {
        private DispositivoDAL dispositivoDAL= new DispositivoDAL();

        public void GravarDispositivos(Dispositivo dispositivo)
        {
            dispositivoDAL.gravarDispositivo(dispositivo);
        }
        
        public IQueryable<Dispositivo> ProcurarTodosDispositivos()
        {
            return dispositivoDAL.procurarTodosDispositivos();
        }

        public Dispositivo AtualizarDispositivo (Dispositivo dispositivo)
        {
            return dispositivoDAL.updateDispositivo(dispositivo);
        }

        public Dispositivo ExcluirDispositivo(long id)
        {
            return dispositivoDAL.excluirDispositivo(id);
        }

    }
}
