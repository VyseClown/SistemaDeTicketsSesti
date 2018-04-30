<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="ticket_detalhes.aspx.cs" Inherits="TicketsSesti.WebForm6" %>
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
                <form id="form30" runat="server">
                    <h2 class="form-signin-heading text-left">Responder Ticket</h2>
                    <label class="sr-only" for="titulo">Título da Resposta: </label>
                    <asp:TextBox ID="titulo" runat="server" CssClass="form-control" placeholder="Título"></asp:TextBox>
                    <label class="sr-only" for="mensagem">Resposta</label>
                    <asp:TextBox ID="mensagem" TextMode="MultiLine" CssClass="form-control" Columns="20" Rows="10" runat="server" placeholder="Mensagem:"></asp:TextBox>
                    <br />
                    <div class="form-group">
                        <asp:Label Text="Arquivo:" runat="server" />
                        <asp:FileUpload ID="uploadAnexo" runat="server" CssClass="form-control"></asp:FileUpload>
                    </div>
                    <br />
                    <asp:RadioButton ID="fecharTicket" CssClass="btn btn-danger" Text="&nbsp;Fechar Ticket" runat="server" />
                    &nbsp;
                    <asp:RadioButton ID="abrirTicket" CssClass="btn btn-success" Text="&nbsp;Abrir Ticket" runat="server" />
                    <br />
                    &nbsp;
                    <br />
                    <asp:Button CssClass="btn btn-primary btn-block" ID="entrar" runat="server" Text="Responder" OnClick="btnLoginClick" />
                    <br />
                    &nbsp;
                    <br />
                </form>

                <table class="table">
                    <thead>
                        <tr>
                            <th>#</th>                           
                            <th>D</th>
                            <th>Data</th>
                            <th>Assunto</th>
                            <th>Descrição</th> 
                            <th>Status</th>
                            <th>Usuário</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:ListView runat="server" ID="ListView1">
                            <ItemTemplate>
                                <tr runat="server">
                                    <td runat="server">
                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval( "Ticket" ) %>' />
                                    </td>
                                    <td>
                                        <a href="anexos/<%# Eval("anexo") %>"><span class="<%# (Eval("anexo") != null) ? "glyphicon glyphicon-paperclip" : "hidden" %>"></a>
                                    </td>
                                    <td runat="server">
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("Data") %>' />
                                    </td>
                                    <td runat="server">
                                        <asp:Label ID="NameLabel" runat="server" Text='<%#Eval("Titulo") %>' />
                                    </td>
                                    <td runat="server">
                                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("Descricao") %>' />
                                    </td>
                                    <td runat="server">
                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("status")  %>' />
                                    </td>
                                    <td runat="server">
                                        <%# Eval("usuario") %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

</asp:Content>
