<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="lista_tickets.aspx.cs" Inherits="TicketsSesti.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-xs-12">
                <form id="form31" runat="server">
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
                                <th>Detalhes</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:ListView runat="server" ID="ListView1">
                                <ItemTemplate>
                                    <tr runat="server">
                                        <td runat="server">
                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("Ticket") %>' />
                                        </td>

                                        <td>
                                            <a href="anexos/<%# Eval("anexo") %>">
                                                <span class="glyphicon glyphicon-paperclip"></span>
                                            </a>
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
                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("status") %>' />
                                        </td>
                                        <td runat="server">
                                            <%# Eval("usuario") %>
                                        </td>
                                        <td runat="server">
                                            <a href="ticket_detalhes.aspx?tickID=<%#Eval("Ticket") %>" class="btn btn-info">Detalhes</a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                        </tbody>
                    </table>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
