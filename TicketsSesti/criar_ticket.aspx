<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="criar_ticket.aspx.cs" Inherits="TicketsSesti.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-xs-12">
                <div id="alerta" class="alert alert-warning hidden" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </div>
                <div id="sucessoAlert" class="alert alert-success hidden" runat="server">
                    <asp:Label ID="lblMessageSucess" runat="server" Text=""></asp:Label>
                </div>
                <br />
                <form id="form32" runat="server" class="text-center">
                    <h2 class="form-signin-heading">Abrir Chamado</h2>
                    <label class="sr-only" for="titulo">Titulo do Chamado</label>
                    <asp:TextBox ID="titulo" CssClass="form-control" runat="server" placeholder="Titulo do Chamado"></asp:TextBox>
                    <label class="sr-only" for="descricao">Descrição</label>
                    <asp:TextBox ID="descricao" TextMode="MultiLine" runat="server" Columns="10" Rows="10" CssClass="form-control" placeholder="Descreva o seu problema"></asp:TextBox>
                    <div class="form-group">
                        <asp:Label Text="Arquivo:" runat="server" />
                        <asp:FileUpload ID="uploadAnexo" runat="server" CssClass="form-control"></asp:FileUpload>
                    </div>
                    <br />
                    <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="criarticket" runat="server" Text="Abrir Chamado" OnClick="btnCriarTicket" />
                </form>
            </div>
        </div>
    </div>
</asp:Content>
