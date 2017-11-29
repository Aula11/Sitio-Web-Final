<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html >

<html >
<head runat="server">
  <meta charset="UTF-8">
  <title>Iniciar Sesión-Aula11</title>
  
  
  
      <link rel="stylesheet" href="Login/css/style.css">

  
</head>

<body>
    
  <div id="wrapper">

	  <form id="form1" runat="server" class="login-form" method="post">
	
		<div class="header">
		<h1>Iniciar Sesión</h1>
		<span>Rellene el formulario para iniciar sesión con Aula11.</span>
		</div>
	
		<div class="content">

            <asp:TextBox ID="txtUsuario" runat="server" CssClass="input username" placeholder="Usuario" ></asp:TextBox><div class="user-icon"></div>
            <asp:TextBox ID="txtPassword" runat="server" type="password" CssClass="input password" placeholder="Contraseña"></asp:TextBox>
           
          <div class="pass-icon"></div>		
		</div>

		<div class="footer">
		
            <asp:Button ID="btnEntrar" runat="server" Text="Ingresar" CssClass="button" OnClick="btnEntrar_Click" />
            <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" CssClass="register" OnClick="btnRegistrar_Click" />
           
            <asp:Label ID="lblError" runat="server" style ="position: absolute; top: 322px; left: 21px; height: 24px; width: 86px;" ForeColor="Red"></asp:Label>
           
            <asp:Label ID="lblError2" runat="server" style ="position: absolute; top: 357px; left: 22px; width: 88px;" ForeColor="Red" ></asp:Label>
            <asp:Label ID="lblError3" runat="server" style ="position: absolute; top: 394px; left: 23px; width: 84px;" ForeColor="Red" ></asp:Label>
           
          </div>
		
	
	  </form>

</div>
<div class="gradient"></div>
  

</body>
</html>
