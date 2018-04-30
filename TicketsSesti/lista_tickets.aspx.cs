using Dominios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicketsSesti
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["pessoaID"] == null)
                Response.Redirect("login.aspx");

            if ( ! IsPostBack )
            {
                TicketsDominio      dom     = new TicketsDominio();
                AtualizacaoDominio  adom    = new AtualizacaoDominio();            
                List<Atualizacao>   listaS  = new List<Atualizacao>();
                PessoasDominio domPessoas   = new PessoasDominio();
                List<Tickets> lista = null;

                Pessoas cara = domPessoas.selecionar( int.Parse( Session["pessoaID"].ToString() ) );

                lista = ( cara.TipoPessoa == 2 ) ? dom.listarTickets( ) : dom.listarTickets(cara.id);

                foreach (Tickets item in lista)
                    listaS.Add( adom.selecionaTicketPai( item.id ) );

                ListView1.DataSource = adom.reescreveLista(listaS);
                ListView1.DataBind();
            }
        }

        protected void verDelhesClick(Object sender, CommandEventArgs e)
        {
            string ticketID = e.CommandArgument.ToString();
            Response.Redirect("ticket_detalhes.aspx?tickID=" + ticketID);
        }
    }
}