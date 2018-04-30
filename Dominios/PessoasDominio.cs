using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominios
{
    public class PessoasDominio
    {
        public Pessoas selecionar ( string nome )
        {
            try
            {
                Pessoas cara = null;
                using (SestiEntities db = new SestiEntities())
                {
                    cara = (from c in db.Pessoas where c.Nome.Equals(nome) select c).FirstOrDefault();
                }
                return cara;
            }
            catch (Exception)
            {
                throw;
            }
          
        }

        public Pessoas selecionar(int id)
        {
            try
            {
                Pessoas cara = null;
                using (SestiEntities db = new SestiEntities())
                {
                    cara = (from c in db.Pessoas where c.id == id select c).FirstOrDefault();
                }
                return cara;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static int conta()
        {
            try
            {
                List<Pessoas> lista = null;
                using (SestiEntities db = new SestiEntities())
                {
                    lista = (from c in db.Pessoas select c).ToList();
                    db.Dispose();
                }
                return lista.Count();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public string getNome( int caraID )
        {
            try
            {
                Pessoas cara = new Pessoas();

                using (SestiEntities db = new SestiEntities())
                {
                    cara = (from p in db.Pessoas where p.id == caraID select p).FirstOrDefault();
                }
                return (cara != null) ? cara.Nome : "";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void criarConta(string nome, string senha)
        {
            try
            {
                using (SestiEntities db = new SestiEntities())
                {
                    db.Pessoas.Add(new Pessoas { Nome = nome, TipoPessoa = 1, senha = senha });
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
