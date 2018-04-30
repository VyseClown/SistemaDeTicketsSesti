using Dominios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicketsSesti
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ( Session["pessoaID"] != null )
                Response.Redirect("index.aspx");

            if (IsPostBack)
            {
                string senha = Request.Form["senha"];
                string login = Request.Form["userLogin"];

                if (senha == "" || login == "")
                {
                    Response.Write("Por favor preencha todos os campos.");
                }
                else
                {
                    PessoasDominio selecionar = new PessoasDominio();
                    Pessoas cara = selecionar.selecionar(login);

                    if (cara == null)
                    {
                        selecionar.criarConta(login, senha);
                        Response.Write("Usuario criado com sucesso !");
                        Response.Redirect("login.aspx");
                    }
                    else
                    {
                        Response.Write("Parece que já existe alguém cadastrado com esses dados.");
                    }

                }
            }
        }

        protected void btnLoginClick(object sender, EventArgs e)
        {
            
        }
    }
}