using Dominios;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicketsSesti
{
    public partial class WebForm4 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["pessoaID"] == null)
                Response.Redirect("login.aspx");

            TicketsDominio tick = new TicketsDominio();
            PessoasDominio selecionar = new PessoasDominio();
            Pessoas cara = selecionar.selecionar( int.Parse( Session["pessoaID"].ToString()) );

            if (IsPostBack)
            {
                string tituloT = titulo.Text;
                string descricaoT = descricao.Text;

                if (string.IsNullOrEmpty(tituloT) || string.IsNullOrEmpty(descricaoT))
                {
                    lblMessage.Text = "Preencha todos os campos.";
                    alerta.Attributes["class"] = alerta.Attributes["class"].Replace("hidden", "");
                }
                else
                {
                    String filename = "";

                    if (uploadAnexo.HasFile)
                    {
                        filename = uploadAnexo.FileName;
                        uploadAnexo.SaveAs( Server.MapPath("~/anexos/") + filename );
                    }

                    tick.criarTicket(cara.id, descricaoT, tituloT, filename);
                    
                    Response.Write("Enviado com sucesso !");
                    Response.Redirect("lista_tickets.aspx");
                }
            }
        }

        protected void btnCriarTicket(object sender, EventArgs e)
        {
        }
    }
}