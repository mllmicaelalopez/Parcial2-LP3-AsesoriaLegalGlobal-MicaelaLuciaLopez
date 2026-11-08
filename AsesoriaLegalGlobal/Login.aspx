<%@ Page Title="Iniciar sesión - Asesoría Legal Global" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AsesoriaLegalGlobal.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tarjeta formulario">
        <h1>Iniciar sesión</h1>

        <asp:Label ID="lblMensaje" runat="server" CssClass="mensaje"></asp:Label>

        <div class="campo">
            <asp:Label ID="lblUsuario" runat="server" Text="Nombre de usuario" AssociatedControlID="txtUsuario"></asp:Label>
            <asp:TextBox ID="txtUsuario" runat="server" MaxLength="20"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario"
                ErrorMessage="Ingresá tu nombre de usuario." Display="Dynamic" CssClass="error"></asp:RequiredFieldValidator>
        </div>

        <div class="campo">
            <asp:Label ID="lblPassword" runat="server" Text="Contraseña" AssociatedControlID="txtPassword"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="30"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                ErrorMessage="Ingresá tu contraseña." Display="Dynamic" CssClass="error"></asp:RequiredFieldValidator>
        </div>

        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="boton" OnClick="btnIngresar_Click" />

        <p class="aclaracion">¿No tenés cuenta? <asp:HyperLink ID="lnkRegistro" runat="server" NavigateUrl="~/Registro.aspx">Registrate acá</asp:HyperLink></p>
    </div>

</asp:Content>
