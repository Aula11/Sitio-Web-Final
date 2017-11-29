<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registrar.aspx.cs" Inherits="Registrar" %>

<!DOCTYPE html>

<html >
<head>
	<meta charset="UTF-8">
	<title>Registrar-Aula11</title>



	<link rel="stylesheet" href="Registrar/css/style.css">


    </head>

<body>
	<div id="wrapper">

		<form id="form1" runat="server" class="login-form" method="post">

			<div class="header">
				<h1>Registrar Aula11</h1>
				<span>Rellene el siguiente formulario para poder registrarse y usar los servicios de Aula11</span>
			</div>

			<div class="content">



			    
                <asp:TextBox ID="txtNombre" runat="server" CssClass="input username" placeholder="Nombres" ></asp:TextBox>
                <div class="user-icon" style="top:153px"></div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debes Ingresar tu Nombre" style="z-index: 1; left: 283px; top: 148px; position: absolute" ControlToValidate="txtNombre" ForeColor="Red"></asp:RequiredFieldValidator>
                


                
                <asp:TextBox ID="txtApe_Pa" runat="server" CssClass="input username" placeholder="Apellido Paterno" ></asp:TextBox>
                <div class="user-icon" style="top:207px"></div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debes ingresar tu Apellido Paterno" style="z-index: 1; top: 202px; position: absolute; left: 281px" ControlToValidate="txtApe_Pa" ForeColor="Red"></asp:RequiredFieldValidator>
                

                <asp:TextBox ID="txtApe_Ma" runat="server" CssClass="input username" placeholder="Apellido Materno" ></asp:TextBox>
               <div class="user-icon" style="top:261px"></div>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Debes ingresar tu apellido Materno" style="z-index: 1; left: 282px; top: 256px; position: absolute" ControlToValidate="txtApe_Ma" ForeColor="Red"></asp:RequiredFieldValidator>
                


                <asp:TextBox ID="txtCorreo" runat="server" CssClass="input username" placeholder="Correo Electrónico" ></asp:TextBox>
               <div class="user-icon" style="top:315px"></div>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Debes ingresar tu Correo" style="z-index: 1; left: 283px; top: 311px; position: absolute" ControlToValidate="txtCorreo" ForeColor="Red"></asp:RequiredFieldValidator>
                

                <asp:TextBox ID="txtTelefono" runat="server" CssClass="input username" placeholder="Teléfono/Celular" ></asp:TextBox>
                <div class="user-icon" style="top:369px"></div>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Debes ingresar un Correo válido" style="z-index: 1; left: 283px; top: 313px; position: absolute" ControlToValidate="txtCorreo" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Debes ingresar tu Telèfono/Celular" style="z-index: 1; left: 283px; top: 364px; position: absolute; bottom: 321px;" ControlToValidate="txtTelefono" ForeColor="Red"></asp:RequiredFieldValidator>
                

				<asp:TextBox ID="txtUsuario" runat="server" CssClass="input username" placeholder="Usuario" ></asp:TextBox>
                <div class="user-icon" style="top:423px"></div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Debes ingresar un Usuario" style="z-index: 1; left: 285px; top: 418px; position: absolute" ControlToValidate="txtUsuario" ForeColor="Red"></asp:RequiredFieldValidator>
                
                
                <asp:TextBox ID="txtPassword" runat="server" type="password" CssClass="input password" placeholder="Contraseña"></asp:TextBox>
                <div class="pass-icon"></div>		
                <asp:TextBox ID="txtPassword2" runat="server" type="password" CssClass="input password" placeholder="Confirmar Contraseña"></asp:TextBox>
                <div class="pass-icon"></div>	


			    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Debes ingresar una contraseña" style="z-index: 1; left: 285px; top: 491px; position: absolute" ControlToValidate="txtPassword" ForeColor="Red"></asp:RequiredFieldValidator>
           


			    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtPassword2" ErrorMessage="Las contraseñas deben ser iguales" ForeColor="Red" style="z-index: 1; left: 292px; top: 554px; position: absolute"></asp:CompareValidator>
           


			</div>

			<div class="footer">
			
                <asp:Button ID="Button1" runat="server" Text="Registrarse" CssClass="button" OnClick="Button1_Click" />
                <asp:Button ID="btnRegistrar" runat="server" Text="Iniciar Sesión" CssClass="register" OnClick="btnIniciar_Sesion_Click" />
			    <asp:Label ID="lblUserRepe" runat="server" ForeColor="Red"></asp:Label>
			</div>

		</form>

	</div>
	<div class="gradient"></div>


</body>
</html>