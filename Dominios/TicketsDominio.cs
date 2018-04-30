using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominios
{
    public class TicketsDominio
    {
        public void criarTicket(int usuario, string descricao, string titulo, string anexo)
        {
            try
            {
                AtualizacaoDominio atualizacao = new AtualizacaoDominio();

                using (SestiEntities db = new SestiEntities())
                {
                    Tickets tick = new Tickets
                    {
                        Usuario = usuario,
                        Data = DateTime.Now,
                    };

                    db.Tickets.Add(tick);
                    db.SaveChanges();
                    atualizacao.novaAtualizacao((int)tick.id, titulo, descricao, (int) tick.Usuario, 1, anexo);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Tickets pegarTicket(int ticketID)
        {
            try
            {
                Tickets lista = new Tickets();

                using (SestiEntities db = new SestiEntities())
                {
                    lista = (from t in db.Tickets where t.id == ticketID select t).FirstOrDefault();
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Tickets> pegarTickets(int ticket)
        {
            try
            {
                List<Tickets> lista = new List<Tickets>();

                using (SestiEntities db = new SestiEntities())
                {
                    lista = (from t in db.Tickets where t.id == ticket orderby t.Data descending select t).ToList();
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Tickets> listarTickets()
        {
            try
            {
                List<Tickets> lista = new List<Tickets>();

                using (SestiEntities db = new SestiEntities())
                {
                    lista = (from t in db.Tickets orderby t.Data descending select t).ToList();
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }
   
        public List<Tickets> listarTickets(int usuario)
        {
            try
            {
                List<Tickets> lista = new List<Tickets>();

                using (SestiEntities db = new SestiEntities())
                {
                    lista = (from t in db.Tickets where t.Usuario == usuario select t).ToList();
                }
                return lista.OrderBy( d => d.Data ).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

 
}
