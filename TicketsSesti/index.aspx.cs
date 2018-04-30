using Dominios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicketsSesti
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["pessoaID"] == null)         
                Response.Redirect("login.aspx");           

            PessoasDominio dom = new PessoasDominio();
            Pessoas cara = null;

            cara = dom.selecionar( int.Parse(Session["pessoaID"].ToString()) );

            Literal1.Text = cara.Nome;
        }
        public void btnClickSair(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("login.aspx");
        }
    }    
}