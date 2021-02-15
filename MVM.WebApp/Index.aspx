<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MVM.WebApp.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <!-- Latest compiled and minified CSS -->
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="alert alert-warning alert-dismissible" role="alert" runat="server" id="alerta"> 
            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <strong>Importante!</strong><asp:Label ID="lblalerta" runat="server" Text=""></asp:Label>
        </div>
        <div class="container col-md-4 col-md-offset-4" style="margin-top:15%">

            <div class="form-horizontal text-center">
                <h3 style="margin-bottom:10%">Iniciar Sesión</h3>
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">User Id</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtUser" cssclass="form-control" placeholder="User Id" runat="server"></asp:TextBox>
                       
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputPassword3" class="col-sm-2 control-label">Password</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtPass" cssclass="form-control" TextMode="Password" placeholder="Password"  runat="server"></asp:TextBox>
                        
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button ID="btnIniciar" CssClass="btn btn-primary" OnClick="btnIniciar_Click" runat="server" Text="Iniciar Sesión" />                  
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
    <!-- Latest compiled and minified JavaScript -->
<script src="https://stackpath.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js" ></script>
</html>
