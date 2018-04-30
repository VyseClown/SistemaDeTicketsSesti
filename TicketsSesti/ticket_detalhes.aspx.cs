using Dominios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicketsSesti
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["pessoaID"] == null)
                Response.Redirect("login.aspx");
               
            int ticketID = int.Parse( Request.QueryString["tickID"].ToString() );

            PessoasDominio domPessoas = new PessoasDominio();
            AtualizacaoDominio adom = new AtualizacaoDominio();
            TicketsDominio tickDom = new TicketsDominio();
            List<Atualizacao> listaS = new List<Atualizacao>();

            Pessoas cara = domPessoas.selecionar( int.Parse(Session["pessoaID"].ToString()) );
            Tickets ticket = tickDom.pegarTicket(ticketID);

            if (ticket == null || cara.id != ticket.Usuario && cara.TipoPessoa != 2)
                Response.Redirect("index.aspx");

            listaS = adom.listarTickets(ticketID);

            ListView1.DataSource = adom.reescreveLista(listaS);
            ListView1.DataBind();

            if ( IsPostBack )
            {             

                string descricao = mensagem.Text;
                string titulos = titulo.Text;

                if (titulos == "" || descricao == "")
                {
                    lblMessageSucess.Text = "Por favor preencha todos os campos.";
                    sucessoAlert.Attributes["class"] = alerta.Attributes["class"].Replace("hidden", "");
                }
                else
                {
                    String filename = "";

                    if (uploadAnexo.HasFile)
                    {
                        filename = Path.GetFileName(uploadAnexo.FileName);
                        uploadAnexo.SaveAs(Server.MapPath("~/anexos/") + filename);
                    }

                    adom.novaAtualizacao(ticketID, titulos, descricao, cara.id, filename);

                    if (fecharTicket.Checked == true)
                        adom.fecharTicketsPorID( ticketID );

                    if (abrirTicket.Checked == true)
                        adom.abrirTicketsPorID(ticketID);

                    mensagem.Text = "";
                    titulo.Text = "";

                    lblMessageSucess.Text = "Resposta enviada com sucesso.";
                    sucessoAlert.Attributes["class"] = sucessoAlert.Attributes["class"].Replace("hidden", "");
                    Response.AddHeader("REFRESH", "5;URL=lista_tickets.aspx");
                }
            }

        }
        protected void btnLoginClick(object sender, EventArgs e)
        {
           
        }
    }
}