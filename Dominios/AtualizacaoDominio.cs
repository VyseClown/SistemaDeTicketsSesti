using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominios
{
    public class AtualizacaoDominio
    {

        public void abrirTicketsPorID(int ticketID)
        {
            try
            {
                using (SestiEntities db = new SestiEntities())
                {
                    db.Atualizacao
                         .Where(a => a.Ticket == ticketID)
                         .ToList()
                         .ForEach(a => a.status = 0);

                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void fecharTicketsPorID(int ticketID)
        {
            try
            {
                using (SestiEntities db = new SestiEntities())
                {
                    db.Atualizacao
                        .Where(a => a.Ticket == ticketID)
                        .ToList()
                        .ForEach(a => a.status=1);

                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
               throw;
            }
        }
        /// <summary>
        /// Nesse metodo eu passo o ID do técnico
        /// </summary>
        public void novaAtualizacao(int ticketID, string titulo, string descricao, int usuarioID, int tecnicoID, string anexo )
        {
            try
            {
                using (SestiEntities dba = new SestiEntities())
                {
                    dba.Atualizacao.Add(new Atualizacao {
                        Ticket = ticketID,
                        Titulo = titulo,
                        Descricao = descricao,
                        Data = DateTime.Now,
                        Usuario = usuarioID,
                        Tecnico = tecnicoID,
                        status = 0,
                        Anexo = anexo,
                    } );
                    dba.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Nesse metodo eu não passo o ID do técnico
        /// </summary>
        public void novaAtualizacao(int ticketID, string titulo, string descricao, int usuarioID, string anexo)
        {
            try
            {
                PessoasDominio domPessoas = new PessoasDominio();
                Pessoas cara = domPessoas.selecionar(usuarioID);

                using (SestiEntities dba = new SestiEntities())
                {
                    dba.Atualizacao.Add(new Atualizacao
                    {
                        Ticket = ticketID,
                        Titulo = titulo,
                        Descricao = descricao,
                        Data = DateTime.Now,
                        Usuario = cara.id,
                        Tecnico = (cara.TipoPessoa == 2) ? cara.id : 0,
                        status = 0,
                        Anexo = anexo,
                    });
                    dba.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Atualizacao selecionaTicketPai(int ticketID)
        {
            try
            {
                Atualizacao atualizacao = new Atualizacao();

                using (SestiEntities db = new SestiEntities())
                {
                    atualizacao = (from a in db.Atualizacao where a.Ticket == ticketID orderby a.Data ascending select a).First();
                }
                return atualizacao;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Atualizacao> listarTicketsPai(int ticketID)
        {
            try
            {
                List<Atualizacao> lista = new List<Atualizacao>();

                using (SestiEntities db = new SestiEntities())
                {
                    lista = (from a in db.Atualizacao where a.Ticket == ticketID && a.id == a.Ticket select a).ToList();
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Atualizacao> listarTickets()
        {
            try
            {
                List<Atualizacao> lista = new List<Atualizacao>();

                using (SestiEntities db = new SestiEntities())
                {
                    lista = (from a in db.Atualizacao orderby a.Data descending select a).ToList();
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Atualizacao> listarTickets(int ticketID)
        {
            try
            {
                List<Atualizacao> lista = new List<Atualizacao>();

                using (SestiEntities db = new SestiEntities())
                {
                    lista = (from a in db.Atualizacao where a.Ticket == ticketID orderby a.Data descending select a).ToList();
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<object> reescreveLista(List<Atualizacao> listaS)
        {
            try
            {
                List<object> listaFinal = new List<object>();
                foreach (var item in listaS)
                {
                    PessoasDominio itemPessoaDom = new PessoasDominio();
                    Pessoas itemUsuario = new Pessoas();
                    Pessoas itemTecnico = new Pessoas();

                    listaFinal.Add(new
                    {
                        id = item.id,
                        Ticket = item.Ticket,
                        Titulo = item.Titulo,
                        Descricao = item.Descricao,
                        Data = item.Data,
                        Usuario = itemPessoaDom.getNome((int)item.Usuario),
                        Tecnico = itemPessoaDom.getNome((int)item.Tecnico),
                        status = item.status == 0 ? "Aberto" : "Fechado",
                        Anexo = item.Anexo,
                    });
                }
                return listaFinal;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
