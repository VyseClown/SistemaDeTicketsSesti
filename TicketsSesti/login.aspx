<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TicketsSesti.login" %>

<!DOCTYPE html>

<html lang="pt-br">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>SESTI Login</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css">
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <div class="container">
        <form id="form1" runat="server" class="form-signin text-center">
            <h2 class="form-signin-heading text-left">Entrar</h2>
            <label class="sr-only" for="email">Endereço de E-mail</label>
            <asp:TextBox ID="userLogin" CssClass="form-control" runat="server"  placeholder="Login"></asp:TextBox>
            <label class="sr-only" for="senha">Senha</label>
            <asp:TextBox ID="senha" TextMode="Password" runat="server" CssClass="form-control" placeholder="Senha"></asp:TextBox>
            <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="entrar" runat="server" Text="Entrar" OnClick="btnLoginClick" />
            <a href="cadastro.aspx">Criar Conta.</a>            
        </form>
    </div>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</body>
</html>
