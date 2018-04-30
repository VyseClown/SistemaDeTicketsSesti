using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominios;

namespace TicketsSesti
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ( Session["pessoaID"] != null )
            {
                Response.Redirect("index.aspx");
            }
            
            if (IsPostBack)
            {
                string senha = Request.Form["senha"];
                string login = Request.Form["userLogin"];

                if (senha == "" || login == "")
                {
                    Response.Write("Por favor, digite todos os campos !");
                }
                else
                {
                    
                    PessoasDominio selecionar = new PessoasDominio();
                    Pessoas cara = selecionar.selecionar(login);

                    if (cara == null )
                    {
                        Response.Write("Pessoa não encontrado.");
                    }
                    else if (senha != cara.senha)
                    {
                        Response.Write("Senha incorreta.");
                    }
                    else
                    {
                        Session["pessoaID"] = cara.id;
                        Response.Redirect("index.aspx");
                    }

                }
            }

        }

        protected void btnLoginClick(object sender, EventArgs e)
        {
        }
    }
}