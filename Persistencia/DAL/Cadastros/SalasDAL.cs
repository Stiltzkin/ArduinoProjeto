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
    public class SalasDAL
    {
        private EFContext context = new EFContext();

        public Salas obterSalasPorId(long id)
        {
            return context.Salas.Where(d => d.SalaId == id).First();
        }


        public void gravarSala(Salas sala)
        {
            try
            {
                context.Salas.Add(sala);
            }

            catch (Exception e)
            {
                context.Entry(sala).State = EntityState.Modified;
            }
        }


        public Salas excluirSala(long id)
        {
            Salas sala = obterSalasPorId(id);
            context.Salas.Remove(sala);
            context.SaveChanges();
            return sala;
        }

        public IQueryable<Salas> procurarTodasAsSalas()
        {
            return context.Salas.Include(d => d.SalaId);
        }

        public Salas updateSala(Salas sala)
        {
            var salas = context.Salas.Find(sala.SalaId);
            try
            {

                if (salas != null)
                {
                    context.Entry(salas).CurrentValues.SetValues(sala);
                    context.SaveChanges();
                }

            }
            catch (Exception e)
            {

            }
            return salas;

        }
    }
}
