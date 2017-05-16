using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Cadastros;
using System.Data.Entity;

namespace Persistencia.DAL.Cadastros
{
    public class DispositivoDAL
    {
        private EFContext context = new EFContext();
      
        public Dispositivo obterDipositivoPorId(long id)
        {
            return context.Dispositivos.Where(d => d.DispositivoId == id).First();
        }


        public void  gravarDispositivo(Dispositivo dispositivo)
        {
            try
            {
                context.Dispositivos.Add(dispositivo);
                
            }
         
            catch(Exception e)
            {
                context.Entry(dispositivo).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Dispositivo excluirDispositivo(long id)
        {
            Dispositivo dispositivo = obterDipositivoPorId(id);
            context.Dispositivos.Remove(dispositivo);
            context.SaveChanges();
            return dispositivo;
        }

        public IQueryable<Dispositivo> procurarTodosDispositivos()
        {
            return context.Dispositivos.Include(d => d.DispositivoId);
        }

        public Dispositivo updateDispositivo(Dispositivo dispositivo)
        {
            var dispositivos = context.Dispositivos.Find(dispositivo.DispositivoId);
            try
            {
                
                if(dispositivos != null)
                {
                    context.Entry(dispositivos).CurrentValues.SetValues(dispositivo);
                    context.SaveChanges();
                }
                  
            }
            catch(Exception e)
            {
             
            }
            return dispositivos;
           
        }


    }
}
